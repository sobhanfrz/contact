using Contact.model.table;
using Dapper;
using Microsoft.Data.SqlClient;
namespace Contact
{

    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionstring = "Data Source=.;Database=contacts;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            //string sql = "insert into dbo.[user](username,password,fullname) values(@username,@password,@fullname)";
            //usertable user = new usertable()
            //{
            //    username = "admin",
            //    password = [],
            //    fullname = "adminastrator"

            //};
            object param = new
            {
                username = "nima",
                password = Array.Empty<byte>(),
                fullname = "nimanazari"
            };
            object i = new
            {
                id = 1001
            };

            string sql = "select * from dbo.[user]";
            IEnumerable<usertable> users=connection.Query<usertable>(sql);
            foreach (usertable user in users)
            {
                Console.WriteLine($"username:{user.username},fullname:{user.fullname}");
            }

            //connection.Execute(sql,param);


            connection.Close();


        }
      
        
    }
}
