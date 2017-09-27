namespace RunescapeMVC_BLL
{
    public interface IAreaInfoBO
    {
        long AreaID { get; set; }

        string AreaName { get; set; }

        string Kingdom { get; set; }

        string Climate { get; set; }

        int BeastsInArea { get; set; }
    }
}
