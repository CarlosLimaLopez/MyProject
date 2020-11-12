using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Infrastructure.Entities
{
    public class Gateway
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int g_id { get; set; }
        [Key]
        public string g_serial { get; set; }
        public string g_brand { get; set; }
        public string g_model { get; set; }
        public string g_ip { get; set; }
        public string g_port { get; set; }

        public Device Devices { get; set; }
    }
}
