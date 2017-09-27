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
    
    public class BeastsController : Controller
    {
        //DataAccess Instantiations
        AreasDataAccess AreaData = new AreasDataAccess();
        BeastDataAccess BeastData = new BeastDataAccess();
        MasterDataAccess MasterData = new MasterDataAccess();

        //Method to Create new Beast if users role is at least poweruser
        [HttpGet]
        public ActionResult CreateBeast()
        {
            ActionResult oResponse = null;

            if (Session["UserName"] != null && (int)Session["Role"] != 1)
            {
                BeastVM beastVM = new BeastVM();

                //map necesary data to populate form dropDownLists
                PopulateDropDownLists(beastVM);
                oResponse = View(beastVM);
            }
            else
            {
                oResponse = RedirectToAction("Index", "Home");
            }
            return oResponse;
        }

        //Method to Create new Beast if users role is at least poweruser
        [HttpPost]
        public ActionResult CreateBeast(BeastVM iViewModel)
        {
            ActionResult oResponse = null;

            if (Session["UserName"] != null && (int)Session["Role"] != 1)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        IBeastDO lBeastForm = BeastMap.MapBeastPOtoDO(iViewModel.Beast);
                        BeastData.InsertBeast(lBeastForm);
                        oResponse = RedirectToAction("ViewAllBeasts", "Beasts");
                    }
                    catch (Exception ex)
                    {
                        //Catch the exception log it, store in VM
                        using (StreamWriter fileWriter = new StreamWriter(@"C:\Users\Lukus\Documents\BootCamp\Projects\Visual Studio\RunescapeMVC\ErrorLogs\Logs.txt"))
                        {
                            fileWriter.WriteLine("{0}-{1}",
                                DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), ex.Message, true);
                        }

                        iViewModel.ErrorMessage = "We apologize, but we were unable to handle your request.";

                        //map necesary data to populate form dropDownLists
                        PopulateDropDownLists(iViewModel);
                        oResponse = View(iViewModel);
                    }
                    finally
                    {
                    }
                }
                else
                {
                    //map necesary data to populate form dropDownLists
                    PopulateDropDownLists(iViewModel);
                    oResponse = View(iViewModel);
                }
            }
            else
            {
                oResponse = RedirectToAction("Index", "Home");
            }
            return oResponse;
        }

        //Method to view all Beast
        [HttpGet]
        public ActionResult ViewAllBeasts()
        {
            BeastVM ViewAllBeastsVM = new BeastVM();
            ActionResult oResponse = null;

            if (Session["UserName"] != null && (int)Session["Role"] >= 1)
            {
                try
                {
                    //Data call to run SQL query
                    List<IBeastDO> allBeasts = BeastData.ViewAllBeasts();
                    
                    ViewAllBeastsVM.ListOfBeastsPO = BeastMap.MapListOfDOsToListOfPOs(allBeasts);

                    oResponse = View(ViewAllBeastsVM);
                }
                catch (Exception ex)
                {
                    //Catch the exception and show error message to user
                    using (StreamWriter fileWriter = new StreamWriter(@"C:\Users\Lukus\Documents\BootCamp\Projects\Visual Studio\RunescapeMVC\ErrorLogs\Logs.txt"))
                    {
                        fileWriter.WriteLine("{0}-{1}",
                            DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), ex.Message, true);
                    }
                    ViewAllBeastsVM.ErrorMessage = "We apologize, but we were unable to handle your request.";

                    oResponse = View(ViewAllBeastsVM);
                }
            }
            else
            {
                oResponse = RedirectToAction("Index", "Home");
            }
            return oResponse;
        }
        //Method to Update Beast if users role is at least poweruser
        [HttpGet]
        public ActionResult UpdateBeast(long beastID)
        {
            ActionResult oResponse = null;

            if (Session["UserName"] != null && (int)Session["Role"] != 1)
            {
                BeastVM beastVM = new BeastVM();

                //Map all necessary data to appropriate types to populate dropDownList
                IBeastDO BeastDO = BeastData.ViewBeastByID(beastID);
                beastVM.Beast = BeastMap.MapBeastDOtoPO(BeastDO);
                PopulateDropDownLists(beastVM);

                oResponse = View(beastVM);
            }
            else
            {
                oResponse = RedirectToAction("Index", "Home");
            }
            return oResponse;
        }

        //Method to Update Beast if users role is at least poweruser
        [HttpPost]
        public ActionResult UpdateBeast(BeastVM iViewModel)
        {
            ActionResult oResponse = null;

            if (Session["UserName"] != null && (int)Session["Role"] != 1)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        IBeastDO lBeastForm = BeastMap.MapBeastPOtoDO(iViewModel.Beast);
                        BeastData.UpdateBeast(lBeastForm);
                        oResponse = RedirectToAction("ViewAllBeasts", "Beasts");
                    }
                    catch (Exception ex)
                    {
                        //log error message to file
                        using (StreamWriter fileWriter = new StreamWriter(@"C:\Users\Lukus\Documents\BootCamp\Projects\Visual Studio\RunescapeMVC\ErrorLogs\Logs.txt"))
                        {
                            fileWriter.WriteLine("{0}-{1}",
                                DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), ex.Message, true);
                        }
                        iViewModel.ErrorMessage = "Sorry, something went wrong.Please try again.";


                        //Map all necessary data to appropriate types to populate dropDownList

                        PopulateDropDownLists(iViewModel);
                        oResponse = View(iViewModel);
                    }
                    finally
                    {
                    }
                }
                else
                {
                    //Map all necessary data to appropriate types to populate dropDownList

                    PopulateDropDownLists(iViewModel);
                    oResponse = View(iViewModel);
                }
            }
            else
            {
                oResponse = RedirectToAction("Index", "Home");
            }
            return oResponse;
        }

        //method to delete beast by ID if role is at least PowerUser
        [HttpGet]
        public ActionResult DeleteBeast(long beastID)
        {
            ActionResult oResponse = null;

            if (Session["UserName"] != null && (int)Session["Role"] != 1)
            {
                try
                {
                    //try to delete beast by ID
                    BeastData.DeleteBeast(beastID);
                }
                catch (Exception ex)
                {
                    BeastVM error = new BeastVM();
                    error.ErrorMessage = "Sorry we are unable to handle your request right now.";

                    using (StreamWriter fileWriter = new StreamWriter(@"C:\Users\Lukus\Documents\BootCamp\Projects\Visual Studio\RunescapeMVC\ErrorLogs\Logs.txt"))
                    {
                        fileWriter.WriteLine("{0}-{1}",
                            DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), ex.Message, true);
                    }
                }
                finally
                {
                    //always return to viewall to confirm delete
                    oResponse = RedirectToAction("ViewAllBeasts", "Beasts");
                }
            }
            else
            {
                oResponse = RedirectToAction("Index", "Home");
            }
            return oResponse;
        }
        
        //Method to populate beast form dropdown lists
        public void PopulateDropDownLists(BeastVM iViewModel)
        {
            List<IAreaInfoDO> Areas = AreaData.ViewAllAreas();
            List<IMasterDO> Masters = MasterData.ViewAllMasters();

            iViewModel.Beast.AreasDropDown = new SelectList(Areas, "AreaID", "AreaName");
            iViewModel.Beast.MastersDropDown = new SelectList(Masters, "SlayerMasterID", "MasterName");

        }
    }
}