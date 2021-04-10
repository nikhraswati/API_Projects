using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShopBridge.Controllers
{
   // [BasicAuthentication]
    public class ValuesController : ApiController
    {
        
        DataAccessLayer dal = new DataAccessLayer();
        // GET api/values
        [HttpGet]
        public async Task<HttpResponseMessage> FetchProduct()
        {
            try
            {
                Task<List<Product>> task = new Task<List<Product>>(dal.GetProducts);
                task.Start();
                var result = await task;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,"");
            }

        }

        // GET api/values/5
        [HttpGet]
        public async Task<HttpResponseMessage> FetchProductById(int id)
        {
            try
            {
                var result = await Task.FromResult<Product>(dal.GetProductById(id));
            
           
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, "");

            }
        }

        // POST api/values
        [HttpPost]
        public async Task<HttpResponseMessage> InsertProduct([FromBody]Product prod)
        {
            try
            {
              var a= await Task.FromResult<bool>(dal.AddProduct(prod));
                return Request.CreateResponse(HttpStatusCode.OK, "Record inserted successfully");

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error occurred while inserting record");
            }
        }

        [Route("api/Values/bulk")]
        [HttpPost]
        public async Task<HttpResponseMessage> InsertProducts([FromBody]List<Product> list)
        {
            try
            {
                var a = await Task.FromResult<bool>(dal.BulkInsert(list));
                return Request.CreateResponse(HttpStatusCode.OK, "Records have been inserted successfully");

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error occurred while inserting record");
            }
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<HttpResponseMessage> ModifyProuct(Product p)
        {
            try
            {
                var a = await Task.FromResult<bool>(dal.UpdateProdList(p));

              return Request.CreateResponse(HttpStatusCode.OK, "Record updated successfully");

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, "Error occurred while updating record");

            }

        }

        [Route("api/Values/bulk")]
        [HttpPut]
        public async Task<HttpResponseMessage> ModifyProucts(List<Product> p)
        {
            try
            {
                var a = await Task.FromResult<bool>(dal.BulkUpdate(p));

                return Request.CreateResponse(HttpStatusCode.OK, "Records have been updated successfully");

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, "Error occurred while updating the records");

            }

        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<HttpResponseMessage> RemoveProduct(int id)
        {
            try
            {
                var a = await Task.FromResult<bool>(dal.DeleteProduct(id));


                return Request.CreateResponse(HttpStatusCode.OK, "Record deleted successfully");

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, "Error occurred while deleting the record");
            }
        }
        [HttpDelete]
        [Route("api/Values/bulk")]
        public async Task<HttpResponseMessage> RemoveProducts(List<Product> p)
        {
            try
            {
                var a = await Task.FromResult<bool>(dal.BulkDelete(p));


                return Request.CreateResponse(HttpStatusCode.OK, "Records have been deleted successfully");

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, "Error occurred while deleting the records");
            }
        }
        //[HttpGet]
        //public HttpResponseMessage ReturnAPIResponse(List<Product> message,HttpStatusCode code,)
        //{
        //    return Request.CreateResponse(code, message);

        //}

        //public HttpResponseMessage ReturnAPIErrorResponse(string message, HttpStatusCode code)
        //{
        //    return Request.CreateErrorResponse(code, message);

        //}
    }
}
