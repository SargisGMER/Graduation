using System;
using Graduation.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Graduation.DAL
{
    public class UserDAL
    {
        GraduationDBContext graduationDBContext;
        public UserDAL(GraduationDBContext _graduationDBContext)
        {
            DbContextOptionsBuilder<GraduationDBContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<GraduationDBContext>();

            dbContextOptionsBuilder.UseSqlServer("Persist Security Info=False;User ID=sa;Initial Catalog=GraduationDB;Data Source=10.25.15.112;Password=A!@123456h;");
            graduationDBContext = new GraduationDBContext(dbContextOptionsBuilder.Options);
            
            CharactersDataAccess userDataAccess = new CharactersDataAccess(graduationDBContext);

        }

        public  


    }
}
