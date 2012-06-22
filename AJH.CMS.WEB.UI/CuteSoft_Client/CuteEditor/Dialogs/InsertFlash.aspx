<%@ Page Language="C#" Inherits="CuteEditor.Dialogs.FileBrowserPage" %>
<%@ Register TagPrefix="CE" Assembly="CuteEditor" Namespace="CuteEditor" %>
<script runat="server">
override protected void OnInit(EventArgs args)
{
	if(Context.Request.QueryString["IsFrame"]==null)
	{
		string FrameSrc="InsertFlash.Aspx?IsFrame=1&"+Request.ServerVariables["QUERY_STRING"];
		CuteEditor.CEU.WriteDialogOuterFrame(Context,"[[InsertFlash]]",FrameSrc);
		Context.Response.End();
	}
	base.OnInit(args);
}
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>		
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.1)" />
		<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.1)" />
		<meta http-equiv="Cache-Control" content="no-cache" />
		<meta http-equiv="Pragma" content="no-cache" />
		<meta http-equiv="EXPIRES" content="0" />
		<title></title>
		<link href="Load.ashx?type=style&file=dialog.css" type="text/css" rel="stylesheet" />
		<!--[if IE]>
			<link href="Load.ashx?type=style&file=IE.css" type="text/css" rel="stylesheet" />
		<![endif]-->
		<script type="text/javascript" src="Load.ashx?type=dialogscript&file=DialogHead.js"></script>
		<script type="text/javascript" >		
		function PostBackAction()
		{
			<%=Page.ClientScript.GetPostBackEventReference(hiddenAction,"")%>
		}
		</script>
		<style type="text/css">
		.row { HEIGHT: 22px }
		.cb { VERTICAL-ALIGN: middle }
		.itemimg { VERTICAL-ALIGN: middle }
		.editimg { VERTICAL-ALIGN: middle }
		.cell1 { VERTICAL-ALIGN: middle }
		.cell2 { VERTICAL-ALIGN: middle }
		.cell3 { PADDING-RIGHT: 4px; VERTICAL-ALIGN: middle; TEXT-ALIGN: right }
		.cb { }
		</style>
	</head>
	<body>
		<form runat="server" enctype="multipart/form-data" id="Form1">
			<!-- start hidden -->
<input type="hidden" runat="server" id="hiddenDirectory" /> 
<input type="hidden" runat="server" id="hiddenFile" />
<input type="hidden" runat="server" enableviewstate="false" id="hiddenAlert" /> 
<input type="hidden" runat="server" enableviewstate="false" id="hiddenAction" onserverchange="hiddenAction_ServerChange" />
<input type="hidden" runat="server" enableviewstate="false" id="hiddenActionData" />
			<!-- end hidden -->
			<table border="0" cellspacing="0" cellpadding="0" width="100%">
				<tr>
					<td style="width:20">
						<asp:Image id="Image1" Runat="server" ImageUrl="../Load.ashx?type=image&file=openfolder.gif"></asp:Image>
					</td>
					<td style="width:240" class="normal">
						<asp:Label Runat="server" id="FolderDescription"></asp:Label>
					</td>
					<td>
<asp:ImageButton id="CreateDir" BorderWidth="1" Runat="server" AlternateText="[[Createdirectory]]" ImageUrl="../Load.ashx?type=image&file=newfolder.gif" OnClick="CreateDir_Click" />
<asp:ImageButton id="Copy" BorderWidth="1" Runat="server" AlternateText="[[Copyfiles]]" ImageUrl="../Load.ashx?type=image&file=Copy.gif" OnClick="Copy_Click" />
<asp:ImageButton id="Move" BorderWidth="1" Runat="server" AlternateText="[[Movefiles]]" ImageUrl="../Load.ashx?type=image&file=move.gif" OnClick="Move_Click" />
<img id="btn_zoom_in" src="../Load.ashx?type=image&file=zoom_in.gif" onclick="Zoom_In();" alt="[[ZoomIn]]" class="dialogButton"	/> 
<img id="btn_zoom_out" src="../Load.ashx?type=image&file=zoom_out.gif" onclick="Zoom_Out();" alt="[[ZoomOut]]" class="dialogButton"	/> 
<img id="btn_Actualsize" src="../Load.ashx?type=image&file=Actualsize.gif" onclick="Actualsize();" alt="[[ActualSize]]" class="dialogButton" /> 
					</td>
				</tr>
			</table>
			<table border="0" cellspacing="0" cellpadding="2" width="100%">
				<tr>
					<td valign="top" style="white-space:nowrap;width:250">
						<div style="BORDER: 1.5pt inset;  VERTICAL-ALIGN: middle; OVERFLOW: auto; WIDTH: 250; HEIGHT: 240px; Padding:0; BACKGROUND-COLOR: white">
							<asp:Table id="FoldersAndFiles" Runat="server" CellSpacing="1" CellPadding="1" Width="100%" CssClass="sortable">
								<asp:TableRow BackColor="#f0f0f0">
									<asp:TableHeaderCell Width="16px" >
<asp:ImageButton id="Delete" Runat="server" AlternateText="[[Deletefiles]]"	ImageUrl="../Load.ashx?type=image&file=s_cut.gif" OnClick="Delete_Click" />
									</asp:TableHeaderCell>
									<asp:TableHeaderCell Width="16px" >
<asp:ImageButton id="DoRefresh" Runat="server" AlternateText="[[Refresh]]" ImageUrl="../Load.ashx?type=image&file=s_refresh.gif" OnClick="DoRefresh_Click" />
									</asp:TableHeaderCell>
									<asp:TableHeaderCell id="name_Cell" Width="136px" CssClass="filelistHeadCol" Font-Bold="False">[[Name]]</asp:TableHeaderCell>
									<asp:TableHeaderCell id="size_Cell" Width="72px" CssClass="filelistHeadCol" Font-Bold="False">[[Count]]/[[Size]]</asp:TableHeaderCell>
									<asp:TableHeaderCell id="op_Cell"  Width="16px">&nbsp;</asp:TableHeaderCell>
								</asp:TableRow>
							</asp:Table>
						</div>
					</td>
					<td valign="top">
						<div style="BORDER: 1.5pt inset; VERTICAL-ALIGN: top; OVERFLOW: auto; WIDTH: 315px; HEIGHT: 240px; BACKGROUND-COLOR: white; TEXT-ALIGN: center">
							<div id="divpreview" style="BACKGROUND-COLOR: white">&nbsp;</div>
						</div>
					</td>
				</tr>
				<tr>
					<td colspan="2" style="height:2">
					</td>
				</tr>
			</table>
			<table border="0" cellspacing="0" cellpadding="0" width="100%">
				<tr>
					<td valign="top">
						<fieldset>
							<legend>[[Properties]]</legend>
							<table border="0" cellpadding="4" cellspacing="0" id="Table3">
								<tr>
									<td>
										<table border="0" cellpadding="1" cellspacing="0" class="normal">
											<tr>
												<td style="width:110">[[Width]]:</td>
												<td style="width:120">
<input type="text" name="Width" id="Width" style="WIDTH : 80px" onchange="do_preview()"	onkeypress="return CancelEventIfNotDigit()" value="200" />
												</td>
											</tr>
											<tr>
												<td>[[Height]]:</td>
												<td>
<input type="text" name="Height" id="Height" style="WIDTH : 80px" onchange="do_preview()" onkeypress="return CancelEventIfNotDigit()" value="200" />
											    </td>
											</tr>
											<tr>
												<td>[[Backgroundcolor]]:</td>
												<td><input type="text" id="bgColortext" name="bgColortext" size="7" style="WIDTH:57px" />
													<img alt="" id="bgColortext_Preview" src="../Load.ashx?type=image&file=colorpicker.gif" style='vertical-align:inherit;behavior:url(Load.ashx?type=htc&file=ColorPicker.htc)' />
												</td>
											</tr>
											<tr>
												<td>[[Quality]]:
												</td>
												<td><select name="Quality" id="Quality" style="WIDTH : 80px" onchange="do_preview()" onpropertychange="do_preview()">
														<option selected="selected" value="high">High</option>
														<option value="medium">Medium</option>
														<option value="low">Low</option>
													</select>
												</td>
											</tr>
											<tr>
												<td style="width:100">[[Scale]]:</td>
												<td>
													<select name="Scale" style="WIDTH : 80px" id="Scale" onchange="do_preview()" onpropertychange="do_preview()">
														<option selected="selected" value="">[[Default]]</option>
														<option value="Noborder">[[Noborder]]</option>
														<option value="Exactfit">[[Exactfit]]</option>
													</select>
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</fieldset>
						<fieldset>
						<legend>[[Layout]]</legend>
							<table border="0" cellpadding="4" cellspacing="0" width="100%">
								<tr>
									<td>
										<table border="0" cellpadding="1" cellspacing="0" class="normal" width="100%">
											<tr>
												<td style="width:100">[[Alignment]]:</td>
												<td>
													<select name="Align" style="WIDTH : 80px" id="Align" onchange="do_preview()" onpropertychange="do_preview()">
														<option id="optNotSet" selected="selected" value="">[[Notset]]</option>
														<option id="optLeft" value="left">[[Left]]</option>
														<option id="optRight" value="right">[[Right]]</option>
														<option id="optTexttop" value="textTop">[[Texttop]]</option>
														<option id="optAbsMiddle" value="absMiddle">[[Absmiddle]]</option>
														<option id="optBaseline" value="baseline">[[Baseline]]</option>
														<option id="optAbsBottom" value="absBottom">[[Absbottom]]</option>
														<option id="optBottom" value="bottom">[[Bottom]]</option>
														<option id="optMiddle" value="middle">[[Middle]]</option>
														<option id="optTop" value="top">[[Top]]</option>
													</select>
												</td>
											</tr>
											<tr>
												<td valign="middle" style="width:110px">[[Horizontal]]:</td>
												<td><input type="text" size="2" name="HSpace" onchange="do_preview()" onpropertychange="do_preview()"
														onkeypress="return CancelEventIfNotDigit()" style="WIDTH:80px" id="HSpace" />
												</td>
											</tr>
											<tr>
												<td valign="middle">[[Vertical]]:</td>
												<td>
												    <input type="text" size="2" name="VSpace" onchange="do_preview()" onpropertychange="do_preview()"
														onkeypress="return CancelEventIfNotDigit()" style="WIDTH:80px" id="VSpace" />
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</fieldset>
					</td>
					<td style="width:10">
					</td>
					<td valign="top">
						<fieldset style="margin-bottom:5px">
							<legend>
								[[Insert]]</legend>
							<table border="0" cellpadding="4" cellspacing="0">
								<tr>
									<td>
										<table border="0" cellpadding="1" cellspacing="0" class="normal">
											<tr>
												<td valign="middle" style="width:100">
													[[Url]]:</td>
												<td>
													<input type="text" id="TargetUrl" size="43" name="TargetUrl" runat="server" /></td>
											</tr>
											<tr>
												<td colspan="2">
													<input type="checkbox" checked="checked" id="chk_Loop" onchange="do_preview()" onpropertychange="do_preview()" />&nbsp;[[Loop]]&nbsp;&nbsp;
													<input type="checkbox" checked="checked" id="chk_Autoplay" onchange="do_preview()" onpropertychange="do_preview()" />&nbsp;[[Autoplay]]&nbsp;&nbsp;
													<input type="checkbox" checked="checked" id="chk_Transparency" onchange="do_preview()" onpropertychange="do_preview()" />&nbsp;[[Transparency]]&nbsp;
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</fieldset>
						<fieldset id="fieldsetUpload">
							<legend>
								[[Upload]] ([[MaxFileSizeAllowed]]
								<%= CuteEditor.Impl.FileStorage.FormatSize(secset.MaxFlashSize * 1024)%>
								)</legend>
							<table border="0" cellspacing="2" cellpadding="0" width="98%" class="normal">
								<tr>
									<td style="Height:10">
									</td>
								</tr>
								<tr>
									<td valign="top" style="font-size: 8pt; VERTICAL-ALIGN: middle;width:54%">
										<CE:UploadSingleFile id="InputFile" runat="server"></CE:UploadSingleFile>
									</td>
								</tr>
								<tr>
									<td style="width:8">
									</td>
								</tr>
								<tr>
									<td style="width:5">
									</td>
								</tr>
								<tr>
									<td>
										<span style="white-space:nowrap">
										[[MaxFolderSizeAllowed]]: <%= CuteEditor.Impl.FileStorage.FormatSize(secset.MaxFlashFolderSize * 1024)%>.
										[[Used]]: <%= CuteEditor.Impl.FileStorage.FormatSize(fs.GetDirectorySize(fs.VirtualRoot)) %>
										<span style="background-color:green;height:3px;width:40px;font-size:3px">
											<span style="background-color:red;height:3px;width:<%= GetUsedSpaceBarWidth() %>px;font-size:3px"></span>
										</span>
										</span>
									</td>
								</tr>
							</table>
						</fieldset>
						<div style="padding-top:10px;">
							<input class="inputbuttoninsert" type="button" value="[[Insert]]" onclick="do_insert()" />&nbsp;&nbsp;&nbsp;
							<input class="inputbuttoncancel" type="button" value="[[Cancel]]" onclick="do_cancel()" />
						</div>
					</td>
				</tr>
			</table>
		</form>
		<script runat="server">
	protected override void InitOfType()
	{
		fs.VirtualRoot=CuteEditor.EditorUtility.ProcessWebPath(Context,null,secset.FlashGalleryPath).TrimEnd('/')+"/";
	}
    protected override void GetFiles(ArrayList files)
    {
        files.AddRange(fs.GetFileItems(CurrentDirectory, secset.FileNamePrefix + "*.swf"));
    }
    protected override bool AllowFileName(string filename)
    {
        filename = filename.ToLower();
        return filename.EndsWith(".swf");
    }
    protected override string CheckUploadData(ref byte[] data)
    {
		if (fs.GetDirectorySize(fs.VirtualRoot) >= secset.MaxFlashFolderSize * 1024)
           return "Flash folder size exceeds the limit: "+ CuteEditor.Impl.FileStorage.FormatSize(secset.MaxFlashFolderSize * 1024);

		if (data.Length >= secset.MaxFlashSize * 1024)
            return "Flash size exceeds "+CuteEditor.Impl.FileStorage.FormatSize(secset.MaxFlashSize * 1024)+" limit: "+ CuteEditor.Impl.FileStorage.FormatSize(data.Length);
        return null;
    }
    
    protected int GetUsedSpaceBarWidth()
    {
      int w = Convert.ToInt32(40*fs.GetDirectorySize(fs.VirtualRoot)/(secset.MaxFlashFolderSize * 1024));
      if(w<1)
		w=1;
		
	  if(w>40)
		w=40;
		
      return w;      
    }
		</script>
		
	<script type="text/javascript" src="Load.ashx?type=dialogscript&file=DialogFoot.js"></script>
	<script type="text/javascript" src="Load.ashx?type=dialogscript&file=Dialog_InsertFlash.js"></script>
	</body>
</html>
