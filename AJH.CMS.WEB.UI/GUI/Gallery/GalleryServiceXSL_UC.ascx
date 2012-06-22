<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="GalleryServiceXSL_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.GalleryServiceXSL_UC" EnableViewState="false" %>
<script language="javascript" type="text/javascript">
    Sys.Application.add_init(function () {
        $.ajax({
            url: '<%=this._GalleryServiceXslUrl %>',
            data: '<%=AJH.CMS.Core.Configuration.CMSConfig.QueryString.CategoryID %>=<%=this._CategoryID %>&' +
             '<%=AJH.CMS.Core.Configuration.CMSConfig.QueryString.XslID %>=<%=base.XSLTemplateID %>',
            beforeSend: function () {
                var dvLoading = document.getElementById('<%=dvLoading.ClientID %>');
                dvLoading.style.display = "block";

                var dvGallery = document.getElementById('<%=dvGallery.ClientID %>');
                dvGallery.style.display = "none";
                dvGallery.innerHTML = '';
            },
            success: function (data, textStatus, jqXHR) {
                var dvLoading = document.getElementById('<%=dvLoading.ClientID %>');
                dvLoading.style.display = "none";

                var indexData = 0;
                indexData = data.indexOf('<');
                var dvGallery = document.getElementById('<%=dvGallery.ClientID %>');
                dvGallery.style.display = "block";
                if (indexData >= 0) {
                    dvGallery.innerHTML = data.substring(indexData);
                }
                else
                    dvGallery.innerHTML = '';
            },
            error: function (jqXHR, textStatus, errorThrown) {
            }
        });
    });
</script>
<div id="dvGallery" runat="server">
</div>
<div id="dvLoading" runat="server" class="panelLoading">
    <img src="App_Themes/Image/cms_loading.gif" alt="Loading..." />
</div>
