using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using VisaApplicationSysWeb.Data;
using VisaApplicationSysWeb.Models;

namespace VisaApplicationSysWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisaAPIController : ControllerBase
    {

        private readonly VisaDBContext _dbContext;

        public VisaAPIController(VisaDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // POST api/VisaAPI/CustomPost
        [HttpPost("CustomPost")]
        public IActionResult CustomPost([FromBody] string value)
        {
            // Do something with the posted data (in this case, just return it)
            // You can customize the response based on your needs
            return Ok(new { Message = "Post request successful", Data = value });
        }

        [HttpPost("PostStudentVisa")]
        public IActionResult PostStudentVisa([FromForm] StudentVisaForm model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var studentProfile = new StudentVisaForm
                    {
                        FullName = model.FullName,
                        DateOfBirth = model.DateOfBirth,
                        Nationality = model.Nationality,
                        PassportNumber = model.PassportNumber,
                        CurrentAddress = model.CurrentAddress,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        HighestEducationLevel = model.HighestEducationLevel,
                        InstitutionName = model.InstitutionName,
                        CourseTitle = model.CourseTitle,
                        ExpectedStartDate = model.ExpectedStartDate,
                        ProofOfFundsType = model.ProofOfFundsType,
                        LanguageTestTaken = model.LanguageTestTaken,
                        LanguageTestScore = model.LanguageTestScore,
                        HighestEducationLevelMarkSheetPath = model.HighestEducationLevelMarkSheetPath,
                        ResumePath = model.ResumePath,
                        TestCardPath = model.TestCardPath,
                        Passportpath = model.Passportpath,
                    };

                    var applicantname = model.FullName;
                    var applicantEmail = model.Email;

                    var visaStatus = new VisaStatusModel
                    {
                        VisaType = "Student",
                        Status = "Pending",
                        Email = applicantEmail,
                        FullName = applicantname
                    };

                    _dbContext.tblVisaStatus.Add(visaStatus);
                    _dbContext.SaveChangesAsync(); // Use asynchronous SaveChanges
                    _dbContext.tblStudentVisaForm.Add(studentProfile);
                    _dbContext.SaveChangesAsync(); // Use asynchronous SaveChanges

                    return Ok(new { Message = "Profile created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { Message = "Registration failed", Error = ex.Message });
                }
            }

            return BadRequest(ModelState);
        }
    }
}
