var OxOce0b=["inp_action","sel_Method","inp_name","inp_id","inp_encode","sel_target","Name","value","name","id","action","method","encoding","application/x-www-form-urlencoded","","target"];var inp_action=Window_GetElement(window,OxOce0b[0],true);var sel_Method=Window_GetElement(window,OxOce0b[1],true);var inp_name=Window_GetElement(window,OxOce0b[2],true);var inp_id=Window_GetElement(window,OxOce0b[3],true);var inp_encode=Window_GetElement(window,OxOce0b[4],true);var sel_target=Window_GetElement(window,OxOce0b[5],true);UpdateState=function UpdateState_Form(){} ;SyncToView=function SyncToView_Form(){if(element[OxOce0b[6]]){inp_name[OxOce0b[7]]=element[OxOce0b[6]];} ;if(element[OxOce0b[8]]){inp_name[OxOce0b[7]]=element[OxOce0b[8]];} ;inp_id[OxOce0b[7]]=element[OxOce0b[9]];if(element[OxOce0b[10]]){inp_action[OxOce0b[7]]=element[OxOce0b[10]];} ;if(element[OxOce0b[11]]){sel_Method[OxOce0b[7]]=element[OxOce0b[11]];} ;if(element[OxOce0b[12]]==OxOce0b[13]){inp_encode[OxOce0b[7]]=OxOce0b[14];} else {inp_encode[OxOce0b[7]]=element[OxOce0b[12]];} ;if(element[OxOce0b[15]]){sel_target[OxOce0b[7]]=element[OxOce0b[15]];} ;} ;SyncTo=function SyncTo_Form(element){element[OxOce0b[8]]=inp_name[OxOce0b[7]];if(element[OxOce0b[6]]){element[OxOce0b[6]]=inp_name[OxOce0b[7]];} else {if(element[OxOce0b[8]]){element.removeAttribute(OxOce0b[8],0);element[OxOce0b[6]]=inp_name[OxOce0b[7]];} else {element[OxOce0b[6]]=inp_name[OxOce0b[7]];} ;} ;element[OxOce0b[9]]=inp_id[OxOce0b[7]];element[OxOce0b[10]]=inp_action[OxOce0b[7]];element[OxOce0b[11]]=sel_Method[OxOce0b[7]];try{element[OxOce0b[12]]=inp_encode[OxOce0b[7]];} catch(e){} ;element[OxOce0b[15]]=sel_target[OxOce0b[7]];if(element[OxOce0b[15]]==OxOce0b[14]){element.removeAttribute(OxOce0b[15]);} ;if(element[OxOce0b[6]]==OxOce0b[14]){element.removeAttribute(OxOce0b[6]);} ;if(element[OxOce0b[10]]==OxOce0b[14]){element.removeAttribute(OxOce0b[10]);} ;} ;