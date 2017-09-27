namespace RunescapeMVC.Controllers
{
    using RunescapeMVC.Custom;
    using RunescapeMVC.Models;
    using RunescapeMVC.ViewModels;
    using RunescapeMVC_DAL;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web.Mvc;

    public class SlayerMastersController : Controller
    {
        MasterDataAccess MasterData = new MasterDataAccess();
        // GET: Masters
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateMaster()
        {
            ActionResult oResponse = null;
            if (Session["UserName"] != null && (int)Session["Role"] != 1)
            {
                MasterVM masterVM = new MasterVM();
                oResponse = View(masterVM);
            }
            else
            {
                oResponse = RedirectToAction("Index", "Home");
            }
            return oResponse;
        }

        [HttpPost]
        public ActionResult CreateMaster(MasterVM iViewModel)
        {
            ActionResult oResponse = null;
            if (Session["UserName"] != null && (int)Session["Role"] != 1)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        IMasterDO lMasterForm = MasterMap.MapMasterPOtoDO(iViewModel.Master);
                        MasterData.InsertMaster(lMasterForm);
                    }
                    catch (Exception ex)
                    {
                        //Catch the exception and show error message to user
                        using (StreamWriter fileWriter = new StreamWriter(@"C:\Users\Lukus\Documents\BootCamp\Projects\Visual Studio\RunescapeMVC\ErrorLogs\Logs.txt"))
                        {
                            fileWriter.WriteLine("{0}-{1}",
                                DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), ex.Message, true);
                        }
                        iViewModel.ErrorMessage = "We apologize, but we were unable to handle your request.";
                    }
                    finally
                    {
                        //If null, then there was no error
                        if (iViewModel.ErrorMessage == null)
                        {
                            oResponse = RedirectToAction("ViewAllMasters", "SlayerMasters");
                        }
                        //If not null, there WAS an error
                        else
                        {
                            oResponse = View(iViewModel);
                        }
                    }
                }
                else
                {
                    oResponse = View(iViewModel);
                }
            }
            else
            {
                oResponse = RedirectToAction("Index", "Home");
            }
            return oResponse;
        }

        [HttpGet]
        public ActionResult ViewAllMasters()
        {
            MasterVM ViewAllMastersVM = new MasterVM();
            ActionResult oResponse = null;

            if (Session["UserName"] != null && (int)Session["Role"] >= 1)
            {
                try
                {
                    List<IMasterDO> allMasters = MasterData.ViewAllMasters();

                    List<MasterPO> listOFMasterPOs = MasterMap.MapListOfDOsToListOfPOs(allMasters);

                    ViewAllMastersVM.ListOfMastersPO = listOFMasterPOs;

                    oResponse = View(ViewAllMastersVM);
                }
                catch (Exception ex)
                {
                    //Catch the exception and show error message to user
                    using (StreamWriter fileWriter = new StreamWriter(@"C:\Users\Lukus\Documents\BootCamp\Projects\Visual Studio\RunescapeMVC\ErrorLogs\Logs.txt"))
                    {
                        fileWriter.WriteLine("{0}-{1}",
                            DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), ex.Message, true);
                    }
                    ViewAllMastersVM.ErrorMessage = "We apologize, but we were unable to handle your request.";
                }
            }
            else
            {
                oResponse = RedirectToAction("Index", "Home");
            }
            return oResponse;
        }

        [HttpGet]
        public ActionResult DeleteMaster(long masterID)
        {
            ActionResult oResponse = null;
            if (Session["UserName"] != null && (int)Session["Role"] != 1)
            {
                try
                {
                    MasterData.DeleteMaster(masterID);
                }
                catch (Exception ex)
                {
                    using (StreamWriter fileWriter = new StreamWriter(@"C:\Users\Lukus\Documents\BootCamp\Projects\Visual Studio\RunescapeMVC\ErrorLogs\Logs.txt"))
                    {
                        fileWriter.WriteLine("{0}-{1}",
                            DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), ex.Message, true);
                    }
                    MasterVM error = new MasterVM();
                    error.ErrorMessage = "Sorry, something went wrong. Please try again.";;
                }
                finally
                {
                    oResponse = RedirectToAction("ViewAllMasters", "SlayerMasters");
                }
            }
            else
            {
                oResponse = RedirectToAction("Index", "Home");
            }
            return oResponse;
        }

        [HttpGet]
        public ActionResult UpdateMaster(long masterID)
        {
            ActionResult oResponse = null;
            if (Session["UserName"] != null && (int)Session["Role"] != 1)
            {
                MasterVM masterVM = new MasterVM();
                IMasterDO MasterDO = MasterData.ViewMasterByID(masterID);
                masterVM.Master = MasterMap.MapMasterDOtoPO(MasterDO);
                oResponse = View(masterVM);
            }
            else
            {
                oResponse = RedirectToAction("Index", "Home");
            }
            return oResponse;
        }

        [HttpPost]
        public ActionResult UpdateMaster(MasterVM iViewModel)
        {
            ActionResult oResponse = null;
            if (Session["UserName"] != null && (int)Session["Role"] != 1)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        IMasterDO lMasterForm = MasterMap.MapMasterPOtoDO(iViewModel.Master);
                        MasterData.UpdateMaster(lMasterForm);
                        oResponse = RedirectToAction("ViewAllMasters", "SlayerMasters");
                    }
                    catch (Exception ex)
                    {
                        using (StreamWriter fileWriter = new StreamWriter(@"C:\Users\Lukus\Documents\BootCamp\Projects\Visual Studio\RunescapeMVC\ErrorLogs\Logs.txt"))
                        {
                            fileWriter.WriteLine("{0}-{1}",
                                DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), ex.Message, true);
                        }
                        iViewModel.ErrorMessage = "Sorry, it broke.";
                        oResponse = View(iViewModel);
                    }
                    finally
                    {
                    }
                }
                else
                {
                    oResponse = View(iViewModel);
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