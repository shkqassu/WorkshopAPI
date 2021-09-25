﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WorkshopData;

namespace WorkshopAPI.Controllers
{
    [RoutePrefix("api/workshop")]
    public class WorkshopController : ApiController
    {
        #region Get
        [HttpGet]
        public List<SP_GetWorkshops_Result> GetWorkshops()
        {
            using(conString con = new conString())
            {
                return con.SP_GetWorkshops().ToList<SP_GetWorkshops_Result>();
            }
        }

        [HttpGet]
        [Route("WorkshopByUser/{StudentId}")]
        public List<SP_GetWorkShopByUser_Result> GetWorkshopByUser(int StudentId)
        {
            using (conString con = new conString())
            {
                return con.SP_GetWorkShopByUser(StudentId).ToList<SP_GetWorkShopByUser_Result>();
            }
        }

        [HttpGet]
        [Route("WorkshopById/{WorkshopId}")]
        public List<SP_GetWorkshopById_Result> GetWorkshopById(int WorkshopId)
        {
            using (conString con = new conString())
            {
                return con.SP_GetWorkshopById(WorkshopId).ToList<SP_GetWorkshopById_Result>();
            }
        }

        [HttpGet]
        [Route("WorkshopRequest")]
        public List<SP_GetWorkshopRequest_Result> GetWorkshopRequest()
        {
            using (conString con = new conString())
            {
                return con.SP_GetWorkshopRequest().ToList<SP_GetWorkshopRequest_Result>();
            }
        }
        #endregion

        #region Post
        [HttpPost]
        [Route("InsertWorkshop")]
        public bool InsertWorkshop(WorkShop Wp)
        {
            using(conString con = new conString())
            {
                try
                {
                    con.SP_InsertWorkshop(Wp.WorkShopTitle, Wp.WorkShopDate, Wp.WorkShopDuration, Wp.WorkShopTopics);
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

        [HttpPut]
        [Route("UpdateWorkshop")]
        public bool UpdateWorkshopById(WorkShop Wp)
        {
            using (conString con = new conString())
            {
                try
                {
                    con.SP_UpdateWorkshopById(Wp.WorkShopTitle, Wp.WorkShopDate, Wp.WorkShopDuration, Wp.WorkShopTopics, Wp.WorkShopId);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        [HttpDelete]
        [Route("DeleteWorkshop")]
        public bool DeleteWorkshopById(int WorkshopId)
        {
            using (conString con = new conString())
            {
                try
                {
                    con.SP_DeleteWorkshopById(WorkshopId);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        [HttpPost]
        [Route("AssignTrainers")]
        public bool AssignTrainersToWorkShop(Trainer_WorkShop_Mapping TWM)
        {
            using (conString con = new conString())
            {
                try
                {
                    con.SP_InsertIntoTrainerWorkshopMapping(TWM.TrainerId, TWM.WorkShopId);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        [HttpPut]
        [Route("AppOrRejWorkshop")]
        public bool AppOrRejectWorkshopRequest(Student_WorkShop_Mapping SWM)
        {
            using (conString con = new conString())
            {
                try
                {
                    con.SP_AppOrRejectWorkshopRequest(SWM.ISApproved, SWM.SerialNo);
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