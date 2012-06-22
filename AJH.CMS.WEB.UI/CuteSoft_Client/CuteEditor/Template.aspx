<%@ Page Language="C#" %>
<%@ OutputCache Duration="31536000" VaryByParam="None" Location="Client" %>
<%
if(Request.HttpMethod!="POST")
{
	string referrer=Request.QueryString["Referrer"];
	if(referrer==null)
	{
		referrer=Convert.ToString(Request.UrlReferrer);
	}
%>
<html>
	<head>
		<title>Untitled</title>
		<meta name="GENERATOR" content="CuteEditor">
		<base target="_blank"  href="<%=referrer%>" />
	</head>
	<body>
	
	</body>
</html>
<%
}
else
{

%>
<html>
	<head runat="server" id="Head1">
		<title>Posted Values</title>
		<style type="text/css">
		 body { font:normal 12px arial;} 
		 table { font:normal 12px arial; }
		</style>
	</head>
	<body>
		<table border="1" cellspacing="0" cellpadding="3" style="border-collapse:collapse;width:400px;">
			<tr style="color:white;background-color:steelblue">
				<td>Name</td>
				<td>Value</td>
			</tr>
			<%foreach(string key in Request.Form.AllKeys){%>
			<tr>
				<td><%=HttpUtility.HtmlEncode(key+"")%></td>
				<td><pre><%=HttpUtility.HtmlEncode(Request.Form[key]+"")%></pre>
				</td>
			</tr>
			<%}%>
		</table>
	</body>
</html>
<%
}
%>
