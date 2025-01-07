﻿using Contact.business;
using Contact.Data;
using Contact.model.table;
using Contact.model.User;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace Contact
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string data = Convert.ToBase64String(File.ReadAllBytes("C:\\Users\\sobhan\\Pictures\\avatar.jpg"));
            //Console.WriteLine(data);
            //BusinessResult<int> result = new UserBusiness().RegisterBusiness(new model.User.UserAddModel()
            //{
            //    fullname = "test1",
              //ImageData = "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/nARvjlvoe3vAbsGK4PP5mdWDLVfv0nN/wD2Of8Aofa91ecz4twvvn/7j//aAAwDAQACAAMAAAAQ8888888888888888888888888888888888888888488888888888888888888888ziL888888888888888888888nI5H88888888888888888884pqZ888888888888888888888s3VAM8888888888888888888wh7AT08888888888888888888UMP0uU888888888848888888wIFrZXX88888888889xU8888800t8MR88888846y88ZFMy8888s4AIzYp8888kQli887yCxy88s842M5Ff888t47N888sXzisa0scSfNqti18vlMhi8888pq1Otas0m63QZNloeQog/4888/Itm7rQ4HJBudR4/Xggk888888LEEgZGTMMoQhPgMLkuc888888s/wDIZClZGlLiRHzH1N/PPPPPPPLSvaQyjOVNunBG8z/PPPPPPPPPGIHf9ROTpQkwMwPPPPPPPPPPPN10KC5FtDOCme2vPPPPPPPPPP8ADoQi4mQ5hpwgFlXzzzzzzzzzTY3WW2S1J9IkYnjfzzzzzzzzzFdxDIKaE8pO2er5zzzzzzzzzw8C3PLzMJ6urXAVdbzzzzzzzzzhfAx6h48218jX1bzzzzzzzzzzz6PikADZiWg+6x/zzzzzzzzzzwohFB9XUjc+lulzzzzzzzzzzzxO/wDLyGKbTarW2888888888888Oy2SPf8J1YVGW8888888888888q3i18sYFmcN88888888888888N1b8888AXt+8888888888888889c8888s/gc8888888888888888888888s88888888888888888888888888888888888//xAArEQEAAgECAwgDAQEBAQAAAAABABExIUEQUWEgMHGBkbHR8EChweHxUGD/2gAIAQMBAT8Q/wDgNQdCB6W8YNpVn4woYtjnBaVSncbfijyLHWWu5WAa84NbPs3/ABVDZvBSDBN9htl0Npv+KwYNY2JIFrSZz9n8QEcTHQi0Gpyc8NH4ZnDXl+x+Jh9zVnSNuH75wG3MpUnmHd0vA1gVBT0lM9XcW1XBlG7XrMp5U++/b3ElQaeNVeZBvER2TnocPc0blr6cFLbL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",
            //    password = "112678",
            //    passwordconfirm = "112678",
            //    username = "tes"
            //}
            //);


            //BusinessResult<int> result = new UserBusiness().loginBussiness(new userloginmodel
            //{
            //    username="sami",
            //    password="112288"
            //});

            //BusinessResult<userprofilemodel> result = new UserBusiness().profileBusiness(4014);

            //usertable table = new usertable();
            //table.username = "bot@gmail.com";
            //table.fullname = "bt";

            //insert<usertable>(table);


            new UserData().update();

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseCors(x=>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            }
                
                );

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
      
        }

        //static void insert<T>(T model)
        //{


        //}


    }
}
