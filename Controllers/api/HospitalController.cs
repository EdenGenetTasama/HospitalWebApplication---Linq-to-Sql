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
                List<Hospital> hospitals = datacontext.Hospitals.ToList();
                return Ok(new { hospitals });
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
                Hospital hospitalById = datacontext.Hospitals.First(item => item.Id == id);
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
            try
            {
                datacontext.Hospitals.InsertOnSubmit(hospitalPost);
                datacontext.SubmitChanges();
                return Ok("addd");
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
        public IHttpActionResult Put(int id, [FromBody] Hospital hospitalNeedToUpdate)
        {
            try
            {
                Hospital hostiptalObject = datacontext.Hospitals.First(item => item.Id == id);
                if (hostiptalObject != null)
                {
                    hostiptalObject.firstName = hospitalNeedToUpdate.firstName;
                    hostiptalObject.lastName = hospitalNeedToUpdate.lastName;
                    hostiptalObject.payment = hospitalNeedToUpdate.payment;
                    hostiptalObject.hoursOfWOrk = hospitalNeedToUpdate.hoursOfWOrk;
                    hostiptalObject.yearBirth = hospitalNeedToUpdate.yearBirth;


                }
                datacontext.SubmitChanges();
                return Ok("Update");
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
                Hospital hospitalToDelete = datacontext.Hospitals.First(item => item.Id ==id);
                if (hospitalToDelete != null)
                {
                    datacontext.Hospitals.DeleteOnSubmit(hospitalToDelete);
                }

                datacontext.SubmitChanges();
                return Ok("Delete");
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
