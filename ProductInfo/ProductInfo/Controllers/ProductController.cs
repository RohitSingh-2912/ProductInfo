using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using ProductInfo.Services;
using ProductInfo.Models;

namespace ProductInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController(ProductServices productService)
        {
            ProductServices = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public ProductServices ProductServices { get; }

        [HttpGet]
        [Route("get")]
        public ActionResult Get()
        {
            try
            {

                var product = ProductServices.Get();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("getById")]
        public ActionResult GetById([FromQuery] int id)
        {
            try
            {

                var product = ProductServices.GetById(id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getByName")]
        public ActionResult GetByName([FromQuery] string name)
        {
            try
            {

                var product = ProductServices.GetByName(name);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [Route("insert")]
        public ActionResult Create([FromBody] Products product)
        {
            try
            {

                return Ok(ProductServices.Create(product));
            }
            catch (Exception ex)
            {
                return Forbid(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public ActionResult Update([FromBody] Products product)
        {
           var products = ProductServices.GetById(product.id);

            if ( products == null)
            {
                return NotFound();
            }

                ProductServices.Update(product);

            return NoContent();
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult Delete([FromQuery] int id)
        {
            try
            {
                return Ok(ProductServices.Remove(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
    }
}