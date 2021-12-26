using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WorkshopData;

namespace WorkshopAPI.Controllers
{
    [RoutePrefix("api/Workshop")]
    public class WorkshopController : ApiController
    {
        #region Get
        [HttpGet]
        public IHttpActionResult GetWorkshops()
        {
            using(conString con = new conString())
            {
                try
                {
                    var response = con.SP_GetWorkshops().ToList<SP_GetWorkshops_Result>();
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

        [HttpGet]
        [Route("WorkshopByUserId")]
        public IHttpActionResult GetWorkshopByUser(int StudentId)
        {
            using (conString con = new conString())
            {
                try
                {
                    var response = con.SP_GetWorkShopByUser(StudentId).ToList<SP_GetWorkShopByUser_Result>();
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

        [HttpGet]
        [Route("WorkshopById")]
        public IHttpActionResult GetWorkshopById(int WorkshopId)
        {
            using (conString con = new conString())
            {
                try
                {
                    var response = con.SP_GetWorkshopById(WorkshopId).ToList<SP_GetWorkshopById_Result>();
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

        [HttpGet]
        [Route("WorkshopRequest")]
        public IHttpActionResult GetWorkshopRequest()
        {
            using (conString con = new conString())
            {
                try
                {
                    var response = con.SP_GetWorkshopRequest().ToList<SP_GetWorkshopRequest_Result>();
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
        [HttpPost]
        [Route("InsertWorkshop")]
        public IHttpActionResult InsertWorkshop(WorkShop Wp)
        {
            using(conString con = new conString())
            {
                try
                {
                    var response = con.SP_InsertWorkshop(Wp.WorkShopTitle, Wp.WorkShopDate, Wp.WorkShopDuration, Wp.WorkShopTopics);
                    return Created("Success", response);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut]
        [Route("UpdateWorkshop")]
        public IHttpActionResult UpdateWorkshopById(WorkShop Wp)
        {
            using (conString con = new conString())
            {
                try
                {
                    var response = con.SP_UpdateWorkshopById(Wp.WorkShopTitle, Wp.WorkShopDate, Wp.WorkShopDuration, Wp.WorkShopTopics, Wp.WorkShopId);
                    if (response < 1)
                    {
                        return InternalServerError();
                    }
                    else
                    {
                        return Ok("Success");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpDelete]
        [Route("DeleteWorkshop")]
        public IHttpActionResult DeleteWorkshopById(int WorkshopId)
        {
            using (conString con = new conString())
            {
                try
                {
                    var response = con.SP_DeleteWorkshopById(WorkshopId);
                    if (response < 1)
                    {
                        return InternalServerError();
                    }
                    else
                    {
                        return Ok("Success");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPost]
        [Route("AssignTrainers")]
        public IHttpActionResult AssignTrainersToWorkShop(Trainer_WorkShop_Mapping TWM)
        {
            using (conString con = new conString())
            {
                try
                {
                    var response = con.SP_InsertIntoTrainerWorkshopMapping(TWM.TrainerId, TWM.WorkShopId);
                    if (response < 1)
                    {
                        return InternalServerError();
                    }
                    else
                    {
                        return Ok("Success");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut]
        [Route("AppOrRejWorkshop")]
        public IHttpActionResult AppOrRejectWorkshopRequest(Student_WorkShop_Mapping SWM)
        {
            using (conString con = new conString())
            {
                try
                {
                    var response = con.SP_AppOrRejectWorkshopRequest(SWM.ISApproved, SWM.SerialNo);
                    if (response < 1)
                    {
                        return InternalServerError();
                    }
                    else 
                    {
                        return Ok("Success");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        #endregion 
    }
}
