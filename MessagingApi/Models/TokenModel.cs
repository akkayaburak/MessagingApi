namespace MessagingApi.Models
{
    public class TokenModel
    {
        public TokenModel(string userToken, int userId)
        {
            UserToken = userToken;
            UserId = userId;
        }
        public string UserToken { get; set; }

        public int UserId { get; set; }
    }
}
