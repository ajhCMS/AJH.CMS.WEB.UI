<%@ Page Language="C#" Inherits="CuteEditor.EditorUtilityPage" %>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title>[[YouTube]] </title>		
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.1)" />
		<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.1)" />
		<link href='Load.ashx?type=themecss&file=dialog.css&theme=[[_Theme_]]' type="text/css" rel="stylesheet" />
		<!--[if IE]>
			<link href="Load.ashx?type=style&file=IE.css" type="text/css" rel="stylesheet" />
		<![endif]-->
		<script type="text/javascript" src="Load.ashx?type=dialogscript&verfix=1006&file=DialogHead.js"></script>		
		<style type="text/css">
			html, body,#ajaxdiv,#Form1 {height: 100%;}
		#idSource{width: 480px; height: 120px;background-color:#ffffff;padding:0;border:1px solid #a0a0a0;}
		</style>
	</head>
	<body>
		<div id="ajaxdiv">
			<table border="0" cellspacing="2" cellpadding="2" width="100%">
				<tr>
					<td style="white-space:nowrap;">
						<p style="margin:3px">[[PasteYouTube]]:</p>
							<textarea name="idSource" id="idSource" rows="9" cols="50" onpaste="setTimeout('do_preview()',100)" onchange="do_preview()"></textarea>
						<input type="hidden" id="TargetUrl" size="50" name="TargetUrl" />
					</td>
				</tr>
			</table>
			<div style="padding-top:10px;text-align:center">
<input class="formbutton" type="button" value="[[Insert]]" onclick="do_insert()" />&nbsp;&nbsp;&nbsp;
<input class="formbutton" type="button" value="[[Cancel]]" onclick="do_Close()" />
			</div>								
		</div>
	</body>
	<script type="text/javascript" src="Load.ashx?type=dialogscript&verfix=1006&file=DialogFoot.js"></script>
	<script type="text/javascript" src="Load.ashx?type=dialogscript&verfix=1006&file=Dialog_YouTube.js"></script>
</html>