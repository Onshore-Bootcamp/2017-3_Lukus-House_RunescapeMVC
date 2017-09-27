namespace RunescapeMVC_DAL.Models
{
    public class AreaInfoDO : IAreaInfoDO
    {
        public long AreaID { get; set; }

        public string AreaName { get; set; }

        public string Kingdom { get; set; }

        public string Climate { get; set; }

        public int BeastsInArea { get; set; }

    }
}
