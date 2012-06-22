$(document).ready(function () {
    $('#MainContent_upnlLogin').css("marginTop", $(window).height() / 2 - 170);
    $('#MainContent_upnlLogin').delay('400').fadeIn("slow");
});
$(window).resize(function () {
    $('#MainContent_upnlLogin').css("marginTop", $(window).height() / 2 - 170);
});