var OxO4877=["=","; path=/;"," expires=",";","cookie","length","","#ffffff","CECC","onmouseover","event","srcElement","target","className","colordiv","style","onmouseout","onclick","CheckboxColorNames","checked","cname","backgroundColor","cvalue","[[_CuteEditorResource_]]Load.ashx?type=dialog\x26file=ColorPicker.Aspx\x26culture=[[_culture_]]","\x26[[DNN_Arg]]","dialogWidth:520px;dialogHeight:420px;help:0;status:0;resizable:1","dialogArguments","object","onchange","color","editor","divpreview","value","#","RecentColors","SPAN","[[ValidColor]]"];function SetCookie(name,Ox4f,Ox56){var Ox57=name+OxO4877[0]+escape(Ox4f)+OxO4877[1];if(Ox56){var Ox58= new Date();Ox58.setSeconds(Ox58.getSeconds()+Ox56);Ox57+=OxO4877[2]+Ox58.toUTCString()+OxO4877[3];} ;document[OxO4877[4]]=Ox57;} ;function GetCookie(name){var Ox5a=document[OxO4877[4]].split(OxO4877[3]);for(var i=0;i<Ox5a[OxO4877[5]];i++){var Ox5b=Ox5a[i].split(OxO4877[0]);if(name==Ox5b[0].replace(/\s/g,OxO4877[6])){return unescape(Ox5b[1]);} ;} ;} ;function GetCookieDictionary(){var Ox12b={};var Ox5a=document[OxO4877[4]].split(OxO4877[3]);for(var i=0;i<Ox5a[OxO4877[5]];i++){var Ox5b=Ox5a[i].split(OxO4877[0]);Ox12b[Ox5b[0].replace(/\s/g,OxO4877[6])]=unescape(Ox5b[1]);} ;return Ox12b;} ;function GetCookieArray(){var arr=[];var Ox5a=document[OxO4877[4]].split(OxO4877[3]);for(var i=0;i<Ox5a[OxO4877[5]];i++){var Ox5b=Ox5a[i].split(OxO4877[0]);var Ox57={name:Ox5b[0].replace(/\s/g,OxO4877[6]),value:unescape(Ox5b[1])};arr[arr[OxO4877[5]]]=Ox57;} ;return arr;} ;var __defaultcustomlist=[OxO4877[7],OxO4877[7],OxO4877[7],OxO4877[7],OxO4877[7],OxO4877[7],OxO4877[7],OxO4877[7]];function GetCustomColors(){var Ox12f=__defaultcustomlist.concat();for(var i=0;i<18;i++){var Oxdc=GetCustomColor(i);if(Oxdc){Ox12f[i]=Oxdc;} ;} ;return Ox12f;} ;function GetCustomColor(Ox131){return GetCookie(OxO4877[8]+Ox131);} ;function SetCustomColor(Ox131,Oxdc){SetCookie(OxO4877[8]+Ox131,Oxdc,60*60*24*365);} ;var _origincolor=OxO4877[6];document[OxO4877[9]]=function (Ox1d0){Ox1d0=window[OxO4877[10]]||Ox1d0;var Ox12=Ox1d0[OxO4877[11]]||Ox1d0[OxO4877[12]];if(Ox12[OxO4877[13]]==OxO4877[14]){firecolorchange(Ox12[OxO4877[15]].backgroundColor);} ;} ;document[OxO4877[16]]=function (Ox1d0){Ox1d0=window[OxO4877[10]]||Ox1d0;var Ox12=Ox1d0[OxO4877[11]]||Ox1d0[OxO4877[12]];if(Ox12[OxO4877[13]]==OxO4877[14]){firecolorchange(_origincolor);} ;} ;document[OxO4877[17]]=function (Ox1d0){Ox1d0=window[OxO4877[10]]||Ox1d0;var Ox12=Ox1d0[OxO4877[11]]||Ox1d0[OxO4877[12]];if(Ox12[OxO4877[13]]==OxO4877[14]){var Ox29d=document.getElementById(OxO4877[18])&&document.getElementById(OxO4877[18])[OxO4877[19]];if(Ox29d){do_select(Ox12.getAttribute(OxO4877[20])||Ox12[OxO4877[15]][OxO4877[21]]);} else {do_select(Ox12.getAttribute(OxO4877[22])||Ox12[OxO4877[15]][OxO4877[21]]);} ;} ;} ;var _editor;function firecolorchange(Ox2a0){} ;function ShowColorDialog(Ox234){var Ox13b=OxO4877[23]+OxO4877[24];var Ox2a2=OxO4877[25];var Ox13e=showModalDialog(Ox13b,null,Ox2a2);if(Ox13e!=null&&Ox13e!==false){Ox234(Ox13e);} ;} ;if(top[OxO4877[26]]){if( typeof (top[OxO4877[26]])==OxO4877[27]){if(top[OxO4877[26]][OxO4877[28]]){firecolorchange=top[OxO4877[26]][OxO4877[28]];_origincolor=top[OxO4877[26]][OxO4877[29]];_editor=top[OxO4877[26]][OxO4877[30]];} ;} ;} ;var _selectedcolor=null;function do_select(Oxdc){_selectedcolor=Oxdc;firecolorchange(Oxdc);var Ox2a5=document.getElementById(OxO4877[31]);if(Ox2a5){Ox2a5[OxO4877[32]]=Oxdc;} ;} ;function do_saverecent(Oxdc){if(!Oxdc){return ;} ;if(Oxdc[OxO4877[5]]!=7){return ;} ;if(Oxdc.substring(0,1)!=OxO4877[33]){return ;} ;var hex=Oxdc.substring(1,7);var Ox2a7=GetCookie(OxO4877[34]);if(!Ox2a7){Ox2a7=OxO4877[6];} ;if((Ox2a7[OxO4877[5]]%6)!=0){Ox2a7=OxO4877[6];} ;for(var i=0;i<Ox2a7[OxO4877[5]];i+=6){if(Ox2a7.substr(i,6)==hex){Ox2a7=Ox2a7.substr(0,i)+Ox2a7.substr(i+6);i-=6;} ;} ;if(Ox2a7[OxO4877[5]]>31*6){Ox2a7=Ox2a7.substr(0,31*6);} ;Ox2a7=hex+Ox2a7;SetCookie(OxO4877[34],Ox2a7,60*60*24*365);} ;function do_insert(){var Oxdc;var divpreview=document.getElementById(OxO4877[31]);if(divpreview){Oxdc=divpreview[OxO4877[32]];} else {Oxdc=_selectedcolor;} ;if(!Oxdc){return ;} ;if(/^[0-9A-F]{6}$/ig.test(Oxdc)){Oxdc=OxO4877[33]+Oxdc;} ;try{document.createElement(OxO4877[35])[OxO4877[15]][OxO4877[29]]=Oxdc;do_saverecent(Oxdc);Window_SetDialogReturnValue(window,Oxdc);Window_CloseDialog(window);} catch(x){alert(OxO4877[36]);divpreview[OxO4877[32]]=OxO4877[6];return false;} ;} ;