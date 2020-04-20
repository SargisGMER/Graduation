using Graduation.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Graduation.DAL.Repository.Core
{
    public interface IStudentRepository
    {
        IEnumerable<Account> GetStudents();
        Account GetStudentByID(int studentId);
        void InsertStudent(Account student);
        void DeleteStudent(int studentID);
        void UpdateStudent(Account student);
        void Save();
    }
}
