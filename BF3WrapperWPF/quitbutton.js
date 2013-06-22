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