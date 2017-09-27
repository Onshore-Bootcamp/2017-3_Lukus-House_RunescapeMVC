namespace RunescapeMVC_DAL.Models
{
    public class MasterDO : IMasterDO
    {
        public long SlayerMasterID { get; set; }

        public string MasterName { get; set; }

        public int ReqSlayerLevel { get; set; }

        public int RequiredCombatLevel { get; set; }

        public string RequiredQuests { get; set; }

        public string Location { get; set; }

    }
}
