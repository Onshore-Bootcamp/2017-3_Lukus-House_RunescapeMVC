using RunescapeMVC.Models;
using RunescapeMVC_DAL;
using RunescapeMVC_DAL.Models;
using System.Collections.Generic;

namespace RunescapeMVC.ViewModels
{
    public class BeastVM
    {
        public BeastVM()
        {
            Beast = new BeastPO();
            ListOfAreas = new List<IAreaInfoDO>();
            ListOfBeastsDO = new List<BeastDO>();
            ListOfBeastsPO = new List<BeastPO>();

        }
        public BeastPO Beast { get; set; }

        public List<BeastPO> ListOfBeastsPO { get; set; }

        public List<BeastDO> ListOfBeastsDO { get; set; }

        public List<IAreaInfoDO> ListOfAreas { get; set; }

        public string ErrorMessage { get; set; }

    }
}