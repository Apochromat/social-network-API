using social_network_API.Models.DTO;

namespace social_network_API.Services; 

public interface IAccountService {
    Task<TokenResponse> Register(UserRegisterModel userRegisterModel);
    Task<String> DeleteUser(string email);
    Task<TokenResponse> Login(LoginCredentials loginCredentials);
    Task<UserProfile> GetProfile(string email);
    Task<String> EditProfile(string email, UserProfileEdit userProfileEdit);
}