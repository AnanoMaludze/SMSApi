using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApi.Domain.Entities
{
    public class SMSMessage
    {
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public DateTime SentDate { get; set; }
        public string Provider { get; set; }

        public SMSMessage(string phoneNumber, string message)
        {
            PhoneNumber = phoneNumber;
            Message = message;
            SentDate = DateTime.Now;
        }
    }
}
