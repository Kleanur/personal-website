using Newtonsoft.Json;
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

        public ActionResult GetBlog(string qfilename)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + qfilename;
            string content = System.IO.File.ReadAllText(path);

            return Content(content, "text/html");

            //DataTable data = GetData("SELECT * FROM Blog");
            //string jsonString = JsonConvert.SerializeObject(data);
            //return Content(jsonString, "application/json");


            //return Content("{\"C1\": 1, \"C2\": 2}", "application/json");
        }
    }
}