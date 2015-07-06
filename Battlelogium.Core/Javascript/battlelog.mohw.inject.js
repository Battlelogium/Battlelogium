/// <reference path="windowbutton/battlelog.windowbutton.js" />
/// <reference path="playbar/battlelog.bf3.playbar.js" />
/// <reference path="dialog/battlelog.bf3.dialog.js" />
/// <reference path="stats/battlelog.bf3.stats.js" />
var baseurl = 'http://battlelogium.github.io/Battlelogium/Battlelogium.Core/Javascript';
function injectOnce() {
    if (document.getElementById('_windowbutton') == null) {
        injectScript('_windowbutton', baseurl+'/windowbutton/battlelog.windowbutton.min.js');
    }
    if (document.getElementById('css_windowbutton') == null) {
        injectCSS('css_windowbutton', baseurl + '/windowbutton/battlelog.windowbutton.min.css');
    }
    if (document.getElementById('css_misc') == null) {
        injectCSS('css_misc', baseurl + '/misc/battlelog.misc.min.css');
    }
    if (document.getElementById('_battlelogplaybar') == null) {
        injectScript('_battlelogplaybar', baseurl + '/playbar/battlelog.mohw.playbar.min.js');
    }
    if (document.getElementById('_battlelogstats') == null) {
        injectScript('_battlelogstats', baseurl + '/stats/battlelog.mohw.stats.min.js');
    }
    if (document.getElementById('_battlelogsettings') == null) {
        injectScript('_battlelogsettings', baseurl + '/settings/battlelog.mohw.settings.min.js');
    }
}

function runCustomJS() {
    try {
        battlelogplaybar.fixQuickMatchButtons();
        windowbutton.addWindowButtons();
        windowbutton.updateMaximizeButton();
        battlelogplaybar.fixEAPlaybarButtons();
        battlelogplaybar.addPlaybarButton(battlelogplaybar.createPlaybarButton('btnServers', 'SERVERS', 'location.href = "http://battlelog.battlefield.com/mohw/servers/"'));
        $("#base-header-secondary-nav>ul>li>a:contains('Buy Battlefield 4')").remove();
    } catch (error) {
    }
    if (window.location.href.match(/\/soldier\//) != null) {
        battlelogstats.overview();
    }
    if (window.location.href == 'http://battlelog.battlefield.com/mohw/profile/edit/') {
        
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