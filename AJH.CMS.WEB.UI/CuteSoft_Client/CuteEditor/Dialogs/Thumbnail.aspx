<%@ Page Language="C#" Inherits="CuteEditor.Dialogs.ThumbnailPage" %>

<script runat="server">
override protected void OnInit(EventArgs args)
{
	if(Context.Request.QueryString["Dialog"]=="Standard")
	{
		if(Context.Request.QueryString["IsFrame"]==null)
		{
			string FrameSrc="Thumbnail.aspx?IsFrame=1&"+Request.ServerVariables["QUERY_STRING"];
			CuteEditor.CEU.WriteDialogOuterFrame(Context,"[[AutoThumbnail]]",FrameSrc);
			Context.Response.End();
		}
	}
		base.OnInit(args);
}
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>[[AutoThumbnail]] </title>		
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.1)" />
		<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.1)" />
		<link href='Load.ashx?type=themecss&file=dialog.css&theme=[[_Theme_]]' type="text/css" rel="stylesheet" />
		<script type="text/javascript" src="Load.ashx?type=dialogscript&verfix=1004&file=DialogHead.js"></script>
	</head>
	<body style="margin:0px;border-width:0px;padding:4px;">
		<form runat="server" id="Form1">
			<input type="hidden" runat="server" id="hiddenDirectory" name="hiddenDirectory" /> 
			<input type="hidden" runat="server" id="hiddenFile" name="hiddenFile" />
			<input type="hidden" runat="server" enableviewstate="false" id="hiddenAlert" name="hiddenAlert" /> 
			<input type="hidden" runat="server" enableviewstate="false" id="hiddenAction" name="hiddenAction" />
		<table border="0" cellpadding="4" cellspacing="0" width="100%">
			<tr>
				<td>
					<table border="0" cellpadding="1" cellspacing="4" class="normal">
					<tr>
						<td style="white-space:nowrap" >
							<fieldset style="height:80px;">
								<table border="0" cellpadding="0" cellspacing="0" class="normal">
									<tr>
										<td style="white-space:nowrap; width:60" >[[Width]]:</td>
										<td>
											<input runat="server" id="inp_width" value="80" maxlength="3" onkeyup="checkConstrains('width');"  onkeypress="return CancelEventIfNotDigit()" style="WIDTH : 70px" name="inp_width" />
										</td>
										<td rowspan="2" align="right" valign="middle"><img src="Load.ashx?type=image&file=locked.gif" id="imgLock" width="25" height="32" title="[[ConstrainProportions]]" /></td>
									</tr>
									<tr>
										<td>[[Height]]:</td>
										<td>
											<input runat="server" id="inp_height" value="80" maxlength="3" onkeyup="checkConstrains('height');"  onkeypress="return CancelEventIfNotDigit()" style="WIDTH : 70px" name="inp_height" />
										</td>
									</tr>
									<tr>
										<td colspan="3">
											<input type="checkbox" id="constrain_prop" checked="checked" onclick="javascript:toggleConstrains();" />
											 [[ConstrainProportions]]
										</td>
									</tr>
								</table>
							</fieldset>		
						</td>
						<td style="white-space:nowrap" >
							<div style="width:100px; height:80px; vertical-align:top;overflow:hidden;BACKGROUND-COLOR: #ffffff;BORDER-RIGHT: buttonhighlight 1px solid;BORDER-TOP: buttonshadow 1px solid;BORDER-LEFT: buttonshadow 1px solid;BORDER-BOTTOM: buttonhighlight 1px solid;">
								<img alt="" id="img_demo" src="Load.ashx?type=image&file=1x1.gif" />
							</div>
						</td>
					</tr>	
					<tr>
						<td>
							<div style="margin-top:8px;text-align:center">
								<asp:Button id="okButton" Text="  [[OK]]  " CssClass="formbutton" Runat="server" OnClick="thumbnailButton_Click" />
								&nbsp;&nbsp;
								<input type="button" value="[[Cancel]]" class="formbutton" onclick="top.returnValue=false;(top.close||top.closeeditordialog)()" />
							</div>
						</td>
					</tr>				
				</table>
			</td>
		</tr>
		</table>
	</form>			
	</body>
</html>
	
		<script type="text/javascript">
			var OxOec40=["src","img_demo","inp_width","inp_height","hiddenFile","hiddenAlert","hiddenDirectory","hiddenAction","onload","value","","IMG","width","height","[[ImagetooSmall]]","dir","imgLock","constrain_prop","checked","Load.ashx?type=image\x26file=locked.gif","Load.ashx?type=image\x26file=1x1.gif","preview_image","DIV","cssText","style","position:absolute","body","offsetWidth","offsetHeight","length"];var obj=Window_GetDialogArguments(window);var src=obj[OxOec40[0]];var img_demo=document.getElementById(OxOec40[1]);var inp_width=document.getElementById(OxOec40[2]);var inp_height=document.getElementById(OxOec40[3]);var hiddenFile=Window_GetElement(window,OxOec40[4],true);var hiddenAlert=Window_GetElement(window,OxOec40[5],true);var hiddenDirectory=Window_GetElement(window,OxOec40[6],true);var hiddenAction=Window_GetElement(window,OxOec40[7],true);var defaultwidth=<%= secset.ThumbnailWidth %>;var defaultheight=<%= secset.ThumbnailHeight %>;window[OxOec40[8]]=reset_hiddens;function reset_hiddens(){if(hiddenAction[OxOec40[9]]!=OxOec40[10]){if(hiddenAlert[OxOec40[9]]){alert(hiddenAlert.value);} ;Window_SetDialogReturnValue(window,hiddenAction.value);Window_CloseDialog(window);} else {hiddenAlert[OxOec40[9]]=OxOec40[10];hiddenAction[OxOec40[9]]=OxOec40[10];} ;} ;SyncToView();function SyncToView(){if(src){var img=document.createElement(OxOec40[11]);img[OxOec40[0]]=src;img_demo[OxOec40[0]]=src;var p1=parseInt(img[OxOec40[12]]/defaultwidth);var Ox71=parseInt(img[OxOec40[13]]/defaultheight);if(p1>Ox71){if(img[OxOec40[12]]<defaultwidth){alert(OxOec40[14]);inp_width[OxOec40[9]]=img[OxOec40[12]];inp_height[OxOec40[9]]=img[OxOec40[13]];} else {inp_width[OxOec40[9]]=defaultwidth;var Ox72=parseInt(defaultwidth*img[OxOec40[13]]/img[OxOec40[12]]);inp_height[OxOec40[9]]=Ox72;} ;} else {if(img[OxOec40[13]]<defaultheight){alert(OxOec40[14]);inp_width[OxOec40[9]]=img[OxOec40[12]];inp_height[OxOec40[9]]=img[OxOec40[13]];} else {inp_height[OxOec40[9]]=defaultheight;var Ox73=parseInt(defaultwidth*img[OxOec40[12]]/img[OxOec40[13]]);inp_width[OxOec40[9]]=Ox73;} ;} ;hiddenFile[OxOec40[9]]=src;hiddenDirectory[OxOec40[9]]=obj[OxOec40[15]];do_preview();} ;} ;function toggleConstrains(){var Ox75=document.getElementById(OxOec40[16]);var Ox76=document.getElementById(OxOec40[17]);if(Ox76[OxOec40[18]]){Ox75[OxOec40[0]]=OxOec40[19];checkConstrains(OxOec40[12]);} else {Ox75[OxOec40[0]]=OxOec40[20];} ;} ;var checkingConstrains=false;function checkConstrains(Ox79){if(checkingConstrains){return ;} ;checkingConstrains=true;try{var Ox76=document.getElementById(OxOec40[17]);if(Ox76[OxOec40[18]]){var Ox7a=document.getElementById(OxOec40[21]);if(Ox7a){var Ox7b=document.createElement(OxOec40[22]);Ox7b[OxOec40[24]][OxOec40[23]]=OxOec40[25];document[OxOec40[26]].appendChild(Ox7b);Ox7b.appendChild(Ox7a);Ox7a.removeAttribute(OxOec40[12]);Ox7a.removeAttribute(OxOec40[13]);Ox7a[OxOec40[24]][OxOec40[12]]=OxOec40[10];Ox7a[OxOec40[24]][OxOec40[13]]=OxOec40[10];original_width=Ox7a[OxOec40[27]];original_height=Ox7a[OxOec40[28]];Ox7b.removeNode(true);} else {var Ox7c=document.createElement(OxOec40[11]);Ox7c[OxOec40[0]]=src;original_width=Ox7c[OxOec40[12]];original_height=Ox7c[OxOec40[13]];} ;if((original_width>0)&&(original_height>0)){width=inp_width[OxOec40[9]];height=inp_height[OxOec40[9]];if(Ox79==OxOec40[12]){if(width[OxOec40[29]]==0||isNaN(width)){inp_width[OxOec40[9]]=OxOec40[10];inp_height[OxOec40[9]]=OxOec40[10];} else {height=parseInt(width*original_height/original_width);inp_height[OxOec40[9]]=height;} ;} ;if(Ox79==OxOec40[13]){if(height[OxOec40[29]]==0||isNaN(height)){inp_width[OxOec40[9]]=OxOec40[10];inp_height[OxOec40[9]]=OxOec40[10];} else {width=parseInt(height*original_width/original_height);inp_width[OxOec40[9]]=width;} ;} ;} ;} ;do_preview();} finally{checkingConstrains=false;} ;} ;function do_preview(){img_demo[OxOec40[12]]=inp_width[OxOec40[9]];img_demo[OxOec40[13]]=inp_height[OxOec40[9]];} ;	
			
		</script>

