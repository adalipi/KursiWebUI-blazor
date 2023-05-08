using Microsoft.AspNetCore.Mvc;

namespace KursiWebUI.Data
{
    public class AuthService : IAuthService
    {
        private readonly IApiService _apiService;

        public AuthService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<TokenDTO> LoginAsync(string username, string password)
        {
            return await _apiService.HttpPOST<TokenDTO>("Auth/Login", new { username, password });
        }
    }
}
