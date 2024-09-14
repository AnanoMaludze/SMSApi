using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApi.Domain.Entities
{
    public class Provider
    {
        public string Name { get; set; }
        public string ApiUrl { get; set; }
        public bool IsActive { get; set; }

        public Provider(string name, string apiUrl, bool isActive = true)
        {
            Name = name;
            ApiUrl = apiUrl;
            IsActive = isActive;
        }
    }
}
