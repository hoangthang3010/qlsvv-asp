<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginView.aspx.cs" Inherits="Doanbaove.loginView" %>

<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">
    
  <title>Hệ thống quản lí sinh viên</title>

  <!-- Custom fonts for this template-->
  <link href="Assets/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
  <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">
  <!-- Custom styles for this template-->
  <link href="Assets/css/sb-admin-2.min.css" rel="stylesheet">
  <script src="Scripts/animation.js"></script>

    <style type="text/css">
        .auto-style1 {
            text-align: center;
            font-family: "Segoe UI";
        }
        .auto-style2 {
            position: relative;
            width: 100%;
            flex: 0 0 50%;
            max-width: 50%;
            left: 0px;
            top: 0px;
            padding-left: .75rem;
            padding-right: .75rem;
        }
    </style>

</head>
<body>



    <div>
          <div class="container">

    <!-- Outer Row -->
    <div class="row justify-content-center">

      <div class="col-xl-10 col-lg-12 col-md-9">

        <div class="card o-hidden border-0 shadow-lg my-5">
          <div class="card-body p-0">
            <!-- Nested Row within Card Body -->
            <div class="row">
              <div class="col-lg-6 d-none d-lg-block bg-login-image"></div>
              <div class="auto-style2">
                <div class="p-5">
                  <div class="text-center">
                    <h1 class="h4 text-gray-900 mb-4">Phần mềm quản lý sinh viên</h1>
                  </div>
                  <form class="user" runat="server" method="post">
                    <div class="form-group">  
                        <asp:TextBox ID="txt_username" runat="server" class="form-control form-control-user" aria-describedby="emailHelp" placeholder="Enter Username"></asp:TextBox>
                        </div>
                    <div class="form-group">
                
                        <asp:TextBox ID="txt_password" runat="server" type="password" class="form-control form-control-user"  placeholder="Password"></asp:TextBox> 

                    </div>
                    <div class="form-group">
                      <div class="custom-control custom-checkbox small">
                        <input type="checkbox" class="custom-control-input" id="customCheck">
                          <asp:Label ID="lbl_tb" runat="server" ForeColor="Red"></asp:Label>
                          <br />
&nbsp;<label class="custom-control-label" for="customCheck">Remember Me</label>
                      </div>
                    </div>
                    
                      <asp:Button ID="btn_login" runat="server" class="btn btn-primary btn-user btn-block" Text="Login" OnClick="btn_login_Click" />
                    <hr>
                    <a href="index.html" class="btn btn-google btn-user btn-block">
                      <i class="fab fa-google fa-fw"></i> Login with Google
                    </a>
                    <a href="https://www.facebook.com/dialog/oauth?client_id=594051934729967&redirect_uri=https://localhost:44342/loginfb.aspx" class="btn btn-facebook btn-user btn-block">
                      <i class="fab fa-facebook-f fa-fw"></i> Login with Facebook
                    </a>
                  
                  <hr>
                  <div class="text-center">
                    <a class="small" href="forgot-password.html">Forgot Password?</a>
                  </div>
                      <div class="auto-style1">
                        <%--<a class="small">Create an Account!</a>--%>
                          <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Create an Account!</asp:LinkButton>
                          <br />
                          <asp:Literal ID="lit_tao" runat="server"></asp:Literal>
                      </div>
                  <div style="margin-top: 10px;text-align:center;">
                      <div class="form-group">
                      <asp:TextBox ID="tbx_creatuser" class="form-control form-control-user" runat="server" Visible="False"></asp:TextBox></div>
                      <div class="form-group">
                      <asp:TextBox ID="tbx_creatpass" class="form-control form-control-user" runat="server" Visible="False"></asp:TextBox></div>
                      <div class="form-group">
                      <asp:Label ID="lbl_tb1" runat="server" ForeColor="Red" Visible="False"></asp:Label></div>
                      <div class="form-group">
                      <asp:Button ID="btt_add" runat="server" class="btn btn-primary btn-user btn-block" Text="Tạo" OnClick="btt_add_Click" Visible="False" /></div>
                  </div>
                  </form>
                </div>
              </div>
            </div>
          </div>
        </div>

      </div>

    </div>

  </div>

  <!-- Bootstrap core JavaScript-->
  <script src="Assets/vendor/jquery/jquery.min.js"></script>
  <script src="Assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

  <!-- Core plugin JavaScript-->
  <script src="Assets/vendor/jquery-easing/jquery.easing.min.js"></script>

  <!-- Custom scripts for all pages-->
  <script src="Assets/js/sb-admin-2.min.js"></script>

    </div>



</body>
</html>

