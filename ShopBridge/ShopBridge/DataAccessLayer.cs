using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge
{
    public class DataAccessLayer
    {
        
      
        ThinkBridgeDBEntities context = new ThinkBridgeDBEntities();

        public List<Product> GetProducts()
        {
            try
            {

                var result = context.Products.ToList();
                return result;
            }
            catch(Exception e)
            {
                throw (e);
            }
        }

        public Product GetProductById(int id)
        {
            try
            {
                var result = context.Products.Where(x => x.ProdId == id).Single();
                return result;
            }
            catch(Exception e)
            {
                throw (e);
            }
        }

        public bool AddProduct(Product p)
        {         
            try
            {
                context.Products.Add(p);
                context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                throw (e);
            }

        }

        public bool UpdateProdList(Product p)
        {
            try
            {
                var result = context.Products.Where(x => x.ProdId == p.ProdId).Single();
                result.ProdId = p.ProdId;
                result.Description = p.Description;
                result.Price = p.Price;
                result.Color = p.Color;
                result.WarrantyPeriodInMonths = p.WarrantyPeriodInMonths;
                context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                throw (e);
            }

        }

        public bool DeleteProduct(int id)
        {
            try
            {
                var result = context.Products.Where(x => x.ProdId == id).Single();
                context.Products.Remove(result);
                context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                throw (e);
            }

        }
    
    }
}
   