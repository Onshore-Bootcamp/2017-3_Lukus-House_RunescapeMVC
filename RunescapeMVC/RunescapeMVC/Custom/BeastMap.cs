namespace RunescapeMVC.Custom
{
    using Models;
    using RunescapeMVC_BLL;
    using RunescapeMVC_BLL.Models;
    using RunescapeMVC_DAL;
    using RunescapeMVC_DAL.Models;
    using System;
    using System.Collections.Generic;

    public class BeastMap
    {
        //Method to map a PO to a DO
        public static IBeastDO MapBeastPOtoDO(BeastPO iBeast)
        {
            //New class instantiation
            IBeastDO oBeast = new BeastDO();
            try
            {
                oBeast.BeastID = iBeast.BeastID;
                oBeast.Name = iBeast.Name;
                oBeast.SlayerLevelReq = iBeast.SlayerLevelReq;
                oBeast.BeastCombatLevel = iBeast.BeastCombatLevel;
                oBeast.Lifepoints = iBeast.Lifepoints;
                oBeast.Weakness = iBeast.Weakness;
                oBeast.Members = iBeast.Members;
                oBeast.AreaID = iBeast.AreaID;
                oBeast.AreaName = iBeast.AreaName;
                oBeast.Gear = iBeast.Gear;
                oBeast.ExpPerKill = iBeast.ExpPerKill;
                oBeast.AssignedBy = iBeast.AssignedBy;
                oBeast.MasterName = iBeast.MasterName;
            }
            catch (Exception)
            {
                throw;
            }
            return oBeast;
        }

        //Method to map a DO to PO
        public static BeastPO MapBeastDOtoPO(IBeastDO iBeast)
        {
            //New class instantiation
            BeastPO oBeast = new BeastPO();
            try
            {
                oBeast.BeastID = iBeast.BeastID;
                oBeast.Name = iBeast.Name;
                oBeast.SlayerLevelReq = iBeast.SlayerLevelReq;
                oBeast.BeastCombatLevel = iBeast.BeastCombatLevel;
                oBeast.Lifepoints = iBeast.Lifepoints;
                oBeast.Weakness = iBeast.Weakness;
                oBeast.Members = iBeast.Members;
                oBeast.AreaID = iBeast.AreaID;
                oBeast.Gear = iBeast.Gear;
                oBeast.ExpPerKill = iBeast.ExpPerKill;
                oBeast.AssignedBy = iBeast.AssignedBy;
                oBeast.AreaName = iBeast.AreaName;
                oBeast.MasterName = iBeast.MasterName;
            }
            catch (Exception)
            {
                throw;
            }
            return oBeast;
        }

        //Method to map DO to BO
        public static IBeastBO MapBeastDOtoBO(IBeastDO iBeast)
        {
            IBeastBO oBeast = new BeastBO();
            try
            {
                oBeast.BeastID = iBeast.BeastID;
                oBeast.Name = iBeast.Name;
                oBeast.SlayerLevelReq = iBeast.SlayerLevelReq;
                oBeast.BeastCombatLevel = iBeast.BeastCombatLevel;
                oBeast.Lifepoints = iBeast.Lifepoints;
                oBeast.Weakness = iBeast.Weakness;
                oBeast.AttackStyles = iBeast.AttackStyles;
                oBeast.Members = iBeast.Members;
                oBeast.AreaID = iBeast.AreaID;
                oBeast.Gear = iBeast.Gear;
                oBeast.ExpPerKill = iBeast.ExpPerKill;
                oBeast.AssignedBy = iBeast.AssignedBy;
                oBeast.AreaName = iBeast.AreaName;
                oBeast.MasterName = iBeast.MasterName;
            }
            catch (Exception)
            {
                throw;
            }
            return oBeast;
        }

        //Method to map BO to PO
        public static BeastPO MapBeastBOtoPO(BeastBO iBeast)
        {
            BeastPO oBeast = new BeastPO();
            try
            {
                oBeast.BeastID = iBeast.BeastID;
                oBeast.Name = iBeast.Name;
                oBeast.SlayerLevelReq = iBeast.SlayerLevelReq;
                oBeast.BeastCombatLevel = iBeast.BeastCombatLevel;
                oBeast.Lifepoints = iBeast.Lifepoints;
                oBeast.Weakness = iBeast.Weakness;
                oBeast.Members = iBeast.Members;
                oBeast.AreaID = iBeast.AreaID;
                oBeast.Gear = iBeast.Gear;
                oBeast.ExpPerKill = iBeast.ExpPerKill;
                oBeast.AssignedBy = iBeast.AssignedBy;
                oBeast.AreaName = iBeast.AreaName;
                oBeast.MasterName = iBeast.MasterName;
            }
            catch (Exception)
            {
                throw;
            }
            return oBeast;
        }

        //Method to map a list of DOs to a list of POs
        public static List<BeastPO> MapListOfDOsToListOfPOs(List<IBeastDO> iBeastDOs)
        {
            List<BeastPO> listOfBeastPOs = new List<BeastPO>();
            try
            {
                //Foreach loop to map each object in the list
                foreach (IBeastDO Beast in iBeastDOs)
                {
                    BeastPO BeastPO = MapBeastDOtoPO(Beast);
                    listOfBeastPOs.Add(BeastPO);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listOfBeastPOs;
        }
        public static List<IBeastBO> MapListOfDOsToListOfBOs(List<IBeastDO> iBeastDOs)
        {
            List<IBeastBO> listOfBeastBOs = new List<IBeastBO>();
            try
            {
                //Foreach loop to map each object in the list
                foreach (IBeastDO Beast in iBeastDOs)
                {
                    IBeastBO BeastBO = MapBeastDOtoBO(Beast);
                    listOfBeastBOs.Add(BeastBO);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listOfBeastBOs;
        }
    }
}