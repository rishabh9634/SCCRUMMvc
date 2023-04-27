using SCCRUMMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SCCRUMMvc.Controllers
{
    public class WebApiController : ApiController
    {
         SCCRUMDBContext _context = new SCCRUMDBContext();

        [HttpGet]
        public IHttpActionResult GetProducts()
        {
            List<Product> products = _context.Products.ToList();

            return Ok(products);
        }

        [HttpPost]
        public IHttpActionResult ProductInsert(Product p)
        {
            _context.Products.Add(p);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetProductsById(int id)
        {
            var product = _context.Products.Where(model=>model.Product_ID==id).FirstOrDefault();
           
            return Ok(product);
        }

        [HttpPut]
        public IHttpActionResult ProductUpdate(Product p)
        {

            _context.Entry(p).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult ProductDelete(int id)
        {
            var product = _context.Products.Where(model => model.Product_ID == id).FirstOrDefault();
            _context.Entry(product).State = System.Data.Entity.EntityState.Deleted;
            _context.SaveChanges();
            return Ok();
        }
    }
}
