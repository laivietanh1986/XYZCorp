using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XYZCorp.Utility
{
    public static class Message
    {
        public const string UserNotExist = "User does not exist.";
        public const string UserCouldNotCreate = "Could not create user.";
        public const string NameAlreadyExist = "There is same user with this name in system.";
        public const string NameIsEmpty = "Name is empty.";
        public const string PointMustGreaterThanZero = "Point must greater than zero.";
    }
    public enum ResultValue
    {
        Success,Fail
    }
}