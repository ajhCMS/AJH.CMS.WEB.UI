var OxO3fb6=["Form1","FoldersAndFiles","Image1","FolderDescription","cbThumbSize","cbColumns","cbRows","cbTypes","cbSorts","ThumbList1_MyList","MyList","ThumbList1_hdnCurPage","hdnCurPage","ThumbList1_hdnPrevPath","hdnPrevPath","hiddenAlert","lightyellow","0px","-3px","value","","onload","all","getElementById","\x3Cdiv id=\x22tooltipdiv\x22 style=\x22visibility:hidden;background-color:","\x22 \x3E\x3C/div\x3E","tooltipdiv","left","offsetLeft","offsetTop","offsetParent","style","top","visibility","compatMode","BackCompat","documentElement","body","rightedge","opera","scrollLeft","clientWidth","pageXOffset","innerWidth","contentmeasure","offsetWidth","x","scrollTop","clientHeight","pageYOffset","innerHeight","offsetHeight","y","innerHTML","visible","hidden","px","bottomedge","undefined","hidetip()","element","editor","editdoc","^[a-z]*:[/][/][^/]*","IMG","src","width","height","border","alt","product","Gecko","src_cetemp","Edit"];var Form1=Window_GetElement(window,OxO3fb6[0],true);var FoldersAndFiles=Window_GetElement(window,OxO3fb6[1],true);var Image1=Window_GetElement(window,OxO3fb6[2],true);var FolderDescription=Window_GetElement(window,OxO3fb6[3],true);var cbThumbSize=Window_GetElement(window,OxO3fb6[4],true);var cbColumns=Window_GetElement(window,OxO3fb6[5],true);var cbRows=Window_GetElement(window,OxO3fb6[6],true);var cbTypes=Window_GetElement(window,OxO3fb6[7],true);var cbSorts=Window_GetElement(window,OxO3fb6[8],true);var ThumbList1_MyList=Window_GetElement(window,OxO3fb6[9],false)||Window_GetElement(window,OxO3fb6[10],true);var ThumbList1_hdnCurPage=Window_GetElement(window,OxO3fb6[11],false)||Window_GetElement(window,OxO3fb6[12],true);var ThumbList1_hdnPrevPath=Window_GetElement(window,OxO3fb6[13],false)||Window_GetElement(window,OxO3fb6[14],true);var hiddenAlert=Window_GetElement(window,OxO3fb6[15],true);var tipbgcolor=OxO3fb6[16];var disappeardelay=250;var vertical_offset=OxO3fb6[17];var horizontal_offset=OxO3fb6[18];var delayhidetimerid;function reset_hiddens(){if(hiddenAlert[OxO3fb6[19]]){alert(hiddenAlert.value);} ;hiddenAlert[OxO3fb6[19]]=OxO3fb6[20];} ;Event_Attach(window,OxO3fb6[21],reset_hiddens);var ie4=document[OxO3fb6[22]];var ns6=document[OxO3fb6[23]]&&!document[OxO3fb6[22]];if(ie4||ns6){document.write(OxO3fb6[24]+tipbgcolor+OxO3fb6[25]);var dropmenuobj=Window_GetElement(window,OxO3fb6[26],true);} ;function getposOffset(Ox405,Ox406){var Ox407=(Ox406==OxO3fb6[27])?Ox405[OxO3fb6[28]]:Ox405[OxO3fb6[29]];var Ox408=Ox405[OxO3fb6[30]];while(Ox408!=null){Ox407+=(Ox406==OxO3fb6[27])?Ox408[OxO3fb6[28]]:Ox408[OxO3fb6[29]];Ox408=Ox408[OxO3fb6[30]];} ;return Ox407;} ;function showhide(obj,Ox40a,Ox40b){if(ie4||ns6){dropmenuobj[OxO3fb6[31]][OxO3fb6[27]]=dropmenuobj[OxO3fb6[31]][OxO3fb6[32]]=-500;} ;obj[OxO3fb6[33]]=Ox40a;} ;function iecompattest(){return (document[OxO3fb6[34]]&&document[OxO3fb6[34]]!=OxO3fb6[35])?document[OxO3fb6[36]]:document[OxO3fb6[37]];} ;function clearbrowseredge(obj,Ox40e){var Ox40f=(Ox40e==OxO3fb6[38])?parseInt(horizontal_offset)*-1:parseInt(vertical_offset)*-1;if(Ox40e==OxO3fb6[38]){var Ox410=ie4&&!window[OxO3fb6[39]]?iecompattest()[OxO3fb6[40]]+iecompattest()[OxO3fb6[41]]-15:window[OxO3fb6[42]]+window[OxO3fb6[43]]-15;dropmenuobj[OxO3fb6[44]]=dropmenuobj[OxO3fb6[45]];if(Ox410-dropmenuobj[OxO3fb6[46]]<dropmenuobj[OxO3fb6[44]]){Ox40f=dropmenuobj[OxO3fb6[44]]-obj[OxO3fb6[45]];} ;} else {var Ox410=ie4&&!window[OxO3fb6[39]]?iecompattest()[OxO3fb6[47]]+iecompattest()[OxO3fb6[48]]-15:window[OxO3fb6[49]]+window[OxO3fb6[50]]-18;dropmenuobj[OxO3fb6[44]]=dropmenuobj[OxO3fb6[51]];if(Ox410-dropmenuobj[OxO3fb6[52]]<dropmenuobj[OxO3fb6[44]]){Ox40f=dropmenuobj[OxO3fb6[44]]+obj[OxO3fb6[51]];} ;} ;return Ox40f;} ;function showTooltip(Ox42,obj){Event_CancelEvent();clearhidetip();dropmenuobj[OxO3fb6[53]]=Ox42;if(ie4||ns6){showhide(dropmenuobj.style,OxO3fb6[54],OxO3fb6[55]);dropmenuobj[OxO3fb6[46]]=getposOffset(obj,OxO3fb6[27]);dropmenuobj[OxO3fb6[52]]=getposOffset(obj,OxO3fb6[32]);dropmenuobj[OxO3fb6[31]][OxO3fb6[27]]=dropmenuobj[OxO3fb6[46]]-clearbrowseredge(obj,OxO3fb6[38])+OxO3fb6[56];dropmenuobj[OxO3fb6[31]][OxO3fb6[32]]=dropmenuobj[OxO3fb6[52]]-clearbrowseredge(obj,OxO3fb6[57])+obj[OxO3fb6[51]]*1.1+2+OxO3fb6[56];} ;} ;function hidetip(){if( typeof dropmenuobj!=OxO3fb6[58]){if(ie4||ns6){dropmenuobj[OxO3fb6[31]][OxO3fb6[33]]=OxO3fb6[55];} ;} ;} ;function delayhidetip(){if(ie4||ns6){delayhidetimerid=setTimeout(OxO3fb6[59],disappeardelay);} ;} ;function clearhidetip(){clearTimeout(delayhidetimerid);} ;function cancel(){Window_CloseDialog(window);} ;var obj=Window_GetDialogArguments(window);var element=obj[OxO3fb6[60]];var editor=obj[OxO3fb6[61]];var editdoc=obj[OxO3fb6[62]];function insert(src){if(src){var Ox287=src.replace( new RegExp(OxO3fb6[63],OxO3fb6[20]),OxO3fb6[20]);function Actualsize(){var Ox7d=document.createElement(OxO3fb6[64]);Ox7d[OxO3fb6[65]]=Ox287;if(Ox7d[OxO3fb6[66]]>0&&Ox7d[OxO3fb6[67]]>0){element[OxO3fb6[66]]=Ox7d[OxO3fb6[66]];element[OxO3fb6[67]]=Ox7d[OxO3fb6[67]];} else {setTimeout(Actualsize,400);} ;} ;if(element){element[OxO3fb6[65]]=Ox287;} else {element=editdoc.createElement(OxO3fb6[64]);element[OxO3fb6[65]]=Ox287;element[OxO3fb6[68]]=0;element[OxO3fb6[69]]=OxO3fb6[20];Actualsize();} ;if(navigator[OxO3fb6[70]]==OxO3fb6[71]){try{element.setAttribute(OxO3fb6[72],Ox287);} catch(e){} ;} else {if(editor.GetActiveTab()==OxO3fb6[73]){element.setAttribute(OxO3fb6[72],Ox287);} ;} ;editor.InsertElement(element);Window_CloseDialog(window);} ;} ;