using System;
using Graduation.DAL.Models;

namespace Graduation.DAL
{
    public class UserDAL
    {
        GraduationDBContext GraduationDBContext;
        public UserDAL(GraduationDBContext _graduationDBContext)
        {
            GraduationDBContext = _graduationDBContext;
        }



    }
}
