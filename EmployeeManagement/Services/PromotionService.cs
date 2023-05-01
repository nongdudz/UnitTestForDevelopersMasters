using EmployeeManagement.Model;
using EmployeeManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly HttpClient _httpClient;
        private readonly IEmployeeRepository _employeegementRepository;
        public PromotionService(HttpClient httpClient, IEmployeeRepository employeegementRepository)
        {
            _httpClient = httpClient;
            _employeegementRepository = employeegementRepository;
        }

        public async Task<bool> PromoteInternalEmployeeAsync(InternalEmployee employee)
        {
            if (await CheckIfInternalEmployeeIsEligibleForPromotion(employee.EmployeeId))
            {
                employee.JobLevel++;
                await _employeegementRepository.SaveChangesAsync();
                return true;
            }
            return false;
        }

        private async Task<bool> CheckIfInternalEmployeeIsEligibleForPromotion(
            int employeeId)
        {
            // call into API
            var apiRoot = "http://localhost:5057";

            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{apiRoot}/api/promotioneligibilities/{employeeId}");
            request.Headers.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // deserialize content
            var content = await response.Content.ReadAsStringAsync();
            var promotionEligibility = JsonSerializer.Deserialize<PromotionEligibility>(content,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            // return value
            return promotionEligibility == null ?
                false : promotionEligibility.EligibleForPromotion;
        }
    }
}
