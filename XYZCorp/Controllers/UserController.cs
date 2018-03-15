using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XYZCorp.Models;
using XYZCorp.Services;
using XYZCorp.Utility;

namespace XYZCorp.Controllers
{
   
    public class UsersController : ApiController
    {
        private readonly IUserServices userServices;
        public UsersController()
        {
            //todo: will upgrade to user Dependency injection here  
            userServices = new UserServices();
        }

        /// <summary>
        /// Return an array of all saved users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, userServices.GetUserList());            
        }

        /// <summary>
        /// Return Match User 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var result = userServices.GetUser(id);
            if (result.Result== ResultValue.Fail)
            {
               return Request.CreateResponse(HttpStatusCode.NotFound, Message.UserNotExist);
                
            }
            return Request.CreateResponse(HttpStatusCode.OK, (User)result.Data);
            
        }

        /// <summary>
        /// Add Users to List
        /// </summary>
        /// <param name="user">User Object</param>
        [HttpPost]        
        public HttpResponseMessage Post([FromBody]User user)
        {
            var result = userServices.InsertUser(user);
            if (result.Result == ResultValue.Fail)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, result.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, (int)result.Data);
            
        }
        /// <summary>
        /// Assign the points the user whose id matches,
        /// </summary>
        /// <param name="user">User Point Object</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/setPoints")]
        public HttpResponseMessage SetPoints([FromBody]UserPoint user)
        {
            var result = userServices.SetPoint(user);
            if (result.Result == ResultValue.Fail)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, Message.UserNotExist);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        

        
    }
}
