<%@ Register TagPrefix="CC1" TagName="ThumbList" Src="ThumbList.ascx" %>
<%@ Register TagPrefix="CE" Assembly="CuteEditor" Namespace="CuteEditor" %>
<%@ Page Language="C#" EnableViewState="true" Inherits="CuteEditor.Dialogs.InsertGalleryFrame" %>
<script runat="server">
override protected void OnInit(EventArgs args)
{
	if(Context.Request.QueryString["IsFrame"]==null)
	{
		string FrameSrc="InsertGallery.Aspx?IsFrame=1&"+Request.ServerVariables["QUERY_STRING"];
		CuteEditor.CEU.WriteDialogOuterFrame(Context,"[[ImageGalleryByBrowsing]]",FrameSrc);
		Context.Response.End();
	}
	base.OnInit(args);
}
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>		
	    <title></title>
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.1)" />
		<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.1)" />
		<link href="Load.ashx?type=style&file=dialog.css" type="text/css" rel="stylesheet" />
		<!--[if IE]>
			<link href="Load.ashx?type=style&file=IE.css" type="text/css" rel="stylesheet" />
		<![endif]-->
		<script type="text/javascript" src="Load.ashx?type=dialogscript&file=DialogHead.js"></script>
		<script type="text/javascript">		
			function Check(t,n)
			{	
				if(n==1)
				{
					t.style.border="1px solid #00107B";t.style.background="#F1EEE7";
				}
				else
				{
					t.style.border="1px solid white";t.style.background="#FFFFFF";
				}
			}	
			function showTooltip(menucontents, obj, e){
			}
			function insert(src) {
			}
			function delayhidetip()
			{
			}
		</script>
		<style type="text/css">
			INPUT {border:black 1px solid; FONT-SIZE: 8pt; VERTICAL-ALIGN: middle; CURSOR: pointer; FONT-FAMILY: MS Sans Serif; margin-bottom:2px; }
			A:link { COLOR: #000099 }
			A:visited { COLOR: #000099 }
			A:active { COLOR: #000099 }
			A:hover { COLOR: darkred }
			#tooltipdiv{
			position:absolute;
			padding: 2px;
			border:1px solid black;
			font:menu;
			z-index:100;
			}
		</style>
	</head>
	<body style="overflow:auto">
		<form runat="server" enctype="multipart/form-data" id="Form1">
			<input type="hidden" runat="server" enableviewstate="false" id="hiddenAlert" name="hiddenAlert" />
			<fieldset>
				<legend>
					[[ImageGalleryByBrowsing]]
				</legend>
				<div>
					<asp:Table runat="server" Width="100%" id="FoldersAndFiles">
						<asp:TableRow>
							<asp:TableCell Width="20" HorizontalAlign="right">
								<asp:Image runat="server" ImageUrl="../Load.ashx?type=image&file=openfolder.gif" id="Image1"></asp:Image>
							</asp:TableCell>
							<asp:TableCell HorizontalAlign="left" ColumnSpan="2">
								<asp:Label runat="server" id="FolderDescription"></asp:Label>
							</asp:TableCell>
						</asp:TableRow>
					</asp:Table>
				</div>
				<table width="100%" cellspacing="2" cellpadding="0" border="0" align="center">
					<tr>
						<td class="normal" style="padding-left:3px">
							[[Size]]:
							<asp:DropDownList id="cbThumbSize" runat="server" AutoPostBack="True"></asp:DropDownList>
							[[Columns]]:
							<asp:DropDownList id="cbColumns" runat="server" AutoPostBack="True"></asp:DropDownList>
							[[Rows]]:
							<asp:DropDownList id="cbRows" runat="server" AutoPostBack="True"></asp:DropDownList>
							[[Type]]:
							<asp:DropDownList id="cbTypes" runat="server" AutoPostBack="True"></asp:DropDownList>
							<asp:DropDownList id="cbSorts" Runat="server" AutoPostBack="True"></asp:DropDownList>
						
						</td>
					</tr>
					<tr>
						<td class="normal" style="padding-left:3px">
							<CE:UploadSingleFile id="myuploadFile" runat="server"></CE:UploadSingleFile>
						</td>
					</tr>
					<tr>
						<td>
							<CC1:ThumbList id="ThumbList1" runat="server"></CC1:ThumbList>
						</td>
					</tr>
				</table>
			</fieldset>
			<p style="text-align:center">
				<input type="button" value="[[Cancel]]" onclick="cancel();" />
			</p>
		</form>
	</body>
	<script type="text/javascript" src="Load.ashx?type=dialogscript&file=DialogFoot.js"></script>
	<script type="text/javascript" src="Load.ashx?type=dialogscript&file=Dialog_InsertGallery.js"></script>
</html>
