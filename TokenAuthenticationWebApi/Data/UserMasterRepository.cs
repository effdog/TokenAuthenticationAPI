using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokenAuthenticationWebApi.Models;

namespace TokenAuthenticationWebApi.Data
{
    public class UserMasterRepository
    {
        //validate user cred
        public UserMaster ValidateUser(string username, string password)
        {

            if (username == "user" && password == "password")
            {
                UserMaster obj = new UserMaster
                {
                    UserName = username,
                    Password = password
                };

                return obj;
            }

            return null;

        }

    }
}