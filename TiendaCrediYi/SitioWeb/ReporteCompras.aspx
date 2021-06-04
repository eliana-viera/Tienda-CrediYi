<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteCompras.aspx.cs" Inherits="SitioWeb.ReporteCompras" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reporte de compras</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous">

</head>
<body>
 <form id="form1" runat="server">
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav mr-auto">
          <li class="nav-item active">
            <a class="nav-link" href="InicioEmpleado.aspx">Incio  </a>
          </li>
          <li class="nav-item active">
            <a class="nav-link" href="RegistroCompra.aspx">Agregar Compra</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="ReporteComprasCliente.aspx">Reporte de Compras por Cliente</a>
          </li>
          </ul>
        <form class="form-inline my-2 my-lg-0">
          <asp:Button ID="btnSalir" runat="server" Text="Salir"  class="btn btn-primary"
                  onclick="btnSalir_Click"/>
        </form>
      </div>
    </nav>  
        <div class="div-back" style="margin: 5%;
                                    background-color: #f8f9fa;
                                    padding-left: 2%;
                                    padding-top: 10px;">
           <h4 style="text-align:center">Reporte de compras Realizadas</h4>
           <hr />
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="gvCompras" runat="server" BackColor="White" 
                BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
            <br />
        </div>
    </form>
</body>
</html>

