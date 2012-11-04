<%@ Page Language="C#" EnableViewState="true" Inherits="CuteEditor.Dialogs.InsertGalleryFrame" %>
<%@ Register TagPrefix="CE" Assembly="CuteEditor" Namespace="CuteEditor" %>
<%@ Register TagPrefix="CC1" TagName="ThumbList" Src="ThumbList.ascx" %>
<script runat="server">
override protected void OnInit(EventArgs args)
{
	if(Context.Request.QueryString["Dialog"]=="Standard")
	{
		if(Context.Request.QueryString["IsFrame"]==null)
		{
			string FrameSrc="InsertGallery.Aspx?IsFrame=1&"+Request.ServerVariables["QUERY_STRING"];
			CuteEditor.CEU.WriteDialogOuterFrame(Context,"[[ImageGalleryByBrowsing]]",FrameSrc);
			Context.Response.End();
		}
	}
		base.OnInit(args);
}
</script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>[[ImageGalleryByBrowsing]]</title>
		<link href='Load.ashx?type=themecss&file=dialog.css&theme=[[_Theme_]]' type="text/css" rel="stylesheet" />
		<!--[if IE]>
			<link href="Load.ashx?type=style&file=IE.css" type="text/css" rel="stylesheet" />
		<![endif]-->
		<script type="text/javascript" src="Load.ashx?type=dialogscript&verfix=1006&file=DialogHead.js"></script>
		<script type="text/javascript" src="Load.ashx?type=dialogscript&verfix=1006&amp;file=Dialog_gallery_spring.js"></script>
		<script type="text/javascript">		
			function Check(t,n)
			{	
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
			#dropdowncell { padding:0 0 5px 10px;vertical-align:middle;}
			#FoldersAndFiles{table-layout:auto;margin 5px 0 0 5px; }
			A:link { COLOR: #000099 }	
			A:visited { COLOR: #000099 }	
			A:active { COLOR: #000099 }	
			A:hover { COLOR: darkred }
			#tooltipdiv { border: black 1px solid; padding: 2px; z-index: 100; font: menu; position: absolute }	
			#ThumbList1_MyList IMG { border:solid 2px #cccccc;}	
			IMG.spring_image { BEHAVIOR: url(htc.htc); CURSOR: pointer; -moz-binding: url("xbl.xml#MyComponent") }	
			IMG.spring_image_popup { border:solid 2px #ff0000; DISPLAY: none; Z-INDEX: 99999; LEFT: 0px; FLOAT: none; MARGIN: 0px; CURSOR: pointer; POSITION: absolute; TOP: 0px }	
		</style>
	</head>
	<body>
		<form runat="server" enctype="multipart/form-data" id="Form1">
			<div id="ajaxdiv" style="overflow:auto;height:560px">
			<input type="hidden" runat="server" enableviewstate="false" id="hiddenAlert" name="hiddenAlert">
			<table width="100%" cellspacing="0" cellpadding="0" border="0">
				<tr>
					<td valign="top" style="height:100px">
						<asp:table runat="server" id="FoldersAndFiles">
							<asp:tablerow>
								<asp:tablecell Width="20" HorizontalAlign="right" Wrap="False">
									<asp:image runat="server" ImageUrl="../Load.ashx?type=image&file=openfolder.gif" id="Image1"></asp:image>
								</asp:tablecell>
								<asp:tablecell HorizontalAlign="left" ColumnSpan="2">
									<asp:label runat="server" id="FolderDescription"></asp:label>
									<asp:dropdownlist Runat="server" ID="FolderList" Visible="False" />
								</asp:tablecell>
							</asp:tablerow>
						</asp:table>
					</td>
				</tr>
				<tr>
					<td id="dropdowncell">
						[[Size]]:
						<asp:dropdownlist id="cbThumbSize" runat="server" AutoPostBack="True"></asp:dropdownlist>
						[[Columns]]:
						<asp:dropdownlist id="cbColumns" runat="server" AutoPostBack="True"></asp:dropdownlist>
						[[Rows]]:
						<asp:dropdownlist id="cbRows" runat="server" AutoPostBack="True"></asp:dropdownlist>
						[[Type]]:
						<asp:dropdownlist id="cbTypes" runat="server" AutoPostBack="True"></asp:dropdownlist>
						<asp:dropdownlist id="cbSorts" Runat="server" AutoPostBack="True"></asp:dropdownlist>
					</td>
				</tr>
				<tr>
					<td>
						<cc1:thumblist id="ThumbList1" runat="server"></cc1:thumblist>
						<br>
					</td>
				</tr>
				<tr>
					<td>
						<table width="90%">
							<tr>
								<td id="uploader">
									<ce:uploader id="myuploadFile" runat="server"></ce:uploader>
								</td>
								<td align="center">
									<input type="button" value="[[Cancel]]" class="formbutton" onclick="cancel();">
								</td>							
							</tr>
						</table>
					</td>
				</tr>
			</table>
			</div>
		</form>
		<script type="text/javascript" src="Load.ashx?type=dialogscript&verfix=1006&amp;file=DialogFoot.js"></script>
		<script type="text/javascript" src="Load.ashx?type=dialogscript&verfix=1006&amp;file=Dialog_InsertGallery.js"></script>
	</body>
	<script runat="server">
		
	protected override void InitOfType()
	{
		this.Context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
		string folder=secset.ImageGalleryPath;
		if(folder==null||folder=="")
		{
			Response.Write("ImageGalleryPath not set!");
			Response.End();
		}

		string[] flist=folder.Split('|');
		if(flist.Length<2)
		{
			fs.VirtualRoot=CuteEditor.EditorUtility.ProcessWebPath(Context,null,folder).TrimEnd('/')+"/";
			return;
		}
		
		_multiplefolderlist=flist;
		
		//just set display to none, maybe javascript need it.
		FolderDescription.Style["display"]="none";
		
		int selectedIndex=0;
		for(int i=0;i<flist.Length;i++)
		{
			flist[i]=CuteEditor.EditorUtility.ProcessWebPath(Context,null,flist[i]).TrimEnd('/')+"/";
			if(flist[i]==Request.QueryString["SelectedRoot"])
			{
				selectedIndex=i;
			}
		}
		
		FolderList.DataSource=flist;
		FolderList.DataBind();
		FolderList.Visible=true;
		FolderList.AutoPostBack=true;
		FolderList.SelectedIndexChanged+=new EventHandler(FolderList_SelectedIndexChanged);
		FolderList.SelectedIndex=selectedIndex;
		fs.VirtualRoot=flist[selectedIndex];
	}
	
	string[] _multiplefolderlist;

	void FolderList_SelectedIndexChanged(object sender,EventArgs args)
	{
		for(int i=0;i<FolderList.Items.Count;i++)
		{
			FolderList.Items[i].Text=FolderList.Items[i].Value;
		}
		fs.VirtualRoot=_multiplefolderlist[FolderList.SelectedIndex];
		
		string url=CuteEditor.EditorUtility.ReplaceParam(Request.RawUrl,"SelectedRoot",fs.VirtualRoot);
		url=CuteEditor.EditorUtility.ReplaceParam(url,"C_GP","/");
		Response.Redirect(url);
	}
	protected override void OnPreRender(EventArgs args)
	{
		base.OnPreRender(args);
		if(FolderList.Visible)
		{
			FolderList.SelectedItem.Text=FolderDescription.Text;
		}
	}
	protected override bool HideDirectoryItem(CuteEditor.Impl.DirectoryItem item)
	{
		//write custom code to filter the directories
		return base.HideDirectoryItem(item);
	}
	protected override bool HideFileItem(CuteEditor.Impl.FileItem item)
	{
		//write custom code to filter the files
		return base.HideFileItem(item);
	}
	</script>
</html>
