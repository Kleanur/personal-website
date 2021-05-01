using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDefault.Controllers
{
    public class DataController : Controller
    {
        public static DataTable GetData(string query)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDefault"].ConnectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(query, connection);
                DataTable data = new DataTable();
                data.TableName = "Data";
                adapter.Fill(data);
                return data;
            }
        }


        public ActionResult GetBlog(string qfilename, int categoryID)
        {
            ViewBag.Message = "Your blog page";

            return View();
        }
    }
}