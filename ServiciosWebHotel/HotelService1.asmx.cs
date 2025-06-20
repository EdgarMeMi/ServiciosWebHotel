using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServiciosWebHotel
{
    /// <summary>
    /// Descripción breve de HotelService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class HotelService1 : System.Web.Services.WebService
    {

        
        [WebMethod]
        public Reserva ObtenerReservaPorId(int reservaId)
        {
            if (reservaId <= 0)
                throw new ArgumentException("ID de reserva inválido.");

            string cs = ConfigurationManager.ConnectionStrings["HotelConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(@"
            SELECT reserva_id, cliente, hab_tipo, precio_noche, noches, checkin, checkout
            FROM reservas_hotel
            WHERE reserva_id = @reservaId", conn);

                cmd.Parameters.AddWithValue("@reservaId", reservaId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                {
                    if (reader.Read())
                    {
                        return new Reserva
                        {
                            ReservaId = Convert.ToInt32(reader["reserva_id"]),
                            Cliente = reader["cliente"].ToString(),
                            HabTipo = reader["hab_tipo"].ToString(),
                            Noches = Convert.ToInt32(reader["noches"]),
                            PrecioNoche = Convert.ToDouble(reader["precio_noche"]),
                            Checkin = Convert.ToDateTime(reader["checkin"]),
                            Checkout = Convert.ToDateTime(reader["checkout"])
                        };
                    }
                    else
                    {
                        throw new Exception("Reserva no encontrada.");
                    }
                }
            }
        }


    }

    public class Reserva
    {
        public int ReservaId { get; set; }
        public string Cliente { get; set; }
        public string HabTipo { get; set; }
            public int Noches { get; set; }
            public double PrecioNoche { get; set; }
       
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
    }
}

