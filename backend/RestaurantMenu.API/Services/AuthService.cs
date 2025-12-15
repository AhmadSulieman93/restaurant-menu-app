using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestaurantMenu.API.Data;
using RestaurantMenu.API.Models;
using RestaurantMenu.API.Models.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;

namespace RestaurantMenu.API.Services;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthService(ApplicationDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<LoginResponse> RegisterAsync(RegisterRequest request)
    {
        // Check if user exists
        if (await _context.Users.AnyAsync(u => u.Email == request.Email))
        {
            throw new InvalidOperationException("Email already exists");
        }

        // Hash password
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        // Create user
        var user = new User
        {
            Email = request.Email,
            PasswordHash = passwordHash,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Phone = request.Phone,
            Role = Enum.Parse<UserRole>(request.Role.ToUpper()),
            Status = UserStatus.ACTIVE
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        // Generate token
        var token = GenerateJwtToken(user);

        return new LoginResponse
        {
            Token = token,
            UserId = user.Id,
            Email = user.Email,
            Role = user.Role.ToString()
        };
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        try
        {
            Console.WriteLine($"Attempting to query database for user: {request.Email}");
            
            // Test database connection first
            try
            {
                var canConnect = await _context.Database.CanConnectAsync();
                Console.WriteLine($"Database connection test: {canConnect}");
            }
            catch (Exception connEx)
            {
                Console.WriteLine($"Database connection test failed: {connEx.GetType().Name} - {connEx.Message}");
                throw new Exception($"Cannot connect to database. Please check your database connection. Error: {connEx.Message}", connEx);
            }
            
            var user = await _context.Users
                .Include(u => u.Restaurants)
                .FirstOrDefaultAsync(u => u.Email == request.Email);
            
            Console.WriteLine($"User query completed. User found: {user != null}");

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid email or password");
            }

            if (user.Status != UserStatus.ACTIVE)
            {
                throw new UnauthorizedAccessException("Account is not active");
            }

            var token = GenerateJwtToken(user);
            var restaurantId = user.Restaurants.FirstOrDefault()?.RestaurantId;

            return new LoginResponse
            {
                Token = token,
                UserId = user.Id,
                Email = user.Email,
                Role = user.Role.ToString(),
                RestaurantId = restaurantId
            };
        }
        catch (System.Net.Sockets.SocketException ex) when (ex.Message.Contains("The requested name is valid, but no data of the requested type was found"))
        {
            throw new Exception("Database connection failed. Please check your database connection string and network.", ex);
        }
        catch (Npgsql.NpgsqlException ex)
        {
            throw new Exception($"Database error: {ex.Message}. Please check your database connection.", ex);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Login error: {ex.GetType().Name} - {ex.Message}");
            Console.WriteLine($"Full exception: {ex}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"Inner exception type: {ex.InnerException.GetType().Name}");
                Console.WriteLine($"Inner exception message: {ex.InnerException.Message}");
                Console.WriteLine($"Inner exception stack: {ex.InnerException.StackTrace}");
            }
            throw;
        }
    }

    public async Task<UserResponse?> GetUserByIdAsync(string userId)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null) return null;

        return new UserResponse
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Role = user.Role.ToString(),
            Status = user.Status.ToString()
        };
    }

    public async Task<bool> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null || !BCrypt.Net.BCrypt.Verify(currentPassword, user.PasswordHash))
        {
            return false;
        }

        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
        await _context.SaveChangesAsync();

        return true;
    }

    private string GenerateJwtToken(User user)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["SecretKey"] ?? throw new InvalidOperationException("JWT SecretKey not configured");
        var key = Encoding.UTF8.GetBytes(secretKey);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(int.Parse(jwtSettings["ExpirationMinutes"] ?? "60")),
            Issuer = jwtSettings["Issuer"],
            Audience = jwtSettings["Audience"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}

