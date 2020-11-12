using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Infrastructure.Entities
{
    public class Device
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int d_id { get; set; }
        [Key]
        public string d_serial { get; set; }

        public Counter Counters { get; set; }
        public Gateway Gateways { get; set; }
    }
}
