<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroCompra.aspx.cs" Inherits="SitioWeb.RegistroCompra" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Agregar Compra</title>
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous"/>
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
          <li class="nav-item">
            <a class="nav-link" href="ReporteCompras.aspx">Reporte de Compras</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="ReporteComprasCliente.aspx">Reporte de Compras por Cliente</a>
         </li>
          </ul> 
            <asp:Button ID="btnSalir" runat="server" Text="Salir"  class="btn btn-primary"
                  onclick="btnSalir_Click"/>   
      </div>
    </nav>     
        <div class="form-floating mb-3">
           
            <div class="div-back" style="margin: 5%;
                                        background-color: #f8f9fa;
                                        padding-left: 2%;
                                        padding-top: 10px;
                                        padding-bottom: 10px;">
            <h3 style="text-align:center"> Agregar compra</h3>
            <hr />
                <asp:Button ID="BtnLimpiar" runat="server" Text="Limpiar" 
                    class="btn btn-primary" onclick="BtnLimpiar_Click"/>
                <br />
                <br />
                <asp:Label ID="Label5" runat="server" Text="Serie"></asp:Label>
&nbsp;
                <asp:TextBox ID="txtSerie" runat="server" MaxLength="1"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label6" runat="server" Text="Número"></asp:Label>
&nbsp;<asp:TextBox ID="txtNumero" runat="server" TextMode="Number"></asp:TextBox>
                &nbsp;
            <asp:Label ID="Label2" runat="server" Text="Cliente"></asp:Label>
&nbsp;<asp:TextBox ID="txtCliente" runat="server" ontextchanged="txtCliente_TextChanged" 
                    MaxLength="8" TextMode="Number"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <br />
            <asp:Label ID="Label1" runat="server" Text="Fecha" CssClass="control-label col-sm-2"></asp:Label>
            <br />
            <asp:Calendar ID="CldFecha" runat="server"></asp:Calendar>
            &nbsp;
            <br />
&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Text="Producto"></asp:Label>
&nbsp;&nbsp;
                <asp:DropDownList ID="ddlProducto" runat="server">
                </asp:DropDownList>
&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server" Text="Cantidad"></asp:Label>
&nbsp; <asp:TextBox ID="TxtCantidad" runat="server" TextMode="Number"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar producto" 
                    class="btn btn-primary" onclick="btnAgregarProducto_Click" />
                <br />
            <br />
            <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" 
                    onselectedindexchanged="gvProductos_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="producto.IdProducto" HeaderText="Codigo" />
                    <asp:BoundField DataField="producto.Descripcion" HeaderText="Descripcion" />
                    <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" />
                </Columns>
            </asp:GridView>
                <br />
            <asp:Button ID="BtnAgregar" runat="server" Text="Agregar" class="btn btn-primary" 
                    Enabled="False" onclick="BtnAgregar_Click" />
                <br />
                <br />
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            <br />
         </div>
        </div>
    </form>
     </div>
</body>
</html>
