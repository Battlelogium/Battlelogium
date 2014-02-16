/// <reference path="windowchrome/battlelog.windowchrome.js" />
/// <reference path="button/battlelog.bf4.button.js" />
var baseurl = 'http://localhost/battlelogium';
function injectOnce() {
    if (document.getElementById('_windowchrome') == null) {
        injectScript('_windowchrome', baseurl + '/windowchrome/battlelog.windowchrome.min.js');
    }
    if (document.getElementById('css_windowchrome') == null) {
        injectCSS('css_windowchrome', baseurl + '/windowchrome/battlelog.windowchrome.min.css');
    }
    if (document.getElementById('_battlelogbutton') == null) {
        injectScript('_battlelogbutton', baseurl + '/button/battlelog.bf4.button.min.js');
    }
    if (document.getElementById('_battlelogstats') == null) {
        injectScript('_battlelogstats', baseurl + '/stats/battlelog.bf4.stats.min.js');
    }
}

function runCustomJS() {
    windowchrome.addChromeButtons();
    battlelogbutton.fixEAPlaybarButtons();
    battlelogbutton.createPlaybarButton('btnServers', 'SERVERS', '/bf4/servers', 'btn-primary margin-left').insertAfter($('#btnMulti'))

    
    if (statstimer == null) {
        var statstimer = window.setInterval(function () {
            battlelogstats.overview();
        }, 1000);
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