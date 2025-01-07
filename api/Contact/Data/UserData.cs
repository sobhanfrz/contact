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
        private crud crud;
        public UserData()
        {

            string connectionstring = "Data Source=.;Database=contacts;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
            connection = new(connectionstring);
            crud = new(connection);

        }






        public int insert(usertable table)
        {

            return crud.insert(table);
        }

        public int getuserid(string username, byte[] password)
        {


            string sql = @"select id from dbo.[user] where username=@username and password=@password";
            int id = connection.ExecuteScalar<int>(sql, new { username = username, password = password });
            return id;
        }

        public usertable getuserinfobyid(int id)
        {
            string sql = @"select username,fullname,avatar
from dbo.[user] 
where id=@id";
            usertable table = connection.QuerySingle<usertable>(sql, new { id = id });
            return table;
        }

        public IEnumerable<usertable> selectall()
        {
            return crud.select<usertable>();
        }

        public void update()
        {

            usertable user = this.crud.getbyid<usertable>(5012);
            user.fullname = "ahmadrezasi";
            user.username = "mi";
            this.crud.updatebyid(user);
        }

        public usertable getbyid(int id)
        {
            return crud.getbyid<usertable>(id);

        }

        public bool deletebyid(int id)
        {

            return crud.deletebyid<usertable>(id);
        }



    }
}
