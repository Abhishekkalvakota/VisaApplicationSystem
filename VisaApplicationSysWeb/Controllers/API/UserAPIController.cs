using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using VisaApplicationSysWeb.Data;
using VisaApplicationSysWeb.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace VisaApplicationSysWeb.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        private readonly VisaDBContext dBContext;

        public UserAPIController(VisaDBContext dbContext)
        {
            dBContext = dbContext;
        }

        [HttpPost("Registration")]
        public IActionResult PostRegistration([FromBody] RegisterRequestModel model)
        {
            if (ModelState.IsValid)
            {

                if (model.Password != model.ConfirmPassword)
                {
                    return BadRequest(new { Message = "Passwords do not match" });
                }

                try
                {
                    if (dBContext.tblUser.Any(u => u.Username == model.Username))
                    {

                        return BadRequest(new { Message = "Username is already taken" });
                    }

                    var user = new UserModel
                    {
                        Username = model.Username,
                        Password = model.Password,
                        ConfirmPassword = model.ConfirmPassword
                    };

                    dBContext.tblUser.Add(user);
                    dBContext.SaveChanges();


                    return Ok(new { Message = "Registration successful" });
                }
                catch (Exception ex)
                {

                    return StatusCode(500, new { Message = "Registration failed", Error = ex.Message });
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost("Login")]
        public IActionResult PostLogin([FromBody] LoginRequestModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isValid = dBContext.tblUser.Any(X => X.Username == model.Username && X.Password == model.Password);

                    if (isValid)
                    {
                        return Ok(new { Message = "Login successful" });
                    }

                    return Unauthorized(new { Message = "Invalid credentials" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { Message = "Login failed", Error = ex.Message });
                }
            }

            return BadRequest(ModelState);
        }


        [HttpGet]
        [Route("api/UserAPI/GetApplicantData")]
        public IActionResult GetApplicantData(int applicantId, int visaTypeId)
        {
            try
            {
                switch (visaTypeId)
                {
                    case 1: 
                        var studentVisaData = dBContext.tblStudentVisaForm.FirstOrDefault(p => p.ApplicantId == applicantId);
                        if (studentVisaData != null)
                        {
                            return Ok(studentVisaData);
                        }
                        break;

                    case 2: // Tourist Visa
                        var touristVisaData = dBContext.tblTouristVisaForm.FirstOrDefault(p => p.ApplicantId == applicantId);
                        if (touristVisaData != null)
                        {
                            return Ok(touristVisaData);
                        }
                        break;

                    case 3: // Employment Visa
                        var employmentVisaData = dBContext.tblEmploymentVisaForm.FirstOrDefault(p => p.ApplicantId == applicantId);
                        if (employmentVisaData != null)
                        {
                            return Ok(employmentVisaData);
                        }
                        break;

                    case 4: // Business Visa
                        var businessVisaData = dBContext.tblBusinessVisaForm.FirstOrDefault(p => p.ApplicantId == applicantId);
                        if (businessVisaData != null)
                        {
                            return Ok(businessVisaData);
                        }
                        break;

                    default:
                        return NotFound("Invalid Visa Type");
                }

                return NotFound("Applicant data not found");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("api/UserAPI/UpdateApplicantData")]
        public IActionResult UpdateApplicantData(int applicantId, int visaTypeId, [FromBody] ApplicantProfile updatedProfile)
        {
            try
            {
                
                switch (visaTypeId)
                {
                    case 1: // Student Visa
                        var studentVisaData = dBContext.tblStudentVisaForm.FirstOrDefault(p => p.ApplicantId == applicantId);
                        if (studentVisaData != null)
                        {

                            studentVisaData.FullName = updatedProfile.FullName;
                            studentVisaData.DateOfBirth = updatedProfile.DateOfBirth;
                            studentVisaData.Nationality = updatedProfile.Nationality;
                            studentVisaData.PassportNumber = updatedProfile.PassportNumber;
                            studentVisaData.CurrentAddress = updatedProfile.CurrentAddress;
                            studentVisaData.Email = updatedProfile.Email;
                            studentVisaData.PhoneNumber = updatedProfile.PhoneNumber;
                            studentVisaData.HighestEducationLevel = updatedProfile.HighestEducationLevel;
                            studentVisaData.InstitutionName = updatedProfile.InstitutionName;
                            studentVisaData.CourseTitle = updatedProfile.CourseTitle;
                            studentVisaData.ExpectedStartDate = updatedProfile.ExpectedStartDate;
                            studentVisaData.ProofOfFundsType = updatedProfile.ProofOfFundsType;
                            studentVisaData.LanguageTestTaken = updatedProfile.LanguageTestTaken;
                            studentVisaData.LanguageTestScore = updatedProfile.LanguageTestScore;
                            studentVisaData.HighestEducationLevelMarkSheetPath = updatedProfile.HighestEducationLevelMarkSheetPath;
                            studentVisaData.PassportPhotoPath = updatedProfile.PassportPhotoPath;
                            studentVisaData.ResumePath = updatedProfile.ResumePath;
                            studentVisaData.TestCardPath = updatedProfile.TestCardPath;
                            studentVisaData.Passportpath = updatedProfile.Passportpath;

                            dBContext.SaveChanges();

                            return Ok("Student Visa data updated successfully");
                        }
                        break;

                    case 2: // Tourist Visa
                        var touristVisaData = dBContext.tblTouristVisaForm.FirstOrDefault(p => p.ApplicantId == applicantId);
                        if (touristVisaData != null)
                        {
                            
                            touristVisaData.FullName = updatedProfile.FullName;
                            touristVisaData.DateOfBirth = updatedProfile.DateOfBirth;
                            touristVisaData.Nationality = updatedProfile.Nationality;
                            touristVisaData.PassportNumber = updatedProfile.PassportNumber;
                            touristVisaData.CurrentAddress = updatedProfile.CurrentAddress;
                            touristVisaData.Email = updatedProfile.Email;
                            touristVisaData.PhoneNumber = updatedProfile.PhoneNumber;
                            touristVisaData.IntendedArrivalDate = updatedProfile.IntendedArrivalDate;
                            touristVisaData.IntendedDepartureDate = updatedProfile.IntendedDepartureDate;
                            touristVisaData.PassportPhotoPath = updatedProfile.PassportPhotoPath;
                            touristVisaData.TravelItineraryPath = updatedProfile.TravelItineraryPath;
                            touristVisaData.HotelReservationPath = updatedProfile.HotelReservationPath;
                            touristVisaData.Passportpath = updatedProfile.Passportpath;

                            dBContext.SaveChanges();

                            return Ok("Tourist Visa data updated successfully");
                        }
                        break;

                    case 3: // Employment Visa
                        var employmentVisaData = dBContext.tblEmploymentVisaForm.FirstOrDefault(p => p.ApplicantId == applicantId);
                        if (employmentVisaData != null)
                        {
                            // Update properties based on the provided updatedData
                            employmentVisaData.FullName = updatedProfile.FullName;
                            employmentVisaData.DateOfBirth = updatedProfile.DateOfBirth;
                            employmentVisaData.Nationality = updatedProfile.Nationality;
                            employmentVisaData.PassportNumber = updatedProfile.PassportNumber;
                            employmentVisaData.CurrentAddress = updatedProfile.CurrentAddress;
                            employmentVisaData.Email = updatedProfile.Email;
                            employmentVisaData.PhoneNumber = updatedProfile.PhoneNumber;
                            employmentVisaData.JobTitle = updatedProfile.JobTitle; // Add the actual property name
                            employmentVisaData.CurrentEmployer = updatedProfile.CurrentEmployer; // Add the actual property name
                            employmentVisaData.MonthlySalary = updatedProfile.MonthlySalary; // Add the actual property name
                            employmentVisaData.ContractStartDate = updatedProfile.ContractStartDate; // Add the actual property name
                            employmentVisaData.ContractEndDate = updatedProfile.ContractEndDate; // Add the actual property name
                            employmentVisaData.PassportPhotoPath = updatedProfile.PassportPhotoPath;
                            employmentVisaData.ResumePath = updatedProfile.ResumePath;
                            employmentVisaData.Passportpath = updatedProfile.Passportpath;
                            // Update other properties as needed

                            // Save changes to the database
                            dBContext.SaveChanges();

                            return Ok("Employment Visa data updated successfully");
                        }
                        break;

                    case 4: // Business Visa
                        var businessVisaData = dBContext.tblBusinessVisaForm.FirstOrDefault(p => p.ApplicantId == applicantId);
                        if (businessVisaData != null)
                        {
                            // Update properties based on the provided updatedProfile
                            businessVisaData.FullName = updatedProfile.FullName;
                            businessVisaData.DateOfBirth = updatedProfile.DateOfBirth;
                            businessVisaData.Nationality = updatedProfile.Nationality;
                            businessVisaData.PassportNumber = updatedProfile.PassportNumber;
                            businessVisaData.CurrentAddress = updatedProfile.CurrentAddress;
                            businessVisaData.Email = updatedProfile.Email;
                            businessVisaData.PhoneNumber = updatedProfile.PhoneNumber;
                            businessVisaData.CompanyName = updatedProfile.CompanyName;
                            businessVisaData.BusinessTitle = updatedProfile.BusinessTitle;
                            businessVisaData.BusinessNature = updatedProfile.BusinessNature;
                            businessVisaData.IntendedArrivalDate = updatedProfile.IntendedArrivalDate;
                            businessVisaData.IntendedDepartureDate = updatedProfile.IntendedDepartureDate;
                            businessVisaData.PassportPhotoPath = updatedProfile.PassportPhotoPath;
                            businessVisaData.Passportpath = updatedProfile.Passportpath;
                            // Update other properties as needed

                            // Save changes to the database
                            dBContext.SaveChanges();

                            return Ok("Business Visa data updated successfully");
                        }
                        break;

                    default:
                        return BadRequest("Invalid Visa Type");
                }

                return NotFound("Applicant data not found");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("{applicantId}")]
        public IActionResult GetVisaStatus(int applicantId)
        {
            var visaStatusModel = dBContext.tblVisaStatus
                .FirstOrDefault(model => model.ApplicantId == applicantId);

            if (visaStatusModel == null)
            {
                return NotFound();
            }

            return Ok(visaStatusModel);
        }
    }

}

