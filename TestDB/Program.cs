using System;
using Graduation.DAL.Models;
using Graduation.DAL.Implementations;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TestDB
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.Configuration.ConfigurationFileMap fileMap = new System.Configuration.ConfigurationFileMap(@"D:\Graduation Projects\Graduation\TestDB\config.xml"); //Path to your config file
            //System.Configuration.Configuration configuration = System.Configuration.ConfigurationManager.OpenMappedMachineConfiguration(fileMap);
            DbContextOptionsBuilder<GraduationDBContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<GraduationDBContext>();

            dbContextOptionsBuilder.UseSqlServer("Persist Security Info=False;User ID=sa;Initial Catalog=GraduationDB;Data Source=10.25.15.112;Password=A!@123456h;");
            GraduationDBContext graduationDBContext = new GraduationDBContext(dbContextOptionsBuilder.Options);


            CharactersDataAccess userDataAccess = new CharactersDataAccess(graduationDBContext);


            var character = userDataAccess.GetById(8);
            Console.WriteLine($"{character.Id} : {character.Account}");




            //var getall = userCharactersDataAccess.GetAll().Where(x => x.Email == "aa@aa");

            //foreach (var item in getall)
            //{
            //    Console.WriteLine($"{item.Id} : {item.Name} : {item.Email} : {item.Password}");
            //}

            //Console.WriteLine();
            //Console.Read();
        }
    }
}
