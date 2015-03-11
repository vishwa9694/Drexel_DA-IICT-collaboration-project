<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LockScreen.aspx.cs" Inherits="Collaboration_LLS.Panel.LockScreen" %>

<html lang="en">
<!DOCTYPE html>
<!-- Mirrored from bucketadmin.themebucket.net/lock_screen.html by HTTrack Website Copier/3.x [XR&CO'2014], Thu, 31 Jul 2014 11:14:14 GMT -->
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">
    <meta name="keyword" content="FlatLab, Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">
    <link rel="shortcut icon" href="img/favicon.html">

    <title>Lock Screen</title>

    <!-- Bootstrap core CSS -->
    <link href="../App_Themes/Home/bs3/css/bootstrap.min.css" rel="stylesheet">
    <link href="../App_Themes/Home/css/bootstrap-reset.css" rel="stylesheet">
    <!--external css-->
    <link href="../App_Themes/Home/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <!-- Custom styles for this template -->
    <link href="../App_Themes/Home/css/stylec4ca.css?1" rel="stylesheet">
    <link href="../App_Themes/Home/css/style-responsive.css" rel="stylesheet" />

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 tooltipss and media queries -->
    <!--[if lt IE 9]>
    <script src="js/html5shiv.js"></script>
    <script src="js/respond.min.js"></script>
    <![endif]-->
</head>

<body class="lock-screen" onload="startTime()">

    <div class="lock-wrapper">

        <div id="time"></div>


        <div class="lock-box text-center">
            <div class="lock-name">
                <asp:Label ID="lblUserName" runat="server"></asp:Label></div>
            <img src="../App_Themes/Home/images/lock_thumb.jpg" id="imgUser" runat="server" alt="lock avatar" />
            <div class="lock-pwd">
                <form role="form" class="form-inline" runat="server">
                    <div class="form-group">
                        <%-- <input type="password" placeholder="Hello.." disabled="disabled" style="color:#1fb5ad;" value="" class="form-control lock-input ">--%>
                        <asp:Label ID="lblHello" runat="server" ForeColor="#1fb5ad">Let's Get into it..</asp:Label>
                        <%--<button class="btn" type="submit" id="btnReLogin" style="padding-left:20px; background:#fff; height:40px;" onclick=" runat="server">
                            <i class="fa fa-arrow-right"></i>
                        </button>
                        --%>
                        <a href="login.aspx" style="padding-left:20px; background:#fff; height:40px;"><i class="fa fa-arrow-right"></i></a>
                    </div>
                </form>

            </div>

        </div>
    </div>
    <script>
        function startTime() {
            var today = new Date();
            var h = today.getHours();
            var m = today.getMinutes();
            var s = today.getSeconds();
            // add a zero in front of numbers<10
            m = checkTime(m);
            s = checkTime(s);
            document.getElementById('time').innerHTML = h + ":" + m + ":" + s;
            t = setTimeout(function () { startTime() }, 500);
        }

        function checkTime(i) {
            if (i < 10) {
                i = "0" + i;
            }
            return i;
        }
    </script>
</body>

<!-- Mirrored from bucketadmin.themebucket.net/lock_screen.html by HTTrack Website Copier/3.x [XR&CO'2014], Thu, 31 Jul 2014 11:14:15 GMT -->
</html>
