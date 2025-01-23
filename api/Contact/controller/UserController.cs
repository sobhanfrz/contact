using Contact.business;
using Contact.model;
using Contact.model.table;
using Contact.model.User;
using Microsoft.AspNetCore.Mvc;

namespace Contact.controller
{
    [ApiController]
    [Route("user")]
    public class UserController
    {
        private UserBusiness userbusiness;

        public UserController(UserBusiness userBusiness) { 

        this.userbusiness =userBusiness;

        }
        [HttpPost("login")]
        public BusinessResult<int> login(userloginmodel model)
        {
            return this.userbusiness.loginBussiness(model);

        }
        //insert user
        [HttpPost("add")]

        public BusinessResult<int> register(UserAddModel model)
        {
            return this.userbusiness.RegisterBusiness(model);

        }
        //user profile
        [HttpGet("profile")]
          public BusinessResult<userprofilemodel> profile(int userid)
        {
            return this.userbusiness.profileBusiness(userid);

        }
        [HttpGet("time")]
        public DateTime getdatetime()
        {
            return DateTime.Now;

        }
   
    }
}
