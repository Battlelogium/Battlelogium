//Adds a button to the Battlelog playbar
function addPlaybarButton(elementid, label, tooltip, onclick) {
    if ($('#'+elementid).length == 0) {
        $("<button/>", {
            id: elementid,
            onclick: onclick,
            class: 'common-button-large main-loggedin-playbutton',
            'data-tooltip': tooltip
        })
        .html("<p>" + label + "</p>")
        .appendTo($('.main-loggedin-playbar')[0]);
    }
}

function fixEAPlaybarButtons() {


    //Fix Quick Match Button
    if ($('btnQuickMatch').length == 0) {
        var btnQuickMatch = $("button[data-track='actionbar.quickmatch']")
        btnQuickMatch.attr('id', 'btnQuickMatch');
        $("#btnQuickMatch").mouseover(); //Workaround to get the tooltip to appear
        $("#btnQuickMatch").mouseout();
        $('.tooltip').find('.tooltip-body:contains("Loading")').html("Play a Quick Match");
    }

    //Fix Co-Op Button
    if ($('btnCoOp').length == 0) {
        var btnCoOp = $("button[data-track='actionbar.coop']")
        btnCoOp.attr('id', 'btnCoOp');
        btnCoOp.attr('data-tooltip', 'Play a Co-Op Match');
        btnCoOp.html("<p>CO-OP</p>");
    }

    //Fix Campaign Button
    if ($('btnCampaign').length == 0) {
        var btnCampaign = $("button[data-track='actionbar.campaign']")
        btnCampaign.attr('id', 'btnCampaign')
        btnCampaign.attr('data-tooltip', 'Play Campaign Mode');
        btnCampaign.html("<p>CAMPAIGN</p>");
    }
}

function createToolsButton(onclick, id) {
    var toolsButton =
    $('<li/>', {
        onclick: onclick,
        id: id + "Button"
    });

    $('<div/>', {
        class: "tools-item log " + id
    }).appendTo(toolsButton);

    return toolsButton
}

function addChromeButtons() {
    var avatarLi = $('#base-header-user-tools .tools.pull-right .comcenter-toggle.tools-item').prev(); //Insert our chrome buttons before the avatar list item. 
    var closeButton = createToolsButton("wrapper.quitWrapper()", 'close');
    var minimizeButton = createToolsButton("wrapper.minimize()", 'minimize');
    var reloadButton = createToolsButton("location.reload()", 'reload');
   
    if ($('#reloadButton').length == 0) {
        reloadButton.insertBefore(avatarLi);
    }
    if ($('#minimizeButton').length == 0) {
        minimizeButton.insertBefore(avatarLi);
    }
    if ($('#closeButton').length == 0) {
        closeButton.insertBefore(avatarLi);
    }
}

function applyChromeCSS() {
    var head = document.getElementsByTagName('head')[0];
    var chromeCSS = document.createElement('link');
    chromeCSS.setAttribute('rel', 'stylesheet');
    chromeCSS.setAttribute('type', 'text/css');
    chromeCSS.setAttribute('href', 'asset://local/bf3icons.css'); 
    head.appendChild(chromeCSS);
}

function applyChromeCSS() {
    $('<link/>', {
        rel: 'stylesheet',
        type: 'text/css',
        href: 'asset://local/bf3icons.css'
    }).appendTo($('head'));
}

applyChromeCSS(); //Add our modified spritesheet for the false chrome buttons
addChromeButtons(); //Add the false window chrome buttons to DOM
fixEAPlaybarButtons();
addPlaybarButton('serverBrowserButton', 'SERVERS', 'View Servers', 'location.href = "http://battlelog.battlefield.com/bf3/servers/"');
addPlaybarButton('wrapperSettingsButton', 'SETTINGS', 'Change Battlelogium Settings', 'showDialog(settingsDialog())');

//Dialog functions

function showDialog(dialog) {
    //Close any previously opened dialog
    closeDialog();

    var dialogContainer = $("#dialog-container"); //Get the dialogContainer

    $('<div/>', {  //Create the modal overlay
        class: 'modal-overlay show'
    }).appendTo(dialogContainer);

    dialogContainer.append(dialog);
}

function closeDialog() {
    $("#dialog-container").empty();
}

function okDialog(header, reason) {
    var okButton = createDialogButton('okButton', 'closeDialog()', " OK ", "OK", true);
    return createDialog(header, header, reason, false, [okButton]);
}

function settingsDialog() {
    var clearCacheButton = createDialogButton('clearCacheButton', 'showDialog(clearCacheDialog())', " Clear Cache ", "Clear Battlelogium Webcache", false);
    var editSettingsButton = createDialogButton('editSettingsButton', 'wrapper.editSettings()', " Edit Settings ", "Open the settings editor", false);
    var closeSettingsButton = createDialogButton('closeSettingsButton', 'closeDialog()', " Close ", "Close this dialog", true);

    return createDialog("Battlelogium Settings", "Battlelogium Settings", "Clear the cache if you have problems<br />Edit settings to open the settings editor. Settings will be applied on restart", true, [clearCacheButton, editSettingsButton, closeSettingsButton]);
}

function quitConfirmDialog(header, reason) {
    var quitBattlelogiumButton = createDialogButton('quitBattlelogiumButton', 'wrapper.quitWrapper()', " Close Battlelogium ", "Quit Battlelogium", false);
    var closeDialogButton = createDialogButton('closeDialogButton', 'closeDialog()', " Cancel ", null, true);
    return createDialog("Confirm Closing", header, reason, false, [quitBattlelogiumButton, closeDialogButton]);
}

function clearCacheDialog() {
    var clearCacheButton = createDialogButton('clearCacheDialogButton', 'wrapper.clearCache()', " Clear the Cache ", null, false);
    var closeDialogButton = createDialogButton('closeDialogButton', 'closeDialog()', " Cancel ", null, true);
    return createDialog("Clear the Cache?", "Clear the Cache?", "Are you sure you want to clear cache and cookies? This can not be undone", false, [clearCacheButton, closeDialogButton]);
}

function createDialogButton(id, onclick, text, tooltip, grey) {
    var dialogButton = $('<button/>', {
        id: id,
        onclick: onclick
    });
    if (grey) {
        dialogButton.attr('class', 'btn btn-continue');
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
        id: 'dialog-1',
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
        dialogWindowHeader.html('<a class="icon-custom icon-close " href="#" onclick="closeDialog()">Close</a>' + '<h3>' + dialogHeaderText, '</h3>');
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

