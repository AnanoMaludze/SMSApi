using SMSApi.Application.DTOs;
using SMSApi.Application.Interfaces;
using SMSApi.Domain.Entities;
using SMSApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApi.Application.Services
{
    public class SmsService : ISmsService
    {
        private readonly SMSApi.Domain.Services.SmsService _domainSmsService;
        private readonly ISmsProviderSelectorFactory _providerSelectorFactory;

        public SmsService(SMSApi.Domain.Services.SmsService domainSmsService, ISmsProviderSelectorFactory providerSelectorFactory)
        {
            _domainSmsService = domainSmsService;
            _providerSelectorFactory = providerSelectorFactory;
        }

        public async Task<bool> SendMessageAsync(SmsMessageDto messageDto, string selectionLogic)
        {
            var smsMessage = new SMSMessage(messageDto.Phone, messageDto.Text);

            var providerSelector = _providerSelectorFactory.CreateSelector(selectionLogic);

            return await _domainSmsService.SendMessageAsync(smsMessage, selectionLogic);
        }
    }
}
