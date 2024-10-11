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
    public partial class ManageQualification : System.Web.UI.Page
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
            SqlCommand cmd = new SqlCommand("usp_Qualification", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", 2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gv_qualification.DataSource = dt;
            gv_qualification.DataBind();
        }


        protected void btnsave_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_Qualification", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", 1);
            cmd.Parameters.AddWithValue("@qname", txtname.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            BindGrid();
        }

        protected void gv_qualification_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SV")
            {
                TextBox TB1 = gv_qualification.FooterRow.FindControl("txtname2") as TextBox;
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_Qualification", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", 1);
                cmd.Parameters.AddWithValue("@qname", TB1.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
            }
            else if (e.CommandName == "DALL")
            {
                foreach (GridViewRow gvr in gv_qualification.Rows)
                {
                    CheckBox CB = gvr.FindControl("chkdelete") as CheckBox;
                    if (CB.Checked == true)
                    {
                        string IDD = gv_qualification.DataKeys[gvr.RowIndex].Value.ToString();
                        con.Open();
                        SqlCommand cmd = new SqlCommand("usp_Qualification", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@action", 4);
                        cmd.Parameters.AddWithValue("@qid", IDD);
                        cmd.ExecuteNonQuery();
                        con.Close();

                    }
                }

                BindGrid();
            }
        }

        protected void gv_qualification_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_qualification.EditIndex = -1;
            BindGrid();
        }

        protected void gv_qualification_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox TB1 = gv_qualification.Rows[e.RowIndex].FindControl("txtname1") as TextBox;
            string IDD = gv_qualification.DataKeys[e.RowIndex].Value.ToString();

            con.Open();
            SqlCommand cmd = new SqlCommand("usp_Qualification", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", 3);
            cmd.Parameters.AddWithValue("@qid", IDD);
            cmd.Parameters.AddWithValue("@qname", TB1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            gv_qualification.EditIndex = -1;
            BindGrid();
        }

        protected void gv_qualification_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string IDD = gv_qualification.DataKeys[e.RowIndex].Value.ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_Qualification", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", 4);
            cmd.Parameters.AddWithValue("@qid", IDD);
            cmd.ExecuteNonQuery();
            con.Close();
            BindGrid();
        }

        protected void gv_qualification_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_qualification.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void chkdeleteall_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox CBH = gv_qualification.HeaderRow.FindControl("chkdeleteall") as CheckBox;
            if (CBH.Checked == true)
            {
                foreach (GridViewRow gvr in gv_qualification.Rows)
                {
                    CheckBox CB = gvr.FindControl("chkdelete") as CheckBox;
                    CB.Checked = true;
                }
            }
            else
            {
                foreach (GridViewRow gvr in gv_qualification.Rows)
                {
                    CheckBox CB = gvr.FindControl("chkdelete") as CheckBox;
                    CB.Checked = false;
                }
            }
        }
    }
}