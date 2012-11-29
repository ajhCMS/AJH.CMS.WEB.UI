<%@ Page Language="C#" Inherits="CuteEditor.EditorUtilityPage" %>
<%@ Import Namespace="System.Xml"%>
<script runat="server">
override protected void OnInit(EventArgs args)
{
	if(Context.Request.QueryString["IsFrame"]==null)
	{
		string FrameSrc="Tag.Aspx?IsFrame=1&"+Request.ServerVariables["QUERY_STRING"];
		CuteEditor.CEU.WriteDialogOuterFrame(Context,"[[Tag]]",FrameSrc);
		Context.Response.End();
	}
	base.OnInit(args);
}
</script>
<script runat="server">
public bool IsTagPattern(string tagname,string pattern)
{
	if(pattern=="*")return true;
	tagname=tagname.ToLower();
	pattern=pattern.ToLower();
	if(tagname==pattern)return true;
	foreach(string str in pattern.Split(",;|/".ToCharArray()))
	{
		if(str=="*")return true;
		if(str==tagname)return true;
		if(str=="-"+tagname)return false;
	}
	return false;
}
public string GetTagDisplayName(string tagname)
{
	switch(tagname.ToLower())
	{
		case "img":
			return "[[Image]]";
		case "object":
			return "[[ActiveXObject]]";
		case "table":
		case "inserttable":
			return "[["+tagname+"]]";
		default:
			return tagname;
	}
}
bool nocancel=false;
</script>
<%
	if(Context.Request.QueryString["NoCancel"]=="True")
		nocancel=true;
		
	string tagName=Context.Request.QueryString["Tag"];
	string tabName=Context.Request.QueryString["Tab"];
	XmlDocument doc=new XmlDocument();
	doc.Load(Server.MapPath("tag.config"));
	string tabcontrol=null;
	string tabtext="";
%>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.1)" />
		<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.1)" />
		<link href="Load.ashx?type=style&file=dialog.css" type="text/css" rel="stylesheet" />
		<!--[if IE]>
			<link href="Load.ashx?type=style&file=IE.css" type="text/css" rel="stylesheet" />
		<![endif]-->
		<script type="text/javascript" src="Load.ashx?type=dialogscript&file=DialogHead.js"></script>
		<%if(nocancel){%>
		<script type="text/javascript">
	var OxO5217=["nocancel"]; top[OxO5217[0x0]]=true ;
		</script>
		<%}else{%>
		<script type="text/javascript">
	var OxO4a83=["nocancel"]; top[OxO4a83[0x0]]=false ;
		</script>
		<%}%>
		<script type="text/javascript" src="Load.ashx?type=dialogscript&file=Dialog_TagHead.js"></script>
		<title></title>
	</head>
	<body style="border-width:0px;padding-top:4px;padding-left:4px;padding-right:4px;;margin:0px;">
		<span style="font-size:10pt;font-family:Tahoma; font-weight:bold;TEXT-TRANSFORM: capitalize">
			<%=GetTagDisplayName(tagName)%>
		</span>
		<fieldset id="controlparent" style="width:100%; height:386px; padding-left:7px; padding-right:7px; padding-bottom:7px;">
			<legend align="right">
				<table>
					<tr>
						<td id="menu">
							<%
					int index=0;
					foreach(XmlElement xe in doc.DocumentElement.SelectNodes("add"))
					{
						string tab=xe.GetAttribute("tab");
						
						if(IsTagPattern(tagName,xe.GetAttribute("pattern")))
						{
							bool isactive=(index==0&&(tabName==null||tabName==""))||(string.Compare(tab,tabName,true)==0);
							if(isactive)
							{
								tabcontrol=xe.GetAttribute("control");
								tabtext=xe.GetAttribute("text");
							}
						%>
							<a class='<%=isactive?"ActiveTabNav":"TabNav"%>' tabindex="-1" href='<%=CuteEditor.EditorUtility.ReplaceParam(Request.RawUrl,"Tab",tab)%>'>
								<span style="white-space:nowrap;" >
									<%=xe.GetAttribute("text")%>
								</span>
							</a>
							<%
							index++;
						}
					}	
					%>
						</td>
					</tr>
				</table>
			</legend>
			<%
				if(tabcontrol!=null)
				{
					try
					{
						Control ctrl=LoadControl("Tag/"+tabcontrol);
						holder1.Controls.Add(ctrl);
					}
					catch
					{
						if(Context.Request.QueryString["_err"]=="2")
							throw;
						%>
			<iframe style="width:378;height:333" src='<%=Context.Request.RawUrl+"&_err=2"%>'>
			</iframe>
			<%
					}
				}
			%>
			<asp:PlaceHolder id="holder1" Runat="server"></asp:PlaceHolder>
		</fieldset>
		<div style="text-align:right;padding-top:8px;padding-bottom:2px;padding-right:12px;">
			<input type="button" id="btn_editinwin" value="[[EditHtml]]" />				
			&nbsp;&nbsp;&nbsp;
			<input type="button" id="btnok" value="[[OK]]" style="width:80px"/>&nbsp;
			<input type="button" id="btncc" value="[[Cancel]]" style="width:80px"/>

		</div>
	</body>
	<script type="text/javascript" src="Load.ashx?type=dialogscript&file=DialogFoot.js"></script>
	<script type="text/javascript" src="Load.ashx?type=dialogscript&file=Dialog_TagFoot.js"></script>
</html>
