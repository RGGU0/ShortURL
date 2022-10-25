using Microsoft.AspNetCore.Mvc;
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
                while ((hash > 0)&&(newhash.Length < 8))
                {
                    int temp = hash * 17 % 123;
                    if (((temp > 64)&&(temp < 92))||((temp > 97) && (temp < 124)))
                    {
                        newhash += (char)temp;
                    }
                    else 
                    {
                        newhash += Convert.ToString(temp);
                    }
                    hash /= 123;
                } 
                if(newhash == "") newhash = Convert.ToString(this.LongUrl.GetHashCode());
                newhash = newhash.Substring(1);
                return newhash;
            }
            else
            {
                return null;
            }
        }
    }
}
