var OxO39d9=["inp_width","eenheid","alignment","hrcolor","hrcolorpreview","shade","sel_size","width","style","value","px","%","size","align","color","backgroundColor","noShade","noshade","","onclick"];var inp_width=Window_GetElement(window,OxO39d9[0],true);var eenheid=Window_GetElement(window,OxO39d9[1],true);var alignment=Window_GetElement(window,OxO39d9[2],true);var hrcolor=Window_GetElement(window,OxO39d9[3],true);var hrcolorpreview=Window_GetElement(window,OxO39d9[4],true);var shade=Window_GetElement(window,OxO39d9[5],true);var sel_size=Window_GetElement(window,OxO39d9[6],true);UpdateState=function UpdateState_Hr(){} ;SyncToView=function SyncToView_Hr(){if(element[OxO39d9[8]][OxO39d9[7]]){if(element[OxO39d9[8]][OxO39d9[7]].search(/%/)<0){eenheid[OxO39d9[9]]=OxO39d9[10];inp_width[OxO39d9[9]]=element[OxO39d9[8]][OxO39d9[7]].split(OxO39d9[10])[0];} else {eenheid[OxO39d9[9]]=OxO39d9[11];inp_width[OxO39d9[9]]=element[OxO39d9[8]][OxO39d9[7]].split(OxO39d9[11])[0];} ;} ;sel_size[OxO39d9[9]]=element[OxO39d9[12]];alignment[OxO39d9[9]]=element[OxO39d9[13]];hrcolor[OxO39d9[9]]=element[OxO39d9[14]];if(element[OxO39d9[14]]){hrcolor[OxO39d9[8]][OxO39d9[15]]=element[OxO39d9[14]];} ;if(element[OxO39d9[16]]){shade[OxO39d9[9]]=OxO39d9[17];} else {shade[OxO39d9[9]]=OxO39d9[18];} ;} ;SyncTo=function SyncTo_Hr(element){if(sel_size[OxO39d9[9]]){element[OxO39d9[12]]=sel_size[OxO39d9[9]];} ;if(hrcolor[OxO39d9[9]]){element[OxO39d9[14]]=hrcolor[OxO39d9[9]];} ;if(alignment[OxO39d9[9]]){element[OxO39d9[13]]=alignment[OxO39d9[9]];} ;if(shade[OxO39d9[9]]==OxO39d9[17]){element[OxO39d9[16]]=true;} else {element[OxO39d9[16]]=false;} ;if(inp_width[OxO39d9[9]]){element[OxO39d9[8]][OxO39d9[7]]=inp_width[OxO39d9[9]]+eenheid[OxO39d9[9]];} ;} ;hrcolor[OxO39d9[19]]=hrcolorpreview[OxO39d9[19]]=function hrcolor_onclick(){SelectColor(hrcolor,hrcolorpreview);} ;