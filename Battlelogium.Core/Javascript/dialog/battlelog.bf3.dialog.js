var battlelogdialog = {
    getDialogOverlay: function () {
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
    },

    showDialog: function (dialog, removeOverlay) {
        //Close any previously opened dialog
        this.closeDialog(removeOverlay);

        var dialogContainer = $("#dialog-container"); //Get the dialogContainer

        if (removeOverlay) {
            this.getDialogOverlay().appendTo(dialogContainer).fadeIn(200);
        } //Add the overlay container to the dialog container

        dialog.appendTo(dialogContainer);
    },

    closeDialog: function (removeOverlay) {
        if (removeOverlay) {
            $(".overlay.show").fadeOut(200, function () {
                $(".overlay-container").hide();
                $(this).show();
            }) //Fade out the overlay
        }
        $("#dialog-battlelogium").remove();
    },

    okDialog: function (header, reason) {
        var okButton = this.createDialogButton('okButton', 'closeDialog(true)', " OK ", "OK", true);
        return this.createDialog(header, header, reason, false, [okButton]);
    },

    settingsDialog: function () {
        var clearCacheButton = this.createDialogButton('clearCacheButton', 'showDialog(clearCacheDialog(), false)', " Clear Cache ", "Clear all cache and cookies", false);
        var editSettingsButton = this.createDialogButton('editSettingsButton', 'app.editSettings()', " Battlelogium Settings ", "Open the settings editor", false);
        var userSettingsButton = this.createDialogButton('userSettingsButton', 'location.href = "http://battlelog.battlefield.com/bf3/profile/edit/"', " User Settings ", "Edit your Battlelog profile", false);
        var closeSettingsButton = this.createDialogButton('closeSettingsButton', 'closeDialog(true)', " Close ", "Close this dialog", true);

        return this.createDialog("Settings", "Settings", "You may edit your Battlelog profile settings or Battlelogium's settings, or clear the cache to fix any problems ", true, [userSettingsButton, editSettingsButton, clearCacheButton, closeSettingsButton]);
    },

    quitConfirmDialog: function (header, reason) {
        var quitBattlelogiumButton = this.createDialogButton('quitBattlelogiumButton', 'app.quit()', " Close Battlelogium ", "Quit Battlelogium", false);
        var closeDialogButton = this.createDialogButton('closeDialogButton', 'closeDialog(true)', " Cancel ", null, true);
        return this.createDialog("Confirm Closing", header, reason, false, [quitBattlelogiumButton, closeDialogButton]);
    },

    clearCacheDialog: function () {
        var clearCacheButton = this.createDialogButton('clearCacheDialogButton', 'app.clearCache()', " Clear the Cache ", null, false);
        var closeDialogButton = this.createDialogButton('closeDialogButton', 'closeDialog(true)', " Cancel ", null, true);
        return this.createDialog("Clear the Cache?", "Clear the Cache?", "Are you sure you want to clear cache and cookies? This can not be undone", false, [clearCacheButton, closeDialogButton]);
    },

    createDialogButton: function (id, onclick, text, tooltip, grey) {
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
    },

    createDialog: function (dialogHeaderText, dialogBodyHeaderText, dialogBodyText, showCloseX, dialogButtons) {
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
}