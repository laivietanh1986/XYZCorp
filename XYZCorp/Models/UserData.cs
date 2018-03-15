using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XYZCorp.Models
{
    public static class UserData
    {
        private static List<UserEntity> data;
        public static void InitData()
        {
            data = new List<UserEntity>()
            {
                new UserEntity(){Id=1,Name="Viet Anh",Points= 10},
                new UserEntity(){Id=2,Name="Hai Tung",Points= 9},
                new UserEntity(){Id=3,Name="Nguyen Hoang",Points= 8},
                new UserEntity(){Id=4,Name="Dinh Cuong",Points= 7},

            };
        }
        public static List<UserEntity>  GetUserData()
        {
            return data;
        }

    }
}
