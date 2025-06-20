<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaReserva1.aspx.cs" Inherits="ServiciosWebHotel.ConsultaReserva1" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
   <main style="background-image: url('images/fondoconsulta.jpg'); background-size: cover; background-position: center; min-height: 100vh;">
        <div class="container d-flex align-items-center justify-content-center" style="min-height: 100vh;">
            <div class="card shadow-lg rounded-5 p-5 border-0" style="background: rgba(255, 255, 255, 0.95); max-width: 600px; width: 100%;">

                <h2 class="mb-4 text-center fw-bold">Consultar Reserva</h2>

                <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger text-center d-block mb-3" />

                <div class="mb-3">
                    <asp:Label ID="lblId" runat="server" AssociatedControlID="txtReservaId" Text="ID de Reserva:" CssClass="form-label" />
                    <asp:TextBox ID="txtReservaId" runat="server" CssClass="form-control rounded-3 shadow-sm" />
                </div>

                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-warning btn-lg w-100 rounded-pill shadow mb-4" OnClick="btnBuscar_Click" />

                <asp:Panel ID="pnlResultado" runat="server" Visible="false">
                    <div class="p-4 bg-light rounded-4 border shadow-sm">
                        <asp:Literal ID="litResultado" runat="server" />
                    </div>
                </asp:Panel>

            </div>
        </div>
    </main>
</asp:Content>
