
if(!window.editorconstant)window.editorconstant={};

// When creating a table using the Wizard, the following default attributes apply.
editorconstant._CreateEditingTableStyle = "<table border='0' cellspacing='2' cellpadding='2' width='500'>";
// When creating a new div box, the following default attributes apply.
editorconstant._BoxFormattingStyle = "border: solid 1px #666666;";
// Default editorconstant ornaments for the ColorPicker dialog
editorconstant._colorpickerDialogFeature = "dialogWidth:500px;dialogHeight:335px;help:0;status:0;resizable:1";
// Default editorconstant ornaments for the Preview dialog
editorconstant._previewDialogFeature = "dialogWidth:640px;dialogHeight:480px;help:0;status:0;resizable:1";
// Default editorconstant ornaments for the Anchor dialog
editorconstant._anchorDialogFeature = "help:0;status:0;resizable:0;dialogWidth:320px;dialogHeight:250px;";
// Default editorconstant ornaments for the Link dialog
editorconstant._linkDialogFeature = "help:0;status:0;resizable:0;dialogWidth:460px;dialogHeight:214px;";
// Default editorconstant ornaments for the Char dialog
editorconstant._charDialogFeature = "help:0;status:0;resizable:0;dialogWidth:480px;dialogHeight:385px;";
// Default editorconstant ornaments for the find dialog
editorconstant._findDialogFeature = "help:0;status:0;resizable:1;dialogWidth:385px;dialogHeight:180px;";
// Default editorconstant ornaments for the Emotion dialog
editorconstant._emotionDialogFeature = "help:0;status:0;resizable:0;dialogWidth:320px;dialogHeight:365px;";
// Default editorconstant ornaments for the Template dialog
editorconstant._templateDialogFeature = "status:0;dialogWidth:660px;dialogHeight:470px; scroll: 0; resizable: 0; help:0";
// Default editorconstant ornaments for the Create Template dialog
editorconstant._createtemplateDialogFeature = "dialogWidth:760px;dialogHeight:385px;help:no;scroll:no;status:no;resizable:0;";
// Default editorconstant ornaments for the Document dialog
editorconstant._documentDialogFeature = "status:0;dialogWidth:600px;dialogHeight:560px; scroll: 0; resizable: 0; help:0";
// Default editorconstant ornaments for the gallery dialog
editorconstant._galleryDialogFeature = "status:0;dialogWidth:564px;dialogHeight:630px; scroll: 0; resizable: yes; help:0";
// Default editorconstant ornaments for the image dialog
editorconstant._imageDialogFeature = "status:0;dialogWidth:620px;dialogHeight:595px; scroll: 0; resizable: 0; help:0";
// Default editorconstant ornaments for the image map dialog
editorconstant._imagemapDialogFeature = "status:0;dialogWidth:610px;dialogHeight:400px; scroll: 0; resizable: yes; help:0";
// Default editorconstant ornaments for the media dialog
editorconstant._mediaDialogFeature = "status:0;dialogWidth:580px;dialogHeight:550px; scroll: 0; resizable: 0; help:0";
// Default editorconstant ornaments for the flash dialog
editorconstant._flashDialogFeature = "status:0;dialogWidth:587px;dialogHeight:595px; scroll: 0; resizable: 0; help:0";
// Default editorconstant ornaments for the page properties dialog
editorconstant._pageDialogFeature = "status:0;dialogWidth:490px;dialogHeight:520px; scroll: 0; resizable: yes; help:0";
// Default editorconstant ornaments for the Tag dialog
editorconstant._tagDialogFeature = "help:0;status:0;resizable:0;dialogWidth:453px;dialogHeight:515px;";
// Default editorconstant ornaments for the help 
editorconstant._helpDialogFeature = "status:0;dialogWidth:760px;dialogHeight:450px; scroll: 0; resizable: yes; help:0";
// Default editorconstant ornaments for the Rule dialog
editorconstant._RuleDialogFeature = "help:0;status:0;resizable:1;dialogWidth:340px;dialogHeight:210px;";
// Default style in the source view 
editorconstant._editorSourceStyle = "background:#ffffff;margin:0;padding:0;color:black";
// Default editorconstant ornaments for the paste dialog
editorconstant._pastetextDialogFeature = "help:0;status:0;resizable:0;dialogWidth:450px;dialogHeight:400px;";
// Default editorconstant ornaments for the universal keyboard dialog
editorconstant._keyboardDialogFeature = "help:0;status:0;resizable:0;dialogWidth:415px;dialogHeight:310px;";
// All colors in the following color array will be used in the editor color picker
editorconstant.colorsArray = new Array("#000000","#993300","#333300","#003300","#003366","#000080","#333399","#333333",
			"#800000","#FF6600","#808000","#008000","#008080","#0000FF","#666699","#808080",
			"#FF0000","#FF9900","#99CC00","#339966","#33CCCC","#3366FF","#800080","#999999",
			"#FF00FF","#FFCC00","#FFFF00","#00FF00","#00FFFF","#00CCFF","#993366","#C0C0C0",
			"#FF99CC","#FFCC99","#FFFF99","#CCFFCC","#CCFFFF","#99CCFF","#CC99FF","#FFFFFF");
// Specifies whether MoreColors button in the color picker are visible 
editorconstant.ShowMoreColors = true;
editorconstant.layerdefaultstyle = "position:absolute;width:104px; height: 104px";
editorconstant.ToggleBorderStyle='1px dotted #000000';
editorconstant.DisableCtrlZ = false;
//By default, when users double click a control, a tag property dialog will open. Set it to true if you want to disable this feature.
editorconstant.DisableDoubleClickEvent = false; 
editorconstant.AbsolutePositionValue='absolute'; //'relative';

//set to window for compatible
for(var p in editorconstant)window[p]=editorconstant[p];



