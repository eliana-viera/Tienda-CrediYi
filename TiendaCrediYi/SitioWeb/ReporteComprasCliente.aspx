<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteComprasCliente.aspx.cs" Inherits="SitioWeb.ReporteComprasCliente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>Compras por Cliente</title>
    <!-- CSS only -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous">
</head>
  <body> 
   <div class="contenedor">
        <form id="form1" runat="server" class="form-horizontal">
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
                <a class="nav-link" href="ReporteCompras.aspx">Reporte de Compras</a>
              </li>
            </ul>
          
              <asp:Button ID="btnSalir" runat="server" Text="Salir"  class="btn btn-primary" onclick="btnSalir_Click"/> 
          </div>
     </nav>
     <div class="form-floating mb-3">
      <div class="div-back" style="margin: 5%;
                                        background-color: #f8f9fa;
                                        padding-left: 2%;
                                        padding-top: 10px;
                                        padding-bottom: 10px;">
          <h4 style="text-align:center">Reporte de compras por cliente</h4>
           <hr />
          <br />
          <asp:Label ID="Label1" runat="server" Text="Cliente"></asp:Label>
&nbsp;<asp:TextBox ID="txtCliente" runat="server" MaxLength="8" TextMode="Number"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;        
          <asp:Button ID="btnBuscar" runat="server" Text="Buscar" class="btn btn-primary" 
              onclick="btnBuscar_Click"  />
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" 
              class="btn btn-primary" onclick="btnLimpiar_Click"  />
&nbsp;<div style="margin-top:5px;">

              <br />
              <asp:GridView ID="gvCompras" runat="server" AutoGenerateColumns="False" 
                  onselectedindexchanged="gvCompras_SelectedIndexChanged">
                  <Columns>
                      <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
                      <asp:BoundField DataField="IdCabezal" HeaderText="ID" />
                      <asp:BoundField DataField="Serie" HeaderText="Serie" />
                      <asp:BoundField DataField="Numero" HeaderText="Numero" />
                      <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                      <asp:BoundField DataField="totalCompra" HeaderText="Total" />
                  </Columns>
              </asp:GridView>
              <br />
              <asp:GridView ID="gvDetalle" runat="server" BackColor="White" 
                  BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                  ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False">
                  <AlternatingRowStyle BackColor="White" />
                  <Columns>
                      <asp:BoundField HeaderText="Producto Id" DataField="producto.IdProducto" />
                      <asp:BoundField DataField="producto.Descripcion" HeaderText="Descripcion" />
                      <asp:BoundField HeaderText="Cantidad" DataField="cantidad" />
                  </Columns>
                  <FooterStyle BackColor="#CCCC99" />
                  <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                  <RowStyle BackColor="#F7F7DE" />
                  <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
              </asp:GridView>
              <br />
              <asp:Label ID="lblError" runat="server"></asp:Label>
        </div>
      </div>
      </form>
</body>
</html>

