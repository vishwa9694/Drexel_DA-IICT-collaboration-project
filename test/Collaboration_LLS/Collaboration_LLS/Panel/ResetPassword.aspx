<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Collaboration_LLS.Panel.ResetPassword" %>
<!DOCTYPE html>
<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7 lt-ie10"> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8 lt-ie10"> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9 lt-ie10"> <![endif]-->
<!--[if IE 9]>         <html class="no-js lt-ie10"> <![endif]-->
<!--[if gt IE 9]><!--> <html class="no-js"> <!--<![endif]-->
    
<!-- Mirrored from proton.orangehilldev.com/login.html by HTTrack Website Copier/3.x [XR&CO'2014], Wed, 30 Jul 2014 17:51:59 GMT -->
<!-- Added by HTTrack --><meta http-equiv="content-type" content="text/html;charset=utf-8" /><!-- /Added by HTTrack -->
<head>
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        
        <title>Reset Password</title>
        <meta name="description" content="">
        <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
        <!-- Place favicon.ico and apple-touch-icon.png in the root directory -->

        <link rel="stylesheet" href="../App_Themes/Login/styles/92bc1fe4.bootstrap.css">
        

        <!-- Proton CSS: -->
        <link rel="stylesheet" href="../App_Themes/Login/styles/aaf5c053.proton.css">
        <link rel="stylesheet" href="../App_Themes/Login/styles/vendor/animate.css">

        <!-- adds CSS media query support to IE8   -->
        <!--[if lt IE 9]>
            <script src="//cdnjs.cloudflare.com/ajax/libs/html5shiv/3.6.2/html5shiv.js"></script>
            <script src="scripts/vendor/respond.min.js"></script>
        <![endif]-->

        <!-- Fonts CSS: -->
        <link rel="stylesheet" href="../App_Themes/Login/styles/6227bbe5.font-awesome.css" type="text/css" />
        <link rel="stylesheet" href="../App_Themes/Login/styles/40ff7bd7.font-titillium.css" type="text/css" />
        <!-- Common Scripts: -->
        <script>
            (function () {
                var js;
                if (typeof JSON !== 'undefined' && 'querySelector' in document && 'addEventListener' in window) {
                    js = '../App_Themes/Login/ajax.googleapis.com/ajax/libs/jquery/2.0.3/jquery.min.js';
                } else {
                    js = '../App_Themes/Login/ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js';
                }
                document.write('<script src="' + js + '"><\/script>');
            }());
        </script>
        <script src="../App_Themes/Login/scripts/vendor/modernizr.js"></script>
        <script src="../App_Themes/Login/scripts/vendor/jquery.cookie.js"></script>
    <link id="Link1" runat="server" rel="shortcut icon" href="../favicon.ico" type="image/x-icon"/>
        <link id="Link2" runat="server" rel="icon" href="../favicon.ico" type="image/ico" />
        
    </head>

    <body class="login-page" style="background-image: url('../App_Themes/Login/images/bckgrnd.jpg'); background-repeat:no-repeat; background-size:cover;">            
        <script>
            var theme = $.cookie('protonTheme') || 'default';
            $('body').removeClass(function (index, css) {
                return (css.match(/\btheme-\S+/g) || []).join(' ');
            });
            if (theme !== 'default') $('body').addClass(theme);
        </script>
        <!--[if lt IE 8]>
            <p class="browsehappy">You are using an <strong>outdated</strong> browser. Please <a href="http://browsehappy.com/">upgrade your browser</a> to improve your experience.</p>
        <![endif]-->
       
        <form id="Form1" role="form" runat="server">
            <section class="wrapper scrollable animated fadeInDown">
                <section class="panel panel-default">
                    <div class="panel-heading">
                        <div>
                            <img src="../App_Themes/Login/images/logo.png" alt="lls-logo" style="height:60px; width:60px;">
                            <h1>
                                <span class="title">
                                    The LLS
                                </span>
                                <span class="subtitle">
                                   The Leukemia & <br />Lymphoma Society
                                </span>
                            </h1>
                        </div>
                    </div>
                    <ul class="list-group">
                        <li class="list-group-item">
                            
                            <span class="welcome-text">
                                RESET PASSWORD
                            </span>
                            
                        </li>
                        <li class="list-group-item">
                            <span class="login-text">
                                A verification code has been sent to your email account. 
                            </span>
                            <div class="form-group">
                                <label id="Label1" for="code" runat="server">Verification code</label>
                                <input type="text" runat="server" name="txtcode" class="form-control input-lg" id="code" placeholder="Verification code" >
                            </div>
                            <div class="form-group">
                                <label id="Label2" for="newPassword" runat="server">New Password</label>
                                <input type="password" runat="server" name="newPassword" class="form-control input-lg" id="newPassword" placeholder="New Password" />
                            </div>
                            <div class="form-group">
                                <label id="Label3" for="confirmPassword" runat="server">Confirm Password</label>
                                <input type="password" runat="server" name="confirmPassword" class="form-control input-lg" id="confirmPassword" placeholder="Confirm Password" />
                            </div>
                        </li>
                    </ul>
                    <div class="panel-footer">
                        <asp:Button ID="btnReset" runat="server" class="btn btn-lg btn-success" Text="RESET YOUR PASSWORD" OnClick="btnReset_Click" />
                        <br>
                    </div>
                </section>
            </section>
        </form>
        <img src="../App_Themes/Login/images/logo_lls.png" alt="lls-logo" style="position:fixed; bottom:10px; left:10px; z-index:-1;">
    </body>

<!-- Mirrored from proton.orangehilldev.com/login.html by HTTrack Website Copier/3.x [XR&CO'2014], Wed, 30 Jul 2014 17:51:59 GMT -->
</html>