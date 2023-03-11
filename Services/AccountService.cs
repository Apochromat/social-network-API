using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using social_network_API.Models;
using social_network_API.Models.DTO;
using social_network_API.Models.Enum;

namespace social_network_API.Services;
/// <summary>
/// Users account management service
/// </summary>
public class AccountService : IAccountService {
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly ILogger<AccountService> _logger;
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    /// <summary>
    /// Users account management service
    /// </summary>
    public AccountService(ILogger<AccountService> logger, ApplicationDbContext context,
        UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager,
        IConfiguration configuration, IMapper mapper) {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _logger = logger;
        _context = context;
        _configuration = configuration;
        _mapper = mapper;
    }

    /// <summary>
    /// Register a new user
    /// </summary>
    public async Task<TokenResponse> Register(UserRegisterModel userRegisterModel) {
        if (userRegisterModel.Email == null) {
            throw new ArgumentNullException(nameof(userRegisterModel.Email));
        }

        if (userRegisterModel.Password == null) {
            throw new ArgumentNullException(nameof(userRegisterModel.Password));
        }

        if (await _userManager.FindByEmailAsync(userRegisterModel.Email) != null)
            throw new InvalidOperationException("User with this email already exists");

        User user = _mapper.Map<User>(userRegisterModel);

        var result = await _userManager.CreateAsync(user, userRegisterModel.Password);
        if (result.Succeeded) {
            _logger.LogInformation("Successful register");

            await _userManager.AddToRoleAsync(user, ApplicationRoleNames.User);

            return await Login(new LoginCredentials
                { Email = userRegisterModel.Email, Password = userRegisterModel.Password });
        }

        var errors = string.Join(", ", result.Errors.Select(x => x.Description));
        throw new ArgumentException(errors);
    }

    /// <summary>
    /// Deletes an user if it exists
    /// </summary>
    public async Task<String> DeleteUser(string email) {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null) return "There is no user with this email";

        await _userManager.DeleteAsync(user);

        return "User was deleted successfully";
    }

    /// <summary>
    /// Log user in
    /// </summary>
    public async Task<TokenResponse> Login(LoginCredentials loginCredentials) {
        if (loginCredentials.Password == null || loginCredentials.Email == null) throw new ArgumentNullException();
        var identity = await GetIdentity(loginCredentials.Email.ToLower(), loginCredentials.Password);
        if (identity == null) {
            throw new ArgumentException("Incorrect username or password");
        }

        var now = DateTime.UtcNow;
        var jwt = new JwtSecurityToken(
            issuer: JwtConfiguration.Issuer,
            audience: JwtConfiguration.Audience,
            notBefore: now,
            claims: identity.Claims,
            expires: now.Add(TimeSpan.FromMinutes(JwtConfiguration.Lifetime)),
            signingCredentials: new SigningCredentials(JwtConfiguration.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));

        _logger.LogInformation("Successful login");

        return new TokenResponse {
            Token = new JwtSecurityTokenHandler().WriteToken(jwt),
            Email = identity.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault(""),
            Roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList()
        };
    }

    /// <summary>
    /// Returns user`s profile
    /// </summary>
    public async Task<UserProfile> GetProfile(string email) {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null) throw new KeyNotFoundException("User not found");

        user = _userManager.Users.Where(u => u.Email == email).Include(u => u.Roles)!
            .ThenInclude(r => r.Role)
            .First();

        _logger.LogInformation("User`s profile was returned successfuly");
        return _mapper.Map<UserProfile>(user);
    }

    /// <summary>
    /// Edit user`s profile
    /// </summary>
    public async Task<String> EditProfile(string email, UserProfileEdit userProfileEdit) {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null) throw new KeyNotFoundException("User not found");
        
        user.FullName = userProfileEdit.FullName == null ? user.FullName : Regex.Replace(userProfileEdit.FullName, @"\s+", " ");
        user.Birthdate = userProfileEdit.Birthdate;
        user.Status = userProfileEdit.Status ?? user.Status;
        user.Bio = userProfileEdit.Bio ?? user.Bio;
        user.ProfileImage = userProfileEdit.ProfileImage ?? user.ProfileImage;
        user.BackgroundImage = userProfileEdit.BackgroundImage ?? user.BackgroundImage;
        user.Discord = userProfileEdit.Discord ?? user.Discord;
        user.Telegram = userProfileEdit.Telegram ?? user.Telegram;
        
        await _context.SaveChangesAsync();

        _logger.LogInformation("User`s profile was modified successfully");

        return "User`s profile was modified successfully";
    }

    private async Task<ClaimsIdentity?> GetIdentity(string email, string password) {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null) {
            return null;
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
        if (!result.Succeeded) return null;

        var claims = new List<Claim> {
            new Claim(ClaimTypes.Name, user.Email ?? "")
        };

        foreach (var role in await _userManager.GetRolesAsync(user)) {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        return new ClaimsIdentity(claims, "Token", ClaimTypes.Name, ClaimTypes.Role);
    }
}