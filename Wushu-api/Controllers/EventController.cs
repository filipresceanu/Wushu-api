using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using OfficeOpenXml;
using System.Collections.ObjectModel;
using System.Drawing;
using Wushu_api.Dto;
using Wushu_api.Models;
using Wushu_api.Services;

namespace Wushu_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IParticipantService _participantService;

        public EventController(IEventService eventService,IParticipantService participantService)
        {
            _eventService = eventService;
           _participantService= participantService;
        }

        [HttpPut("add-event")]
        public async Task<ActionResult>AddEvent(EventDto competition)
        {
            var _competition = new Event {

                Name = competition.Name,
                Date = competition.Date,
                Categories = new Collection<Category>()

                 };

            await _eventService.CreateEvent(_competition);
            return Ok("Success");
        }
        [HttpGet("get-event")]
        public async Task<ActionResult<IEnumerable<EventDto>>>GetEvents()
        {
            var _competition=await _eventService.GetEvents();
            return Ok(_competition);
        }

        [HttpPut("add-in-competition/{id}")]
        public async Task<ActionResult>AddParticipantsInCompetition(Guid id,
            ParticipantDto participantDto)
        {
            string result=await _participantService.AddParticipantsInCompetition(id,
                participantDto);
            if(string.IsNullOrEmpty(result))
            {
                return BadRequest("There is no category for this participant");
            }
            return Ok("success");
        }

        [HttpGet("export_to_excel")]
        public async Task<ActionResult>ExportParticipant(Guid competitionId)
        {
            var participants=await _participantService.GetParticipantsInCompetitionId(competitionId);
            var competition=await _eventService.GetEvent(competitionId);
            var stream = new MemoryStream();

            using(var xlPackage=new ExcelPackage(stream))
            {
                var worksheet=xlPackage.Workbook.Worksheets.Add("Participants");

                var customStyle = xlPackage.Workbook.Styles.CreateNamedStyle("CustomStyle");
                customStyle.Style.Font.UnderLine = true;
                customStyle.Style.Font.Color.SetColor(Color.Red);

                var startRow = 5;
                var row = startRow;

                worksheet.Cells["A1"].Value="Title"+competition.Name;
                using (var r = worksheet.Cells["A1:E1"])
                {
                    r.Merge = true;
                    r.Style.Font.Color.SetColor(Color.Green);
                    r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    r.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 93));
                }

                worksheet.Cells["A4"].Value = "Name";
                worksheet.Cells["B4"].Value = "Club";
                worksheet.Cells["C4"].Value = "Data_Nasterii";
                worksheet.Cells["D4"].Value = "Sex";
                worksheet.Cells["E4"].Value = "Categoria_de_greutate";
                worksheet.Cells["A4:E4"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                worksheet.Cells["A4:E4"].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

                row = 5;
                foreach(var participant in participants)
                {
                    worksheet.Cells[row, 1].Value = participant.Name;
                    worksheet.Cells[row, 2].Value = participant.Club;
                    worksheet.Cells[row, 3].Value = participant.BirthDay.ToString("dd-MM-yyyy");
                    worksheet.Cells[row, 4].Value = participant.Sex;
                    worksheet.Cells[row, 5].Value = participant.CategoryWeight;
                    
                    row++;
                }
                xlPackage.Workbook.Properties.Title = "participanti";
                xlPackage.Workbook.Properties.Author = "User";

                xlPackage.Save();
            }
            stream.Position = 0;

            return File(stream, "application/vnd.openxmlformats-officedocument.spredsheetml.sheet", "participanti.xlsx");
        }

        [HttpPut("upload-in-competition")]
        public async Task<ActionResult>ImportParticipant(Guid id,IFormFile file)
        {
            if(file?.Length > 0)
            {
                //convert to a stream
                var stream=file.OpenReadStream();
                var participants=new List<ParticipantDto>();

                try
                {
                    using(var package=new ExcelPackage(stream))
                    {
                        var worksheet=package.Workbook.Worksheets.First();
                        var rowCount = worksheet.Dimension.Rows;

                        for(var row=2;row<=rowCount; row++)
                        {
                            try
                            {
                                var name = worksheet.Cells[row, 1].Value?.ToString();
                                var club = worksheet.Cells[row, 2].Value?.ToString();
                                var birthday = Convert.ToDateTime( worksheet.Cells[row, 3].Value?.ToString());
                                var sex = worksheet.Cells[row, 4].Value?.ToString();
                                var categoryWeight =Convert.ToInt32( worksheet.Cells[row, 5].Value?.ToString());

                                var participant = new ParticipantDto()
                                {
                                    Name = name,
                                    Club = club,
                                    BirthDay = birthday,
                                    Sex = sex,
                                    CategoryWeight = categoryWeight
                                };
                                participants.Add(participant);

                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                    foreach(var participant in participants)
                    {
                        await _participantService.AddParticipantsInCompetition(id, participant);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
            return Ok("success");
            
            
        }


        [HttpGet("participants-for-specific/{competitionId}")]
        public async Task<ActionResult<IEnumerable<ParticipantDto>>>GetParticipantForCompetition(Guid competitionId)
        {
            var participants=await _participantService.GetParticipantsInCompetitionId(competitionId);
            return Ok(participants);
        }


    }
}
