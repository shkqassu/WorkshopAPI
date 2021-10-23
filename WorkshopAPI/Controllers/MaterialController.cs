using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WorkshopData;

namespace WorkshopAPI.Controllers
{
    public class MaterialController : ApiController
    {
        #region Get
        [HttpGet]
        public List<SP_GetMaterials_Result> GetMaterials()
        {
            using (conString con = new conString())
            {
                return con.SP_GetMaterials().ToList<SP_GetMaterials_Result>();
            }
        }

        #endregion

        #region Post
        [HttpPost]
        [Route("CreateMaterial")]
        public bool CreateMaterial(Material M)
        {
            using (conString con = new conString())
            {
                try
                {
                    con.SP_CreateMaterial(M.MaterialPath, M.WorkShopId);
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
