<%@ Page Language="C#" Inherits="CuteEditor.EditorUtilityPage" %>
<script runat="server">
	string FrameSrc;
override protected void OnInit(EventArgs args)
{
	if(Context.Request.QueryString["IsFrame"]==null)
	{
		FrameSrc="ColorPicker.Aspx?IsFrame=1&"+Request.ServerVariables["QUERY_STRING"];
		CuteEditor.CEU.WriteDialogOuterFrame(Context,"[[MoreColors]]",FrameSrc);
		Context.Response.End();
	}
	base.OnInit(args);
}
</script>
<%
//FEATURE:color picker
%>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.1)" />
		<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.1)" />
		<script type="text/javascript" src="Load.ashx?type=dialogscript&file=DialogHead.js"></script>
		<style type="text/css">
			body,input,textarea,button,select,fieldset,td
			{
				color: windowtext; font:normal 11px Tahoma;
			}
			body
			{
				background-color:menu;	
				overflow:hidden;
			}
		</style>
		<title>[[MoreColors]] 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		</title>
		<script type="text/javascript">
		var OxOb96f=["0","FF","GetH","GetS","GetB","toString","valueOf","_h","r","g","b","_s","_b","#","","length","\x3Ctable bgColor=","\x3E","backgroundColor","style","bgColor","0x","\x3Ctd onmouseup=\x27YSUp(this)\x27 onclick=\x27YSDown(this)\x27 onmouseover=\x27YSDown(this)\x27 onmousedown=\x27YSDown(this)\x27 onmousemove=\x27YSMove(this)\x27 style=\x27font-size:2px; width:","px;height:","px;\x27\x3E\x26nbsp;\x3C/td\x3E","\x3Ctd onmouseup=\x27YSUp(this)\x27 onclick=\x27YSDown(this)\x27 onmousedown=\x27YSDown(this)\x27 style=\x27width:","px;\x27\x3E\x3C/td\x3E","\x3Ctr\x3E","\x3C/tr\x3E","\x3Ctr\x3E\x3Ctd onmouseup=\x27ZUp(this)\x27 onmouseover=\x27ZDown(this)\x27 onclick=\x27ZDown(this)\x27 onmousedown=\x27ZDown(this)\x27 onmousemove=\x27ZMove(this)\x27 style=\x27font-size:2px;width:30px;height:","px;\x27\x3E\x26nbsp;\x3C/td\x3E\x3C/tr\x3E","\x3Ctr\x3E\x3Ctd onmouseup=\x27ZUp(this)\x27 onclick=\x27ZDown(this)\x27 onmousedown=\x27ZDown(this)\x27 onmousemove=\x27ZMove(this)\x27 style=\x27width:30px;height:","px;\x27\x3E\x3C/td\x3E\x3C/tr\x3E"];var yxExponent=parseInt('<%=Request.QueryString["Quality"]%>')||0x5;var zExponent=0x7;var yxcount=Math.pow(0x2,yxExponent);var zcount=Math.pow(0x2,zExponent);var updatedelay=yxcount*yxcount/0x40;var usesafe=true; function NeedSafe(Oxe){if(!usesafe){return Math.floor(Math.max(0x0,Math.min(0xff,Oxe)));} ;var Oxf=0x33;return Math.floor(Math.max(0x0,Math.min(0xff,Math.round(Oxe/Oxf)*Oxf)));}  ;var rgbhexs=[]; InitRgbVars() ; function InitRgbVars(){for(var i=0x0;i<=0x100;i++){ rgbhexs[i]=Ox13(i) ;} ; function Ox13(n){if(n<0x10){return OxOb96f[0x0]+n.toString(0x10).toUpperCase();} ;if(n>=0x100){return OxOb96f[0x1];} ;return n.toString(0x10).toUpperCase();}  ;}  ; function RgbClass(Oxf,Ox16,Ox17){var obj={r:Oxf,g:Ox16,b:Ox17}; obj[OxOb96f[0x2]]=RgbClassGetH ; obj[OxOb96f[0x3]]=RgbClassGetS ; obj[OxOb96f[0x4]]=RgbClassGetB ; obj[OxOb96f[0x6]]=obj[OxOb96f[0x5]]=RgbClassToString ;return obj;}  ; function RgbClassGetH(){if(this[OxOb96f[0x7]]!=null){return this[OxOb96f[0x7]];} ;return this[OxOb96f[0x7]]=RgbClassGetH_Internal(this);}  ; function RgbClassGetH_Internal(Ox1b){var Ox1c=Math.max(Math.max(Ox1b[OxOb96f[0x8]],Ox1b.g),Ox1b.b);if(Ox1c==0x0){return 0x0;} ;var Oxf=Ox1b[OxOb96f[0x8]]*0x100/Ox1c;var Ox16=Ox1b[OxOb96f[0x9]]*0x100/Ox1c;var Ox17=Ox1b[OxOb96f[0xa]]*0x100/Ox1c; Ox1c=0x100 ;var Ox1d=Math.min(Math.min(Oxf,Ox16),Ox17);if(Ox1c==Ox1d){return 0x0;} ;if(Oxf==Ox1d){ Oxf=0x0 ;} ;if(Ox16==Ox1d){ Ox16=0x0 ;} ;if(Ox17==Ox1d){ Ox17=0x0 ;} ;var Ox1e=0x100;if(Oxf!=0x0&&Oxf!=0x100){ Ox1e=Oxf ;} ;if(Ox16!=0x0&&Ox16!=0x100){ Ox1e=Ox16 ;} ;if(Ox17!=0x0&&Ox17!=0x100){ Ox1e=Ox17 ;} ;var Ox1f=Ox1c*(Ox1e-Ox1d)/(Ox1c-Ox1d);if(Oxf!=0x0&&Oxf!=0x100){ Oxf=Ox1f ;} ;if(Ox16!=0x0&&Ox16!=0x100){ Ox16=Ox1f ;} ;if(Ox17!=0x0&&Ox17!=0x100){ Ox17=Ox1f ;} ;if(Oxf==0x0){if(Ox16==0x100){return 0x81-(0x100-Ox17)/0x6;} else {return 0x80+(0x100-Ox16)/0x6;} ;} ;if(Ox16==0x0){if(Ox17==0x100){return 0xd6-(0x100-Oxf)/0x6;} else {return 0xd6+(0x100-Ox17)/0x6;} ;} ;if(Ox17==0x0){if(Oxf==0x100){return 0x2b-(0x100-Ox16)/0x6;} else {return 0x2b+(0x100-Oxf)/0x6;} ;} ;}  ; function RgbClassGetS(){if(this[OxOb96f[0xb]]!=null){return this[OxOb96f[0xb]];} ;if(this[OxOb96f[0x8]]==0x0||this[OxOb96f[0x9]]==0x0||this[OxOb96f[0xa]]==0x0){if(this[OxOb96f[0x8]]==0x0&&this[OxOb96f[0x9]]==0x0&&this[OxOb96f[0xa]]==0x0){return this[OxOb96f[0xb]]=0x0;} ;return this[OxOb96f[0xb]]=0x64;} ;var Ox1c=Math.max(Math.max(this[OxOb96f[0x8]],this.g),this.b);var Ox1d=Math.min(Math.min(this[OxOb96f[0x8]],this.g),this.b);return this[OxOb96f[0xb]]=0x64*(Ox1c-Ox1d)/Ox1c;}  ; function RgbClassGetB(){if(this[OxOb96f[0xc]]!=null){return this[OxOb96f[0xc]];} ;return this[OxOb96f[0xc]]=0x64*Math.max(Math.max(this[OxOb96f[0x8]],this.g),this.b)/0x100;}  ; function RgbClassToString(){return OxOb96f[0xd]+rgbhexs[NeedSafe(this.r)]+rgbhexs[NeedSafe(this.g)]+rgbhexs[NeedSafe(this.b)];}  ; function ParseRgb(Ox24){if(!Ox24){return null;} ; Ox24=Ox24+OxOb96f[0xe] ;if(Ox24[OxOb96f[0xf]]==0x0){return null;} ;if(Ox24.charAt(0x0)!=OxOb96f[0xd]||Ox24[OxOb96f[0xf]]!=0x7){var Ox25=document.createElement(OxOb96f[0x10]+Ox24+OxOb96f[0x11]);try{ Ox25[OxOb96f[0x13]][OxOb96f[0x12]]=Ox24 ;} catch(x){return null;} ; Ox24=Ox25[OxOb96f[0x14]]+OxOb96f[0xe] ;if(Ox24.charAt(0x0)!=OxOb96f[0xd]||Ox24[OxOb96f[0xf]]!=0x7){return null;} ;} ;return  new RgbClass(parseInt(OxOb96f[0x15]+Ox24.substr(0x1,0x2)),parseInt(OxOb96f[0x15]+Ox24.substr(0x3,0x2)),parseInt(OxOb96f[0x15]+Ox24.substr(0x5,0x2)));}  ; function GetRgbOfH_GetV(i){ i=i%0x100 ;if(i<0x80){ i=0x100-i ;} ; i=(i-0x80)*0x2 ;if(i>0x100*0x2/0x3){return 0x100;} ;if(i<0x100/0x3){return 0x0;} ; i=(i-0x100/0x3)*0x3 ;return i;}  ; function GetRgbOfH(i){return  new RgbClass(GetRgbOfH_GetV(i),GetRgbOfH_GetV(i+0xab),GetRgbOfH_GetV(i+0x55));}  ; function GetRgbOfHsb(Ox29,Ox2a,Ox2b){var Oxf=GetRgbOfH_GetV(Ox29)*Ox2b/0x100;var Ox16=GetRgbOfH_GetV(Ox29+0x100*0x2/0x3)*Ox2b/0x100;var Ox17=GetRgbOfH_GetV(Ox29+0x100/0x3)*Ox2b/0x100;var Ox1c=Math.max(Oxf,Math.max(Ox16,Ox17));if(Ox1c==0x0){return  new RgbClass(0x0,0x0,0x0);} ;var Ox1e=Ox1c;if(Oxf!=0x0&&Oxf!=Ox1c){ Ox1e=Oxf ;} ;if(Ox16!=0x0&&Ox16!=Ox1c){ Ox1e=Ox16 ;} ;if(Ox17!=0x0&&Ox17!=Ox1c){ Ox1e=Ox17 ;} ;var Ox2c=Ox1c*(0x1-Ox2a/0x100);var Ox1f=Ox1c-(Ox1c-Ox1e)*(Ox1c-Ox2c)/Ox1c;if(Oxf==Ox1e){ Oxf=Ox1f ;} ;if(Ox16==Ox1e){ Ox16=Ox1f ;} ;if(Ox17==Ox1e){ Ox17=Ox1f ;} ;if(Oxf==0x0){ Oxf=Ox2c ;} ;if(Ox16==0x0){ Ox16=Ox2c ;} ;if(Ox17==0x0){ Ox17=Ox2c ;} ;return  new RgbClass(Oxf,Ox16,Ox17);}  ; function GetRgbByH(Ox2e,Ox2f,Ox30,Ox31){var Ox32=GetRgbOfH(0x100-Ox2e);if(Ox31){return Ox32;} ;var Ox33=(0x100-Ox30)*(0x100-Ox2f)/0x100;var p=(0x100-Ox2f)*Ox30/0x10000;return  new RgbClass(Ox33+p*Ox32[OxOb96f[0x8]],Ox33+p*Ox32[OxOb96f[0x9]],Ox33+p*Ox32.b);}  ; function GetXyzByH(Ox1b){return {x:Ox1b.GetS()*0x100/0x64,y:0x100-Ox1b.GetB()*0x100/0x64,z:0x100-Ox1b.GetH()};}  ; function GetRgbByS(Ox2e,Ox2f,Ox30,Ox31){return GetRgbOfHsb(Ox30,0x100-Ox2e,0x100-Ox2f);}  ; function GetXyzByS(Ox1b){return {x:Ox1b.GetH(),y:0x100-Ox1b.GetB()*0x100/0x64,z:0x100-Ox1b.GetS()*0x100/0x64};}  ; function GetRgbByB(Ox2e,Ox2f,Ox30,Ox31){return GetRgbOfHsb(Ox30,0x100-Ox2f,0x100-Ox2e);}  ; function GetXyzByB(Ox1b){return {x:Ox1b.GetH(),y:0x100-Ox1b.GetS()*0x100/0x64,z:0x100-Ox1b.GetB()*0x100/0x64};}  ; function GetRgbByRed(Ox2e,Ox2f,Ox30,Ox31){return  new RgbClass(0x100-Ox2e,0x100-Ox2f,Ox30);}  ; function GetXyzByRed(Ox1b){return {x:Ox1b[OxOb96f[0xa]],y:0x100-Ox1b[OxOb96f[0x9]],z:0x100-Ox1b[OxOb96f[0x8]]};}  ; function GetRgbByGreen(Ox2e,Ox2f,Ox30,Ox31){return  new RgbClass(0x100-Ox2f,0x100-Ox2e,Ox30);}  ; function GetXyzByGreen(Ox1b){return {x:Ox1b[OxOb96f[0xa]],y:0x100-Ox1b[OxOb96f[0x8]],z:0x100-Ox1b[OxOb96f[0x9]]};}  ; function GetRgbByBlue(Ox2e,Ox2f,Ox30,Ox31){return  new RgbClass(Ox30,0x100-Ox2f,0x100-Ox2e);}  ; function GetXyzByBlue(Ox1b){return {x:Ox1b[OxOb96f[0x8]],y:0x100-Ox1b[OxOb96f[0x9]],z:0x100-Ox1b[OxOb96f[0xa]]};}  ; function WriteYSTable(){var Ox2a;if(Browser_IsSafari()){ Ox2a=OxOb96f[0x16]+(0x100/yxcount)+OxOb96f[0x17]+(0xe6/yxcount)+OxOb96f[0x18] ;} else { Ox2a=OxOb96f[0x19]+(0x100/yxcount)+OxOb96f[0x17]+(0xe6/yxcount)+OxOb96f[0x1a] ;} ;var Ox41=Ox2a;for(var i=0x0;i<yxExponent;i++){ Ox41+=Ox41 ;} ; Ox2a+=Ox41 ; Ox2a=OxOb96f[0x1b]+Ox2a+OxOb96f[0x1c] ; Ox41=Ox2a ;for(var i=0x0;i<yxExponent;i++){ Ox41+=Ox41 ;} ; Ox2a+=Ox41 ; document.write(Ox2a) ;}  ; function WriteZTable(){var Ox2a;if(Browser_IsSafari()){ Ox2a=OxOb96f[0x1d]+(0xff/zcount)+OxOb96f[0x1e] ;} else { Ox2a=OxOb96f[0x1f]+(0xff/zcount)+OxOb96f[0x20] ;} ;var Ox43=Ox2a;for(var i=0x0;i<zExponent;i++){ Ox43+=Ox43 ;} ; Ox2a+=Ox43 ; document.write(Ox2a) ;}  ;
		</script>
	</head>
	<body style="margin:0px;padding:4px;overflow:hidden;">
		<table id="table1" cellspacing="0" cellpadding="0">
			<tr>
				<td style="width:256px">
					<table id="yxtable" onselectstart="return false;" cellspacing="0" cellpadding="0" border="0"
						style='border:1.5pt inset;background-color:black;height:256px;'>
						<script type="text/javascript">
							var OxOd827=[]; WriteYSTable() ;
						</script>
					</table>
				</td>
				<td id="tdzl" valign="top" style="font-size:9px;font-family:webdings;padding-left:4px;padding-right:0px;text-align:right;">4</td>
				<td valign='top'>
					<table id="ztable" onselectstart="return false;" cellspacing="0" cellpadding="0" border="0"
						style='border:1.5pt inset;background-color:black;height:256px; width:20px'>
						<script type="text/javascript">
					var OxO4d6d=[]; WriteZTable() ;
						</script>
					</table>
				</td>
				<td id="tdzr" valign="top" style="font-size:9px;font-family:webdings;padding-left:4px;padding-left:0px;text-align:left;">3</td>
				<td valign='top'>
					<table cellspacing="2" cellpadding="0">
						<tr>
							<td colspan="3" align="center">
								<div id="divpreview"  style="width:83px;height:45px;border:1.5pt inset; Padding:0;">
								</div>
							</td>
							<td>
							    &nbsp;&nbsp;<input type="button" id="btnok" value="[[OK]]" style="width:70px" onclick="do_ok();" />
							    &nbsp;
								<br />
								<br />
								&nbsp;&nbsp;
								<input type="button" id="btncc" value="[[Cancel]]" style="width:70px" onclick="do_cancel();" />
							</td>
						</tr>
						<tr>
							<td style="height:6px;" colspan="4"></td>
						</tr>
						<tr>
							<td><input type="radio" onclick="HandleUIChanged()" name="rd_mode" id="rd_hsb_h" value="hsb_h" /></td>
							<td>
								H:</td>
							<td><input type="text" id="hsb_h" readonly="readonly" style="width:52px" />
							</td>
						</tr>
						<tr>
							<td><input type="radio" onclick="HandleUIChanged()" name="rd_mode" id="rd_hsb_s" value="hsb_s" /></td>
							<td>
								S:</td>
							<td><input type="text" id="hsb_s" readonly="readonly" style="width:52px" />
							</td>
						</tr>
						<tr>
							<td><input type="radio" checked="checked" onclick="HandleUIChanged()" name="rd_mode" id="rd_hsb_b" value="hsb_b" /></td>
							<td>
								B:</td>
							<td><input type="text" id="hsb_b" readonly="readonly" style="width:52px" />
							</td>
						</tr>
						<tr>
							<td style="height:6px;" colspan="4"></td>
						</tr>
						<tr>
							<td><input type="radio" onclick="HandleUIChanged()" name="rd_mode" id="rd_rgb_r" value="rgb_r" /></td>
							<td>
								R:</td>
							<td><input type="text" id="rgb_r" style="width:52px" />
							</td>
							<td><div id="scroll_rgb_r" style='height:15px;width:90px;overflow-x:scroll;overflow-y:hidden;'><div style='width:180px'></div>
								</div>
							</td>
						</tr>
						<tr>
							<td><input type="radio" onclick="HandleUIChanged()" name="rd_mode" id="rd_rgb_g" value="rgb_g" /></td>
							<td>
								G:</td>
							<td><input type="text" id="rgb_g" style="width:52px" />
							</td>
							<td><div id="scroll_rgb_g" style='height:15px;width:90px;overflow-x:scroll;overflow-y:hidden;'>
							        <div style='width:180px'></div>
								</div>
							</td>
						</tr>
						<tr>
							<td><input type="radio" onclick="HandleUIChanged()" name="rd_mode" id="rd_rgb_b" value="rgb_b" /></td>
							<td>B:</td>
							<td><input type="text" id="rgb_b" style="width:52px" />
							</td>
							<td>
								<div id="scroll_rgb_b" style='height:15px;width:90px;overflow-x:scroll;overflow-y:hidden;'>
									<div style='width:170px'></div>
								</div>
							</td>
						</tr>
						<tr>
							<td style="height:6px;" colspan="4">
							</td>
						</tr>
						<tr>
							<td colspan="2">
								[[HTML]]:</td>
							<td colspan="2"><input type="text" id="val_v" maxlength="7" style="width:55px; font:normal 12px Tahoma;" />
							</td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td colspan="5">
					<table width="98%" cellpadding="0" cellspacing="0">
						<tr>
							<td style="width:150">
								<input type='checkbox' id='cb_safe' onpropertychange='Update()' onclick='Update()' /><label for='cb_safe'>[[OnlyWebColor]]</label>
							</td>
							<td>
								[[Quality]]: <input type='radio' name="radio_qlt" id='radio_qlt_low' onpropertychange='ChangeQuanlity()'
									onclick='ChangeQuanlity()' /><label for='radio_qlt_low'>[[Low]]</label> <input type='radio' name="radio_qlt" id='radio_qlt_medium' onpropertychange='ChangeQuanlity()'
									onclick='ChangeQuanlity()' /><label for='radio_qlt_medium'>[[Medium]]</label> <input type='radio' name="radio_qlt" id='radio_qlt_high' onpropertychange='ChangeQuanlity()'
									onclick='ChangeQuanlity()' /><label for='radio_qlt_high'>[[High]]</label> <span style='display:none'>
									<input type='radio' name="radio_qlt" id='radio_qlt_veryhigh' onpropertychange='ChangeQuanlity()'
										onclick='ChangeQuanlity()' /><label for='radio_qlt_veryhigh'>[[VeryHigh]]</label>
								</span>
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
	</body>
</html>
<script type="text/javascript">
var OxOea53=["addEventListener","TABLE","INPUT","DIV","BUTTON","TD","length","id","var ","=document.getElementById(\x27","\x27)"];if(document[OxOea53[0x0]]){var tagnamearr=[OxOea53[0x1],OxOea53[0x2],OxOea53[0x3],OxOea53[0x4],OxOea53[0x5]];for(var tni=0x0;tni<tagnamearr[OxOea53[0x6]];tni++){var tagname=tagnamearr[tni];var coll=document.getElementsByTagName(tagname);for(var i=0x0;i<coll[OxOea53[0x6]];i++){var element=coll[i];if(element[OxOea53[0x7]]){ eval(OxOea53[0x8]+element[OxOea53[0x7]]+OxOea53[0x9]+element[OxOea53[0x7]]+OxOea53[0xa]) ;} ;} ;} ;} ;
</script>
<script type="text/javascript">

var OxOae3b=["checked","border","style","","x","y","z","paddingTop","value","backgroundColor","r","g","b","1px solid white","cells","rows","onmouseup","scrollLeft","clientWidth","scrollWidth","onchange","onscroll"];var GetRgbBy=GetRgbByH;var GetXyzBy=GetXyzByH;var selz=0x0;var sely=0x0;var selx=yxcount; currentrgb=GetRgbBy(selz*0x100/zcount,sely*0x100/yxcount,selx*0x100/yxcount) ;var yxs=[];var zs=[];var isupdating=false;var downz=false;var downyx=false;var update_timer=0x0;var needupdateyx=true;var needupdatez=true;var firebyscroll=false; function HandleUIChanged(Ox1b){if(Ox1b==null){ Ox1b=currentrgb ;} ;if(rd_hsb_h[OxOae3b[0x0]]){ GetXyzBy=GetXyzByH ;} ;if(rd_hsb_s[OxOae3b[0x0]]){ GetXyzBy=GetXyzByS ;} ;if(rd_hsb_b[OxOae3b[0x0]]){ GetXyzBy=GetXyzByB ;} ;if(rd_rgb_r[OxOae3b[0x0]]){ GetXyzBy=GetXyzByRed ;} ;if(rd_rgb_g[OxOae3b[0x0]]){ GetXyzBy=GetXyzByGreen ;} ;if(rd_rgb_b[OxOae3b[0x0]]){ GetXyzBy=GetXyzByBlue ;} ; yxs[sely][selx][OxOae3b[0x2]][OxOae3b[0x1]]=OxOae3b[0x3] ;var Ox5c=GetXyzBy(Ox1b); selx=Math.round(Ox5c[OxOae3b[0x4]]*yxcount/0x100) ; sely=Math.round(Ox5c[OxOae3b[0x5]]*yxcount/0x100) ; selz=Math.round(Ox5c[OxOae3b[0x6]]*zcount/0x100) ; Update(true) ;}  ; function OnUpdate(Ox1b){}  ; function Update(Ox5f){ isupdating=true ;try{if(rd_hsb_h[OxOae3b[0x0]]){ GetRgbBy=GetRgbByH ;} ;if(rd_hsb_s[OxOae3b[0x0]]){ GetRgbBy=GetRgbByS ;} ;if(rd_hsb_b[OxOae3b[0x0]]){ GetRgbBy=GetRgbByB ;} ;if(rd_rgb_r[OxOae3b[0x0]]){ GetRgbBy=GetRgbByRed ;} ;if(rd_rgb_g[OxOae3b[0x0]]){ GetRgbBy=GetRgbByGreen ;} ;if(rd_rgb_b[OxOae3b[0x0]]){ GetRgbBy=GetRgbByBlue ;} ;var Ox32=GetRgbBy(selz*0x100/zcount,sely*0x100/yxcount,selx*0x100/yxcount); currentrgb=Ox32 ;var Ox60=Ox32.toString(); tdzl[OxOae3b[0x2]][OxOae3b[0x7]]=tdzr[OxOae3b[0x2]][OxOae3b[0x7]]=selz*0x100/zcount ; hsb_h[OxOae3b[0x8]]=Math.floor(Ox32.GetH()) ; hsb_s[OxOae3b[0x8]]=Math.round(Ox32.GetS()) ; hsb_b[OxOae3b[0x8]]=Math.round(Ox32.GetB()) ; val_v[OxOae3b[0x8]]=Ox60.toLowerCase() ; divpreview[OxOae3b[0x2]][OxOae3b[0x9]]=Ox60 ; rgb_r[OxOae3b[0x8]]=Math.floor(Ox32.r) ; rgb_g[OxOae3b[0x8]]=Math.floor(Ox32.g) ; rgb_b[OxOae3b[0x8]]=Math.floor(Ox32.b) ;if(!firebyscroll){if(Math.abs(GetScrollValue(scroll_rgb_r)*0x100-Ox32.r)>0x34){ SetScrollValue(scroll_rgb_r,Ox32[OxOae3b[0xa]]/0x100) ;} ;if(Math.abs(GetScrollValue(scroll_rgb_g)*0x100-Ox32.g)>0x34){ SetScrollValue(scroll_rgb_g,Ox32[OxOae3b[0xb]]/0x100) ;} ;if(Math.abs(GetScrollValue(scroll_rgb_b)*0x100-Ox32.b)>0x34){ SetScrollValue(scroll_rgb_b,Ox32[OxOae3b[0xc]]/0x100) ;} ;} ; OnUpdate(Ox32) ; clearTimeout(update_timer) ; update_timer=setTimeout(UpdateInternal,Ox5f?0x1:updatedelay) ;} finally{ isupdating=false ;} ;}  ; function UpdateInternal(){ usesafe=cb_safe[OxOae3b[0x0]] ; yxs[sely][selx][OxOae3b[0x2]][OxOae3b[0x1]]=OxOae3b[0xd] ;if(needupdatez){for(var Ox2e=0x0;Ox2e<=zcount;Ox2e++){ zs[Ox2e][OxOae3b[0x2]][OxOae3b[0x9]]=GetRgbBy(Ox2e*0x100/zcount,sely*0x100/yxcount,selx*0x100/yxcount,true).toString() ;} ;} ;if(needupdateyx){for(var Ox2f=0x0;Ox2f<=yxcount;Ox2f++){for(var Ox30=0x0;Ox30<=yxcount;Ox30++){ yxs[Ox2f][Ox30][OxOae3b[0x2]][OxOae3b[0x9]]=GetRgbBy(selz*0x100/zcount,Ox2f*0x100/yxcount,Ox30*0x100/yxcount,false).toString() ;} ;} ;} ; needupdateyx=true ; needupdatez=true ;}  ; function Initialize(){for(var Ox2f=0x0;Ox2f<=yxcount;Ox2f++){var Ox63=[];for(var Ox30=0x0;Ox30<=yxcount;Ox30++){var Ox64=yxtable[OxOae3b[0xf]][Ox2f][OxOae3b[0xe]][Ox30]; Ox64[OxOae3b[0x4]]=Ox30 ; Ox64[OxOae3b[0x5]]=Ox2f ; Ox63[Ox30]=Ox64 ;} ; yxs[Ox2f]=Ox63 ;} ;for(var Ox2e=0x0;Ox2e<=zcount;Ox2e++){var Ox64=ztable[OxOae3b[0xf]][Ox2e][OxOae3b[0xe]][0x0]; Ox64[OxOae3b[0x6]]=Ox2e ; zs[Ox2e]=Ox64 ;} ; Update(true) ;}  ; document[OxOae3b[0x10]]=function (){ downyx=false ; downz=false ;}  ; function YSDown(Ox64){ downyx=true ; Update() ;}  ; function YSMove(Ox64){if(downyx&&yxs[sely][selx]!=Ox64){ yxs[sely][selx][OxOae3b[0x2]][OxOae3b[0x1]]=OxOae3b[0x3] ; needupdateyx=false ; sely=Ox64[OxOae3b[0x5]] ; selx=Ox64[OxOae3b[0x4]] ; Update() ;} ;}  ; function YSUp(Ox64){ yxs[sely][selx][OxOae3b[0x2]][OxOae3b[0x1]]=OxOae3b[0x3] ; needupdateyx=false ; sely=Ox64[OxOae3b[0x5]] ; selx=Ox64[OxOae3b[0x4]] ; Update() ;}  ; function ZDown(Ox64){ downz=true ;}  ; function ZMove(Ox64){if(downz){ needupdatez=false ; selz=Ox64[OxOae3b[0x6]] ; Update() ;} ;}  ; function ZUp(Ox64){ downz=false ; needupdatez=false ; selz=Ox64[OxOae3b[0x6]] ; Update() ;}  ; function GetScrollValue(Ox6c){return Ox6c[OxOae3b[0x11]]/(Ox6c[OxOae3b[0x13]]-Ox6c[OxOae3b[0x12]]);}  ; function SetScrollValue(Ox6c,Ox60){ Ox6c[OxOae3b[0x11]]=Ox60*(Ox6c[OxOae3b[0x13]]-Ox6c[OxOae3b[0x12]]) ;}  ; rgb_r[OxOae3b[0x14]]=function (){if(isupdating){return ;} ; HandleUIChanged( new RgbClass(parseInt(rgb_r.value),parseInt(rgb_g.value),parseInt(rgb_b.value))) ;}  ; scroll_rgb_r[OxOae3b[0x15]]=function (){if(isupdating){return ;} ;var Oxe=GetScrollValue(scroll_rgb_r); rgb_r[OxOae3b[0x8]]=0x100*Oxe ; firebyscroll=true ;try{ HandleUIChanged( new RgbClass(parseInt(rgb_r.value),parseInt(rgb_g.value),parseInt(rgb_b.value))) ;} finally{ firebyscroll=false ;} ;}  ; rgb_g[OxOae3b[0x14]]=function (){if(isupdating){return ;} ; HandleUIChanged( new RgbClass(parseInt(rgb_r.value),parseInt(rgb_g.value),parseInt(rgb_b.value))) ;}  ; scroll_rgb_g[OxOae3b[0x15]]=function (){if(isupdating){return ;} ;var Oxe=GetScrollValue(scroll_rgb_g); rgb_g[OxOae3b[0x8]]=0x100*Oxe ; firebyscroll=true ;try{ HandleUIChanged( new RgbClass(parseInt(rgb_r.value),parseInt(rgb_g.value),parseInt(rgb_b.value))) ;} finally{ firebyscroll=false ;} ;}  ; rgb_b[OxOae3b[0x14]]=function (){if(isupdating){return ;} ; HandleUIChanged( new RgbClass(parseInt(rgb_r.value),parseInt(rgb_g.value),parseInt(rgb_b.value))) ;}  ; scroll_rgb_b[OxOae3b[0x15]]=function (){if(isupdating){return ;} ;var Oxe=GetScrollValue(scroll_rgb_b); rgb_b[OxOae3b[0x8]]=0x100*Oxe ; firebyscroll=true ;try{ HandleUIChanged( new RgbClass(parseInt(rgb_r.value),parseInt(rgb_g.value),parseInt(rgb_b.value))) ;} finally{ firebyscroll=false ;} ;}  ;


</script>
<script type="text/javascript">
var OxO787f=["onload","dialogArguments","string","object","onchange","onkeydown","event","keyCode","returnValue","checked","href","ColorPicker.Aspx?Quality=","\x26[[DNN_Arg]]","value","backgroundColor","style","[[ValidColor]]","","color1","color2"]; function OnUpdate1(Ox70){}  ; function OnUpdate2(Ox1b){ OnUpdate1(Ox1b.toString()) ;}  ; window[OxO787f[0x0]]=function (){ Initialize() ;if(top[OxO787f[0x1]]){if( typeof (top[OxO787f[0x1]])==OxO787f[0x2]){ HandleUIChanged(ParseRgb(top.dialogArguments)) ;} else {if( typeof (top[OxO787f[0x1]])==OxO787f[0x3]){if(top[OxO787f[0x1]][OxO787f[0x4]]){ OnUpdate1=top[OxO787f[0x1]][OxO787f[0x4]] ; OnUpdate=OnUpdate2 ;} ; HandleUIChanged(ParseRgb(top[OxO787f[0x1]].color)) ;} ;} ;} ;}  ; document[OxO787f[0x5]]=function (Ox72){ Ox72=Ox72||window[OxO787f[0x6]] ;if(Ox72[OxO787f[0x7]]==0x1b){ top[OxO787f[0x8]]=false ; top.close() ;} ;}  ;switch(yxExponent){case 0x3: radio_qlt_low[OxO787f[0x9]]=true ;break ;case 0x4: radio_qlt_medium[OxO787f[0x9]]=true ;break ;case 0x5: radio_qlt_high[OxO787f[0x9]]=true ;break ;case 0x6: radio_qlt_veryhigh[OxO787f[0x9]]=true ;break ;;;;;} ; ChangeQuanlity=ChangeQuanlity2 ; function ChangeQuanlity(){}  ; function ChangeQuanlity2(){var Ox75=0x4;if(radio_qlt_low[OxO787f[0x9]]){ Ox75=0x3 ;} ;if(radio_qlt_medium[OxO787f[0x9]]){ Ox75=0x4 ;} ;if(radio_qlt_high[OxO787f[0x9]]){ Ox75=0x5 ;} ;if(radio_qlt_veryhigh[OxO787f[0x9]]){ Ox75=0x6 ;} ;if(Ox75!=yxExponent){ location[OxO787f[0xa]]=OxO787f[0xb]+Ox75+OxO787f[0xc] ;} ;}  ; function do_ok(){try{ divpreview[OxO787f[0xf]][OxO787f[0xe]]=val_v[OxO787f[0xd]] ;} catch(er){ alert(OxO787f[0x10]) ; val_v[OxO787f[0xd]]=OxO787f[0x11] ;return false;} ;var Ox60=val_v[OxO787f[0xd]];var obj=Window_GetDialogArguments(window);if(obj){var Ox77=obj[OxO787f[0x12]];if(Ox77){ Ox77[OxO787f[0xf]][OxO787f[0xe]]=Ox60 ;if(Ox77[OxO787f[0xd]]){ Ox77[OxO787f[0xd]]=Ox60 ;} ;} ;var Ox78=obj[OxO787f[0x13]];if(Ox78){ Ox78[OxO787f[0xf]][OxO787f[0xe]]=Ox60 ;if(Ox78[OxO787f[0xd]]){ Ox78[OxO787f[0xd]]=Ox60 ;} ;} ;} ; Window_SetDialogReturnValue(window,Ox60) ; Window_CloseDialog(window) ;}  ; function do_cancel(){ Window_CloseDialog(window) ;}  ;

</script>
