//Adds a button to the Battlelog playbar
function addPlaybarButton(elementid, label, tooltip, onclick) {
    var buttonElement = document.getElementById(elementid);
    if (buttonElement == null) {
        var playbar = document.getElementsByClassName('main-loggedin-playbar')[0];
        var button = document.createElement('button');
        button.innerHTML = "".concat("<p>", label, "</p>");
        button.setAttribute('class', 'common-button-large main-loggedin-playbutton');
        button.setAttribute('onclick', onclick);
        button.setAttribute('id', elementid);
        button.setAttribute('data-tooltip', tooltip);
        playbar.appendChild(button);
    }
}

function fixEAPlaybarButtons() {

    var eaPlaybarButtons = getAllElementsWithAttribute('data-track');
    if (eaPlaybarButtons != null) {
        for (var i = 0; i < eaPlaybarButtons.length; i++) {

            if (eaPlaybarButtons[i].getAttribute('data-track') == 'actionbar.quickmatch') {
                eaPlaybarButtons[i].setAttribute('data-tooltip', 'Play a quick match');
                //For some reason this doesn't work. Oh well.
            }
            if (eaPlaybarButtons[i].getAttribute('data-track') == 'actionbar.coop') {
                eaPlaybarButtons[i].setAttribute('data-tooltip', 'Play a Co-Op Match');
                eaPlaybarButtons[i].innerHTML = "<p>CO-OP</p>";
            }
            if (eaPlaybarButtons[i].getAttribute('data-track') == 'actionbar.campaign') {
                eaPlaybarButtons[i].setAttribute('data-tooltip', 'Start Campaign');
                eaPlaybarButtons[i].innerHTML = "<p>CAMPAIGN</p>";
            }
        }
    }
}

function createToolsButton(onclick, id){
    var toolsButton = document.createElement('li');
    toolsButton.setAttribute('onclick', onclick);
    toolsButton.setAttribute('id', "".concat(id, "Button"));
    var toolsDiv = document.createElement('div');
    toolsDiv.setAttribute('class', "".concat("tools-item log ", id));
    toolsButton.appendChild(toolsDiv);
    return toolsButton
}

function addChromeButtons() {
    var headerTools = document.getElementById('base-header-user-tools').getElementsByClassName('tools pull-right')[0];
    var avatarLi = document.getElementById('base-header-user-tools').getElementsByClassName('tools pull-right')[0].getElementsByClassName('comcenter-toggle tools-item')[0].previousElementSibling; //Insert our chrome buttons before the avatar list item. 
    var closeButton = createToolsButton("wrapper.quitWrapper()", 'close');
    var minimizeButton = createToolsButton("wrapper.minimize()", 'minimize');
    var reloadButton = createToolsButton("location.reload()", 'reload');
   
    if (document.getElementById('reloadButton') == null) {
        headerTools.insertBefore(reloadButton, avatarLi);
    }
    if (document.getElementById('minimizeButton') == null) {
        headerTools.insertBefore(minimizeButton, avatarLi);
    }
    if (document.getElementById('closeButton') == null) {
        headerTools.insertBefore(closeButton, avatarLi);
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

applyChromeCSS(); //Add our modified spritesheet for the false chrome buttons
addChromeButtons(); //Add the false window chrome buttons to DOM
fixEAPlaybarButtons();
addPlaybarButton('serverBrowserButton', 'SERVERS', 'View Servers', 'location.href = "http://battlelog.battlefield.com/bf3/servers/"');
addPlaybarButton('wrapperSettingsButton', 'SETTINGS', 'Change Battlelogium Settings', 'showDialog(settingsDialog())');
addPlaybarButton('wrapperQuitButton', 'QUIT', 'Quit Battlelogium', 'wrapper.quitConfirm()');

//Dialog functions

function showDialog(dialog) {
    //Close any previously opened dialog
    closeDialog();

    //Get the dialog container
    var dialogContainer = document.getElementById("dialog-container");

    //Create the modal overlay
    var modalOverlay = document.createElement('div');
    modalOverlay.setAttribute('class', 'modal-overlay show')
    dialogContainer.appendChild(modalOverlay);
    dialogContainer.appendChild(dialog);

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
    var dialogButton = document.createElement('button');

    if (grey) {
        dialogButton.setAttribute('class', 'btn btn-continue');
    } else {
        dialogButton.setAttribute('class', 'btn btn-primary');
    }
    dialogButton.setAttribute('id', id);
    dialogButton.setAttribute('onclick', onclick);
    if ((tooltip != null) && (tooltip != "null")) {
        dialogButton.setAttribute('data-tooltip', tooltip);
    }
    dialogButton.innerHTML = text;
    return dialogButton;
}

function createDialog(dialogHeaderText, dialogBodyHeaderText, dialogBodyText, showCloseX, dialogButtons) {
    //Create the dialogWindow
    var dialogWindow = document.createElement('div');
    dialogWindow.setAttribute('class', 'dialog hide in');
    dialogWindow.setAttribute('id', 'dialog-1');
    dialogWindow.setAttribute('style', 'display: block;');
    dialogWindow.setAttribute('tabindex', '-1');
    dialogWindow.setAttribute('role', 'dialog');
    dialogWindow.setAttribute('aria-hidden', 'false');

    //Create the dialogWindow header eleent
    var dialogWindowHeader = document.createElement('header');

    if (!showCloseX) {
        dialogWindowHeader.innerHTML = "".concat("<h3>", dialogHeaderText, "</h3>");
    } else {
        dialogWindowHeader.innerHTML = "".concat('<a class="icon-custom icon-close " href="#" onclick="closeDialog()">Close</a>', "<h3>", dialogHeaderText, "</h3>");
    }

    //Create the main section of the dialog window
    var dialogWindowMain = document.createElement('section');
    dialogWindowMain.setAttribute('style', 'height: auto;');
    dialogWindowMain.setAttribute('class', 'dialog-body ');

    //Create the dialog logo
    var dialogLogo = document.createElement('div');
    dialogLogo.setAttribute('class', 'popup-prompt-logo');

    //Create the dialog text
    var dialogWindowText = document.createElement('div');
    dialogWindowText.setAttribute('class', 'popup-prompt-body');
    dialogWindowText.innerHTML = "".concat("<h2>", dialogBodyHeaderText, "</h2><p>", dialogBodyText, "</p>");
    //Create the footer with the buttons
    var dialogWindowFooter = document.createElement('footer');
    var dialogWindowFooterDiv = document.createElement('div');
    dialogWindowFooterDiv.setAttribute('class', 'popup-prompt-buttons');

    if (dialogButtons != null) {
        for (var i = 0; i < dialogButtons.length; i++) {
            dialogWindowFooterDiv.appendChild(dialogButtons[i]);
        }
    }

    dialogWindowFooter.appendChild(dialogWindowFooterDiv);

    dialogWindowMain.appendChild(dialogLogo);
    dialogWindowMain.appendChild(dialogWindowText);

    dialogWindow.appendChild(dialogWindowHeader);
    dialogWindow.appendChild(dialogWindowMain);
    dialogWindow.appendChild(dialogWindowFooter);

    return dialogWindow;
}

function closeDialog() {
    var dialogContainer = document.getElementById("dialog-container");
    dialogContainer.innerHTML = "";
}

function getAllElementsWithAttribute(attribute) {
    var matchingElements = [];
    var allElements = document.getElementsByTagName('*');
    for (var i = 0; i < allElements.length; i++) {
        if (allElements[i].getAttribute(attribute)) {
            // Element exists with attribute. Add to array.
            matchingElements.push(allElements[i]);
        }
    }
    return matchingElements;
}

