using HospitalWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HospitalWebApplication.Controllers.api
{
    public class HospitalController : ApiController
    {
        static string connectionString = "Data Source=DESKTOP-0MT6QTG;Initial Catalog=HospitalDataBase;Integrated Security=True;Pooling=False";
        static HospitalContexctDataContext datacontext = new HospitalContexctDataContext(connectionString);
        // GET: api/Hospital
        public IHttpActionResult Get()
        {
            try
            {
                List <Hospital> hospitals = datacontext.Hospitals.ToList();
                return Ok(new { hospitals});
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Hospital/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Hospital hospitalById = datacontext.Hospitals.First(item =>  item.Id == id);
                return Ok(new { hospitalById });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Hospital
        public IHttpActionResult Post([FromBody] Hospital hospitalPost)
        {
            datacontext.Hospitals.InsertOnSubmit(hospitalPost);
            datacontext.SubmitChanges();
            return Ok("addd");
            try
            {

                return Ok();
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Hospital/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            try
            {

                return Ok();
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Hospital/5
        public IHttpActionResult Delete(int id)
        {
            try
            {

                return Ok();
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
