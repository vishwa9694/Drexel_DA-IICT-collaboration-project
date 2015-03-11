<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="Collaboration_LLS.Panel.WebForm1" MasterPageFile="~/Panel/PanelAdmin.Master"  %>

<asp:content ID="Content1" contentplaceholderid="cpAdmin" runat="server">
    
    <div class="container">
        <input type="text" id="message" />
        <input type="button" id="sendmessage" value="Send" />
        <input type="hidden" id="displayname" />
        <ul id="discussion">
        </ul>
    </div>
    
    <link rel="Stylesheet" href="Styles/Site.css" />
    <script src="Scripts/jquery-1.7.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
   <script src="Scripts/jquery.signalR-1.1.4.js" type="text/javascript"></script>
     <script src="Scripts/jquery-1.7.1.intellisense.js" type="text/javascript"></script> 
     <!-- <script src="Scripts/json2.js" type="text/javascript"></script> -->
    <script src="Scripts/jquery.signalR-1.1.4.min.js" type="text/javascript"></script>
    <script src="signalr/hubs" type="text/javascript"></script>
    <script type="text/javascript">

       
            // Declare a proxy to reference the hub. 
            var chat = $.connection.ChatHub;
            // Create a function that the hub can call to broadcast messages.
            chat.client.broadcastMessage = function (message) {
                // Html encode display name and message. 
               // var encodedName = $('<div />').text(name).html();
                var encodedMsg = $('<div />').text(message).html();
                // Add the message to the page. 
                $('#discussion').append('<li>'+ encodedMsg + '</li>');
            };
            // Get the user name and store it to prepend to messages.
          //  $('#displayname').val(prompt('Enter your name:', ''));
            // Set initial focus to message input box.  
            $('#message').focus();
            // Start the connection.
            $.connection.hub.start().done(function () {
                $('#sendmessage').click(function () {
                    // Call the Send method on the hub. 
                    chat.server.send('Aditi', $('#message').val());
                    // Clear text box and reset focus for next comment. 
                    $('#message').val('').focus();
                });
            });
       
    </script>
    
                  
                  </asp:content>
