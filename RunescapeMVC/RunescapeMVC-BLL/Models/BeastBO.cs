namespace RunescapeMVC_BLL.Models
{
    public class BeastBO : IBeastBO
    {
        public long BeastID { get; set; }

        public string Name { get; set; }

        public int SlayerLevelReq { get; set; }

        public int BeastCombatLevel { get; set; }

        public long Lifepoints { get; set; }

        public string Weakness { get; set; }

        public string AttackStyles { get; set; }

        public bool Members { get; set; }

        public long AreaID { get; set; }

        public string AreaName { get; set; }

        public string Gear { get; set; }

        public string ExpPerKill { get; set; }

        public long AssignedBy { get; set; }

        public string MasterName { get; set; }

    }
}
