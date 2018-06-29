using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class estudiante : System.Web.UI.Page
{
    //método conexión
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
    //Al iniciar la página se carga el dropdownlist de los restaurantes llamado 'ddRest'
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                OdbcConnection con = conectarBD();
                if (con != null)
                {
                    //consulta todos los restaurantes registrados en la base de datos.
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
            for (int a = 1; a <= 16; a++)
            {
                ddSemana.Items.Add(a.ToString());
            }
        }
    }
    // Este método permite consultar los datos del estudiante.
    // Además, despliega las comidas registradas para cada semana
    protected void btConsulta_Click(object sender, EventArgs e)
    {
        try
        {
            OdbcConnection con = conectarBD();
            if (con != null)
            {
                //Consulta los datos del estudiante cuya clave única está dada por el usuario
                string strQuery = "select nombre, semestre, numComidas as comidas, porcentajeBeca as '% de beca' from estudiante where idEstudiante = " + tbClave.Text;
                OdbcCommand sql = new OdbcCommand(strQuery, con);
                OdbcDataReader lector = sql.ExecuteReader();
                if (lector.HasRows)
                {
                    gvEst.DataSource = lector;
                    gvEst.DataBind();
                }
                else
                {
                    Response.Write("No se encuentra al estudiante");
                    gvEst.DataSource = null;
                    gvEst.DataBind();
                }
                con.Close();
                lector.Close();

            }
            else
                Response.Redirect("Error en la conexión.");
        }
        catch (Exception ex)
        {
            Response.Write("No se encuentra el estudiante. Verifica la clave única. ");
        }
        //llama al método que enlista en un ListBox
        enlistaComidas();
    }
    //Este método permite al estudiante registrar su comida en el restaurante de su preferencia.
    //El estudiante puede elegir la semana en la que quiere registrar su comida
    //Hay dos restricciones:
    //La primera es que la capacidad del local. Sólo se podrán inscribir los estudiantes si no han
    //rebasado su capacidad de comidas ofrecidas por semana
    //La segunda es que el alumno sólo podrá registrar las comidas si no ha rebasado su número de comidas asignadas por semana.
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            OdbcConnection con = conectarBD();
            if (con != null)
            {
                //consulta de la capacidad del restaurante seleccionado.
                string strQuery = "select capacidad from restaurant where nombre = '" + ddRest.SelectedValue + "'";
                OdbcCommand sql = new OdbcCommand(strQuery, con);
                OdbcDataReader lector = sql.ExecuteReader();
                lector.Read();
                int capacidad = lector.GetInt32(0);
                //consulta del número de comidas del estudiante cuya clave única fue dada por el usuario.
                strQuery = "select numComidas from estudiante where idEstudiante = " + tbClave.Text;
                sql = new OdbcCommand(strQuery, con);
                lector = sql.ExecuteReader();
                int numComidas;
                if (lector.Read())
                {
                    numComidas = lector.GetInt32(0);
                    //restricción 1
                    if (capacidad > contarComidasRest())
                    {
                        //restricción 2
                        if (numComidas > contarComidas())
                        {
                            // query que inserta la comida. Entidad que relaciona que estudiante comerá en que restaurante en una semana específica.
                            strQuery = String.Format("insert into comida values ({0},{1},{2},{3})", ultimo().ToString(), tbClave.Text, getIdRest().ToString(), ddSemana.SelectedValue);
                            sql = new OdbcCommand(strQuery, con);
                            int insert = sql.ExecuteNonQuery();
                            if (insert > 0)
                            {
                                Response.Write("Se dio de alta la comida");
                                listComidas.Items.Clear();
                                enlistaComidas();
                            }
                            else
                                Response.Write("No se registró la comida");
                        }
                        else
                            Response.Write("Ya tienes el total de tus comidas por semana");

                    }
                    else
                        Response.Write("Este restaurante no puede ofrecer más servicios de comida. Intenta con otro restaurante");
                }
                else
                    Response.Redirect("No se encontró la clave única.");
                lector.Close();
            }
            else
                Response.Write("Conexión nula.");
            con.Close();

        }
        catch
        {
            Response.Write("Error en conexión al agregar comida. Verifica la clave única (sin ceros).");
        }


    }
    //Método que enlista las comidas de la clave única especificada por el usuario en la semana elegida por el mismo.
    protected void enlistaComidas()
    {
        try
        {
            OdbcConnection con = conectarBD();
            if (con != null)
            {
                Label2.Text = "Comidas registradas para la semana " + ddSemana.SelectedValue;
                listComidas.Items.Clear();
                //consulta que obtiene el nombre de los restaurantes. Dejando los repetidos, pues el estudiante puede comer más de una vez en el mismo restaurante en una semana.
                string strQuery = "select restaurant.nombre from restaurant inner join comida on restaurant.idRestaurant = comida.idRestaurant inner join estudiante on comida.idEstudiante = estudiante.idEstudiante where estudiante.idEstudiante =" + tbClave.Text + "and semana = " + ddSemana.SelectedValue;
                OdbcCommand sql = new OdbcCommand(strQuery, con);
                OdbcDataReader lector = sql.ExecuteReader();
                while (lector.Read())
                    listComidas.Items.Add(lector.GetString(0));
                con.Close();
                lector.Close();

            }
            else
                Response.Redirect("Error en la conexión.");
        }
        catch
        {
            Response.Write("Revisa que esté bien escrita la Clave Única (sin ceros) y hayas seleccionado una semana.");
        }
    }

    protected int contarComidas()
    {
        int a;
        try
        {

            OdbcConnection con = conectarBD();
            if (con != null)
            {
                //Cuenta las comidas que ya tiene registradas el estudiante para la semana seleccionada por el usuario.
                string strQuery = "select count(idComida) from estudiante inner join comida on estudiante.idEstudiante = comida.idEstudiante inner join restaurant on comida.idRestaurant = restaurant.idRestaurant where semana = '" + ddSemana.SelectedValue + "' and estudiante.idEstudiante =" + tbClave.Text + " group by estudiante.nombre";
                OdbcCommand sql = new OdbcCommand(strQuery, con);
                OdbcDataReader lector = sql.ExecuteReader();
                lector.Read();
                a = lector.GetInt32(0);

                lector.Close();
            }
            else
            {
                Response.Redirect("Conexión nula.");
                a = 0;
            }
            con.Close();
        }
        catch
        {
            Response.Write("Error en conexión al contar las comidas del estudiante.");
            a = 0;
        }
        return a;
    }
    //Método que cuenta el número de comidas que el restaurante tiene por semana. Necesario para la primer restricción
    protected int contarComidasRest()
    {
        int a;
        try
        {

            OdbcConnection con = conectarBD();
            if (con != null)
            {
                //Consulta que cuenta el número de comidas por restaurante.
                string strQuery = "select count(idComida) from comida where idRestaurant = " + getIdRest() + "and semana = " + ddSemana.SelectedValue;
                OdbcCommand sql = new OdbcCommand(strQuery, con);
                OdbcDataReader lector = sql.ExecuteReader();
                lector.Read();
                a = lector.GetInt32(0);
                con.Close();
                lector.Close();
            }
            else
            {
                Response.Redirect("Conexión nula.");
                a = 0;
            }

        }
        catch
        {
            Response.Write("Error en conexión al contar las comidas del restaurant.");
            a = 0;
        }
        return a;
    }
    //Método que regresa el id de la base SQL de los restaurantes registrados. Sirve para hacer la inserción de la tupla en la tabla comida.
    protected int getIdRest()
    {
        int a;
        try
        {

            OdbcConnection con = conectarBD();
            if (con != null)
            {
                //consulta que obtiene el idRestaurante según el nombre seleccionado en el DropDownList
                string strQuery = "select idRestaurant from restaurant where nombre = '" + ddRest.SelectedValue + "'";
                OdbcCommand sql = new OdbcCommand(strQuery, con);
                OdbcDataReader lector = sql.ExecuteReader();
                lector.Read();
                a = lector.GetInt32(0);
                con.Close();
                lector.Close();
            }
            else
            {
                Response.Redirect("Error en la conexión.");
                a = 0;
            }

        }
        catch
        {
            Response.Write("Error al obtener el iD del Restaurant.");
            a = 0;
        }
        return a;
    }
    //Metodo que te regresa un entero que representa el id siguiente en el orden según los registros para la inserción de una tupla en la tabla comida
    protected int ultimo()
    {
        int a;
        try
        {

            OdbcConnection con = conectarBD();
            if (con != null)
            {
                //consulta para obtener el id con el entero positivo más alto
                string strQuery = "select top 1 idComida from comida order by idComida desc";
                OdbcCommand sql = new OdbcCommand(strQuery, con);
                OdbcDataReader lector = sql.ExecuteReader();
                lector.Read();
                a = lector.GetInt32(0);
                con.Close();
                lector.Close();
            }
            else
            {
                Response.Redirect("Error en la conexión.");
                a = 0;
            }

        }
        catch
        {
            Response.Write("Error en conexión al obtener el último idComida.");
            a = 0;
        }
        return a + 1;
    }


    protected void Button1_Click1(object sender, EventArgs e)
    {



    }
}