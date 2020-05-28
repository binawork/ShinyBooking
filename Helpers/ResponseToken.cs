using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShinyBooking.Helpers
{
    public class ResponseToken
    {
        [JsonProperty(PropertyName = "id")]
        public string Id {get; set; }
         [JsonProperty(PropertyName = "userName")]
        public string UserName {get; set; }
         [JsonProperty(PropertyName = "auth_token")]
        public string AuthToken {get; set; }
         [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn {get; set; }




    }
}
