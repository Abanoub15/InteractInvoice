function viewToaster(msg) {
    toastr.options.closeButton = true;
    toastr.options.timeOut = 0;
    toastr.options.extendedTimeOut = 0;
    toastr.info(msg);
    //if (msgType == 1 || 4) // no error
    //{
    //    toastr.info(msg, operation);
    //}
    //else {
    //    toastr.error(msg, operation)
    //}
}

function ChangeProgressBar(value) {
    if (value < 100) {
        $('#ProgressBar').css('display', 'block');
        $("#ProgressBar").progressbar("option", "value", value);
    }
    else {
        $("#ProgressBar").progressbar("option", "value", value);
        $('#ProgressBar').css('display', 'none');
    }
    
}
