using Graduation.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Graduation.BLL
{
    public class CoreBL
    {
        private UnitOfWork unitOfWork;


        public CoreBL()
        {
            unitOfWork = new UnitOfWork();
        }

        public UnitOfWork UnitOfWork
        {
            get
            {
                return unitOfWork;
            }
        }
    }
}
