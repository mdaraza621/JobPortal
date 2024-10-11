using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace ProjectBatch1
{
    public partial class ApplyForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["xyz"].ConnectionString);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetEmail();
            }
        }
        public void GetEmail()
        {
            SqlCommand cmd = new SqlCommand("usp_tbljobpost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "Company_email_by_jpid");
            cmd.Parameters.AddWithValue("@jobid", Request.QueryString["JID"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                txttoemail.Text = dt.Rows[0]["Email"].ToString();
            }
        }


        protected void btn_SendMail_Click(object sender, EventArgs e)
        {
            MailAddress bcc = new MailAddress("aloksrivastava355@gmail.com");
            using (MailMessage mm = new MailMessage(txtfromemail.Text, txttoemail.Text))
            {
                mm.Subject = txtsubject.Text;
                mm.Body = txtbody.Text;
                mm.CC.Add(bcc);
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(txtfromemail.Text, txtpassword.Text);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 25;
                smtp.Send(mm);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
            }
        }
    }
}