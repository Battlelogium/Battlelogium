/// <reference path="windowbutton/battlelog.windowbutton.js" />
/// <reference path="playbar/battlelog.bf4.playbar.js" />
/// <reference path="settings/battlelog.bf4.settings.js" />
var baseurl = 'http://ron975.github.io/Battlelogium/Battlelogium.Core/Javascript';
function injectOnce() {
    if (document.getElementById('_windowbutton') == null) {
        injectScript('_windowbutton', baseurl + '/windowbutton/battlelog.windowbutton.min.js');
    }
    if (document.getElementById('css_windowbutton') == null) {
        injectCSS('css_windowbutton', baseurl + '/windowbutton/battlelog.windowbutton.min.css');
    }
    if (document.getElementById('_battlelogplaybar') == null) {
        injectScript('_battlelogplaybar', baseurl + '/playbar/battlelog.bf4.playbar.min.js');
    }
    if (document.getElementById('_battlelogstats') == null) {
        injectScript('_battlelogstats', baseurl + '/stats/battlelog.bf4.stats.min.js');
    }
    if (document.getElementById('_battlelogsettings') == null) {
        injectScript('_battlelogsettings', baseurl + '/settings/battlelog.bf4.settings.min.js');
    }
}

function runCustomJS() {
    try {
        windowbutton.addWindowButtons();
        windowbutton.updateMaximizeButton();
        battlelogplaybar.fixEAPlaybarButtons();
        battlelogplaybar.createPlaybarButton('btnServers', 'SERVERS', '/bf4/servers', 'btn-primary margin-left').insertAfter($('#btnMulti'));
    } catch (error) {
    }
    if (window.location.href.match(/\/soldier\//) != null) {
        battlelogstats.overview();
    }
    if (window.location.href == 'http://battlelog.battlefield.com/bf4/profile/edit/' || window.location.href == 'http://battlelog.battlefield.com/bf4/profile/edit/edit-notifications/') {
        battlelogsettings.addSettingsSection();
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