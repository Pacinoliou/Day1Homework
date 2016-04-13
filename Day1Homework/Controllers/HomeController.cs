using Day1Homework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day1Homework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GridChildView( int objSeqNo)
        {

            var objGridViewModels = new GridViewModels { SeqNo = objSeqNo,
                                                         AccType ="支出",
                                                         RecDate = DateTime.Now.AddDays(objSeqNo - 1).ToString("yyyy/MM/dd"),
                                                         SetMoney = 500 * objSeqNo };

            return View(objGridViewModels);

        }
      
    }
}