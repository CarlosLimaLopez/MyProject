using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class GatewayModel
    {
        public string Serial { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Ip { get; set; }
        public string Port { get; set; }
    }
}
