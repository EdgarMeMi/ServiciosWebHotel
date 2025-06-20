using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosWebHotel
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ReservaService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ReservaService.svc o ReservaService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ReservaService : IReservaService
    {
        public bool AgregarReserva(Reserva2 nuevaReserva)
        {
            if (string.IsNullOrWhiteSpace(nuevaReserva.Cliente) ||
                string.IsNullOrWhiteSpace(nuevaReserva.HabTipo) ||
                nuevaReserva.Noches <= 0 || nuevaReserva.PrecioNoche <= 0 ||
                nuevaReserva.Checkin >= nuevaReserva.Checkout)
            {
                throw new ArgumentException("Datos inválidos para la reserva.");
            }

            string cs = ConfigurationManager.ConnectionStrings["HotelConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = @"
                INSERT INTO reservas_hotel 
                (cliente, hab_tipo, precio_noche, noches, checkin, checkout) 
                VALUES (@cliente, @hab_tipo, @precio_noche, @noches, @checkin, @checkout)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cliente", nuevaReserva.Cliente);
                cmd.Parameters.AddWithValue("@hab_tipo", nuevaReserva.HabTipo);
                cmd.Parameters.AddWithValue("@precio_noche", nuevaReserva.PrecioNoche);
                cmd.Parameters.AddWithValue("@noches", nuevaReserva.Noches);
                cmd.Parameters.AddWithValue("@checkin", nuevaReserva.Checkin);
                cmd.Parameters.AddWithValue("@checkout", nuevaReserva.Checkout);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
