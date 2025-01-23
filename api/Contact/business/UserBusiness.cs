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
        private UserData userData;
        public UserBusiness(UserData userdata) {
            this.userData = userdata;
        }
        public BusinessResult<int> RegisterBusiness(UserAddModel model)
        {

            BusinessResult<int> result = new();
           
            //convert string to byte 
            byte[] password = MD5.HashData(Encoding.UTF8.GetBytes(model.password));

            model.imagedata = model.imagedata.Replace("data:image/jpeg;base64,", "");


            //converet img to byte
            byte[] avatar = Convert.FromBase64String(model.imagedata);
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

            UserTable user = new UserTable
            {
                username = model.username,
                password = password,
                fullname = model.fullname,
                avatar = model.imagedata
            };
            result.Data = this.userData.insert(user);
            result.Success = true;

            return result;
        }

        public BusinessResult<int> loginBussiness(UserLoginModel model)
        {
            byte[] password = MD5.HashData(Encoding.UTF8.GetBytes(model.password));
            int id = this.userData.getuserid(model.username, password);

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

        public BusinessResult<UserProfilemodel> profileBusiness(int userid)
        {

            UserTable table = this.userData.getuserinfobyid(userid);
            string file = @$".\Avatar\{table.username.ToLower()}.jpg";
            string data = "data: image / jpeg; base64,";

            if (File.Exists(file))
            {
                data += Convert.ToBase64String(File.ReadAllBytes(file));
            }
            


             return new BusinessResult<UserProfilemodel>()
            {
                Success = true,
                Data = new UserProfilemodel()
                {
                    avatar = data,
                    username = table.username,
                    fullname = table.fullname
                }
            };

        }

    }
}
