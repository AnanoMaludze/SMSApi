using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApi.Application.DTOs
{
    public class SmsMessageDto
    {
        public string Phone { get; set; }
        public string Text { get; set; }
    }
}
