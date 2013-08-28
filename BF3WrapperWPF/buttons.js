//Adds a button to the Battlelog playbar
function addButton(elementid, label, onclick) {
    var buttonElement = document.getElementById(elementid);
    if (buttonElement == null) {
        var playbar = document.getElementsByClassName('main-loggedin-playbar')[0];
        var button = document.createElement('button');
        button.innerHTML = "".concat("<p>", label, "</p>");
        button.setAttribute('class', 'common-button-large main-loggedin-playbutton');
        button.setAttribute('onclick', onclick);
        button.setAttribute('id', elementid);
        playbar.appendChild(button);
    }
}

addButton('serverBrowserButton', 'SERVERS', 'location.href = "http://battlelog.battlefield.com/bf3/servers/"');
addButton('wrapperSettingsButton', 'SETTINGS', 'wrapper.showSettings()');
addButton('wrapperQuitButton', 'QUIT', 'wrapper.quitWrapper()');
