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

        [HttpPost]
        [Route("PostStudent")]
        public IActionResult PostStudent(StudentVisaForm model)
        {
            if (ModelState.IsValid)
            {
                try
{

                    var newApplicant = new Applicant
                    {
                        FullName = model.FullName,
                        Email = model.Email,
                        VisaType = "Student",
                        VisaTypeId = 1,
                        IsVisaApplied = true
                    };

                    _dbContext.tblApplicant.Add(newApplicant);
                    _dbContext.SaveChanges();

                   
                    var newVisaStatus = new VisaStatusModel
                    {
                        FullName = model.FullName,
                        Email = model.Email,
                        VisaSatus = "Pending",
                        VisaType = "Student",
                        ApplicantID = newApplicant.ApplicantID
                    };

                    _dbContext.tblVisaStatus.Add(newVisaStatus);
                    _dbContext.SaveChanges();

                    
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
                        PassportPhotoPath = model.PassportPhotoPath,
                       
                        ApplicantID = newApplicant.ApplicantID
                    };

                    _dbContext.tblStudentVisaForm.Add(StudentProfile);
                    _dbContext.SaveChanges();

                    return Ok(new { Message = "Profile created successfully" });
                }
                
                catch (Exception ex)
                {

                    return StatusCode(500, new { Message = "Profile Creation  failed", Error = ex.Message });
                }
            }

            return BadRequest(ModelState);

        }

        [HttpPost]
        [Route("PostTourist")]
        public IActionResult PostTourist(TouristVisaForm model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    var newApplicant = new Applicant
                    {
                        FullName = model.FullName,
                        Email = model.Email,
                        VisaType = "Tourist", 
                        VisaTypeId = 2,
                        IsVisaApplied = true
                    };

                    _dbContext.tblApplicant.Add(newApplicant);
                    _dbContext.SaveChanges();

                   
                    var newVisaStatus = new VisaStatusModel
                    {
                        FullName = model.FullName,
                        Email = model.Email,
                        VisaSatus = "Pending",
                        VisaType = "Tourist",
                        ApplicantID = newApplicant.ApplicantID
                    };

                    _dbContext.tblVisaStatus.Add(newVisaStatus);
                    _dbContext.SaveChanges();

                    
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
                       
                        ApplicantID = newApplicant.ApplicantID
                    };

                    _dbContext.tblTouristVisaForm.Add(TouristProfile);
                    _dbContext.SaveChanges();

                    return Ok(new { Message = "Profile created successfully" });
                }
                catch (Exception ex)
                {

                    return StatusCode(500, new { Message = "Profile Creation failed", Error = ex.Message });
                }
            }

            return BadRequest(ModelState);

        }
        [HttpPost]
        [Route("PostEmployment")]
        public IActionResult PostEmployment(EmploymentVisaForm model)
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

                    var newApplicant = new Applicant
                    {
                        FullName = model.FullName,
                        Email = model.Email,
                        VisaType = "Employment",
                        VisaTypeId = 3,
                        IsVisaApplied = true
                    };


                    _dbContext.tblApplicant.Add(newApplicant);
                    _dbContext.SaveChanges();


                    var newVisaStatus = new VisaStatusModel
                    {
                        FullName = model.FullName,
                        Email = model.Email,
                        VisaSatus = "Pending",
                        VisaType = "Employment",
                        ApplicantID = newApplicant.ApplicantID
                    };


                    _dbContext.tblVisaStatus.Add(newVisaStatus);
                    _dbContext.SaveChanges();


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

        [HttpPost]
        [Route("PostBusiness")]
        public IActionResult Business(BusinessVisaForm model)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    var newApplicant = new Applicant
                    {
                        FullName = model.FullName,
                        Email = model.Email,
                        VisaType = "Business", 
                        VisaTypeId = 4,
                         IsVisaApplied = true
                    };

                    _dbContext.tblApplicant.Add(newApplicant);
                    _dbContext.SaveChanges();

                   
                    var newVisaStatus = new VisaStatusModel
                    {
                        FullName = model.FullName,
                        Email = model.Email,
                        VisaSatus = "Pending",
                        VisaType = "Business",
                        ApplicantID = newApplicant.ApplicantID
                    };

                    _dbContext.tblVisaStatus.Add(newVisaStatus);
                    _dbContext.SaveChanges();

                   
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
                        IsVisaApplied = true,
                        ApplicantID = newApplicant.ApplicantID
                    };

                    _dbContext.tblBusinessVisaForm.Add(BusinessProfile);
                    _dbContext.SaveChanges();


                    return Ok(new { Message = "Profile created successfully" });
                }
                catch (Exception ex)
                {

                    return StatusCode(500, new { Message = "Profile Creation  failed", Error = ex.Message });
                }
            }

            return BadRequest(ModelState);
        }
    }
}
