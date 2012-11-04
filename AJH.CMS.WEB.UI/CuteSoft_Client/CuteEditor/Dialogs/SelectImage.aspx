<%@ Page Language="C#" Inherits="CuteEditor.Dialogs.FileBrowserPage" %>
<%@ Register TagPrefix="CE" Assembly="CuteEditor" Namespace="CuteEditor" %>
<script runat="server">
override protected void OnInit(EventArgs args)
{
	if(Context.Request.QueryString["Dialog"]=="Standard")
	{
	if(Context.Request.QueryString["IsFrame"]==null)
	{
		string FrameSrc="SelectImage.Aspx?IsFrame=1&"+Request.ServerVariables["QUERY_STRING"];
		CuteEditor.CEU.WriteDialogOuterFrame(Context,"[[Browse]]",FrameSrc);
		Context.Response.End();
	}
	}
	base.OnInit(args);
	
	InputFile.ValidateOption.MaxSizeKB=secset.MaxImageSize;
	InputFile.ValidateOption.AllowedFileExtensions=string.Join(",",(string[])secset.ImageFilters.ToArray(typeof(string)));
}
</script>
<%
string QUERY_STRING=Request.ServerVariables["QUERY_STRING"];
%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>[[Browse]]</title>
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.1)" />
		<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.1)" />
		<link href='Load.ashx?type=themecss&file=dialog.css&theme=[[_Theme_]]' type="text/css" rel="stylesheet" />
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
			#browse_Frame{border-top:1px solid #a0a0a0;border-left:1px solid #a0a0a0;border-bottom:1px solid #ffffff;border-right:1px solid #ffffff;width:260px;height:250px;overflow:auto;background-color:white;}
			#divouter{border-top:1px solid #a0a0a0;border-left:1px solid #a0a0a0;border-bottom:1px solid #ffffff;border-right:1px solid #ffffff;vertical-align: top; overflow: auto; width:280px;height:250px; background-color:white;text-align:center}
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
			.cell3 {vertical-align: middle; text-align:right}
			#FolderList {
				/* for Firefox, Opera and others: */
				max-width: 220px; 
			}
			.image-align{vertical-align:middle;margin:3px;}
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
		<div id="ajaxdiv">
			<!-- start hidden -->
			<input type="hidden" runat="server" id="hiddenDirectory" name="hiddenDirectory" />
			<input type="hidden" runat="server" id="hiddenFile" name="hiddenFile" /> 
			<input type="hidden" runat="server" enableviewstate="false" id="hiddenAlert" name="hiddenAlert" />
			<input type="hidden" runat="server" enableviewstate="false" id="hiddenAction" onserverchange="hiddenAction_ServerChange" name="hiddenAction" /> 
			<input type="hidden" runat="server" enableviewstate="false" id="hiddenActionData" name="hiddenActionData" />
			<!-- end hidden -->
			<table border="0" cellspacing="0" cellpadding="0" width="100%">
				<tr>
					<td style="width:20px">
						<asp:Image id="Image1" Runat="server" ImageUrl="Load.ashx?type=image&file=openfolder.gif"></asp:Image>
					</td>
					<td style="width:200px" class="normal">
						<asp:Label Runat="server" id="FolderDescription"></asp:Label>
						<asp:dropdownlist Runat="server" ID="FolderList" Visible="False" />
					</td>
					<td>
<asp:ImageButton id="CreateDir" BorderWidth="1" Runat="server" AlternateText="[[Createdirectory]]" ImageUrl="Load.ashx?type=image&file=newfolder.gif" OnClick="CreateDir_Click" />
<asp:ImageButton id="Copy" BorderWidth="1" Runat="server" AlternateText="[[Copyfiles]]" ImageUrl="Load.ashx?type=image&file=Copy.gif" Visible="true" OnClick="Copy_Click" />
<asp:ImageButton id="Move" BorderWidth="1" Runat="server" AlternateText="[[Movefiles]]" ImageUrl="Load.ashx?type=image&file=move.gif" Visible="true" OnClick="Move_Click" />
<img id="btn_zoom_in" src="Load.ashx?type=image&file=zoom_in.gif" onclick="Zoom_In();" title="[[ZoomIn]]" class="cursor dialogButton"	 /> 
<img id="btn_zoom_out" src="Load.ashx?type=image&file=zoom_out.gif" onclick="Zoom_Out();" title="[[ZoomOut]]" class="cursor dialogButton" /> 
<img id="btn_bestfit" src="Load.ashx?type=image&file=bestfit.gif" onclick="BestFit();" title="[[BestFit]]" class="cursor dialogButton" /> 
<img id="btn_Actualsize" src="Load.ashx?type=image&file=Actualsize.gif" onclick="Actualsize();" title="[[ActualSize]]" class="cursor dialogButton" /> 
<img id="img_AutoThumbnail" src="Load.ashx?type=image&file=resize.gif" onclick="AutoThumbnail();" title="[[AutoThumbnail]]" class="cursor dialogButton" /> 
<% if(secset.AllowModify) {%>
	<img id="img_ImageEditor" class="cursor dialogButton" src="Load.ashx?type=image&file=imageeditor.gif" onclick="ImageEditor();" title="[[ImageEditor]]" />
<%
}
else
{
%>
	<img id="img_ImageEditor" class="CuteEditorButtonDisabled" src="Load.ashx?type=image&file=imageeditor.gif" title="[[ImageEditor]]" />
<%
}
%>
					</td>
				</tr>
			</table>
			<table border="0" cellspacing="0" cellpadding="0" width="100%" style="margin:2px 0 2px 0;">
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
		<asp:tableheadercell id="name_Cell" Wrap="True" Width="120px" CssClass="filelistHeadCol" Font-Bold="False">[[Name]]</asp:tableheadercell>
		<asp:tableheadercell id="size_Cell" Width="52px" CssClass="filelistHeadCol" Wrap="False" Font-Bold="False">[[Size]]</asp:tableheadercell>
		<asp:tableheadercell id="op_Cell" Width="16px">&nbsp;</asp:tableheadercell>
	</asp:tablerow>
</asp:table>
							</div>
						</td>
						<td>
							<div id="divouter">
								<div id="divpreview">
									<img id="img_demo" alt="" src="../Load.ashx?type=image&file=1x1.gif" />
								</div>
							</div>
						</td>
					</tr>
				</table>
			
			<table border="0" cellspacing="2" cellpadding="0" width="98%">
				<tr>
					<td>
						<fieldset style="width:98%;">
							<legend>
								[[Insert]]</legend>
								<div style="padding:4px;">
									<table id="Table8" cellspacing="0" cellpadding="2" border="0" class="normal">
										<tr>
											<td valign="middle">[[Url]]:</td>
											<td>												
<input type="text" id="TargetUrl" style="width:400px" name="TargetUrl" runat="server" />												
											</td>
										</tr>
									</table>
								</div>
						</fieldset>
						<fieldset id="fieldsetUpload">
							<legend>
							[[Upload]] ([[MaxFileSizeAllowed]]
							<%= CuteEditor.Impl.FileStorage.FormatSize(secset.MaxImageSize * 1024)%>
							)</legend>
							<div id="uploader">
								<ce:uploader id="InputFile" runat="server"></ce:uploader>
							</div>
							<table>
								<% if(secset.RestrictUploadedImageDimension) {%>
								<tr>
									<td><img class="image-align" alt="" src="../Load.ashx?type=image&file=colorfocus.gif" /></td>
									<td>[[MaxImagedImension]]
									<%= secset.MaxImageWidth%>
									x
									<%= secset.MaxImageHeight%>
									[[pixels]].</td>
								</tr>
								<tr><td><img class="image-align" alt="" src="../Load.ashx?type=image&file=colorfocus.gif" /></td><td>[[AutomaticImageResizeOnOff]]
									<%= secset.AutoResizeUploadedImages? "[[on]]":"[[off]]" %>.</td></tr>
								<%}%>
								<tr><td><img class="image-align" alt="" src="../Load.ashx?type=image&file=colorfocus.gif" /></td>
								<td>
									<%if(secset.MaxImageFolderSize>0){%>
									<table border="0" cellpadding="0" cellspacing="0">
										<tr>
											<td style="margin:0;padding:0">[[MaxFolderSizeAllowed]]: <%= CuteEditor.Impl.FileStorage.FormatSize(secset.MaxImageFolderSize * 1024)%>.</td>
											<td>&nbsp; [[Used]]: <%= CuteEditor.Impl.FileStorage.FormatSize(RootDirectorySize) %></td>
											<td>
												<div class="progress-container">
													<div id="progress_bar" style="width:<%= GetUsedPercent() %>%"></div>
												</div>
											</td>
										</tr>
									</table>
									<%}%>
								</td>
								</tr>								
							</table>										
						</fieldset>
						<div style="padding-top:15px;" align="center">
							<input class="formbutton" type="button" value="[[Insert]]" onclick="do_insert()"
								id="Button1" /> &nbsp;&nbsp;&nbsp; <input class="formbutton" type="button" value="[[Cancel]]" onclick="do_Close()" id="Button2" />
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
		this.Context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
		string folder=secset.ImageBrowserPath;
		if(folder==null||folder=="")folder=secset.ImageGalleryPath;
		
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
        foreach (string ext in secset.ImageFilters)
        {
            if (ext == null || ext.Length == 0) continue;

            files.AddRange(fs.GetFileItems(CurrentDirectory, secset.FileNamePrefix + "*" + ext));
        }
    }
    protected override bool AllowFileName(string filename)
    {
        filename = filename.ToLower();
        foreach (string ext in secset.ImageFilters)
        {
            if (ext == null || ext.Length == 0) continue;
            if(filename.EndsWith(ext.ToLower()))
                return true;
        }
        return false;
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
    protected override string CheckUploadData(ref byte[] data)
    {  
		if(secset.MaxImageFolderSize>0)
		{
			if (RootDirectorySize >= secset.MaxImageFolderSize * 1024)
				return "Image folder size exceeds the limit: "+ CuteEditor.Impl.FileStorage.FormatSize(secset.MaxImageFolderSize * 1024);
		}			
      
        System.Drawing.Image img;
        try
        {
            img = System.Drawing.Image.FromStream(new System.IO.MemoryStream(data));
        }
        catch
        {
            return "Image is in the wrong format.";
        }

        //let base class to implement
        /*
        
        if (data.Length >= secset.MaxImageSize * 1024)
           return "Image size exceeds "+CuteEditor.Impl.FileStorage.FormatSize(secset.MaxImageSize * 1024)+" limit: "+ CuteEditor.Impl.FileStorage.FormatSize(data.Length);


        if(secset.RestrictUploadedImageDimension)
        {
			if(secset.AutoResizeUploadedImages)
			{
				return null;//let base class implement the secset.AutoResizeUploadedImages
			}
			else
			{
				if ((img.Width > secset.MaxImageWidth) || ((img.Height > secset.MaxImageHeight)))
					return String.Format("Image dimension ({0} x {1} pixels) exceeding limits.", img.Width, img.Height);
			}	
		}
		*/
		
        return null;
    }
	</script>
	<script type="text/javascript" src="Load.ashx?type=dialogscript&verfix=1006&file=DialogFoot.js"></script>
	<script type="text/javascript" src="Load.ashx?type=dialogscript&verfix=1006&file=Dialog_SelectImage.js"></script>
</html>
