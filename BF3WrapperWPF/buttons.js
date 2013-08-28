function addServerBrowserButton() {
    var quitButtonElement = document.getElementById('serverBrowserButton');
    if (quitButtonElement == null) {
        var playbar = document.getElementsByClassName('main-loggedin-playbar')[0];
        var button = document.createElement('button');
        button.innerHTML = "<p>SERVER BROWSER</p>";
        button.setAttribute('class', 'common-button-large main-loggedin-playbutton');
        button.setAttribute('onclick', 'location.href = "http://battlelog.battlefield.com/bf3/servers/"');
        button.setAttribute('id', 'serverBrowserButton');
        playbar.appendChild(button);
    }
}

function addQuitButton() {
    var quitButtonElement = document.getElementById('wrapperQuitButton');
    if (quitButtonElement == null) {
        var playbar = document.getElementsByClassName('main-loggedin-playbar')[0];
        var button = document.createElement('button');
        button.innerHTML = "<p>QUIT</p>";
        button.setAttribute('class', 'common-button-large main-loggedin-playbutton');
        button.setAttribute('onclick', 'wrapper.quitWrapper()');
        button.setAttribute('id', 'wrapperQuitButton');
        playbar.appendChild(button);
    }
}

function addSettingsButton() {
    var settingsButtonElement = document.getElementById('wrapperSettingsButton');
    if (settingsButtonElement == null) {
        var playbar = document.getElementsByClassName('main-loggedin-playbar')[0];
        var button = document.createElement('button');
        button.innerHTML = "<p>SETTINGS</p>";
        button.setAttribute('class', 'common-button-large main-loggedin-playbutton');
        button.setAttribute('onclick', 'wrapper.showSettings()');
        button.setAttribute('id', 'wrapperSettingsButton');
        playbar.appendChild(button);
    }
}

addServerBrowserButton();
addSettingsButton();
addQuitButton();