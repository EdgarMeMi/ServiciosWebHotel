<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarReserva.aspx.cs" Inherits="ServiciosWebHotel.AgregarReserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <main style="background-image: url('images/fondoagregar.jpg'); background-size: cover; background-position: center; min-height: 100vh;">
    <div class="container d-flex align-items-center justify-content-center" style="min-height: 100vh;">
        <div class="card shadow-lg rounded-5 p-5 border-0" style="background: rgba(255, 255, 255, 0.95); max-width: 700px; width: 100%;">

            <h2 class="mb-4 text-center fw-bold">Agregar Nueva Reserva</h2>

            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger text-center d-block mb-3" />

            <div class="mb-3">
                <asp:Label AssociatedControlID="txtCliente" runat="server" Text="Nombre del Cliente" CssClass="form-label" />
                <asp:TextBox ID="txtCliente" runat="server" CssClass="form-control rounded-3 shadow-sm" />
            </div>

            <div class="mb-3">
                <asp:Label AssociatedControlID="ddlTipoHabitacion" runat="server" Text="Tipo de Habitación" CssClass="form-label" />
                <asp:DropDownList ID="ddlTipoHabitacion" runat="server" CssClass="form-select rounded-3 shadow-sm" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoHabitacion_SelectedIndexChanged" />
            </div>

            <div class="mb-3">
                <asp:Label AssociatedControlID="txtPrecio" runat="server" Text="Precio por Noche" CssClass="form-label" />
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control rounded-3 shadow-sm" ReadOnly="true" />
            </div>

            <div class="mb-3">
                <asp:Label AssociatedControlID="txtNoches" runat="server" Text="Número de Noches" CssClass="form-label" />
                <asp:TextBox ID="txtNoches" runat="server" CssClass="form-control rounded-3 shadow-sm" />
            </div>

            <div class="mb-3">
                <asp:Label AssociatedControlID="txtCheckin" runat="server" Text="Fecha de Check-In" CssClass="form-label" />
                <asp:TextBox ID="txtCheckin" runat="server" CssClass="form-control rounded-3 shadow-sm" TextMode="Date" />
            </div>

            <div class="mb-4">
                <asp:Label AssociatedControlID="txtCheckout" runat="server" Text="Fecha de Check-Out" CssClass="form-label" />
                <asp:TextBox ID="txtCheckout" runat="server" CssClass="form-control rounded-3 shadow-sm" TextMode="Date" />
            </div>

            <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-warning btn-lg w-100 rounded-pill shadow" Text="Registrar Reserva" OnClick="btnRegistrar_Click" />

        </div>
    </div>
</main>

<!-- JS para validar fechas y calcular noches automáticamente -->
<script type="text/javascript">
    window.onload = function () {
        var today = new Date().toISOString().split('T')[0];
        var txtCheckin = document.getElementById('<%= txtCheckin.ClientID %>');
        var txtCheckout = document.getElementById('<%= txtCheckout.ClientID %>');
        var txtNoches = document.getElementById('<%= txtNoches.ClientID %>');

        txtCheckin.setAttribute('min', today);
        txtCheckout.setAttribute('min', today);
        txtNoches.setAttribute('readonly', true); // Solo lectura del lado del cliente

        txtCheckin.addEventListener('change', function () {
            txtCheckout.setAttribute('min', this.value);
            calcularNoches();
        });

        txtCheckout.addEventListener('change', function () {
            calcularNoches();
        });

        function calcularNoches() {
            let fechaIn = new Date(txtCheckin.value);
            let fechaOut = new Date(txtCheckout.value);

            if (!isNaN(fechaIn) && !isNaN(fechaOut) && fechaOut > fechaIn) {
                let diferencia = fechaOut - fechaIn;
                let noches = diferencia / (1000 * 60 * 60 * 24);
                txtNoches.value = noches;
            } else {
                txtNoches.value = "";
            }
        }
    };
</script>
</asp:Content>