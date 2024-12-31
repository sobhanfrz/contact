using Contact.model.table;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Contact.utility
{
    public  class crud
    {

        private SqlConnection connection;
        public crud(SqlConnection connection)
        {
            this.connection = connection;
        

        }
        public bool deletebyid<T>(int id) {

            Type type = typeof(T);

            string table = type.Name.Replace("table", "");

            string sql = $"delete  from dbo.[{table}] where id=@id";

            return connection.Execute(sql,new {id=id})>0;
        }

      
        public T getbyid<T>(int id) {
            Type type = typeof(T);

            string table = type.Name.Replace("table", "");

            string sql = $"select * from dbo.[{table}] where id=@id";

            return connection.QuerySingle<T>(sql,new {id=id});
        }

        public IEnumerable<T> select<T>() { 
            Type type = typeof(T);

       string table=type.Name.Replace("table","");

            string sql= $"select * from dbo.[{table}]";
        
            return connection.Query<T> (sql);


        }
        public bool updatebyid<T>(T model) {
            Type type = typeof(T);

            string table = type.Name.Replace("table", "");

            PropertyInfo[] properties = type.GetProperties();
            List<string> equals = new();


            foreach (var property in properties)
            {
                if (property.Name == "id")
                {
                    continue;
                }
                equals.Add($"[{ property.Name}]=@{ property.Name}");

            }

            string cvequals = string.Join(",", equals);




            string sql = $"update  dbo.[{table}] set {cvequals} where id=@id";

            return connection.ExecuteScalar<int>(sql, model)>0;
        }

        public int insert<T> (T model){


            Type type = typeof(T);

            string table = type.Name.Replace("table", "");

            PropertyInfo[] properties=type.GetProperties();
            List<string> fields = new();
            List<string> parameters=new();

            string output = "";

            foreach (var property in properties)
            {
                if (property.Name == "id")
                {
                    output = "output inserted.id"; 
                    continue;
                }
                fields.Add(property.Name);
                parameters.Add($"@{property.Name}");

            }

            string csvfields= string.Join(",", fields);
            string csvparameters= string.Join(",", parameters);
            



            string sql = $"insert  into dbo.[{table}]({csvfields}) {output} values({csvparameters} )";

            return connection.ExecuteScalar<int>(sql,model);
        }


    }
}
