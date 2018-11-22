using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAST_Alumni_Portal.Models
{
    public class TokenResponse
    {
        [JsonProperty(PropertyName = "access_token")]
        public string Access_token { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public int Expires_in { get; set; }

    }
}