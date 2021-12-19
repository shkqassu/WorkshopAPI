using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WorkshopData;

namespace WorkshopAPI.Controllers
{
    [RoutePrefix("api/Material")]
    public class MaterialController : ApiController
    {
        #region Get
        [HttpGet]
        [Route("AllMaterials")]
        public IHttpActionResult GetMaterials()
        {
            using (conString con = new conString())
            {
                try
                {
                    var response = con.SP_GetMaterials().ToList<SP_GetMaterials_Result>();
                    if (response.Count <= 0)
                    {
                        return NotFound();
                    }
                    return Ok(response);
                }
                catch
                {
                    return BadRequest();
                }
            }
        }

        [HttpGet]
        [Route("MaterialById")]
        public IHttpActionResult GetMaterialsById(int MaterialId)
        {
            using (conString con = new conString())
            {
                try
                {
                    var response = con.SP_GetMaterials().Where(x => x.MaterialId == MaterialId).ToList();
                    if (response.Count <= 0)
                    {
                        return NotFound();
                    }
                    return Ok(response);
                }
                catch
                {
                    return BadRequest();
                }
            }
        }

        [HttpGet]
        [Route("DownloadMaterialById")]
        public IHttpActionResult DownloadMaterialById(int MaterialId)
        {
            try
            {
                using (conString con = new conString())
                {
                    var response = con.Materials.Find(MaterialId);
                    if (response == null)
                    {
                        return NotFound();
                    }
                    return Ok(response.MaterialPath);
                }
            }
            catch
            {
                return BadRequest();
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
