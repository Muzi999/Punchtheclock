using HPIT.ClockIn.Web.Content;
using HPIT.ClockIn.Web.Models;
using HPIT.ClockIn.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HPIT.ClockIn.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Mobile, string Pwd)
        {
            SerializeResult sr = new SerializeResult();
            using (SingleModel db = new SingleModel())
            {
                string pwd = EncryptHelper.GerMd5Hash(Pwd);
                var list = db.LoinTable.Where(s => s.Mobile == Mobile && s.Pwd ==pwd ).ToList();

                if (list.Count > 0)
                {
                    Session["UserInfo"] = list;
                    sr.State = 1;
                    sr.Message = "登陆成功！";
                }
                else
                {
                    sr.State = -1;
                    sr.Message = "用户名或密码错误！";
                }
            }
            return Json(sr);
        }
        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            SerializeResult sr = new SerializeResult();
            using (SingleModel db = new SingleModel())
            {
                var result = db.LoinTable.Where(s => s.Mobile == model.Mobile).ToList();
                if (result.Count > 0)
                {
                    sr.State = -1;
                    sr.Message = "该手机号已被注册！";

                }
                else
                {
                    LoinTable login = new LoinTable()
                    {
                        Name = model.Name,
                        Mobile = model.Mobile,
                        Pwd = EncryptHelper.GerMd5Hash(model.Pwd)
                    };
                    db.LoinTable.Add(login);
                   
                    if (db.SaveChanges() > 0)
                    {
                        sr.State = 1;
                        sr.Message = "注册成功！";
                    }
                    else
                    {
                        sr.State = -1;
                        sr.Message = "注册失败！";
                    }
                }
            }
            return Json(sr, JsonRequestBehavior.AllowGet);
        }
    }
}