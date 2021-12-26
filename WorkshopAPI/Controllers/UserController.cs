using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WorkshopData;

namespace WorkshopAPI.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        #region Get
        [Route("AllStudents")]
        public IHttpActionResult GetStudents()
        {
            using (conString con = new conString())
            {
                try
                {
                    var response = con.SP_GetAllStudents().ToList<SP_GetAllStudents_Result>();
                    if (response.Count <= 0)
                    {
                        return NotFound();
                    }
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [Route("AllTrainers")]
        public IHttpActionResult GetTrainers()
        {
            using (conString con = new conString())
            {
                try
                {
                    var response = con.SP_GetTrainers().ToList<SP_GetTrainers_Result>();
                    if (response.Count <= 0)
                    {
                        return NotFound();
                    }
                    return Ok(response);
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [Route("UsersByUserName")]
        public IHttpActionResult GetUserByUserName(string Username)
        {
            using (conString con = new conString())
            {
                try
                {
                    con.Configuration.ProxyCreationEnabled = false;
                    var response = con.UserDetails.Where(x => x.UserName_Email == Username).ToList();
                    if (response.Count <= 0)
                    {
                        return NotFound();
                    }
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [Route("UserById")]
        public IHttpActionResult GetUserById(int UserId)
        {
            using (conString con = new conString())
            {
                try
                {
                    var response = con.SP_GetUserById(UserId).ToList<SP_GetUserById_Result>();
                    if (response.Count <= 0)
                    {
                        return NotFound();
                    }
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        #endregion

        #region Post
        [Route("ValidateUserByUsername")]
        public IHttpActionResult ValidateUser(string Username)
        {
            using (conString con = new conString())
            {
                try
                {
                    var response = con.UserDetails.Any(x => x.UserName_Email == Username);
                    if (response == false)
                    {
                        return NotFound();
                    }
                    else
                        return Ok(response);
                }
                catch
                {
                    return BadRequest();
                }
            }
        }
        
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
