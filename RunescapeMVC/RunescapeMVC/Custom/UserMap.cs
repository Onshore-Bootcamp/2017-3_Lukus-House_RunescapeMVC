using RunescapeMVC.Models;
using RunescapeMVC_DAL;
using RunescapeMVC_DAL.Models;
using System;
using System.Collections.Generic;

namespace RunescapeMVC.Custom
{
    public class UserMap
    {
        //Method to map a PO to a DO
        public static IUserDO MapUserPOtoDO(UserPO iUserInfo)
        {
            //New class instantiation
            IUserDO oUser = new UserDO();
            try
            {
                oUser.UserID = iUserInfo.UserID;
                oUser.UserName = iUserInfo.UserName;
                oUser.Password = iUserInfo.Password;
                oUser.Role = iUserInfo.Role;
                oUser.FirstName = iUserInfo.FirstName;
                oUser.LastName = iUserInfo.LastName;
            }
            catch (Exception)
            {
                throw;
            }
            return oUser;
        }

        //Method to map a DO to PO
        public static UserPO MapUserDOtoPO(IUserDO iUserInfo)
        {
            //New class instantiation
            UserPO oUser = new UserPO();
            try
            {
                oUser.UserID = iUserInfo.UserID;
                oUser.UserName = iUserInfo.UserName;
                oUser.Password = iUserInfo.Password;
                oUser.Role = iUserInfo.Role;
                oUser.FirstName = iUserInfo.FirstName;
                oUser.LastName = iUserInfo.LastName;
            }
            catch (Exception)
            {
                throw;
            }
            return oUser;
        }

        //Method to map a list of DOs to a list of POs
        public static List<UserPO> MapListOfDOsToListOfPOs(List<IUserDO> iUserDOs)
        {
            List<UserPO> listOfUserPOs = new List<UserPO>();
            try
            {
                //Foreach loop to map each object in the list
                foreach (IUserDO user in iUserDOs)
                {
                    UserPO userPO = MapUserDOtoPO(user);
                    listOfUserPOs.Add(userPO);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listOfUserPOs;
        }
    }
}