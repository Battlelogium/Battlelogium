/// <reference path="windowchrome/battlelog.windowchrome.js" />
/// <reference path="playbar/battlelog.bf4.playbar.js" />
var baseurl = 'http://localhost/battlelogium';
function injectOnce() {
    if (document.getElementById('_windowchrome') == null) {
        injectScript('_windowchrome', baseurl + '/windowchrome/battlelog.windowchrome.min.js');
    }
    if (document.getElementById('css_windowchrome') == null) {
        injectCSS('css_windowchrome', baseurl + '/windowchrome/battlelog.windowchrome.min.css');
    }
    if (document.getElementById('_battlelogplaybar') == null) {
        injectScript('_battlelogplaybar', baseurl + '/playbar/battlelog.bf4.playbar.min.js');
    }
    if (document.getElementById('_battlelogstats') == null) {
        injectScript('_battlelogstats', baseurl + '/stats/battlelog.bf4.stats.min.js');
    }
    if (document.getElementById('_battlelogurlchange') == null) {
        injectScript('_battlelogurlchange', baseurl + '/battlelog.bf4.urlchange.min.js');
    }
}

function runCustomJS() {
    windowchrome.addChromeButtons();
    battlelogplaybar.fixEAPlaybarButtons();
    battlelogplaybar.createPlaybarButton('btnServers', 'SERVERS', '/bf4/servers', 'btn-primary margin-left').insertAfter($('#btnMulti'))
}

function runOnURLChange() {
    if (window.location.href.match(/\/soldier\//) != null) {
        battlelogstats.overview();
    }
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