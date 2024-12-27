using Contact.model.table;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//قسمت اتصال به اس کیو ال 
namespace Contact.Data
{
    public class UserData
    {
        public int insert(usertable table)
        {
            string connectionstring = "Data Source=.;Database=contacts;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            string sql = @"insert into dbo.[user] 
(username,password,fullname,avatar)
output INSERTED.id
values(@username,@password,@fullname,@avatar)";

            connection.Execute(sql,table);
            connection.Close();
            return 0;
        }

        public int getuserid(string username, byte[] password)
        {

            string connectionstring = "Data Source=.;Database=contacts;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            string sql = @"select id from dbo.[user] where username=@username and password=@password";
          int id= connection.ExecuteScalar<int>(sql, new { username = username ,password=password});
            connection.Close();
            return id;
        }

    }
}
