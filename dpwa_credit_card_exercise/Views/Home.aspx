<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="dpwa_credit_card_exercise.Home1" %>

<%@ Register Src="~/UserControl/InputTarjeta.ascx" TagName="ValidarTarjeta" TagPrefix="ucl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <ucl:ValidarTarjeta ID="ValidarTarjeta1" runat="server" />

</asp:Content>
