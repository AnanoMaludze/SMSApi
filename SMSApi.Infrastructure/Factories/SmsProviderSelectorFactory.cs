using SMSApi.Domain.Interfaces;
using SMSApi.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApi.Infrastructure.Factories
{
    public class SmsProviderSelectorFactory : ISmsProviderSelectorFactory
    {
        private readonly RandomProviderSelector _randomProviderSelector;
        private readonly PercentProviderSelector _percentProviderSelector;

        public SmsProviderSelectorFactory(
            RandomProviderSelector randomProviderSelector,
            PercentProviderSelector percentProviderSelector)
        {
            _randomProviderSelector = randomProviderSelector;
            _percentProviderSelector = percentProviderSelector;
        }

        public ISmsProviderSelector CreateSelector(string selectionLogic)
        {
            return selectionLogic switch
            {
                "Percentage" => _percentProviderSelector,
                "Random" => _randomProviderSelector,
                _ => throw new ArgumentException($"Unknown selection logic: {selectionLogic}")
            };
        }
    }
}
