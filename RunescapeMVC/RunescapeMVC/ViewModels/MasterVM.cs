using RunescapeMVC.Models;
using RunescapeMVC_DAL.Models;
using System.Collections.Generic;

namespace RunescapeMVC.ViewModels
{
    public class MasterVM
    {
        public MasterPO Master { get; set; }

        public List<MasterPO> ListOfMastersPO { get; set; }

        public List<MasterDO> ListOfMastersDO { get; set; }

        public string ErrorMessage { get; set; }
    }
}