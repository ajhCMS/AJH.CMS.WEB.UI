var OxO7a6a=["inp_width","eenheid","alignment","hrcolor","shade","sel_size","width","value","","%","size","align","color","backgroundColor","style","noShade","noshade","hrcolorpreview","onclick"];var inp_width=Window_GetElement(window,OxO7a6a[0x0],true);var eenheid=Window_GetElement(window,OxO7a6a[0x1],true);var alignment=Window_GetElement(window,OxO7a6a[0x2],true);var hrcolor=Window_GetElement(window,OxO7a6a[0x3],true);var shade=Window_GetElement(window,OxO7a6a[0x4],true);var sel_size=Window_GetElement(window,OxO7a6a[0x5],true); UpdateState=function UpdateState_Hr(){}  ; SyncToView=function SyncToView_Hr(){if(element[OxO7a6a[0x6]]){if(element[OxO7a6a[0x6]].search(/%/)<0x0){ eenheid[OxO7a6a[0x7]]=OxO7a6a[0x8] ; inp_width[OxO7a6a[0x7]]=element[OxO7a6a[0x6]] ;} else { eenheid[OxO7a6a[0x7]]=OxO7a6a[0x9] ; inp_width[OxO7a6a[0x7]]=element[OxO7a6a[0x6]].split(OxO7a6a[0x9])[0x0] ;} ;} ; sel_size[OxO7a6a[0x7]]=element[OxO7a6a[0xa]] ; alignment[OxO7a6a[0x7]]=element[OxO7a6a[0xb]] ; hrcolor[OxO7a6a[0x7]]=element[OxO7a6a[0xc]] ;if(element[OxO7a6a[0xc]]){ hrcolor[OxO7a6a[0xe]][OxO7a6a[0xd]]=element[OxO7a6a[0xc]] ;} ;if(element[OxO7a6a[0xf]]){ shade[OxO7a6a[0x7]]=OxO7a6a[0x10] ;} else { shade[OxO7a6a[0x7]]=OxO7a6a[0x8] ;} ;}  ; SyncTo=function SyncTo_Hr(element){if(sel_size[OxO7a6a[0x7]]){ element[OxO7a6a[0xa]]=sel_size[OxO7a6a[0x7]] ;} ;if(hrcolor[OxO7a6a[0x7]]){ element[OxO7a6a[0xc]]=hrcolor[OxO7a6a[0x7]] ;} ;if(alignment[OxO7a6a[0x7]]){ element[OxO7a6a[0xb]]=alignment[OxO7a6a[0x7]] ;} ;if(shade[OxO7a6a[0x7]]==OxO7a6a[0x10]){ element[OxO7a6a[0xf]]=true ;} else { element[OxO7a6a[0xf]]=false ;} ;if(inp_width[OxO7a6a[0x7]]){ element[OxO7a6a[0x6]]=inp_width[OxO7a6a[0x7]]+eenheid[OxO7a6a[0x7]] ;} ;}  ;if(!Browser_IsWinIE()){var hrcolorpreview=Window_GetElement(window,OxO7a6a[0x11],true); hrcolor[OxO7a6a[0x12]]=hrcolorpreview[OxO7a6a[0x12]]=function hrcolor_onclick(){ SelectColor(hrcolor,hrcolorpreview) ;}  ;} ;