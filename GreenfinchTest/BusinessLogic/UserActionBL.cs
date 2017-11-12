using AbstractedORMLibrary;
using GreenfinchTest.Entity;
using GreenfinchTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenfinchTest.BusinessLogic
{
    public static class UserActionBL
    {
        public static bool DidUserCreatedBefore(string email)
        {
            var dataProvider = DataBase.DataProvider(EDataAccessType.NPoco);
            return dataProvider.Select<LoginUser>(x => x.EMail == email ).FirstOrDefault() != null;
        }


        public static string GetUserName(string email, string password)
        {
            var dataProvider = DataBase.DataProvider(EDataAccessType.NPoco);
            return dataProvider.Select<LoginUser>(x => x.EMail == email && x.Password == password).FirstOrDefault().UserName;
        }
        public static bool AuthorizeUser(LoginViewModel userInfo) {
            var dataProvider = DataBase.DataProvider(EDataAccessType.NPoco);
            return dataProvider.Select<LoginUser>(x => x.EMail == userInfo.Email && x.Password == userInfo.Password).FirstOrDefault() != null;
        }

        public static bool RegisterUser(RegisterViewModel userInfo)
        {
            var dataProvider = DataBase.DataProvider(EDataAccessType.NPoco);
            var loginUser = new LoginUser {
                EMail = userInfo.Email,
                Password = userInfo.Password,
                UserName = userInfo.UserName,
                HeardId = userInfo.HeardId,
                Reason = userInfo.Reason
            };
            return dataProvider.SaveOrUpdate(loginUser);
        }

        public static List<HeardAbout> GetHeardAboutList() {
            var dataProvider = DataBase.DataProvider(EDataAccessType.NPoco);
            return dataProvider.Select<HeardAbout>(null).ToList();
        }
    }
}