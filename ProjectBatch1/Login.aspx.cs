using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ProjectBatch1
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["xyz"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            if (ddlusertype.SelectedValue == "1")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Admin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    Session["admin"] = dt.Rows[0]["adminid"].ToString();
                    Response.Redirect("adminhome.aspx");
                }
                else
                {
                    lblmsg.Text = "Admin Login Failed !!!";
                }
            }
            else if (ddlusertype.SelectedValue == "3")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Recruiter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "login");
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    Session["recruiter"] = dt.Rows[0]["cid"].ToString();
                    Response.Redirect("Recruiterhome.aspx");
                }
                else
                {
                    lblmsg.Text = "Recruiter Login Failed !!!";
                }
            }
            else if (ddlusertype.SelectedValue == "2")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Reg", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "login");
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    
                    Session["user"] = dt.Rows[0]["rid"].ToString();
                    Response.Redirect("userhome.aspx");
                }
                else
                {
                    lblmsg.Text = "User Login Failed !!!";
                }
            }
        }
    }
}