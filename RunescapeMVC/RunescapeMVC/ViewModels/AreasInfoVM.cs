using RunescapeMVC.Models;
using RunescapeMVC_DAL.Models;
using System.Collections.Generic;

namespace RunescapeMVC.ViewModels
{
    public class AreasInfoVM
    {
        public AreasInfoVM()
        {
            Area = new AreaInfoPO();
            ListOfAreasPO = new List<AreaInfoPO>();
            ListOfAreaDO = new List<AreaInfoDO>();
            //BeastsInArea = new int();
        }
        public AreaInfoPO Area { get; set; }
    
        public List<AreaInfoPO> ListOfAreasPO { get; set; }

        public List<AreaInfoDO> ListOfAreaDO { get; set; }

        public int BeastsInArea { get; set; }
        
        public string ErrorMessage { get; set; }
    }
}