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
    public partial class Manage_Skills : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["xyz"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindJP();
                BindGrid();
            }
        }
        public void BindJP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_JobProfiles", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", 2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddljp.DataValueField = "jpid";
            ddljp.DataTextField = "jpname";
            ddljp.DataSource = dt;
            ddljp.DataBind();
            ddljp.Items.Insert(0, new ListItem("--Select--", "0"));

        }
        public void BindGrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_skills", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", 2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gv_skills.DataSource = dt;
            gv_skills.DataBind();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_skills", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", btnsave.Text == "Save" ? 1 : 3);
            cmd.Parameters.AddWithValue("@skid", btnsave.Text == "Save" ? "0" : ViewState["IDD"]);
            cmd.Parameters.AddWithValue("@jpid", ddljp.SelectedValue);
            cmd.Parameters.AddWithValue("@skname", txtskills.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            BindGrid();
        }

        protected void gv_skills_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_skills", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", 4);
                cmd.Parameters.AddWithValue("@skid", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
            }
            else if (e.CommandName == "B")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_skills", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", 5);
                cmd.Parameters.AddWithValue("@skid", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    ddljp.SelectedValue = dt.Rows[0]["jpid"].ToString();
                    txtskills.Text = dt.Rows[0]["skname"].ToString();
                    btnsave.Text = "Update";
                    ViewState["IDD"] = e.CommandArgument;
                }
            }
        }
    }
}