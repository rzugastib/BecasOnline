using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Importamos las siguientes librerías para poder generar el pdf con la información de un GridView
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Text;
using System.Data;
using iTextSharp.tool.xml;

public partial class lista : System.Web.UI.Page
{
    //Método Conexión
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

    //La página carta el DataGridView con la información de la comida para cierto restaurant y para cierta semana.
    //Se despliega directo esta información pues fue solicitada desde la página restaurant.aspx
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            OdbcConnection con = conectarBD();
            if (con != null)
            {
                //Consulta que genera una lista de los estudiantes que comerán en el restaurant para cierta semana.
                string strQuery = "select estudiante.nombre as Estudiante, count(idComida) as Comidas from estudiante inner join comida on estudiante.idEstudiante = comida.idEstudiante inner join restaurant on comida.idRestaurant = restaurant.idRestaurant where semana = '" + Session["Sem"].ToString() + "' and restaurant.nombre = '" + Session["Rest"].ToString() + "'" + " group by estudiante.nombre";
                OdbcCommand sql = new OdbcCommand(strQuery, con);
                OdbcDataReader lector = sql.ExecuteReader();
                GridView1.DataSource = lector;
                GridView1.DataBind();
                //Guardamos la información de la semana y el restaurante que lo busca con la clase Session
                Label1.Text = "[" + Session["Rest"] + "]";
                Label2.Text = "Semana " + Session["Sem"] + "";

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
    //Método que permite crear un pdf de la lista de los alumnos registrados.
    //Permite a los restaurantes imprimirla para llevar un control de los servicios ofrecidos.
    protected void btCrear_Click(object sender, EventArgs e)
    {

        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {

                GridView1.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                //Se crea declara e instancia el documento con sus dimensiones como parámetros
                Document dc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                //Se declara e instancia la clase que permite escribir sobre el documento como pdf.
                PdfWriter wr = PdfWriter.GetInstance(dc, Response.OutputStream);
                dc.Open();
                //Método que convierte el pdf en html
                XMLWorkerHelper.GetInstance().ParseXHtml(wr, dc, sr);
                dc.Close();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + Session["Rest"] + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(dc);
                //Fin del stream
                Response.End();
            }
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
}