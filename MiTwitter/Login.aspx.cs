using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //conectarme a la base
        SqlConnection con = new SqlConnection();
        con.ConnectionString =
       ConfigurationManager.ConnectionStrings["TwitterDAI"].ConnectionString;
        try
        {
            con.Open();
            //generar un query
            String qs = @"SELECT count(*)
                          FROM Usuario
                          WHERE nick=@login AND pwd = @pwd";
            SqlCommand q = new SqlCommand(qs, con);
            q.Parameters.AddWithValue("login", TextBox1.Text);
            q.Parameters.AddWithValue("pwd", TextBox2.Text);
            //enviar el query a la base
            int v = (int)q.ExecuteScalar();
            con.Close();
            //procesar
            if (v == 1)
            {
                HttpCookie c = new HttpCookie("usuario");
                c.Value = TextBox1.Text;
                c.Expires = DateTime.Now.AddMinutes(30);
                Response.Cookies.Add(c);
                Response.Redirect("PaginaPrincipal.aspx");
            }
            else
            {
                Response.Write("Contraseña o usuario erroneos");
            }
        }
        catch (SqlException err)
        {
            Response.Write("<h2> Tu base chafeó gacho </h2>" + err);
        }
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AltaUsuario.aspx");
    }
}