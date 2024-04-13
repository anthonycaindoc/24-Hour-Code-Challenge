using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSales.Infrastructure.Configurations
{
    public class TokenConfiguration
    {
        public string CLIENT_ID { get; set; }
        public string CLIENT_SECRET { get; set; }
        public string SECRET_KEY { get; set; }
        public string AUDIENCE { get; set; }
        public string ISSUER { get; set; }
        public int EXPIRY_HOURS { get; set; }
        public bool VALIDATE_LIFETIME { get; set; }
    }
}
