namespace RunescapeMVC_DAL
{
    public interface IBeastDO
    {
        long BeastID { get; set; }

        string Name { get; set; }

        int SlayerLevelReq { get; set; }

        int BeastCombatLevel { get; set; }

        long Lifepoints { get; set; }

        string Weakness { get; set; }

        string AttackStyles { get; set; }

        bool Members { get; set; }

        long AreaID { get; set; }

        string Gear { get; set; }

        string ExpPerKill { get; set; }

        long AssignedBy { get; set; }

        string AreaName { get; set; }

        string MasterName { get; set; }
    }
}
