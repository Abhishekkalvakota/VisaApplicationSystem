using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VisaApplicationSysWeb.Data;
using VisaApplicationSysWeb.Models;

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

        [HttpPost("Profile")]
        public IActionResult PostProfile([FromBody] LoginRequestModel modelO)
        {

            return BadRequest(ModelState);

        }

        [HttpGet("GetVisaTypes")]
        public IActionResult GetVisaTypes()
        {
            try
            {
                var visaTypes = dBContext.tblVisaType.ToList(); 

                return Ok(visaTypes);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "Internal server error");
            }
        }
    }

}

