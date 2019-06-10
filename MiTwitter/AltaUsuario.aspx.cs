using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AltaUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //conectar a la base
        SqlConnection con = new SqlConnection();
        con.ConnectionString =
       ConfigurationManager.ConnectionStrings["TwitterDAI"].ConnectionString;
        try
        {
            con.Open();
            //enviar mi alta
            String sq = @"INSERT INTO Usuario(nick, pwd, nombre, email, foto)
                          VALUES(@nick, @pwd, @nombre, @email, @foto);
                          INSERT INTO Seguidor(nickStalker, nickStalkeado)
                          VALUES(@nick, @nick)";
            SqlCommand q = new SqlCommand(sq, con);
            q.Parameters.AddWithValue("nick", TextBox1.Text);
            q.Parameters.AddWithValue("pwd", TextBox2.Text);
            q.Parameters.AddWithValue("nombre", TextBox3.Text);
            q.Parameters.AddWithValue("email", TextBox4.Text);
            if (FileUpload1.HasFile)
            {
                q.Parameters.AddWithValue("foto", TextBox1.Text + Path.GetExtension(FileUpload1.FileName));
                FileUpload1.SaveAs(Server.MapPath("~/fotos/") +
                   TextBox1.Text + Path.GetExtension(FileUpload1.FileName));
            }
            else
                q.Parameters.AddWithValue("foto", "huevito.png");

            q.ExecuteNonQuery();

            con.Close();

            Label1.Text = "Usuario creado. Felicidades!";
            Response.Redirect("Login.aspx");

            //TODO: recuerda que tmb hay que seguirme a mi mismo
            //TODO: Irme al default o plantar cookie

        }
        catch (SqlException error)
        {
            //verificar si es por el nick
            if (error.Number == 2627)
                Label1.Text = "Te ganaron el nick por tortugo";
            //o si es error del servidor
            else
                Label1.Text = "Error del servidor. Date un tiro";
            //TODO: borrar la imagen del servidor
        }
        catch (IOException error)
        {
            Label1.Text = "Error al cargar la imagen. ¿Quizás estás muy feo?";

        }
    }
}