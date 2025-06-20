using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiciosWebHotel.HotelService;

namespace ServiciosWebHotel
{
    public partial class ConsultaReserva1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int reservaId;

            if (!int.TryParse(txtReservaId.Text, out reservaId) || reservaId <= 0)
            {
                lblMensaje.Text = "Ingrese un ID válido.";
                pnlResultado.Visible = false;
                return;
            }
            
            try
            {
               
                HotelService1 client = new HotelService1();
                Reserva r = client.ObtenerReservaPorId(reservaId);

                litResultado.Text = $@"
                <div class='alert alert-success'>
                    <strong>Reserva encontrada:</strong><br/>
                    <b>ID:</b> {r.ReservaId}<br/>
                    <b>Cliente:</b> {r.Cliente}<br/>
                    <b>Tipo de Habitación:</b> {r.HabTipo}<br/>
                    <b>Precio por Noche:</b> ${r.PrecioNoche}<br/>
                    <b>Noches:</b> {r.Noches}<br/>
                    <b>Check-In:</b> {r.Checkin.ToShortDateString()}<br/>
                    <b>Check-Out:</b> {r.Checkout.ToShortDateString()}
                </div>";
                lblMensaje.Text = "";
                pnlResultado.Visible = true;
                
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error: {ex.Message}";
                pnlResultado.Visible = false;
            }
               
        }
    }
}