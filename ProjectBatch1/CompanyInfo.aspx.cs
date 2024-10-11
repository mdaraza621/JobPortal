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
    public partial class CompanyInfo : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["xyz"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Display();
            }
        }
        public void Display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Recruiter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "SingleSelect");
            cmd.Parameters.AddWithValue("@cid",Request.QueryString["CID"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            lblcname.Text = dt.Rows[0]["name"].ToString();
            lblcurl.Text = dt.Rows[0]["url"].ToString();
            lblcaddress.Text = dt.Rows[0]["address"].ToString() + "," + dt.Rows[0]["cityname"].ToString() + "," + dt.Rows[0]["statename"].ToString() + "," + dt.Rows[0]["countryname"].ToString();
            lblchr.Text = dt.Rows[0]["hr"].ToString();
            lblemail.Text = dt.Rows[0]["email"].ToString();
            lblcn.Text = dt.Rows[0]["contactno"].ToString();
        }
    }
}