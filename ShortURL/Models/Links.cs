using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ShortURL.Models
{
    public class Links
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string LongUrl { get; set; }
        public int Created { get; set; }
        public string ShortUrl { get; set; }
        public int Clicks { get; set; }
    }
}
