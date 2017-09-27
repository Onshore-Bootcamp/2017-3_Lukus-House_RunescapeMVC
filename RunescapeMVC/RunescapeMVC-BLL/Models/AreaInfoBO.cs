namespace RunescapeMVC_BLL.Models
{
    public class AreaInfoBO : IAreaInfoBO
    {
        public long AreaID { get; set; }

        public string AreaName { get; set; }

        public string Kingdom { get; set; }

        public string Climate { get; set; }

        public int BeastsInArea { get; set; }
    }
}
