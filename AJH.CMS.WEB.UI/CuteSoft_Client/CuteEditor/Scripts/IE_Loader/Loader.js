var OxO8061=["undefined","Microsoft.XMLHTTP","readyState","onreadystatechange","","document","length","element \x27","\x27 not found","returnValue","preventDefault","cancelBubble","stopPropagation","onchange","oninitialized","command","commandui","commandvalue","oncommand","string","_fireEventFunction","event","parentNode","_IsCuteEditor","True","readOnly","_IsRichDropDown","null","value","selectedIndex","nodeName","TR","cells","display","style","nextSibling","innerHTML","\x3Cimg src=\x22","/Load.ashx?type=image\x26file=t-minus.gif\x22\x3E","onclick","CuteEditor_CollapseTreeDropDownItem(this,\x22","\x22)","none","/Load.ashx?type=image\x26file=t-plus.gif\x22\x3E","CuteEditor_ExpandTreeDropDownItem(this,\x22","//TODO: event not found? throw error ?","all","UNSELECTABLE","on","tabIndex","-1","contentWindow","contentDocument","parentWindow","id","frames","frameElement","//TODO:frame contentWindow not found?","head","script","language","javascript","type","text/javascript","src","caller","arguments","parent","top","opener","srcElement","target","//TODO: srcElement not found? throw error ?","fromElement","relatedTarget","toElement","keyCode","clientX","clientY","offsetX","offsetY","button","ctrlKey","altKey","shiftKey","CuteEditor_GetEditor(this).ExecImageCommand(this.getAttribute(\x27Command\x27),this.getAttribute(\x27CommandUI\x27),this.getAttribute(\x27CommandArgument\x27),this)","CuteEditor_GetEditor(this).PostBack(this.getAttribute(\x27Command\x27))","this.onmouseout();CuteEditor_GetEditor(this).DropMenu(this.getAttribute(\x27Group\x27),this)","ResourceDir","Theme","/Load.ashx?type=theme\x26theme=","\x26file=all.png","/Images/blank2020.gif","IMG","alt","title","Command","Group","ThemeIndex","width","20px","height","backgroundImage","url(",")","backgroundPosition","0 -","px","className","separator","CuteEditorButton","onmouseover","CuteEditor_ButtonCommandOver(this)","onmouseout","CuteEditor_ButtonCommandOut(this)","onmousedown","CuteEditor_ButtonCommandDown(this)","onmouseup","CuteEditor_ButtonCommandUp(this)","oncontextmenu","ondragstart","PostBack","ondblclick","_ToolBarID","_CodeViewToolBarID","_FrameID"," CuteEditorFrame"," CuteEditorToolbar","buttonInitialized","isover","CuteEditorButtonOver","CuteEditorButtonDown","CuteEditorDown","border","solid 1px #0A246A","backgroundColor","#b6bdd2","padding","1px","solid 1px #f5f5f4","inset 1px","IsCommandDisabled","CuteEditorButtonDisabled","IsCommandActive","CuteEditorButtonActive","(","href","location",",DanaInfo=",",","+","scriptProperties","GetScriptProperty","/Load.ashx?type=scripts\x26file=IE_Implementation\x26culture=","Culture","/Load.ashx?type=scripts\x26file=EditorExtension\x26culture=","CuteEditorImplementation","function","POST","\x26getModified=1\x26_temp=","loadScript","status","responseText","GET","\x26modified=","Failed to load impl code!","block","contentEditable","body","cursor","InitializeCode","no-drop","CuteEditorInitialize"];function CreateXMLHttpRequest(){try{if( typeof (XMLHttpRequest)!=OxO8061[0]){return  new XMLHttpRequest();} ;if( typeof (ActiveXObject)!=OxO8061[0]){return  new ActiveXObject(OxO8061[1]);} ;} catch(x){return null;} ;} ;function LoadXMLAsync(Oxa37,Ox287,Ox234,Oxa38){var Oxe7=CreateXMLHttpRequest();function Oxa39(){if(Oxe7[OxO8061[2]]!=4){return ;} ;Oxe7[OxO8061[3]]= new Function();var Ox28f=Oxe7;Oxe7=null;Ox234(Ox28f);} ;Oxe7[OxO8061[3]]=Oxa39;Oxe7.open(Oxa37,Ox287,true);Oxe7.send(Oxa38||OxO8061[4]);} ;function Window_GetElement(Ox1a8,Ox9a,Ox23f){var Ox29=Ox1a8[OxO8061[5]].getElementById(Ox9a);if(Ox29){return Ox29;} ;var Ox31=Ox1a8[OxO8061[5]].getElementsByName(Ox9a);if(Ox31[OxO8061[6]]>0){return Ox31.item(0);} ;if(Ox23f){throw ( new Error(OxO8061[7]+Ox9a+OxO8061[8]));} ;return null;} ;function Event_PreventDefault(Ox244){Ox244=Event_GetEvent(Ox244);Ox244[OxO8061[9]]=false;if(Ox244[OxO8061[10]]){Ox244.preventDefault();} ;} ;function Event_CancelBubble(Ox244){Ox244=Event_GetEvent(Ox244);Ox244[OxO8061[11]]=true;if(Ox244[OxO8061[12]]){Ox244.stopPropagation();} ;return false;} ;function Event_CancelEvent(Ox244){Ox244=Event_GetEvent(Ox244);Event_PreventDefault(Ox244);return Event_CancelBubble(Ox244);} ;function CuteEditor_AddMainMenuItems(Ox667){} ;function CuteEditor_AddDropMenuItems(Ox667,Ox66e){} ;function CuteEditor_AddTagMenuItems(Ox667,Ox670){} ;function CuteEditor_AddVerbMenuItems(Ox667,Ox670){} ;function CuteEditor_OnInitialized(editor){} ;function CuteEditor_OnCommand(editor,Ox4d,Ox4e,Ox4f){} ;function CuteEditor_OnChange(editor){} ;function CuteEditor_FilterCode(editor,Ox26a){return Ox26a;} ;function CuteEditor_FilterHTML(editor,Ox282){return Ox282;} ;function CuteEditor_FireChange(editor){window.CuteEditor_OnChange(editor);CuteEditor_FireEvent(editor,OxO8061[13],null);} ;function CuteEditor_FireInitialized(editor){window.CuteEditor_OnInitialized(editor);CuteEditor_FireEvent(editor,OxO8061[14],null);} ;function CuteEditor_FireCommand(editor,Ox4d,Ox4e,Ox4f){var Ox13e=window.CuteEditor_OnCommand(editor,Ox4d,Ox4e,Ox4f);if(Ox13e==true){return true;} ;var Ox679={};Ox679[OxO8061[15]]=Ox4d;Ox679[OxO8061[16]]=Ox4e;Ox679[OxO8061[17]]=Ox4f;Ox679[OxO8061[9]]=true;CuteEditor_FireEvent(editor,OxO8061[18],Ox679);if(Ox679[OxO8061[9]]==false){return true;} ;} ;function CuteEditor_FireEvent(editor,Ox67b,Ox67c){if(Ox67c==null){Ox67c={};} ;var Ox67d=editor.getAttribute(Ox67b);if(Ox67d){if( typeof (Ox67d)==OxO8061[19]){editor[OxO8061[20]]= new Function(OxO8061[21],Ox67d);} else {editor[OxO8061[20]]=Ox67d;} ;editor._fireEventFunction(Ox67c);} ;} ;function CuteEditor_GetEditor(element){for(var Ox43=element;Ox43!=null;Ox43=Ox43[OxO8061[22]]){if(Ox43.getAttribute(OxO8061[23])==OxO8061[24]){return Ox43;} ;} ;return null;} ;function CuteEditor_DropDownCommand(element,Oxa3b){var editor=CuteEditor_GetEditor(element);if(editor[OxO8061[25]]){return ;} ;if(element.getAttribute(OxO8061[26])==OxO8061[24]){var Ox142=element.GetValue();if(Ox142==OxO8061[27]){Ox142=OxO8061[4];} ;var Ox201=element.GetText();if(Ox201==OxO8061[27]){Ox201=OxO8061[4];} ;element.SetSelectedIndex(0);editor.ExecCommand(Oxa3b,false,Ox142,Ox201);} else {if(!editor[OxO8061[25]]&&element[OxO8061[28]]){var Ox142=element[OxO8061[28]];if(Ox142==OxO8061[27]){Ox142=OxO8061[4];} ;element[OxO8061[29]]=0;editor.ExecCommand(Oxa3b,false,Ox142,Ox201);} else {element[OxO8061[29]]=0;} ;} ;editor.FocusDocument();} ;function CuteEditor_ExpandTreeDropDownItem(src,Ox73d){var Oxba=null;while(src!=null){if(src[OxO8061[30]]==OxO8061[31]){Oxba=src;break ;} ;src=src[OxO8061[22]];} ;var Ox1e4=Oxba[OxO8061[32]].item(0);Oxba[OxO8061[35]][OxO8061[34]][OxO8061[33]]=OxO8061[4];Ox1e4[OxO8061[36]]=OxO8061[37]+Ox73d+OxO8061[38];Oxba[OxO8061[39]]= new Function(OxO8061[40]+Ox73d+OxO8061[41]);} ;function CuteEditor_CollapseTreeDropDownItem(src,Ox73d){var Oxba=null;while(src!=null){if(src[OxO8061[30]]==OxO8061[31]){Oxba=src;break ;} ;src=src[OxO8061[22]];} ;var Ox1e4=Oxba[OxO8061[32]].item(0);Oxba[OxO8061[35]][OxO8061[34]][OxO8061[33]]=OxO8061[42];Ox1e4[OxO8061[36]]=OxO8061[37]+Ox73d+OxO8061[43];Oxba[OxO8061[39]]= new Function(OxO8061[44]+Ox73d+OxO8061[41]);} ;function Event_GetEvent(Ox244){Ox244=Event_FindEvent(Ox244);if(Ox244==null){Debug_Todo(OxO8061[45]);} ;return Ox244;} ;function Element_GetAllElements(p){var arr=[];for(var i=0;i<p[OxO8061[46]][OxO8061[6]];i++){arr.push(p[OxO8061[46]].item(i));} ;return arr;} ;function Element_SetUnselectable(element){element.setAttribute(OxO8061[47],OxO8061[48]);element.setAttribute(OxO8061[49],OxO8061[50]);var arr=Element_GetAllElements(element);var len=arr[OxO8061[6]];if(!len){return ;} ;for(var i=0;i<len;i++){arr[i].setAttribute(OxO8061[47],OxO8061[48]);arr[i].setAttribute(OxO8061[49],OxO8061[50]);} ;} ;function Frame_GetContentWindow(Ox348){if(Ox348[OxO8061[51]]){return Ox348[OxO8061[51]];} ;if(Ox348[OxO8061[52]]){if(Ox348[OxO8061[52]][OxO8061[53]]){return Ox348[OxO8061[52]][OxO8061[53]];} ;} ;var Ox1a8;if(Ox348[OxO8061[54]]){Ox1a8=window[OxO8061[55]][Ox348[OxO8061[54]]];if(Ox1a8){return Ox1a8;} ;} ;var len=window[OxO8061[55]][OxO8061[6]];for(var i=0;i<len;i++){Ox1a8=window[OxO8061[55]][i];if(Ox1a8[OxO8061[56]]==Ox348){return Ox1a8;} ;if(Ox1a8[OxO8061[5]]==Ox348[OxO8061[52]]){return Ox1a8;} ;} ;Debug_Todo(OxO8061[57]);} ;function Array_IndexOf(arr,Ox246){for(var i=0;i<arr[OxO8061[6]];i++){if(arr[i]==Ox246){return i;} ;} ;return -1;} ;function Array_Contains(arr,Ox246){return Array_IndexOf(arr,Ox246)!=-1;} ;function clearArray(Ox249){for(var i=0;i<Ox249[OxO8061[6]];i++){Ox249[i]=null;} ;} ;function Event_FindEvent(Ox244){if(Ox244&&Ox244[OxO8061[10]]){return Ox244;} ;if(window[OxO8061[21]]){return window[OxO8061[21]];} ;return Event_FindEvent_FindEventFromWindows();} ;function include(Oxc9,Ox287){var Ox288=document.getElementsByTagName(OxO8061[58]).item(0);var Ox289=document.getElementById(Oxc9);if(Ox289){Ox288.removeChild(Ox289);} ;var Ox28a=document.createElement(OxO8061[59]);Ox28a.setAttribute(OxO8061[60],OxO8061[61]);Ox28a.setAttribute(OxO8061[62],OxO8061[63]);Ox28a.setAttribute(OxO8061[64],Ox287);Ox28a.setAttribute(OxO8061[54],Oxc9);Ox288.appendChild(Ox28a);} ;function Event_FindEvent_FindEventFromCallers(){var Ox18f=Event_GetEvent[OxO8061[65]];for(var i=0;i<100;i++){if(!Ox18f){break ;} ;var Ox244=Ox18f[OxO8061[66]][0];if(Ox244&&Ox244[OxO8061[10]]){return Ox244;} ;Ox18f=Ox18f[OxO8061[65]];} ;} ;function Event_FindEvent_FindEventFromWindows(){var arr=[];return Ox24d(window);function Ox24d(Ox1a8){if(Ox1a8==null){return null;} ;if(Ox1a8[OxO8061[21]]){return Ox1a8[OxO8061[21]];} ;if(Array_Contains(arr,Ox1a8)){return null;} ;arr.push(Ox1a8);var Ox24e=[];if(Ox1a8[OxO8061[67]]!=Ox1a8){Ox24e.push(Ox1a8.parent);} ;if(Ox1a8[OxO8061[68]]!=Ox1a8[OxO8061[67]]){Ox24e.push(Ox1a8.top);} ;if(Ox1a8[OxO8061[69]]){Ox24e.push(Ox1a8.opener);} ;for(var i=0;i<Ox1a8[OxO8061[55]][OxO8061[6]];i++){Ox24e.push(Ox1a8[OxO8061[55]][i]);} ;for(var i=0;i<Ox24e[OxO8061[6]];i++){try{var Ox244=Ox24d(Ox24e[i]);if(Ox244){return Ox244;} ;} catch(x){} ;} ;return null;} ;} ;function Event_GetSrcElement(Ox244){Ox244=Event_GetEvent(Ox244);if(Ox244[OxO8061[70]]){return Ox244[OxO8061[70]];} ;if(Ox244[OxO8061[71]]){return Ox244[OxO8061[71]];} ;Debug_Todo(OxO8061[72]);return null;} ;function Event_GetFromElement(Ox244){Ox244=Event_GetEvent(Ox244);if(Ox244[OxO8061[73]]){return Ox244[OxO8061[73]];} ;if(Ox244[OxO8061[74]]){return Ox244[OxO8061[74]];} ;return null;} ;function Event_GetToElement(Ox244){Ox244=Event_GetEvent(Ox244);if(Ox244[OxO8061[75]]){return Ox244[OxO8061[75]];} ;if(Ox244[OxO8061[74]]){return Ox244[OxO8061[74]];} ;return null;} ;function Event_GetKeyCode(Ox244){Ox244=Event_GetEvent(Ox244);return Ox244[OxO8061[76]];} ;function Event_GetClientX(Ox244){Ox244=Event_GetEvent(Ox244);return Ox244[OxO8061[77]];} ;function Event_GetClientY(Ox244){Ox244=Event_GetEvent(Ox244);return Ox244[OxO8061[78]];} ;function Event_GetOffsetX(Ox244){Ox244=Event_GetEvent(Ox244);return Ox244[OxO8061[79]];} ;function Event_GetOffsetY(Ox244){Ox244=Event_GetEvent(Ox244);return Ox244[OxO8061[80]];} ;function Event_IsLeftButton(Ox244){Ox244=Event_GetEvent(Ox244);return Ox244[OxO8061[81]]==1;} ;function Event_IsCtrlKey(Ox244){Ox244=Event_GetEvent(Ox244);return Ox244[OxO8061[82]];} ;function Event_IsAltKey(Ox244){Ox244=Event_GetEvent(Ox244);return Ox244[OxO8061[83]];} ;function Event_IsShiftKey(Ox244){Ox244=Event_GetEvent(Ox244);return Ox244[OxO8061[84]];} ;function CuteEditor_BasicInitialize(editor){var Ox706= new Function(OxO8061[85]);var Oxa3f= new Function(OxO8061[86]);var Oxa40= new Function(OxO8061[87]);var Oxa41=editor.GetScriptProperty(OxO8061[88]);var Oxa42=editor.GetScriptProperty(OxO8061[89]);var Oxa43=Oxa41+OxO8061[90]+Oxa42+OxO8061[91];var Oxa44=Oxa41+OxO8061[92];var images=editor.getElementsByTagName(OxO8061[93]);var len=images[OxO8061[6]];for(var i=0;i<len;i++){var img=images[i];if(img.getAttribute(OxO8061[94])&&!img.getAttribute(OxO8061[95])){img.setAttribute(OxO8061[95],img.getAttribute(OxO8061[94]));} ;var Ox135=img.getAttribute(OxO8061[96]);var Ox66e=img.getAttribute(OxO8061[97]);if(!(Ox135||Ox66e)){continue ;} ;var Oxa45=img.getAttribute(OxO8061[98]);if(parseInt(Oxa45)>=0){img[OxO8061[34]][OxO8061[99]]=OxO8061[100];img[OxO8061[34]][OxO8061[101]]=OxO8061[100];img[OxO8061[64]]=Oxa44;img[OxO8061[34]][OxO8061[102]]=OxO8061[103]+Oxa43+OxO8061[104];img[OxO8061[34]][OxO8061[105]]=OxO8061[106]+(Oxa45*20)+OxO8061[107];img[OxO8061[34]][OxO8061[33]]=OxO8061[4];} ;if(img[OxO8061[108]]!=OxO8061[109]){img[OxO8061[108]]=OxO8061[110];img[OxO8061[111]]= new Function(OxO8061[112]);img[OxO8061[113]]= new Function(OxO8061[114]);img[OxO8061[115]]= new Function(OxO8061[116]);img[OxO8061[117]]= new Function(OxO8061[118]);} ;if(!img[OxO8061[119]]){img[OxO8061[119]]=Event_CancelEvent;} ;if(!img[OxO8061[120]]){img[OxO8061[120]]=Event_CancelEvent;} ;if(Ox135){var Ox18f=img.getAttribute(OxO8061[121])==OxO8061[24]?Oxa3f:Ox706;if(img[OxO8061[39]]==null){img[OxO8061[39]]=Ox18f;} ;if(img[OxO8061[122]]==null){img[OxO8061[122]]=Ox18f;} ;} else {if(Ox66e){if(img[OxO8061[39]]==null){img[OxO8061[39]]=Oxa40;} ;} ;} ;} ;var Ox773=Window_GetElement(window,editor.GetScriptProperty(OxO8061[123]),true);var Ox774=Window_GetElement(window,editor.GetScriptProperty(OxO8061[124]),true);var Ox76f=Window_GetElement(window,editor.GetScriptProperty(OxO8061[125]),true);Ox76f[OxO8061[108]]+=OxO8061[126];Ox773[OxO8061[108]]+=OxO8061[127];Ox774[OxO8061[108]]+=OxO8061[127];Element_SetUnselectable(Ox773);Element_SetUnselectable(Ox774);} ;function CuteEditor_ButtonOver(element){if(!element[OxO8061[128]]){element[OxO8061[119]]=Event_CancelEvent;element[OxO8061[113]]=CuteEditor_ButtonOut;element[OxO8061[115]]=CuteEditor_ButtonDown;element[OxO8061[117]]=CuteEditor_ButtonUp;Element_SetUnselectable(element);element[OxO8061[128]]=true;} ;element[OxO8061[129]]=true;element[OxO8061[108]]=OxO8061[130];} ;function CuteEditor_ButtonOut(){var element=this;element[OxO8061[108]]=OxO8061[110];element[OxO8061[129]]=false;} ;function CuteEditor_ButtonDown(){if(!Event_IsLeftButton()){return ;} ;var element=this;element[OxO8061[108]]=OxO8061[131];} ;function CuteEditor_ButtonUp(){if(!Event_IsLeftButton()){return ;} ;var element=this;if(element[OxO8061[129]]){element[OxO8061[108]]=OxO8061[130];} else {element[OxO8061[108]]=OxO8061[132];} ;} ;function CuteEditor_ColorPicker_ButtonOver(element){if(!element[OxO8061[128]]){element[OxO8061[119]]=Event_CancelEvent;element[OxO8061[113]]=CuteEditor_ColorPicker_ButtonOut;element[OxO8061[115]]=CuteEditor_ColorPicker_ButtonDown;Element_SetUnselectable(element);element[OxO8061[128]]=true;} ;element[OxO8061[129]]=true;element[OxO8061[34]][OxO8061[133]]=OxO8061[134];element[OxO8061[34]][OxO8061[135]]=OxO8061[136];element[OxO8061[34]][OxO8061[137]]=OxO8061[138];} ;function CuteEditor_ColorPicker_ButtonOut(){var element=this;element[OxO8061[129]]=false;element[OxO8061[34]][OxO8061[133]]=OxO8061[139];element[OxO8061[34]][OxO8061[135]]=OxO8061[4];element[OxO8061[34]][OxO8061[137]]=OxO8061[138];} ;function CuteEditor_ColorPicker_ButtonDown(){var element=this;element[OxO8061[34]][OxO8061[133]]=OxO8061[140];element[OxO8061[34]][OxO8061[135]]=OxO8061[4];element[OxO8061[34]][OxO8061[137]]=OxO8061[138];} ;function CuteEditor_ButtonCommandOver(element){element[OxO8061[129]]=true;if(element[OxO8061[141]]){element[OxO8061[108]]=OxO8061[142];} else {element[OxO8061[108]]=OxO8061[130];} ;} ;function CuteEditor_ButtonCommandOut(element){element[OxO8061[129]]=false;if(element[OxO8061[143]]){element[OxO8061[108]]=OxO8061[144];} else {if(element[OxO8061[141]]){element[OxO8061[108]]=OxO8061[142];} else {element[OxO8061[108]]=OxO8061[110];} ;} ;} ;function CuteEditor_ButtonCommandDown(element){if(!Event_IsLeftButton()){return ;} ;element[OxO8061[108]]=OxO8061[131];} ;function CuteEditor_ButtonCommandUp(element){if(!Event_IsLeftButton()){return ;} ;if(element[OxO8061[141]]){element[OxO8061[108]]=OxO8061[142];return ;} ;if(element[OxO8061[129]]){element[OxO8061[108]]=OxO8061[130];} else {if(element[OxO8061[143]]){element[OxO8061[108]]=OxO8061[144];} else {element[OxO8061[108]]=OxO8061[110];} ;} ;} ;var CuteEditorGlobalFunctions=[CuteEditor_GetEditor,CuteEditor_ButtonOver,CuteEditor_ButtonOut,CuteEditor_ButtonDown,CuteEditor_ButtonUp,CuteEditor_ColorPicker_ButtonOver,CuteEditor_ColorPicker_ButtonOut,CuteEditor_ColorPicker_ButtonDown,CuteEditor_ButtonCommandOver,CuteEditor_ButtonCommandOut,CuteEditor_ButtonCommandDown,CuteEditor_ButtonCommandUp,CuteEditor_DropDownCommand,CuteEditor_ExpandTreeDropDownItem,CuteEditor_CollapseTreeDropDownItem,CuteEditor_OnInitialized,CuteEditor_OnCommand,CuteEditor_OnChange,CuteEditor_AddVerbMenuItems,CuteEditor_AddTagMenuItems,CuteEditor_AddMainMenuItems,CuteEditor_AddDropMenuItems,CuteEditor_FilterCode,CuteEditor_FilterHTML];function SetupCuteEditorGlobalFunctions(){for(var i=0;i<CuteEditorGlobalFunctions[OxO8061[6]];i++){var Ox18f=CuteEditorGlobalFunctions[i];var name=Ox18f+OxO8061[4];name=name.substr(8,name.indexOf(OxO8061[145])-8).replace(/\s/g,OxO8061[4]);if(!window[name]){window[name]=Ox18f;} ;} ;} ;SetupCuteEditorGlobalFunctions();var __danainfo=null;var danaurl=window[OxO8061[147]][OxO8061[146]];var danapos=danaurl.indexOf(OxO8061[148]);if(danapos!=-1){var pluspos1=danaurl.indexOf(OxO8061[149],danapos+10);var pluspos2=danaurl.indexOf(OxO8061[150],danapos+10);if(pluspos1!=-1&&pluspos1<pluspos2){pluspos2=pluspos1;} ;__danainfo=danaurl.substring(danapos,pluspos2)+OxO8061[150];} ;function CuteEditor_GetScriptProperty(name){var Ox142=this[OxO8061[151]][name];if(Ox142&&__danainfo){if(name==OxO8061[88]){return Ox142+__danainfo;} ;var Ox381=this[OxO8061[151]][OxO8061[88]];if(Ox142.substr(0,Ox381.length)==Ox381){return Ox381+__danainfo+Ox142.substring(Ox381.length);} ;} ;return Ox142;} ;function CuteEditor_SetScriptProperty(name,Ox142){if(Ox142==null){this[OxO8061[151]][name]=null;} else {this[OxO8061[151]][name]=String(Ox142);} ;} ;function CuteEditorInitialize(Oxa52,Oxa53){var editor=Window_GetElement(window,Oxa52,true);editor[OxO8061[151]]=Oxa53;editor[OxO8061[152]]=CuteEditor_GetScriptProperty;var Ox76f=Window_GetElement(window,editor.GetScriptProperty(OxO8061[125]),true);var editwin=Frame_GetContentWindow(Ox76f);var editdoc=editwin[OxO8061[5]];var Oxa54=false;var Oxa55;var Oxa56=false;var Oxa57=editor.GetScriptProperty(OxO8061[88])+OxO8061[153]+editor.GetScriptProperty(OxO8061[154]);var Oxadd=editor.GetScriptProperty(OxO8061[88])+OxO8061[155]+editor.GetScriptProperty(OxO8061[154]);function Oxa58(){if( typeof (window[OxO8061[156]])==OxO8061[157]){return ;} ;try{LoadXMLAsync(OxO8061[158],Oxa57+OxO8061[159]+ new Date().getTime(),Oxa59);} catch(x){include(OxO8061[160],Oxa57);var Oxade=setInterval(function (){if(window[OxO8061[156]]){clearInterval(Oxade);if(Oxa54){Oxa5b();} ;} ;} ,100);} ;} ;function Oxa59(Ox28f){var Ox883= new Date().getTime();if(Ox28f[OxO8061[161]]!=200){} else {Ox883=Ox28f[OxO8061[162]];} ;LoadXMLAsync(OxO8061[163],Oxa57+OxO8061[164]+Ox883,Oxa5a);} ;function Oxa5a(Ox28f){if(Ox28f[OxO8061[161]]!=200){alert(OxO8061[165]);return ;} ;CuteEditorInstallScriptCode(Ox28f.responseText,OxO8061[156]);if(Oxa54){Oxa5b();} ;} ;function Oxa5b(){if(Oxa56){return ;} ;for(var Ox183=editor;Ox183&&Ox183[OxO8061[34]];Ox183=Ox183[OxO8061[22]]){if(Ox183[OxO8061[34]][OxO8061[33]]==OxO8061[42]){setTimeout(Oxa5b,100);return ;} ;} ;Oxa56=true;Ox76f[OxO8061[34]][OxO8061[33]]=OxO8061[166];editdoc[OxO8061[168]][OxO8061[167]]=true;window.CuteEditorImplementation(editor);try{editor[OxO8061[34]][OxO8061[169]]=OxO8061[4];} catch(x){} ;try{editdoc[OxO8061[168]][OxO8061[34]][OxO8061[169]]=OxO8061[4];} catch(x){} ;var Oxa5c=editor.GetScriptProperty(OxO8061[170]);if(Oxa5c){editor.Eval(Oxa5c);} ;} ;function Oxa5d(){if(!window[OxO8061[5]][OxO8061[168]].contains(editor)){return ;} ;try{Ox76f=Window_GetElement(window,editor.GetScriptProperty(OxO8061[125]),true);editwin=Frame_GetContentWindow(Ox76f);editdoc=editwin[OxO8061[5]];x=editdoc[OxO8061[168]];} catch(x){setTimeout(Oxa5d,100);return ;} ;if(!editdoc[OxO8061[168]]){setTimeout(Oxa5d,100);return ;} ;if(!Oxa54){Oxa54=true;setTimeout(Oxa5d,100);return ;} ;if( typeof (window[OxO8061[156]])==OxO8061[157]){Oxa5b();} else {try{editdoc[OxO8061[168]][OxO8061[34]][OxO8061[169]]=OxO8061[171];} catch(x){} ;} ;} ;CuteEditor_BasicInitialize(editor);Oxa58();Oxa5d();} ;function CuteEditorInstallScriptCode(Ox9b6,Ox9b7){eval(Ox9b6);window[Ox9b7]=eval(Ox9b7);} ;window[OxO8061[172]]=CuteEditorInitialize;