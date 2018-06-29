using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class restaurant : System.Web.UI.Page
{
    //Método conexión
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
    //Al abrirse la página carga el DRopdownlist con los restaurantes
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                OdbcConnection con = conectarBD();
                if (con != null)
                {
                    string strQuery = "select nombre from restaurant";
                    OdbcCommand sql = new OdbcCommand(strQuery, con);
                    OdbcDataReader lector = sql.ExecuteReader();
                    while (lector.Read())
                    {

                        ddRest.Items.Add(lector.GetString(0));
                    }
                    con.Close();
                    lector.Close();

                }
                else
                    Response.Redirect("Error en la conexión.");
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                Response.Redirect("No se pudo realizar la conexión.");
            }
        }
    }
    //Método que carga el DropdownList de la semana al seleccionarse un restaurant.
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            OdbcConnection con = conectarBD();
            if (con != null)
            {
                //Selecciona todas las semanas, sin repetición, para las que existe algún registro para cierto restaurant.
                string strQuery = "select distinct semana from comida inner join restaurant on comida.idRestaurant = restaurant.idRestaurant where restaurant.nombre ='" + ddRest.SelectedValue + "'";
                OdbcCommand sql = new OdbcCommand(strQuery, con);
                OdbcDataReader lector = sql.ExecuteReader();
                ddSemana.Items.Clear();
                while (lector.Read())
                {
                    ddSemana.Items.Add(lector.GetString(0));
                }
                con.Close();
                lector.Close();

            }
            else
                Response.Redirect("Error en la conexión.");
        }
        catch (Exception ex)
        {
            Response.Write(ex);
            Response.Redirect("No se pudo realizar la conexión.");
        }
    }
    //Método quue despliega la información de algún restaurante para ser verificada por el usuario.
    protected void btConsultar_Click(object sender, EventArgs e)
    {
        try
        {
            OdbcConnection con = conectarBD();
            if (con != null)
            {
                string strQuery = "select nombre, capacidad, rfc, direccion from restaurant where nombre = '" + ddRest.SelectedValue + "'";
                OdbcCommand sql = new OdbcCommand(strQuery, con);
                OdbcDataReader lector = sql.ExecuteReader();
                GridView1.DataSource = lector;
                GridView1.DataBind();
                con.Close();
                lector.Close();
                Label1.Text = "¿Están sus datos mal? Contacte a soporte";
            }
            else
                Response.Redirect("Error en la conexión.");
        }
        catch (Exception ex)
        {
            Response.Write(ex);
            Response.Write("No se pudo realizar la conexión.");
        }
    }
    //Método que guarda la información del Restaurant y de la semana de interés para trabajarse en la siguiente ventanta 'filtro.aspx'
    protected void btReporte_Click(object sender, EventArgs e)
    {
        Session["Sem"] = ddSemana.SelectedValue;
        Session["Rest"] = ddRest.SelectedValue;
        Response.Redirect("filtro.aspx");
    }
}