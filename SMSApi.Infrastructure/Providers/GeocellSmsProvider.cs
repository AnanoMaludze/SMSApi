using SMSApi.Domain.Entities;
using SMSApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SMSApi.Infrastructure.Providers
{
    public class GeocellSmsProvider : ISmsProvider
    {
        private readonly HttpClient _httpClient;

        public GeocellSmsProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public string GetProviderName()
        {
            return "Geocell";
        }

        public async Task<bool> SendSmsAsync(SMSMessage message)
        {
            Console.WriteLine("Geocell");
            return true;
        }
    }
}
