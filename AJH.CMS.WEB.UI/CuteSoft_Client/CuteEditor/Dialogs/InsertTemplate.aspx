<%@ Page Language="C#" Inherits="CuteEditor.Dialogs.TemplateBrowserPage" %>
<%@ Register TagPrefix="CE" Assembly="CuteEditor" Namespace="CuteEditor" %>
<script runat="server">
override protected void OnInit(EventArgs args)
{
	if(Context.Request.QueryString["Dialog"]=="Standard")
	{
	if(Context.Request.QueryString["IsFrame"]==null)
	{
		string FrameSrc="InsertTemplate.Aspx?IsFrame=1&"+Request.ServerVariables["QUERY_STRING"];
		CuteEditor.CEU.WriteDialogOuterFrame(Context,"[[InsertTemplate]]",FrameSrc);
		Context.Response.End();
	}
	}
	base.OnInit(args);
}
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.1)" />
		<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.1)" />
		<link href='Load.ashx?type=themecss&file=dialog.css&theme=[[_Theme_]]' type="text/css"
			rel="stylesheet" />
		<!--[if IE]>
			<link href="Load.ashx?type=style&file=IE.css" type="text/css" rel="stylesheet" />
		<![endif]-->
		<script type="text/javascript" src="Load.ashx?type=dialogscript&verfix=1006&file=DialogHead.js"></script>
		<script type="text/javascript">
		function PostBackAction()
		{
			<%=Page.ClientScript.GetPostBackEventReference(hiddenAction,"")%>
		}
		</script>
		<title>[[InsertTemplate]]</title>
		<style type="text/css">
			#browse_Frame{border-top:1px solid #a0a0a0;border-left:1px solid #a0a0a0;border-bottom:1px solid #ffffff;border-right:1px solid #ffffff;width:260px;height:240px;overflow:auto;background-color:white;}
			#divouter{border-top:1px solid #a0a0a0;border-left:1px solid #a0a0a0;border-bottom:1px solid #ffffff;border-right:1px solid #ffffff;padding:0;vertical-align: top; overflow: auto; width:365px;height:240px; background-color:white;}
			#divpreview{background-color:white;height:100%;width:100%;}
			#inp_color_preview{margin-bottom:-3px}
			.row {}
			.cb { vertical-align: middle }
			.itemimg { vertical-align: middle }
			.editimg { vertical-align: middle }
			.cell1 { vertical-align: middle }
			.cell2 { 
				vertical-align: middle;
				white-space: pre-wrap; /* css-3 */
				white-space: -moz-pre-wrap; /* Mozilla, since 1999 */
				white-space: -pre-wrap; /* Opera 4-6 */
				white-space: -o-pre-wrap; /* Opera 7 */
				word-wrap: break-word; /* Internet Explorer 5.5+ */
				overflow: hidden;
				break-word: break-all;
			}
			.cell3 {vertical-align: middle; text-align:right}
			.image-align{vertical-align:middle;margin:3px;}			
		#framepreview {
			width: 100%;
			height: 100%;
			overflow:auto;
			text-align: left;
			vertical-align: top;
			padding: 0;
			margin: 0;
			background-color: white;
		}
			#FolderList {
				/* for Firefox, Opera and others: */
				max-width: 220px; 
			}
			html, body,#ajaxdiv,#Form1 {height: 100%;}
		</style>
		<!--[if gte IE 5]>
		<style type="text/css">
		#FolderList {
				/* For Internet Explorer: */
			width: expression(Math.min(parseInt(this.offsetWidth), 220 ) + "px"); 
		}
		</style>
		<![endif]-->
	</head>
	<body>
		<form runat="server" enctype="multipart/form-data" id="Form1">
			<div runat=server id="ajaxdiv">
			<!-- start hidden -->
<input type="hidden" runat="server" id="hiddenDirectory" name="hiddenDirectory" />
<input type="hidden" runat="server" id="hiddenHTML" name="hiddenDirectory" /> 
<input type="hidden" runat="server" id="hiddenFile" name="hiddenFile" />
<input type="hidden" runat="server" enableviewstate="false" id="hiddenAlert" name="hiddenAlert" />
<input type="hidden" runat="server" enableviewstate="false" id="hiddenAction" onserverchange="hiddenAction_ServerChange" name="hiddenAction" /> 
<input type="hidden" runat="server" enableviewstate="false" id="hiddenActionData" name="hiddenActionData" />
			<!-- end hidden -->
			<table border="0" cellspacing="0" cellpadding="0" width="100%">
				<tr>
					<td style="width:20px">
						<asp:Image id="Image1" Runat="server" ImageUrl="../Load.ashx?type=image&file=openfolder.gif"></asp:Image>
					</td>
					<td style="width:240px" class="normal">
						<asp:Label Runat="server" id="FolderDescription"></asp:Label>
						<asp:dropdownlist Runat="server" ID="FolderList" Visible="False" />
					</td>
					<td>
<asp:ImageButton id="CreateDir" BorderWidth="1" Runat="server" AlternateText="[[Createdirectory]]" ImageUrl="../Load.ashx?type=image&file=newfolder.gif" OnClick="CreateDir_Click" />
<asp:ImageButton id="Copy" BorderWidth="1" Runat="server" AlternateText="[[Copyfiles]]" ImageUrl="../Load.ashx?type=image&file=Copy.gif" OnClick="Copy_Click" />
<asp:ImageButton id="Move" BorderWidth="1" Runat="server" AlternateText="[[Movefiles]]" ImageUrl="../Load.ashx?type=image&file=move.gif" OnClick="Move_Click" />
<img id="btn_zoom_in" src="../Load.ashx?type=image&file=zoom_in.gif" onclick="Zoom_In();" title="[[ZoomIn]]" class="cursor dialogButton" /> 
<img id="btn_zoom_out" src="../Load.ashx?type=image&file=zoom_out.gif" onclick="Zoom_Out();" title="[[ZoomOut]]" class="cursor dialogButton" /> 
<img id="btn_Actualsize" src="../Load.ashx?type=image&file=Actualsize.gif" onclick="Actualsize();" title="[[ActualSize]]" class="cursor dialogButton" />
<asp:ImageButton id="NewTemplate" BorderWidth="1" Runat="server" AlternateText="[[NewTemplate]]" ImageUrl="../Load.ashx?type=image&file=newtemplate.gif" OnClick="NewTemplate_Click" />
					</td>
				</tr>
			</table>
			<table border="0" cellspacing="0" cellpadding="2" width="100%">
				<tr>					
					<td style="white-space:nowrap; width:260px">
						<div id="browse_Frame">

<asp:table id="FoldersAndFiles" Runat="server" CellSpacing="1" CellPadding="0" Width="100%" CssClass="sortable">
	<asp:tablerow BackColor="#f0f0f0">
		<asp:tableheadercell Width="17px">
			<asp:imagebutton id="Delete" Runat="server" AlternateText="[[Deletefiles]]" ImageUrl="../Load.ashx?type=image&file=s_cut.gif" OnClick="Delete_Click" />
		</asp:tableheadercell>
		<asp:tableheadercell Width="20px">
			<asp:imagebutton id="DoRefresh" Runat="server" AlternateText="[[Refresh]]" ImageUrl="../Load.ashx?type=image&file=s_refresh.gif" OnClick="DoRefresh_Click" />
		</asp:tableheadercell>
		<asp:tableheadercell id="name_Cell" Wrap="True" Width="115px" CssClass="filelistHeadCol" Font-Bold="False">[[Name]]</asp:tableheadercell>
		<asp:tableheadercell id="size_Cell" Width="52px" CssClass="filelistHeadCol" Wrap="False" Font-Bold="False">[[Size]]</asp:tableheadercell>
		<asp:tableheadercell id="op_Cell" Width="16px">&nbsp;</asp:tableheadercell>
		<asp:tableheadercell id="op_Cell2" Width="16px">&nbsp;</asp:tableheadercell>
	</asp:tablerow>
</asp:table>
						</div>
					</td>
					<td>
						<div id="divouter">
<iframe id="framepreview" frameborder="0" src="../template.aspx" scrolling="auto" frameborder="0"></iframe>
						</div>
					</td>
				</tr>
			</table>
			<br />
			<table border="0" cellspacing="2" cellpadding="0" width="98%">
				<tr>
					<td>
						<input type="hidden" id="TargetUrl" size="40" name="TargetUrl" runat="server" />
						<fieldset id="fieldsetUpload">
							<legend>
							[[Upload]] ([[MaxFileSizeAllowed]]
							<%= CuteEditor.Impl.FileStorage.FormatSize(secset.MaxTemplateSize * 1024)%>
							)</legend>
							<div id="uploader">
								<ce:uploader id="InputFile" runat="server"></ce:uploader>
							</div>
							<%if(secset.MaxTemplateFolderSize>0){%>
							<table>
								<tr>
									<td><img class="image-align" alt="" src="../Load.ashx?type=image&file=colorfocus.gif" /></td>
									<td style="margin:0;padding:0">[[MaxFolderSizeAllowed]]: <%= CuteEditor.Impl.FileStorage.FormatSize(secset.MaxTemplateFolderSize * 1024)%>.</td>
									<td>&nbsp; [[Used]]: <%= CuteEditor.Impl.FileStorage.FormatSize(RootDirectorySize) %></td>
									<td>
										<div class="progress-container">
											<div id="progress_bar" style="width:<%= GetUsedPercent() %>%"></div>
										</div>
									</td>
								</tr>
							</table>
							<%}%>
						</fieldset>
						<div style="padding-top:15px;" align="center">
<input class="formbutton" type="button" value="[[Insert]]" onclick="do_insert()" />&nbsp;&nbsp;&nbsp;
<input class="formbutton" type="button" value="[[Cancel]]" onclick="do_Close()" />
						</div>
					</td>
				</tr>
			</table>
		</div></form>
		<script runat="server">
	protected override void InitOfType()
	{
		string folder=secset.TemplateGalleryPath;
		string[] flist=folder.Split('|');
		if(flist.Length<2)
		{
			fs.VirtualRoot=CuteEditor.EditorUtility.ProcessWebPath(Context,null,folder).TrimEnd('/')+"/";
			return;
		}
		
		_multiplefolderlist=flist;
		
		//just set display to none, maybe javascript need it.
		FolderDescription.Style["display"]="none";
		
		for(int i=0;i<flist.Length;i++)
		{
			flist[i]=CuteEditor.EditorUtility.ProcessWebPath(Context,null,flist[i]).TrimEnd('/')+"/";
		}
		
		FolderList.DataSource=flist;
		FolderList.DataBind();
		FolderList.Visible=true;
		FolderList.AutoPostBack=true;
		FolderList.SelectedIndexChanged+=new EventHandler(FolderList_SelectedIndexChanged);
		Page.Load+=new EventHandler(Page_Load_ForFolderList);
		
		fs.VirtualRoot=flist[0];
	}
	
	string[] _multiplefolderlist;
	void Page_Load_ForFolderList(object sender,EventArgs args)
	{
		fs.VirtualRoot=_multiplefolderlist[FolderList.SelectedIndex];
	}
	void FolderList_SelectedIndexChanged(object sender,EventArgs args)
	{
		for(int i=0;i<FolderList.Items.Count;i++)
		{
			FolderList.Items[i].Text=FolderList.Items[i].Value;
		}
		fs.VirtualRoot=_multiplefolderlist[FolderList.SelectedIndex];
		CurrentDirectory=fs.VirtualRoot;
		Refresh();
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
	
    protected override void GetFiles(ArrayList files)
    {		
		foreach (string ext in secset.TemplateFilters)
		{
			if (ext == null || ext.Length == 0) continue;
			
			foreach(CuteEditor.Impl.FileItem item in fs.GetFileItems(CurrentDirectory, secset.FileNamePrefix + "*" + ext))
			{
				string itemext=System.IO.Path.GetExtension(item.Path).ToLower();
				if(ext.ToLower().EndsWith(itemext))
					files.Add(item);
			}
		}
    }
    protected override bool AllowFileName(string filename)
    {
		filename = filename.ToLower();
		foreach (string ext in secset.TemplateFilters)
		{
			if (ext == null || ext.Length == 0) continue;
			if(filename.EndsWith(ext.ToLower()))
				return true;
		}
		return false;
    }
    protected override string CheckUploadData(ref byte[] data)
    {
		if(secset.MaxTemplateFolderSize>0)
		{
			if (RootDirectorySize >= secset.MaxTemplateFolderSize * 1024)
				return "Template folder size exceeds the limit: "+ CuteEditor.Impl.FileStorage.FormatSize(secset.MaxTemplateFolderSize * 1024);
		}
		
		if (data.Length >= secset.MaxTemplateSize * 1024)
            return "Template size exceeds "+CuteEditor.Impl.FileStorage.FormatSize(secset.MaxTemplateSize * 1024)+" limit: "+ CuteEditor.Impl.FileStorage.FormatSize(data.Length);
        return null;
    }
    
    protected int GetUsedPercent()
	{
	int w = Convert.ToInt32(100*RootDirectorySize/(secset.MaxImageFolderSize * 1024));
	if(w<1)
		w=1;
		
	if(w>100)
		w=100;
		
	return w;      
	}
		</script>
	</body>
	<script type="text/javascript" src="Load.ashx?type=dialogscript&verfix=1006&file=DialogFoot.js"></script>
	<script type="text/javascript" src="Load.ashx?type=dialogscript&verfix=1006&file=Dialog_InsertTemplate.js"></script>
</html>
