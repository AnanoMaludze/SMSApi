using SMSApi.Domain.Entities;
using SMSApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApi.Domain.Services
{
    public class SmsService
    {
        private readonly ISmsProviderSelectorFactory _providerSelectorFactory;
        private readonly IEnumerable<ISmsProvider> _providers;

        public SmsService(ISmsProviderSelectorFactory providerSelectorFactory, IEnumerable<ISmsProvider> providers)
        {
            _providerSelectorFactory = providerSelectorFactory;
            _providers = providers;
        }

        public async Task<bool> SendMessageAsync(SMSMessage message, string selectionLogic)
        {
            Console.WriteLine($"Starting SMS send process for {message.PhoneNumber}");
            Console.WriteLine($"Using selection logic: {selectionLogic}");

            var providerSelector = _providerSelectorFactory.CreateSelector(selectionLogic);

            var selectedProvider = providerSelector.SelectProvider(_providers);

            Console.WriteLine($"Selected provider: { selectedProvider.GetProviderName()}");

            var result = await selectedProvider.SendSmsAsync(message);
            if (result)
            {
                Console.WriteLine($"SMS sent successfully to {message.PhoneNumber} via {selectedProvider.GetProviderName()}");
            }
            else
            {
                Console.WriteLine($"Failed to send SMS to {message.PhoneNumber} via { selectedProvider.GetProviderName()}");
            }

            return result;
        }
    }
}
