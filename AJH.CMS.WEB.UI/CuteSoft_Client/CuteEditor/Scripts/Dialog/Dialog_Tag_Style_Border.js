var OxOcc5e=["SetStyle","length","","GetStyle","GetText",":",";","cssText","div_selector_event","div_selector","sel_part","tb_margin","sel_margin_unit","tb_padding","sel_padding_unit","tb_border","sel_border_unit","sel_border","sel_style","inp_color","outer","div_demo","offsetWidth","offsetHeight","Top","Left","Bottom","Right","onmousemove","runtimeStyle","border","4px solid red","style","onmouseout","onclick","value","onchange","disabled","selectedIndex","4px solid blue","-","Color"," ","#7f7c75","backgroundColor","Style","Width","options","margin","padding"]; function pause(Ox39f){var Oxf2= new Date();var Ox3a0=Oxf2.getTime()+Ox39f;while(true){ Oxf2= new Date() ;if(Oxf2.getTime()>Ox3a0){return ;} ;} ;}  ; function StyleClass(Ox176){var Ox3a2=[];var Ox3a3={};if(Ox176){ Ox3a8() ;} ; this[OxOcc5e[0x0]]=function SetStyle(name,Ox1a6,Ox3a5){ name=name.toLowerCase() ;for(var i=0x0;i<Ox3a2[OxOcc5e[0x1]];i++){if(Ox3a2[i]==name){break ;} ;} ; Ox3a2[i]=name ; Ox3a3[name]=Ox1a6?(Ox1a6+(Ox3a5||OxOcc5e[0x2])):OxOcc5e[0x2] ;}  ; this[OxOcc5e[0x3]]=function GetStyle(name){ name=name.toLowerCase() ;return Ox3a3[name]||OxOcc5e[0x2];}  ; this[OxOcc5e[0x4]]=function Ox3a7(){var Ox176=OxOcc5e[0x2];for(var i=0x0;i<Ox3a2[OxOcc5e[0x1]];i++){var n=Ox3a2[i];var p=Ox3a3[n];if(p){ Ox176+=n+OxOcc5e[0x5]+p+OxOcc5e[0x6] ;} ;} ;return Ox176;}  ; function Ox3a8(){var arr=Ox176.split(OxOcc5e[0x6]);for(var i=0x0;i<arr[OxOcc5e[0x1]];i++){var p=arr[i].split(OxOcc5e[0x5]);var n=p[0x0].replace(/^\s+/g,OxOcc5e[0x2]).replace(/\s+$/g,OxOcc5e[0x2]).toLowerCase(); Ox3a2[Ox3a2[OxOcc5e[0x1]]]=n ; Ox3a3[n]=p[0x1] ;} ;}  ;}  ; function GetStyle(Ox3a9,name){return  new StyleClass(Ox3a9.cssText).GetStyle(name);}  ; function SetStyle(Ox3a9,name,Ox1a6,Ox3aa){var Ox3ab= new StyleClass(Ox3a9.cssText); Ox3ab.SetStyle(name,Ox1a6,Ox3aa) ; Ox3a9[OxOcc5e[0x7]]=Ox3ab.GetText() ;}  ; function ParseFloatToString(Ox24){var Oxe=parseFloat(Ox24);if(isNaN(Oxe)){return OxOcc5e[0x2];} ;return Oxe+OxOcc5e[0x2];}  ;var div_selector_event=Window_GetElement(window,OxOcc5e[0x8],true);var div_selector=Window_GetElement(window,OxOcc5e[0x9],true);var sel_part=Window_GetElement(window,OxOcc5e[0xa],true);var tb_margin=Window_GetElement(window,OxOcc5e[0xb],true);var sel_margin_unit=Window_GetElement(window,OxOcc5e[0xc],true);var tb_padding=Window_GetElement(window,OxOcc5e[0xd],true);var sel_padding_unit=Window_GetElement(window,OxOcc5e[0xe],true);var tb_border=Window_GetElement(window,OxOcc5e[0xf],true);var sel_border_unit=Window_GetElement(window,OxOcc5e[0x10],true);var sel_border=Window_GetElement(window,OxOcc5e[0x11],true);var sel_style=Window_GetElement(window,OxOcc5e[0x12],true);var inp_color=Window_GetElement(window,OxOcc5e[0x13],true);var outer=Window_GetElement(window,OxOcc5e[0x14],true);var div_demo=Window_GetElement(window,OxOcc5e[0x15],true); function GetPartFromEvent(){var src=Event_GetSrcElement();var Ox30=Event_GetOffsetX();var Ox2f=Event_GetOffsetY();if(src==div_selector){ Ox30+=0xa ; Ox2f+=0xa ;} ;var Ox2b=0xf-Ox30;var Oxf=Ox30-(div_selector_event[OxOcc5e[0x16]]-0xf);var Ox25=0xf-Ox2f;var Ox17=Ox2f-(div_selector_event[OxOcc5e[0x17]]-0xf);if(Ox2b>0x0){if(Ox25>0x0){return Ox2b>Ox25?OxOcc5e[0x18]:OxOcc5e[0x19];} ;if(Ox17>0x0){return Ox2b>Ox17?OxOcc5e[0x1a]:OxOcc5e[0x19];} ;return OxOcc5e[0x19];} ;if(Oxf>0x0){if(Ox25>0x0){return Oxf>Ox25?OxOcc5e[0x18]:OxOcc5e[0x1b];} ;if(Ox17>0x0){return Oxf>Ox17?OxOcc5e[0x1a]:OxOcc5e[0x1b];} ;return OxOcc5e[0x1b];} ;if(Ox25>0x0){return OxOcc5e[0x18];} ;if(Ox17>0x0){return OxOcc5e[0x1a];} ;return OxOcc5e[0x2];}  ; div_selector_event[OxOcc5e[0x1c]]=function div_selector_event_onmousemove(){var Ox3c4=GetPartFromEvent();if(Browser_IsWinIE()){ div_selector[OxOcc5e[0x1d]][OxOcc5e[0x7]]=OxOcc5e[0x2] ; div_selector[OxOcc5e[0x1d]][OxOcc5e[0x1e]+Ox3c4]=OxOcc5e[0x1f] ;} else { div_selector[OxOcc5e[0x20]][OxOcc5e[0x7]]=OxOcc5e[0x2] ; div_selector[OxOcc5e[0x20]][OxOcc5e[0x1e]+Ox3c4]=OxOcc5e[0x1f] ;} ;}  ; div_selector_event[OxOcc5e[0x21]]=function div_selector_event_onmouseout(){if(Browser_IsWinIE()){ div_selector[OxOcc5e[0x1d]][OxOcc5e[0x7]]=OxOcc5e[0x2] ;} else { div_selector[OxOcc5e[0x20]][OxOcc5e[0x7]]=OxOcc5e[0x2] ;} ;}  ; div_selector_event[OxOcc5e[0x22]]=function div_selector_event_onclick(){ sel_part[OxOcc5e[0x23]]=GetPartFromEvent() ; SyncToViewInternal() ; UpdateState() ;}  ; sel_part[OxOcc5e[0x24]]=function sel_part_onchange(){ SyncToViewInternal() ; UpdateState() ;}  ; UpdateState=function UpdateState_Border(){ tb_border[OxOcc5e[0x25]]=sel_border_unit[OxOcc5e[0x25]]=(sel_border[OxOcc5e[0x26]]>0x0) ; div_demo[OxOcc5e[0x20]][OxOcc5e[0x7]]=element[OxOcc5e[0x20]][OxOcc5e[0x7]] ; div_selector[OxOcc5e[0x20]][OxOcc5e[0x7]]=OxOcc5e[0x2] ; div_selector[OxOcc5e[0x20]][OxOcc5e[0x1e]+(sel_part[OxOcc5e[0x23]]||OxOcc5e[0x2])]=OxOcc5e[0x27] ;}  ; SyncToView=function SyncToView_Border(){var Ox3c4=sel_part[OxOcc5e[0x23]];var Ox3c5=Ox3c4?OxOcc5e[0x28]+Ox3c4:Ox3c4;if(Browser_IsWinIE()){ inp_color[OxOcc5e[0x23]]=element[OxOcc5e[0x20]][OxOcc5e[0x1e]+Ox3c4+OxOcc5e[0x29]] ;} else {var arr=revertColor(element[OxOcc5e[0x20]][OxOcc5e[0x1e]+Ox3c4+OxOcc5e[0x29]]).split(OxOcc5e[0x2a]);if(arr[0x0]!=OxOcc5e[0x2b]){ inp_color[OxOcc5e[0x23]]=arr[0x0] ;} ;} ; inp_color[OxOcc5e[0x20]][OxOcc5e[0x2c]]=inp_color[OxOcc5e[0x23]] ; sel_style[OxOcc5e[0x23]]=element[OxOcc5e[0x20]][OxOcc5e[0x1e]+Ox3c4+OxOcc5e[0x2d]] ; sel_border[OxOcc5e[0x23]]=element[OxOcc5e[0x20]][OxOcc5e[0x1e]+Ox3c4+OxOcc5e[0x2e]] ;var Ox4aa=element[OxOcc5e[0x20]][OxOcc5e[0x1e]+Ox3c4+OxOcc5e[0x2e]]; tb_border[OxOcc5e[0x23]]=ParseFloatToString(Ox4aa) ;if(tb_border[OxOcc5e[0x23]]){for(var i=0x0;i<sel_border_unit[OxOcc5e[0x2f]][OxOcc5e[0x1]];i++){var Ox60=sel_border_unit[OxOcc5e[0x2f]][i][OxOcc5e[0x23]];if(Ox60&&Ox4aa.indexOf(Ox60)!=-0x1){ sel_border_unit[OxOcc5e[0x26]]=i ;break ;} ;} ;} ;var Ox4ab=element[OxOcc5e[0x20]][OxOcc5e[0x30]+Ox3c4]; tb_margin[OxOcc5e[0x23]]=ParseFloatToString(Ox4ab) ;if(tb_margin[OxOcc5e[0x23]]){for(var i=0x0;i<sel_margin_unit[OxOcc5e[0x2f]][OxOcc5e[0x1]];i++){var Ox60=sel_margin_unit[OxOcc5e[0x2f]][i][OxOcc5e[0x23]];if(Ox60&&Ox4ab.indexOf(Ox60)!=-0x1){ sel_margin_unit[OxOcc5e[0x26]]=i ;break ;} ;} ;} ;var Ox4ac=element[OxOcc5e[0x20]][OxOcc5e[0x31]+Ox3c4]; tb_padding[OxOcc5e[0x23]]=ParseFloatToString(Ox4ac) ;if(tb_padding[OxOcc5e[0x23]]){for(var i=0x0;i<sel_padding_unit[OxOcc5e[0x2f]][OxOcc5e[0x1]];i++){var Ox60=sel_padding_unit[OxOcc5e[0x2f]][i][OxOcc5e[0x23]];if(Ox60&&Ox4ac.indexOf(Ox60)!=-0x1){ sel_padding_unit[OxOcc5e[0x26]]=i ;break ;} ;} ;} ;}  ; SyncTo=function SyncTo_Border(element){var Ox3c4=sel_part[OxOcc5e[0x23]];var Ox3c5=Ox3c4?OxOcc5e[0x28]+Ox3c4:Ox3c4;var Ox3c6=OxOcc5e[0x2];if(sel_border[OxOcc5e[0x26]]>0x0){ Ox3c6=sel_border[OxOcc5e[0x23]] ;} else {if(ParseFloatToString(tb_border.value)){ Ox3c6=ParseFloatToString(tb_border.value)+sel_border_unit[OxOcc5e[0x23]] ;} else { Ox3c6=OxOcc5e[0x2] ;} ;} ;var Ox70=inp_color[OxOcc5e[0x23]]||OxOcc5e[0x2];var Ox3a9=sel_style[OxOcc5e[0x23]]||OxOcc5e[0x2];if(Ox3c6||Ox3a9){ SetStyle(element[OxOcc5e[0x20]],OxOcc5e[0x1e]+Ox3c5,Ox3c6+OxOcc5e[0x2a]+Ox3a9+OxOcc5e[0x2a]+Ox70) ;} else { SetStyle(element[OxOcc5e[0x20]],OxOcc5e[0x1e]+Ox3c5,OxOcc5e[0x2]) ;} ; SetStyle(element[OxOcc5e[0x20]],OxOcc5e[0x30]+Ox3c5,ParseFloatToString(tb_margin.value),sel_margin_unit.value) ; SetStyle(element[OxOcc5e[0x20]],OxOcc5e[0x31]+Ox3c5,ParseFloatToString(tb_padding.value),sel_padding_unit.value) ;}  ;if(!Browser_IsWinIE()){ inp_color[OxOcc5e[0x22]]=function inp_color_onclick(){ SelectColor(inp_color) ;}  ;} ;