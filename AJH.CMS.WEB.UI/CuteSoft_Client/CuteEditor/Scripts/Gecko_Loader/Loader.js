var OxO109a=["ua","userAgent","isOpera","opera","isSafari","safari","isGecko","gecko","isWinIE","msie","compatMode","document","CSS1Compat","undefined","Microsoft.XMLHTTP","readyState","onreadystatechange","","length","all","childNodes","nodeType","\x0D\x0A","caller","onchange","oninitialized","command","commandui","commandvalue","returnValue","oncommand","string","_fireEventFunction","event","parentNode","_IsCuteEditor","True","value","arguments","target","nodeName","SELECT","OPTION","readOnly","_IsRichDropDown","null","selectedIndex","TR","cells","display","style","nextSibling","innerHTML","\x3Cimg src=\x22","/Load.ashx?type=image\x26file=t-minus.gif\x22\x3E","onclick","CuteEditor_CollapseTreeDropDownItem(this,\x22","\x22)","none","/Load.ashx?type=image\x26file=t-plus.gif\x22\x3E","CuteEditor_ExpandTreeDropDownItem(this,\x22","contains","UNSELECTABLE","on","tabIndex","-1","//TODO: event not found? throw error ?","contentWindow","contentDocument","parentWindow","id","frames","frameElement","//TODO:frame contentWindow not found?","preventDefault","parent","top","opener","head","script","language","javascript","type","text/javascript","src","srcElement","//TODO: srcElement not found? throw error ?","fromElement","relatedTarget","toElement","keyCode","clientX","clientY","offsetX","offsetY","button","ctrlKey","altKey","shiftKey","cancelBubble","stopPropagation","CuteEditor_GetEditor(this).ExecImageCommand(this.getAttribute(\x27Command\x27),this.getAttribute(\x27CommandUI\x27),this.getAttribute(\x27CommandArgument\x27),this)","CuteEditor_GetEditor(this).PostBack(this.getAttribute(\x27Command\x27))","this.onmouseout();CuteEditor_GetEditor(this).DropMenu(this.getAttribute(\x27Group\x27),this)","ResourceDir","Theme","/Load.ashx?type=theme\x26theme=","\x26file=all.png","/Images/blank2020.gif","IMG","alt","title","Command","Group","ThemeIndex","width","20px","height","backgroundImage","url(",")","backgroundPosition","0 -","px","onload","className","separator","CuteEditorButton","onmouseover","CuteEditor_ButtonCommandOver(this)","onmouseout","CuteEditor_ButtonCommandOut(this)","onmousedown","CuteEditor_ButtonCommandDown(this)","onmouseup","CuteEditor_ButtonCommandUp(this)","oncontextmenu","ondragstart","PostBack","ondblclick","_ToolBarID","_CodeViewToolBarID","_FrameID"," CuteEditorFrame"," CuteEditorToolbar","cursor","no-drop","ActiveTab","Edit","Code","View","buttonInitialized","isover","CuteEditorButtonOver","CuteEditorButtonDown","CuteEditorDown","border","solid 1px #0A246A","backgroundColor","#b6bdd2","padding","1px","solid 1px #f5f5f4","inset 1px","IsCommandDisabled","CuteEditorButtonDisabled","IsCommandActive","CuteEditorButtonActive","cmd_fromfullpage","(","href","location",",DanaInfo=",",","+","scriptProperties","initfuncbecalled","GetScriptProperty","/Load.ashx?type=scripts\x26file=Gecko_Implementation\x26culture=","Culture","CuteEditorImplementation","function","POST","\x26getModified=1\x26_temp=","status","responseText","GET","\x26modified=","body","block","contentEditable","InitializeCode","CuteEditorInitialize"];var _Browser_TypeInfo=null;function Browser__InitType(){if(_Browser_TypeInfo!=null){return ;} ;var Ox4={};Ox4[OxO109a[0]]=navigator[OxO109a[1]].toLowerCase();Ox4[OxO109a[2]]=(Ox4[OxO109a[0]].indexOf(OxO109a[3])>-1);Ox4[OxO109a[4]]=(Ox4[OxO109a[0]].indexOf(OxO109a[5])>-1);Ox4[OxO109a[6]]=(!Ox4[OxO109a[2]]&&Ox4[OxO109a[0]].indexOf(OxO109a[7])>-1);Ox4[OxO109a[8]]=(!Ox4[OxO109a[2]]&&Ox4[OxO109a[0]].indexOf(OxO109a[9])>-1);_Browser_TypeInfo=Ox4;} ;Browser__InitType();function Browser_IsWinIE(){return _Browser_TypeInfo[OxO109a[8]];} ;function Browser_IsGecko(){return _Browser_TypeInfo[OxO109a[6]];} ;function Browser_IsOpera(){return _Browser_TypeInfo[OxO109a[2]];} ;function Browser_IsSafari(){return _Browser_TypeInfo[OxO109a[4]];} ;function Browser_UseIESelection(){return _Browser_TypeInfo[OxO109a[8]];} ;function Browser_IsCSS1Compat(){return window[OxO109a[11]][OxO109a[10]]==OxO109a[12];} ;function CreateXMLHttpRequest(){try{if( typeof (XMLHttpRequest)!=OxO109a[13]){return  new XMLHttpRequest();} ;if( typeof (ActiveXObject)!=OxO109a[13]){return  new ActiveXObject(OxO109a[14]);} ;} catch(x){return null;} ;} ;function LoadXMLAsync(Oxa29,Ox286,Ox231,Oxa2a){var Oxe6=CreateXMLHttpRequest();function Oxa2b(){if(Oxe6[OxO109a[15]]!=4){return ;} ;Oxe6[OxO109a[16]]= new Function();var Ox28e=Oxe6;Oxe6=null;if(Ox231){Ox231(Ox28e);} ;} ;Oxe6[OxO109a[16]]=Oxa2b;Oxe6.open(Oxa29,Ox286,true);Oxe6.send(Oxa2a||OxO109a[17]);} ;function Element_GetAllElements(p){var arr=[];if(Browser_IsWinIE()){for(var i=0;i<p[OxO109a[19]][OxO109a[18]];i++){arr.push(p[OxO109a[19]].item(i));} ;return arr;} ;Ox23e(p);function Ox23e(Ox29){var Ox23f=Ox29[OxO109a[20]];var Ox11=Ox23f[OxO109a[18]];for(var i=0;i<Ox11;i++){var Ox27=Ox23f.item(i);if(Ox27[OxO109a[21]]!=1){continue ;} ;arr.push(Ox27);Ox23e(Ox27);} ;} ;return arr;} ;var __ISDEBUG=false;function Debug_Todo(msg){if(!__ISDEBUG){return ;} ;throw ( new Error(msg+OxO109a[22]+Debug_Todo[OxO109a[23]]));} ;function Window_GetElement(Ox1a7,Ox99,Ox23c){var Ox29=Ox1a7[OxO109a[11]].getElementById(Ox99);if(Ox29){return Ox29;} ;var Ox31=Ox1a7[OxO109a[11]].getElementsByName(Ox99);if(Ox31[OxO109a[18]]>0){return Ox31.item(0);} ;return null;} ;function CuteEditor_AddMainMenuItems(Ox665){} ;function CuteEditor_AddDropMenuItems(Ox665,Ox66c){} ;function CuteEditor_AddTagMenuItems(Ox665,Ox66e){} ;function CuteEditor_AddVerbMenuItems(Ox665,Ox66e){} ;function CuteEditor_OnInitialized(editor){} ;function CuteEditor_OnCommand(editor,Ox4d,Ox4e,Ox4f){} ;function CuteEditor_OnChange(editor){} ;function CuteEditor_FilterCode(editor,Ox268){return Ox268;} ;function CuteEditor_FilterHTML(editor,Ox280){return Ox280;} ;function CuteEditor_FireChange(editor){window.CuteEditor_OnChange(editor);CuteEditor_FireEvent(editor,OxO109a[24],null);} ;function CuteEditor_FireInitialized(editor){window.CuteEditor_OnInitialized(editor);CuteEditor_FireEvent(editor,OxO109a[25],null);} ;function CuteEditor_FireCommand(editor,Ox4d,Ox4e,Ox4f){var Ox13d=window.CuteEditor_OnCommand(editor,Ox4d,Ox4e,Ox4f);if(Ox13d==true){return true;} ;var Ox677={};Ox677[OxO109a[26]]=Ox4d;Ox677[OxO109a[27]]=Ox4e;Ox677[OxO109a[28]]=Ox4f;Ox677[OxO109a[29]]=true;CuteEditor_FireEvent(editor,OxO109a[30],Ox677);if(Ox677[OxO109a[29]]==false){return true;} ;} ;function CuteEditor_FireEvent(editor,Ox679,Ox67a){if(Ox67a==null){Ox67a={};} ;var Ox67b=editor.getAttribute(Ox679);if(Ox67b){if( typeof (Ox67b)==OxO109a[31]){editor[OxO109a[32]]= new Function(OxO109a[33],Ox67b);} else {editor[OxO109a[32]]=Ox67b;} ;editor._fireEventFunction(Ox67a);} ;} ;function CuteEditor_GetEditor(element){for(var Ox43=element;Ox43!=null;Ox43=Ox43[OxO109a[34]]){if(Ox43.getAttribute(OxO109a[35])==OxO109a[36]){return Ox43;} ;} ;return null;} ;function CuteEditor_DropDownCommand(element,Oxa2d){var Ox141=element[OxO109a[37]];if(CuteEditor_DropDownCommand[OxO109a[23]]){var Ox43=CuteEditor_DropDownCommand[OxO109a[23]][OxO109a[38]][0];if(Ox43&&Ox43[OxO109a[39]]){if(Ox43[OxO109a[39]][OxO109a[40]]==OxO109a[41]){return ;} ;if(Ox43[OxO109a[39]][OxO109a[40]]==OxO109a[42]){Ox141=Ox43[OxO109a[39]][OxO109a[37]];} ;} ;} ;var editor=CuteEditor_GetEditor(element);if(editor[OxO109a[43]]){return ;} ;if(element.getAttribute(OxO109a[44])==OxO109a[36]){var Ox141=element.GetValue();if(Ox141==OxO109a[45]){Ox141=OxO109a[17];} ;var Ox200=element.GetText();if(Ox200==OxO109a[45]){Ox200=OxO109a[17];} ;element.SetSelectedIndex(0);editor.ExecCommand(Oxa2d,false,Ox141,Ox200);} else {if(Ox141){if(Ox141==OxO109a[45]){Ox141=OxO109a[17];} ;element[OxO109a[46]]=0;editor.ExecCommand(Oxa2d,false,Ox141,Ox200);} else {element[OxO109a[46]]=0;} ;} ;editor.FocusDocument();} ;function CuteEditor_ExpandTreeDropDownItem(src,Ox73b){var Oxb9=null;while(src!=null){if(src[OxO109a[40]]==OxO109a[47]){Oxb9=src;break ;} ;src=src[OxO109a[34]];} ;var Ox1e3=Oxb9[OxO109a[48]].item(0);Oxb9[OxO109a[51]][OxO109a[50]][OxO109a[49]]=OxO109a[17];Ox1e3[OxO109a[52]]=OxO109a[53]+Ox73b+OxO109a[54];Oxb9[OxO109a[55]]= new Function(OxO109a[56]+Ox73b+OxO109a[57]);} ;function CuteEditor_CollapseTreeDropDownItem(src,Ox73b){var Oxb9=null;while(src!=null){if(src[OxO109a[40]]==OxO109a[47]){Oxb9=src;break ;} ;src=src[OxO109a[34]];} ;var Ox1e3=Oxb9[OxO109a[48]].item(0);Oxb9[OxO109a[51]][OxO109a[50]][OxO109a[49]]=OxO109a[58];Ox1e3[OxO109a[52]]=OxO109a[53]+Ox73b+OxO109a[59];Oxb9[OxO109a[55]]= new Function(OxO109a[60]+Ox73b+OxO109a[57]);} ;function Element_Contains(element,Ox182){if(!Browser_IsOpera()){if(element[OxO109a[61]]){return element.contains(Ox182);} ;} ;for(;Ox182!=null;Ox182=Ox182[OxO109a[34]]){if(element==Ox182){return true;} ;} ;return false;} ;function Element_SetUnselectable(element){element.setAttribute(OxO109a[62],OxO109a[63]);element.setAttribute(OxO109a[64],OxO109a[65]);var arr=Element_GetAllElements(element);var len=arr[OxO109a[18]];if(!len){return ;} ;for(var i=0;i<len;i++){arr[i].setAttribute(OxO109a[62],OxO109a[63]);arr[i].setAttribute(OxO109a[64],OxO109a[65]);} ;} ;function Event_GetEvent(Ox242){Ox242=Event_FindEvent(Ox242);if(Ox242==null){Debug_Todo(OxO109a[66]);} ;return Ox242;} ;function Frame_GetContentWindow(Ox347){if(Ox347[OxO109a[67]]){return Ox347[OxO109a[67]];} ;if(Ox347[OxO109a[68]]){if(Ox347[OxO109a[68]][OxO109a[69]]){return Ox347[OxO109a[68]][OxO109a[69]];} ;} ;var Ox1a7;if(Ox347[OxO109a[70]]){Ox1a7=window[OxO109a[71]][Ox347[OxO109a[70]]];if(Ox1a7){return Ox1a7;} ;} ;var len=window[OxO109a[71]][OxO109a[18]];for(var i=0;i<len;i++){Ox1a7=window[OxO109a[71]][i];if(Ox1a7[OxO109a[72]]==Ox347){return Ox1a7;} ;if(Ox1a7[OxO109a[11]]==Ox347[OxO109a[68]]){return Ox1a7;} ;} ;Debug_Todo(OxO109a[73]);} ;function Array_IndexOf(arr,Ox244){for(var i=0;i<arr[OxO109a[18]];i++){if(arr[i]==Ox244){return i;} ;} ;return -1;} ;function Array_Contains(arr,Ox244){return Array_IndexOf(arr,Ox244)!=-1;} ;function Event_FindEvent(Ox242){if(Ox242&&Ox242[OxO109a[74]]){return Ox242;} ;if(Browser_IsGecko()){return Event_FindEvent_FindEventFromCallers();} else {if(window[OxO109a[33]]){return window[OxO109a[33]];} ;return Event_FindEvent_FindEventFromWindows();} ;return null;} ;function Event_FindEvent_FindEventFromCallers(){var Ox18e=Event_GetEvent[OxO109a[23]];for(var i=0;i<100;i++){if(!Ox18e){break ;} ;var Ox242=Ox18e[OxO109a[38]][0];if(Ox242&&Ox242[OxO109a[74]]){return Ox242;} ;Ox18e=Ox18e[OxO109a[23]];} ;} ;function Event_FindEvent_FindEventFromWindows(){var arr=[];return Ox24b(window);function Ox24b(Ox1a7){if(Ox1a7==null){return null;} ;if(Ox1a7[OxO109a[33]]){return Ox1a7[OxO109a[33]];} ;if(Array_Contains(arr,Ox1a7)){return null;} ;arr.push(Ox1a7);var Ox24c=[];if(Ox1a7[OxO109a[75]]!=Ox1a7){Ox24c.push(Ox1a7.parent);} ;if(Ox1a7[OxO109a[76]]!=Ox1a7[OxO109a[75]]){Ox24c.push(Ox1a7.top);} ;if(Ox1a7[OxO109a[77]]){Ox24c.push(Ox1a7.opener);} ;for(var i=0;i<Ox1a7[OxO109a[71]][OxO109a[18]];i++){Ox24c.push(Ox1a7[OxO109a[71]][i]);} ;for(var i=0;i<Ox24c[OxO109a[18]];i++){try{var Ox242=Ox24b(Ox24c[i]);if(Ox242){return Ox242;} ;} catch(x){} ;} ;return null;} ;} ;function include(Oxc8,Ox286){var Ox287=document.getElementsByTagName(OxO109a[78]).item(0);var Ox288=document.getElementById(Oxc8);if(Ox288){Ox287.removeChild(Ox288);} ;var Ox289=document.createElement(OxO109a[79]);Ox289.setAttribute(OxO109a[80],OxO109a[81]);Ox289.setAttribute(OxO109a[82],OxO109a[83]);Ox289.setAttribute(OxO109a[84],Ox286);Ox289.setAttribute(OxO109a[70],Oxc8);Ox287.appendChild(Ox289);} ;function Event_GetSrcElement(Ox242){Ox242=Event_GetEvent(Ox242);if(Ox242[OxO109a[85]]){return Ox242[OxO109a[85]];} ;if(Ox242[OxO109a[39]]){return Ox242[OxO109a[39]];} ;Debug_Todo(OxO109a[86]);return null;} ;function Event_GetFromElement(Ox242){Ox242=Event_GetEvent(Ox242);if(Ox242[OxO109a[87]]){return Ox242[OxO109a[87]];} ;if(Ox242[OxO109a[88]]){return Ox242[OxO109a[88]];} ;return null;} ;function Event_GetToElement(Ox242){Ox242=Event_GetEvent(Ox242);if(Ox242[OxO109a[89]]){return Ox242[OxO109a[89]];} ;if(Ox242[OxO109a[88]]){return Ox242[OxO109a[88]];} ;return null;} ;function Event_GetKeyCode(Ox242){Ox242=Event_GetEvent(Ox242);return Ox242[OxO109a[90]];} ;function Event_GetClientX(Ox242){Ox242=Event_GetEvent(Ox242);return Ox242[OxO109a[91]];} ;function Event_GetClientY(Ox242){Ox242=Event_GetEvent(Ox242);return Ox242[OxO109a[92]];} ;function Event_GetOffsetX(Ox242){Ox242=Event_GetEvent(Ox242);return Ox242[OxO109a[93]];} ;function Event_GetOffsetY(Ox242){Ox242=Event_GetEvent(Ox242);return Ox242[OxO109a[94]];} ;function Event_IsLeftButton(Ox242){Ox242=Event_GetEvent(Ox242);if(Browser_IsWinIE()){return Ox242[OxO109a[95]]==1;} ;if(Browser_IsGecko()){return Ox242[OxO109a[95]]==0;} ;return Ox242[OxO109a[95]]==0;} ;function Event_IsCtrlKey(Ox242){Ox242=Event_GetEvent(Ox242);return Ox242[OxO109a[96]];} ;function Event_IsAltKey(Ox242){Ox242=Event_GetEvent(Ox242);return Ox242[OxO109a[97]];} ;function Event_IsShiftKey(Ox242){Ox242=Event_GetEvent(Ox242);return Ox242[OxO109a[98]];} ;function Event_PreventDefault(Ox242){Ox242=Event_GetEvent(Ox242);Ox242[OxO109a[29]]=false;if(Ox242[OxO109a[74]]){Ox242.preventDefault();} ;} ;function Event_CancelBubble(Ox242){Ox242=Event_GetEvent(Ox242);Ox242[OxO109a[99]]=true;if(Ox242[OxO109a[100]]){Ox242.stopPropagation();} ;return false;} ;function Event_CancelEvent(Ox242){Ox242=Event_GetEvent(Ox242);Event_PreventDefault(Ox242);return Event_CancelBubble(Ox242);} ;function CuteEditor_BasicInitialize(editor){var Ox157=Browser_IsOpera();var Ox704= new Function(OxO109a[101]);var Oxa31= new Function(OxO109a[102]);var Oxa32= new Function(OxO109a[103]);var Oxa33=editor.GetScriptProperty(OxO109a[104]);var Oxa34=editor.GetScriptProperty(OxO109a[105]);var Oxa35=Oxa33+OxO109a[106]+Oxa34+OxO109a[107];var Oxa36=Oxa33+OxO109a[108];var images=editor.getElementsByTagName(OxO109a[109]);var len=images[OxO109a[18]];for(var i=0;i<len;i++){var img=images[i];if(img.getAttribute(OxO109a[110])&&!img.getAttribute(OxO109a[111])){img.setAttribute(OxO109a[111],img.getAttribute(OxO109a[110]));} ;var Ox134=img.getAttribute(OxO109a[112]);var Ox66c=img.getAttribute(OxO109a[113]);if(!(Ox134||Ox66c)){continue ;} ;var Oxa37=img.getAttribute(OxO109a[114]);if(parseInt(Oxa37)>=0){img[OxO109a[50]][OxO109a[115]]=OxO109a[116];img[OxO109a[50]][OxO109a[117]]=OxO109a[116];img[OxO109a[84]]=Oxa36;img[OxO109a[50]][OxO109a[118]]=OxO109a[119]+Oxa35+OxO109a[120];img[OxO109a[50]][OxO109a[121]]=OxO109a[122]+(Oxa37*20)+OxO109a[123];img[OxO109a[50]][OxO109a[49]]=OxO109a[17];} ;if(!Ox134&&!Ox66c){if(Ox157){img[OxO109a[124]]=CuteEditor_OperaHandleImageLoaded;} ;continue ;} ;if(img[OxO109a[125]]!=OxO109a[126]){img[OxO109a[125]]=OxO109a[127];img[OxO109a[128]]= new Function(OxO109a[129]);img[OxO109a[130]]= new Function(OxO109a[131]);img[OxO109a[132]]= new Function(OxO109a[133]);img[OxO109a[134]]= new Function(OxO109a[135]);} ;if(!img[OxO109a[136]]){img[OxO109a[136]]=Event_CancelEvent;} ;if(!img[OxO109a[137]]){img[OxO109a[137]]=Event_CancelEvent;} ;if(Ox134){var Ox18e=img.getAttribute(OxO109a[138])==OxO109a[36]?Oxa31:Ox704;if(img[OxO109a[55]]==null){img[OxO109a[55]]=Ox18e;} ;if(img[OxO109a[139]]==null){img[OxO109a[139]]=Ox18e;} ;} else {if(Ox66c){if(img[OxO109a[55]]==null){img[OxO109a[55]]=Oxa32;} ;} ;} ;} ;var Ox771=Window_GetElement(window,editor.GetScriptProperty(OxO109a[140]),true);var Ox772=Window_GetElement(window,editor.GetScriptProperty(OxO109a[141]),true);var Ox76d=Window_GetElement(window,editor.GetScriptProperty(OxO109a[142]),true);Ox76d[OxO109a[125]]+=OxO109a[143];Ox771[OxO109a[125]]+=OxO109a[144];Ox772[OxO109a[125]]+=OxO109a[144];Element_SetUnselectable(Ox771);Element_SetUnselectable(Ox772);try{editor[OxO109a[50]][OxO109a[145]]=OxO109a[146];} catch(x){} ;var Ox7f4=editor.GetScriptProperty(OxO109a[147]);switch(Ox7f4){case OxO109a[148]:Ox771[OxO109a[50]][OxO109a[49]]=OxO109a[17];break ;;case OxO109a[149]:Ox772[OxO109a[50]][OxO109a[49]]=OxO109a[17];break ;;case OxO109a[150]:break ;;} ;} ;function CuteEditor_OperaHandleImageLoaded(){var img=this;if(img[OxO109a[50]][OxO109a[49]]){img[OxO109a[50]][OxO109a[49]]=OxO109a[58];setTimeout(function Oxa39(){img[OxO109a[50]][OxO109a[49]]=OxO109a[17];} ,1);} ;} ;function CuteEditor_ButtonOver(element){if(!element[OxO109a[151]]){element[OxO109a[136]]=Event_CancelEvent;element[OxO109a[130]]=CuteEditor_ButtonOut;element[OxO109a[132]]=CuteEditor_ButtonDown;element[OxO109a[134]]=CuteEditor_ButtonUp;Element_SetUnselectable(element);element[OxO109a[151]]=true;} ;element[OxO109a[152]]=true;element[OxO109a[125]]=OxO109a[153];} ;function CuteEditor_ButtonOut(){var element=this;element[OxO109a[125]]=OxO109a[127];element[OxO109a[152]]=false;} ;function CuteEditor_ButtonDown(){if(!Event_IsLeftButton()){return ;} ;var element=this;element[OxO109a[125]]=OxO109a[154];} ;function CuteEditor_ButtonUp(){if(!Event_IsLeftButton()){return ;} ;var element=this;if(element[OxO109a[152]]){element[OxO109a[125]]=OxO109a[153];} else {element[OxO109a[125]]=OxO109a[155];} ;} ;function CuteEditor_ColorPicker_ButtonOver(element){if(!element[OxO109a[151]]){element[OxO109a[136]]=Event_CancelEvent;element[OxO109a[130]]=CuteEditor_ColorPicker_ButtonOut;element[OxO109a[132]]=CuteEditor_ColorPicker_ButtonDown;Element_SetUnselectable(element);element[OxO109a[151]]=true;} ;element[OxO109a[152]]=true;element[OxO109a[50]][OxO109a[156]]=OxO109a[157];element[OxO109a[50]][OxO109a[158]]=OxO109a[159];element[OxO109a[50]][OxO109a[160]]=OxO109a[161];} ;function CuteEditor_ColorPicker_ButtonOut(){var element=this;element[OxO109a[152]]=false;element[OxO109a[50]][OxO109a[156]]=OxO109a[162];element[OxO109a[50]][OxO109a[158]]=OxO109a[17];element[OxO109a[50]][OxO109a[160]]=OxO109a[161];} ;function CuteEditor_ColorPicker_ButtonDown(){var element=this;element[OxO109a[50]][OxO109a[156]]=OxO109a[163];element[OxO109a[50]][OxO109a[158]]=OxO109a[17];element[OxO109a[50]][OxO109a[160]]=OxO109a[161];} ;function CuteEditor_ButtonCommandOver(element){element[OxO109a[152]]=true;if(element[OxO109a[164]]){element[OxO109a[125]]=OxO109a[165];} else {element[OxO109a[125]]=OxO109a[153];} ;} ;function CuteEditor_ButtonCommandOut(element){element[OxO109a[152]]=false;if(element[OxO109a[166]]){element[OxO109a[125]]=OxO109a[167];} else {if(element[OxO109a[164]]){element[OxO109a[125]]=OxO109a[165];} else {if(element[OxO109a[70]]!=OxO109a[168]){element[OxO109a[125]]=OxO109a[127];} ;} ;} ;} ;function CuteEditor_ButtonCommandDown(element){if(!Event_IsLeftButton()){return ;} ;element[OxO109a[125]]=OxO109a[154];} ;function CuteEditor_ButtonCommandUp(element){if(!Event_IsLeftButton()){return ;} ;if(element[OxO109a[164]]){element[OxO109a[125]]=OxO109a[165];return ;} ;if(element[OxO109a[152]]){element[OxO109a[125]]=OxO109a[153];} else {if(element[OxO109a[166]]){element[OxO109a[125]]=OxO109a[167];} else {element[OxO109a[125]]=OxO109a[127];} ;} ;} ;var CuteEditorGlobalFunctions=[CuteEditor_GetEditor,CuteEditor_ButtonOver,CuteEditor_ButtonOut,CuteEditor_ButtonDown,CuteEditor_ButtonUp,CuteEditor_ColorPicker_ButtonOver,CuteEditor_ColorPicker_ButtonOut,CuteEditor_ColorPicker_ButtonDown,CuteEditor_ButtonCommandOver,CuteEditor_ButtonCommandOut,CuteEditor_ButtonCommandDown,CuteEditor_ButtonCommandUp,CuteEditor_DropDownCommand,CuteEditor_ExpandTreeDropDownItem,CuteEditor_CollapseTreeDropDownItem,CuteEditor_OnInitialized,CuteEditor_OnCommand,CuteEditor_OnChange,CuteEditor_AddVerbMenuItems,CuteEditor_AddTagMenuItems,CuteEditor_AddMainMenuItems,CuteEditor_AddDropMenuItems,CuteEditor_FilterCode,CuteEditor_FilterHTML];function SetupCuteEditorGlobalFunctions(){for(var i=0;i<CuteEditorGlobalFunctions[OxO109a[18]];i++){var Ox18e=CuteEditorGlobalFunctions[i];var name=Ox18e+OxO109a[17];name=name.substr(8,name.indexOf(OxO109a[169])-8).replace(/\s/g,OxO109a[17]);if(!window[name]){window[name]=Ox18e;} ;} ;} ;SetupCuteEditorGlobalFunctions();var __danainfo=null;var danaurl=window[OxO109a[171]][OxO109a[170]];var danapos=danaurl.indexOf(OxO109a[172]);if(danapos!=-1){var pluspos1=danaurl.indexOf(OxO109a[173],danapos+10);var pluspos2=danaurl.indexOf(OxO109a[174],danapos+10);if(pluspos1!=-1&&pluspos1<pluspos2){pluspos2=pluspos1;} ;__danainfo=danaurl.substring(danapos,pluspos2)+OxO109a[174];} ;function CuteEditor_GetScriptProperty(name){var Ox141=this[OxO109a[175]][name];if(Ox141&&__danainfo){if(name==OxO109a[104]){return Ox141+__danainfo;} ;var Ox380=this[OxO109a[175]][OxO109a[104]];if(Ox141.substr(0,Ox380.length)==Ox380){return Ox380+__danainfo+Ox141.substring(Ox380.length);} ;} ;return Ox141;} ;function CuteEditor_SetScriptProperty(name,Ox141){if(Ox141==null){this[OxO109a[175]][name]=null;} else {this[OxO109a[175]][name]=String(Ox141);} ;} ;function CuteEditorInitialize(Oxa44,Oxa45){var editor=Window_GetElement(window,Oxa44,true);if(editor[OxO109a[176]]){return ;} ;editor[OxO109a[176]]=1;editor[OxO109a[175]]=Oxa45;editor[OxO109a[177]]=CuteEditor_GetScriptProperty;var Ox76d=Window_GetElement(window,editor.GetScriptProperty(OxO109a[142]),true);var editwin,editdoc;try{editwin=Frame_GetContentWindow(Ox76d);editdoc=editwin[OxO109a[11]];} catch(x){} ;var Oxa46=false;var Oxa47;var Oxa48=false;var Oxa49=editor.GetScriptProperty(OxO109a[104])+OxO109a[178]+editor.GetScriptProperty(OxO109a[179]);function Oxa4a(){if( typeof (window[OxO109a[180]])==OxO109a[181]){return ;} ;LoadXMLAsync(OxO109a[182],Oxa49+OxO109a[183]+ new Date().getTime(),Oxa4b);} ;function Oxa4b(Ox28e){var Ox87e= new Date().getTime();if(Ox28e[OxO109a[184]]!=200){} else {Ox87e=Ox28e[OxO109a[185]];} ;LoadXMLAsync(OxO109a[186],Oxa49+OxO109a[187]+Ox87e,Oxa4c);} ;function Oxa4c(Ox28e){if(Ox28e[OxO109a[184]]!=200){return ;} ;CuteEditorInstallScriptCode(Ox28e.responseText,OxO109a[180]);if(Oxa46){Oxa4d();} ;} ;function Oxa4d(){if(Oxa48){return ;} ;Oxa48=true;try{editor[OxO109a[50]][OxO109a[145]]=OxO109a[17];} catch(x){} ;try{editdoc[OxO109a[188]][OxO109a[50]][OxO109a[145]]=OxO109a[17];} catch(x){} ;Ox76d[OxO109a[50]][OxO109a[49]]=OxO109a[189];if(Browser_IsOpera()){editdoc[OxO109a[188]][OxO109a[190]]=true;} else {} ;window.CuteEditorImplementation(editor);var Oxa4e=editor.GetScriptProperty(OxO109a[191]);if(Oxa4e){editor.Eval(Oxa4e);} ;} ;function Oxa4f(){if(!Element_Contains(window[OxO109a[11]].body,editor)){return ;} ;try{Ox76d=Window_GetElement(window,editor.GetScriptProperty(OxO109a[142]),true);editwin=Frame_GetContentWindow(Ox76d);editdoc=editwin[OxO109a[11]];var y=editdoc[OxO109a[188]];} catch(x){setTimeout(Oxa4f,100);return ;} ;if(!editdoc[OxO109a[188]]){setTimeout(Oxa4f,100);return ;} ;if(!Oxa46){Oxa46=true;setTimeout(Oxa4f,50);return ;} ;if( typeof (window[OxO109a[180]])==OxO109a[181]){Oxa4d();} else {try{editdoc[OxO109a[188]][OxO109a[50]][OxO109a[145]]=OxO109a[146];} catch(x){} ;} ;} ;var Oxa50=0;var Ox43=CuteEditor_Find_DisplayNone(editor);if(Ox43){function Oxa51(){if(Ox43[OxO109a[50]][OxO109a[49]]!=OxO109a[58]){window.clearInterval(Oxa50);Oxa50=OxO109a[17];editor[OxO109a[176]]=false;CuteEditorInitialize(Oxa44,Oxa45);} ;} ;Oxa50=setInterval(Oxa51,1000);} else {CuteEditor_BasicInitialize(editor);Oxa4a();Oxa4f();} ;function CuteEditor_Find_DisplayNone(element){var Oxa53;for(var Ox43=element;Ox43!=null;Ox43=Ox43[OxO109a[34]]){if(Ox43[OxO109a[50]]&&Ox43[OxO109a[50]][OxO109a[49]]==OxO109a[58]){Oxa53=Ox43;break ;} ;} ;return Oxa53;} ;} ;function CuteEditorInstallScriptCode(Ox9a9,Ox9aa){eval(Ox9a9);window[Ox9aa]=eval(Ox9aa);} ;window[OxO109a[192]]=CuteEditorInitialize;