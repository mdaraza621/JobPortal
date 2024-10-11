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
    public partial class Changepassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["xyz"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null && Session["user"].ToString() != "")
            {
                if (!IsPostBack)
                {
                   //loadcode
                }
            }
            else
            {
                Response.Redirect("Logout.aspx");
            }
        }

        protected void btnchangepassword_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Reg", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "changepassword");
            cmd.Parameters.AddWithValue("@rid", Session["user"]);
            cmd.Parameters.AddWithValue("@password", txtoldpassword.Text);
            cmd.Parameters.AddWithValue("@newpassword", txtnewpassword.Text);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                lblmsg.Text = "Your password has been changed successfully !!!";
            }
            else
            {
                lblmsg.Text = "Your password has not been changed successfully !!!";
            }
        }
    }
}