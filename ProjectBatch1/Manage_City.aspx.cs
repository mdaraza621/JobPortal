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
    public partial class Manage_City : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["xyz"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null && Session["admin"].ToString() != "")
            {
                if (!IsPostBack)
                {
                    BindCountry();
                    ddlstate.Enabled = false;
                    ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));
                    BindGrid();
                }
            }
            else
            {
                Response.Redirect("Logout.aspx");
            }

        }

        public void BindCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_Country", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", 2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlcountry.DataValueField = "countryid";
            ddlcountry.DataTextField = "countryname";
            ddlcountry.DataSource = dt;
            ddlcountry.DataBind();
            ddlcountry.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void BindState()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_state", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", 6);
            cmd.Parameters.AddWithValue("@countryid", ddlcountry.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlstate.DataValueField = "stateid";
            ddlstate.DataTextField = "statename";
            ddlstate.DataSource = dt;
            ddlstate.DataBind();
            ddlstate.Items.Insert(0,new ListItem("--Select--","0"));
        }

        public void BindGrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_city", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", 2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gv_city.DataSource = dt;
            gv_city.DataBind();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_city", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", btnsave.Text == "Save" ? 1 : 3);
            cmd.Parameters.AddWithValue("@cityid", btnsave.Text == "Save" ? "0" : ViewState["IDD"]);
            cmd.Parameters.AddWithValue("@stateid", ddlstate.SelectedValue);
            cmd.Parameters.AddWithValue("@cityname", txtname.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            BindGrid();
        }

        protected void gv_city_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_city", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", 4);
                cmd.Parameters.AddWithValue("@cityid", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
            }
            else if (e.CommandName == "B")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_city", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", 5);
                cmd.Parameters.AddWithValue("@cityid", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    ddlcountry.SelectedValue = dt.Rows[0]["countryid"].ToString();
                    ddlstate.Enabled = true;
                    BindState();
                    ddlstate.SelectedValue = dt.Rows[0]["stateid"].ToString();
                    txtname.Text = dt.Rows[0]["cityname"].ToString();
                    btnsave.Text = "Update";
                    ViewState["IDD"] = e.CommandArgument;
                }
            }
        }

        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlcountry.SelectedValue == "0")
            {
                ddlstate.Enabled = true;
                ddlstate.SelectedValue = "0";
            }
            else
            {
                ddlstate.Enabled = true;
                BindState();
            }
        }
    }
}