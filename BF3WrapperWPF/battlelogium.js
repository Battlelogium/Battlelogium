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

function fixQuickMatchButtons() {
    if ($('#btnQuickMatch').length == 0) {
        var btnQuickMatch = $("button[data-track='actionbar.quickmatch']")
        .attr('id', 'btnQuickMatch')
        .mouseover()
        .mouseout(); //Workaround to get the tooltip to appear
    }
    
     var btnQuickMatchBig = $("button[data-track='menudropdown.quickmatch']")
     .attr('id', 'btnQuickMatchBig')
     .mouseover() //Workaround to get the tooltip to appear
     .mouseout();
   
   
     var btnQuickMatchServerBrowser = $("button[data-track='serverbrowser.server.quickmatch']")
    .attr('id', 'btnQuickMatchServerBrowser')
    .mouseover() //Workaround to get the tooltip to appear
    .mouseout();
    
    $('.tooltip').find('.tooltip-body:contains("Loading")').html("Play a Quick Match");
   
}
function fixEAPlaybarButtons() {

     //Fix Co-Op Button
    if ($('#btnCoOp').length == 0) {
        var btnCoOp = $("button[data-track='actionbar.coop']")
        btnCoOp.attr('id', 'btnCoOp');
        btnCoOp.attr('data-tooltip', 'Play a Co-Op Match');
        btnCoOp.html("<p>CO-OP</p>");
    }

    //Fix Campaign Button
    if ($('#btnCampaign').length == 0) {
        var btnCampaign = $("button[data-track='actionbar.campaign']")
        btnCampaign.attr('id', 'btnCampaign')
        btnCampaign.attr('data-tooltip', 'Play Campaign Mode');
        btnCampaign.html("<p>CAMPAIGN</p>");
    }
}

function removeBF4Preorder() {
    var bf4Preorder = $("li[data-page='preorderbf4']");
    bf4Preorder.remove();
}

function addSecondaryNavOption(id, onclick, href, text) {
    if ($('#' + id).length == 0) {
        $('<a/>', {
            class: 'wfont base-no-ajax',
            href: href,
            onclick: onclick
        })
            .html(text)
            .appendTo($("<li/>", {
            id: id
             })
      .prependTo($("#base-header-secondary-nav").find("ul")));
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
    $('<link/>', {
        rel: 'stylesheet',
        type: 'text/css',
        href: 'asset://local/bf3icons.css'
    }).appendTo($('head'));
}

function hijackSettingsLink() { //Take over the settings link in the dropdown menu
    var settingsLink = $('li .edit').children("a[href='/bf3/profile/edit/']");
    settingsLink.attr('href', '#');
    settingsLink.attr('onclick', 'showDialog(settingsDialog())');
}

applyChromeCSS(); //Add our modified spritesheet for the false chrome buttons
addChromeButtons(); //Add the false window chrome buttons to DOM
fixEAPlaybarButtons();
fixQuickMatchButtons(); //Fix the quick match buttons (tooltips)
removeBF4Preorder();
addSecondaryNavOption('btnSettings', 'showDialog(settingsDialog())', '#', 'Settings');
hijackSettingsLink();
addPlaybarButton('btnServers', 'SERVERS', 'Browse servers', 'location.href = "http://battlelog.battlefield.com/bf3/servers/"');

//Dialog functions

function getDialogOverlay() {
    if ($("div .overlay-container").length == 0) {
      
        var overlaycontainer =  $('<div/>', {  //Add the overlay to a container
            class: 'overlay-container'
        }).append(
         $('<div/>', { //Create the modal overlay
            class: 'overlay show',
            style: 'display: block; z-index: 2;'
        }));
    }else{
        var overlaycontainer = $("div .overlay-container");
    }
    return overlaycontainer;
}


function showDialog(dialog, removeOverlay) {

    if (arguments.length == 1) removeOverlay = true; //Assume we want to remove the overlay unless specified otherwise
    //Close any previously opened dialog
    closeDialog(removeOverlay);

    var dialogContainer = $("#dialog-container"); //Get the dialogContainer

    if (removeOverlay) {
        getDialogOverlay().appendTo(dialogContainer).fadeIn(200);
    } //Add the overlay container to the dialog container

    dialog.appendTo(dialogContainer);
}

function closeDialog(removeOverlay) {
    if (arguments.length == 0) removeOverlay = true; //Assume we want to remove the overlay unless specified otherwise
    if (removeOverlay) {
        $(".overlay.show").fadeOut(200, function () {
            $(".overlay-container").hide();
            $(this).show();
        }) //Fade out the overlay
    }
    $("#dialog-battlelogium").remove();
}

function okDialog(header, reason) {
    var okButton = createDialogButton('okButton', 'closeDialog()', " OK ", "OK", true);
    return createDialog(header, header, reason, false, [okButton]);
}

function settingsDialog() {
    var clearCacheButton = createDialogButton('clearCacheButton', 'showDialog(clearCacheDialog(), false)', " Clear Cache ", "Clear all cache and cookies", false);
    var editSettingsButton = createDialogButton('editSettingsButton', 'wrapper.editSettings()', " Battlelogium Settings ", "Open the settings editor", false);
    var userSettingsButton = createDialogButton('userSettingsButton', 'location.href = "http://battlelog.battlefield.com/bf3/profile/edit/"', " User Settings ", "Edit your Battlelog profile", false);
    var closeSettingsButton = createDialogButton('closeSettingsButton', 'closeDialog()', " Close ", "Close this dialog", true);

    return createDialog("Settings", "Settings", "You may edit your Battlelog profile settings or Battlelogium's settings, or clear the cache to fix any problems " , true, [userSettingsButton, editSettingsButton, clearCacheButton, closeSettingsButton]);
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
        dialogWindowHeader.html('<a class="icon-custom icon-close" onclick="closeDialog()" href="#">Close</a>' + '<h3>' + dialogHeaderText, '</h3>');
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

