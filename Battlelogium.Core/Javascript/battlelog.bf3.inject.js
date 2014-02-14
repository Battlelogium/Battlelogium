/// <reference path="windowchrome/battlelog.windowchrome.js" />
/// <reference path="button/battlelog.bf3.button.js" />
/// <reference path="dialog/battlelog.bf3.dialog.js" />
var baseurl = 'http://ron975.github.io/Battlelogium/Battlelogium.Core/Javascript';
function injectOnce() {
    if (document.getElementById('_windowchrome') == null) {
        injectScript('_windowchrome', baseurl+'/windowchrome/battlelog.windowchrome.min.js');
    }
    if (document.getElementById('css_windowchrome') == null) {
        injectCSS('css_windowchrome', baseurl+'/windowchrome/battlelog.windowchrome.min.css');
    }
    if (document.getElementById('css_misc') == null) {
        injectCSS('css_windowchrome', baseurl + '/misc/battlelog.misc.min.css');
    }
    if (document.getElementById('_battlelogbutton') == null) {
        injectScript('_battlelogbutton', baseurl + '/button/battlelog.bf3.button.min.js');
    }
    if (document.getElementById('_battlelogdialog') == null) {
        injectScript('_battlelogdialog', baseurl + '/dialog/battlelog.bf3.dialog.min.js');
    }
}

function runCustomJS() {
    windowchrome.addChromeButtons();
    battlelogbutton.fixEAPlaybarButtons();
    battlelogbutton.fixQuickMatchButtons();
    battlelogbutton.addPlaybarButton('btnServers', 'SERVERS', 'Browse servers', 'location.href = "http://battlelog.battlefield.com/bf3/servers/"');
    battlelogbutton.addPlaybarButton('btnServers', 'SERVERS', 'Browse servers', 'app.showdevtools()');

    $("#base-header-secondary-nav>ul>li>a:contains('Buy Battlefield 4')").remove();
}

function injectScript(id, url) {
    var script = document.createElement('script');
    script.setAttribute('src', url);
    script.setAttribute('id', id);
    document.getElementsByTagName('head')[0].appendChild(script);
}
function injectCSS(id, url) {
    var script = document.createElement('link');
    script.setAttribute('rel', 'stylesheet');
    script.setAttribute('type', 'text/css');
    script.setAttribute('href', url);
    script.setAttribute('id', id);
    document.getElementsByTagName('head')[0].appendChild(script);
}

injectOnce();