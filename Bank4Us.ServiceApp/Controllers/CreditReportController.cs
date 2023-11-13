using Bank4Us.BusinessLayer.Managers.CreditReportManagement;
using Bank4Us.Common.CanonicalSchema;
using Bank4Us.Common.Facade;
using Bank4Us.ServiceApp.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

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
    public class CreditReportController : BaseController
    {
        CreditReportManager _manager;
        ILogger<CreditReportManager> _logger;

        public CreditReportController(CreditReportManager manager, ILogger<CreditReportManager> logger) : base(manager, logger)
        {
            _manager = (CreditReportManager)manager;
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
        [Route("creditreports")]
        public IActionResult GetAllCreditReports()
        {
            try
            {
                var items = _manager.GetAllCreditReports();
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
        public IActionResult Post([FromBody] CreditReport report)
        {
            try
            {
                _manager.Create(report);
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
        public IActionResult Put(CreditReport report)
        {
            try
            {
                _manager.Update(report);
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
        public IActionResult Delete(CreditReport report)
        {
            try
            {
                _manager.Delete(report);
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
        [Route("creditreports/{reportId}")]
        public IActionResult GetCreditReportByreportId(int reportId)
        {
            try
            {
                var report = _manager.GetCreditReport(reportId);
                if (report != null)
                {
                    return new OkObjectResult(report);
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
