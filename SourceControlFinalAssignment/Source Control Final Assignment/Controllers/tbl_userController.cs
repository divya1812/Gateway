using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using NLog;
using Source_Control_Final_Assignment.Models;


namespace Source_Control_Final_Assignment.Controllers
{
    public class tbl_userController : Controller
    {
       // public static Logger db_logger = LogManager.GetLogger("databaseLogger");
        //public static Logger logger = LogManager.GetLogger("myAppLoggerRules");
        private static Logger logger = LogManager.GetCurrentClassLogger();

        // GET: tbl_user

        db_testEntities2 db = new db_testEntities2();
     
        public ActionResult Index()
        {
            // return View();
            
            if (Session["UserId"] != null)
            {
                return View();
            }
            
            else
            {
                return RedirectToAction("Login");
                //return View();
            }
            

        }

        //GET: Register

        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(tbl_user user)
        {
            if (ModelState.IsValid)
            {
                tbl_user obj = new tbl_user();
                if (user.ImageFile != null && user.ImageFile.ContentLength > 0)
                {
                    String fileName = Path.GetFileNameWithoutExtension(user.ImageFile.FileName);
                    String extension = Path.GetExtension(user.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    user.Profile = "~/Image/" + fileName;

                    fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                    user.ImageFile.SaveAs(fileName);
                }
                obj.Profile = user.Profile;

                var check = db.tbl_user.FirstOrDefault(s => s.Email == user.Email);

                if (check == null)
                {
                    user.Password = GetMD5(user.Password);
                    user.ConfirmPassword = GetMD5(user.ConfirmPassword);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.tbl_user.Add(user);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Registered Successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                  // ViewBag.Message = "Email already exists";
                   TempData["ErrorMessage"] = "Email already exists!";
                    return View();
                }


            }
            return View();


        }

        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            //Exception Handling
            try
            {
                if (ModelState.IsValid)
                {


                    var f_password = GetMD5(password);
                    var data = db.tbl_user.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                    if (data.Count() > 0)
                    {
                        //add session
                        Session["Name"] = data.FirstOrDefault().Name;
                        Session["Email"] = data.FirstOrDefault().Email;
                        Session["UserId"] = data.FirstOrDefault().UserId;
                        Session["Profile"] = data.FirstOrDefault().Profile.Split('~')[1];
                        Session["Address"] = data.FirstOrDefault().Address;
                        Session["Age"] = data.FirstOrDefault().Age;
                        Session["Phone"] = data.FirstOrDefault().Phone;
                        //Session["DateOfBirth"] = data.FirstOrDefault().DateOfBirth;
                        // Session["ImageFile"] = data.FirstOrDefault().ImageFile;

                        logger.Info("Login successfully");
                        TempData["successMsg"] = "Login  Successfully!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        // ViewBag.Message = "Invalid Email and Password";
                        logger.Info("Login failed");
                        TempData["ErrorMsg"] = "Invalid Email or Password..";
                        return RedirectToAction("Login");
                    }
                }
                return View();
            }
            catch(Exception e)
            {
                logger.Error("Exception !" + e.Message);
                //throw e;
                return Content("Exception in Login" + e.Message);

            }
           // return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }



        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }
}
