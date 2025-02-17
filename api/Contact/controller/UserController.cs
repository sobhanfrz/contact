﻿using Contact.business;
using Contact.model;
using Contact.model.table;
using Contact.model.User;
using Contact.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contact.controller
{
    [ApiController]
    [Route("user")]
    public class UserController: ControllerBase
    {
        private UserBusiness userbusiness;

        public UserController(UserBusiness userBusiness) { 

        this.userbusiness =userBusiness;

        }
        [HttpPost("login")]
        public BusinessResult<string> login(UserLoginModel model)
        {
            BusinessResult<int> result = this.userbusiness.loginBussiness(model);
            if (result.Success)
            {
                int userid = result.Data;
                string token = Token.Generate(userid);

                return new()
                {
                    Success = true,
                    Data = token
                };

            }
            else
            {
                return new()
                {
                    Success = false,
                    Errorcode = result.Errorcode,
                    ErrorMessage = result.ErrorMessage
                };

            }
        }

        //insert user
        [HttpPost("add")]

        public BusinessResult<int> register(UserAddModel model)
        {
            return this.userbusiness.RegisterBusiness(model);

        }
        //user profile
        [Authorize]
        [HttpGet("profile")]
          public BusinessResult<UserProfilemodel> profile()
        {

            string userid = base.User.Identity.Name;

            return this.userbusiness.profileBusiness(int.Parse(userid));

        }
        [HttpGet("time")]
        public DateTime getdatetime()
        {
            return DateTime.Now;

        }
   
    }
}
