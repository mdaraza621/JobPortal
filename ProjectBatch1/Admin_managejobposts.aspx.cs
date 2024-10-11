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
    public partial class Admin_managejobposts : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["xyz"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null && Session["admin"].ToString() != "")
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
            SqlCommand cmd = new SqlCommand("usp_tbljobpost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "selectall");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gv_jobposts.DataSource = dt;
            gv_jobposts.DataBind();

        }

        protected void gv_jobposts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "APR")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_tbljobpost", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "apr");
                cmd.Parameters.AddWithValue("@jobid", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                BindJP();
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("usp_tbljobpost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "selectbyjobtitle");
            cmd.Parameters.AddWithValue("@ujobtitle", ddljobtitle.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gv_jobposts.DataSource = dt;
            gv_jobposts.DataBind();
        }
    }
}