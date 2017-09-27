using System.ComponentModel.DataAnnotations;

namespace RunescapeMVC.Models
{
    public class AreaInfoPO
    {
        public long AreaID { get; set; }

        [Required]
        public string AreaName { get; set; }

        [Required]
        public string Kingdom { get; set; }

        [Required]
        public string Climate { get; set; }

        public int BeastsInArea { get; set; }

    }
}