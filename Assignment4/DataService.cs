using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Assignment4
{
    public class DataService
    {
        //henricks code
        /*public void CreateCategory(string categoryName)
        {
            GetProducts().Add(new Category()
            {
                Id = GetProducts().Max(x => x.Id) + 1,
                Name = categoryName
            });
        }*/

       
        /// <summary>
        /// Category Tests
        /// </summary>
        public List<Category> GetCategory()
        {
            using (var db = new NorthwindContex())
            {
                return db.Categories.ToList();
            }

        }
        public Category GetCategory(int index)
        {
            using (var db = new NorthwindContex())
            {
                return db.Categories.Find(index);
            }
        }
        public Category CreateCategory(string name, string description)
        {
            using (var db = new NorthwindContex())
            {
                var count = GetCategory();
                var newCat = new Category()
                {
                    Id = count.Count() + 1,
                    Name = name,
                    Description = description
                };
                db.Categories.Add(newCat);
                db.SaveChanges();
                return newCat;
            }

        }
        

      

        public bool UpdateCategory(int categoryId, String name, String description)
        {
            
                using (var db = new NorthwindContex())
                {
                    var category = db.Categories.FirstOrDefault(x => x.Id == categoryId);
                if(category != null)
                {
                    category.Name = name;
                    category.Description = description;
                    db.SaveChanges();
                    return true;
                }
                return false;
                }
            }
       /* public bool DeleteCategory(int id)
        {

            using (var db = new NorthwindContex())
            {
                var category = db.Categories.FirstOrDefault(x => x.Id == id);

                if (category != null)
                {
                    db.Categories.Remove(category);
                    
                    db.SaveChanges();

                    return true;
                }
                return false;
            }
        }*/
        public bool DeleteCategory(int id)
        {
            try
            {
                using (var db = new NorthwindContex())
                {
                    var delCat = new Category() { Id = id };
                    db.Categories.Attach(delCat);
                    db.Categories.Remove(delCat);
                    db.SaveChanges();
                    if (delCat != null)
                    {

                        return true;
                    }
                     return false;
                }
            }
            catch (Exception) { }
            return false;
        }


        /// <summary>
        /// Product Tests
        /// </summary>
        /// 
        public List<Product> GetProduct()
        {
            using (var db = new NorthwindContex())
            {
                return db.Products.ToList();
            }

        }
        public Product GetProduct(int productId)
        {
            using (var db = new NorthwindContex())
            {
                var product = db.Products
                    .Include(x => x.Category)
                    .FirstOrDefault(x => x.Id == productId);
                return product;
            }
        }

        public List<Product> GetProductByName(String productName)
        {
            using (var db = new NorthwindContex())
            {
                var product = db.Products
                    .Where(x => x.Name.ToLower().Contains(productName.ToLower()));

                return product.ToList();
            }
        }

        public List<Product> GetProductByCategory(int categoryId)
        {
            using (var db = new NorthwindContex())
            {
                var products = db.Products
                    .Include(x => x.Category)
                    .Where(x => x.Category.Id == categoryId)
                    .ToList();
                return products;
            }
        }

        public List<Order> GetOrders()
        {
            using (var db = new NorthwindContex())
            {
                return db.Orders.ToList();
            }
        }
        //not done
        public Order GetOrder(int id)
        {
            using (var db = new NorthwindContex())
            {

                return db.Orders.Include(x => x.OrderDetails).
                    ThenInclude(x =>x.Product).
                    ThenInclude(x => x.Category)
                    .FirstOrDefault(x =>x.Id == id);
            }

        }

        public List<OrderDetails> GetOrderDetailsByOrderId(int orderid)
        {
            using(var db = new NorthwindContex())
            {
                return db.OrderDetails
                    .Include(x => x.Product)
                    .Where(x => x.OrderId == orderid)
                    .ToList();
            }
        }
       

            public List<OrderDetails> GetOrderDetailsByProductId(int id)
        {
            using (var db = new NorthwindContex())
            {
                return db.OrderDetails
                    .Include(x => x.Order)
                    .Where(x => x.ProductId == id)
                    .OrderBy(x => x.Order.Date)
                    .ToList();
            }
        }




     }
} 

   // }
//}
