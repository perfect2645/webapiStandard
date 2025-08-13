namespace WebapiStandard.Services.Auth
{
    public interface ITokenService
    {
        string GenerateToken(string username);
        Task<string> GenerateTokenAsync(string username);
    }
}
