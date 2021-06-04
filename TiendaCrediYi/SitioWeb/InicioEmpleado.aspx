<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioEmpleado.aspx.cs" Inherits="SitioWeb.InicioEmpleado" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous" />
    <title>Bienvenido Tienda CrediYi</title>
    <style>
      .bd-placeholder-img {
        font-size: 1.125rem;
        text-anchor: middle;
        -webkit-user-select: none;
        -moz-user-select: none;
        user-select: none;
      }

      @media (min-width: 768px) {
        .bd-placeholder-img-lg {
          font-size: 3.5rem;
        }
      }
    </style> 
  </head>
  <body style:"margin-top: 110px; background-color: #f8f9fa;">
    <div Class="container well"  style="margin: 5%;
                                        background-color: #f8f9fa;
                                        padding-left: 2%;
                                        padding-top: 10px;
                                        padding-bottom: 10px;
                                        text-align: center;">
  <main class="px-3">
    <h1>Bienvenido a Tienda CrediYi</h1> 
  </main>
     <p class="lead">Seleccione la opción deseada</p>
     <a class="nav-link" href="RegistroCompra.aspx">Agregar una nueva Compra</a>
     <a class="nav-link" href="ReporteCompras.aspx">Consultar la totalidad de Compras</a>
     <a class="nav-link" href="ReporteComprasCliente.aspx">Consultar las compras realizadas por Cliente</a>
</div>
</body>
</html>
