using SMSApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApi.Domain.Services
{
    public class RandomProviderSelector : ISmsProviderSelector
    {
        private static readonly Random _random = new Random();

        public ISmsProvider SelectProvider(IEnumerable<ISmsProvider> providers)
        {
            var activeProviders = providers?.Where(p => p != null).ToList();
            Console.WriteLine($"Number of active providers: {activeProviders.Count}" );  

            if (!activeProviders.Any())
            {
                Console.WriteLine("No active providers available.");
                throw new Exception("No active providers available.");
            }

            var index = _random.Next(activeProviders.Count);
            var selectedProvider = activeProviders[index];

            Console.WriteLine($"Selected provider: {selectedProvider.GetProviderName()}"); 

            return selectedProvider;
        }
    }
}
