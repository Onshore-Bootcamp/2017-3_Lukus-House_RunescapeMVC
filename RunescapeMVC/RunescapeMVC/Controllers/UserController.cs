namespace RunescapeMVC.Controllers
{
    using RunescapeMVC.Custom;
    using RunescapeMVC.Models;
    using RunescapeMVC.ViewModels;
    using RunescapeMVC_DAL;
    using RunescapeMVC_DAL.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.Mvc;
    using System.Web.Security;

    public class UserController : Controller
    {
        private UserDataAccess UserData = new UserDataAccess();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();

            return RedirectToAction("Login", "User");
        }

        [HttpGet]
        public ActionResult ViewAllUsers()
        {
            ActionResult oResponse = null;
            if (Session["UserName"] != null && (int)Session["Role"] == 3)
            {
                UserVM UserVM = new UserVM();
                try
                {
                    List<IUserDO> allUsers = UserData.ViewAllUsers();

                    List<UserPO> listOFUserPOs = UserMap.MapListOfDOsToListOfPOs(allUsers);

                    UserVM.AllUsers = listOFUserPOs;
                }
                catch (Exception)
                {
                    //Catch the exception and show error message to user
                    UserVM.ErrorMessage = "We apologize, but we were unable to handle your request.";
                }
                oResponse = View(UserVM);
            }
            else
            {
                oResponse = RedirectToAction("Login", "User");
            }
            return oResponse;
        }

        [HttpGet]
        public ActionResult ViewProfile()
        {
            UserVM userVM = new UserVM();
            ActionResult oResponse = null;

            if (Session["UserName"] != null)
            {
                oResponse = View(userVM);
            }
            else
            {
                oResponse = RedirectToAction("Index", "Home");
            }
            return oResponse;
        }

        [HttpGet]
        public ActionResult DeleteUser(long userID)
        {
            ActionResult oResponse = null;
            if (Session["UserName"] != null && (int)Session["Role"] == 3)
            {
                try
                {
                    UserDO user = UserData.GetUserByID(userID);

                    if (user != null && user.Role != 3)
                    {
                        //allow delete if user to be deleted is not admin
                        UserData.DeleteUser(userID);
                    }
                    else
                    {
                        //do not allow Delete
                    }
                }
                catch (Exception ex)
                {

                    using (StreamWriter fileWriter = new StreamWriter(@"C:\Users\Lukus\Documents\BootCamp\Projects\Visual Studio\RunescapeMVC\ErrorLogs\Logs.txt"))
                    {
                        fileWriter.WriteLine("{0}-{1}",
                            DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), ex.Message, true);
                    }
                    UserVM error = new UserVM();
                    error.ErrorMessage = "Sorry, something went wrong. Please try again.";
                }
                finally
                {
                    oResponse = RedirectToAction("ViewAllUsers", "User");
                }
            }
            else
            {
                oResponse = RedirectToAction("Index", "Home");
            }
            return oResponse;
        }

        [HttpGet]
        public ActionResult Register()
        {
            UserVM UserVM = new UserVM();
            return View(UserVM);
        }
        [HttpPost]
        public ActionResult Register(UserVM iForm)
        {
            ActionResult oResponse = null;
            if (ModelState.IsValid)
            {
                try
                {
                    IUserDO lUserForm = UserMap.MapUserPOtoDO(iForm.User);
                    UserData.CreateUser(lUserForm);
                }
                catch (SqlException ex)
                {
                    //Catch the exception and show error message to user
                    iForm.ErrorMessage = "We apologize, but we were unable to handle your request.";
                    if (ex.Number == 2601)
                    {
                        oResponse = View(iForm);
                    }
                    using (StreamWriter fileWriter = new StreamWriter(@"C:\Users\Lukus\Documents\BootCamp\Projects\Visual Studio\RunescapeMVC\ErrorLogs\Logs.txt"))
                    {
                        fileWriter.WriteLine("{0}-{1}",
                            DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), ex.Message, true);
                    }
                }
                finally
                {
                    //If null, then there was no error
                    if (iForm.ErrorMessage == null)
                    {
                        oResponse = RedirectToAction("ViewAllUsers", "User");
                    }
                    //If not null, there WAS an error
                    else
                    {

                    }
                }
            }
            else
            {
                oResponse = View(iForm);
            }
            return oResponse;
        }

        [HttpPost]
        public JsonResult doesUserNameExist(string UserName)
        {

            var user = Membership.GetUser(UserName);

            return Json(user == null);
        }

        [HttpGet]
        public ActionResult Login()
        {
            UserVM VM = new UserVM();
            return View(VM);
        }
        [HttpPost]
        public ActionResult Login(UserVM iForm)
        {
            ActionResult oResponse = null;
            if (ModelState.IsValid)
            {
                UserDO user = UserData.GetUserByUserName(iForm.User.UserName);

                if (user != null && iForm.User.Password.Equals(user.Password))
                {
                    Session["UserName"] = user.UserName;
                    Session["Role"] = user.Role;
                    Session.Timeout = 10;

                    oResponse = RedirectToAction("Index", "Home");
                }
                else
                {
                    oResponse = View(iForm);
                }
            }
            else
            {
                oResponse = View(iForm);
            }
            return oResponse;
        }

        [HttpGet]
        public ActionResult UpdateUser(string userName)
        {
            ActionResult oResponse = null;
            if (Session["UserName"] != null && (int)Session["Role"] == 3)
            {
                UserVM userVM = new UserVM();
                IUserDO userDO = UserData.GetUserByUserName(userName);
                userVM.User = UserMap.MapUserDOtoPO(userDO);
                oResponse = View(userVM);
            }
            else
            {
                oResponse = RedirectToAction("Index", "Home");
            }
            return oResponse;
        }
        [HttpPost]
        public ActionResult UpdateUser(UserVM iForm)
        {
            ActionResult oResponse = null;
            if (Session["UserName"] != null && (int)Session["Role"] == 3)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        IUserDO lForm = UserMap.MapUserPOtoDO(iForm.User);
                        UserData.UpdateUser(lForm);
                        oResponse = RedirectToAction("ViewAllUsers", "User");
                    }
                    catch (Exception ex)
                    {
                        using (StreamWriter fileWriter = new StreamWriter(@"C:\Users\Lukus\Documents\BootCamp\Projects\Visual Studio\RunescapeMVC\ErrorLogs\Logs.txt"))
                        {
                            fileWriter.WriteLine("{0}-{1}",
                                DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), ex.Message, true);
                        }
                        iForm.ErrorMessage = "Sorry, something went wrong. Please try again.";
                        oResponse = View(iForm);
                    }
                    finally
                    {
                    }
                }
                else
                {
                    oResponse = View(iForm);
                }
            }
            else
            {
                oResponse = RedirectToAction("Index", "Home");
            }
            return oResponse;
        }
    }
}