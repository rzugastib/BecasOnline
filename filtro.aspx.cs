using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Esta pagina es únicamente una antesala de la página lista. Se requiere autentificar con contraseña.
public partial class filtro : System.Web.UI.Page
{
    //método de conexión.
    protected OdbcConnection conectarBD()
    {
        try
        {
            OdbcConnection con = new OdbcConnection("Driver={ODBC Driver 11 for SQL Server};Server=RICHO;Uid=sa;Pwd=sqladmin;Database=Becas");
            con.Open();
            return con;
        }
        catch (Exception ex)
        {
            Response.Write(ex);
            return null;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //Botón que comprueba que la contraseña del restaurante sea válida.
    //En caso de ser válida, dará acceso a la página lista.
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            OdbcConnection con = conectarBD();
            if (con != null)
            {

                string strQuery = "select pwd from restaurant where nombre = '" + Session["Rest"].ToString() + "'";
                OdbcCommand sql = new OdbcCommand(strQuery, con);
                OdbcDataReader lector = sql.ExecuteReader();
                lector.Read();
                string pwd = lector.GetString(0);
                if (pwd == tbPwd.Text)
                {
                    Response.Redirect("lista.aspx");
                }
                else
                {
                    Response.Write("Contraseña incorrecta, vuelve a intentar.");
                }
                lector.Close();
                con.Close();
            }
            else
                Response.Write("Conexión nula.");
        }
        catch (Exception ex)
        {
            Response.Write(ex);
            Response.Write("No se pudo realizar la conexión.");
        }
    }
}