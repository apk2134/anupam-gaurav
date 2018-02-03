function CreateModalDialog(displayText, IsAlert, onYes, onNo, dialogWidth, dialogHeight) {

    if ($('#mskModal').length == 0) {
        //create mask
        var mskWorld = $('<div id="mskModal" class="modalWorld"></div>');
        var dialogTable = $('<table style="width:80%;margin-left: 49px;margin-top: 20px;"><tr><td class="controlbox"></td></tr>' +
            '<tr><td class="content"></td></tr>' +
            '<tr><td class="responsebox" align="center"></td></tr>' +
            '</table>');
        var yesButton = $('<button id="btnYes" role="button" class="btn btn-info btn-lg btn3d"><span class="glyphicon glyphicon-ok"></span>Yes</button>');
        var noButton = $('<button id="btnNo" role="button" class="button slim primary">No</button>');
        yesButton.on('click', function () { CloseModalDialog(1); });
        noButton.on('click', function () { CloseModalDialog(0); });

        //var closebutton = $('<div id="mskCloseBtn" class="close"><a href="javascript:void(0);return false;">&times;</a></div>');
        var closebutton = $('<div id="mskCloseBtn" class="close"></div>');
        closebutton.on('click', function () { CloseModalDialog(3); });

        var content = $('<div id="content" style="text-align: center;word-break: break-word;color:#ffffff;">' + displayText + '</div>');

        dialogTable.find('.controlbox').append(closebutton);
        dialogTable.find('.content').append(content);
        if (IsAlert) {
            yesButton.html("OK");
            dialogTable.find('.responsebox').append(yesButton);
        } else {
            dialogTable.find('.responsebox').append(yesButton).append(noButton);
        }

        var dialogWrapper = $('<div id="dialogWrapper" class="btn-primary btn-lg btn3d"></div>');
        dialogWrapper.append(dialogTable);

        //set action recort
        mskWorld.data('onYes', onYes);
        mskWorld.data('onNo', onNo);
        mskWorld.css({ 'opacity': '0' });
        dialogWrapper.css({ 'opacity': '0' });
        if (dialogWidth != null) dialogWrapper.css({ 'width': dialogWidth });
        if (dialogHeight != null) dialogWrapper.css({ 'height': dialogHeight });

        mskWorld.width($(document).width());
        mskWorld.height($(document).height());
        $('body').append(mskWorld);
        $('body').append(dialogWrapper);

        dialogWrapper.css({ 'left': ($(window).width() / 2 - dialogWrapper.width() / 2) + 'px', 'top': ($(window).height() / 2 - dialogWrapper.height() / 2) + 'px' });
        //dialogTable.height(dialogWrapper.height() - 10);
        mskWorld.fadeTo(300, 0.7, function () { });
        $('#dialogWrapper').fadeTo(300, 1, function () {
            yesButton.focus();
        });
    }
    return false;
}


function CloseModalDialog(dialogResult) {
    var mskWorld = $('#mskModal');
    if (mskWorld) {
        try {
            var onYes = mskWorld.data('onYes');
            var onNo = mskWorld.data('onNo');
            mskWorld.fadeTo(300, 0, function () { mskWorld.remove(); });
            $('#dialogWrapper').fadeTo(300, 0, function () {
                $('#dialogWrapper').remove();
                if (dialogResult == 1 && onYes) onYes();
                else if (!dialogResult == 0 && onNo) onNo();
            });
        } catch (err) { }
    }
}
function CreateMskWorld(callbackFunction, dialogWidth, dialogHeight, onCloseFunction) {
    if ($('#mskWorld').length == 0) {
        //create mask
        var mskWorld = $('<div id="mskWorld" class="maskWorld"></div>');
        var closebutton = $('<div id="mskCloseBtn"></div>');
        var wrapper = $('<div id="mskWrapper">&#x274c</div>');
        var content = $('<div id="content"><div id="mskDataLoading">Please wait while data is loading...</div></div>');

        closebutton.on('click', function () {
            CloseMskWorld(onCloseFunction);
        });

        //set action recort
        //mskWorld.data("action", action);
        //mskWorld.data("target", target);
        mskWorld.data('callback', callbackFunction);

        mskWorld.css({ 'opacity': '0' });
        wrapper.css({ 'opacity': '0' });
        if (dialogWidth != null) wrapper.css({ 'width': dialogWidth });
        if (dialogHeight != null) wrapper.css({ 'height': dialogHeight });

        mskWorld.width($(document).width());
        mskWorld.height($(document).height());
        $('body').append(mskWorld);
        $('body').append(wrapper.append(closebutton).append(content));

        wrapper.css({ 'left': ($(window).width() / 2 - wrapper.width() / 2) + 'px', 'top': ($(window).height() / 2 - wrapper.height() / 2) + 'px' });
        //content.height(wrapper.height() -80);

        mskWorld.fadeTo(300, 0.5, function () { });
        $('#mskWrapper').fadeTo(300, 1, function () { });
        return content;
    }
    return null;
}
function CloseMskWorld(callbackfunction) {
    var mskWorld = $('#mskWorld');
    if (mskWorld) {
        try {
            mskWorld.fadeTo(300, 0, function () { mskWorld.remove(); });
            $('#mskWrapper').fadeTo(300, 0, function () { $('#mskWrapper').remove(); });
            if (callbackfunction) {
                callbackfunction();
            }
        } catch (err) { }
    }
}
function isNullAndUndef(variable) {

    if (variable == null && variable == undefined) {
        return "Please wait while data is loading...";
    }
    else {
        return variable;
    }

    //return (variable !== null && variable !== undefined);
}
function CreateMskWorld(callbackFunction, dialogWidth, dialogHeight, onCloseFunction, data) {
    if ($('#mskWorld').length == 0) {
        //create mask
        var mskWorld = $('<div id="mskWorld" class="maskWorld"></div>');
        var closebutton = $('<div id="mskCloseBtn" class="glyphicon glyphicon-remove-circle grow"></div>');
        //var closebutton = $(' <button type="button" id="mskCloseBtn" class="btn btn-default" data-dismiss="modal"></button>');
        var wrapper = $('<div id="mskWrapper"></div>');
        var content = $('<div id="content"><div id="mskDataLoading">' + isNullAndUndef(data) + '</div></div>');

        closebutton.on('click', function () {
            CloseMskWorld(onCloseFunction);
        });

        //set action recort
        //mskWorld.data("action", action);
        //mskWorld.data("target", target);
        mskWorld.data('callback', callbackFunction);

        mskWorld.css({ 'opacity': '0' });
        wrapper.css({ 'opacity': '0' });
        if (dialogWidth != null) wrapper.css({ 'width': dialogWidth });
        if (dialogHeight != null) wrapper.css({ 'height': dialogHeight });

        mskWorld.width($(document).width());
        mskWorld.height($(document).height());
        $('body').append(mskWorld);
        $('body').append(wrapper.append(closebutton).append(content));

        wrapper.css({ 'left': ($(window).width() / 2 - wrapper.width() / 2) + 'px', 'top': ($(window).height() / 2 - wrapper.height() / 2) + 'px' });
        //content.height(wrapper.height() -80);

        mskWorld.fadeTo(300, 0.5, function () { });
        $('#mskWrapper').fadeTo(300, 1, function () { });
        return content;
    }
    return null;
}
function confirmationbox(question, cancelButtonTxt, okButtonTxt, callback) {
    var confirmModal =
      $('<div class="modal fade" >' +
          '<div class="modal-dialog" id="deleteConfirmation">' +
          '<div class="btn-magick btn-lg btn3d" >' +
            '<div class="modal-body">' +
            '<p class="Modal-message">' + question + '</p>' +
          '</div>' +

          '<div class="modal-footer" id="ConfirmationFooter">' +
          '<a  id="okButton" class="btn btn-danger btn-lg btn3d">' +
              okButtonTxt +
            '</a>' + "          " +
            '<a href="#!" id="btnNo" class="btn btn-primary btn-lg btn3d" data-dismiss="modal">' +
              cancelButtonTxt +
            '</a>' +

          '</div>' +
          '</div>' +
          '</div>' +
        '</div>');

    confirmModal.find('#okButton').click(function (event) {

        callback();

        confirmModal.modal('hide');
    });

    confirmModal.modal('show');
};
function confirmationboxwithheader(heading, question, cancelButtonTxt, okButtonTxt, callback) {
    var confirmModal =
      $('<div class="modal fade" >' +
          '<div class="modal-dialog" id="deleteConfirmation">' +
          '<div class="modal-content" >' +
          '<div class="modal-header">' +
            '<a class="close" data-dismiss="modal" >&times;</a>' +
            '<h3>' + heading + '</h3>' +
          '</div>' +

          '<div class="modal-body">' +
            '<p class="Modal-message">' + question + '</p>' +
          '</div>' +

          '<div class="modal-footer" id="ConfirmationFooter">' +
          '<a  id="okButton" class="btn btn-danger grow">' +
              okButtonTxt +
            '</a>' + "          " +
            '<a href="#!" class="btn btn-primary grow" data-dismiss="modal">' +
              cancelButtonTxt +
            '</a>' +

          '</div>' +
          '</div>' +
          '</div>' +
        '</div>');

    confirmModal.find('#okButton').click(function (event) {

        callback();

        confirmModal.modal('hide');
    });

    confirmModal.modal('show');
};