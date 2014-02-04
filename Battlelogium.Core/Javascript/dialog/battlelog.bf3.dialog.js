function getDialogOverlay() {
    if ($("div .overlay-container").length == 0) {

        var overlaycontainer = $('<div/>', {  //Add the overlay to a container
            class: 'overlay-container'
        }).append(
         $('<div/>', { //Create the modal overlay
             class: 'overlay show',
             style: 'display: block; z-index: 2;'
         }));
    } else {
        var overlaycontainer = $("div .overlay-container");
    }
    return overlaycontainer;
}

function showDialog(dialog, removeOverlay) {
    //Close any previously opened dialog
    closeDialog(removeOverlay);

    var dialogContainer = $("#dialog-container"); //Get the dialogContainer

    if (removeOverlay) {
        getDialogOverlay().appendTo(dialogContainer).fadeIn(200);
    } //Add the overlay container to the dialog container

    dialog.appendTo(dialogContainer);
}

function closeDialog(removeOverlay) {
    if (removeOverlay) {
        $(".overlay.show").fadeOut(200, function () {
            $(".overlay-container").hide();
            $(this).show();
        }) //Fade out the overlay
    }
    $("#dialog-battlelogium").remove();
}

function okDialog(header, reason) {
    var okButton = createDialogButton('okButton', 'closeDialog(true)', " OK ", "OK", true);
    return createDialog(header, header, reason, false, [okButton]);
}

function settingsDialog() {
    var clearCacheButton = createDialogButton('clearCacheButton', 'showDialog(clearCacheDialog(), false)', " Clear Cache ", "Clear all cache and cookies", false);
    var editSettingsButton = createDialogButton('editSettingsButton', 'app.editSettings()', " Battlelogium Settings ", "Open the settings editor", false);
    var userSettingsButton = createDialogButton('userSettingsButton', 'location.href = "http://battlelog.battlefield.com/bf3/profile/edit/"', " User Settings ", "Edit your Battlelog profile", false);
    var closeSettingsButton = createDialogButton('closeSettingsButton', 'closeDialog(true)', " Close ", "Close this dialog", true);

    return createDialog("Settings", "Settings", "You may edit your Battlelog profile settings or Battlelogium's settings, or clear the cache to fix any problems ", true, [userSettingsButton, editSettingsButton, clearCacheButton, closeSettingsButton]);
}

function quitConfirmDialog(header, reason) {
    var quitBattlelogiumButton = createDialogButton('quitBattlelogiumButton', 'app.quit()', " Close Battlelogium ", "Quit Battlelogium", false);
    var closeDialogButton = createDialogButton('closeDialogButton', 'closeDialog(true)', " Cancel ", null, true);
    return createDialog("Confirm Closing", header, reason, false, [quitBattlelogiumButton, closeDialogButton]);
}

function clearCacheDialog() {
    var clearCacheButton = createDialogButton('clearCacheDialogButton', 'app.clearCache()', " Clear the Cache ", null, false);
    var closeDialogButton = createDialogButton('closeDialogButton', 'closeDialog(true)', " Cancel ", null, true);
    return createDialog("Clear the Cache?", "Clear the Cache?", "Are you sure you want to clear cache and cookies? This can not be undone", false, [clearCacheButton, closeDialogButton]);
}

function createDialogButton(id, onclick, text, tooltip, grey) {
    var dialogButton = $('<button/>', {
        id: id,
        onclick: onclick
    });
    if (grey) {
        dialogButton.attr('class', 'btn btn-continue');
        dialogButton.attr('data-bind-action', 'no');
    } else {
        dialogButton.attr('class', 'btn btn-primary');
    }
    if ((tooltip != null) && (tooltip != "null")) {
        dialogButton.attr('data-tooltip', tooltip);
    }
    dialogButton.html(text);
    return dialogButton;
}

function createDialog(dialogHeaderText, dialogBodyHeaderText, dialogBodyText, showCloseX, dialogButtons) {
    //Create the dialogWindow
    var dialogWindow = $('<div/>', {
        class: 'dialog hide in',
        id: 'dialog-battlelogium',
        style: 'display: block;',
        tabindex: '-1',
        role: 'dialog',
        'aria-hidden': false
    });

    //Create the dialogWindow header eleent
    var dialogWindowHeader = $('<header/>');

    if (!showCloseX) {
        dialogWindowHeader.html('<h3>' + dialogHeaderText + '</h3>');
    } else {
        dialogWindowHeader.html('<a class="icon-custom icon-close" onclick="closeDialog(true)" href="#">Close</a>' + '<h3>' + dialogHeaderText, '</h3>');
    }

    //Create the main section of the dialog window and the logo
    var dialogWindowMain = $('<section/>', {
        style: 'height: auto;',
        class: 'dialog-body '
    })
    .append($('<div/>', {
        class: 'popup-prompt-logo'
    }));

    //Create the dialog text
    var dialogWindowText = $('<div/>', {
        class: 'popup-prompt-body'
    });
    dialogWindowText.html('<h2>' + dialogBodyHeaderText + '</h2><p>' + dialogBodyText + '</p>');

    //Create the footer with the buttons
    var dialogWindowFooterButtons = $('<div/>', {
        class: 'popup-prompt-buttons'
    });

    if (dialogButtons != null) {
        for (var i = 0; i < dialogButtons.length; i++) { //Still the fastest, most readable way to do this in jQuery.
            dialogWindowFooterButtons.append(dialogButtons[i]);
        }
    }

    var dialogWindowFooter = $('<footer/>').append(dialogWindowFooterButtons);

    dialogWindowMain.append(dialogWindowText);

    dialogWindow
    .append(dialogWindowHeader)
    .append(dialogWindowMain)
    .append(dialogWindowFooter);

    return dialogWindow;
}
