/*using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppProductEx.Models;

namespace WebAppProductEx.Controllers
{
    public class ProductsController : Controller
    {
        string conString = ConfigurationManager.ConnectionStrings["ProductsConStr"].ConnectionString;
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader srdr;
       
        // GET: Products
        public ActionResult Index()
        {
            List<Product> products = new List<Product>();
            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("select * from Product");
                cmd.Connection = con;
                con.Open();
                srdr = cmd.ExecuteReader();
                while (srdr.Read())
                {
                    products.Add(
                        new Product 
                        {
                           Id = (int)(srdr["Id"]),
                           Name = (string)(srdr["Name"]),
                           Price = (double)(srdr["Price"])

                        }
                        );
                }
            }
            catch (Exception ex)
            {
                TempData["error"]=ex.Message;
                return View("Error");
            }
            //finally 
            //{ 
            //    con.Close(); 
            //}
            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View(new Product());
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                // TODO: Add insert logic here
                con = new SqlConnection(conString);
                cmd = new SqlCommand("insert into Product values(@id,@name,@price)");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("id", product.Id);
                cmd.Parameters.AddWithValue("name", product.Name);
                cmd.Parameters.AddWithValue("price",product.Price);
                con.Open();
                cmd.ExecuteNonQuery();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");
            }
            finally { con.Close(); }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            Product product = new Product();
            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("select * from Product where Id=@pid");
                cmd.Parameters.AddWithValue("id", id);
                cmd.Connection = con;
                con.Open();
                srdr = cmd.ExecuteReader();
                while (srdr.Read())
                {

                    product = new Product
                    {
                        Id = (int)(srdr["Id"]),
                        Name = (string)(srdr["Name"]),
                        Price = (double)(srdr["Price"])

                    };
                        
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here



                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
*/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using WebAppProductEx.Models;

namespace WebAppProductADO.Controllers
{
    public class ProductsController : Controller
    {
        string conString = ConfigurationManager.ConnectionStrings["ProductsConStr"].ConnectionString;
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader srdr;

        // GET: Products
        public ActionResult Index()
        {
            List<Product> products = new List<Product>();
            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("select * from Product");
                cmd.Connection = con;
                con.Open();
                srdr = cmd.ExecuteReader();
                while (srdr.Read())
                {
                    products.Add(
                        new Product
                        {
                            Id = (int)(srdr["Id"]),
                            Name = (string)srdr["Name"],
                            Price = (double)(srdr["Price"])
                        }
                        );
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");
            }
            finally
            {
                con.Close();
            }

            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            Product product = new Product();
            con = new SqlConnection(conString);
            try
            {
                cmd = new SqlCommand("select * from Product where Id = @id");
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = con;
                con.Open();
                srdr = cmd.ExecuteReader();
                while (srdr.Read())
                {
                    product.Id = (int)(srdr["Id"]);
                    product.Name = (string)srdr["Name"];
                    product.Price = (double)(srdr["Price"]);
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");
            }
            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }

            return View(product);
        }


        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {

            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("insert into Product values (@id,@name,@price)");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@id", product.Id);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);
                con.Open();
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");
            }
            finally
            {
                con.Close();
            }

        }




        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = new Product();
            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("Select * from Product");
                cmd.Connection = con;
                con.Open();
                srdr = cmd.ExecuteReader();
                while (srdr.Read())
                {


                    product.Id = (int)(srdr["Id"]);
                    product.Name = srdr["Name"].ToString();
                    product.Price = (double)(srdr["Price"]);

                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");
            }
            return View(product);

        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("update Product set Name = @pn, Price=@pr where Id=@upid");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@upid", product.Id);
                cmd.Parameters.AddWithValue("@pn", product.Name);
                cmd.Parameters.AddWithValue("@pr", product.Price);

                con.Open();
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");
            }
            finally
            {
                con.Close();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {

            Product product = new Product();
            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("select * from Product");
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = con;
                con.Open();
                srdr = cmd.ExecuteReader();
                while (srdr.Read())
                {
                    product =
                        new Product
                        {
                            Id = (int)(srdr["Id"]),
                            Name = (string)srdr["Name"],
                            Price = (double)(srdr["Price"])
                        };

                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");
            }
            finally
            {
                con.Close();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("delete from Product where Id=@pid");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@pid", product.Id);

                con.Open();
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");
            }
            finally
            {
                con.Close();
            }

        }

    }
}