var OxO8ae6=["Xml","Brushes","sh","CssClass","dp-xml","Style",".dp-xml .cdata { color: #ff1493; }",".dp-xml .tag, .dp-xml .tag-name { color: #069; font-weight: bold; }",".dp-xml .attribute { color: red; }",".dp-xml .attribute-value { color: blue; }","prototype","Aliases","xml","xhtml","xslt","html","ProcessRegexList","length","(\x26lt;|\x3C)\x5C!\x5C[[\x5Cw\x5Cs]*?\x5C[(.|\x5Cs)*?\x5C]\x5C](\x26gt;|\x3E)","gm","cdata","(\x26lt;|\x3C)!--\x5Cs*.*?\x5Cs*--(\x26gt;|\x3E)","comments","([:\x5Cw-.]+)\x5Cs*=\x5Cs*(\x22.*?\x22|\x27.*?\x27|\x5Cw+)*|(\x5Cw+)","attribute","index","attribute-value","(\x26lt;|\x3C)/*\x5C?*(?!\x5C!)|/*\x5C?*(\x26gt;|\x3E)","tag","(?:\x26lt;|\x3C)/*\x5C?*\x5Cs*([:\x5Cw-.]+)","tag-name"];dp[OxO8ae6[2]][OxO8ae6[1]][OxO8ae6[0]]=function (){this[OxO8ae6[3]]=OxO8ae6[4];this[OxO8ae6[5]]=OxO8ae6[6]+OxO8ae6[7]+OxO8ae6[8]+OxO8ae6[9];} ;dp[OxO8ae6[2]][OxO8ae6[1]][OxO8ae6[0]][OxO8ae6[10]]= new dp[OxO8ae6[2]].Highlighter();dp[OxO8ae6[2]][OxO8ae6[1]][OxO8ae6[0]][OxO8ae6[11]]=[OxO8ae6[12],OxO8ae6[13],OxO8ae6[14],OxO8ae6[15],OxO8ae6[13]];dp[OxO8ae6[2]][OxO8ae6[1]][OxO8ae6[0]][OxO8ae6[10]][OxO8ae6[16]]=function (){function Oxb51(Oxb52,Ox4f){Oxb52[Oxb52[OxO8ae6[17]]]=Ox4f;} ;var Ox1fc=0;var Ox935=null;var Oxb53=null;this.GetMatches( new RegExp(OxO8ae6[18],OxO8ae6[19]),OxO8ae6[20]);this.GetMatches( new RegExp(OxO8ae6[21],OxO8ae6[19]),OxO8ae6[22]);Oxb53= new RegExp(OxO8ae6[23],OxO8ae6[19]);while((Ox935=Oxb53.exec(this.code))!=null){if(Ox935[1]==null){continue ;} ;Oxb51(this.matches, new dp[OxO8ae6[2]].Match(Ox935[1],Ox935.index,OxO8ae6[24]));if(Ox935[2]!=undefined){Oxb51(this.matches, new dp[OxO8ae6[2]].Match(Ox935[2],Ox935[OxO8ae6[25]]+Ox935[0].indexOf(Ox935[2]),OxO8ae6[26]));} ;} ;this.GetMatches( new RegExp(OxO8ae6[27],OxO8ae6[19]),OxO8ae6[28]);Oxb53= new RegExp(OxO8ae6[29],OxO8ae6[19]);while((Ox935=Oxb53.exec(this.code))!=null){Oxb51(this.matches, new dp[OxO8ae6[2]].Match(Ox935[1],Ox935[OxO8ae6[25]]+Ox935[0].indexOf(Ox935[1]),OxO8ae6[30]));} ;} ;