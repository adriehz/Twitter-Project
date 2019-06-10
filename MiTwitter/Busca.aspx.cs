using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Busca : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        HttpCookie c = Request.Cookies["usuario"];
        SqlConnection con = new SqlConnection();
        con.ConnectionString =
       ConfigurationManager.ConnectionStrings["TwitterDAI"].ConnectionString;
        try
        {
            con.Open();
            String select = (String) GridView1.SelectedValue;
            String qs = @"SELECT count(*)
                          FROM Seguidor
                          WHERE nickStalker=@stalker AND nickStalkeado = @stalkeado";
            SqlCommand q = new SqlCommand(qs, con);
            q.Parameters.AddWithValue("stalker", c.Value);
            q.Parameters.AddWithValue("stalkeado", select);
            //enviar el query a la base
            int v = (int)q.ExecuteScalar();
            //procesar
            if (v == 0)
            {
                //enviar mi alta
                String sq = @"INSERT INTO Seguidor(nickStalker, nickStalkeado)
                            VALUES (@nickStalker, @nickStalkeado)";
                SqlCommand q1 = new SqlCommand(sq, con);
                q1.Parameters.AddWithValue("nickStalker", c.Value);
                q1.Parameters.AddWithValue("nickStalkeado", select);
                q1.ExecuteNonQuery();
                con.Close();
                Label5.Visible = true;
                Label5.Text = "Ahora estas siguiendo a " + select + "!";
            }
            else
            {
                Label5.Visible = true;
                Label5.Text = "Ya estas siguiendo a " + select + "!";
            }
        }
        catch (SqlException error)
        {
            Response.Write("super fail" + error);
            {


            }
        }
    }
    protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
    {
        HttpCookie c = Request.Cookies["usuario"];
        SqlConnection con = new SqlConnection();
        con.ConnectionString =
       ConfigurationManager.ConnectionStrings["TwitterDAI"].ConnectionString;
        try
        {
            con.Open();
            String select = (String)GridView1.SelectedValue;
            String qs = @"SELECT count(*)
                          FROM Seguidor
                          WHERE nickStalker=@stalker AND nickStalkeado = @stalkeado";
            SqlCommand q = new SqlCommand(qs, con);
            q.Parameters.AddWithValue("stalker", c.Value);
            q.Parameters.AddWithValue("stalkeado", select);
            //enviar el query a la base
            int v = (int)q.ExecuteScalar();
            //procesar
            if (v == 1)
            {
                String sq = @"DELETE FROM Seguidor
                            WHERE nickStalker = @nick AND nickStalkeado = @stalkeado";
                SqlCommand q1 = new SqlCommand(sq, con);
                q1.Parameters.AddWithValue("nick", c.Value);
                q1.Parameters.AddWithValue("stalkeado", select);
                q1.ExecuteNonQuery();
                con.Close();

                Label5.Visible = true;
                Label5.Text = "Dejaste de seguir a " + select + "!";
            }
            else
            {
                Label5.Visible = true;
                Label5.Text = "No estas siguiendo a " + select + "!";
            }


        }
        catch (SqlException error)
        {
            Response.Write("super fail" + error);
            {


            }
        }
    }
}