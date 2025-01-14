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
        private UserBusiness business;

        public UserController() { 
        this.business = new UserBusiness();
        }
        [HttpPost("login")]
        public BusinessResult<int> login(userloginmodel model)
        {
            return this.business.loginBussiness(model);

        }
        //insert user
        [HttpPost("add")]

        public BusinessResult<int> register(UserAddModel model)
        {
            return this.business.RegisterBusiness(model);

        }
        //user profile
        [HttpGet("profile")]
          public BusinessResult<userprofilemodel> profile(int userid)
        {
            return this.business.profileBusiness(userid);

        }
        [HttpGet("time")]
        public DateTime getdatetime()
        {
            return DateTime.Now;

        }
   
    }
}
