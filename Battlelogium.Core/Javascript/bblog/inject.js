function inject(document, version, folder){
    var style = null;
    var el = null;

    if(document.getElementById("base-bf3-html") && !document.getElementById("base-bf3-body").className.match(/preorderbf4/)) style = "bf3-mohw";
    if(document.getElementById("base-mohw-html")) style = "bf3-mohw";
    if(document.getElementById("base-bf4-html")) style = "bf4";

    if(style){
        el = document.createElement('link');
        el.setAttribute('type', 'text/css');
        el.setAttribute('rel', 'stylesheet');
        el.setAttribute('href', folder+"/style-general.css?"+version);
        document.head.appendChild(el);

        el = document.createElement('link');
        el.setAttribute('type', 'text/css');
        el.setAttribute('rel', 'stylesheet');
        el.setAttribute('href', folder+"/style-"+style+".css?"+version);
        document.head.appendChild(el);

        el = document.createElement('script');
        el.setAttribute('type', 'text/javascript');
        el.setAttribute('src',  folder+"/bblog-translations-compressed.js?"+version);
        document.head.appendChild(el);

        if(document.getElementById("base-bf3-html")){
            el = document.createElement('script');
            el.setAttribute('type', 'text/javascript');
            el.setAttribute('src', folder+"/bblog-weapons-compressed.js?"+version);
            document.head.appendChild(el);
        }
    }

    el = document.createElement('script');
    el.setAttribute('type', 'text/javascript');
    el.setAttribute('src', folder+"/bblog.js?"+version);
    el.setAttribute('id', 'bblog-basescript');
    el.setAttribute('data-folder', folder);
    document.head.appendChild(el);
}