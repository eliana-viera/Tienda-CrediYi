<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SitioWeb.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Logueo</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous"/>
</head>
 
  <body> 
      <div class="contenedor" style="margin-top: 70px; margin:auto;width: 40%; padding-top: 10%;" >
      <div class="container well"  style="margin: 5%;
                                        background-color: #f8f9fa;
                                        padding-left: 2%;
                                        padding-top: 10px;
                                        padding-bottom: 10px;">
      <div class="row" > 
          <div class="col-xs-12" >
              <h1 style="text-align:center">Tienda CrediYi </h1>
              <hr />
              <h4 style="text-align: center;">Iniciar sesión </h4>
          </div>
          
      </div>
      <form id="form1" runat="server" class="form-horizontal" style="margin: auto;">
            <div class="form-group" style="padding-left: 5%;">       
                <p id="lblCI">
                    <asp:Label ID="lblCedula" runat="server" Text="Cedula" CssClass="control-label col-sm-2"></asp:Label>
                </p>
                <p>
                    <asp:TextBox ID="txtCedula" runat="server" MaxLength="8" TextMode="Number"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="lblContrasena" runat="server" Text="Contraseña" CssClass="control-label col-sm-2"></asp:Label>
                </p>
                <p>
                    <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password"></asp:TextBox>
                </p>
                <p>
                    <asp:Button ID="BtnIngresar" runat="server" Text="Ingresar" class="btn btn-primary" OnClick="BtnIngresar_Click" />
                </p>
                <p>
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                </p>    
        </div>
    </form>
    </div>
    </div>
</body>

</html>
