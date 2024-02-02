using DALProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DALProduct
{
    public class ProductRepository
    {
        private ProductsContext context;
        public ProductRepository()
        {
            context = new ProductsContext();    
        }

        public List<Product> GetProductsDetails()
        {
            var productdetails = (from p in context.Products
                               select p).ToList();
            return productdetails;
        }

        public Product GetProductbyId(int pid)
        {
            Product p;
            try
            {
                p = context.Products.Where(e => e.Id.Equals(pid)).FirstOrDefault();

            }
            catch (Exception e)
            {
                p = null;

            }
            return p;
        }

        public bool AddProductDetails(Product p)
        {
            bool status = false;
            Product product = new Product()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price
            };
            try
            {
                context.Add(product);
                context.SaveChanges();
                status = true;

            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        public bool UpdateProductDetails(Product p)
        {
            bool st = false;
            Product product = new Product();
            try
            {
                product = context.Products.Find(p.Id);
                if (product != null)
                {
                    product.Name = p.Name;
                    product.Description = p.Description;
                    product.Price = p.Price;
                    context.Products.Update(product);
                    context.SaveChanges();
                    st = true;

                }
                else
                {
                    st = false;
                }
            }
            catch (Exception ex)
            {
                st = false;
            }
            return st;
        }

        public bool DeleteProductDetails(int pid)
        {
            bool st = false;
            Product e = new Product();
            try
            {
                e = context.Products.Find(pid);
                if (e != null)
                {
                    context.Products.Remove(e);
                    context.SaveChanges();
                    st = true;
                }
                else
                {
                    st = false;
                }

            }
            catch (Exception ex)
            {

                st = false;
            }
            return st;
        }
    }
}
