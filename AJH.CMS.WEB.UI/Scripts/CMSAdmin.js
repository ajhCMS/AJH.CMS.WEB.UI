$(document).ready(function () {
    $('.iis-header').click(function () {
        $('.product-navigator').find('div').removeClass('active');
        $(this).addClass('active');
    });

});

$(function () {
    $('.scroll-pane left-menu').jScrollPane();

});

function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(window.location.search);
    if (results == null)
        return "";
    else
        return decodeURIComponent(results[1].replace(/\+/g, " "));
}

$(document).ready(function () {
    var ParameterValue = getParameterByName('ModuleID');
    if (ParameterValue != null && ParameterValue != '') {
        var hrefParentModule = document.getElementById('hrefParentModule' + ParameterValue);
        if (hrefParentModule != null) {
            hrefParentModule.className = hrefParentModule.className + " active-top-menu-item";
        }
    }

    var ulMenuChildItems = document.getElementById('ulMenuChildItems');
    if (ulMenuChildItems != null) {
        var currentPage = window.location.pathname;
        var hrefItems = ulMenuChildItems.getElementsByTagName('a');
        var liItems = ulMenuChildItems.getElementsByTagName('li');
        for (var i = 0; i < hrefItems.length; i++) {
            if (hrefItems[i].href.indexOf(currentPage) > -1) {
                liItems[i].className = liItems[i].className + " active-left-menu-item";
                break;
            }
        }
    }
});