namespace RunescapeMVC.Custom
{
    using RunescapeMVC.Models;
    using RunescapeMVC_BLL;
    using RunescapeMVC_BLL.Models;
    using RunescapeMVC_DAL;
    using RunescapeMVC_DAL.Models;
    using System;
    using System.Collections.Generic;

    public class Map
    {
        //Method to map a PO to a DO
        public static IAreaInfoDO MapAreaPOtoDO(AreaInfoPO iAreaInfo)
        {
            //New class instantiation
            IAreaInfoDO oArea = new AreaInfoDO();
            try
            {
                oArea.AreaID = iAreaInfo.AreaID;
                oArea.AreaName = iAreaInfo.AreaName;
                oArea.Kingdom = iAreaInfo.Kingdom;
                oArea.Climate = iAreaInfo.Climate;
                oArea.BeastsInArea = iAreaInfo.BeastsInArea;
            }
            catch (Exception)
            {
                throw;
            }
            return oArea;
        }

        //Method to map a DO to PO
        public static AreaInfoPO MapAreaDOtoPO(IAreaInfoDO iAreaInfo)
        {
            //New class instantiation
            AreaInfoPO oArea = new AreaInfoPO();
            try
            {
                oArea.AreaID = iAreaInfo.AreaID;
                oArea.AreaName = iAreaInfo.AreaName;
                oArea.Kingdom = iAreaInfo.Kingdom;
                oArea.Climate = iAreaInfo.Climate;
                oArea.BeastsInArea = iAreaInfo.BeastsInArea;
            }
            catch (Exception)
            {
                throw;
            }
            return oArea;
        }

        //Method to map DO to BO
        public static IAreaInfoBO MapAreaDOtoBO(IAreaInfoDO iAreaInfo)
        {
            IAreaInfoBO oArea = new AreaInfoBO();
            try
            {
                oArea.AreaID = iAreaInfo.AreaID;
                oArea.AreaName = iAreaInfo.AreaName;
                oArea.Kingdom = iAreaInfo.Kingdom;
                oArea.Climate = iAreaInfo.Climate;
                oArea.BeastsInArea = iAreaInfo.BeastsInArea;
            }
            catch (Exception)
            {
                throw;
            }
            return oArea;
        }

        //Method to map BO to PO
        public static AreaInfoPO MapAreaBOtoPO(IAreaInfoBO iAreaInfo)
        {
            AreaInfoPO oArea = new AreaInfoPO();
            try
            {
                oArea.AreaID = iAreaInfo.AreaID;
                oArea.AreaName = iAreaInfo.AreaName;
                oArea.Kingdom = iAreaInfo.Kingdom;
                oArea.Climate = iAreaInfo.Climate;
                oArea.BeastsInArea = iAreaInfo.BeastsInArea;
            }
            catch (Exception)
            {
                throw;
            }
            return oArea;
        }
        //Method to map a list of DOs to a list of POs
        public static List<AreaInfoPO> MapListOfDOsToListOfPOs(List<IAreaInfoDO> iAreaDOs)
        {
            List<AreaInfoPO> listOfAreaPOs = new List<AreaInfoPO>();
            try
            {
                //Foreach loop to map each object in the list
                foreach (IAreaInfoDO area in iAreaDOs)
                {
                    AreaInfoPO areaPO = MapAreaDOtoPO(area);
                    listOfAreaPOs.Add(areaPO);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listOfAreaPOs;
        }
        public static List<IAreaInfoBO> MapListOfDOsToListOfBOs(List<IAreaInfoDO> iAreaDOs)
        {
            List<IAreaInfoBO> listOfAreaBOs = new List<IAreaInfoBO>();
            try
            {
                //Foreach loop to map each object in the list
                foreach (IAreaInfoDO Area in iAreaDOs)
                {
                    IAreaInfoBO AreaBO = MapAreaDOtoBO(Area);
                    listOfAreaBOs.Add(AreaBO);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listOfAreaBOs;
        }
        public static List<AreaInfoPO> MapListOfBOsToListOfPOs(List<IAreaInfoBO> iAreaBOs)
        {
            List<AreaInfoPO> listOfAreaBOs = new List<AreaInfoPO>();
            try
            {
                foreach (IAreaInfoBO Area in iAreaBOs)
                {
                    AreaInfoPO AreaPO = MapAreaBOtoPO(Area);
                    listOfAreaBOs.Add(AreaPO);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listOfAreaBOs;
        }
    }
}