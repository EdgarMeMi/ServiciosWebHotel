<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ServiciosWebHotel.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <main style="background-image: url('images/fondocontacto.jpg'); background-size: cover; background-position: center; min-height: 100vh;">
        <div class="container d-flex align-items-center justify-content-center" style="min-height: 100vh;">
            <div class="card shadow-lg rounded-5 p-5 border-0" style="background: rgba(255, 255, 255, 0.95); max-width: 700px; width: 100%;">
                <h2 class="text-center fw-bold mb-4">Contáctanos</h2>
                <p class="text-center text-muted mb-4">Estamos encantados de ayudarte. Aquí tienes nuestros datos de contacto:</p>

                <div class="mb-4">
                    <h5 class="fw-bold">Dirección</h5>
                    <p class="mb-0">Hotel Paraíso del Sol</p>
                    <p>Avenida del Mar 1234<br />Playa Dorada, Costa Azul 45678</p>
                </div>

                <div class="mb-4">
                    <h5 class="fw-bold">Teléfono</h5>
                    <p>+52 (999) 123-4567</p>
                </div>

                <div class="mb-4">
                    <h5 class="fw-bold">Correo Electrónico</h5>
                    <p>
                        <strong>Atención al cliente:</strong> <a href="mailto:atencion@paraisodelsol.com">atencion@paraisodelsol.com</a><br />
                        <strong>Reservaciones:</strong> <a href="mailto:reservas@paraisodelsol.com">reservas@paraisodelsol.com</a><br />
                        <strong>Marketing:</strong> <a href="mailto:marketing@paraisodelsol.com">marketing@paraisodelsol.com</a>
                    </p>
                </div>

                <div class="text-center">
                    <img src="images/logohotel.png" alt="Hotel Paraíso del Sol" style="max-height: 50px;" class="mt-3" />
                </div>
            </div>
        </div>
    </main>
</asp:Content>
