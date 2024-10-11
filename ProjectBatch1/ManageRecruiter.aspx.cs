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
    public partial class ManageRecruiter : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["xyz"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null && Session["admin"].ToString() != "")
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
            cmd.Parameters.AddWithValue("@action", "select");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grd.DataSource = dt;
            grd.DataBind();
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "APR")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Recruiter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "apr");
                cmd.Parameters.AddWithValue("@cid", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
            }
        }

    }
}