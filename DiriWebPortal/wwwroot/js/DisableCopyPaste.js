
function DisableCopyPaste(domName) {
    $(document).ready(function () {
        $(domName).bind('cut copy paste', function (event) {
            event.preventDefault();
        });
    });
}


