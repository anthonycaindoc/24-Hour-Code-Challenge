namespace PizzaSales.Core.Features.Token.Queries.GetToken
{
    public class GetTokenVM
    {
        public string Scheme { get; set; }
        public string AccessToken { get; set; }
        public long ExpiresIn { get; set; }
    }
}
