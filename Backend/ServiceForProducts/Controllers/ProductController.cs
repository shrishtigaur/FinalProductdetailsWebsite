using DALProduct;
using DALProduct.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ServiceForProducts.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : Controller
    {
        ProductRepository repository;
        public ProductController()
        {
            this.repository = new ProductRepository();
        }
        [HttpGet]
        public JsonResult GetProductDetails()
        {
            List<Product> p = new List<Product>();
            try
            {

                p = repository.GetProductsDetails();
            }
            catch (Exception)
            {
                p = null;
            }

            return Json(p);
        }
        [HttpGet]
        public JsonResult GetProductDetailsByID(int pid)
        {
            Product p = new Product();
            try
            {
                p = repository.GetProductbyId(pid);
            }
            catch (Exception)
            {
                p = null;
            }
            return Json(p);
        }
        [HttpPost]
        public JsonResult AddProduct(Product p)
        {
            bool st = false;
            try
            {
                st = repository.AddProductDetails(p);
            }
            catch (Exception)
            {
                st = false;
            }
            return Json(st);

        }
        [HttpPut]
        public JsonResult UpdateProduct(Product p)
        {
            bool st = false;
            try
            {
                st = repository.UpdateProductDetails(p);
            }
            catch (Exception)
            {
                st = false;
            }
            return Json(st);

        }
        [HttpDelete]
        public JsonResult DeleteEmployee(int pid)
        {

            bool st = false;
            try
            {
                st = repository.DeleteProductDetails(pid);
            }
            catch (Exception)
            {
                st = false;
            }
            return Json(st);
        }

    }
}
