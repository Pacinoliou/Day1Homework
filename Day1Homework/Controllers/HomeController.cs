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

        private SkillTreeHomeworkEntities1 db = new SkillTreeHomeworkEntities1();

        public ActionResult Index()
        {


            return View(db.AccountBook.OrderBy(p => p.Dateee).Skip(0).Take(10).ToList());
        }


        public ActionResult GridChildView(int objSeqNo, AccountBook objAccountBook)
        {

            var objGridViewModels = new GridViewModels
            {
                SeqNo = objSeqNo,
                AccType = objAccountBook.Categoryyy == 0 ? "支出" : "收入",
                RecDate = objAccountBook.Dateee.ToString("yyyy/MM/dd HH：ss"),
                SetMoney = objAccountBook.Amounttt
            };

            return View(objGridViewModels);

        }

    }
}