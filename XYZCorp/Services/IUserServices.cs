using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYZCorp.Models;
using XYZCorp.Utility;

namespace XYZCorp.Services
{
    public interface IUserServices
    {        
        IEnumerable<User> GetUserList();
        CommonResult GetUser(int id);
        CommonResult InsertUser(User user);
        CommonResult SetPoint(UserPoint user);
    }
}
