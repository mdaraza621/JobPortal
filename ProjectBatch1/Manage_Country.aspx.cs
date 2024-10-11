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
    public partial class Manage_Country : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["xyz"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null && Session["admin"].ToString() != "")
            {
                if (!IsPostBack)
                {
                    BindGrid();
                }
            }
            else
            {
                Response.Redirect("Logout.aspx");
            }

        }

        public void BindGrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_Country", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", 2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gv_country.DataSource = dt;
            gv_country.DataBind();
        }


        protected void btnsave_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_country", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", 1);
            cmd.Parameters.AddWithValue("@countryname", txtname.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            BindGrid();
        }

        protected void gv_country_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SV")
            {
                TextBox TB1 = gv_country.FooterRow.FindControl("txtname2") as TextBox;
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_Country", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", 1);
                cmd.Parameters.AddWithValue("@countryname", TB1.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
            }
            else if (e.CommandName == "DALL")
            {
                foreach (GridViewRow gvr in gv_country.Rows)
                {
                    CheckBox CB = gvr.FindControl("chkdelete") as CheckBox;
                    if (CB.Checked == true)
                    {
                        string IDD = gv_country.DataKeys[gvr.RowIndex].Value.ToString();
                        con.Open();
                        SqlCommand cmd = new SqlCommand("usp_Country", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@action", 4);
                        cmd.Parameters.AddWithValue("@countryid", IDD);
                        cmd.ExecuteNonQuery();
                        con.Close();

                    }
                }

                BindGrid();
            }
        }

        protected void chkdeleteall_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox CBH = gv_country.HeaderRow.FindControl("chkdeleteall") as CheckBox;
            if (CBH.Checked == true)
            {
                foreach (GridViewRow gvr in gv_country.Rows)
                {
                    CheckBox CB = gvr.FindControl("chkdelete") as CheckBox;
                    CB.Checked = true;
                }
            }
            else
            {
                foreach (GridViewRow gvr in gv_country.Rows)
                {
                    CheckBox CB = gvr.FindControl("chkdelete") as CheckBox;
                    CB.Checked = false;
                }
            }

        }

        protected void gv_country_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_country.EditIndex = -1;
            BindGrid();
        }

        protected void gv_country_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox TB1 = gv_country.Rows[e.RowIndex].FindControl("txtname1") as TextBox;
            string IDD = gv_country.DataKeys[e.RowIndex].Value.ToString();

            con.Open();
            SqlCommand cmd = new SqlCommand("usp_Country", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", 3);
            cmd.Parameters.AddWithValue("@countryid", IDD);
            cmd.Parameters.AddWithValue("@countryname", TB1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            gv_country.EditIndex = -1;
            BindGrid();
        }

        protected void gv_country_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string IDD = gv_country.DataKeys[e.RowIndex].Value.ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_Country", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", 4);
            cmd.Parameters.AddWithValue("@countryid", IDD);
            cmd.ExecuteNonQuery();
            con.Close();
            BindGrid();
        }

        protected void gv_country_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_country.EditIndex = e.NewEditIndex;
            BindGrid();
        }
    }
}