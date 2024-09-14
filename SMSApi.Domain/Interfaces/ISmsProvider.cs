using SMSApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApi.Domain.Interfaces
{
    public interface ISmsProvider
    {
        Task<bool> SendSmsAsync(SMSMessage message);
        string GetProviderName();
    }
}
