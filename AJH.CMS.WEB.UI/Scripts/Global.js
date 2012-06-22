function ConfirmOperation(ControlID, ConfirmMessage) {
    var checkItem = false;
    var control = document.getElementById(ControlID);
    if (control == null)
        return true;
    var chkItems = control.getElementsByTagName('input');
    for (i = 0; i < chkItems.length; i++) {
        if (chkItems[i].type == 'checkbox') {
            if (chkItems[i] != null && chkItems[i].checked) {
                checkItem = true;
            }
        }
    }
    if (!checkItem) {
        alert('Please select at least one record.');
        return false;
    }
    return confirm(ConfirmMessage);
}

function PortalLanguageSelectValidation(sender, args) {
    hdnPortalLanguageSelect = sender.getAttribute("hdnPortalLanguageSelect");
    if (hdnPortalLanguageSelect != null) {
        hdnPortalLanguageSelect = document.getElementById(hdnPortalLanguageSelect);
        if (hdnPortalLanguageSelect != null && hdnPortalLanguageSelect.value <= 0) {
            args.IsValid = false;
        }
    }
}