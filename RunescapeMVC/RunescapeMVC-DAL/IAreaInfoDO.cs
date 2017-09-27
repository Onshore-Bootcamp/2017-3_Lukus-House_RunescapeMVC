namespace RunescapeMVC_DAL
{
    public interface IAreaInfoDO
    {
        long AreaID { get; set; }

        string AreaName { get; set; }

        string Kingdom { get; set; }

        string Climate { get; set; }

        int BeastsInArea { get; set; }
    }
}
