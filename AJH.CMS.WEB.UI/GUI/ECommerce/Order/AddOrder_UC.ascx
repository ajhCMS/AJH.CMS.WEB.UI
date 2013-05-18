<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="AddOrder_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.GUI.ECommerce.Order.AddOrder_UC" %>
  <%--   <script src="http://ajax.microsoft.com/ajax/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#button1').click(function () {
                $('#hdColor').val($('#selID').val());
                //alert($('#hd1').val());
            });
        });
    </script>
    <select id="selID">
    <option value="1">Red</option>
    <option value="2">Green</option>
    <option value="3">Blue</option>
    </select>
    <input type="button" value="Click" id="button1" />
    <input type="hidden" id="hdColor" name="hdColor" />--%>
<asp:Button ID="btnAddtoChart" runat="server" Text="Add to cart"/>
