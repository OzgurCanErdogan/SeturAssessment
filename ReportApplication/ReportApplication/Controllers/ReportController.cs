using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReportApplication.Data;
using ReportApplication.Dtos;
using ReportApplication.Models;
using ReportApplication.Services;
using System.Collections;

namespace ReportApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        private IReportRepo _repository;
        private IMapper _mapper;
        private readonly IReportService _messageBusClient;

        public ReportController(IReportRepo repository, IMapper mapper, IReportService messageBusClient)
        {
            _repository = repository;
            _mapper = mapper;
            _messageBusClient = messageBusClient;
        }

        [HttpPost(Name = "CreateReport")]
        [Route("~/api/[controller]/CreateReport")]
        public async Task<ActionResult> CreateReport()
        {
            Report report = new Report();
            report.Status = ReportStatus.InProgress;
            report.RequestDateTime = DateTime.Now.ToUniversalTime();
            _repository.CreateReport(report);
            
            //Send Async Message
            try
            {
                ReportDetailsPublishedDto dto = new ReportDetailsPublishedDto();
                dto.Id = report.Id;
                dto.Event = "ReportRequested";

                _messageBusClient.PublishNewReportDetails(dto);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"--> Could not send asynchronously: {ex.Message}");
            }
            
            return Ok();
        }

        [HttpGet(Name = "GetReport")]
        [Route("~/api/[controller]/GetReport/{reportId}")]
        public async Task<ActionResult> GetReport(Guid reportId)
        {
            Report report = _repository.GetReportById(reportId);

            if(report.Status != ReportStatus.Created)
            {
                return NotFound();
            }

            ReportDetails reportDetails = _repository.GetReportDetailsById(reportId);
            if(reportDetails == null)
            {
                return NotFound();
            }

            return File(reportDetails.ReportByte, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [HttpGet(Name = "GetCompletedReports")]
        [Route("~/api/[controller]/GetCompletedReports")]
        public ActionResult GetCompletedReports()
        {
            var reports = _repository.GetAllReportsWithCompletedStatus();
            if(reports == null)
                return NotFound();


            return Ok(_mapper.Map<IEnumerable<ReportsReadDto>>(reports));
        }
    }
}
