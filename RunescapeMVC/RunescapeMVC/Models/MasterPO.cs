using System.ComponentModel.DataAnnotations;

namespace RunescapeMVC.Models
{
    public class MasterPO
    {
        public long SlayerMasterID { get; set; }

        [Required]
        public string MasterName { get; set; }

        [Required]
        public int ReqSlayerLevel { get; set; }

        [Required]
        public int RequiredCombatLevel { get; set; }

        [Required]
        public string RequiredQuests { get; set; }

        [Required]
        public string Location { get; set; }

    }
}