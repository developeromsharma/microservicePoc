using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthService.Domain.Interfaces;
using AuthService.Infrastructure.RabbitMQ;
using System.Net;
using AuthService.Domain.Entities;

namespace AuthService.Application.Services
{
    public class AuthCheckService : IAuthCheckService
    {
        private readonly HttpClient _httpClient;
        private readonly IRabbitMqService _rabbitService;

        public AuthCheckService(HttpClient httpClient, IRabbitMqService rabbitService)
        {
            _httpClient = httpClient;
            _rabbitService = rabbitService;
        }

        public async Task<EligibilityResult> IsEligibleAsync(int userId, int assetId)
        {
            var userResponse = await _httpClient.GetAsync($"https://localhost:7247/api/User/{userId}");
            var assetResponse = await _httpClient.GetAsync($"https://localhost:7060/api/Assets/{assetId}");

            bool isEligible = userResponse.StatusCode == HttpStatusCode.OK && assetResponse.StatusCode == HttpStatusCode.OK;

            var message = new EligibilityResult { IsEligibleForTransaction = isEligible };

            await _rabbitService.SendMessageAsync("dafult", message);
            await _rabbitService.SendMessageAsync("isEligibleForTransaction", message);

            return message;
        }
    }

}
