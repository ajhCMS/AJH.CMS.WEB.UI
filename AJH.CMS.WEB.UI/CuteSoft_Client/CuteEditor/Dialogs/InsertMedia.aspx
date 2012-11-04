<%@ Page Language="C#" Inherits="CuteEditor.Dialogs.FileBrowserPage" %>
<%@ Register TagPrefix="CE" Assembly="CuteEditor" Namespace="CuteEditor" %>
<script runat="server">
override protected void OnInit(EventArgs args)
{
	if(Context.Request.QueryString["Dialog"]=="Standard")
	{
		if(Context.Request.QueryString["IsFrame"]==null)
		{
			string FrameSrc="InsertMedia.Aspx?IsFrame=1&"+Request.ServerVariables["QUERY_STRING"];
			CuteEditor.CEU.WriteDialogOuterFrame(Context,"[[InsertMedia]]",FrameSrc);
			Context.Response.End();
		}
	}
	base.OnInit(args);
	
	InputFile.ValidateOption.MaxSizeKB=secset.MaxMediaSize;
	InputFile.ValidateOption.AllowedFileExtensions=string.Join(",",(string[])secset.MediaFilters.ToArray(typeof(string)));
}
</script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>[[InsertMedia]]</title>
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
		<style type="text/css">
			#browse_Frame{border-top:1px solid #a0a0a0;border-left:1px solid #a0a0a0;border-bottom:1px solid #ffffff;border-right:1px solid #ffffff;width:250px;height:240px;overflow:auto;background-color:white;}
			#divouter{border-top:1px solid #a0a0a0;border-left:1px solid #a0a0a0;border-bottom:1px solid #ffffff;border-right:1px solid #ffffff;vertical-align: top; overflow: auto; width:290px;height:240px; background-color:white;text-align:center}
			#divpreview{background-color:white;height:100%;width:100%;}
			#bordercolor_Preview{margin-bottom:-3px}
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
			html, body,#ajaxdiv,#Form1 {height: 100%;}
			.cell3 {vertical-align: middle; text-align:right}
			#FolderList {
				/* for Firefox, Opera and others: */
				max-width: 220px; 
			}
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
			<div runat="server" id="ajaxdiv">
				<!-- start hidden -->
<input type="hidden" runat="server" id="hiddenDirectory" /> 
<input type="hidden" runat="server" id="hiddenFile" />
<input type="hidden" runat="server" enableviewstate="false" id="hiddenAlert" /> 
<input type="hidden" runat="server" enableviewstate="false" id="hiddenAction" onserverchange="hiddenAction_ServerChange" />
<input type="hidden" runat="server" enableviewstate="false" id="hiddenActionData" />
				<!-- end hidden -->
				<table border="0" cellspacing="0" cellpadding="0" width="100%">
					<tr>
						<td style="width:20px">
							<asp:image id="Image1" Runat="server" ImageUrl="../Load.ashx?type=image&file=openfolder.gif"></asp:image>
						</td>
						<td style="width:240px" class="normal">
							<asp:label Runat="server" id="FolderDescription"></asp:label>
							<asp:dropdownlist Runat="server" ID="FolderList" Visible="False" />
						</td>
						<td>
<asp:imagebutton id="CreateDir" BorderWidth="1" Runat="server" AlternateText="[[Createdirectory]]" ImageUrl="../Load.ashx?type=image&file=newfolder.gif" OnClick="CreateDir_Click" />
<asp:imagebutton id="Copy" BorderWidth="1" Runat="server" AlternateText="[[Copyfiles]]" ImageUrl="../Load.ashx?type=image&file=Copy.gif" OnClick="Copy_Click" />
<asp:imagebutton id="Move" BorderWidth="1" Runat="server" AlternateText="[[Movefiles]]" ImageUrl="../Load.ashx?type=image&file=move.gif" OnClick="Move_Click" />
<img id="btn_zoom_in" src="../Load.ashx?type=image&file=zoom_in.gif" onclick="Zoom_In();" title="[[ZoomIn]]" class="cursor dialogButton" /> 
<img id="btn_zoom_out" src="../Load.ashx?type=image&file=zoom_out.gif" onclick="Zoom_Out();" title="[[ZoomOut]]" class="cursor dialogButton" /> 
<img id="btn_Actualsize" src="../Load.ashx?type=image&file=Actualsize.gif" onclick="Actualsize();" title="[[ActualSize]]" class="cursor dialogButton" />
						</td>
					</tr>
				</table>
				<table border="0" cellspacing="0" cellpadding="0" width="100%" style="margin:2px 0 2px 0;">
				<tr>
					<td style="white-space:nowrap; width:250px">
						<div id="browse_Frame">
<asp:table id="FoldersAndFiles" Runat="server" CellSpacing="1" CellPadding="0" Width="100%" CssClass="sortable">
	<asp:tablerow BackColor="#f0f0f0">
		<asp:tableheadercell Width="17px">
			<asp:imagebutton id="Delete" Runat="server" AlternateText="[[Deletefiles]]" ImageUrl="../Load.ashx?type=image&file=s_cut.gif" OnClick="Delete_Click" />
		</asp:tableheadercell>
		<asp:tableheadercell Width="20px">
			<asp:imagebutton id="DoRefresh" Runat="server" AlternateText="[[Refresh]]" ImageUrl="../Load.ashx?type=image&file=s_refresh.gif" OnClick="DoRefresh_Click" />
		</asp:tableheadercell>
		<asp:tableheadercell id="name_Cell" Wrap="True" Width="110px" CssClass="filelistHeadCol" Font-Bold="False">[[Name]]</asp:tableheadercell>
		<asp:tableheadercell id="size_Cell" Width="52px" CssClass="filelistHeadCol" Wrap="False" Font-Bold="False">[[Size]]</asp:tableheadercell>
		<asp:tableheadercell id="op_Cell" Width="16px">&nbsp;</asp:tableheadercell>
	</asp:tablerow>
</asp:table>
						</div>
					</td>
					<td>						
						<div id="divouter">
							<div id="divpreview">
								&nbsp;
							</div>
						</div>
					</td>					
				</tr>
			</table>
			<table border="0" cellspacing="0" cellpadding="0" width="97%">
				<tr>
					<td style="vertical-align:top">
						<fieldset>
							<legend>[[Properties]]</legend>
							<div style="padding:3px;">
							<table border="0" cellpadding="1" cellspacing="0" class="normal">
								<tr>
									<td style="width:100px">
										[[Width]]:</td>
									<td>
<input type="text" name="Width" id="Width" style="width: 80px;" onchange="do_preview()" onkeypress="return CancelEventIfNotDigit()" value="200" /></td>
								</tr>
								<tr>
									<td>
										[[Height]]:</td>
									<td>
<input type="text" name="Height" id="Height" style="width: 80px;" onchange="do_preview()" onkeypress="return CancelEventIfNotDigit()" value="200" /></td>
								</tr>
								<tr>
									<td>
										[[AutoStart]]:</td>
									<td>
<input type="checkbox" name="AutoStart" onchange="do_preview()" onpropertychange="do_preview()" id="AutoStart" checked="checked" value="AutoStart" /></td>
								</tr>
								<tr>
									<td style="height: 24px">
										[[ShowControls]]:</td>
									<td style="height: 24px">
<input type="checkbox" name="ShowControls" onchange="do_preview()" onpropertychange="do_preview()" id="ShowControls" checked="checked" value="ShowControls" /></td>
								</tr>
								<tr>
									<td>[[ShowStatusBar]]:</td>
									<td>
<input type="checkbox" name="ShowStatusBar" onchange="do_preview()" onpropertychange="do_preview()" id="ShowStatusBar" value="ShowStatusBar" /></td>
								</tr>
								<tr>
									<td>[[WindowlessVideo]]:</td>
									<td>
<input type="checkbox" name="WindowlessVideo" onchange="do_preview()" onpropertychange="do_preview()" id="WindowlessVideo" value="windowlessVideo" /></td>
								</tr>
							</table>
							</div>									
						</fieldset>
					</td>
					<td style="width:2px"></td>
					<td style="vertical-align:top">
						<fieldset style="margin-bottom:5px">
							<legend>[[Insert]]</legend>
							<div style="padding:3px;">
							<table border="0" cellpadding="1" cellspacing="0" class="normal">
								<tr>
									<td valign="middle">
										[[Url]]:</td>
									<td>
										<input type="text" id="TargetUrl" size="40" name="TargetUrl" runat="server" />
									</td>
								</tr>
							</table>
							</div>									
						</fieldset>
						<fieldset id="fieldsetUpload">
						<legend>
						[[Upload]] ([[MaxFileSizeAllowed]]
						<%= CuteEditor.Impl.FileStorage.FormatSize(secset.MaxMediaSize * 1024)%>
						)</legend>
						<div id="uploader">
							<ce:uploader id="InputFile" runat="server"></ce:uploader>
						</div>								
						<ul id="uploadinfo">
							<%if(secset.MaxMediaFolderSize>0){%>
							<li>[[MaxFolderSizeAllowed]]: <%= CuteEditor.Impl.FileStorage.FormatSize(secset.MaxMediaFolderSize * 1024)%>.
								<table border="0" cellpadding="0" cellspacing="0">
									<tr>
										<td>[[Used]]: <%= CuteEditor.Impl.FileStorage.FormatSize(RootDirectorySize) %></td>
										<td>
											<div class="progress-container"> 
												<div id="progress_bar" style="width:<%= GetUsedPercent() %>%"></div>
											</div>
										</td>
									</tr>
								</table>										
							</li>
							<%}%>
						</ul>										
					</fieldset>
						<div style="padding-top:12px;" align="center">
							<input class="formbutton" type="button" value="[[Insert]]" onclick="do_insert()" id="Button1" />
							&nbsp;&nbsp;&nbsp; <input class="formbutton" type="button" value="[[Cancel]]" onclick="do_Close()" id="Button2" />
						</div>
					</td>
				</tr>
			</table>
			</div>
		</form>
	</body>
	<script runat="server">
	protected override void InitOfType()
	{
		string folder=secset.MediaGalleryPath;

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
        foreach (string ext in secset.MediaFilters)
        {
            if (ext == null || ext.Length == 0) continue;

            files.AddRange(fs.GetFileItems(CurrentDirectory, secset.FileNamePrefix + "*" + ext));
        }
    }
    protected override bool AllowFileName(string filename)
    {
        filename = filename.ToLower();
        foreach (string ext in secset.MediaFilters)
        {
            if (ext == null || ext.Length == 0) continue;
            if(filename.EndsWith(ext.ToLower()))
                return true;
        }
        return false;
    }
    protected override string CheckUploadData(ref byte[] data)
    {
		if(secset.MaxMediaFolderSize>0)
		{
			if (RootDirectorySize >= secset.MaxMediaFolderSize * 1024)
				return "Media folder size exceeds the limit: "+ CuteEditor.Impl.FileStorage.FormatSize(secset.MaxMediaFolderSize * 1024);
		}
        if (data.Length >= secset.MaxMediaSize * 1024)
            return "Media size exceeds "+CuteEditor.Impl.FileStorage.FormatSize(secset.MaxMediaSize * 1024)+" limit: "+ CuteEditor.Impl.FileStorage.FormatSize(data.Length);
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
	<script type="text/javascript" src="Load.ashx?type=dialogscript&verfix=1006&file=DialogFoot.js"></script>
	<script type="text/javascript" src="Load.ashx?type=dialogscript&verfix=1006&file=Dialog_InsertMedia.js"></script>
</html>
