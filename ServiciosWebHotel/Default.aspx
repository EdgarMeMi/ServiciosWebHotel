<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ServiciosWebHotel._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

 <main style="background-image: url('images/fondohotel.jpg'); background-size: cover; background-position: center; min-height: 100vh;">
    <div class="container d-flex align-items-center justify-content-center" style="min-height: 100vh;">
        <div class="card shadow-lg rounded-5 p-5 text-white text-center border-0" style="background: rgba(0, 0, 0, 0.6); max-width: 700px;">

            <h1 class="display-4 fw-bold mb-4">Bienvenido al <span style="color: #ffcc70;">Hotel Paraíso</span></h1>
            <p class="lead mb-5">Tu escape perfecto. Reserva tu habitación de ensueño o revisa tu próxima estadía.</p>

            <div class="d-flex flex-column flex-md-row justify-content-center gap-4">
                <a href="AgregarReserva.aspx" class="btn btn-warning btn-lg px-5 py-3 rounded-pill shadow-lg" style="font-weight: 600;">
                    Hacer Reserva
                </a>
                <a href="ConsultaReserva1.aspx" class="btn btn-outline-light btn-lg px-5 py-3 rounded-pill shadow-lg" style="font-weight: 600;">
                    Consultar Reserva
                </a>
            </div>

        </div>
    </div>
</main>

</asp:Content>
