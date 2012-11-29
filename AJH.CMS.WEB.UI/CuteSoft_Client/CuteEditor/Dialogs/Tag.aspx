<%@ Import Namespace="System.Xml"%>
<%@ Page Language="C#" Inherits="CuteEditor.EditorUtilityPage" %>
<html>
	<head>
		<title>[[Tag]]</title>
		<script runat="server">
override protected void OnInit(EventArgs args)
{
	if(Context.Request.QueryString["Dialog"]=="Standard")
	{
	if(Context.Request.QueryString["IsFrame"]==null)
	{
		string FrameSrc="Tag.Aspx?IsFrame=1&"+Request.ServerVariables["QUERY_STRING"];
		CuteEditor.CEU.WriteDialogOuterFrame(Context,"[[Tag]]",FrameSrc);
		Context.Response.End();
	}
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
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.1)">
		<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.1)">
		<link href='Load.ashx?type=themecss&amp;file=dialog.css&amp;theme=[[_Theme_]]' type="text/css"	rel="stylesheet"> 
		<!--[if IE]><LINK 
rel=stylesheet type=text/css href="Load.ashx?type=style&amp;file=IE.css"><![endif]-->
			<script type="text/javascript" src="Load.ashx?type=dialogscript&verfix=1004&amp;file=DialogHead.js"></script>
			<%if(nocancel){%>
			<script type="text/javascript">
			var OxO2661=["nocancel"];top[OxO2661[0]]=true;
			</script>
			<%}else{%>
			<script type="text/javascript">
			var OxObac5=["nocancel"];top[OxObac5[0]]=false;
			</script>
			<%}%>
			<script type="text/javascript" src="Load.ashx?type=dialogscript&verfix=1004&amp;file=Dialog_TagHead.js"></script>
	</head>
	<body>
		<div id="ajaxdiv" style="padding:10px;margin:0;text-align:center; background:#eeeeee;height:100%;width:100%">
			<div class="tab-pane-control tab-pane" id="controlparent">
				<div class="tab-row">
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
					<h2 class='<%=isactive?"tab selected":"tab"%>'>
						<a tabindex="-1" href='<%=CuteEditor.EditorUtility.ReplaceParam(Request.RawUrl,"Tab",tab)%>'>
							<span style="WHITE-SPACE:nowrap">
								<%=xe.GetAttribute("text")%>
							</span>
						</a>
					</h2>
					<%
							index++;
						}
					}	
					%>
				</div>
				<div class="tab-page" style="WIDTH:450px">
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
					<iframe style="WIDTH:378px;HEIGHT:333px" src='<%=Context.Request.RawUrl+"&amp;_err=2"%>'>
					</iframe>
					<%
					}
				}
			%>
					<asp:PlaceHolder id="holder1" Runat="server"></asp:PlaceHolder>
				</div>
			</div>
			<br>
			<div id="container-bottom">
				<input type="button" id="btn_editinwin" class="formbutton" value="[[EditHtml]]">
				&nbsp;&nbsp;&nbsp; <input type="button" id="btnok" class="formbutton" value="[[OK]]" style="width:80px;">&nbsp;
				<input type="button" id="btncc" class="formbutton" value="[[Cancel]]" style="width:80px;">
			</div>
		</div>
		<script type="text/javascript" src="Load.ashx?type=dialogscript&verfix=1004&amp;file=DialogFoot.js"></script>
		<script type="text/javascript" src="Load.ashx?type=dialogscript&verfix=1004&amp;file=Dialog_TagFoot.js"></script>
	</body>
</HTML>
