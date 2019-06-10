using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PlantillaMaestra : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie c = Request.Cookies["usuario"];
        if (c == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            Label4.Text = c.Value;
        }

        SqlConnection con = new SqlConnection();
        con.ConnectionString =
       ConfigurationManager.ConnectionStrings["TwitterDAI"].ConnectionString;
        try
        {
            con.Open();
            String foto = @"SELECT foto
                          FROM usuario
                          WHERE nick=@login";
            SqlCommand foto1 = new SqlCommand(foto, con);
            foto1.Parameters.AddWithValue("login", c.Value);
            SqlDataReader drfoto = foto1.ExecuteReader();
            while (drfoto.Read())
            {
                String x = drfoto.GetString(0);
                Image7.ImageUrl = "fotos/"+ x;
            }
            drfoto.Close();
            String qs = @"SELECT count(*)
                          FROM Tweet
                          WHERE nick=@login";
            SqlCommand q = new SqlCommand(qs, con);
            q.Parameters.AddWithValue("login", c.Value);
            SqlDataReader dr = q.ExecuteReader();
            while (dr.Read())
            {
                int x = dr.GetInt32(0);
                Label1.Text = x.ToString();
            }
            dr.Close();

            String qs1 = @"SELECT count(*)
                          FROM Seguidor
                          WHERE nickStalker=@login";
            SqlCommand q1 = new SqlCommand(qs1, con);
            q1.Parameters.AddWithValue("login", c.Value);
            SqlDataReader dr2 = q1.ExecuteReader();
            while (dr2.Read())
            {
                int x = dr2.GetInt32(0);
                Label2.Text = x.ToString();
            }
            dr2.Close();

            String qs2 = @"SELECT count(*)
                          FROM Seguidor
                          WHERE nickStalkeado=@login";
            SqlCommand q2 = new SqlCommand(qs2, con);
            q2.Parameters.AddWithValue("login", c.Value);
            SqlDataReader dr3 = q2.ExecuteReader();
            while (dr3.Read())
            {
                int x = dr3.GetInt32(0);
                Label3.Text = x.ToString();
            }
            dr3.Close();


            con.Close();
            //procesar

        }
        catch (SqlException err)
        {
            Response.Write("<h2> Error </h2>" + err);
        }


    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        HttpCookie c = new HttpCookie("usuario");
        c.Expires = DateTime.Now.AddDays(-1);
        Response.SetCookie(c);
        Response.Redirect("Login.aspx");
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {
        HttpCookie c = Request.Cookies["usuario"];

        SqlConnection con = new SqlConnection();
        con.ConnectionString =
       ConfigurationManager.ConnectionStrings["TwitterDAI"].ConnectionString;
        try
        {
            con.Open();
            String qs = @"INSERT INTO Tweet
                          VALUES(@text, GetDate(), @nick)";
            SqlCommand q = new SqlCommand(qs, con);
            q.Parameters.AddWithValue("nick", c.Value);
            q.Parameters.AddWithValue("text", TextBox1.Text);
            q.ExecuteNonQuery();

            con.Close();
            Response.Redirect("PaginaPrincipal.aspx");
        }
        catch (SqlException err)
        {
            Response.Write("<h2> Tu base chafeó gacho </h2>" + err);
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("PaginaPrincipal.aspx");
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Notificaciones.aspx");
    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        HttpCookie c = new HttpCookie("busca");
        TextBox2.Text = "%" + TextBox2.Text + "%";
        c.Value = TextBox2.Text;
        c.Expires = DateTime.Now.AddMinutes(30);
        Response.Cookies.Add(c);
        Response.Redirect("Busca.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void ImageButton2_Click1(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Notificaciones.aspx");
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        Response.Redirect("Busca.aspx");
    }
}

