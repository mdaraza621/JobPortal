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
    public partial class ViewJobPosts : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["xyz"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null && Session["user"].ToString() != "")
            {
                if (!IsPostBack)
                {
                    BindJP();
                    BindJobTitle();
                }
            }
            else
            {
                Response.Redirect("Logout.aspx");
            }
            
        }
        public void BindJobTitle()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_JobProfiles", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", 2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddljobtitle.DataValueField = "jpid";
            ddljobtitle.DataTextField = "jpname";
            ddljobtitle.DataSource = dt;
            ddljobtitle.DataBind();
            ddljobtitle.Items.Insert(0, new ListItem("--Select--", "0"));

        }
        public void BindJP()
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("sp_Reg", con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@action", "edit");
            cmd1.Parameters.AddWithValue("@rid", Session["user"]);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            string JT = dt1.Rows[0]["ujobtitle"].ToString();
           
            SqlCommand cmd = new SqlCommand("usp_tbljobpost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "selectbyjobtitle");
            cmd.Parameters.AddWithValue("@ujobtitle", JT);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gv_jobposts.DataSource = dt;
            gv_jobposts.DataBind();

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("usp_tbljobpost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "search");
            cmd.Parameters.AddWithValue("@ujobtitle", ddljobtitle.SelectedValue);
            cmd.Parameters.AddWithValue("@maxsalary", txtsalary.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gv_jobposts.DataSource = dt;
            gv_jobposts.DataBind();
        }
    }
}