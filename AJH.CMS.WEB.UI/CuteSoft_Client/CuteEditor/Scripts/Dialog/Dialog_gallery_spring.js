var OxO5232=["is_spring_image","1","gid","zIndex","style","srcImg","documentElement","body","getBoundingClientRect","left","top","getBoxObjectFor","x","y","offsetWidth","offsetHeight","offsetLeft","offsetTop","offsetParent","R","width","px","height","M","spring_expand(\x27","id","\x27)","lastActiveElement","spring_collapse(\x27","display","none","parentNode","block","hidetip","src","url","className","spring_image_popup","void(0)","expand","collapse","onmouseout","onmouseover","onclick","tooltip","click","prototype","MouseEvents","ownerDocument","addEventListener","scroll","attachEvent","onscroll"];function hidetip(){} ;function render_spring_image(Ox29){var Ox322;if(Ox29.getAttribute(OxO5232[0])==OxO5232[1]){return ;} ;Ox29.setAttribute(OxO5232[0],OxO5232[1]);render_spring_image[OxO5232[2]]=render_spring_image[OxO5232[2]]||1;render_spring_image[OxO5232[2]]++;function Ox323(){clearTimeout(this.M);render_spring_image[OxO5232[2]]++;this[OxO5232[4]][OxO5232[3]]=1000000+render_spring_image[OxO5232[2]];var Ox324=this[OxO5232[5]];var Ox325,Ox326,Ox327,Ox328;Ox327=Math.max(document[OxO5232[6]].scrollTop,document[OxO5232[7]].scrollTop);Ox328=Math.max(document[OxO5232[6]].scrollLeft,document[OxO5232[7]].scrollLeft);if(Ox324[OxO5232[8]]){Ox325=Ox324.getBoundingClientRect()[OxO5232[9]];Ox326=Ox324.getBoundingClientRect()[OxO5232[10]];} else {if(document[OxO5232[11]]){Ox325=document.getBoxObjectFor(Ox324)[OxO5232[12]]-Ox328;Ox326=document.getBoxObjectFor(Ox324)[OxO5232[13]]-Ox327;} else {var Ox329=Ox32a(Ox324);Ox325=Ox329[OxO5232[12]]-Ox328;Ox326=Ox329[OxO5232[13]]-Ox327;} ;} ;function Ox32a(element){var Ox329={x:0,y:0,width:element[OxO5232[14]],height:element[OxO5232[15]]};while(element){Ox329[OxO5232[12]]+=element[OxO5232[16]];Ox329[OxO5232[13]]+=element[OxO5232[17]];element=element[OxO5232[18]];} ;return Ox329;} ;if(this[OxO5232[19]]<1.35){this[OxO5232[19]]+=0.1;this[OxO5232[4]][OxO5232[20]]=Math.floor(Ox324[OxO5232[14]]*this[OxO5232[19]])+OxO5232[21];this[OxO5232[4]][OxO5232[22]]=Math.floor(Ox324[OxO5232[15]]*this[OxO5232[19]])+OxO5232[21];Ox326=Math.floor(Ox326+Ox327-(this[OxO5232[14]]-Ox324[OxO5232[14]])/2)+OxO5232[21];;;Ox325=Math.floor(Ox325+Ox328-(this[OxO5232[15]]-Ox324[OxO5232[15]])/2)+OxO5232[21];this[OxO5232[4]][OxO5232[10]]=Ox326;this[OxO5232[4]][OxO5232[9]]=Ox325;this[OxO5232[23]]=setTimeout(OxO5232[24]+this[OxO5232[25]]+OxO5232[26],20);} else {if(render_spring_image[OxO5232[27]]!=this){this[OxO5232[23]]=setTimeout(OxO5232[28]+this[OxO5232[25]]+OxO5232[26],20);} ;} ;} ;function Ox32b(){clearTimeout(this.M);var Ox324=this[OxO5232[5]];var Ox325,Ox326,Ox327,Ox328;Ox327=Math.max(document[OxO5232[6]].scrollTop,document[OxO5232[7]].scrollTop);Ox328=Math.max(document[OxO5232[6]].scrollLeft,document[OxO5232[7]].scrollLeft);if(Ox324[OxO5232[8]]){Ox325=Ox324.getBoundingClientRect()[OxO5232[9]];Ox326=Ox324.getBoundingClientRect()[OxO5232[10]];} else {if(document[OxO5232[11]]){Ox325=document.getBoxObjectFor(Ox324)[OxO5232[12]]-Ox328;Ox326=document.getBoxObjectFor(Ox324)[OxO5232[13]]-Ox327;} ;} ;if(this[OxO5232[19]]>1){this[OxO5232[19]]-=0.1;this[OxO5232[4]][OxO5232[20]]=Math.ceil(Ox324[OxO5232[14]]*this[OxO5232[19]])+OxO5232[21];this[OxO5232[4]][OxO5232[22]]=Math.ceil(Ox324[OxO5232[15]]*this[OxO5232[19]])+OxO5232[21];Ox326=Math.ceil(Ox326+Ox327-(this[OxO5232[14]]-Ox324[OxO5232[14]])/2)+OxO5232[21];;;Ox325=Math.ceil(Ox325+Ox328-(this[OxO5232[15]]-Ox324[OxO5232[15]])/2)+OxO5232[21];this[OxO5232[4]][OxO5232[10]]=Ox326;this[OxO5232[4]][OxO5232[9]]=Ox325;this[OxO5232[23]]=setTimeout(OxO5232[28]+this[OxO5232[25]]+OxO5232[26],0);} else {this[OxO5232[4]][OxO5232[29]]=OxO5232[30];} ;} ;function Ox32c(){var Ox32d=Ox322;if(Ox32d[OxO5232[31]]==null){document[OxO5232[7]].appendChild(Ox32d);} ;if((render_spring_image[OxO5232[27]]!=null)&&(render_spring_image[OxO5232[27]]!=this)){render_spring_image[OxO5232[27]][OxO5232[23]]=setTimeout(OxO5232[28]+render_spring_image[OxO5232[27]][OxO5232[25]]+OxO5232[26],0);} ;render_spring_image[OxO5232[27]]=Ox32d;Ox32d[OxO5232[4]][OxO5232[29]]=OxO5232[32];Ox32d.expand();} ;function Ox32e(){try{if(window[OxO5232[33]]){hidetip();} ;this.collapse();} catch(x){} ;} ;Ox322= new Image();Ox322[OxO5232[34]]=Ox29.getAttribute(OxO5232[35])||Ox29[OxO5232[34]];Ox322[OxO5232[36]]=OxO5232[37];Ox322[OxO5232[25]]=OxO5232[37]+render_spring_image[OxO5232[2]];Ox322[OxO5232[23]]=setTimeout(OxO5232[38],0);Ox322[OxO5232[19]]=1;Ox322[OxO5232[5]]=Ox29;Ox322[OxO5232[39]]=Ox323;Ox322[OxO5232[40]]=Ox32b;Ox322[OxO5232[41]]=Ox32e;Ox322[OxO5232[42]]=Ox32f;Ox322[OxO5232[43]]=function (){insert(Ox29.getAttribute(OxO5232[35]));} ;function Ox32f(){var Ox330=Ox29.getAttribute(OxO5232[44]);showTooltip(Ox330,this);} ;try{Ox29[OxO5232[42]]=Ox32c;} catch(x){} ;} ;if(document[OxO5232[11]]!=null){HTMLElement[OxO5232[46]][OxO5232[45]]=function (){var Ox331=this[OxO5232[48]].createEvent(OxO5232[47]);Ox331.initMouseEvent(OxO5232[45],true,true,this[OxO5232[48]].defaultView,1,0,0,0,0,false,false,false,false,0,null);this.dispatchEvent(Ox331);} ;} ;function spring_image_scrcoll(){render_spring_image[OxO5232[27]]=null;} ;if(window[OxO5232[49]]){window.addEventListener(OxO5232[50],spring_image_scrcoll,true);} else {if(window[OxO5232[51]]){window.attachEvent(OxO5232[52],spring_image_scrcoll);} ;} ;function spring_expand(Ox99){var Ox29=document.getElementById(Ox99);if(Ox29){Ox29.expand();} ;} ;function spring_collapse(Ox99){var Ox29=document.getElementById(Ox99);if(Ox29){Ox29.collapse();} ;} ;