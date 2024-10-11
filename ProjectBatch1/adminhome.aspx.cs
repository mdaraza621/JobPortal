using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectBatch1
{
    public partial class adminhome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null && Session["admin"].ToString() != "")
            {
                if (!IsPostBack)
                {
                    //lodecode
                }
            }
            else
            {
                Response.Redirect("Logout.aspx");
            }
        }
    }
}