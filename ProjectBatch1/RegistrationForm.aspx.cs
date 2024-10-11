using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace ProjectBatch1
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["xyz"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindJP();
                BindQualification();
                BindCountry();
                tr_skills.Visible = false;
                ddlstate.Enabled = false;
                ddlcity.Enabled = false;
                ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlcity.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            if (Request.QueryString["pp"] != null && Request.QueryString["pp"].ToString() != "")
            {
                if (!IsPostBack)
                {
                    Edit(); ;
                }
            }
        }

        public void Edit()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Reg", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "edit");
            cmd.Parameters.AddWithValue("@rid", Request.QueryString["pp"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                txtname.Text = dt.Rows[0]["name"].ToString();
                rblgender.SelectedValue = dt.Rows[0]["gender"].ToString();
                txtemail.Text = dt.Rows[0]["email"].ToString();
                txtpassword.Text = dt.Rows[0]["password"].ToString();
                ddljp.SelectedValue = dt.Rows[0]["ujobtitle"].ToString();
                ddlqualification.SelectedValue = dt.Rows[0]["uqualification"].ToString();
                ddlcountry.SelectedValue = dt.Rows[0]["country"].ToString();
                ddlstate.Enabled = true;
                BindState();
                ddlstate.SelectedValue = dt.Rows[0]["state"].ToString();
                ddlcity.Enabled = true;
                BindCity();
                ddlcity.SelectedValue = dt.Rows[0]["city"].ToString();
                ViewState["OLDPHOTO"] = dt.Rows[0]["photo"].ToString();
                ViewState["OLDRESUME"] = dt.Rows[0]["resumee"].ToString();
                btnreg.Text = "Update";
            }
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
        public void BindQualification()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_Qualification", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", 2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlqualification.DataValueField = "qid";
            ddlqualification.DataTextField = "qname";
            ddlqualification.DataSource = dt;
            ddlqualification.DataBind();
            ddlqualification.Items.Insert(0, new ListItem("--Select--", "0"));

        }

        public void BindSkills()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Skills where jpid='" + ddljp.SelectedValue + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            cblskills.DataValueField = "skid";
            cblskills.DataTextField = "skname";
            cblskills.DataSource = dt;
            cblskills.DataBind();

        }

        protected void btnreg_Click(object sender, EventArgs e)
        {


            string SKL = "";
            for (int i = 0; i < cblskills.Items.Count; i++)
            {
                if (cblskills.Items[i].Selected == true)
                {
                    SKL += cblskills.Items[i].Text + ",";
                }
            }

            SKL = SKL.TrimEnd(',');

            string PhotoName = "";
            string ResumeName = "";
            string PhotoExt = "";
            string ResumeExt = "";


            if (btnreg.Text == "Register")
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("sp_Reg", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@action", "checkuser");
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
                    PhotoName = DateTime.Now.Ticks.ToString() + Path.GetFileName(fuphoto.PostedFile.FileName);
                    PhotoExt = Path.GetExtension(fuphoto.PostedFile.FileName);
                    fuphoto.SaveAs(Server.MapPath("JOBSEEKER_PHOTO" + "\\" + PhotoName));

                    ResumeName = DateTime.Now.Ticks.ToString() + Path.GetFileName(furesume.PostedFile.FileName);
                    ResumeExt = Path.GetExtension(furesume.PostedFile.FileName);
                    furesume.SaveAs(Server.MapPath("JOBSEEKER_RESUME" + "\\" + ResumeName));

                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_Reg", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@action", "insert");
                    cmd.Parameters.AddWithValue("@name", txtname.Text);
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                    cmd.Parameters.AddWithValue("@ugender", rblgender.SelectedValue);
                    cmd.Parameters.AddWithValue("@uqualification", ddlqualification.SelectedValue);
                    cmd.Parameters.AddWithValue("@ujobtitle", ddljp.SelectedValue);
                    cmd.Parameters.AddWithValue("@country", ddlcountry.SelectedValue);
                    cmd.Parameters.AddWithValue("@state", ddlstate.SelectedValue);
                    cmd.Parameters.AddWithValue("@city", ddlcity.SelectedValue);
                    cmd.Parameters.AddWithValue("@skills", SKL);
                    cmd.Parameters.AddWithValue("@photo", PhotoName);
                    cmd.Parameters.AddWithValue("@resumee", ResumeName);
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        Response.Write("<script>alert('Data inserted successfully')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Data not inserted successfully')</script>");
                    }
                }

            }


            //***************** UPDATE CODE START ******************************//
            else
            {
                PhotoName = Path.GetFileName(fuphoto.PostedFile.FileName);
                ResumeName = Path.GetFileName(furesume.PostedFile.FileName);

                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Reg", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "update");
                cmd.Parameters.AddWithValue("@rid", Request.QueryString["pp"]);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                cmd.Parameters.AddWithValue("@ugender", rblgender.SelectedValue);
                cmd.Parameters.AddWithValue("@uqualification", ddlqualification.SelectedValue);
                cmd.Parameters.AddWithValue("@ujobtitle", ddljp.SelectedValue);
                cmd.Parameters.AddWithValue("@country", ddlcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@state", ddlstate.SelectedValue);
                cmd.Parameters.AddWithValue("@city", ddlcity.SelectedValue);
                cmd.Parameters.AddWithValue("@skills", SKL);
                if (PhotoName != "")
                {
                    PhotoName = DateTime.Now.Ticks.ToString() + PhotoName;
                    cmd.Parameters.AddWithValue("@photo", PhotoName);
                    File.Delete(Server.MapPath("JOBSEEKER_PHOTO" + "\\" + ViewState["OLDPHOTO"]));
                    fuphoto.SaveAs(Server.MapPath("JOBSEEKER_PHOTO" + "\\" + PhotoName));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@photo", ViewState["OLDPHOTO"]);
                }

                if (ResumeName != "")
                {
                    ResumeName = DateTime.Now.Ticks.ToString() + ResumeName;
                    cmd.Parameters.AddWithValue("@resumee", ResumeName);
                    File.Delete(Server.MapPath("JOBSEEKER_RESUME" + "\\" + ViewState["OLDRESUME"]));
                    fuphoto.SaveAs(Server.MapPath("JOBSEEKER_RESUME" + "\\" + PhotoName));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@resumee", ViewState["OLDRESUME"]);
                }

                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    Response.Write("<script>alert('Data Updated successfully')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Data not Updated successfully')</script>");
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

        protected void ddljp_SelectedIndexChanged(object sender, EventArgs e)
        {
            tr_skills.Visible = true;
            BindSkills();
        }
    }
}