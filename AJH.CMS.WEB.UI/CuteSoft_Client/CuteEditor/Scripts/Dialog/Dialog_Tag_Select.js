var OxO883f=["inp_name","inp_access","inp_id","inp_index","inp_size","inp_Multiple","inp_Disabled","inp_item_text","inp_item_value","btnInsertItem","btnUpdateItem","btnDeleteItem","btnMoveUpItem","btnMoveDownItem","list_options","list_options2","inp_item_forecolor","inp_item_backcolor","value","text","color","style","backgroundColor","selectedIndex","options","Please select an item first","length","ondblclick","OPTION","document","id","cssText","Name","name","size","disabled","checked","multiple","tabIndex","","accessKey"];var inp_name=Window_GetElement(window,OxO883f[0x0],true);var inp_access=Window_GetElement(window,OxO883f[0x1],true);var inp_id=Window_GetElement(window,OxO883f[0x2],true);var inp_index=Window_GetElement(window,OxO883f[0x3],true);var inp_size=Window_GetElement(window,OxO883f[0x4],true);var inp_Multiple=Window_GetElement(window,OxO883f[0x5],true);var inp_Disabled=Window_GetElement(window,OxO883f[0x6],true);var inp_item_text=Window_GetElement(window,OxO883f[0x7],true);var inp_item_value=Window_GetElement(window,OxO883f[0x8],true);var btnInsertItem=Window_GetElement(window,OxO883f[0x9],true);var btnUpdateItem=Window_GetElement(window,OxO883f[0xa],true);var btnDeleteItem=Window_GetElement(window,OxO883f[0xb],true);var btnMoveUpItem=Window_GetElement(window,OxO883f[0xc],true);var btnMoveDownItem=Window_GetElement(window,OxO883f[0xd],true);var list_options=Window_GetElement(window,OxO883f[0xe],true);var list_options2=Window_GetElement(window,OxO883f[0xf],true);var inp_item_forecolor=Window_GetElement(window,OxO883f[0x10],true);var inp_item_backcolor=Window_GetElement(window,OxO883f[0x11],true); function SetOption(Ox47b){ Ox47b[OxO883f[0x13]]=inp_item_text[OxO883f[0x12]] ; Ox47b[OxO883f[0x12]]=inp_item_value[OxO883f[0x12]] ; Ox47b[OxO883f[0x15]][OxO883f[0x14]]=inp_item_forecolor[OxO883f[0x12]] ; Ox47b[OxO883f[0x15]][OxO883f[0x16]]=inp_item_backcolor[OxO883f[0x12]] ;}  ; function SetOption2(Ox47b){ Ox47b[OxO883f[0x13]]=inp_item_value[OxO883f[0x12]] ; Ox47b[OxO883f[0x12]]=inp_item_text[OxO883f[0x12]] ; Ox47b[OxO883f[0x15]][OxO883f[0x14]]=inp_item_forecolor[OxO883f[0x12]] ; Ox47b[OxO883f[0x15]][OxO883f[0x16]]=inp_item_backcolor[OxO883f[0x12]] ;}  ; function Select(Ox47b){var Ox47e=Ox47b[OxO883f[0x17]]; list_options[OxO883f[0x17]]=Ox47e ; list_options2[OxO883f[0x17]]=Ox47e ; inp_item_text[OxO883f[0x12]]=list_options2[OxO883f[0x12]] ; inp_item_value[OxO883f[0x12]]=list_options[OxO883f[0x12]] ;}  ; function Insert(){var Ox47b= new Option(); SetOption(Ox47b) ; list_options[OxO883f[0x18]].add(Ox47b) ;var Ox480= new Option(); SetOption2(Ox480) ; list_options2[OxO883f[0x18]].add(Ox480) ; FireUIChanged() ;}  ; function Update(){if(list_options[OxO883f[0x17]]==-0x1){ alert(OxO883f[0x19]) ;return ;} ;var Ox47b=list_options.options(list_options.selectedIndex); SetOption(Ox47b) ;var Ox480=list_options2.options(list_options2.selectedIndex); SetOption2(Ox480) ; FireUIChanged() ;}  ; function Move(Ox60){var Ox47e=list_options[OxO883f[0x17]];if(Ox47e<0x0){return ;} ;var Ox481=Ox47e-Ox60;if(Ox481<0x0){ Ox481=0x0 ;} ;if(Ox481>(list_options[OxO883f[0x18]][OxO883f[0x1a]]-0x1)){ Ox481=list_options[OxO883f[0x18]][OxO883f[0x1a]]-0x1 ;} ;if(Ox47e==Ox481){return ;} ;var Ox47b=list_options.options(list_options.selectedIndex);var Ox25=list_options2[OxO883f[0x12]];var Oxe=list_options[OxO883f[0x12]]; Delete() ; inp_item_text[OxO883f[0x12]]=Ox25 ; inp_item_value[OxO883f[0x12]]=Oxe ;var Ox47b= new Option(); SetOption(Ox47b) ; list_options[OxO883f[0x18]].add(Ox47b,Ox481) ;var Ox480= new Option(); SetOption2(Ox480) ; list_options2[OxO883f[0x18]].add(Ox480,Ox481) ; list_options[OxO883f[0x17]]=Ox481 ; list_options2[OxO883f[0x17]]=Ox481 ; FireUIChanged() ;}  ; function Delete(){if(list_options[OxO883f[0x17]]==-0x1||list_options[OxO883f[0x17]]==-0x1){ alert(OxO883f[0x19]) ;return ;} ;var Ox482=list_options[OxO883f[0x17]];var Ox47b=list_options.options(list_options.selectedIndex); Ox47b.removeNode(true) ; Ox47b=list_options2.options(list_options2.selectedIndex) ; Ox47b.removeNode(true) ;if(list_options[OxO883f[0x18]][OxO883f[0x1a]]>Ox482){ list_options[OxO883f[0x17]]=Ox482 ;} else {if(list_options[OxO883f[0x18]][OxO883f[0x1a]]){ list_options[OxO883f[0x17]]=list_options[OxO883f[0x18]][OxO883f[0x1a]]-0x1 ;} ;} ; list_options.ondblclick() ;if(list_options2[OxO883f[0x18]][OxO883f[0x1a]]>Ox482){ list_options2[OxO883f[0x17]]=Ox482 ;} else {if(list_options2[OxO883f[0x18]][OxO883f[0x1a]]){ list_options2[OxO883f[0x17]]=list_options2[OxO883f[0x18]][OxO883f[0x1a]]-0x1 ;} ;} ; FireUIChanged() ;}  ; list_options[OxO883f[0x1b]]=function list_options_ondblclick(){if(list_options[OxO883f[0x17]]==-0x1){return ;} ;var Ox47b=list_options.options(list_options.selectedIndex); inp_item_text[OxO883f[0x12]]=Ox47b[OxO883f[0x13]] ; inp_item_value[OxO883f[0x12]]=Ox47b[OxO883f[0x12]] ; inp_item_forecolor[OxO883f[0x12]]=inp_item_forecolor[OxO883f[0x15]][OxO883f[0x16]]=Ox47b[OxO883f[0x15]][OxO883f[0x14]] ; inp_item_backcolor[OxO883f[0x12]]=inp_item_backcolor[OxO883f[0x15]][OxO883f[0x16]]=Ox47b[OxO883f[0x15]][OxO883f[0x16]] ;}  ; function CopySelect(Ox485,Ox486){ Ox486[OxO883f[0x18]][OxO883f[0x1a]]=0x0 ;for(var i=0x0;i<Ox485[OxO883f[0x18]][OxO883f[0x1a]];i++){var Ox487=Ox485[OxO883f[0x18]][i];var Ox480;if(Browser_IsWinIE()){ Ox480=Ox486[OxO883f[0x1d]].createElement(OxO883f[0x1c]) ;} else { Ox480=document.createElement(OxO883f[0x1c]) ;} ;if(Ox486[OxO883f[0x1e]]!=OxO883f[0xf]){ Ox480[OxO883f[0x12]]=Ox487[OxO883f[0x12]] ; Ox480[OxO883f[0x13]]=Ox487[OxO883f[0x13]] ;} else { Ox480[OxO883f[0x12]]=Ox487[OxO883f[0x13]] ; Ox480[OxO883f[0x13]]=Ox487[OxO883f[0x12]] ;} ; Ox480[OxO883f[0x15]][OxO883f[0x1f]]=Ox487[OxO883f[0x15]][OxO883f[0x1f]] ; Ox486[OxO883f[0x18]].add(Ox480) ;} ; Ox486[OxO883f[0x17]]=Ox485[OxO883f[0x17]] ;}  ; UpdateState=function UpdateState_Select(){}  ; SyncToView=function SyncToView_Select(){if(element[OxO883f[0x20]]){ inp_name[OxO883f[0x12]]=element[OxO883f[0x20]] ;} ;if(element[OxO883f[0x21]]){ inp_name[OxO883f[0x12]]=element[OxO883f[0x21]] ;} ; inp_id[OxO883f[0x12]]=element[OxO883f[0x1e]] ; inp_size[OxO883f[0x12]]=element[OxO883f[0x22]] ; CopySelect(element,list_options) ; CopySelect(element,list_options2) ; inp_Disabled[OxO883f[0x24]]=element[OxO883f[0x23]] ; inp_Multiple[OxO883f[0x24]]=element[OxO883f[0x25]] ;if(element[OxO883f[0x26]]==0x0){ inp_index[OxO883f[0x12]]=OxO883f[0x27] ;} else { inp_index[OxO883f[0x12]]=element[OxO883f[0x26]] ;} ;if(element[OxO883f[0x28]]){ inp_access[OxO883f[0x12]]=element[OxO883f[0x28]] ;} ;}  ; SyncTo=function SyncTo_Select(element){ element[OxO883f[0x21]]=inp_name[OxO883f[0x12]] ;if(element[OxO883f[0x20]]){ element[OxO883f[0x20]]=inp_name[OxO883f[0x12]] ;} else {if(element[OxO883f[0x21]]){ element.removeAttribute(OxO883f[0x21],0x0) ; element[OxO883f[0x20]]=inp_name[OxO883f[0x12]] ;} else { element[OxO883f[0x20]]=inp_name[OxO883f[0x12]] ;} ;} ; element[OxO883f[0x1e]]=inp_id[OxO883f[0x12]] ; element[OxO883f[0x22]]=inp_size[OxO883f[0x12]] ; element[OxO883f[0x23]]=inp_Disabled[OxO883f[0x24]] ; element[OxO883f[0x25]]=inp_Multiple[OxO883f[0x24]] ; element[OxO883f[0x28]]=inp_access[OxO883f[0x12]] ; element[OxO883f[0x26]]=inp_index[OxO883f[0x12]] ;if(element[OxO883f[0x26]]==OxO883f[0x27]){ element.removeAttribute(OxO883f[0x26]) ;} ;if(element[OxO883f[0x28]]==OxO883f[0x27]){ element.removeAttribute(OxO883f[0x28]) ;} ; CopySelect(list_options,element) ;}  ;