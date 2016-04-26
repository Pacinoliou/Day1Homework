using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day1Homework.Models;
using Day1Homework.Repositories;

namespace Day1Homework.Models
{
   public class InserService  : Repository<AccountBook>
    {

        private readonly IRepository<AccountBook> _accRep;

        public InserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _accRep = new Repository<AccountBook>(unitOfWork);
        }

        public void Add(int intCategory, int intAmount, DateTime day, string strRemark)
        {
            _accRep.Create(new AccountBook
            {

                Id = Guid.NewGuid(),

                Categoryyy = intCategory,

                Amounttt = intAmount,

                Dateee = day, 

                Remarkkk = strRemark

            });
        }

        public void Save()
        {
            _accRep.Commit();
        }


    }
}
