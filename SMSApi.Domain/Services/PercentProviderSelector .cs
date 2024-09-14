using SMSApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApi.Domain.Services
{
    public class PercentProviderSelector : ISmsProviderSelector
    {
        private readonly Dictionary<string, double> _providerPercentages;

        public PercentProviderSelector(Dictionary<string, double> providerPercentages)
        {
            _providerPercentages = providerPercentages;
        }

        public ISmsProvider SelectProvider(IEnumerable<ISmsProvider> providers)
        {
            var activeProviders = providers?.Where(p => p != null).ToList();
            if (activeProviders == null || !activeProviders.Any())
            {
                throw new Exception("No active providers available.");
            }

            double roll = new Random().NextDouble();
            double cumulative = 0.0;

            foreach (var provider in activeProviders)
            {
                if (_providerPercentages.TryGetValue(provider.GetProviderName(), out var percentage))
                {
                    cumulative += percentage / 100.0;
                    if (roll <= cumulative)
                    {
                        return provider;
                    }
                }
            }

            throw new Exception("Failed to select provider based on percentage.");
        }
    }
}
