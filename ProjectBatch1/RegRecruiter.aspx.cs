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
    public partial class RegRecruiter : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["xyz"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountry();
                ddlstate.Enabled = false;
                ddlcity.Enabled = false;
                ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlcity.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            if (Request.QueryString["kk"] != null && Request.QueryString["kk"].ToString() != "")
            {
                if (!IsPostBack)
                {
                    LoadDataOnEdit();
                }

            }
        }


        public void LoadDataOnEdit()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Recruiter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "edit");
            cmd.Parameters.AddWithValue("@cid", Request.QueryString["kk"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            txtcname.Text = dt.Rows[0]["name"].ToString();
            txtcurl.Text = dt.Rows[0]["url"].ToString();
            txtcaddress.Text = dt.Rows[0]["address"].ToString();
            txtchr.Text = dt.Rows[0]["hr"].ToString();
            txtemail.Text = dt.Rows[0]["email"].ToString();
            txtpassword.Text = dt.Rows[0]["password"].ToString();
            txtcn.Text = dt.Rows[0]["contactno"].ToString();
            ddlcountry.SelectedValue = dt.Rows[0]["country"].ToString();
            ddlstate.Enabled = true;
            BindState();
            ddlstate.SelectedValue = dt.Rows[0]["state"].ToString();
            ddlcity.Enabled = true;
            BindCity();
            ddlcity.SelectedValue = dt.Rows[0]["city"].ToString();
            btnsave.Text = "Update";
        }
        public void BindCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblCountry", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                ddlcountry.DataValueField = "countryid";
                ddlcountry.DataTextField = "countryname";
                ddlcountry.DataSource = dt;
                ddlcountry.DataBind();
                ddlcountry.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }

        public void BindState()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblState where countryid='" + ddlcountry.SelectedValue + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                ddlstate.DataValueField = "stateid";
                ddlstate.DataTextField = "statename";
                ddlstate.DataSource = dt;
                ddlstate.DataBind();
                ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }

        public void BindCity()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblCity where stateid='" + ddlstate.SelectedValue + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                ddlcity.DataValueField = "cityid";
                ddlcity.DataTextField = "cityname";
                ddlcity.DataSource = dt;
                ddlcity.DataBind();
                ddlcity.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Submit")
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("sp_Recruiter", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@action", "checkrecruiter");
                cmd1.Parameters.AddWithValue("@email", txtemail.Text);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                con.Close();
                if (dt1.Rows.Count > 0)
                {
                    lblmsg.Text = "This email id is already exist !!";
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_Recruiter", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@action", "insert");
                    cmd.Parameters.AddWithValue("@name", txtcname.Text);
                    cmd.Parameters.AddWithValue("@url", txtcurl.Text);
                    cmd.Parameters.AddWithValue("@address", txtcaddress.Text);
                    cmd.Parameters.AddWithValue("@hr", txtchr.Text);
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                    cmd.Parameters.AddWithValue("@contactno", txtcn.Text);
                    cmd.Parameters.AddWithValue("@country", ddlcountry.SelectedValue);
                    cmd.Parameters.AddWithValue("@state", ddlstate.SelectedValue);
                    cmd.Parameters.AddWithValue("@city", ddlcity.SelectedValue);
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        lblmsg.Text = "Your record saved successfully !!!";

                    }
                    else
                    {
                        lblmsg.Text = "Your record not saved successfully.. Try later !!!";
                    }
                }
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Recruiter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "update");
                cmd.Parameters.AddWithValue("@cid", Request.QueryString["kk"]);
                cmd.Parameters.AddWithValue("@name", txtcname.Text);
                cmd.Parameters.AddWithValue("@url", txtcurl.Text);
                cmd.Parameters.AddWithValue("@address", txtcaddress.Text);
                cmd.Parameters.AddWithValue("@hr", txtchr.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                cmd.Parameters.AddWithValue("@contactno", txtcn.Text);
                cmd.Parameters.AddWithValue("@country", ddlcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@state", ddlstate.SelectedValue);
                cmd.Parameters.AddWithValue("@city", ddlcity.SelectedValue);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    Response.Redirect("ManageRecruiter.aspx");

                }
                else
                {
                    lblmsg.Text = "Your record not updated successfully.. Try later !!!";
                }
            }
        }

        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlstate.Enabled = true;
            BindState();
        }

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlcity.Enabled = true;
            BindCity();
        }
    }
}