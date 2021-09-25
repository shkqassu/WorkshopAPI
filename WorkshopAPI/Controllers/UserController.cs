using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WorkshopData;

namespace WorkshopAPI.Controllers
{
    public class UserController : ApiController
    {
        #region Get
        public List<SP_GetStudents_Result> GetStudents()
        {
            using (conString con = new conString())
            {
                return con.SP_GetStudents().ToList<SP_GetStudents_Result>();
            }
        }

        public List<SP_GetTrainers_Result> GetTrainers()
        {
            using (conString con = new conString())
            {
                return con.SP_GetTrainers().ToList<SP_GetTrainers_Result>();
            }
        }

        public UserDetail GetUserById(string Username)
        {
            using (conString con = new conString())
            {
                return con.UserDetails.Find(Username);
            }
        }

        public bool ValidateUser(string Username)
        {
            using (conString con = new conString())
            {
                try
                {
                    if (con.UserDetails.Any(x => x.UserName_Email == Username))
                    {
                        return true;
                    }
                    else
                        return false;
                }
                catch
                {
                    return false;
                    throw;
                }
            }
        }
        #endregion

        #region Post

        #endregion
    }
}
