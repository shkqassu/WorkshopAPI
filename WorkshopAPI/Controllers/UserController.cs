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

        public UserDetail GetUserByUserName(string Username)
        {
            using (conString con = new conString())
            {
                return con.UserDetails.Find(Username);
            }
        }

        public List<SP_GetUserById_Result> GetUserById(int UserId)
        {
            using (conString con = new conString())
            {
                return con.SP_GetUserById(UserId).ToList<SP_GetUserById_Result>();
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
        public bool CreateUserRequest(UserDetail UD)
        {
            using (conString con = new conString())
            {
                try
                {
                    con.SP_InsertIntoUserDetailsOfStudents(UD.UserName_Email);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool CreateTrainer(UserDetail UD)
        {
            using (conString con = new conString())
            {
                try
                {
                    con.SP_CreateTrainer(UD.UserName_Email, UD.FirstName, UD.LastName, UD.RoleId);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool ActivateDeactivateUsers(UserDetail UD)
        {
            using (conString con = new conString())
            {
                try
                {
                    con.SP_ActivateDeactivateUsers(UD.Userid, UD.IsActive);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool UpdateUsers(UserDetail UD)
        {
            using (conString con = new conString())
            {
                try
                {
                    con.SP_UpdateUsers(UD.FirstName, UD.LastName, UD.UserGender, UD.Mobile, UD.SkillsSet, UD.Experience, UD.UserDob, UD.RoleId, UD.Userid);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        #endregion
    }
}
