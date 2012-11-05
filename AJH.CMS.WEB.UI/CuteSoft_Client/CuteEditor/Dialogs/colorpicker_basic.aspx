<%@ Page Language="C#" Inherits="CuteEditor.EditorUtilityPage" %>
<script runat="server">
string GetDialogQueryString;
override protected void OnInit(EventArgs args)
{
	if(Context.Request.QueryString["Dialog"]=="Standard")
	{	
	if(Context.Request.QueryString["IsFrame"]==null)
	{
		string FrameSrc="colorpicker_basic.aspx?IsFrame=1&"+Request.ServerVariables["QUERY_STRING"];
		CuteEditor.CEU.WriteDialogOuterFrame(Context,"[[MoreColors]]",FrameSrc);
		Context.Response.End();
	}
	}
	string s="";
	if(Context.Request.QueryString["Dialog"]=="Standard")	
		s="&Dialog=Standard";
	
	GetDialogQueryString="Theme="+Context.Request.QueryString["Theme"]+s;	
	base.OnInit(args);
}
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.1)" />
		<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.1)" />
		<script type="text/javascript" src="Load.ashx?type=dialogscript&verfix=1006&file=DialogHead.js"></script>
		<script type="text/javascript" src="Load.ashx?type=dialogscript&verfix=1006&file=Dialog_ColorPicker.js"></script>
		<link href='Load.ashx?type=themecss&file=dialog.css&theme=[[_Theme_]]' type="text/css"
			rel="stylesheet" />
		<style type="text/css">
			.colorcell
			{
				width:16px;
				height:17px;
				cursor:hand;
			}
			.colordiv,.customdiv
			{
				border:solid 1px #808080;
				width:16px;
				height:17px;
				font-size:1px;
			}
			#ajaxdiv{padding:10px;margin:0;text-align:center; background:#eeeeee;}
		</style>
		<title>[[NamedColors]]</title>
		<script>
								
		var OxO2878=["Green","#008000","Lime","#00FF00","Teal","#008080","Aqua","#00FFFF","Navy","#000080","Blue","#0000FF","Purple","#800080","Fuchsia","#FF00FF","Maroon","#800000","Red","#FF0000","Olive","#808000","Yellow","#FFFF00","White","#FFFFFF","Silver","#C0C0C0","Gray","#808080","Black","#000000","DarkOliveGreen","#556B2F","DarkGreen","#006400","DarkSlateGray","#2F4F4F","SlateGray","#708090","DarkBlue","#00008B","MidnightBlue","#191970","Indigo","#4B0082","DarkMagenta","#8B008B","Brown","#A52A2A","DarkRed","#8B0000","Sienna","#A0522D","SaddleBrown","#8B4513","DarkGoldenrod","#B8860B","Beige","#F5F5DC","HoneyDew","#F0FFF0","DimGray","#696969","OliveDrab","#6B8E23","ForestGreen","#228B22","DarkCyan","#008B8B","LightSlateGray","#778899","MediumBlue","#0000CD","DarkSlateBlue","#483D8B","DarkViolet","#9400D3","MediumVioletRed","#C71585","IndianRed","#CD5C5C","Firebrick","#B22222","Chocolate","#D2691E","Peru","#CD853F","Goldenrod","#DAA520","LightGoldenrodYellow","#FAFAD2","MintCream","#F5FFFA","DarkGray","#A9A9A9","YellowGreen","#9ACD32","SeaGreen","#2E8B57","CadetBlue","#5F9EA0","SteelBlue","#4682B4","RoyalBlue","#4169E1","BlueViolet","#8A2BE2","DarkOrchid","#9932CC","DeepPink","#FF1493","RosyBrown","#BC8F8F","Crimson","#DC143C","DarkOrange","#FF8C00","BurlyWood","#DEB887","DarkKhaki","#BDB76B","LightYellow","#FFFFE0","Azure","#F0FFFF","LightGray","#D3D3D3","LawnGreen","#7CFC00","MediumSeaGreen","#3CB371","LightSeaGreen","#20B2AA","DeepSkyBlue","#00BFFF","DodgerBlue","#1E90FF","SlateBlue","#6A5ACD","MediumOrchid","#BA55D3","PaleVioletRed","#DB7093","Salmon","#FA8072","OrangeRed","#FF4500","SandyBrown","#F4A460","Tan","#D2B48C","Gold","#FFD700","Ivory","#FFFFF0","GhostWhite","#F8F8FF","Gainsboro","#DCDCDC","Chartreuse","#7FFF00","LimeGreen","#32CD32","MediumAquamarine","#66CDAA","DarkTurquoise","#00CED1","CornflowerBlue","#6495ED","MediumSlateBlue","#7B68EE","Orchid","#DA70D6","HotPink","#FF69B4","LightCoral","#F08080","Tomato","#FF6347","Orange","#FFA500","Bisque","#FFE4C4","Khaki","#F0E68C","Cornsilk","#FFF8DC","Linen","#FAF0E6","WhiteSmoke","#F5F5F5","GreenYellow","#ADFF2F","DarkSeaGreen","#8FBC8B","Turquoise","#40E0D0","MediumTurquoise","#48D1CC","SkyBlue","#87CEEB","MediumPurple","#9370DB","Violet","#EE82EE","LightPink","#FFB6C1","DarkSalmon","#E9967A","Coral","#FF7F50","NavajoWhite","#FFDEAD","BlanchedAlmond","#FFEBCD","PaleGoldenrod","#EEE8AA","Oldlace","#FDF5E6","Seashell","#FFF5EE","PaleGreen","#98FB98","SpringGreen","#00FF7F","Aquamarine","#7FFFD4","PowderBlue","#B0E0E6","LightSkyBlue","#87CEFA","LightSteelBlue","#B0C4DE","Plum","#DDA0DD","Pink","#FFC0CB","LightSalmon","#FFA07A","Wheat","#F5DEB3","Moccasin","#FFE4B5","AntiqueWhite","#FAEBD7","LemonChiffon","#FFFACD","FloralWhite","#FFFAF0","Snow","#FFFAFA","AliceBlue","#F0F8FF","LightGreen","#90EE90","MediumSpringGreen","#00FA9A","PaleTurquoise","#AFEEEE","LightCyan","#E0FFFF","LightBlue","#ADD8E6","Lavender","#E6E6FA","Thistle","#D8BFD8","MistyRose","#FFE4E1","Peachpuff","#FFDAB9","PapayaWhip","#FFEFD5"];var colorlist=[{n:OxO2878[0],h:OxO2878[1]},{n:OxO2878[2],h:OxO2878[3]},{n:OxO2878[4],h:OxO2878[5]},{n:OxO2878[6],h:OxO2878[7]},{n:OxO2878[8],h:OxO2878[9]},{n:OxO2878[10],h:OxO2878[11]},{n:OxO2878[12],h:OxO2878[13]},{n:OxO2878[14],h:OxO2878[15]},{n:OxO2878[16],h:OxO2878[17]},{n:OxO2878[18],h:OxO2878[19]},{n:OxO2878[20],h:OxO2878[21]},{n:OxO2878[22],h:OxO2878[23]},{n:OxO2878[24],h:OxO2878[25]},{n:OxO2878[26],h:OxO2878[27]},{n:OxO2878[28],h:OxO2878[29]},{n:OxO2878[30],h:OxO2878[31]}];var colormore=[{n:OxO2878[32],h:OxO2878[33]},{n:OxO2878[34],h:OxO2878[35]},{n:OxO2878[36],h:OxO2878[37]},{n:OxO2878[38],h:OxO2878[39]},{n:OxO2878[40],h:OxO2878[41]},{n:OxO2878[42],h:OxO2878[43]},{n:OxO2878[44],h:OxO2878[45]},{n:OxO2878[46],h:OxO2878[47]},{n:OxO2878[48],h:OxO2878[49]},{n:OxO2878[50],h:OxO2878[51]},{n:OxO2878[52],h:OxO2878[53]},{n:OxO2878[54],h:OxO2878[55]},{n:OxO2878[56],h:OxO2878[57]},{n:OxO2878[58],h:OxO2878[59]},{n:OxO2878[60],h:OxO2878[61]},{n:OxO2878[62],h:OxO2878[63]},{n:OxO2878[64],h:OxO2878[65]},{n:OxO2878[66],h:OxO2878[67]},{n:OxO2878[68],h:OxO2878[69]},{n:OxO2878[70],h:OxO2878[71]},{n:OxO2878[72],h:OxO2878[73]},{n:OxO2878[74],h:OxO2878[75]},{n:OxO2878[76],h:OxO2878[77]},{n:OxO2878[78],h:OxO2878[79]},{n:OxO2878[80],h:OxO2878[81]},{n:OxO2878[82],h:OxO2878[83]},{n:OxO2878[84],h:OxO2878[85]},{n:OxO2878[86],h:OxO2878[87]},{n:OxO2878[88],h:OxO2878[89]},{n:OxO2878[90],h:OxO2878[91]},{n:OxO2878[92],h:OxO2878[93]},{n:OxO2878[94],h:OxO2878[95]},{n:OxO2878[96],h:OxO2878[97]},{n:OxO2878[98],h:OxO2878[99]},{n:OxO2878[100],h:OxO2878[101]},{n:OxO2878[102],h:OxO2878[103]},{n:OxO2878[104],h:OxO2878[105]},{n:OxO2878[106],h:OxO2878[107]},{n:OxO2878[108],h:OxO2878[109]},{n:OxO2878[110],h:OxO2878[111]},{n:OxO2878[112],h:OxO2878[113]},{n:OxO2878[114],h:OxO2878[115]},{n:OxO2878[116],h:OxO2878[117]},{n:OxO2878[118],h:OxO2878[119]},{n:OxO2878[120],h:OxO2878[121]},{n:OxO2878[122],h:OxO2878[123]},{n:OxO2878[124],h:OxO2878[125]},{n:OxO2878[126],h:OxO2878[127]},{n:OxO2878[128],h:OxO2878[129]},{n:OxO2878[130],h:OxO2878[131]},{n:OxO2878[132],h:OxO2878[133]},{n:OxO2878[134],h:OxO2878[135]},{n:OxO2878[136],h:OxO2878[137]},{n:OxO2878[138],h:OxO2878[139]},{n:OxO2878[140],h:OxO2878[141]},{n:OxO2878[142],h:OxO2878[143]},{n:OxO2878[144],h:OxO2878[145]},{n:OxO2878[146],h:OxO2878[147]},{n:OxO2878[148],h:OxO2878[149]},{n:OxO2878[150],h:OxO2878[151]},{n:OxO2878[152],h:OxO2878[153]},{n:OxO2878[154],h:OxO2878[155]},{n:OxO2878[156],h:OxO2878[157]},{n:OxO2878[158],h:OxO2878[159]},{n:OxO2878[160],h:OxO2878[161]},{n:OxO2878[162],h:OxO2878[163]},{n:OxO2878[164],h:OxO2878[165]},{n:OxO2878[166],h:OxO2878[167]},{n:OxO2878[168],h:OxO2878[169]},{n:OxO2878[170],h:OxO2878[171]},{n:OxO2878[172],h:OxO2878[173]},{n:OxO2878[174],h:OxO2878[175]},{n:OxO2878[176],h:OxO2878[177]},{n:OxO2878[178],h:OxO2878[179]},{n:OxO2878[180],h:OxO2878[181]},{n:OxO2878[182],h:OxO2878[183]},{n:OxO2878[184],h:OxO2878[185]},{n:OxO2878[186],h:OxO2878[187]},{n:OxO2878[188],h:OxO2878[189]},{n:OxO2878[190],h:OxO2878[191]},{n:OxO2878[192],h:OxO2878[193]},{n:OxO2878[194],h:OxO2878[195]},{n:OxO2878[196],h:OxO2878[197]},{n:OxO2878[198],h:OxO2878[199]},{n:OxO2878[200],h:OxO2878[201]},{n:OxO2878[202],h:OxO2878[203]},{n:OxO2878[204],h:OxO2878[205]},{n:OxO2878[206],h:OxO2878[207]},{n:OxO2878[208],h:OxO2878[209]},{n:OxO2878[210],h:OxO2878[211]},{n:OxO2878[212],h:OxO2878[213]},{n:OxO2878[214],h:OxO2878[215]},{n:OxO2878[216],h:OxO2878[217]},{n:OxO2878[218],h:OxO2878[219]},{n:OxO2878[220],h:OxO2878[221]},{n:OxO2878[156],h:OxO2878[157]},{n:OxO2878[222],h:OxO2878[223]},{n:OxO2878[224],h:OxO2878[225]},{n:OxO2878[226],h:OxO2878[227]},{n:OxO2878[228],h:OxO2878[229]},{n:OxO2878[230],h:OxO2878[231]},{n:OxO2878[232],h:OxO2878[233]},{n:OxO2878[234],h:OxO2878[235]},{n:OxO2878[236],h:OxO2878[237]},{n:OxO2878[238],h:OxO2878[239]},{n:OxO2878[240],h:OxO2878[241]},{n:OxO2878[242],h:OxO2878[243]},{n:OxO2878[244],h:OxO2878[245]},{n:OxO2878[246],h:OxO2878[247]},{n:OxO2878[248],h:OxO2878[249]},{n:OxO2878[250],h:OxO2878[251]},{n:OxO2878[252],h:OxO2878[253]},{n:OxO2878[254],h:OxO2878[255]},{n:OxO2878[256],h:OxO2878[257]},{n:OxO2878[258],h:OxO2878[259]},{n:OxO2878[260],h:OxO2878[261]},{n:OxO2878[262],h:OxO2878[263]},{n:OxO2878[264],h:OxO2878[265]},{n:OxO2878[266],h:OxO2878[267]},{n:OxO2878[268],h:OxO2878[269]},{n:OxO2878[270],h:OxO2878[271]},{n:OxO2878[272],h:OxO2878[273]}];
		
		</script>
	</head>
	<body>
		<div id="ajaxdiv">
			<div class="tab-pane-control tab-pane" id="tabPane1">
				<div class="tab-row">
					<h2 class="tab">
						<a tabindex="-1" href='colorpicker.aspx?<%=GetDialogQueryString%>'>
							<span style="white-space:nowrap;">
								[[WebPalette]]
							</span>
						</a>
					</h2>
					<h2 class="tab selected">
							<a tabindex="-1" href='colorpicker_basic.aspx?<%=GetDialogQueryString%>'>
								<span style="white-space:nowrap;">
									[[NamedColors]]
								</span>
							</a>
					</h2>
					<h2 class="tab">
							<a tabindex="-1" href='colorpicker_more.aspx?<%=GetDialogQueryString%>'>
								<span style="white-space:nowrap;">
									[[CustomColor]]
								</span>
							</a>
					</h2>
				</div>
				<div class="tab-page">			
					<table class="colortable" align="center">
						<tr>
							<td colspan="16" height="16"><p align="left">Basic:
								</p>
							</td>
						</tr>
						<tr>
							<script>
								var OxOfada=["length","\x3Ctd class=\x27colorcell\x27\x3E\x3Cdiv class=\x27colordiv\x27 style=\x27background-color:","\x27 title=\x27"," ","\x27 cname=\x27","\x27 cvalue=\x27","\x27\x3E\x3C/div\x3E\x3C/td\x3E",""];var arr=[];for(var i=0;i<colorlist[OxOfada[0]];i++){arr.push(OxOfada[1]);arr.push(colorlist[i].n);arr.push(OxOfada[2]);arr.push(colorlist[i].n);arr.push(OxOfada[3]);arr.push(colorlist[i].h);arr.push(OxOfada[4]);arr.push(colorlist[i].n);arr.push(OxOfada[5]);arr.push(colorlist[i].h);arr.push(OxOfada[6]);} ;document.write(arr.join(OxOfada[7]));
							</script>
						</tr>
						<tr>
							<td colspan="16" height="12"><p align="left"></p>
							</td>
						</tr>
						<tr>
							<td colspan="16"><p align="left">Additional:
								</p>
							</td>
						</tr>
						<script>
							var OxOfe51=["length","\x3Ctr\x3E","\x3Ctd class=\x27colorcell\x27\x3E\x3Cdiv class=\x27colordiv\x27 style=\x27background-color:","\x27 title=\x27"," ","\x27 cname=\x27","\x27 cvalue=\x27","\x27\x3E\x3C/div\x3E\x3C/td\x3E","\x3C/tr\x3E",""];var arr=[];for(var i=0;i<colormore[OxOfe51[0]];i++){if(i%16==0){arr.push(OxOfe51[1]);} ;arr.push(OxOfe51[2]);arr.push(colormore[i].n);arr.push(OxOfe51[3]);arr.push(colormore[i].n);arr.push(OxOfe51[4]);arr.push(colormore[i].h);arr.push(OxOfe51[5]);arr.push(colormore[i].n);arr.push(OxOfe51[6]);arr.push(colormore[i].h);arr.push(OxOfe51[7]);if(i%16==15){arr.push(OxOfe51[8]);} ;} ;if(colormore%16>0){arr.push(OxOfe51[8]);} ;document.write(arr.join(OxOfe51[9]));
						</script>
						<tr>
							<td colspan="16" height="8">
							</td>
						</tr>
						<tr>
							<td colspan="16" height="12">
								<input checked id="CheckboxColorNames" style="width: 16px; height: 20px" type="checkbox">
								<span style="width: 118px;">Use color names</span>
							</td>
						</tr>
						<tr>
							<td colspan="16" height="12">
							</td>
						</tr>
						<tr>
							<td colspan="16" valign="middle" height="24">
							<span style="height:24px;width:50px;vertical-align:middle;">Color : </span>&nbsp;
							<input type="text" id="divpreview" size="7" maxlength="7" style="width:180px;height:24px;border:#a0a0a0 1px solid; Padding:4;"/>
					
							</td>
						</tr>
				</table>
			</div>
		</div>
		<div id="container-bottom">
			<input type="button" id="buttonok" value="[[OK]]" class="formbutton" style="width:70px"	onclick="do_insert();" /> 
			&nbsp;&nbsp;&nbsp;&nbsp; 
			<input type="button" id="buttoncancel" value="[[Cancel]]" class="formbutton" style="width:70px"	onclick="do_Close();" />	
		</div>
	</div>
	</body>
</html>

