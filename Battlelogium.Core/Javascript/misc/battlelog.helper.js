function injectJS(scripturl) {
    var script = document.createElement('script');
    script.setAttribute('src', scripturl);
    document.getElementsByTagName('head')[0].appendChild(script);
}
function injectCSS(styleurl) {
    var script = document.createElement('link');
    script.setAttribute('rel', 'stylesheet');
    script.setAttribute('type', 'text/css');
    script.setAttribute('href', styleurl);
    document.getElementsByTagName('head')[0].appendChild(script);
}

