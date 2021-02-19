<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InputTarjeta.ascx.cs" Inherits="dpwa_credit_card_exercise.InputText" %>

<div class="container  justify-content-center align-items-center d-flex" style="height: 100vh">
    <div class="row row-cols-12  justify-content-center align-items-center shadow bg-white pt-5 pb-5">
        <h2 class="text-dark mb-5 ms-5 fw-bold">Validación de tarjeta de crédito</h2>
        <div class="col-sm-12 col-lg-8 justify-content-center align-items-center">
            <div class="input-group input-group-sm">
                <span class="input-group-text" id="num" runat="server">Numero de Tarjeta</span>
                <asp:TextBox ID="txtTarjeta" CssClass="form-control" runat="server" MaxLength="16"></asp:TextBox>
            </div>
            <h5 class="mt-2 mb-2 text-dark">Fecha de caducidad</h5>
            <div class="input-group mb-4 input-group-sm">
                <span class="input-group-text" id="mes" runat="server">Mes</span>
                <asp:DropDownList ID="drpMes" runat="server" CssClass="form-control"></asp:DropDownList>
                <span class="input-group-text">Año</span>
                <asp:DropDownList ID="drpYear" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="input-group mt-4 justify-content-center align-items-center">
                <asp:Button ID="btnValidar" CssClass="btn btn-primary btn-sm shadow px-4" runat="server" Text="Validar" OnClick="btnValidar_Click" />
            </div>
            <asp:Label ID="lblResponse" runat="server" Text=" ">&nbsp;</asp:Label>
            <asp:Label ID="lblResponse2" runat="server" Text=" ">&nbsp;</asp:Label>
        </div>
    </div>
</div>
