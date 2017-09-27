using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RunescapeMVC.Models
{
    public class BeastPO
    {
        public long BeastID { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name= "Required Slayer Level")]
        [Required]
        public int SlayerLevelReq { get; set; }

        [Display(Name= "Combat Level")]
        [Required]
        public int BeastCombatLevel { get; set; }

        [Required]
        public long Lifepoints { get; set; }

        [Required]
        public string Weakness { get; set; }

        [Required]
        public bool Members { get; set; }

        [Display(Name="Area")]
        [Required]
        public long AreaID { get; set; }
        
        public string AreaName { get; set; }

        [Required]
        public string Gear { get; set; }

        [Display (Name = "Exp/Kill")]
        [Required]
        public string ExpPerKill { get; set; }

        [Display (Name ="Assigned By")]
        [Required]
        public long AssignedBy { get; set; }
        
        public string MasterName { get; set; }

        public SelectList AreasDropDown { get; set; }

        public SelectList MastersDropDown { get; set; }
    }
}