using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bank4Us.ServiceApp.Filters;
using Bank4Us.Common.CanonicalSchema;
using Bank4Us.BusinessLayer.Managers.MortgageApplicantManagement;
using Bank4Us.Common.Facade;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Bank4Us.ServiceApp.Controllers
{

    /// <summary>
    ///   Course Name: MSCS 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Ziwei Huang
    ///   Description: Example implementation of a Service App with MVC           
    /// </summary>
    /// 
    [LoggingActionFilter]
    [Route("api/[controller]")]
    public class MortgageApplicantController : BaseController
    {
         
        MortgageApplicantManager _manager;
        ILogger<MortgageApplicantController> _logger;

        public MortgageApplicantController(IMortgageApplicantManager manager, ILogger<MortgageApplicantController> logger) : base(manager, logger)
        {
            _manager = (MortgageApplicantManager)manager;
            _logger = logger;
        }

        [TransactionActionFilter()]
        [HttpGet]
        [Route("baseentities")]
        public IActionResult GetAllBaseEntities()
        {
            try
            {
                var items = _manager.GetAll();
                return new OkObjectResult(items);

            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }

        [TransactionActionFilter()]
        [HttpGet]
        [Route("mortgageapplicants")]
        public IActionResult GetAllMortgageApplicants()
        {
            try
            {
                var items = _manager.GetAllMortgageApplicants();
                return new OkObjectResult(items);

            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }


        [TransactionActionFilter()]
        [HttpPost]
        public IActionResult Post([FromBody] MortgageApplicant applicant)
        {
            try
            {
                _manager.Create(applicant);
                return new OkObjectResult(_manager.BusinessRuleNotifications);

            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }
        [TransactionActionFilter()]
        [HttpPut]
        public IActionResult Put(MortgageApplicant applicant)
        {
            try
            {
                _manager.Update(applicant);
                return new OkObjectResult(_manager.BusinessRuleNotifications);

            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }

        [TransactionActionFilter()]
        [HttpDelete]
        public IActionResult Delete(MortgageApplicant applicant)
        {
            try
            {
                _manager.Delete(applicant);
                return new OkResult();

            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }


        [TransactionActionFilter()]
        [HttpGet]
        [Route("mortgageapplicants/{applicantId}")]
        public IActionResult GetApplicantsByapplicantId(int applicantId)
        {
            try
            {
                var applicant = _manager.GetMortgageApplicant(applicantId);
                if (applicant != null)
                {
                    return new OkObjectResult(applicant);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }


    }
}

      