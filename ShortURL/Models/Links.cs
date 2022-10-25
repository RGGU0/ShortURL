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

        public string GetHash()
        {
            int hash;
            if (this.LongUrl != null)
            {
                hash = this.LongUrl.GetHashCode();
                string newhash = "";
                while (hash != 0)
                {
                    newhash += hash % 100 * 17;
                    hash /= 100;
                }
                return newhash;
            }
            else
            {
                return null;
            }
        }
    }
}
