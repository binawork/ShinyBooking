using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ShinyBooking.Auth;
using ShinyBooking.Models;
using Newtonsoft.Json;

namespace ShinyBooking.Helpers
{
    public class Tokens
    {
        public static async Task<string> GenerateJwt(ClaimsIdentity identity, IJwtFactory jwtFactory, string userName, JwtIssuerOptions jwtOptions, JsonSerializerSettings serializerSettings)
        {
            ResponseToken response = new ResponseToken
            {
                Id = identity.Claims.Single(c => c.Type == "id").Value,
                UserName = identity.Name,
                AuthToken = await jwtFactory.GenerateEncodedToken(userName, identity),
                ExpiresIn = (int)jwtOptions.ValidFor.TotalSeconds
            };

            return JsonConvert.SerializeObject(response, serializerSettings);
        }

        public static ResponseToken DeGenerateJwt(string token)
        {
            var deserialize = JsonConvert.DeserializeObject<ResponseToken>(token);

            return deserialize;


        }
    }
}
