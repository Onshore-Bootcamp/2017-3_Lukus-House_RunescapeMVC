namespace RunescapeMVC.Custom
{
    using Models;
    using RunescapeMVC_DAL;
    using RunescapeMVC_DAL.Models;
    using System;
    using System.Collections.Generic;

    public class MasterMap
    {
        //Method to map a PO to a DO
        public static IMasterDO MapMasterPOtoDO(MasterPO iMasterInfo)
        {
            //New class instantiation
            IMasterDO oMaster = new MasterDO();
            try
            {
                oMaster.SlayerMasterID = iMasterInfo.SlayerMasterID;
                oMaster.MasterName = iMasterInfo.MasterName;
                oMaster.ReqSlayerLevel = iMasterInfo.ReqSlayerLevel;
                oMaster.RequiredCombatLevel = iMasterInfo.RequiredCombatLevel;
                oMaster.RequiredQuests = iMasterInfo.RequiredQuests;
                oMaster.Location = iMasterInfo.Location;
            }
            catch (Exception)
            {
                throw;
            }
            return oMaster;
        }

        //Method to map a DO to PO
        public static MasterPO MapMasterDOtoPO(IMasterDO iMasterInfo)
        {
            //New class instantiation
            MasterPO oMaster = new MasterPO();
            try
            {
                oMaster.SlayerMasterID = iMasterInfo.SlayerMasterID;
                oMaster.MasterName = iMasterInfo.MasterName;
                oMaster.ReqSlayerLevel = iMasterInfo.ReqSlayerLevel;
                oMaster.RequiredCombatLevel = iMasterInfo.RequiredCombatLevel;
                oMaster.RequiredQuests = iMasterInfo.RequiredQuests;
                oMaster.Location = iMasterInfo.Location;
            }
            catch (Exception)
            {
                throw;
            }
            return oMaster;
        }

        //Method to map a list of DOs to a list of POs
        public static List<MasterPO> MapListOfDOsToListOfPOs(List<IMasterDO> iMasterDOs)
        {
            List<MasterPO> listOfMasterPOs = new List<MasterPO>();
            try
            {
                //Foreach loop to map each object in the list
                foreach (IMasterDO Master in iMasterDOs)
                {
                    MasterPO MasterPO = MapMasterDOtoPO(Master);
                    listOfMasterPOs.Add(MasterPO);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listOfMasterPOs;
        }
    }
}