using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Infrastructure.Entities
{
    public class Counter
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int c_id { get; set; }
        [Key]
        public string c_serial { get; set; }
        public string c_brand { get; set; }
        public string c_model { get; set; }
        public string c_type { get; set; }

        public Device Devices { get; set; }
    }
}
