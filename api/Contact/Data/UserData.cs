using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact.model.table;
using Contact.utility;
using Dapper;
using Microsoft.Data.SqlClient;

//قسمت اتصال به اس کیو ال 
namespace Contact.Data
{
    public class UserData
    {
        private SqlConnection connection;
        private Crud crud;
        public UserData(SqlConnection connection ,Crud crud)
        {

           this.connection = connection;
            this.crud = crud;

        }






        public int insert(UserTable table)
        {

            return crud.insert(table);
        }

        public int getuserid(string username, byte[] password)
        {


            string sql = @"select id from dbo.[user] where username=@username and password=@password";
            int id = connection.ExecuteScalar<int>(sql, new { username = username, password = password });
            return id;
        }

        public UserTable getuserinfobyid(int id)
        {
            string sql = @"select username,fullname,avatar
from dbo.[user] 
where id=@id";
            UserTable table = connection.QuerySingle<UserTable>(sql, new { id = id });
            return table;
        }

        public IEnumerable<UserTable> selectall()
        {
            return crud.select<UserTable>();
        }

        public void update()
        {

            UserTable user = this.crud.getbyid<UserTable>(5012);
            user.fullname = "ahmadrezasi";
            user.username = "mi";
            this.crud.updatebyid(user);
        }

        public UserTable getbyid(int id)
        {
            return crud.getbyid<UserTable>(id);

        }

        public bool deletebyid(int id)
        {

            return crud.deletebyid<UserTable>(id);
        }



    }
}
