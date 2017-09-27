namespace RunescapeMVC_DAL
{
    public interface IMasterDO
    {
        long SlayerMasterID { get; set; }

        string MasterName { get; set; }

        int ReqSlayerLevel { get; set; }

        int RequiredCombatLevel { get; set; }

        string RequiredQuests { get; set; }

        string Location { get; set; }
    }
}
