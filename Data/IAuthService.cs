using Microsoft.AspNetCore.Mvc;

namespace KursiWebUI.Data
{
    public interface IAuthService
    {
        Task<TokenDTO> LoginAsync (string username, string password);
    }
}
