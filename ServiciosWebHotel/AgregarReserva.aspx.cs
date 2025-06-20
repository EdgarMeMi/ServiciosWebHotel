using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiciosWebHotel.ReservaServiceReference;

namespace ServiciosWebHotel
{
    public partial class AgregarReserva : System.Web.UI.Page
    {
        protected void ddlTipoHabitacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = ddlTipoHabitacion.SelectedValue;
            double precio = 0;

            switch (tipo)
            {
                case "S1": precio = 2500; break;
                case "D1": precio = 1800; break;
                case "I1": precio = 1200; break;
                case "F1": precio = 3000; break;
            }

            txtPrecio.Text = precio.ToString("F2", CultureInfo.InvariantCulture);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlTipoHabitacion.Items.Clear();
                ddlTipoHabitacion.Items.Add(new ListItem("Suite", "S1"));
                ddlTipoHabitacion.Items.Add(new ListItem("Doble", "D1"));
                ddlTipoHabitacion.Items.Add(new ListItem("Individual", "I1"));
                ddlTipoHabitacion.Items.Add(new ListItem("Familiar", "F1"));

                ddlTipoHabitacion_SelectedIndexChanged(null, null); // Actualizar precio al cargar
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // ✅ Validación de fechas
                DateTime checkin = DateTime.Parse(txtCheckin.Text);
                DateTime checkout = DateTime.Parse(txtCheckout.Text);
                DateTime hoy = DateTime.Today;

                if (checkin < hoy)
                {
                    lblMensaje.Text = "La fecha de Check-In no puede ser anterior a hoy.";
                    return;
                }

                if (checkout < hoy)
                {
                    lblMensaje.Text = "La fecha de Check-Out no puede ser anterior a hoy.";
                    return;
                }

                if (checkout <= checkin)
                {
                    lblMensaje.Text = "La fecha de Check-Out debe ser posterior a la de Check-In.";
                    return;
                }

                // ✅ Validación de entrada numérica
                if (!double.TryParse(txtPrecio.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out double precio))
                {
                    lblMensaje.Text = "Precio inválido. Verifica el tipo de habitación.";
                    return;
                }

                if (!int.TryParse(txtNoches.Text, out int noches))
                {
                    lblMensaje.Text = "Número de noches inválido.";
                    return;
                }

                // ✅ Datos completos
                var cliente = txtCliente.Text;
                var habTipo = ddlTipoHabitacion.SelectedValue;

                var nueva = new ReservaServiceReference.Reserva2
                {
                    Cliente = cliente,
                    HabTipo = habTipo,
                    PrecioNoche = precio,
                    Noches = noches,
                    Checkin = checkin,
                    Checkout = checkout
                };

                var client = new ReservaServiceReference.ReservaServiceClient();
                bool exito = client.AgregarReserva(nueva);

                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Text = exito ? "Reserva registrada exitosamente." : "Error al registrar reserva.";
            }
            catch (Exception ex)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }
    }
}