using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using XYZCorp.Models;
using XYZCorp.Utility;

namespace XYZCorp.Services
{
    public class UserServices:IUserServices
    {
        
        public UserServices()
        {
            //// init one times
            if (UserData.GetUserData()== null)
            {
                UserData.InitData();
            }

        }

        public CommonResult GetUser(int id)
        {            
             var user =  UserData
                .GetUserData()
                .FirstOrDefault(x=>x.Id == id);
            if (user == null)
            {
                return new CommonResult() { Result = ResultValue.Fail };
            }
            return new CommonResult() {
                Result = ResultValue.Success,
                Data = new User()
                {
                    Name = user.Name,
                    Points = user.Points
                }
            };
        }

        public IEnumerable<User> GetUserList()
        {            
            return UserData
                .GetUserData()
                .Select(x => new User() {
                Name = x.Name,
                Points = x.Points
            });
        }

        public CommonResult InsertUser(User user)
        {
            var userData = UserData.GetUserData();
            if (string.IsNullOrEmpty(user.Name) )
            {
                return new CommonResult() { Result = ResultValue.Fail,Message = Message.NameIsEmpty };
            }            
            if (userData.Any(u => u.Name == user.Name))
            {
                return new CommonResult() { Result = ResultValue.Fail,Message = Message.NameAlreadyExist };
            }
            if (user.Points <0)
            {
                return new CommonResult() { Result = ResultValue.Fail, Message = Message.PointMustGreaterThanZero };
            }
            var newUser = new UserEntity()
            {
                Id = userData.Max(x => x.Id) + 1,
                Name = user.Name,
                Points = user.Points
            };
            userData.Add(newUser);
            return new CommonResult() { Result = ResultValue.Success, Data = newUser.Id };
        }

        public CommonResult SetPoint(UserPoint user)
        {
            var updateUser = UserData.GetUserData().FirstOrDefault(u => u.Id == user.Id);
            if (updateUser == null)
            {                
                return new CommonResult() { Result = ResultValue.Fail };
            }
            if (user.Points < 0)
            {
                return new CommonResult() { Result = ResultValue.Fail, Message = Message.PointMustGreaterThanZero };
            }
            updateUser.Points = user.Points;            
            return new CommonResult() { Result = ResultValue.Success};
        }
    }
}