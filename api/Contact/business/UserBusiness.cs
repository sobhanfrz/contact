using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Contact.Data;
using Contact.model;
using Contact.model.table;
using Contact.model.User;

// برنامه logic
namespace Contact.business
{
    public class UserBusiness
    {
        public BusinessResult<int> RegisterBusiness(UserAddModel model)
        {
            BusinessResult<int> result = new();
           
            //convert string to byte 
            byte[] password = MD5.HashData(Encoding.UTF8.GetBytes(model.password));
            //converet img to byte
            byte[] avatar = Convert.FromBase64String(model.ImageData);
            if (!Directory.Exists(@".\Avatar"))
            {
                Directory.CreateDirectory(@".\Avatar");
            }
            string file = @$".\Avatar\{model.username.ToLower()}.jpg";

            if (File.Exists(file))
            {
                File.Delete(file);
            }

            File.WriteAllBytes(file, avatar);

            usertable user = new usertable
            {
                username = model.username,
                password = password,
                fullname = model.fullname,
                avatar = model.ImageData
            };
            result.Data = new UserData().insert(user);
            result.Success = true;

            return result;
        }

        public BusinessResult<int> loginBussiness(userloginmodel model)
        {
            byte[] password = MD5.HashData(Encoding.UTF8.GetBytes(model.password));
            int id = new UserData().getuserid(model.username, password);

            if (id == 0)

            {
                return new BusinessResult<int>()
                {
                    Success = false,
                    Errorcode = 2002,
                    ErrorMessage = "invalide username or password"

                };
            }
            return new BusinessResult<int>()
            {
                Success = true,
                Data = id
            };
        }

        public BusinessResult<userprofilemodel> profileBusiness(int userid)
        {

            usertable table = new UserData().getuserinfobyid(userid);
            string file = @$".\Avatar\{table.username.ToLower()}.jpg";
            string data = Convert.ToBase64String(File.ReadAllBytes(file));

            return new BusinessResult<userprofilemodel>()
            {
                Success = true,
                Data = new userprofilemodel()
                {
                    avatar = data,
                    username = table.username,
                    fullname = table.fullname
                }
            };

        }

    }
}
