using EmployeeManagement.Model;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class PromotionsController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IPromotionService _promotionService;
        public PromotionsController(IEmployeeService employeeService, IPromotionService promotionService)
        {
            _employeeService = employeeService;
            _promotionService = promotionService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePromotion(PromotionForCreationDto promotionForCreation)
        {
            var internalEmployeeToPromote = await _employeeService
                .FetchInternalEmployeeAsync(promotionForCreation.EmployeeId);

            if (internalEmployeeToPromote == null)
            {
                return BadRequest();
            }

            if (await _promotionService.PromoteInternalEmployeeAsync(internalEmployeeToPromote))
            {
                return Ok(new PromotionResultDto()
                {
                    EmployeeId = internalEmployeeToPromote.EmployeeId,
                    JobLevel = internalEmployeeToPromote.JobLevel
                });
            }
            else
            {
                return BadRequest("Employee not eligible for promotion.");
            }
        }
    }
}
