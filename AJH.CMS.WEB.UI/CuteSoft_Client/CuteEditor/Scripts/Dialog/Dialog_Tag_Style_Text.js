var OxOf93e=["","sel_align","sel_valign","sel_justify","sel_letter","tb_letter","sel_letter_unit","sel_line","tb_line","sel_line_unit","tb_indent","sel_indent_unit","sel_direction","sel_writingmode","outer","div_demo","disabled","selectedIndex","cssText","style","textAlign","value","verticalAlign","textJustify","letterSpacing","length","options","lineHeight","textIndent","direction","writingMode"]; function ParseFloatToString(Ox24){var Oxe=parseFloat(Ox24);if(isNaN(Oxe)){return OxOf93e[0x0];} ;return Oxe+OxOf93e[0x0];}  ;var sel_align=Window_GetElement(window,OxOf93e[0x1],true);var sel_valign=Window_GetElement(window,OxOf93e[0x2],true);var sel_justify=Window_GetElement(window,OxOf93e[0x3],true);var sel_letter=Window_GetElement(window,OxOf93e[0x4],true);var tb_letter=Window_GetElement(window,OxOf93e[0x5],true);var sel_letter_unit=Window_GetElement(window,OxOf93e[0x6],true);var sel_line=Window_GetElement(window,OxOf93e[0x7],true);var tb_line=Window_GetElement(window,OxOf93e[0x8],true);var sel_line_unit=Window_GetElement(window,OxOf93e[0x9],true);var tb_indent=Window_GetElement(window,OxOf93e[0xa],true);var sel_indent_unit=Window_GetElement(window,OxOf93e[0xb],true);var sel_direction=Window_GetElement(window,OxOf93e[0xc],true);var sel_writingmode=Window_GetElement(window,OxOf93e[0xd],true);var outer=Window_GetElement(window,OxOf93e[0xe],true);var div_demo=Window_GetElement(window,OxOf93e[0xf],true); UpdateState=function UpdateState_Text(){ tb_letter[OxOf93e[0x10]]=sel_letter_unit[OxOf93e[0x10]]=(sel_letter[OxOf93e[0x11]]>0x0) ; tb_line[OxOf93e[0x10]]=sel_line_unit[OxOf93e[0x10]]=(sel_line[OxOf93e[0x11]]>0x0) ; div_demo[OxOf93e[0x13]][OxOf93e[0x12]]=element[OxOf93e[0x13]][OxOf93e[0x12]] ;}  ; SyncToView=function SyncToView_Text(){ sel_align[OxOf93e[0x15]]=element[OxOf93e[0x13]][OxOf93e[0x14]] ; sel_valign[OxOf93e[0x15]]=element[OxOf93e[0x13]][OxOf93e[0x16]] ; sel_justify[OxOf93e[0x15]]=element[OxOf93e[0x13]][OxOf93e[0x17]] ; sel_letter[OxOf93e[0x15]]=element[OxOf93e[0x13]][OxOf93e[0x18]] ; sel_letter_unit[OxOf93e[0x11]]=0x0 ;if(sel_letter[OxOf93e[0x11]]==-0x1){if(ParseFloatToString(element[OxOf93e[0x13]].letterSpacing)){ tb_letter[OxOf93e[0x15]]=ParseFloatToString(element[OxOf93e[0x13]].letterSpacing) ;for(var i=0x0;i<sel_letter_unit[OxOf93e[0x1a]][OxOf93e[0x19]];i++){var Ox60=sel_letter_unit[OxOf93e[0x1a]][i][OxOf93e[0x15]];if(Ox60&&element[OxOf93e[0x13]][OxOf93e[0x18]].indexOf(Ox60)!=-0x1){ sel_letter_unit[OxOf93e[0x11]]=i ;break ;} ;} ;} ;} ; sel_line[OxOf93e[0x15]]=element[OxOf93e[0x13]][OxOf93e[0x1b]] ; sel_line_unit[OxOf93e[0x11]]=0x0 ;if(sel_line[OxOf93e[0x11]]==-0x1){if(ParseFloatToString(element[OxOf93e[0x13]].lineHeight)){ tb_line[OxOf93e[0x15]]=ParseFloatToString(element[OxOf93e[0x13]].lineHeight) ;for(var i=0x0;i<sel_line_unit[OxOf93e[0x1a]][OxOf93e[0x19]];i++){var Ox60=sel_line_unit[OxOf93e[0x1a]][i][OxOf93e[0x15]];if(Ox60&&element[OxOf93e[0x13]][OxOf93e[0x1b]].indexOf(Ox60)!=-0x1){ sel_line_unit[OxOf93e[0x11]]=i ;break ;} ;} ;} ;} ; sel_indent_unit[OxOf93e[0x11]]=0x0 ;if(!isNaN(ParseFloatToString(element[OxOf93e[0x13]].textIndent))){ tb_indent[OxOf93e[0x15]]=ParseFloatToString(element[OxOf93e[0x13]].textIndent) ;for(var i=0x0;i<sel_indent_unit[OxOf93e[0x1a]][OxOf93e[0x19]];i++){var Ox60=sel_indent_unit[OxOf93e[0x1a]][i][OxOf93e[0x15]];if(Ox60&&element[OxOf93e[0x13]][OxOf93e[0x1c]].indexOf(Ox60)!=-0x1){ sel_indent_unit[OxOf93e[0x11]]=i ;break ;} ;} ;} ; sel_direction[OxOf93e[0x15]]=element[OxOf93e[0x13]][OxOf93e[0x1d]] ; sel_writingmode[OxOf93e[0x15]]=element[OxOf93e[0x13]][OxOf93e[0x1e]] ;}  ; SyncTo=function SyncTo_Text(element){ element[OxOf93e[0x13]][OxOf93e[0x14]]=sel_align[OxOf93e[0x15]] ; element[OxOf93e[0x13]][OxOf93e[0x16]]=sel_valign[OxOf93e[0x15]] ; element[OxOf93e[0x13]][OxOf93e[0x17]]=sel_justify[OxOf93e[0x15]] ;if(sel_letter[OxOf93e[0x11]]>0x0){ element[OxOf93e[0x13]][OxOf93e[0x18]]=sel_letter[OxOf93e[0x15]] ;} else {if(ParseFloatToString(tb_letter.value)){ element[OxOf93e[0x13]][OxOf93e[0x18]]=ParseFloatToString(tb_letter.value)+sel_letter_unit[OxOf93e[0x15]] ;} else { element[OxOf93e[0x13]][OxOf93e[0x18]]=OxOf93e[0x0] ;} ;} ;if(sel_line[OxOf93e[0x11]]>0x0){ element[OxOf93e[0x13]][OxOf93e[0x1b]]=sel_line[OxOf93e[0x15]] ;} else {if(ParseFloatToString(tb_line.value)){ element[OxOf93e[0x13]][OxOf93e[0x1b]]=ParseFloatToString(tb_line.value)+sel_line_unit[OxOf93e[0x15]] ;} else { element[OxOf93e[0x13]][OxOf93e[0x1b]]=OxOf93e[0x0] ;} ;} ;if(ParseFloatToString(tb_indent.value)){ element[OxOf93e[0x13]][OxOf93e[0x1c]]=ParseFloatToString(tb_indent.value)+sel_indent_unit[OxOf93e[0x15]] ;} else { element[OxOf93e[0x13]][OxOf93e[0x1c]]=OxOf93e[0x0] ;} ; element[OxOf93e[0x13]][OxOf93e[0x1d]]=sel_direction[OxOf93e[0x15]]||OxOf93e[0x0] ; element[OxOf93e[0x13]][OxOf93e[0x1e]]=sel_writingmode[OxOf93e[0x15]]||OxOf93e[0x0] ;}  ;