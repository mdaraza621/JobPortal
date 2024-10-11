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
    public partial class RecruiterHome : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["xyz"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["recruiter"] != null && Session["recruiter"].ToString() != "")
            {
                if (!IsPostBack)
                {
                    Display();
                }
            }
            else
            {
                Response.Redirect("Logout.aspx");
            }
            
        }
        public void Display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Recruiter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "SingleSelect");
            cmd.Parameters.AddWithValue("@cid", Session["recruiter"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grd.DataSource = dt;
            grd.DataBind();
            lblname.Text = dt.Rows[0]["name"].ToString();
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Recruiter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "delete");
                cmd.Parameters.AddWithValue("@cid", e.CommandArgument);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    lblmsg.Text = "Your record deleted successfully !!!";
                    Display();

                }
                else
                {
                    lblmsg.Text = "Your record not deleted successfully.. Try later !!!";
                }
            }

            else if (e.CommandName == "B")
            {
                Response.Redirect("RegRecruiter.aspx?kk=" + e.CommandArgument);
            }

        }
       
    }
}