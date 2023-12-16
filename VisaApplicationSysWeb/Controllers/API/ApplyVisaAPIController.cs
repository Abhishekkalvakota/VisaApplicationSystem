using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VisaApplicationSysWeb.Data;
using VisaApplicationSysWeb.Models;

namespace VisaApplicationSysWeb.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplyVisaAPIController : ControllerBase
    {

        private readonly VisaDBContext _dbContext;
        

        public ApplyVisaAPIController(VisaDBContext dbContext)
        {
            _dbContext = dbContext;
            

        }

       
        public IActionResult Student(StudentVisaForm model,[FromForm] IFormFile PassportPhotoPath, [FromForm] IFormFile ResumePath, [FromForm] IFormFile TestCardPath, [FromForm] IFormFile HighestEducationLevelMarkSheetPath)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var StudentProfile = new StudentVisaForm
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


                    _dbContext.tblStudentVisaForm.Add(StudentProfile);
                    _dbContext.SaveChanges();


                    return Ok(new { Message = "Profile created successfully" });
                }
                catch (Exception ex)
                {

                    return StatusCode(500, new { Message = "Registration failed", Error = ex.Message });
                }
            }

            return BadRequest(ModelState);

        }

        public IActionResult Tourist(TouristVisaForm model,[FromForm] IFormFile PassportPhotoPath, [FromForm] IFormFile TravelItineraryPath, [FromForm] IFormFile HotelReservationPath, [FromForm] IFormFile Passportpath)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var TouristProfile = new TouristVisaForm
                    {
                        FullName = model.FullName,
                        DateOfBirth = model.DateOfBirth,
                        Nationality = model.Nationality,
                        PassportNumber = model.PassportNumber,
                        CurrentAddress = model.CurrentAddress,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        IntendedArrivalDate = model.IntendedArrivalDate,
                        IntendedDepartureDate = model.IntendedDepartureDate,
                        PassportPhotoPath = model.PassportPhotoPath,
                        TravelItineraryPath = model.TravelItineraryPath,
                        HotelReservationPath = model.HotelReservationPath,
                         Passportpath = model.Passportpath,
                    };


                    _dbContext.tblTouristVisaForm.Add(TouristProfile);
                    _dbContext.SaveChanges();


                    return Ok(new { Message = "Profile created successfully" });
                }
                catch (Exception ex)
                {

                    return StatusCode(500, new { Message = "Registration failed", Error = ex.Message });
                }
            }

            return BadRequest(ModelState);

        }
        public IActionResult Employment(EmploymentVisaForm model, [FromForm] IFormFile PassportPhotoPath, [FromForm] IFormFile EmploymentContractPath, [FromForm] IFormFile ResumePath, [FromForm] IFormFile Passportpath)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var EmploymentProfile = new EmploymentVisaForm
                    {

                        FullName = model.FullName,
                        DateOfBirth = model.DateOfBirth,
                        Nationality = model.Nationality,
                        PassportNumber = model.PassportNumber,
                        CurrentAddress = model.CurrentAddress,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        CurrentEmployer = model.CurrentEmployer,
                        JobTitle = model.JobTitle,
                        MonthlySalary = model.MonthlySalary,
                        ContractStartDate = model.ContractStartDate,
                        ContractEndDate = model.ContractEndDate,
                        PassportPhotoPath = model.PassportPhotoPath,
                        ResumePath = model.ResumePath,
                        EmploymentContractPath = model.EmploymentContractPath,
                        Passportpath = model.Passportpath,
                        
                    };

                    _dbContext.tblEmploymentVisaForm.Add(EmploymentProfile);
                    _dbContext.SaveChanges();


                    return Ok(new { Message = "Profile created successfully" });
                }
                catch (Exception ex)
                {

                    return StatusCode(500, new { Message = "Registration failed", Error = ex.Message });
                }
            }

            return BadRequest(ModelState);

        }


        public IActionResult Business(BusinessVisaForm model, [FromForm] IFormFile PassportPhotoPath, [FromForm] IFormFile LetterOfInvitationPath, [FromForm] IFormFile BusinessProposalPath, [FromForm] IFormFile Passportpath)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    var BusinessProfile = new BusinessVisaForm
                    {
                        FullName = model.FullName,
                        DateOfBirth = model.DateOfBirth,
                        Nationality = model.Nationality,
                        PassportNumber = model.PassportNumber,
                        CurrentAddress = model.CurrentAddress,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        CompanyName = model.CompanyName,
                        BusinessTitle = model.BusinessTitle,
                        BusinessNature = model.BusinessNature,
                        IntendedArrivalDate = model.IntendedArrivalDate,
                        IntendedDepartureDate = model.IntendedDepartureDate,
                        PassportPhotoPath = model.PassportPhotoPath,
                        Passportpath = model.Passportpath,
                        
                    };


                    _dbContext.tblBusinessVisaForm.Add(BusinessProfile);
                    _dbContext.SaveChanges();


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
