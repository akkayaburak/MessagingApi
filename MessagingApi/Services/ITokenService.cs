using MessagingApi.Entities;

namespace MessagingApi.Services
{
    public interface ITokenService
    {
        void Save(Token token);

        void Delete(int id);

        Token IsAuthenticated(string token);
    }
}
