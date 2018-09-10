using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginFormParameters.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace LoginFormParameters.Controllers
{
    public class UserController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        // GET: User
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User u, string UserName, string Password)
        {
           UserName = u.UserName;
          Password = u.Password;
            if (ModelState.IsValid)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select UserName,Password from UserInfo where UserName=@name and Password=@password", con);
                cmd.Parameters.AddWithValue("@name", UserName);
                cmd.Parameters.AddWithValue("@password", Password);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    return View("DashBoard");
                }
                else
                {
                    ViewBag.error = "Invalid UserName or Password";
                    return View("Login");
                }
            }
            else
            {
                return View("Login");
            }

        }
    }
}