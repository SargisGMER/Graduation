using Graduation.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Graduation.BLL.BLContracts
{
    public interface IAccountBL
    {
        AccountEntity Authentication(string email, string password);
    }
}
