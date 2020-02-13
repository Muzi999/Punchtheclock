using HPIT.ClockIn.Web.Content;
using HPIT.ClockIn.Web.Models;
using HPIT.ClockIn.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace HPIT.ClockIn.Web.Controllers
{
    public class IndexController : Sessions
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ClockIn()
        {
            return View();

        }
        [HttpPost]
        public ActionResult ClockIn(CardTable model)
        {
            SerResult sr = new SerResult();
            if (ModelState.IsValid)
            {

                using (SingleModel db = new SingleModel())
                {
                    CardTable ca = new CardTable()
                    {
                        C_AddTime = DateTime.Now,
                        C_Name = model.C_Name,
                        C_EndTime = model.C_EndTime,
                        C_Task = model.C_Task,
                        C_Evaluate = model.C_Evaluate
                    };
                    db.CardTable.Add(ca);
                    if (db.SaveChanges() > 0)
                    {
                        sr.State = 1;
                        sr.Message = "打卡成功！";
                    }
                    else
                    {
                        sr.State = -1;
                        sr.Message = "打卡失败！";
                    }


                }

            }
            else
            {
                sr.State = -1;
                sr.Message = "今日任务还未填写，要填写哟！";
            }

            return Json(sr, JsonRequestBehavior.AllowGet);
        }
        public ActionResult se()
        {
            using (SingleModel db = new SingleModel())
            {
                var list = db.CardTable.Where(s => true).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }

        }
        //public ActionResult GetCardList(CardViewModel model)
        //{
        //    SingleModel db = new SingleModel();
        //    var list = db.CardTable.Where(s => true);
        //    int counts = list.Count();
        //    var query = db.CardTable.Where(s => true).OrderByDescending(s => s.C_AddTime).Skip((model.page - 1) * model.limit).Take(model.limit);

        //    return Json(new { code = 0, msg = "", data = query, count = counts }, JsonRequestBehavior.AllowGet);


        //}
        public ActionResult Basic()
        {

            return View();

        }
        /// <summary>
        /// JSON
        /// </summary>
        public class SerResult
        {
            public int State { get; set; }
            public string Message { get; set; }

        }
        /// <summary>
        /// 获取姓名
        /// </summary>
        /// <returns></returns>
        public ActionResult Name()
        {
            return Json(Session["UserInfo"], JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(EditViewModel model)
        {
            SerResult sr = new SerResult();
            using (SingleModel db = new SingleModel())
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                var list = db.CardTable.FirstOrDefault(s => s.Id == model.Id);
                if (list != null)
                {
                    list.C_EndTime = DateTime.Now;
                    list.C_Evaluate = model.C_Evaluate;

                    if (db.SaveChanges() > 0)
                    {
                        sr.State = 1;
                        sr.Message = "提交成功！";
                    }
                    else
                    {
                        sr.State = -1;
                        sr.Message = "添加失败";
                    }
                }
                else
                {
                    sr.State = -1;
                    sr.Message = "该用户不存在";
                }
                return Json(sr, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult QueryName(CardViewModel model)
        {
            SingleModel db = new SingleModel();      
            var query = db.CardTable.AsQueryable();
            if (!string.IsNullOrWhiteSpace(model.C_Name))
            {
                query = query.Where(s => s.C_Name.Contains(model.C_Name));
            }
            int counts = query.Count();
            var querys = query.OrderByDescending(s => s.C_AddTime).Skip((model.page - 1) * model.limit).Take(model.limit);
            return Json(new { code = 0, msg = "", data = querys, count = counts }, JsonRequestBehavior.AllowGet);
        }
    }
}