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
    public partial class Recruiter_jobPost : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["xyz"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["recruiter"] != null && Session["recruiter"].ToString() != "")
            {
                if (!IsPostBack)
                {
                    BindJP();
                    if (Request.QueryString["pp"] != null && Request.QueryString["pp"].ToString() != "")
                    {
                        if (!IsPostBack)
                        {
                            LoadDataOnEdit();
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("Logout.aspx");
            }

        }

        public void LoadDataOnEdit()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_tbljobpost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "edit");
            cmd.Parameters.AddWithValue("@jobid", Request.QueryString["pp"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddljobtitle.SelectedValue = dt.Rows[0]["jobtitle"].ToString();
            txtminexp.Text = dt.Rows[0]["minexp"].ToString();
            txtmaxexp.Text = dt.Rows[0]["maxexp"].ToString();
            txtminsalary.Text = dt.Rows[0]["minsalary"].ToString();
            txtmaxsalary.Text = dt.Rows[0]["maxsalary"].ToString();
            txtvacancies.Text = dt.Rows[0]["noofvac"].ToString();
            txtcomment.Text = dt.Rows[0]["comment"].ToString();
            btnsave.Text = "Update";
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
            ddljobtitle.DataValueField = "jpid";
            ddljobtitle.DataTextField = "jpname";
            ddljobtitle.DataSource = dt;
            ddljobtitle.DataBind();
            ddljobtitle.Items.Insert(0, new ListItem("--Select--", "0"));

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(txtminsalary.Text) < Convert.ToInt32(txtmaxsalary.Text))
            {
                if (Convert.ToInt32(txtminexp.Text) < Convert.ToInt32(txtmaxexp.Text))
                {

                    if (btnsave.Text == "Submit")
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("usp_tbljobpost", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@action", "insert");
                        cmd.Parameters.AddWithValue("@companyid", Session["recruiter"]);
                        cmd.Parameters.AddWithValue("@jobtitle", ddljobtitle.SelectedValue);
                        cmd.Parameters.AddWithValue("@minexp", txtminexp.Text);
                        cmd.Parameters.AddWithValue("@maxexp", txtmaxexp.Text);
                        cmd.Parameters.AddWithValue("@minsalary", txtminsalary.Text);
                        cmd.Parameters.AddWithValue("@maxsalary", txtmaxsalary.Text);
                        cmd.Parameters.AddWithValue("@noofvac", txtvacancies.Text);
                        cmd.Parameters.AddWithValue("@comment", txtcomment.Text);
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                        if (i > 0)
                        {
                            lblmsg.Text = "Your record has been saved successfully !!!";
                        }
                        else
                        {
                            lblmsg.Text = "Your record has not been saved successfully !!!";
                        }
                    }
                    else
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("usp_tbljobpost", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@action", "update");
                        cmd.Parameters.AddWithValue("@jobid", Request.QueryString["pp"]);
                        cmd.Parameters.AddWithValue("@jobtitle", ddljobtitle.SelectedValue);
                        cmd.Parameters.AddWithValue("@minexp", txtminexp.Text);
                        cmd.Parameters.AddWithValue("@maxexp", txtmaxexp.Text);
                        cmd.Parameters.AddWithValue("@minsalary", txtminsalary.Text);
                        cmd.Parameters.AddWithValue("@maxsalary", txtmaxsalary.Text);
                        cmd.Parameters.AddWithValue("@noofvac", txtvacancies.Text);
                        cmd.Parameters.AddWithValue("@comment", txtcomment.Text);
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                        if (i > 0)
                        {
                            lblmsg.Text = "Your record has been updated successfully !!!";
                            btnsave.Text = "Submit";

                        }
                        else
                        {
                            lblmsg.Text = "Your record has not been updated successfully !!!";
                        }
                    }
                }

                else
                {
                    lblmsg.Text = "Maximum Exp should be grater than Minimum Exp !!";
                }
            }
            else
            {
                lblmsg.Text = "Maximum Salary should be grater than Minimum Salary !!";
            }
        }
    }
}