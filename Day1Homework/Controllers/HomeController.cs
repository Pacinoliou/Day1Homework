using Day1Homework.Models;
using Day1Homework.Repositories;
using Day1Homework.ViewModels;
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

        private readonly InserService _objInserService = new InserService(new EFUnitOfWork());




        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Category,Amount,Date,Remark,")] InsAcbModels objInsAcbModels)
        {


            if (ModelState.IsValid)
            {

                _objInserService.Add(int.Parse(objInsAcbModels.Category), objInsAcbModels.Amount, objInsAcbModels.Date, objInsAcbModels.Remark);
                _objInserService.Save();

                TempData["message"] = "新增成功!!";
            }

            return View();
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


        public ActionResult GridPartialView()
        {
            //TODO：Skip(0).Take(10)是先為換頁做準備
            return View(db.AccountBook.OrderByDescending(p => p.Dateee).Skip(0).Take(10).ToList());
        }


    }
}