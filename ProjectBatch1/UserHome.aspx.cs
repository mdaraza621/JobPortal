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
    public partial class UserHome : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["xyz"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null && Session["user"].ToString() != "")
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
            SqlCommand cmd = new SqlCommand("sp_Reg", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "SingleUser");
            cmd.Parameters.AddWithValue("@rid", Session["user"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            RepDetails.DataSource = dt;
            RepDetails.DataBind();
            lblname.Text = dt.Rows[0]["name"].ToString();

        }

      

        protected void RepDetails_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Reg", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "delete");
                cmd.Parameters.AddWithValue("@rid", e.CommandArgument);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    lblmsg.Text = "Record Deleted Successfully !!!";
                    Display();
                }
                else
                {
                    lblmsg.Text = "Record not Deleted Successfully !!!";
                }

            }
            else if (e.CommandName == "B")
            {
                Response.Redirect("RegistrationForm.aspx?pp=" + e.CommandArgument);
            }
            else if (e.CommandName == "RSM")
            {
                Response.Redirect("~/JOBSEEKER_RESUME" + "\\" + e.CommandArgument);
            }
        }
    }
}