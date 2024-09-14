using SMSApi.Application.DTOs;
using SMSApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApi.Application.Interfaces
{
    public interface ISmsService
    {
        Task<bool> SendMessageAsync(SmsMessageDto messageDto, string selectionLogic);

    }
}
