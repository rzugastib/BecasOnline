using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class bienvenida : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btEst_Click(object sender, EventArgs e)
    {
        Response.Redirect("estudiante.aspx");
    }

    protected void btRest_Click(object sender, EventArgs e)
    {
        Response.Redirect("restaurant.aspx");
    }
}