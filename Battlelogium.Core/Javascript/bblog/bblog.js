"use strict";
/**
* Better Battlelog - Worldwide Leading Browser Addon for Battlelog
*
* @author Roland Eigelsreiter (BrainFooLong)
* @link http://getbblog.com
* @license GPLv3
*/
var BBLog = {
    /**
    * The BBLog service url
    *
    * @type String
    */
    serviceUrl : 'http://getbblog.com',
    //serviceUrl : 'http://localhost/bblog.new',

    /**
    * BBLog version and build
    *
    * @type String
    */
    version : '4.0.0',
    build : '1401280758',

    /**
    * All possible config keys
    *
    * @type Array
    */
    configKeys : [
        {"key" : 'general.inlineyoutube', "init" : 1, "group" : "general"},
        {"key" : 'general.inlineimages', "init" : 1, "group" : "general"},
        {"key" : 'general.linkintext', "init" : 1, "group" : "general"},
        {"key" : 'general.feed.boardurl.last', "init" : 1, "group" : "general"},
        {"key" : 'general.server.filterset', "init" : 1, "group" : "general"},
        {"key" : 'general.server.markfavorites', "sections" : {"mohw" : 1, "bf3" : 1}, "init" : 1, "group" : "general"},
        {"key" : 'general.server.hiddeninfo', "init" : 1, "group" : "general"},
        {"key" : 'general.mainserverbrowser', "sections" : {"mohw" : 1, "bf3" : 1}, "init" : 1, "group" : "general"},
        {"key" : 'general.contextmenu.serverbrowser', "init" : 1, "group" : "general"},
        {"key" : 'general.contextmenu.serverpage', "sections" : {"mohw" : 1, "bf3" : 1}, "init" : 1, "group" : "general"},
        {"key" : 'bf3.contextmenu.report', "init" : 1, "group" : "general"},
        {"key" : 'general.delayed.contextmenu', "init" : 0, "group" : "general"},
        {"key" : 'general.focus.serverlist', "init" : 0, "group" : "general"},
        {"key" : 'general.radar.soldier.sound', "init" : 0, "group" : "general"},
        {"key" : 'general.background', "init" : 1, 'button' : 'background', "group" : "general"},
        {"key" : 'general.themes', "init" : 1, 'button' : 'themes', "group" : "general"},
        {"key" : 'general.plugins', "init" : 1, 'button' : 'plugins', "group" : "general"},
        {"key" : 'general.radar.soldier', "init" : 1, 'button' : 'radar', 'type' : 'soldier', "group" : "general"},
        {"key" : 'general.radar.server', "init" : 1, 'button' : 'radar', 'type' : 'server', "group" : "general"},
        {"key" : 'general.local.comments', "sections" : {"mohw" : 1, "bf3" : 1, "bf4" : 1}, "init" : 1, 'button' : 'comments', "group" : "general"},
        {"key" : 'board.gotolastpost', "init" : 1, "group" : "board"},
        {"key" : 'board.copybreadcrumps', "init" : 1, "group" : "board"},
        {"key" : 'board.linksblank', "init" : 1, "group" : "board"},
        {"key" : 'board.favthreads.autoadd', "sections" : {"mohw" : 1, "bf3" : 1}, "init" : 1, "group" : "board"},
        {"key" : 'board.contextmenu.quote', "init" : 1, "group" : "board"},
        {"key" : 'board.contextmenu.radar', "init" : 1, "group" : "board"},
        {"key" : 'board.gototop', "sections" : {"mohw" : 1, "bf3" : 1}, "init" : 1, "group" : "board"},
        {"key" : 'board.radar', "init" : 1, 'button' : 'radar', 'type' : 'board', "group" : "board"},
        {"key" : 'board.signature', "init" : 1, 'button' : 'signature', "group" : "board"},
        {"key" : 'board.favthreads.add', "sections" : {"mohw" : 1, "bf3" : 1}, "init" : 1, 'button' : 'favorites', "group" : "board"},
        {"key" : 'bf3.weapons.list.filters', "init" : 1, "sections" : {"bf3" : 1}, "group" : "bf3"},
        {"key" : 'bf3.weapons.list.extradata', "init" : 1, "sections" : {"bf3" : 1}, "group" : "bf3"},
        {"key" : 'bf3.weapons.list.bf3stats', "init" : 1, "sections" : {"bf3" : 1}, "group" : "bf3"},
        {"key" : 'bf3.weapons.info', "init" : 1, "sections" : {"bf3" : 1}, "group" : "bf3"},
        {"key" : 'bf3.weapons.altSort', "init" : 0, "sections" : {"bf3" : 1}, "group" : "bf3"},
        {"key" : 'bf3.vehicle.list.filters', "init" : 1, "sections" : {"bf3" : 1}, "group" : "bf3"},
        {"key" : 'bf3.vehicle.list.extradata', "init" : 1, "sections" : {"bf3" : 1}, "group" : "bf3"},
        {"key" : 'bf3.vehicle.list.bf3stats', "init" : 1, "sections" : {"bf3" : 1}, "group" : "bf3"},
        {"key" : 'bf3.vehicle.altSort', "init" : 0, "sections" : {"bf3" : 1}, "group" : "bf3"},
        {"key" : 'bf3.assignments.bblog', "init" : 1, "sections" : {"bf3" : 1}, "group" : "bf3"},
        {"key" : 'bf3.awards.optimize', "init" : 1, "sections" : {"bf3" : 1}, "group" : "bf3"},
        {"key" : 'bf3.reports.bf3stats', "init" : 1, "sections" : {"bf3" : 1}, "group" : "bf3"},
        {"key" : 'bf3.reports.download', "init" : 1, "sections" : {"bf3" : 1}, "group" : "bf3"},
        {"key" : 'bf3.stats.higherlevel', "init" : 1, "sections" : {"bf3" : 1}, "group" : "bf3"},
        {"key" : 'bf3.stats.bf3stats', "init" : 1, "sections" : {"bf3" : 1}, "group" : "bf3"},
        {"key" : 'bf3.dogtags.counter', "init" : 1, "sections" : {"bf3" : 1}, "group" : "bf3"},
        {"key" : 'bf3.dogtags.noanimation', "init" : 1, "sections" : {"bf3" : 1}, "group" : "bf3"},
        {"key" : 'bf4.weapons.list.filters', "init" : 1, "sections" : {"bf4" : 1}, "group" : "bf4"},
        {"key" : 'bf4.weapons.list.sort', "init" : 1, "sections" : {"bf4" : 1}, "group" : "bf4"},
        {"key" : 'bf4.weapons.info', "init" : 1, "sections" : {"bf4" : 1}, "group" : "bf4"},
        {"key" : 'bf4.vehicle.list.filters', "init" : 1, "sections" : {"bf4" : 1}, "group" : "bf4"},
        {"key" : 'bf4.vehicle.list.sort', "init" : 1, "sections" : {"bf4" : 1}, "group" : "bf4"},
        {"key" : 'bf4.stats.higherlevel', "init" : 1, "sections" : {"bf4" : 1}, "group" : "bf4"},
        {"key" : 'bf4.serverbrowser.data', "init" : 1, "sections" : {"bf4" : 1}, "group" : "bf4"},
        {"key" : 'bf4.serverbrowser.livescore', "init" : 1, "sections" : {"bf4" : 1}, "group" : "bf4"},
        {"key" : 'bf4.stats.bf4stats', "init" : 1, "sections" : {"bf4" : 1}, "group" : "bf4"},
        {"key" : 'bf4.weapons.list.bf4stats', "init" : 1, "sections" : {"bf4" : 1}, "group" : "bf4"},
        {"key" : 'bf4.vehicle.list.bf4stats', "init" : 1, "sections" : {"bf4" : 1}, "group" : "bf4"},
        {"key" : 'general.emblemeditor', "init" : 1, "sections" : {"bf4" : 1}, "group" : "bf4"},
        {"key" : 'mohw.stats.mohwstats', "init" : 1, "sections" : {"mohw" : 1}, "group" : "mohw"},
        {"key" : 'bblog.mark.team', "init" : 1, "group" : "bblog"},
        {"key" : 'bblog.click', "init" : 0, "group" : "bblog"}
    ],

    /**
    * Device info
    *
    * @type Object
    */
    deviceInfo : {1 : "pc", 2 : "xbox", 4 : "ps3", 32 : "ps4", 64 : "xone", "pc" : 1, "xbox" : 2, "ps3" : 4, "ps4" : 32, "xone" : 64, "xboxone" : "xone", "xbox360" : "xbox"},

    /**
    * The cache time for the api call
    */
    cacheTimeInitCall : 10800,

    /**
    * Initialize BBLog, HOOOO Boy, yes
    */
    init : function(){
        if(BBLog.cache("init")) return;
        BBLog.cache("init", true);
        // detect battlelog login attempt
        if(window.location.hash == "#bblog-authenticate" && S.globalContext.session && S.globalContext.session.user){
            $("body").text();
            window.location.href = BBLog.serviceUrl+"/auth/battlelogconnectcallback?id="+S.globalContext.session.user.userId+"&gravatarMd5="+S.globalContext.session.user.gravatarMd5+"&name="+encodeURIComponent(S.globalContext.session.user.username);
            return false;
        }
        // detect plugininstall attempt
        if(window.location.hash.match(/plugininstall-[0-9]+/) && S.globalContext.session && S.globalContext.session.user){
            var id = window.location.hash.match(/plugininstall-([0-9]+)/)[1];
            window.location.href = "#";
            BBLog.handle("api.json", {
                action : "plugin.install", params : {
                    "id" : id,
                    user : S.globalContext.session.user.userId
                },
                handler : function(data){
                    if(data && data.url){
                        var storageKey = "general.plugins.own";
                        var storage = BBLog.storage(storageKey) || [];
                        storage.push({"url" : $.trim(data.url), "active" : 1});
                        BBLog.storage(storageKey, storage);
                        base.showReceipt(BBLog.t("reload.required")+" (F5)");
                    }
                }
            });
        }

        // detect browser
        BBLog.cache("browser", "ff");
        if(navigator.appVersion.match(/Chrome/)) BBLog.cache("browser", "chrome");
        if(navigator.appVersion.match(/OPR/)) BBLog.cache("browser", "opera");

        // detect mode and stop if no mode is detected
        if($("#base-bf3-html").size()) BBLog.cache("mode", "bf3");
        if($("#base-mohw-html").size()) BBLog.cache("mode", "mohw");
        if($("#base-bf4-html").size()) BBLog.cache("mode", "bf4");
        if($("body.preorderbf4").size()) BBLog.cache("mode", false);
        if(!BBLog.cache("mode")) return;

        // detect language
        BBLog.cache("language", "en");
        BBLog.cache("battlelog.language", "");
        var langRealm = S.globalContext.realm.lang;
        var language = 0;
        for(var i in S.globalContext.staticContext.languages){
            if(S.globalContext.staticContext.languages[i].value == langRealm) language = S.globalContext.staticContext.languages[i].lang;
        }
        if(language){
            if(window.location.pathname.match(new RegExp("\/"+language+"(\/|$)"))){
                BBLog.cache("battlelog.language", language+"/");
            }
            if($.inArray(language, ["fr","it","de","es","pl","jp","kr","cz","tw","cs","ru","pt"]) === -1) language = "en";
            BBLog.cache("language", language);
        }

        // soldier data
        if($("div.soldierstats-box:first").size()){
            var e = $("div.soldierstats-box:first");
            var data = e.find("a[href*='/stats/']:first").attr("href").match(/([^\/]+)\/stats\/(.*?)\//i);
            if(data){
                BBLog.cache("soldier.id", data[2]);
                BBLog.cache("soldier.name", data[1]);
            }
            BBLog.cache("account.name", S.globalContext.session.user.username);

            // detect platform
            var platformIV = setInterval(function(){
                var data = e.find(".battlereport-header-info-gameicon").attr("class");
                if(data){
                    BBLog.cache("platform", data.match(/common-game-[0-9]+-([0-9])/)[1]);
                    clearInterval(platformIV);
                }
            }, 200);
        }

        // prepare some stuff
        for(var i in BBLog.configKeys) {
            var data = BBLog.configKeys[i];
            if(BBLog.storage(data.key) == null) BBLog.storage(data.key, data.init);
            // include sources
            if(typeof data.button != "undefined" && data.button == "radar"){
                var storageKey = "radar."+data.type+".sources";
                var storage = BBLog.storage(storageKey);
                if(BBLog.count(storage)){
                    for(var i in storage){
                        var d = storage[i];
                        if(!d || !d["url"]) continue;
                        $("head").append('<script type="text/javascript" defer="defer" src="'+d["url"]+'"></script>');
                    }
                }
            }
        }
        // ommit right-click mousedown time
        BBLog.cache("mousedown.time.3", 0);
        $(document).on("mousedown.bblog", function(ev){
            if(ev.which == 3) BBLog.cache("mousedown.time.3", new Date().getTime());
        })
        // add contextmenu
        $("body").append($('<div id="bblog-contextmenu">').on("click", function(e){
            e.stopPropagation();
        }).on("show", function(ev, oEv){
            if(!BBLog.customContextable()) return;
            $(this).show();
            $(this).css("left", "0px").css("right", "");
            var w = $(this).outerWidth();
            $(this).css("top", oEv.pageY + 10 + "px").css("left", oEv.pageX + 10 + "px");
            if(oEv.pageX + 20 + w > window.innerWidth){
                $(this).css("right", "10px").css("left", "");
            }
        }));
        // developer language
        BBLog.storage("developer.language", 0);
        if(sessionStorage.getItem("bblog-dev-language")) {
            BBLogTranslations = JSON.parse(sessionStorage.getItem("bblog-dev-language"));
            base.showReceipt("BBLog Developer language is active. Untick Developer Language to return to the normal state");
            BBLog.storage("developer.language", 1);
        }
        var timeCache = Date.parse(new Date().toUTCString()) / 1000;
        timeCache = Math.floor(timeCache / 10000) * 10000;
        BBLog.cache("time.cache.value", timeCache);
        // include plugins
        (function(){
            if(!BBLog.storage("general.plugins")) return;
            // own defined plugins
            var data = BBLog.storage("general.plugins.own") || [];
            for(var i in data){
                var d = data[i];
                if(!d || !d["url"] || !d["active"]) continue;
                $.ajax({
                    url: d["url"],
                    dataType: "script",
                    cache : true
                });
            }
        })();
        // load themes
        (function(){
            if(!BBLog.storage("general.themes")) return;
            var data = BBLog.storage("general.themes.own") || [];
            var active = BBLog.storage("general.themes.active."+BBLog.cache("mode"));
            BBLog.cache("active.theme", "");
            if(active){
                var switches = BBLog.storage("general.themes.active."+BBLog.cache("mode")+".switches");
                var themeData = BBLog.storage("themes.data") || {};
                var version = (typeof themeData[active] != "undefined") ? themeData[active].version : 1;
                var url = BBLog.serviceUrl+'/themes/'+active+'.css?version='+version;
                BBLog.cache("theme.url", url);
                BBLog.cache("active.theme", url);
                BBLog.cache("active.theme.key", active);
                $("head").append('<link rel="stylesheet" type="text/css" href="'+url+'" class="bblog-css"/>');
                if(switches && BBLog.count(switches)){
                    $.each(switches, function (k, v){
                        if(v) $("html").addClass(k);
                    });
                }
            }
            for(var i in data){
                var d = data[i];
                if(!d || !d["url"] || !d["active"]) continue;
                $("head").append('<link rel="stylesheet" type="text/css" href="'+d["url"]+'?time='+timeCache+'" class="bblog-css"/>');
            }
        })();
        // set background
        (function(){
            var bg = BBLog.storage("general.background.text."+BBLog.cache("mode"));
            if(bg && bg.length && BBLog.storage("general.background")){
                if(bg.match(/^http/)) bg = "url("+bg+") top center repeat black";
                $("#base-background").css("background", bg);
            }
        })();
        // domchange mutation handler
        var mutationHandler = function(mutations){
            BBLog.handle("domchanged.browsercall");
        };
        var observer = null;
        if(typeof WebKitMutationObserver != "undefined"){
            observer = new WebKitMutationObserver(mutationHandler);
        }else if(typeof MutationObserver != "undefined"){
            observer = new MutationObserver(mutationHandler);
        }
        observer.observe(document.body, { childList: true , subtree : true});
        // click handler
        $(document).on("click", function(){
            $("#bblog-options").remove();
            $("#bblog-menu-icon").removeClass("active");
            $("#bblog-contextmenu").hide();
        })
        // bblog api data callback
        function callbackBBLogApi(data, isCached){
            if(!data) return;
            if(data.hotfixActive && !BBLog.cache("hotfix.activated")){
                BBLog.cache("hotfix.activated", 1);
                $.ajax({
                    url: BBLog.serviceUrl+'/plugins/bblog-hotfix.js?time='+BBLog.cache("time.cache.value"),
                    dataType: "script",
                    cache : true
                });
            }
            if(isCached !== true) {
                BBLog.storage("last.api.call."+BBLog.version, new Date().getTime() / 1000);
            }
            BBLog.storage("themes.data", data.themes);
            BBLog.storage("init.data", data);

            var username = BBLog.cache("account.name");
            if(BBLog.searchInObject(data.team, null, username)){
                BBLog.configKeys.push({"key" : "developer.language", "init" : 0, "group" : "bblog"});
            }
        }

        // check if api call is cached, if yes load from storage
        if(BBLog.storage("last.api.call."+BBLog.version) && BBLog.storage("last.api.call."+BBLog.version) > ((new Date().getTime()/1000) - BBLog.cacheTimeInitCall)){
            callbackBBLogApi(BBLog.storage("init.data"), true);
        }else{
            BBLog.handle("api.json", {
                action : "bblog.init", params : {
                    version : BBLog.version,
                    soldier : BBLog.cache("soldier.id"),
                    language : BBLog.cache("language"),
                    theme : BBLog.cache("active.theme.key") || 0,
                    browser : BBLog.cache("browser"),
                    section : BBLog.cache("mode")
                },
                handler : callbackBBLogApi
            });
        }

        // check if bblog is updated
        if(!BBLog.storage("updatepopup."+BBLog.version)){
            BBLog.storage("updatepopup."+BBLog.version, 1);
            BBLog.popup('news', BBLog.t("update.title").replace(/\{version\}/ig, BBLog.version), '<div style="padding:10px; padding-top:0px; font-size:12px;">'+BBLog.t("update.text.1").replace(/\{hp\}/ig, '<a href="http://getbblog.com" target="_blank">getbblog.com</a>')+'<br/><br/>'+BBLog.t("update.text.2")+'.<br/>'+BBLog.t("update.text.3")+'.</div>');
        }

        // cache http requests
        XMLHttpRequest.prototype._open = XMLHttpRequest.prototype.open;
        XMLHttpRequest.prototype._send = XMLHttpRequest.prototype.send;
        XMLHttpRequest.prototype.open = function(method, url, async, user, pw) {
            this.props = {
                "url" : url,
                "method" : method
            };
            return this._open(method, url, async, user, pw);
        };
        XMLHttpRequest.prototype.send = function(body) {
            this._send(body);
            var req = this;
            var iv = setInterval(function(){
                if(req.readyState == 4){
                    clearInterval(iv);
                    var cache = BBLog.cache("ajax.cache") || [];
                    cache.unshift(req);
                    BBLog.cache("ajax.cache", cache);
                }
            }, 10);
        };
        // detect viewport, bind to domchanges and replace anchors in viewport
        (function(){
            var func = function(){
                var h = $(window).height();
                var scroll = $(window).scrollTop();
                var viewportAnchors = BBLog.cache("viewport.anchors") || [];
                for(var i in viewportAnchors){
                    if(!viewportAnchors[i]) continue;
                    viewportAnchors[i].each(function(){
                        var t = $(this).offset().top;
                        if(t >= scroll && t <= (scroll + h)){
                            $(this).next().show().find("[data-src]").each(function(){
                                $(this).attr("src", $(this).attr("data-src"));
                            });
                            $(this).remove();
                        }
                    });
                }
            };
            $(window).on("scroll", func);
            BBLog.handle("domchange.addhandler", func);
        })();

        BBLog.handle("append.bblog.icon");
        BBLog.handle("egg");
    },

    /**
    * The handler for mostly all option actions
    *
    * @param action
    * @param data Any data
    * @param A callback if process is finished, optional
    * @return mixed
    */
    handle : function(action, data, callback){
        this.callback = typeof callback == "function" ? callback : function(){};
        switch(action){
            case "append.bblog.icon":
                if($("#bblog-icon").size()) return this.callback();
                var handlerType = BBLog.storage("bblog.click") ? "click" : "mouseenter";
                $("body").append($('<div id="bblog-icon">').on(handlerType+" open", function(){
                    if($("#bblog-sidebar").size()) return;
                    var e = $('<div id="bblog-sidebar" style="left:-'+$(this).width()+'px"><div class="inner"><div class="scrollArea"></div></div></div>');
                    $("body").append(e).append('<div id="bblog-sidebar-help"><div class="inner"></div></div>');
                    e.animate({left : 0}, 200);

                    $(document).on("mousemove.bblog", function(ev){
                        if(!$("#bblog-sidebar").size()) return;
                        if(ev.pageX > $("#bblog-sidebar").width()+ 20) {
                            $("#bblog-sidebar").animate({left : -$("#bblog-sidebar").width()}, 200, function(){
                                $(this).remove();
                            });
                        }
                    });

                    var cont = e.find(".scrollArea");
                    cont.height($("#bblog-sidebar").height()-20);
                    cont.append($('<div class="title">Better Battlelog '+BBLog.version+'</div>').on("click", function(){
                        window.open('http://getbblog.com/'+BBLog.cache("language")+'?ref=menu');
                    }));
                    cont.append('<div class="ads"><a href="https://www.facebook.com/getbblog" target="_blank">@FB</a> · <a href="https://twitter.com/#!/BetterBattlelog" target="_blank">@Twitter</a> · <a href="ts3server://getbblog.com?port=10000" target="_blank">Teamspeak</a> · <a href="'+BBLog.serviceUrl+'/'+BBLog.cache("language")+'/changelog?ref=menu" target="_blank">Changelog</a>');
                    cont.append($('<div class="importexport">')
                        .append(
                            $('<input type="file"/>').attr("data-help", BBLog.t("import.settings.tooltip")).on("change", function(ev){
                                var files = ev.target.files;
                                var storageFix = function(object){
                                    for(var i in object){
                                        if(object[i] === "null" || object[i] === "undefined"){
                                            delete object[i];
                                        }else if(typeof object[i] == "object" || typeof object[i] == "object"){
                                            object[i] = storageFix(object[i]);
                                        }
                                    }
                                    return object;
                                };
                                for (var i = 0, f; f = files[i]; i++) {
                                    var reader = new FileReader();
                                    reader.onload = (function(theFile) {
                                        return function(e) {
                                            try{
                                                var json = JSON.parse(e.target.result);
                                                if(json && typeof json["general.inlineimages"] != "undefined"){
                                                    BBLogStorageObject = storageFix(json);
                                                    BBLog.storage("general.inlineimages", json["general.inlineimages"]);
                                                }
                                            }catch(e){}
                                            window.location.href = BBLog.getCleanUrl();
                                        };
                                    })(f);
                                    reader.readAsBinaryString(f);
                                }
                            })
                        ).append(
                            $('<span class="bblog-button import tiny">'+BBLog.t("import.settings")+'</span>')
                        ).append(
                            $('<span class="bblog-button export tiny">'+BBLog.t("export.settings")+'</span>').attr("data-help", BBLog.t("export.settings.tooltip")).on("click", function(){
                                $._post(BBLog.serviceUrl+"/en/api/export.settings", {data : JSON.stringify(BBLogStorageObject)}, function(file){
                                    window.location.href = (BBLog.serviceUrl+"/en/api/export.settings.file?file="+file);
                                });
                            })
                        )
                    );
                    cont.find(".importexport input").width(cont.find(".importexport span:first").outerWidth());

                    var configGroups = {};
                    for(var i in BBLog.configKeys){
                        var data = BBLog.configKeys[i];
                        if(typeof data.sections != "undefined" && typeof data.sections[BBLog.cache("mode")] == "undefined") continue;
                        if(typeof configGroups[data.group] == "undefined") configGroups[data.group] = [];
                        configGroups[data.group].push(data);
                    }

                    for(var group in configGroups){
                        var groupCont = $('<div class="option-group">');
                        cont.append(groupCont);
                        var minimizeKey = group+'.minimize';
                        var cl = BBLog.storage(minimizeKey) ? 'plus' : '';
                        groupCont.append($('<div class="section-title" data-key="'+minimizeKey+'"><span class="bblog-minimize '+cl+'"></span> '+BBLog.t("section."+group)+'</div>').on("click", function(){
                            $(this).next().toggle();
                            $(this).find(".bblog-minimize").toggleClass("plus");
                            BBLog.storage($(this).attr("data-key"), $(this).find(".bblog-minimize").hasClass("plus"));
                        }));
                        var sectionCont = $('<div class="section-configs">');
                        if(BBLog.storage(minimizeKey)) sectionCont.hide();
                        for(var i in configGroups[group]){
                            var data = configGroups[group][i];

                            var key = data.key;
                            var advanced = data.button;
                            var handler = data.handler;
                            var sections = data.sections;

                            var tooltip = BBLog.t(key+'.tooltip') != key+'.tooltip' ? BBLog.t(key+'.tooltip') : null;
                            var cfg = $('<div class="section-config"><span class="bblog-checkbox" data-key="'+key+'"></span> <span class="section-text">'+BBLog.t(key)+'</span></div>');
                            if(BBLog.storage(key)) cfg.find(".bblog-checkbox").addClass("active");
                            if(advanced) cfg.find(".section-text").attr("data-advanced", advanced).addClass("bblog-button tiny");
                            if(typeof handler == "function") cfg.find("span:last").addClass("bblog-button tiny").on("click", handler);
                            if(tooltip) cfg.attr("data-help", tooltip);
                            cfg.find(".section-text").on("click", function(){$(this).prev().trigger("click")});
                            sectionCont.append(cfg);
                        }
                        groupCont.append(sectionCont);
                        groupCont.find("[data-advanced]").off().on("click", function(){
                            var type = $(this).attr("data-advanced");
                            var key = $(this).prev("[data-key]").attr("data-key");
                            var descKey = key+".tooltip";
                            var loadPopup = function(){
                                var e = $('<div>');
                                var obj = {
                                    "type" : type,
                                    "key" : key,
                                    "description" : BBLog.t(descKey),
                                    "title" : BBLog.t(key),
                                    "configObject" : BBLog.getConfigData(key),
                                    "container" : e,
                                    "loadPopup" : loadPopup
                                };
                                BBLog.handle("advanced.option."+type, obj);
                                if(obj.description) e.prepend('<div class="section-description">'+BBLog.t(key+".tooltip")+'</div>');
                                BBLog.popup("bblog-option", obj.title, e);
                            };
                            loadPopup();
                        });
                    }

                    cont.append('<br/><br/><br/><span class="build-nr">BBLog Build '+BBLog.build+'</span>');
                    cont.find(".bblog-checkbox").on("click", function(){
                        $(this).toggleClass("active");
                        var set = $(this).hasClass("active");
                        var key = $(this).attr("data-key");
                        var value = set ? 1 : 0;
                        BBLog.storage(key, value);
                        BBLog.handle("onchange.config", {'key' : key, 'value' : value});
                    });
                    cont.find("[data-help]").on("mouseenter", function(){
                        $("#bblog-sidebar-help").stop().css("top", $(this).offset().top).children().html($(this).attr("data-help"));
                        $("#bblog-sidebar-help").show().fadeOut(0).fadeIn(500);
                    }).on("mouseleave", function(){
                        $("#bblog-sidebar-help").hide().stop();
                    });
                    cont.jScrollPane().on("mousewheel", function(ev){
                        ev.preventDefault();
                    });
                }));
            break;
            case "onchange.config":
                switch(data.key){
                    case "developer.language":
                        if(data.value){
                            base.showReceipt("Loading... Please wait... Page reload automatically");
                            $.getScript(BBLog.serviceUrl+"/dev/addon-translations.js", function(){
                                base.showReceipt("Reloading now");
                                sessionStorage.setItem("bblog-dev-language", JSON.stringify(BBLogTranslations));
                                window.location.href = BBLog.getCleanUrl();
                            });
                        }else{
                            base.showReceipt("Reloading now");
                            sessionStorage.removeItem("bblog-dev-language");
                            window.location.href = BBLog.getCleanUrl();
                        }
                    break;
                    default:
                        BBLog.handle("domchange.browsercall");
                        base.showReceipt(BBLog.t("reload.required")+" (F5)");
                }
            break;
            case "advanced.option.favorites":

                var storageKey = "board.favthreads";
                var storage = BBLog.storage(storageKey) || [];

                data.title += " ("+BBLog.count(storage, true)+")";
                data.description = null;

                var table = $("<table>");
                for(var i in storage){
                    var tmp = storage[i];
                    if(!tmp) continue;
                    table.append(
                        '<tr>' +
                        '<td style="width:100%"><a href="/'+tmp.source+'/'+BBLog.cache("battlelog.language")+'forum/threadview/'+tmp.id+'/">'+tmp.title+'</a></td>' +
                        '<td><span class="bblog-delete" data-id="'+i+'"></span></td>' +
                        '</tr>'
                    );
                }

                table.find(".bblog-delete").attr("data-tooltip", BBLog.t("favThreads.delete")).on("click", function(){
                    var id = $(this).attr("data-id");
                    if(typeof storage[id] != "undefined") delete storage[id];
                    BBLog.storage("board.favthreads", storage);
                    $(this).closest("tr").fadeOut(500);
                });

                data.container.append(table);
            break;
            case "advanced.option.radar":

                data.storageKey = "radar."+data.configObject.type;
                data.storage = BBLog.storage(data.storageKey) || [];

                data.sourceKey = data.key+".sources";
                data.sourceStorageKey = data.storageKey+".sources";
                data.sourceStorage = BBLog.storage(data.sourceStorageKey) || [];
                data.cacheStorage = BBLog.cache(data.storageKey) || [];

                data.title = BBLog.t(data.key);
                data.description = null;

                // sources
                data.container.append('<b>'+BBLog.t("radar.sources")+' ('+BBLog.count(data.sourceStorage, true)+')</b>');
                data.container.append('<div class="section-description">'+BBLog.t(data.sourceKey+".tooltip")+'</div>');
                data.container.append($('<input type="text" value="'+BBLog.t("example")+': '+BBLog.serviceUrl+'/sources/'+data.configObject.type+'.json"/>').attr("data-tooltip", BBLog.t('board.radar.sources.add')).on("keyup", function(e){
                    if(e.keyCode == 13){
                        var url = $.trim(this.value);
                        if(url.match(/^http.*\.json/)){
                            data.sourceStorage.push({"url" : url});
                            BBLog.storage(data.sourceStorageKey, data.sourceStorage);
                            data.loadPopup();
                            base.showReceipt(BBLog.t("reload.required")+" (F5)");
                        }
                    }
                }));

                var table = $("<table>");
                for(var i in data.sourceStorage){
                    var d = data.sourceStorage[i];
                    if(!d) continue;
                    table.append(
                        '<tr>' +
                        '<td style="width:100%"><a href="'+d["url"]+'" target="_blank">'+d["url"]+'</a></td>' +
                        '<td><span class="bblog-delete" data-id="'+i+'"></span></td>' +
                        '</tr>'
                    );
                }
                table.find(".bblog-delete").on("click", function(){
                    var id = $(this).attr("data-id");
                    if(typeof data.sourceStorage[id] != "undefined") delete data.sourceStorage[id];
                    BBLog.storage(data.sourceStorageKey, data.sourceStorage);
                    base.showReceipt(BBLog.t("reload.required")+" (F5)");
                    data.loadPopup();
                });
                data.container.append(table);

                // radar itself
                data.container.append('<br/><br/><b>'+BBLog.t(data.key)+' ('+BBLog.count(combined, true)+')</b>');
                data.container.append('<div class="section-description">'+BBLog.t(data.key+".tooltip")+'</div>');

                var table = $("<table>");
                var combined = [data.storage, data.cacheStorage];
                for(var c in combined){
                    for(var i in combined[c]){
                        var d = combined[c][i];
                        if(!d) continue;
                        var rootUrl = '/'+d.source+'/'+BBLog.cache("battlelog.language");
                        var deleteBtn = '<span class="bblog-delete" data-id="'+i+'"></span>';
                        if(d.fromsource) deleteBtn = "";
                        switch(data.configObject.type){
                            case "board":
                                table.append(
                                    '<tr>' +
                                    '<td style="width:100%"><a href="'+rootUrl+'user/'+d["name"]+'/">'+d["name"]+'</a></td>' +
                                    '<td>'+deleteBtn+'</td>' +
                                    '</tr>'
                                );
                            break;
                            case "server":
                                table.append(
                                    '<tr>' +
                                    '<td style="width:100%"><a href="'+rootUrl+'servers/show/pc/'+d["id"]+'/">'+d["id"]+' ('+d["name"]+')</a></td>' +
                                    '<td>'+deleteBtn+'</td>' +
                                    '</tr>'
                                );
                            break;
                            case "soldier":
                                table.append(
                                    '<tr>' +
                                    '<td style="width:100%"><a href="'+rootUrl+'soldier/cem_ea_id/stats/'+d["id"]+'/">'+d["id"]+' ('+d["name"]+')</a></td>' +
                                    '<td>'+deleteBtn+'</td>' +
                                    '</tr>'
                                );
                            break;
                        }
                    }
                }
                table.find(".bblog-delete").on("click", function(){
                    var id = $(this).attr("data-id");
                    if(typeof data.storage[id] != "undefined") delete data.storage[id];
                    BBLog.storage(data.storageKey, data.storage);
                    base.showReceipt(BBLog.t("reload.required")+" (F5)");
                    data.loadPopup();
                });
                data.container.append(table);
            break;
            case "advanced.option.signature":
                data.container.append($('<textarea cols="5" rows="5">').attr("data-tooltip", BBLog.t(action+".textarea")).val(BBLog.storage("board.signature.text")).on("blur", function(){
                    this.value = $.trim(this.value);
                    this.value = this.value.replace(/http:\/\/([^\s]+)?(youtube\.com|youtu\.be)/ig, "$1$2");
                    this.value = this.value.replace(/https:\/\/([^\s]+)?(youtube\.com|youtu\.be)/ig, "$1$2");
                    this.value = this.value.replace(/http:\/\/([^\s]+)?(\.png|\.jpg|\.jpeg|\.gif)/ig, "$1$2");
                    this.value = this.value.replace(/https:\/\/([^\s]+)?(\.png|\.jpg|\.jpeg|\.gif)/ig, "$1$2");
                    this.value = this.value.replace(/\n{2,99}/g, "\n");
                    this.value = this.value.substr(0, 127);
                    BBLog.storage("board.signature.text", this.value);
                }));
            break;
            case "advanced.option.background":
                var val = BBLog.storage("general.background.text."+BBLog.cache("mode"));
                var del = true;
                if(!val) {
                    var del = false;
                    val = BBLog.t("example")+': http://getbblog.com/img/banners/1920x1080.jpg OR url(http://getbblog.com/img/banners/1920x1080.jpg) top center no-repeat'
                }
                data.container.append($('<input type="text"/>').val(val).on("keyup", function(ev){
                    if(ev.keyCode == 13){
                        BBLog.storage("general.background.text."+BBLog.cache("mode"), $.trim(this.value));
                        base.showReceipt(BBLog.t("reload.required")+" (F5)");
                        data.loadPopup();
                    }
                }));
                if(del){
                    data.container.append($('<span class="bblog-button tiny">'+BBLog.t("delete")+'</span>').on("click", function(){
                        BBLog.storage("general.background.text."+BBLog.cache("mode"), null);
                        data.loadPopup();
                        base.showReceipt(BBLog.t("reload.required")+" (F5)");
                    }));
                }
            break;
            case "advanced.option.themes":
                var initData = BBLog.storage("init.data");
                var rootUrl = '/'+BBLog.cache("mode")+'/'+BBLog.cache("battlelog.language");
                var storageKeyOff = data.key+".active."+BBLog.cache("mode");
                var storageKeyOffSwitches = data.key+".active."+BBLog.cache("mode")+".switches";
                var storage = BBLog.storage(storageKeyOff);
                if(initData){
                    for(var i in initData["themes"]){
                        var d = initData["themes"][i];
                        if(typeof d["sections"] == "undefined" || typeof d["sections"][BBLog.cache("mode")] == "undefined") continue;
                        var a = $('<div data-id="'+i+'" class="theme '+(storage == i ? 'active' : '')+'"><div class="theme-title">'+d["name"]+' v '+d["version"]+'</div><div class="sub"><a href="'+rootUrl+'user/'+d["battlelogname"]+'">'+d["battlelogname"]+'</a> - '+d["updated"]+'</div></div>').attr("data-tooltip", BBLog.t(data.key+".activate"));
                        if(typeof d["desc"] != "undefined") a.find(".title").after('<div class="theme-description">'+d["desc"]+'</div>');
                        if(typeof d["switches"] != "undefined"){
                            var b = $("<div class='theme-options'>");
                            $.each(d["switches"], function(index, value){
                                b.append($('<div><span class="bblog-checkbox" data-key="'+index+'"></span></div>').append(value));
                            });
                            a.append(b);
                            b.find(".bblog-checkbox").on("click", function(ev){
                                var s = BBLog.storage(storageKeyOffSwitches) || {};
                                var k = $(this).attr("data-key");
                                if(s[k]){
                                    s[k] = 0;
                                }else{
                                    s[k] = 1;
                                }
                                BBLog.storage(storageKeyOffSwitches, s);
                                $(this).trigger("init");
                                ev.stopPropagation();
                                ev.preventDefault();
                            }).on("init", function(){
                                var s = BBLog.storage(storageKeyOffSwitches);
                                var k = $(this).attr("data-key");
                                if(s && s[k]){
                                    $(this).addClass("active");
                                }else{
                                    $(this).removeClass("active");
                                }
                            }).trigger("init");
                        }
                        a.find("a").on("click", function(ev){
                            base.redirect($(this).attr("href"));
                            BBLog.closeAllPopups();
                            ev.stopPropagation();
                            ev.preventDefault();
                        })
                        data.container.append(a);
                    }
                    data.container.find(".theme").on("click", function(){
                        if($(this).hasClass("active")){
                            $(this).parent().children().removeClass("active");
                            BBLog.storage(storageKeyOff, 0);
                        }else{
                            $(this).parent().children().removeClass("active");
                            $(this).addClass("active");
                            BBLog.storage(storageKeyOff, $(this).attr("data-id"));
                        }
                        base.showReceipt(BBLog.t("reload.required")+" (F5)");
                    });
                }
                var storageKey = data.key+".own";
                var storage = BBLog.storage(storageKey)  || [];

                var table = $("<table>");
                for(var i in storage){
                    var tmp = storage[i];
                    if(!tmp) continue;
                    table.append(
                        '<tr>' +
                        '<td><span class="bblog-checkbox '+(tmp.active ? 'active' : '')+'" data-id="'+i+'"></span></td>' +
                        '<td style="width:100%"><a href="'+tmp["url"]+'" target="_blank">'+tmp["url"]+'</a></td>' +
                        '<td><span class="bblog-delete" data-id="'+i+'"></span></td>' +
                        '</tr>'
                    );
                }
                data.container.append('<br/><br/><b>'+BBLog.t("theme.own.css")+'</b>');
                data.container.append(table);
                data.container.append($('<input type="text" value="'+BBLog.t("example")+': '+BBLog.serviceUrl+'/dev/demo.css"/>').attr("data-tooltip", BBLog.t("custom.themes.add")).on("keyup", function(ev){
                    if(ev.keyCode == 13){
                        var url = $.trim(this.value);
                        if(url.match(/^http.*/)){
                            var storage = BBLog.storage(storageKey) || [];
                            storage.push({"url" : $.trim(url), "active" : 1});
                            BBLog.storage(storageKey, storage);
                            base.showReceipt(BBLog.t("reload.required")+" (F5)");
                            data.loadPopup();
                        }
                    }
                }));
                data.container.find(".bblog-checkbox").on("click", function(){
                    var id = $(this).attr("data-id");
                    var storage = BBLog.storage(storageKey) || [];
                    if(typeof storage[id] == "undefined") return false;
                    storage[id]["active"] = !$(this).hasClass("active");
                    BBLog.storage(storageKey, storage);
                    base.showReceipt(BBLog.t("reload.required")+" (F5)");
                    data.loadPopup();
                });
                data.container.find(".bblog-delete").on("click", function(){
                    var id = $(this).attr("data-id");
                    var storage = BBLog.storage(storageKey) || [];
                    if(typeof storage[id] != "undefined") delete storage[id];
                    BBLog.storage(storageKey, storage);
                    base.showReceipt(BBLog.t("reload.required")+" (F5)");
                    data.loadPopup();
                });
            break;
            case "advanced.option.plugins":
                var storageKey = data.key+".own";
                var storage = BBLog.storage(storageKey)  || [];
                var iData = {};
                if(action == "advanced.option.channels"){
                    iData.example = "";
                    iData.tooltip = BBLog.t("channels.add");
                }else{
                    iData.example = BBLog.t("example")+': '+BBLog.serviceUrl+'/plugins/example.js';
                    iData.tooltip = BBLog.t("custom.plugins.add");
                }

                var table = $("<table>");
                for(var i in storage){
                    var tmp = storage[i];
                    if(!tmp) continue;
                    table.append(
                        '<tr>' +
                        '<td><span class="bblog-checkbox '+(tmp.active ? 'active' : '')+'" data-id="'+i+'"></span></td>' +
                        '<td style="width:100%"><a href="'+tmp["url"]+'" target="_blank">'+tmp["url"]+'</a></td>' +
                        '<td><span class="bblog-delete" data-id="'+i+'"></span></td>' +
                        '</tr>'
                    );
                }
                data.container.append(table);
                data.container.append($('<input type="text" value="'+iData.example+'"/>').attr("data-tooltip", iData.tooltip).on("keyup", function(ev){
                    if(ev.keyCode == 13){
                        var url = $.trim(this.value);
                        if(url.match(/^http.*/)){
                            var storage = BBLog.storage(storageKey) || [];
                            storage.push({"url" : $.trim(url), "active" : 1});
                            BBLog.storage(storageKey, storage);
                            base.showReceipt(BBLog.t("reload.required")+" (F5)");
                            data.loadPopup();
                        }
                    }
                }));
                data.container.find(".bblog-checkbox").on("click", function(){
                    var id = $(this).attr("data-id");
                    var storage = BBLog.storage(storageKey) || [];
                    if(typeof storage[id] == "undefined") return false;
                    storage[id]["active"] = !$(this).hasClass("active");
                    BBLog.storage(storageKey, storage);
                    base.showReceipt(BBLog.t("reload.required")+" (F5)");
                    data.loadPopup();
                });
                data.container.find(".bblog-delete").on("click", function(){
                    var id = $(this).attr("data-id");
                    var storage = BBLog.storage(storageKey) || [];
                    if(typeof storage[id] != "undefined") delete storage[id];
                    BBLog.storage(storageKey, storage);
                    base.showReceipt(BBLog.t("reload.required")+" (F5)");
                    data.loadPopup();
                });
            break;
            case "advanced.option.comments":
                data.key = "general.local.comments.data";
                var storage = BBLog.storage(data.key) || {};
                var table = $("<table>");
                for(var type in storage){
                    for(var i in storage[type]){
                        var d = storage[type][i];
                        if(!d || !d[0].length) continue;
                        var url = window.location.host != d[3] ? "http://"+d[3]+d[2] : d[2];
                        table.append(
                            '<tr>' +
                            '<td style="white-space:nowrap"><a href="'+url+'" onclick="base.redirect($(this).attr(\'href\')); return false;">'+type.toUpperCase()+" :: "+d[1]+'</a></td>' +
                            '<td style="width:100%">'+d[0].substr(0, 100)+'...</td>' +
                            '</tr>'
                        );
                    }
                }
                data.container.append(table);
            break;
            case "domchange.addhandler":
                data();
                var obj = BBLog.cache("domchange.handler") || [];
                obj.push(data);
                BBLog.cache("domchange.handler", obj);
            break;
            // add plugins
            case "add.plugin":
                if(typeof data != "object") return this.callback();
                if(typeof data.id == "undefined" || data.id.match(/[^0-9a-z\-]/)){
                    console.error("BBLog Plugin with invalid characters as id parameter");
                    return this.callback();
                }
                // config flags
                if(typeof data.configFlags == "object"){
                    if(typeof data.translations != "object"){
                        console.error("Missing required translation for plugin "+data.id);
                        return this.callback();
                    }
                    for(var i in data.configFlags){
                        var d = data.configFlags[i];
                        if(typeof d[0] != "undefined"){
                            var newD = {key : d[0], init : d[1]};
                            if(typeof d[2] != "undefined") newD.handler = d[2];
                            d = newD;
                        }
                        d.group = data.id;
                        if(typeof data.translations["en"][d.key] == "undefined"){
                            console.error("Missing required translation for plugin "+data.id+" and key "+d.key);
                            return this.callback();
                        }
                        if(typeof d.handler != "undefined") {
                            if(typeof d.handler != "function"){
                                delete d.handler;
                            }else{
                                var tmp = d.handler;
                                d.handler = function(){
                                    tmp(data);
                                }
                            }
                        }
                        d.key = data.id+"."+d.key;
                        if(BBLog.storage(d.key) === null) BBLog.storage(d.key, d.init);
                        BBLog.configKeys.push(d);
                    }
                }
                // translations
                BBLogTranslations["en"]["section."+data.id] = data.name;
                if(typeof data.translations == "object"){
                    if(typeof data.translations["cz"] != "undefined" && typeof data.translations["cs"] == "undefined") data.translations["cs"] = data.translations["cz"];
                    for(var lang in data.translations){
                        for(var key in data.translations[lang]) {
                            if(key == "plugin.name") BBLogTranslations[lang]["section."+data.id] = data.translations[lang][key];
                            BBLogTranslations[lang][data.id+"."+key] = data.translations[lang][key];
                        }
                    }
                }
                // add some functions
                data.t = function(key){return BBLog.t(this.id+"."+key);}
                data.cache = function(key, value){return BBLog.cache(this.id+"."+key, value);}
                data.storage = function(key, value){return BBLog.storage(this.id+"."+key, value);}
                if(typeof data.init == "function") data.init(data);
                if(typeof data.domchange == "function") BBLog.handle("domchange.addhandler", function(){data.domchange(data)});
            break
            // this is called everytime something changed, by the browser
            // we wait some time to prevent mass call of the triggers
            case "domchanged.browsercall":
                clearTimeout(BBLog.cache("domchange.timeout"));
                BBLog.cache("domchange.timeout", setTimeout(function(){
                    // call for each config key, if enabled
                    for(var i in BBLog.configKeys) {
                        var data = BBLog.configKeys[i];
                        if(typeof data.sections != "undefined" && typeof data.sections[BBLog.cache("mode")] == "undefined") continue;
                        if(!BBLog.storage(data.key)) continue;
                        BBLog.handle(data.key, data);
                    }
                    // run user defined handler
                    var obj = BBLog.cache("domchange.handler");
                    if(obj) for(var i in obj) obj[i]();
                }, 250));

            break;
            // load data from the getbblog api
            case "api.json":
                var url = BBLog.serviceUrl+"/en/api/"+data.action+"?jsoncallback=?";
                $.getJSON(url, data.params, data.handler);
            break;
            case "source.callback":
                if(BBLog.count(data)){
                    var type = storageKey = data["type"];
                    switch(type){
                        case "radar.soldier":
                        case "radar.server":
                            var keyAs = "id";
                            var params = {"name" : "name"};
                        break;
                        case "radar.board":
                            var keyAs = "name";
                            var params = {};
                        break;
                        default:
                            return false;
                    }
                    var storage = BBLog.cache(storageKey) || [];
                    data = data.list;
                    for(var i in data){
                        var pushData = {'fromsource' : true, "source" : BBLog.cache("mode")};
                        pushData[keyAs] = i;
                        for(var p in params) pushData[params[p]] = data[i][p];
                        storage.push(pushData);
                    }
                    BBLog.cache(storageKey, storage);
                }
            break;
            case "json.from.battlelog":
                if(data.url){
                    data.cache = typeof data.cache == "undefined" ? true : data.cache;
                    // check of url is cached
                    if(data.cache){
                        var cache = BBLog.cache("ajax.cache") || [];
                        var c  = 0;
                        var max = 10;
                        for(var i in cache){
                            if(c++ > max){
                                delete cache[i];
                                continue;
                            }
                            var d = cache[i];
                            if(!d) continue;
                            if((data.url && d.props.url == data.url) || (data.regex && new RegExp(data.regex, "i").test(d.props.url))){
                                return data.callback($.parseJSON(d.responseText));
                            }
                        }
                    }
                    // if not cached, try to fetch it - but only of no regex is given
                    if(data.regex) return this.callback();
                    var cb = data.callback;
                    $.ajax({
                        "url" : data.url,
                        success : function(data){
                            cb(typeof data == "string" ? $.parseJSON(data) : data);
                        },
                        beforeSend : function( xhr, settings ) {
                            xhr.overrideMimeType( 'application/json' );
                            xhr.setRequestHeader( 'X-AjaxNavigation', 1);
                        }
                    });
                }
            break;
            case "json.post.to.battlelog":
                if(data.url){
                    var cb = data.callback;
                    $.ajax({
                        "url" : data.url,
                        "type" : "post",
                        "data" : data.data,
                        success : function(data){
                            cb(typeof data == "string" ? $.parseJSON(data) : data);
                        },
                        beforeSend : function( xhr, settings ) {
                            xhr.overrideMimeType( 'application/json' );
                            xhr.setRequestHeader( 'X-AjaxNavigation', 1);
                        }
                    });
                }
            break;
            case "clear.storage":
                BBLogStorageObject = {};
                BBLog.storage("alive", 1);
            break;
            case "clear.plugins":
                BBLog.storage("general.plugins.own", []);
            break;
            case "clear.themes":
                BBLog.storage("general.themes.own", []);
                BBLog.storage("general.themes.active", null);
            break;
            case "bf3.stats.higherlevel":
                if(BBLog.cache("mode") != "bf3" || !window.location.href.match(/\/soldier\/.*\/stats\//)) return this.callback();
                var e = $(".profile-venicestats-overview-highlight-rank");
                if(BBLog.elementCheck(e, action)) return this.callback();
                var maxRankPoints = 24600000;
                var score = parseInt($(".profile-venicestats-overview-total-score").text().replace(/[^0-9]/ig, ""));
                var rank = 145 + Math.floor((score - maxRankPoints) / 230000);
                if(rank > 145){
                    var colonelSS = rank - 45;
                    $(".profile-venicestats-overview-highlight-rank-info *:first").append('<br/><div style="font-size:14px;">(BBLog Rank '+rank+')</div>');
                    $(".profile-venicestats-overview-highlight-rank-info *:last").append('<br/><div style="font-size:14px;">(BBLog Service Star '+colonelSS+')</div>');
                }
            break;
            case "bf4.stats.higherlevel":
                if(BBLog.cache("mode") != "bf4" || !window.location.href.match(/\/soldier\/.*\/stats\//)) return this.callback();
                var e = $("#overview-rank");
                if(BBLog.elementCheck(e, action)) return this.callback();
                var maxRankPoints = 10400000;
                var maxRank = 110;
                var score = parseInt($("#stat-score").text().replace(/[^0-9]/ig, ""));
                var rank = maxRank + Math.floor((score - maxRankPoints) / 200000);
                if(rank > maxRank){
                    $("#overview-rank .rank").append('<br/><div class="bblog-rank">(BBLog Rank '+rank+')</div>');
                }
            break;
            case "bf4.serverbrowser.data":
                if(BBLog.cache("mode") != "bf4" || !serverbrowserwarsaw || !serverbrowserwarsaw.table) return this.callback();
                var e = serverbrowserwarsaw.table;

                e.find("tbody .server-row").each(function(){
                    $(this).addClass("bblog-serverbrowser-filters")
                    var data = $(this).data("server");
                    if(!data) return true;
                    if(data.slots[4] && !$(this).find(".bblog-slots.commander").length) $(this).find("td.players").append('<div class="bblog-slots commander"><span class="bblog-icon"></span>'+data.slots[4].current+"/"+data.slots[4].max+'</div>');
                    if(data.slots[8] && !$(this).find(".bblog-slots.spectator").length) $(this).find("td.players").append('<div class="bblog-slots spectator"><span class="bblog-icon"></span>'+data.slots[8].current+"/"+data.slots[8].max+'</div>');
                });

                if(BBLog.elementCheck(e, action)) return this.callback();

                var last = e.find("th.server-info a[data-sort]").last();
                last.after($('<a href="#" data-sort="commander" class="ignored-trigger-el">Commander</a>').data("sort", "commander")).after(', ');

                if(typeof serverbrowserwarsaw.sorter._refreshSortings == "undefined"){
                    serverbrowserwarsaw.sorter._refreshSortings = serverbrowserwarsaw.sorter.refreshSortings;
                    serverbrowserwarsaw.sorter.refreshSortings = function(){
                        serverbrowserwarsaw.sorter._refreshSortings();
                        var ASC = false;
                        var DESC = !ASC;
                        serverbrowserwarsaw.sorter.sortings.commander = {
                            defaultOrder: DESC,
                            dataType: "server",
                            sortFunc: function (data) {
                                return data.slots[4] ? data.slots[4].current + data.slots[4].max / 1000 : -1;
                            }
                        };
                    };
                }
                serverbrowserwarsaw.sorter.toggles.off("click.page.serverbrowser");
                serverbrowserwarsaw.trigger("pageshow.sort");
            break;
            case "bf4.serverbrowser.livescore":
                var s = $S("selected-server-scoreboard");
                if(typeof s._render_orig == "undefined"){
                    s._render_orig =  s.render;
                    s.render = function(o, b, kwargs){
                        var ret = this._render_orig(o, b, kwargs);
                        try{
                            if(o && o.scoreboard && o.scoreboard.result){
                                var maxT = o.scoreboard.result.teams.shift().status.ticketsMax;
                                if(maxT > 10) ret = ret.replace(/(\"box-content.*?\"\>)/i, "$1<div class='max_tickets'>"+maxT+" Tickets</div><div class='base-clear'></div>");

                            }
                        }catch(e){console.error(e)}
                        return ret;
                    };
                    if(s.rendered) s.refresh();
                }
            break;
            case "general.server.hiddeninfo":
                if(!window.location.href.match(/servers\/show\//)) return this.callback();
                if(BBLog.cache("mode") == "bf4"){
                    var e = $("#server-page-gamemode");
                    if(BBLog.elementCheck(e, action)) return this.callback();
                    BBLog.handle("json.from.battlelog", {url : window.location.pathname, callback : function(data){
                        if(!data.context.server.extendedInfo) return this.callback();
                        var html;

                        var banner = data.context.server.extendedInfo.bannerUrl;
                        if(banner.length){
                            html = $('<div class="box-content"><img alt="Server-Banner" style="max-width:700px; max-height:300px;"/></div>');
                            html.find("img").attr("src", banner);
                            $("#server-description").after(html);
                        }
                        var message = data.context.server.extendedInfo.message;
                        if(message.length){
                            html = $('<div class="box-content"><p></p></div>');
                            html.find("p").text('Message: '+message);
                            $("#server-description").after(html);
                        }
                    }});
                }else{
                    var e = $("#serverguide-show-joinserver-form");
                    if(BBLog.elementCheck(e, action)) return this.callback();
                    BBLog.handle("json.from.battlelog", {url : e.attr("action"), callback : function(data){
                        if(!data.context.server.extendedInfo) return this.callback();
                        var html;

                        var banner = data.context.server.extendedInfo.bannerUrl;
                        if(banner.length){
                            html = $('<div id="server-message"><h3>Banner</h3><p><img alt="Server-Banner" style="max-width:700px; max-height:300px;"/></p></div>');
                            html.find("img").attr("src", banner);
                            $("#server-settings").next('.base-clear').after(html);
                        }
                        var message = data.context.server.extendedInfo.message;
                        if(message.length){
                            html = $('<div id="server-description"><h3>Message</h3><p></p></div>');
                            html.find("p").text(message);
                            $("#server-settings").next('.base-clear').after(html);
                        }
                    }});
                }
            break;
            case "bf3.awards.optimize":
                if(BBLog.cache("mode") != "bf3" || !window.location.href.match(/awards\//)) return this.callback();
                var e = $("#profile-stats-awards-progression");
                if(BBLog.elementCheck(e, action)) return this.callback();
                var all = e.find(".profile-stats-awards-progression-body:first");
                all.children("[data-dependencies]").each(function(){
                    var medEl = $(this);
                    var ribEl = $("#award-ribbon-"+medEl.attr("data-dependencies"));
                    if(!ribEl.size()){
                        var perc = medEl.find(".progress").get(0).style.width;
                        medEl.prepend('<div class="profile-stats-num-awards-taken bblog-required-ribbons">'+perc+'</div>');
                        e.find(".profile-stats-awards-progression-body:first").append(this);
                        return true;
                    }

                    var title = medEl.attr("title");
                    if(!title) title = medEl.attr("data-tooltip");
                    var neededCounts = parseInt(title.match(/([0-9]{2})[\s+]?$/)[1]);
                    if(ribEl.find(".profile-stats-num-awards-taken").size()){
                        var haveCounts = parseInt(ribEl.find(".profile-stats-num-awards-taken").text().replace(/[^0-9]/ig, ""));
                    }else if(!ribEl.hasClass("nottaken")){
                        var haveCounts = 1;
                    }else{
                        var haveCounts = 0;
                    }

                    var required = ((neededCounts * Math.ceil(haveCounts / neededCounts)) - haveCounts);
                    required = isNaN(required) || required == 0 ? neededCounts : required;

                    // update bubble title with extra infos
                    var newTitle =  title+"<br/>"+required+" "+BBLog.t("ribbons.left");
                    medEl.attr("data-tooltip", newTitle);
                    medEl.prepend('<div class="profile-stats-num-awards-taken bblog-required-ribbons">'+required+'</div>');
                });
                // iterate over all ribbons to detected if a corresponding medal exist
                $(".profile-stats-awards-progression-item-ribbon").each(function(){
                    var id = $(this).attr("id").replace(/.*\-/ig, "");
                    if(!e.find("[data-dependencies='"+id+"']").size()){
                        $(".profile-stats-awards-progression-column-ribbons .profile-stats-awards-progression-body").append(this);
                        e.find(".profile-stats-awards-progression-body:last").append(this);
                    }
                })
            break;
            case "bf3.reports.bf3stats":
                var match = window.location.href.match(/battlereport\/show\/([0-9]+)\/([0-9]+)\//);
                if(BBLog.cache("mode") != "bf3" || !match) return this.callback();
                var e = $("#battlereport h1:first");
                if(BBLog.elementCheck(e, action)) return this.callback();
                var reportId = match[2];
                var format = match[1];
                var platform = BBLog.deviceInfo[format];
                if(platform == "xbox") platform = "360";
                var html = $(
                    '<span id="bf3stats-report" class="bblog-button bblog-report-buttons bf3stats">Bf3stats.com Battlereport</span>'
                ).attr("data-tooltip" ,BBLog.t('report.bf3stats.bubble'));
                html.on("click", function(){
                    window.open('http://bf3stats.com/report/'+platform+'/'+reportId);
                });
                e.after(html);
            break;
            case "bf3.reports.download":
                var match = window.location.href.match(/battlereport\/show\/([0-9]+)\/([0-9]+)\//);
                if(BBLog.cache("mode") != "bf3" || !match) return this.callback();
                var e = $("#battlereport h1:first");
                if(BBLog.elementCheck(e, action)) return this.callback();
                var reportId = match[2];
                var format = match[1];
                var html = $(
                    '<span id="blogger-report" class="bblog-button bblog-report-buttons blogger">'+BBLog.t('report.download')+'</span>'
                ).attr("data-tooltip", BBLog.t('report.download.bubble'));
                var url = window.location.href.replace(/(.*)\/show\/.*/ig, "$1/loadgeneralreport")+"/"+reportId+"/"+format+"/";
                BBLog.handle("json.from.battlelog", {"url" : url, callback : function(data){
                    if($(".battlereport-header-info a[href*='/servers/']").size()){
                        $(".battlereport-header-info a[href*='/servers/']").text(data.gameReport.gameServer.name);
                    }else{
                        $(".battlereport-header-info [data-timestamp]:first").parent().after(' • <a onclick="return false;" href="" style="cursor:text; color:black; text-decoration:none; font-weight:normal;">'+data.gameReport.gameServer.name+'</a>');
                    }
                }});
                html.on("click", function(){
                    var btn = $(this);
                    btn.text(BBLog.t('report.download.loading'));
                    btn.off("click");
                    var rc = $("#battlereport");
                    var data = {};
                    data.domain = window.location.host;
                    data.url = window.location.href;
                    data.lang = BBLog.cache("language");
                    data.title = rc.find("h1.base-big-title").text();
                    data.timestamp = rc.find(".battlereport-header-info [data-timestamp]").attr("data-timestamp");
                    data.device = rc.find(".battlereport-header-info-gameicon").attr("class").match(/common-game-([0-9]+)-([0-9])/)[2];
                    data.game = rc.find(".battlereport-header-info-gameicon").attr("class").match(/common-game-([0-9]+)/)[1];
                    data.servername = rc.find(".battlereport-header-info:first a:first").text();
                    data.serverlink = rc.find(".battlereport-header-info:first a:first").attr("href");
                    data.roundtime = rc.find(".battlereport-header-info:first span:last").text();
                    data.mapimage = rc.find("#battlereport-teamscores").css("background-image");
                    data.mapname = rc.find(".battlereport-header-info:last span:eq(0)").text();
                    data.mapmode = rc.find(".battlereport-header-info:last span:eq(1)").text();
                    data.rankType = rc.find(".battlereport-header-info:last span:eq(2)").text();
                    data.reportId = reportId;
                    data.teams = [
                        {
                            name : rc.find(".battlereport-teamscores-scores > div:first").clone().children().remove().end().text(),
                            score : rc.find(".battlereport-teamscores-scores > div:first div:first").text(),
                            scoreMsg : rc.find(".battlereport-teamscores-scores > div:first .battlereport-teamscores-score-msg").text(),
                            tableHeaders : [
                                rc.find(".battlereport-teamstats-list:first th:eq(0)").text(),
                                rc.find(".battlereport-teamstats-list:first th:eq(1)").text(),
                                rc.find(".battlereport-teamstats-list:first th:eq(2)").text(),
                                rc.find(".battlereport-teamstats-list:first th:eq(3)").text(),
                                rc.find(".battlereport-teamstats-list:first th:eq(4)").text(),
                                rc.find(".battlereport-teamstats-list:first th:eq(5)").text()
                            ],
                            entries : []
                        },
                        {
                            name : rc.find(".battlereport-teamscores-scores > div:last").clone().children().remove().end().text(),
                            score : rc.find(".battlereport-teamscores-scores > div:last div:first").text(),
                            scoreMsg : rc.find(".battlereport-teamscores-scores > div:last .battlereport-teamscores-score-msg").text(),
                            entries : []
                        }
                    ];
                    data.topscores = [];
                    rc.find(".battlereport-topscores-inner .battlereport-topscores-column").each(function(){
                        data.topscores.push({
                            title : $(this).find("h3").text(),
                            avatar : $(this).find("a.avatar").attr("style").match(/(http.*?)\);/i)[1],
                            username : $(this).find(".battlereport-topscores-column-info a").text(),
                            userlink : $(this).find(".battlereport-topscores-column-info a").attr("href"),
                            text : $(this).find("h6").text(),
                            textsub : $(this).find("p").text()
                        });
                    });
                    rc.find(".battlereport-teamstat-column").each(function(index){
                        $(this).find("tr[data-personaid]").each(function(){
                            var tmp = {};
                            tmp.pos1 = $(this).is(".pos1.battlereport-teamstats-list-row-top3"),
                            tmp.pos2 = $(this).is(".pos2.battlereport-teamstats-list-row-top3"),
                            tmp.pos3 = $(this).is(".pos3.battlereport-teamstats-list-row-top3"),
                            tmp.bestSquad = $(this).hasClass("bestSquad"),
                            tmp.place = $(this).find(".battlereport-teamstats-pos").text(),
                            tmp.squad = $(this).find(".battlereport-teamstats-squad").text(),
                            tmp.avatar = $(this).find("a.avatar").attr("style").match(/(http.*?)\);/i)[1],
                            tmp.username = $(this).find(".common-playername-personaname-nolink").text(),
                            tmp.userlink = $(this).find(".battlereport-teamstats-user-container-avatar-small a").attr("href"),
                            tmp.userrank = $(this).find(".battlereport-teamstats-user-personarank img").attr("src"),
                            tmp.kills = $(this).find(".battlereport-teamstats-kills").text(),
                            tmp.deaths = $(this).find(".battlereport-teamstats-deaths").text(),
                            tmp.score = $(this).find(".battlereport-teamstats-score").text();
                            tmp.dnf = $(this).hasClass("dnf");
                            data.teams[index].entries.push(tmp);
                        });
                    });
                    $._post(BBLog.serviceUrl+"/en/api/report.pdf", {"data" : JSON.stringify(data)}, function(url){
                        var m = url.match(/^E([0-9])/);
                        if(m){
                            switch(m[1]){
                                case "3":
                                    alert(BBLog.t("report.pdf.error.3"));
                                break;
                            }
                        }else{
                            btn.text(BBLog.t('report.download.done'));
                            window.open(url);
                            btn.on("click", function(){
                                window.open(url);
                            });
                        }
                    });
                });
                e.after(html);
            break;
            case "general.server.filterset":
                var e = $("#serverbrowser-filters, #serverguide-filtertoggle");
                if(!e.size()) return this.callback();
                if(BBLog.elementCheck(e, action)) return this.callback();
                var storageKey = BBLog.cache("mode")+".serverfilter.array";
                if(BBLog.cache("mode") == "bf4"){
                    e = $("#serverbrowser-filters");
                    e.addClass("bblog-bf4-filters");
                    e = e.find("header.serverbrowser-refresh:first");

                    var clone = e.clone(false, false);
                    clone.attr("class", "bblog-bf4-filter-btn");
                    clone.html("&nbsp;");
                    e.before(clone);
                    $("#serverbrowser-filters").after('<div id="bblog-filtersets">');
                }else{
                    var btn = $('<div class="bblog-bf3-filter-btn"></div>');
                    $("#serverguide-filtertoggle, #serverguide-apply-filters").addClass("bblog-bf3-filters").append(btn);
                    $("#serverguide-filter-form").after('<div id="bblog-filtersets">');
                }

                var filters = BBLog.storage(storageKey) || [];
                var table = $("<table>");
                if(BBLog.count(filters)){
                    for(var i in filters){
                        var tmp = filters[i];
                        if(!tmp) continue;
                        if(tmp.visible){
                            var btn = $('<span class="btn">');
                            btn.text(tmp.name);
                            btn.attr("data-data", tmp.data);
                            btn.on("click", function(){
                                window.location.href = window.location.href.replace(/\?.*/ig, "")+"?"+$(this).attr("data-data");
                            });
                            $("#bblog-filtersets").show().append(btn);
                        }
                    }
                }

                $(".bblog-bf3-filter-btn, .bblog-bf4-filter-btn").on("click", function(ev){
                    ev.stopPropagation();
                    var html = $('<div>'+BBLog.t("filterpopup.text")+'<br/><br/></div>');
                    if(BBLog.count(filters)){
                        var table = $("<table>");
                        for(var i in filters){
                            var tmp = filters[i];
                            if(!tmp) continue;
                            table.append(
                                '<tr>' +
                                '<td><span class="bblog-checkbox '+(tmp.visible ? 'active' : '')+'" data-id="'+i+'" data-tooltip="'+BBLog.t("filterpopup.visible")+'"></span></td>' +
                                '<td style="width:100%"><a href="#" class="filter-entry" data-id="'+i+'">'+tmp.name+'</a></td>' +
                                '<td><span class="bblog-delete" data-id="'+i+'"></span></td>' +
                                '</tr>'
                            );
                        }
                        html.append(table);

                        html.find(".filter-entry").on("click", function(ev){
                            window.location.href = window.location.href.replace(/\?.*/ig, "")+"?"+filters[$(this).attr("data-id")].data;
                            ev.preventDefault();
                        });
                        html.find(".bblog-delete").on("click", function(ev){
                            delete filters[$(this).attr("data-id")];
                            BBLog.storage(storageKey, filters);
                            BBLog.handle(action, data);
                        });
                        html.find(".bblog-checkbox").on("click", function(ev){
                            $(this).toggleClass("active");
                            filters[$(this).attr("data-id")].visible = $(this).hasClass("active");
                            BBLog.storage(storageKey, filters);
                            BBLog.handle(action, data);
                        });
                    }
                    html.append($('<input type="text"/>').attr("data-tooltip", BBLog.t("filterpopup.enter")).on("keyup", function(ev){
                        if(ev.keyCode == 13){
                            $("#serverbrowser-filters .filters-container button[type='submit'], #serverguide-apply-filters .serverguide-apply-filter-button, #serverguide-filtertoggle .serverguide-apply-filter-button").trigger("click");
                            var text = $.trim(this.value);
                            BBLog.closeAllPopups();
                            setTimeout(function(){
                                var hash = window.location.href.match(/\?(.*)/)[1];
                                var filters = BBLog.storage(storageKey) || [];
                                filters.push({name : text, "data" : hash, "visible" : true});
                                BBLog.storage(storageKey, filters);
                            }, 200);
                        }
                    }));
                    BBLog.popup("bblog-option", BBLog.t("filterpopup.title"), html);
                });
            break;
            case "general.server.markfavorites":
                if(!window.location.href.match(/servers\/(\?|$)/) || !S.globalContext) return this.callback();
                var e  = $("#serverguide-server-list");
                for(var i in S.globalContext.favGuids){
                    var f = S.globalContext.favGuids[i];
                    e.find("div[guid='"+f+"']").addClass("favorite");
                }
            break;
            case "bf3.dogtags.counter":
                if(BBLog.cache("mode") != "bf3" || !window.location.href.match(/dogtags\//)) return this.callback();
                var e  = $("#dogtags-list");
                if(!e.size() || BBLog.elementCheck(e, action)) return this.callback();
                var all = e.find("ul.profile-stats-dogtags li");
                e.find("div.filter-all").append(' <span>('+all.size()+')</span>');
                e.find("div.filter-taken").append(' <span>('+all.filter(".taken").size()+')</span>');
                e.find("div.filter-unlocked").append(' <span>('+all.filter(".unlocked").size()+')</span>');
            break;
            case "bf3.dogtags.noanimation":
                if(BBLog.cache("mode") != "bf3" || !window.location.href.match(/dogtags\//)) return this.callback();
                var e  = $("#dogtags-list");
                if(!e.size() || BBLog.elementCheck(e, action)) return this.callback();
                e.find("div.filter-option").closest("li").each(function(){
                    var c = $(this).clone(false, false);
                    c.find("[data-filter]").removeClass("filter-option").addClass("filter-option-legacy").each(function(){
                        $(this).attr("data-filter-legacy", $(this).attr("data-filter"));
                        $(this).removeAttr("data-filter");
                    });
                    $(this).parent().append(c);
                    $(this).remove();
                });
                $("#dogtags-list-isotope .isotope-item").addClass("bblog-fix hide").attr("style", "");
                e.find(".filter-option-legacy").on("click", function(){
                    setTimeout(function(){
                        var filter1 = $("#profile-dogtags-type-filter li.selected .filter-option-legacy").attr("data-filter-legacy");
                        var filter2 = " "+$("#profile-dogtags-criteria-filter li.selected .filter-option-legacy").attr("data-filter-legacy");
                        var items = $("#dogtags-list-isotope .isotope-item");
                        items.addClass("hide");
                        if(filter1) items = items.filter(filter1);
                        if(filter2) items = items.filter(filter2);
                        items.removeClass("hide");
                    }, 80);
                }).filter(":first").trigger("click");
            break;
            case "general.mainserverbrowser":
                var e  = $(".main-loggedin-playbar:first");
                if(BBLog.elementCheck(e, action)) return this.callback();
                e.addClass("bblog-mod");
                var copy = $('<button class="common-button-large main-loggedin-playbutton"><p>'+BBLog.t("serverbrowser")+'</p></button>').on("click", function(){
                    base.redirect('/'+BBLog.cache("mode")+'/'+BBLog.cache("battlelog.language")+'servers/');
                });
                e.append(copy);
            break;
            case "general.linkintext":
                var all = $("#profile-presentation, div.platoon-presentation-padder, div.wallpost-body, section#user .box.presentation .box-content");
                all.each(function(){
                    var e = $(this);
                    if(BBLog.elementCheck(e, action)) return true;
                    var html = (" "+$(this).html()+" ").replace(/(http|ts3server|mumble|https)(\:\/\/[^\n\r\t <\[\]]+)/ig, '<a href="$1$2" target="_blank">$1$2</a>');
                    $(this).html($.trim(html));
                    BBLog.handle("domchange.browsercall");
                });
            break;
            case "general.inlineimages":
                // first run the inlinetext handler
                BBLog.handle("general.linkintext", null, function(){
                    var imageTpl = '<span class="bblog-youtube-anchor"></span><div class="bblog-inlineimage" style="display:none;"><span onclick="window.open($(this).children().attr(\'src\'))"><img data-src="{url}" alt="{url}" title="{url}" onerror="$(this).replaceWith(this.alt)"/></span></div>';
                    $("#profile-presentation, div.platoon-presentation-padder, div.forum-threadview-post-text, section#user .box.presentation .box-content").each(function(){
                        if(BBLog.elementCheck($(this), action)) return true;
                        var links = $(this).find("a[href$='.jpg'], a[href$='.gif'], a[href$='.jpeg'], a[href$='.png'], a[href$='.JPG'], a[href$='.GIF'], a[href$='.JPEG'], a[href$='.PNG']");
                        links.each(function(){
                            $(this).replaceWith(imageTpl.replace(/{url}/ig, $(this).attr("href")));
                        });

                        var viewportAnchors = BBLog.cache("viewport.anchors") || [];
                        viewportAnchors.push($(this).find(".bblog-youtube-anchor"));
                        BBLog.cache("viewport.anchors", viewportAnchors);
                    });
                });
            break;
            case "general.inlineyoutube":
                // first run the inlinetext handler
                BBLog.handle("general.linkintext", null, function(){
                    var iframeTpl = '<span class="bblog-youtube-anchor"></span><div class="bblog-youtube" style="display:none;"><iframe data-src="http://www.youtube.com/embed/{id}?wmode=transparent&hd=1" frameborder="0" allowfullscreen></iframe></div>';
                    $("#profile-presentation, div.platoon-presentation-padder, div.forum-threadview-post-text, section#user .box.presentation .box-content").each(function(){
                        if(BBLog.elementCheck($(this), action)) return true;
                        // all default youtube urls
                        $(this).find("a[href*='youtube.com/'][href*='v='], a[href*='youtube.com/'][href*='/embed/'], a[href*='youtu.be/']").each(function(){
                            var matchInner = this.href.match(/v=([a-z0-9\-\_]+)/i);
                            if(matchInner){
                                $(this).replaceWith(iframeTpl.replace(/{id}/ig, matchInner[1]));
                                return true;
                            }
                            matchInner = this.href.match(/(.*?)\/([a-z0-9\-\_]+)(\?|$)/i);
                            if(matchInner){
                                $(this).replaceWith(iframeTpl.replace(/{id}/ig, matchInner[2]));
                                return true;
                            }
                            matchInner = this.href.match(/\/embed\/([a-z0-9\-\_]+)/i);
                            if(matchInner){
                                $(this).replaceWith(iframeTpl.replace(/{id}/ig, matchInner[1]));
                                return true;
                            }
                        });
                        var html = $(this).html();
                        html = html.replace(/\[youtube\.com\]|\[youtu\.be\]/g, "");
                        $(this).html(html);
                        var viewportAnchors = BBLog.cache("viewport.anchors") || [];
                        viewportAnchors.push($(this).find(".bblog-youtube-anchor"));
                        BBLog.cache("viewport.anchors", viewportAnchors);
                    });
                });
            break;
            case "bf3.assignments.bblog":
                if(BBLog.cache("mode") != "bf3" || !window.location.href.match(/\/assignments\//)) return this.callback();
                var e = $("#assignments-progress");
                if(!e.size() || BBLog.elementCheck(e, action)) return this.callback();
                 e.append('<li id="bblog-ass-link"><a href="#bblog-ass">Better Battlelog</a></li>');
                $(".assignments-container").append('<div class="assignments-group" id="bblog-ass"><h1>Better Battlelog</h1><div class="bblog-ass-info">'+BBLog.t("ass.info")+'</div><div class="assignments_list col-2"><input type="button" value="'+BBLog.t("ass.loadbtn")+'" class="bblog-button"/></div><div class="col-2 assignments_details"></div></div><div class="clear"></div>');
                $("#bblog-ass input").attr("data-tooltip", BBLog.t("ass.loadbtn.tooltip")).on("click", function(){
                    $("#bblog-ass, #bblog-ass-link").remove();
                    BBLog.handle("_bf3.assignments.bblog", data, callback);
                });

                // minimize buttons
                var btn = $('<div class="bblog-minimize">');
                btn.on("click", function(){
                    var id = "bf3.assignments.bblog.closed."+$(this).closest(".assignments-group").attr("id");
                    var val = BBLog.storage(id);
                    BBLog.storage(id, !val ? 1 : 0);
                    $(this).trigger("update");
                }).on("update", function(){
                    var id = "bf3.assignments.bblog.closed."+$(this).closest(".assignments-group").attr("id");
                    var val = BBLog.storage(id);
                    if(val){
                        $(this).addClass("plus");
                        $(this).closest(".assignments-group").addClass("hidden");
                    }else{
                        $(this).removeClass("plus");
                        $(this).closest(".assignments-group").removeClass("hidden");
                    }
                });
                $(".assignments-container .assignments-group > h1").prepend(btn.clone(true, true));
                $(".assignments-container .assignments-group > h1 .bblog-minimize").trigger("update");

            break;
            case "_bf3.assignments.bblog":
                var e = $("#assignments-progress");
                var tabUl  = $("#content ul.tabs:first");
                var dogtagsHref = tabUl.find(".dogtags a").attr("href");
                var userId = dogtagsHref.match(/\/dogtags\/([0-9]+)/)[1];
                var username = dogtagsHref.match(/([^\/]+)\/dogtags\//)[1];
                var deviceId = $(".profile-venicestats-header-soldier-info-type-game:first").attr("class").match(/common-game-([0-9]+)-([0-9])/)[2];
                var device = BBLog.deviceInfo[deviceId];
                var assignments = {
                    //0 : {x : 0, y : 0, ready : false},
                    //1 : {x : 1, y : 0, ready : false},
                    2 : {x : 2, y : 0, ready : false},
                    3 : {x : 3, y : 0, ready : false},
                    4 : {x : 4, y : 0, ready : false},
                    5 : {x : 0, y : 1, ready : false},
                    6 : {x : 1, y : 1, ready : false},
                    7 : {x : 2, y : 1, ready : false},
                    8 : {x : 3, y : 1, ready : false},
                    9 : {x : 4, y : 1, ready : false},
                    10 : {x : 0, y : 2, ready : false},
                    11 : {x : 1, y : 2, ready : false},
                    12 : {x : 2, y : 2, ready : false},
                    13 : {x : 3, y : 2, ready : false},
                    14 : {x : 4, y : 2, ready : false},
                    15 : {x : 0, y : 3, ready : false}
                };
                assignments[2].requirements = {0 : {need : 200, have : 0, perc : 0}};
                assignments[3].requirements = {0 : {need : 500, have : 0, perc : 0}};
                assignments[4].requirements = {0 : {need : 10000, have : 0, perc : 0}};
                assignments[5].requirements = {0 : {need : 5, have : 0, perc : 0}};
                assignments[6].requirements = {
                    0 : {need : 5, have : 0, perc : 0},
                    1 : {need : 5, have : 0, perc : 0}
                };
                assignments[7].requirements = {0 : {need : 4, have : 0, perc : 0}};
                assignments[8].requirements = {0 : {need : 6, have : 0, perc : 0}};
                assignments[9].requirements = {0 : {need : 60, have : 0, perc : 0}};
                assignments[10].requirements = {0 : {need : 5000, have : 0, perc : 0}};
                assignments[11].requirements = {0 : {need : 1000, have : 0, perc : 0}};
                assignments[12].requirements = {
                    0 : {need : 1, have : 0, perc : 0},
                    1 : {need : 1, have : 0, perc : 0},
                    2 : {need : 1, have : 0, perc : 0},
                    3 : {need : 1, have : 0, perc : 0},
                    4 : {need : 1, have : 0, perc : 0},
                    5 : {need : 1, have : 0, perc : 0},
                    6 : {need : 1, have : 0, perc : 0}
                };
                assignments[13].requirements = {
                    0 : {need : 100, have : 0, perc : 0},
                    1 : {need : 100, have : 0, perc : 0},
                    2 : {need : 100, have : 0, perc : 0},
                    3 : {need : 100, have : 0, perc : 0}
                };
                assignments[14].requirements = {
                    0 : {need : 250, have : 0, perc : 0},
                    1 : {need : 250, have : 0, perc : 0},
                    2 : {need : 250, have : 0, perc : 0},
                    3 : {need : 250, have : 0, perc : 0},
                    4 : {need : 250, have : 0, perc : 0}
                };
                assignments[15].requirements = {0 : {need : 20, have : 0, perc : 0}};
                // dogtags
                BBLog.handle("json.from.battlelog", {url : dogtagsHref, callback : function(data){
                    var statsPersonaId = data.context.statsPersona.userId;
                    var url = "/bf3/"+BBLog.cache("battlelog.language")+"soldier/dogtagsPopulateStats/"+username+"/"+userId+"/"+statsPersonaId+"/"+deviceId+"/0/";
                    BBLog.handle("json.from.battlelog", {"url" : url, callback : function(data){
                        assignments[2].requirements[0].have = data.data.seenDogTagsIndices.advanced.length + data.data.seenDogTagsIndices.basic.length;
                        assignments[2].ready = true;
                        $("#bblog-ass").trigger("update");
                    }});
                    var url = "/bf3/"+BBLog.cache("battlelog.language")+"coop/createBodyFetch/"+statsPersonaId+"/"+userId+"/";
                    BBLog.handle("json.from.battlelog", {"url" : url, callback : function(data){
                        assignments[8].requirements[0].have = BBLog.count(data.data.takenLevels);
                        assignments[8].ready = true;
                        $("#bblog-ass").trigger("update");
                    }});
                }});
                // weaponsPopulateStats
                var url = "/bf3/"+BBLog.cache("battlelog.language")+"weaponsPopulateStats/"+userId+"/"+deviceId+"/";
                BBLog.handle("json.from.battlelog", {"url" : url, callback : function(data){
                    for(var i in data.data.mainItemStats){
                        switch(data.data.mainItemStats[i].slug){
                            case "m67-grenade":
                                assignments[3].requirements[0].have = assignments[14].requirements[0].have = data.data.mainItemStats[i].performances[0].stat;
                            break;
                            case "eod-bot":
                                assignments[13].requirements[0].have = data.data.mainItemStats[i].performances[0].stat;
                            break;
                            case "repair-tool":
                                assignments[13].requirements[1].have = data.data.mainItemStats[i].performances[1].stat;
                            break;
                            case "m15-at-mine":
                                assignments[14].requirements[1].have = data.data.mainItemStats[i].performances[0].stat;
                            break;
                            case "c4-explosives":
                                assignments[14].requirements[2].have = data.data.mainItemStats[i].performances[0].stat;
                            break;
                            case "mav":
                                assignments[13].requirements[3].have = data.data.mainItemStats[i].performances[0].stat;
                            break;
                            case "m18-claymore":
                                assignments[14].requirements[3].have = data.data.mainItemStats[i].performances[0].stat;
                            break;
                            case "defibrillator":
                                assignments[13].requirements[2].have = data.data.mainItemStats[i].performances[0].stat;
                            break;
                            case "m224-mortar":
                                assignments[14].requirements[4].have = data.data.mainItemStats[i].performances[0].stat;
                            break;

                        }
                    }
                    var duplicated = {};
                    for(var i in data.data.mainWeaponStats){
                        var dup = data.data.mainWeaponStats[i].duplicateOf;
                        if(dup){
                            if(typeof duplicated[dup] == "undefined"){
                                duplicated[dup] = true;
                            }else{
                                continue;
                            }
                        }
                        if(data.data.mainWeaponStats[i].kills > 0) {
                            assignments[9].requirements[0].have++;
                        }
                        if(data.data.mainWeaponStats[i].slug == "acb-90" || data.data.mainWeaponStats[i].slug == "knife"){
                            assignments[11].requirements[0].have = data.data.mainWeaponStats[i].kills;
                        }
                    }
                    assignments[3].ready = true;
                    assignments[9].ready = true;
                    assignments[11].ready = true;
                    assignments[13].ready = true;
                    assignments[14].ready = true;
                    $("#bblog-ass").trigger("update");
                }});
                // vehiclePopulateStats
                var url = "/bf3/"+BBLog.cache("battlelog.language")+"vehiclesPopulateStats/"+userId+"/"+deviceId+"/";
                BBLog.handle("json.from.battlelog", {"url" : url, callback : function(data){
                    for(var i in data.data.mainVehicleStats){
                        if(data.data.mainVehicleStats[i].destroyXinY){
                            assignments[10].requirements[0].have += data.data.mainVehicleStats[i].destroyXinY;
                            assignments[10].ready = true;
                        }
                    }
                    assignments[10].ready = true;
                    $("#bblog-ass").trigger("update");
                }});
                // overviewPopulateStats
                var url = "/bf3/"+BBLog.cache("battlelog.language")+"overviewPopulateStats/"+userId+"/none/"+deviceId+"/";
                BBLog.handle("json.from.battlelog", {"url" : url, callback : function(data){
                    assignments[4].requirements[0].have = data.data.overviewStats.revives;
                    assignments[4].ready = true;
                    var maxStars = 0;
                    for(var i in data.data.overviewStats.serviceStars){
                        maxStars = Math.max(maxStars, data.data.overviewStats.serviceStars[i]);
                    }
                    assignments[5].requirements[0].have = maxStars;
                    assignments[5].ready = true;
                    $("#bblog-ass").trigger("update");
                }});
                var handleApiAssignmentCallback = function(data){
                    var valid = true;
                    if(!data || !data.assignments) valid = false;
                    if(valid && typeof data.assignments[6] != "undefined"){
                        assignments[6].requirements[0].have = data.assignments[6][0];
                        assignments[6].requirements[1].have = data.assignments[6][1];
                    }
                    if(valid && typeof data.assignments[7] != "undefined"){
                        assignments[7].requirements[0].have = data.assignments[7];
                    }
                    if(valid && typeof data.assignments[12] != "undefined"){
                        for(var i in data.assignments[12]) assignments[12]["requirements"][i].have = data.assignments[12][i];
                    }
                    if(valid && typeof data.assignments[15] != "undefined"){
                        assignments[15].requirements[0].have = data.assignments[15];
                    }
                    assignments[6].ready = true;
                    assignments[7].ready = true;
                    assignments[12].ready = true;
                    assignments[15].ready = true;
                    $("#bblog-ass").trigger("update");
                };
                // check new battlereports for the current logged in user
                if(userId == BBLog.cache("soldier.id")){
                    var url = "/bf3/"+BBLog.cache("battlelog.language")+"battlereport/loadLatestPlayerPreviews/5/";
                    BBLog.handle("json.from.battlelog", {"url" : url, callback : function(data){
                        var reportIds = {};
                        for(var i in data.data){
                            reportIds[data.data[i].reportId] = [data.data[i].reportId, data.data[i].platform, data.data[i].personaId];
                        }
                        $.getJSON(BBLog.serviceUrl+"/en/api/bf3.assignments.process?jsoncallback=?", {
                            username : BBLog.cache("soldier.name"),
                            userId : BBLog.cache("soldier.id"),
                            reportIds : reportIds,
                            version : BBLog.version,
                        }, handleApiAssignmentCallback);
                    }});
                }else{
                    $.getJSON(BBLog.serviceUrl+"/en/api/bf3.assignments.load?jsoncallback=?", {
                        username : username,
                        userId : userId
                    }, handleApiAssignmentCallback);
                }

                $("#assignments-progress").append('<li><a href="#bblog-ass" id="bblog-ass-link">Better Battlelog (<span id="bblog-sum-solved"></span>/<span id="bblog-sum-all"></span>)</a></li>');
                $(".assignments-container").append('<div class="assignments-group" id="bblog-ass"><h1>Better Battlelog</h1><div class="bblog-ass-info">'+BBLog.t("ass.info")+'</div><div class="assignments_list col-2"></div><div class="col-2 assignments_details"></div></div><div class="clear"></div>');

                var allAssCount = BBLog.count(assignments);
                $("#bblog-sum-all").text(allAssCount);

                // update for all loading indicators
                $("#bblog-ass").on("update", function(){
                    var solved = 0;
                    for(var i in assignments){
                        var d = assignments[i];
                        var assAllPerc = 0;
                        var assCount = 0;
                        var finished = true;
                        for(var r in d.requirements){
                            var req = d.requirements[r];
                            if(assignments[i].requirements[r].have > assignments[i].requirements[r].need){
                                assignments[i].requirements[r].have = assignments[i].requirements[r].need;
                            }else if(assignments[i].requirements[r].have < assignments[i].requirements[r].need){
                                finished = false;
                            }
                            if(req.have != 0 && req.perc == 0){
                                assignments[i].requirements[r].perc = Math.ceil((100 / req.need) * req.have);
                            }
                            assAllPerc += assignments[i].requirements[r].perc;
                            assCount++;
                        }
                        var w = (assAllPerc/assCount);
                        if(finished) {
                            $("#bblog-ass [data-id='"+i+"']").addClass("done");
                            solved++;
                        };
                        if(w > 99.4) w = 99.4;
                        $("#bblog-ass [data-id='"+i+"']").find(".loading").attr("style", "width:"+(w)+"%");
                    }
                    var w = $("#assignments-progress li:first").width();
                    var l = (100 / allAssCount) * solved;
                    l = 600 - (w * (l / 100));
                    $("#bblog-sum-solved").text(solved);
                    $("#bblog-ass-link").css("background-position", "-"+l+"px 0px");
                });

                var targetText = $(".assignment_content .container h4:first").text();
                var assTO = null;
                for(var id in assignments){
                    var data = assignments[id];
                    var x = data.x * 484 * -1;
                    var y = data.y * 121 * -1;
                    var title = BBLog.t("ass."+id+".title");
                    var info = BBLog.t("ass."+id+".info");
                    var bubble = '<b>'+title+'</b><br/>'+info;
                    var el = $('<div class="assignment"><div class="done"></div><div class="image"><div class="inner" style="background-position:'+(x * 0.4545)+'px '+(y * 0.4545)+'px;"></div></div><div class="loading"></div></div>').attr("data-tooltip", bubble).attr("data-id", id);
                    el.on("click", [data, x, y, title], function(ev){
                        clearTimeout(assTO);
                        $(this).closest(".assignments_list").find(".assignment").removeClass("active");
                        $(this).addClass("active");
                        $(this).trigger("update");
                    }).on("update", [data, x, y, title], function(ev){
                        var self = $(this);
                        var id = $(this).attr("data-id");
                        var evData = ev.data[0];
                        var html = $(
                            '<div class="assignment_content">'
                                + '<div class="image" style="background-position:'+(ev.data[1])+'px '+(ev.data[2])+'px;"></div>'
                                + '<div class="container"><h3>'+ev.data[3]+'</h3><h4>'+targetText+'</h4></div>'
                            + '</div>'
                        );
                        if(evData.ready == false){
                            html.find(".container").html(BBLog.t("ass.datanotready")+'<br/><br/><div class="bblog-loading"></div>');
                            assTO = setTimeout(function(){
                                if($("#bblog-ass").size()){
                                    self.trigger("update")
                                }
                            }, 300);
                        }else{
                            var div = $('<div class="requirements">');
                            for(var i in evData.requirements){
                                var d = evData.requirements[i];
                                var w = (d.perc / 100) * 460;
                                div.append('<div class="entry"><div class="indicator" style="width:'+w+'px;"></div><div class="value">'+(d.have)+' / '+(d.need)+'</div><div class="title">'+BBLog.t("ass."+id+".req."+i)+'</div></div>');
                            }
                            html.find(".container").append(div);
                        }
                        $("#bblog-ass .assignments_details").html(html);
                    });
                    $("#bblog-ass .assignments_list").append(el);
                }
                $("#bblog-ass .assignments_list .assignment:first").trigger("click");
                $("#bblog-ass").trigger("update");
            break;
            case "general.feed.boardurl.last":
                $(".feed-story-heading a[href*='threadview']").each(function(){
                    if(BBLog.elementCheck($(this), action)) return true;
                    $(this).attr("href", $(this).attr("href")+"last/");
                });
            break;
            case "board.gotolastpost":
                if(!window.location.href.match(/\/threadview\/(.*)\/last\/$/)) return this.callback();
                var e = $("div.forum-threadview-post:last");
                if(BBLog.elementCheck(e, action)) return this.callback();
                setTimeout(function(){
                    window.scrollTo(0, e.offset().top - 60);
                }, 150);
            break;
            case "board.copybreadcrumps":
                if(!window.location.href.match(/\/threadview\//)) return this.callback();
                var e = $("div.forum-breadcrumbs:first, ul.breadcrumb");
                if(BBLog.elementCheck(e, action)) return this.callback();
                var clone = e.clone();
                clone.css({
                    height: "20px",
                    paddingTop : "10px"
                });
                $("div.forum-start-border").after(clone);
            break;
            case "board.linksblank":
                if(!window.location.href.match(/\/threadview\//)) return this.callback();
                var all = $("div.forum-threadview-post-text");
                all.each(function(){
                    var e = $(this);
                    if(BBLog.elementCheck(e, action)) return true;
                    $(this).find("a").attr("target", "_blank");
                });
            break;
            case "bblog.mark.team":
                if(!BBLog.storage("init.data")) return this.callback();
                var d = BBLog.storage("init.data");
                if(window.location.href.match(/\/soldier\/.*?\//)){
                    var username = $.trim(window.location.href.match(/\/soldier\/(.*?)(\/|$)/)[1]);
                    var found = BBLog.searchInObject(d["team"], null, username);
                    var e = $(".profile-venicestats-header-soldier-info-type");
                    if(!BBLog.elementCheck(e, action) && e.size()){
                        if(found !== null){
                            e.prepend($('<span class="bblog-badge"></span>').attr("data-tooltip", BBLog.t("official.bblog.member")));
                        }
                    }
                    var e = $("#warsaw-stats ul.tag-icon-list");
                    if(!BBLog.elementCheck(e, action) && e.size()){
                        if(found !== null){
                            e.after($('<span class="bblog-badge"></span>').attr("data-tooltip", BBLog.t("official.bblog.member")));
                        }
                    }
                }
                if(window.location.href.match(/\/user\//)){
                    var username = $.trim(window.location.href.match(/\/user\/(.*?)(\/|$)/)[1]);
                    var found = BBLog.searchInObject(d["team"], null, username);
                    var e = $("#profile-information");
                    if(!BBLog.elementCheck(e, action) && e.size()){
                        if(found !== null){
                            e.find("ul:first").append($('<li class="bblog-badge"><span class="bblog-badge"></span></li>').attr("data-tooltip", BBLog.t("official.bblog.member")));
                        }
                    }
                    var e = $("#user span.real-name");
                    if(e.size() && !BBLog.elementCheck(e, action)){
                        if(found !== null){
                            e.prepend($('<span class="bblog-badge"></span>').attr("data-tooltip", BBLog.t("official.bblog.member")));
                        }
                    }else if(!e.size()){
                        var e = $("#user .information");
                        if(e.size() && !BBLog.elementCheck(e, action)){
                            if(found !== null){
                                e.prepend($('<span class="bblog-badge"></span>').attr("data-tooltip", BBLog.t("official.bblog.member")));
                            }
                        }
                    }
                }
                if(window.location.href.match(/forum\/threadview/)){
                    $(".forum-threadview-post-poster").each(function(){
                        if(BBLog.elementCheck($(this), action)) return true;
                        var username = $.trim($(this).find(".forum-threadview-post-poster-name").text());
                        if(BBLog.searchInObject(d["team"], null, username)){
                            $(this).find("ul.forum-threadview-post-tags").append($('<li class="bblog-badge"><span class="bblog-badge"></span></li>').attr("data-tooltip", BBLog.t("official.bblog.member")));
                        }
                    });
                }
            break;
            case "general.radar.soldier":
                var key = "radar.soldier";
                var storage = BBLog.combineArray([BBLog.storage(key), BBLog.cache(key)]);

                var e;
                // profile add radar
                if(window.location.href.match(/\/user\//)){
                    var appendFunc = function(ev){
                        var id = $(this).attr("data-id");
                        var storageInner = BBLog.storage(key) || [];
                        var found = BBLog.searchInObject(storageInner, "id", id, true);
                        if(found !== null){
                            delete storageInner[found];
                        }else{
                            storageInner.push({"id" : id, "name" : username, "source" : BBLog.cache("mode")});
                        }
                        BBLog.storage(key, storageInner);
                        $(this).remove();
                        ev.stopPropagation();
                        ev.preventDefault();
                    };

                    // bf4
                    e = $("#user .avatar-container a");
                    if(e.size() && !BBLog.elementCheck(e, action)){
                        var id = $("#soldiers .soldier-data-container").first().attr("id").split("-")[1];
                        var found = BBLog.searchInObject(storage, "id", id);
                        var t = found === null ? "radar.addsoldier" : "radar.removesoldier";
                        var username = $.trim($("#user .box.username .box.content span").first().text());
                        e.append($('<span class="bblog-button tiny '+(found ? 'active' : '')+'" data-id="'+id+'">'+BBLog.t(t)+'</span>').on("click", appendFunc));
                    }
                    // bf3, mohw
                    e = $("#profile-secondary-column .profile-avatar a");
                    if(e.size() && !BBLog.elementCheck(e, action)){
                        var id = $("#soldier-list li[data-id]").first().attr("data-id");
                        var found = BBLog.searchInObject(storage, "id", id);
                        var t = found === null ? "radar.addsoldier" : "radar.removesoldier";
                        var username = $.trim($("#profile-header .username h1").text());
                        e.append($('<span class="bblog-button tiny '+(found ? 'active' : '')+'" data-id="'+id+'">'+BBLog.t(t)+'</span>').on("click", appendFunc));
                    }
                }

                if(BBLog.count(storage)){
                    // mark on server browser
                    if(BBLog.cache("mode") == "bf4"){
                        e = $("#serverbrowser-results tr.active.server-row").first();
                        if(e.size() && !BBLog.elementCheck(e, action)){
                            // http://battlelog.battlefield.com/bf4/servers/show/pc/108fb82d-413f-4d1a-a1f0-54cc5e2ec484/2-UG-ZIPFELKLATSCHER-noobs-crossing-LOCKER-OFFICIAL/
                            var url = $("#serverbrowser-show footer a").attr("href");
                            BBLog.handle("json.from.battlelog", {"url" : url, cache : false, callback : function(data){
                                for(var i in data.context.players){
                                    var p = data.context.players[i];
                                    var id = p.personaId;
                                    var found = BBLog.searchInObject(storage, "id", id, true);
                                    if(found !== null){
                                        $("#serverbrowser-show").addClass("bblog-radar");
                                        $("#serverbrowser-show button.btn-primary").addClass("bblog-red").before('<div class="bblog-radar-warning">'+BBLog.t("user.onradar")+': <b>'+p.persona.personaName+'</b></div>');
                                        break;
                                    }
                                }
                            }});
                        }
                    }else if(BBLog.cache("mode") == "bf3" || BBLog.cache("mode") == "mohw"){
                        if(window.location.href.match(/servers\/(\?|$)/)){
                            $("#serverinfo-players-all-view:visible").trigger("click");
                            e = $("#serverinfo-players-all-wrapper:visible");
                            if(e.size() && e.find(".common-playername-personaname").size() && !BBLog.elementCheck(e, action)){
                                e.find(".common-playername-personaname a").each(function(){
                                    var id = $(this).attr("href").match(/\/([0-9]{5,})\//)[1];
                                    var found = BBLog.searchInObject(storage, "id", id, true);
                                    if(found !== null){
                                        $(this).closest(".serverguide-show-playerrow").addClass("bblog-radar");
                                        $("#serverguide-show-serverjoin").addClass("bblog-red").before('<div class="bblog-radar-warning">'+BBLog.t("user.onradar")+': <b>'+$(this).text()+'</b></div>');
                                    }
                                });
                            }
                        }
                    }
                    // mark on server page
                    if(window.location.href.match(/\/servers\/show/)){
                        var checkRadarSound = function(id){
                            if(!BBLog.storage("general.radar.soldier.sound")) return;
                            var uniqueEl = $("#server-players-list");
                            var userCache = uniqueEl.data("radar.user.cache") || {};
                            if(typeof userCache[id] == "undefined"){
                                userCache[id] = true;
                                uniqueEl.data("radar.user.cache", userCache);
                                BBLog.playAudio("radar-1.ogg", 60);
                            }
                        };
                        if(BBLog.cache("mode") == "bf4"){
                            $("#server-players-list tr[data-personaid]").each(function(){
                                if(BBLog.elementCheck($(this), action)) return;
                                var id = $(this).attr("data-personaid");
                                var found = BBLog.searchInObject(storage, "id", id, true);
                                if(found !== null){
                                    $("#server-page-join-buttons [data-track='serverbrowser.server.join']").addClass("bblog-red");
                                    $(this).addClass("bblog-radar").attr("data-tooltip", BBLog.t("user.onradar"));
                                    checkRadarSound(id);

                                }
                            });
                        }else if(BBLog.cache("mode") == "bf3" || BBLog.cache("mode") == "mohw"){
                            e = $("#serverguide-scoreboard ul.teams-list:visible");
                            if(e.size() && !BBLog.elementCheck(e, action)){
                                e.find(".player-name a").each(function(){
                                    var id = $(this).attr("href").match(/\/([0-9]{5,})\//)[1];
                                    var found = BBLog.searchInObject(storage, "id", id, true);
                                    if(found !== null){
                                        $(this).closest("tr").addClass("bblog-radar-tr");
                                        if(typeof userCache[id] == "undefined"){
                                            $("#server-header").addClass("haswarning");
                                            $("#serverguide-show-joinserver-form").addClass("bblog-red").append('<div class="bblog-radar-warning">'+BBLog.t("user.onradar")+': <b>'+$(this).text()+'</b></div>');
                                            checkRadarSound(id);
                                        }
                                    }
                                });
                            }
                        }
                    }
                    // mark on battlereport
                    if(window.location.href.match(/battlereport\/show\//)){
                        $("tr[data-personaid]").each(function(){
                            var found = BBLog.searchInObject(storage, "id", $(this).attr("data-personaid"), true);
                            if(found !== null){
                                $(this).addClass("bblog-radar").attr("data-tooltip", BBLog.t("user.onradar"));
                            }
                        });
                    }
                }
            break;
            case "general.radar.server":
                var key = "radar.server";
                var storage = BBLog.combineArray([BBLog.storage(key), BBLog.cache(key)]);
                // server add radar
                if(window.location.href.match(/\/servers\/show/)){
                    if(BBLog.cache("mode") == "bf4"){
                        var e = $("#server-page-gamemode");
                        if(!BBLog.elementCheck(e, action)){
                            var id = $("#server-page").attr("data-guid");
                            var found = BBLog.searchInObject(storage, "id", id);
                            if(found !== null){
                                $("#server-page-join-buttons").addClass("bblog-bf4-redbg").attr("data-tooltip", BBLog.t("server.onradar"));
                            }
                            var clone = e.clone(false,false).removeAttr("id");
                            clone.find('p').text('');
                            e.after(clone);
                            e = clone.find("p");
                        }
                    }else{
                        var e = $("#serverguide-middle .serverguide-button-actions-wrapper");
                        if(!BBLog.elementCheck(e, action)){
                            var id = $("#server-page").find("[data-guid]").first().attr("data-guid");
                            var found = BBLog.searchInObject(storage, "id", id);
                            if(found !== null){
                                $("#server-header").find("[data-guid]").first().attr("data-tooltip", ($("#server-header").find("[data-guid]").first().attr("data-tooltip") || "")+BBLog.t("server.onradar"));
                                $("#server-header").find("[data-guid]").first().addClass("bblog-red");
                            }
                        }
                    }

                    if(typeof found != "undefined"){
                        var t = found === null ? "radar.addserver" : "radar.removeserver";
                        e.append($('<span class="bblog-button '+(found ? 'active' : '')+'" data-id="'+id+'">'+BBLog.t(t)+'</span> ').on("click", function(){
                            var id = $(this).attr("data-id");
                            var storageInner = BBLog.storage(key) || [];
                            var found = BBLog.searchInObject(storageInner, "id", id, true);
                            if(found !== null){
                                delete storageInner[found];
                            }else{
                                storageInner.push({"id" : id, "name" : $.trim($("#server-header h1").text()), "source" : BBLog.cache("mode")});
                            }
                            BBLog.storage(key, storageInner);
                            $(this).remove();
                        }));
                    }

                }
                var e = $("#serverbrowser-filters, #serverguide-filtertoggle");
                // mark on server browser
                if(e.size()){
                    if(BBLog.cache("mode") == "bf4"){
                        $("#serverbrowser-show button.join, #serverbrowser-results tr[data-guid]").each(function(){
                            if(!BBLog.elementCheck($(this), action)){
                                var id = $(this).attr("data-guid");
                                var found = BBLog.searchInObject(storage, "id", id, true);
                                if(found !== null){
                                    $(this).addClass("bblog-bf4-redbg").attr("data-tooltip", BBLog.t("server.onradar"));
                                }
                            }
                        });
                    }else{
                        var e = $("#serverguide-show-joinserver-form");
                        if(!BBLog.elementCheck(e, action)){
                            var id = e.attr("guid");
                            var found = BBLog.searchInObject(storage, "id", id, true);
                            if(found !== null){
                                $(this).closest(".serverguide-show-playerrow").addClass("bblog-radar");
                                $("#serverguide-show-serverjoin").addClass("bblog-red").before('<div class="bblog-radar-warning">'+BBLog.t("server.onradar")+'</b></div>');
                            }
                        }
                        $("#serverguide-result [guid]").each(function(){
                            if(BBLog.elementCheck($(this), action)) return true;
                            var id = $(this).attr("guid");
                            var found = BBLog.searchInObject(storage, "id", id, true);
                            if(found !== null){
                                $(this).addClass("bblog-radar");
                            }
                        });
                    }
                }

            break;
            case "board.radar":
                var key = "radar.board";
                var storage = BBLog.combineArray([BBLog.storage(key), BBLog.cache(key)]);
                if(window.location.href.match(/forum\/threadview/)){
                    $(".forum-threadview-post").each(function(){
                        if(BBLog.elementCheck($(this), action)) return true;
                        var name = $.trim($(this).find(".forum-threadview-post-poster-name").text());
                        var found = BBLog.searchInObject(storage, "name", name, true);
                        if(found === null) return true;
                        var post = $(this);
                        post.addClass("bblog-flame-post-bg");
                        post.wrap('<div class="bblog-flame-post-hidden">');
                        var e = $('<div class="bblog-flame-post">').html(BBLog.t("board.radar.post"));
                        e.on("click", function(){
                            post.unwrap();
                            post.next(".bblog-flame-post").remove();
                        })
                        post.parent().after(e);
                    });
                }
                if(window.location.href.match(/forum\/view/)){
                    $(".forum-start-forum").each(function(){
                        if(BBLog.elementCheck($(this), action)) return true;
                        var name = $.trim($(this).find(".forum-start-forum-title-username:first a").text());
                        var found = BBLog.searchInObject(storage, "name", name, true);
                        if(found === null) return true;
                        var post = $(this);
                        post.addClass("bblog-flame-post-bg");
                        post.wrap('<div class="bblog-flame-post-hidden">');
                        var e = $('<div class="bblog-flame-post">').html(BBLog.t("board.radar.thread"));
                        e.on("click", function(){
                            post.unwrap();
                            post.next(".bblog-flame-post").remove();
                        })
                        post.parent().after(e);
                    });
                }
            break;
            case "general.contextmenu.serverbrowser":
                var e = $("#serverbrowser-filters, #serverguide-filtertoggle");
                if(!e.size()) return this.callback();
                $("#serverguide-result [guid], #serverbrowser-results tr[data-guid]").off("contextmenu.bblog").on("contextmenu.bblog", function(ev){
                    var id = $(this).attr("guid") ? $(this).attr("guid") : $(this).attr("data-guid");
                    var name = $.trim($(this).find("a.serverguide-cell-name-server-name").size() ? $(this).find("a.serverguide-cell-name-server-name").text() : $(this).find(".server-name").text());
                    var key = "radar.server";
                    var storage = BBLog.storage(key) || [];
                    var found = BBLog.searchInObject(storage, "id", id, true);
                    var t = found === null ? "radar.addserver" : "radar.removeserver";
                    $("#bblog-contextmenu").html(
                        $('<div>').text(BBLog.t(t)).on("click", function(){
                            if(found !== null){
                                delete storage[found];
                            }else{
                                storage.push({"id" : id, "name" : name, "source" : BBLog.cache("mode")});
                            }
                            BBLog.storage(key, storage);
                            $("#bblog-contextmenu").hide();
                        }
                    )).trigger("show", [ev]);
                    if(BBLog.customContextable()) ev.preventDefault();
                });
            break;
            case "general.contextmenu.serverpage":
                if(!window.location.href.match(/\/servers\/show\//)) return this.callback();
                $("#serverguide-scoreboard tr[data-personaid]").off("contextmenu.bblog").on("contextmenu.bblog", function(ev){
                    var id = $(this).attr("data-personaid");
                    var name = $.trim($(this).find(".player-name a").text());
                    var key = "radar.soldier";
                    var storage = BBLog.storage(key) || [];
                    var found = BBLog.searchInObject(storage, "id", id, true);
                    var t = found === null ? "radar.addsoldier" : "radar.removesoldier";
                    $("#bblog-contextmenu").html(
                        $('<div>').text(BBLog.t(t)).on("click", function(){
                            if(found !== null){
                                delete storage[found];
                            }else{
                                storage.push({"id" : id, "name" : name, "source" : BBLog.cache("mode")});
                            }
                            BBLog.storage(key, storage);
                            $("#bblog-contextmenu").hide();
                        }
                    )).trigger("show", [ev]);
                    if(BBLog.customContextable()) ev.preventDefault();
                });
            break;
            case "general.local.comments":
                var key = "general.local.comments.data";
                var localComment = $('<div class="bblog-local-comment">').append($('<textarea>').on("keydown blur", function(){
                    var storage = BBLog.storage(key) || {};
                    var data = $(this).parent().data("bblogdata");
                    if(typeof storage[data[1]] == "undefined") storage[data[1]] = {};
                    storage[data[1]][data[2]] = [$.trim(this.value), $.trim(data[5]), data[6], window.location.host];
                    BBLog.storage(key, storage);
                }).on("blur", function(){
                    if(this.value.length) {
                        $(this).height(BBLog.getTextareaHeight(this));
                    }else{
                        $(this).css("height", "").val(BBLog.t("local.comments.default")).one("focus", function(){
                            this.value = "";
                        });
                    }
                })).on("init", function(){
                    var storage = BBLog.storage(key) || {};
                    var data = $(this).data("bblogdata");
                    var value = "";
                    if(typeof storage[data[1]] != "undefined" && typeof storage[data[1]][data[2]] != "undefined" && storage[data[1]][data[2]][0].length) {
                        $(this).children().val(storage[data[1]][data[2]][0]).height(BBLog.getTextareaHeight($(this).children()));
                    }else{
                        $(this).children().val(BBLog.t("local.comments.default")).one("focus", function(){
                            this.value = "";
                        });
                    }
                });
                var elements = [];
                /**
                * Array format
                * 0 = The element to insert after/before
                * 1 = The element type
                * 2 = The ID
                * 3 = The insert Method
                * 4 = That class to to the element from the key=0
                * 5 = The server name, text to display in the overview list
                * 6 = The url to the server, without the host
                */


                // server
                var e;
                if(BBLog.cache("mode") == "bf4"){
                    e = $("#serverbrowser-show");
                    if(e.size() && !BBLog.elementCheck(e.find(".server-info"), action)){
                        elements.push([e.find(".quick-info").first(), 'server', e.find("[data-guid]").first().attr("data-guid"), "After", "", $("#results-container tr.server-row.active .server-name").text(), e.find("footer a").first().attr("href")]);
                    }
                    e = $("#server-page-gamemode");
                    if(e.size() && !BBLog.elementCheck(e, action)){
                        elements.push([e, 'server', $("#server-page").attr("data-guid"), "After", "", $("#server-page h1").first().text(), window.location.pathname]);
                    }
                }else{
                    e = $("#selected-server-name a");
                    if(e.size() && !BBLog.elementCheck(e, action)) elements.push([e.closest("h1"), 'server', e.attr("href").match(/\/show\/.*?\/(.*?)\//)[1], "After", "", e.text(), e.attr("href")]);
                    e = $("#serverguide-show-info #server-info");
                    if(e.size() && !BBLog.elementCheck(e, action)) elements.push([e, 'server', $("#server-page button[data-guid]").attr("data-guid"), "Before", "", $("#server-header h1").text(), window.location.pathname]);
                }

                // profile
                if(BBLog.cache("mode") == "bf4"){
                    e = $("#user .profile-overview .right-column .box").first();
                    if(e.size() && !BBLog.elementCheck(e, action)){
                        elements.push([e, 'profile', $("#user").attr("data-user-id"), "Before", "", $("#user .box.username span").first().text(), window.location.pathname]);
                    }
                    e = $("#warsaw-stats > .submenu").first();
                    if(e.size() && !BBLog.elementCheck(e, action)){
                        elements.push([e, 'profile', $("#warsaw-stats a.avatar").first().attr("rel"), "Before", "", $("#warsaw-stats-head .soldier-info-name").find("span").last().text(), $("#warsaw-stats-head a[data-track='soldier.profile']").attr("href")]);
                    }
                }else{
                    e = $("#profile-user #profile-main-column");
                    var username = $("#profile-header h1").clone().children().remove().end();
                    if(e.size() && !BBLog.elementCheck(e, action)) elements.push([e, 'profile', $("#profile-main-column").children(":first").attr("id").replace(/[^0-9]/g, ""), "Before", "", username.text(), $("#profile-header ul.tabs li:first a").attr("href")]);
                    e = $(".profile-venicestats-header-soldier:first").closest(".tabs-outer");
                    if(e.size() && !BBLog.elementCheck(e, action)) elements.push([e, 'profile', $(".base-avatar-container[rel]").attr("rel"), "After", 'stats', e.find(".profile-venicestats-header-soldier-info-name span").text(), e.find(".profile-venicestats-header-soldier-info-type a").attr("href")]);
                    e = $("#mohw-overview.profile-venicestats-overview-highlight").closest(".profile-mohw-stats");
                    if(e.size() && !BBLog.elementCheck(e, action)) elements.push([e, 'profile', $(".base-avatar-container[rel]").attr("rel"), "Before", 'stats', $(".profile-venicestats-header-soldier-info-name span").text(), $(".profile-venicestats-header-soldier-info-type a").attr("href")]);
                    e = $("#platoon-info").closest(".platoon-page-topright");
                }
                // platoon
                if(BBLog.cache("mode") == "bf4"){

                }else{
                    if(e.size() && !BBLog.elementCheck(e, action)) elements.push([e, 'platoon', window.location.pathname.match(/platoon(.*)/)[1].replace(/[^0-9]/g, ""), "After", "", e.find(".platoon-info-title").text(), $(".platoon-menu-main-navigation > div:first a").attr("href")]);

                }
                for(var i in elements){
                    var d = elements[i];
                    var c = localComment.clone(true, true);
                    if(d[4]) c.addClass(d[4]);
                    c["insert"+d[3]](d[0]).data("bblogdata", d).trigger("init");
                }
            break;
            case "general.focus.serverlist":
                var e = $("#serverbrowser-filters, #serverguide-filtertoggle");
                if(!e.size()) return this.callback();
                var e = $("#serverguide-list-outer-wrapper, #serverbrowser-results table");
                if(e.size() && BBLog.elementCheck(e, action)) return this.callback();
                window.scrollTo(0, e.offset().top - 100);
            break;
            case "general.removefriend":
                var e = $("#profile-header");
                if(e.size() && BBLog.elementCheck(e, action)) return this.callback();
                if(!e.find(".allow-add").size() && !$("#profile-status-message").hasClass("profile-your") && !e.find(".base-button-addfriend-wide").size()){
                    e.find(".interact").append($('<input class="base-button-addfriend-wide" type="button" value="'+BBLog.t("friend.remove")+'"/>').on("click", function(){
                        $(this).closest(".interact").remove();
                        var id = $("#profile-header div[rel*='reportProfileDropdown']").attr("rel").match(/reportProfileDropdown\/([0-9]+)/)[1];
                        var url = "/"+BBLog.cache("mode")+"/"+BBLog.cache("battlelog.language")+"friend/removeFriend/"+id+"/";
                        BBLog.handle("json.from.battlelog", {"url" : url, callback : function(data){}});
                    }).attr("data-tooltip", BBLog.t("friend.remove.tooltip")));
                }
            break;
            case "general.emblemeditor":
                if(typeof emblem == "undefined" || typeof emblem.emblem == "undefined" || typeof emblem.emblem.canvas == "undefined" || !$("#emblem-edit").size()) return this.callback();
                if(BBLog.elementCheck($("#emblem-edit"), action)) return this.callback();

                var showActiveOptions = function(){
                    if(emblem.emblem.canvas._activeObject){
                        var html = $('<div>');
                        html.append('<div><layer>Angle</layer><input type="text" data-key="angle" size="6"/></div>');
                        html.append('<div><layer>ScaleX</layer><input type="text" data-key="scaleX" size="6"/></div>');
                        html.append('<div><layer>ScaleY</layer><input type="text" data-key="scaleY" size="6"/></div>');
                        html.append('<div><layer>Top</layer><input type="text" data-key="top" size="6"/></div>');
                        html.append('<div><layer>Left</layer><input type="text" data-key="left" size="6"/></div>');
                        html.find("input").on("blur.bblogemblem update.bblogemblem", function(){
                            if(!emblem.emblem.canvas._activeObject) return true;
                            this.value = this.value.replace(/[\,]/ig, ".").replace(/[^0-9-\.]/ig, "");
                            var v = parseFloat(this.value);
                            var attr = $(this).attr("data-key");
                            var obj = emblem.emblem.canvas.getActiveObject();
                            switch(attr){
                                case "angle": obj.setAngle(v); break;
                                case "scaleX": obj.setScaleX(v); break;
                                case "scaleY": obj.setScaleY(v); break;
                                case "top": obj.setTop(v); break;
                                case "left": obj.setLeft(v); break;
                            }
                            obj.setCoords();
                            emblem.emblem.render();
                        }).on("keydown.bblogemblem click.bblogemblem", function(ev){
                            if(!emblem.emblem.canvas._activeObject) return true;
                            if(ev.keyCode && ev.keyCode == 13){
                                $(this).trigger("update.bblogemblem");
                            }
                            if(ev.keyCode && ev.keyCode == 27) {
                                emblem.emblem.canvas.deactivateAllWithDispatch();
                                $("#emblem-edit-object-opacity:first").trigger("change");
                                $("#bblog-emblem-options").hide();
                                return;
                            }
                            ev.stopPropagation();
                        }).on("init.bblogemblem focus.bblogemblem", function(ev){
                            if(!emblem.emblem.canvas._activeObject) return true;
                            var attr = $(this).attr("data-key");
                            this.value = emblem.emblem.canvas._activeObject[attr];
                        }).trigger("init.bblogemblem");
                        $("#bblog-emblem-options").show().find(".box-content").html(html);
                    }else{
                        $("#bblog-emblem-options").hide();
                    }
                };

                $("#emblem-edit .emblem-layer-options").after(
                    $('<div class="box-content bblog-emblem-info">')
                    .html(BBLog.t("general.emblemeditor.text").replace(/\n/ig, "<br/>")+"<br/><br/>")
                    .append('<input type="file" accept="image/*" id="bblog-emblem-file"/>').on("change", function(ev){
                        var reader = new FileReader();
                        reader.onload = (function(theFile) {
                            return function(e) {
                                if(!$("#bblog-canvas-container").length) $("#emblem-canvas").before('<div id="bblog-canvas-container">');
                                $("#bblog-canvas-container").css("background-image", "url('"+e.target.result+"')");
                                $("#bblog-emblem-file").trigger("blur");
                                $("#emblem-canvas").css("opacity", 0.5);
                            };
                        })(f);
                        reader.readAsDataURL(ev.target.files[0]);
                    })
                );

                $("header.layers-count").parent().before('<div class="box" id="bblog-emblem-options"><header><h1>'+BBLog.t("general.emblemeditor.ld.title")+'</h1></header><div class="box-content"></div></div>');
                $(document).off("click.bblogemblem").on("click.bblogemblem", showActiveOptions);
                $(document).off("keydown.bblogemblem").on("keydown.bblogemblem", function(ev){
                    if(!$(ev.srcElement || ev.target).is("body")) return true;
                    showActiveOptions();
                    var e = emblem.emblem.canvas.getActiveObject();
                    var imageLayer = $("#bblog-canvas-container");
                    if(imageLayer.length){
                        var o = parseFloat(imageLayer.css("opacity"));
                        switch(ev.keyCode){
                            case 65:
                                o -= 0.1;
                            break;
                            case 68:
                                o += 0.1;
                            break;
                        }
                        o = Math.min(1, Math.max(0, o));
                        imageLayer.css("opacity", o);
                        $("#emblem-canvas").css("opacity", 1-o);
                    }
                    if(e){
                        var change = false;
                        if(ev.keyCode == 32) {
                            change = true;
                            if(e._oldValues){
                                for(var i in e._oldValues){
                                    e[i] = e._oldValues[i];
                                }
                                e._oldValues = false;
                            }else{
                                e._oldValues = {};
                                var values = {cornerSize : 0, hasControls : false, hasBorders : true, hasRotatingPoint:false, transparentCorners: true};
                                for(var i in values){
                                    e._oldValues[i] = e[i];
                                    e[i] = values[i];
                                }
                            }
                            change = true;
                        }else if(ev.keyCode == 27) {
                            change = true;
                            emblem.emblem.canvas.deactivateAllWithDispatch();
                        }else if(ev.ctrlKey && (ev.keyCode == 39 || ev.keyCode == 37)) {
                            e.angle += ev.keyCode == 39 ? 1 : -1;
                            if(e.angle > 359) e.angle = 0;
                            if(e.angle < 0) e.angle = 359;
                            change = true;
                        }
                        if(change){
                            e.setCoords();
                            emblem.emblem.render();
                            ev.preventDefault();
                            ev.stopPropagation();
                        }
                    }
                    showActiveOptions();
                });
            break;
            case "bf3.contextmenu.report":
                if(!window.location.href.match(/battlereport\/show/)) return this.callback();
                var e = $("#battlereport-teamstats");
                if(BBLog.elementCheck(e, action)) return this.callback();
                $("tr[data-personaid]").off("contextmenu.bblog").on("contextmenu.bblog", function(ev){
                    var id = $(this).attr("data-personaid");
                    var name = $.trim($(this).find(".common-playername-personaname-nolink").text());
                    var key = "radar.soldier";
                    var storage = BBLog.storage(key) || [];
                    var found = BBLog.searchInObject(storage, "id", id, true);
                    var t = found === null ? "radar.addsoldier" : "radar.removesoldier";
                    $("#bblog-contextmenu").html(
                        $('<div>').text(BBLog.t(t)).on("click", function(){
                            if(found !== null){
                                delete storage[found];
                            }else{
                                storage.push({"id" : id, "name" : name, "source" : BBLog.cache("mode")});
                            }
                            BBLog.storage(key, storage);
                            $("#bblog-contextmenu").hide();
                        }
                    )).trigger("show", [ev]);
                    if(BBLog.customContextable()) ev.preventDefault();
                });
            break;
            case "board.contextmenu.quote":
                if(!window.location.href.match(/forum\/threadview/)) return this.callback();
                var e = $("form.forum-ajax-post");
                if(!e.size() || BBLog.elementCheck(e, action)) return this.callback();
                $(".forum-threadview-post-text").off("contextmenu.bblog").on("contextmenu.bblog", function(ev){
                    var selection = BBLog.getSelection(this);
                    if(selection){
                        $("#bblog-contextmenu").html(
                            $('<div>').text(BBLog.t("contextmenu.quote")).on("click", function(){
                                e.find("textarea").trigger("focus").append('\n[quote]'+selection+'[/quote]');
                                window.scrollTo(0, e.offset().top);
                                $("#bblog-contextmenu").hide();
                            }
                        )).trigger("show", [ev]);
                        if(BBLog.customContextable()) ev.preventDefault();
                    }
                });
            break;
            case "board.contextmenu.radar":
                if(!window.location.href.match(/forum\/threadview/)) return this.callback();
                var key = "radar.board";
                $(".forum-threadview-post-poster-name").off("contextmenu.bblog").on("contextmenu.bblog", function(ev){
                    var name = $.trim($(this).text());
                    var storage = BBLog.storage(key) || [];
                    var found = BBLog.searchInObject(storage, "name", name, true);
                    var t = found === null ? "radar.addboarduser" : "radar.removeboarduser";
                    $("#bblog-contextmenu").html(
                        $('<div>').text(BBLog.t(t)).on("click", function(){
                            if(found !== null){
                                delete storage[found];
                            }else{
                                storage.push({"name" : name, "source" : BBLog.cache("mode")});
                            }
                            BBLog.storage(key, storage);
                            $("#bblog-contextmenu").hide();
                        }
                    )).trigger("show", [ev]);
                    if(BBLog.customContextable()) ev.preventDefault();
                });
            break;
            case "board.favthreads.add":
                var isActive = BBLog.storage("board.favthreads.add");
                var match = window.location.href.match(/\/threadview\/([0-9]+)\//i);
                if(!match || !isActive) return this.callback();
                var threadId = match[1];
                var e = $("div.common-box-title-clean:first");
                if(BBLog.elementCheck(e, action)) return this.callback();
                var storage = BBLog.storage("board.favthreads") || [];
                var insHtml = $('<div class="bblog-favthread-button"><input type="button" value="'+BBLog.t('favThreads.addbtn')+'" class="bblog-button orange fav"/><span class="bblog-totop">&nbsp;<input type="button" value="'+BBLog.t('goto.top')+'" class="bblog-button orange"/></span></div>');
                var clone = insHtml.clone();
                clone.find(".bblog-totop").remove();
                e.after(insHtml.clone()).before(clone);
                var el = $(e.prev()).add(e.next());
                el.find("input.fav").on("click", function(){
                    storage.push({id : threadId, "title" : $("div.forum-start-title:first h1:first").text(), "source" : BBLog.cache("mode")});
                    BBLog.storage("board.favthreads", storage);
                    el.find("input.fav").remove();
                });
                el.find(".bblog-totop input").on("click", function(){
                    window.scrollTo(0,0);
                });
                var found = BBLog.searchInObject(storage, "id", threadId, true);
                if(found !== null) el.find("input.fav").remove();

                // bind the post submit input
                $("input[type='submit'].common-replyform-form-submit").on("click", function(){
                    if(BBLog.storage("board.favthreads.autoadd")){
                        el.find("input").trigger("click");
                    }
                });
            break;
            case "board.gototop":
                if(!window.location.href.match(/\/threadview\/([0-9]+)\//i)) return this.callback();
                BBLog.handle("board.favthreads.add", null, function(){
                    var e = $("div.common-box-title-clean:first");
                    if(BBLog.elementCheck(e, action)) return true;
                    if(!$(".bblog-totop").size()){
                        var insHtml = $('<div class="bblog-favthread-button"><span class="bblog-totop">&nbsp;<input type="button" value="'+BBLog.t('goto.top')+'" class="bblog-button orange"/></span></div>');
                        insHtml.find(".bblog-totop input").on("click", function(){
                            window.scrollTo(0,0);
                        });
                        e.after(insHtml);
                    }
                    $(".bblog-totop").show();
                });
            break;
            case "board.signature":
                var signature = BBLog.storage("board.signature.text");
                if(!window.location.href.match(/\/(threadview|newthread)\/([0-9]+)\//i) || !signature || !signature.length) return this.callback();
                $("input[type='submit'].common-replyform-form-submit, td.forum-newthread-submit-cell input[type='submit']").each(function(){
                    if(BBLog.elementCheck($(this), action)) return true;
                    $(this).after($('<span class="bblog-append-signature"><input type="checkbox" checked="checked" id="bblog-append-sig"/> '+BBLog.t("add.signature")+'</span>').attr("data-tooltip", BBLog.t("add.signature.bubble")));
                    $(this).on("click", function(e){
                        if($(this).data("signature-added") || !$("#bblog-append-sig:checked").size()) return;
                        $(this).data("signature-added", 1);
                        var area = $(this).prev("textarea").add($("#forum-newthread-body"));
                        var val = area.val();
                        val = $.trim(val) + "\n\n"+signature;
                        area.val(val);
                    });
                });
            break;
            case "bf3.stats.bf3stats":
                if(BBLog.cache("mode") != "bf3" || !window.location.href.match(/\/soldier\//)) return this.callback();
                var e = $(".profile-venicestats-overview-boxwideclean:last");
                if(!e.size() || BBLog.elementCheck(e, action)) return this.callback();
                var platform = BBLog.deviceInfo[$(".profile-venicestats-header-soldier-info-type-game").attr("class").match(/common-game-[0-9]-([0-9])/)[1]];
                platform = platform == "xbox" ? "360" : platform;
                var time = $(".profile-venicestats-overview-highlight-stat-value").text();
                var timePlayed = 0;
                var minutes = time.match(/([0-9]+)m+/i);
                var hours = time.match(/([0-9]+)h+/i);
                var username = window.location.href.match(/\/soldier\/(.*?)\//)[1];
                if(hours) timePlayed += parseInt(hours[1]) * 3600;
                if(minutes) timePlayed += parseInt(minutes[1]) * 60;
                var url = 'http://bf3stats.com/stats_'+platform+'/'+username+'/battlelog_frame?timePlayed='+timePlayed;
                if(BBLog.cache("theme.url")) url += "&cssfile="+encodeURIComponent(BBLog.cache("theme.url"));
                var c = e.clone();
                c.removeClass("profile-venicestats-overview-boxwideclean");
                c.find(".common-box-title").text(BBLog.t("bf3stats.overview")+" bf3stats.com");
                c.find(".common-box-inner").html('<div style="padding-top:10px;"></div><iframe src="'+url+'" style="width:100%; height:600px; overflow-x:hidden; overflow-y:hidden; border:0px; margin:0px; padding:0px;" scrollbars="no"></iframe>');
                e.after(c);
                e.css("margin-bottom", "10px");
            break;
            case "bf4.stats.bf4stats":
                if(BBLog.cache("mode") != "bf4" || !window.location.href.match(/\/soldier\/.*?\/stats\//)) return this.callback();
                var e = $("#overview-completion");
                if(!e.size() || BBLog.elementCheck(e, action)) return this.callback();
                var platform = $("#warsaw-stats-head i.icon-platform").clone().removeClass("icon-platform inverted").attr("class");
                if(typeof BBLog.deviceInfo[platform] != "undefined" && isNaN(BBLog.deviceInfo[platform])) platform = BBLog.deviceInfo[platform];
                var time = $("#stat-time-played").text();
                var timePlayed = 0;
                var minutes = time.match(/([0-9]+)m+/i);
                var hours = time.match(/([0-9]+)h+/i);
                var username = window.location.href.match(/\/soldier\/(.*?)\//)[1];
                if(hours) timePlayed += parseInt(hours[1]) * 3600;
                if(minutes) timePlayed += parseInt(minutes[1]) * 60;
                var url = 'http://bf4stats.com/'+platform+'/'+username+'/bblogframe?timePlayed='+timePlayed;
                if(BBLog.cache("theme.url")) url += "&cssfile="+encodeURIComponent(BBLog.cache("theme.url"));
                var c = e.clone();
                c.removeAttr("id");
                c.css("margin-top", "10px");
                c.find("h1").text(BBLog.t("bf3stats.overview")+" bf4stats.com");
                c.find(".box-content").html('<div></div><iframe src="'+url+'" style="width:100%; height:400px; overflow-x:hidden; overflow-y:auto; border:0px; margin:0px; padding:0px;" scrollbars="auto"></iframe>');
                e.after(c);
            break;
            case "mohw.stats.mohwstats":
                // http://mohwstats.com/stats_pc/LOLN1/battlelog_frame
                if(BBLog.cache("mode") != "mohw" || !window.location.href.match(/\/soldier\//)) return this.callback();
                var e = $("#mohw-overview.profile-venicestats-overview-highlight");
                if(!e.size() || BBLog.elementCheck(e, action)) return this.callback();
                var platform = BBLog.deviceInfo[$(".profile-venicestats-header-soldier-info-type-game").attr("class").match(/common-game-([0-9]+)-([0-9])/)[2]];
                platform = platform == "xbox" ? "360" : platform;
                var time = $("#overview-numbers li:eq(1) p").text();
                var timePlayed = 0;
                var minutes = time.match(/([0-9]+)m+/i);
                var hours = time.match(/([0-9]+)h+/i);
                var username = window.location.href.match(/\/soldier\/(.*?)\//)[1];
                if(hours) timePlayed += parseInt(hours[1]) * 3600;
                if(minutes) timePlayed += parseInt(minutes[1]) * 60;
                var url = 'http://mohwstats.com/stats_'+platform+'/'+username+'/battlelog_frame?timePlayed='+timePlayed;
                if(BBLog.cache("theme.url")) url += "&cssfile="+encodeURIComponent(BBLog.cache("theme.url"));
                var c = e.children("div:last").clone();
                c.attr("id", "mohw-overview-mohwstats");
                c.html('<div class="common-box"><h3>'+BBLog.t("bf3stats.overview")+" mohwstats.com"+'</h3><div class="common-box-content"><iframe src="'+url+'" style="width:100%; height:600px; overflow-x:hidden; overflow-y:hidden; border:0px; margin:0px; padding:0px;" scrollbars="no"></iframe></div></div>');
                e.children("div:last").after(c);
            break;
            case "_bf3.vehicle.weapons.textfilter":
                var tables = $("#profile-stats-weapons-main-column table.statisticstable");
                $(".profile-stats-type-container-filters:first").after('<div class="base-clear">');
                var table = tables.filter(":eq(0)");
                table.before('<div class="bblog-textual-filter" id="bblog-textual-filter">');
                var textfield = $('<span>'+BBLog.t("textfilter")+'</span><input type="text" value=""/>').attr("data-tooltip", BBLog.t("textfilter.weapon.bubble").replace(/\\n/g, "\n"));
                var items = tables.find("td.item-name p");
                textfield.val(BBLog.storage(action+data.type) || "");
                textfield.on("keyup blur focus", [items], function(ev){
                    BBLog.storage(action+data.type, $(this).val());
                    var val = $(this).val().replace(/[^0-9a-zA-Z,]/g, "").toLowerCase();
                    var vals = val.split(",");
                    if(!val.length){
                        $(".profile-stats-type-container-filters .last div").trigger("click");
                        return false;
                    }else{
                        $(".profile-stats-type-container-filters .selected").removeClass("selected");
                        ev.data[0].each(function(){
                            var text = $(this).text().replace(/[^0-9a-zA-Z,\ä\ü\ö\Ö\Ü\Ä]/g, "").toLowerCase();
                            for(var i in vals){
                                if(text.match(vals[i])){
                                    $(this).closest("tr").show();
                                    return true;
                                }
                            }
                            $(this).closest("tr").hide();
                        });
                    }
                }).triggerHandler("keyup");
                $("#bblog-textual-filter").append(textfield);
            break;
            case "bf4.vehicle.list.bf4stats":
                if(BBLog.cache("mode") != "bf4" || !window.location.href.match(/\/soldier\/.*?\/vehicles\//)) return this.callback();
                var e = $("#vehicle-list");
                if(!e.size()) return this.callback();
                var username = window.location.href.match(/\/soldier\/(.*?)\//)[1];
                var platform = $("#warsaw-stats-head i.icon-platform").clone().removeClass("icon-platform inverted").attr("class");
                if(typeof BBLog.deviceInfo[platform] != "undefined" && isNaN(BBLog.deviceInfo[platform])) platform = BBLog.deviceInfo[platform];
                var cacheKey = "bf4stats.rank."+platform+"-"+username;
                if(!BBLog.cache(cacheKey)){
                    $._get("http://api.bf4stats.com/api/playerRankings?plat="+platform+"&name="+username+"&output=json", function(data){
                        BBLog.cache(cacheKey, data);
                        BBLog.handle(action);
                    });
                }else{
                    var data = BBLog.cache(cacheKey);
                    if(data && data.rankings){
                        for (var i in Surface.Renderer.state.surface["vehicle-details"].category.vehicles){
                            var v = Surface.Renderer.state.surface["vehicle-details"].category.vehicles[i];
                            for(var i in data.rankings){
                                var r = data.rankings[i];
                                if(r.group == "vehicle" && r.ident == v.slug && r.rank && r.count){
                                    var top = Math.ceil(r.rank/r.count*100)+'%';
                                    e = $("#vehicle-details").find("li[data-guid='"+v.guid+"']").not(".bblog-bf4stats");
                                    if(e.size()){
                                        e.addClass("bblog-bf4stats");
                                        e.children().first().after($('<span class="bblog-bf4stats-rank" onclick="window.open(\''+r.url+'&ref=bblog\'); return false;">Top '+top+'</span>').attr("data-tooltip", BBLog.t("bf3stats.top.bubble").replace(/\{place\}/, r.rank).replace(/\{all\}/, r.count)+'<br/>by bf4stats.com'))
                                    }

                                }
                            }
                        }
                    }
                }
            break;
            case "bf4.weapons.list.bf4stats":
                if(BBLog.cache("mode") != "bf4" || !window.location.href.match(/\/soldier\/.*?\/weapons\//)) return this.callback();
                var e = $("#weapon-list");
                if(!e.size()) return this.callback();
                var username = window.location.href.match(/\/soldier\/(.*?)\//)[1];
                var platform = $("#warsaw-stats-head i.icon-platform").clone().removeClass("icon-platform inverted").attr("class");
                if(typeof BBLog.deviceInfo[platform] != "undefined" && isNaN(BBLog.deviceInfo[platform])) platform = BBLog.deviceInfo[platform];
                var cacheKey = "bf4stats.rank."+platform+"-"+username;
                if(!BBLog.cache(cacheKey)){
                    $._get("http://api.bf4stats.com/api/playerRankings?plat="+platform+"&name="+username+"&output=json", function(data){
                        BBLog.cache(cacheKey, data);
                        BBLog.handle(action);
                    });
                }else{
                    var data = BBLog.cache(cacheKey);
                    if(data && data.rankings){
                        e.find("tr[data-slug]").not(".bblog-bf4stats").each(function(){
                            $(this).addClass("bblog-bf4stats");
                            for(var i in data.rankings){
                                var r = data.rankings[i];
                                if(r.group == "weapon" && r.ident == $(this).attr("data-slug") && r.rank && r.count){
                                    var top = Math.ceil(r.rank/r.count*100)+'%';
                                    $(this).find("td.item-kills").prepend($('<span class="bblog-bf4stats-rank" onclick="window.open(\''+r.url+'&ref=bblog\'); return false;">Top '+top+'</span>').attr("data-tooltip", BBLog.t("bf3stats.top.bubble").replace(/\{place\}/, r.rank).replace(/\{all\}/, r.count)+'<br/>by bf4stats.com'))
                                }
                            }
                        });
                    }
                }
            break;
            case "bf3.weapons.list.bf3stats":
                if(BBLog.cache("mode") != "bf3") return this.callback();
                var e = $("#profile-stats-weapons-statistics");
                if(!e.size() || BBLog.elementCheck(e, action)) return this.callback();
                var soldierInfo = $("div.profile-venicestats-header-soldier-info:first");
                var soldier = soldierInfo.find(".profile-venicestats-header-soldier-info-name span").text();
                var d = {"player" : decodeURIComponent(soldier), "opt" : "clear,ranking,weapons,weaponsRanking"};
                var platform = soldierInfo.find(".profile-venicestats-header-soldier-info-type-game").attr("class").match(/common-game-[0-9]-([0-9]+).*/i)[1];
                platform = BBLog.deviceInfo[parseInt(platform)];
                if(platform == "xbox") platform = "360";
                $._post("http://api.bf3stats.com/"+platform+"/player/", d, function(data){
                    var entries = e.find("tr.filterByKit");
                    data = JSON.parse(data);
                    entries.each(function(){
                        var weapon = $(this).find("a:first").attr("href").match(/iteminfo\/(.*?)\//)[1];
                        var bf3Weapon = BBLog.getBf3StatsMapName(weapon);
                        if(bf3Weapon && typeof data["stats"]["weapons"][bf3Weapon] != "undefined" && typeof data["stats"]["weapons"][bf3Weapon]["c"] != "undefined"){
                            var wd = data["stats"]["weapons"][bf3Weapon];
                            var perc = Math.ceil((wd.r / wd.c) * 100);
                            var startR = Math.ceil(wd.r/100) * 100;
                            var el = $('<div class="bf3stats-top disabled"><span class="profile-select-view-image stats"></span>Top '+perc+'%</div>');
                            el.attr("data-tooltip", '<span class="bblog-tt-top-bf3stats">'+BBLog.t("bf3stats.top.bubble").replace(/\{place\}/, wd.r).replace(/\{all\}/, wd.c)+'<br/>by bf3stats.com</span>');
                            $(this).find(".item-kills .item-object").prepend(el);
                        }
                    });
                });
            break;
            case "bf3.vehicle.list.bf3stats":
                var match = window.location.href.match(/soldier\/(.*?)\/vehicles\/([0-9]+)\//);
                if(BBLog.cache("mode") != "bf3" || !match) return this.callback();
                var e = $("#profile-stats-vehicle-statistics");
                if(!e.size() || BBLog.elementCheck(e, action)) return this.callback();
                var soldierInfo = $("div.profile-venicestats-header-soldier-info:first");
                var soldier = soldierInfo.find(".profile-venicestats-header-soldier-info-name span").text();
                var d = {"player" : decodeURIComponent(soldier), "opt" : "clear,ranking,vehicles,vehiclesRanking"};
                var platform = soldierInfo.find(".profile-venicestats-header-soldier-info-type-game").attr("class").match(/common-game-[0-9]-([0-9]+).*/i)[1];
                platform = BBLog.deviceInfo[parseInt(platform)];
                $._post("http://api.bf3stats.com/"+platform+"/player/", d, function(data){
                    var entries = e.find("#statisticstable tbody tr");
                    data = JSON.parse(data);
                    entries.each(function(){
                        var weapon = $(this).find("a:first").attr("href").match(/iteminfo\/(.*?)\//)[1];
                        var bf3Weapon = BBLog.getBf3StatsMapName(weapon);
                        if(bf3Weapon && typeof data["stats"]["vehicles"][bf3Weapon] != "undefined" && typeof data["stats"]["vehicles"][bf3Weapon]["c"] != "undefined"){
                            var wd = data["stats"]["vehicles"][bf3Weapon];
                            var perc = Math.ceil((wd.r / wd.c) * 100);
                            var startR = Math.ceil(wd.r/100) * 100;
                            var el = $('<div class="bf3stats-top disabled"><span class="profile-select-view-image stats"></span>Top '+perc+'%</div>');
                            el.attr("data-tooltip", BBLog.t("bf3stats.top.bubble").replace(/\{place\}/, wd.r).replace(/\{all\}/, wd.c)+'<br/><span class="small-bubble">by bf3stats.com</span>');
                            $(this).find(".item-kills .item-object").prepend(el);
                        }
                    });
                });
            break;
            case "bf3.weapons.list.filters":
                var match = window.location.href.match(/soldier\/(.*?)\/weapons\/([0-9]+)\//);
                if(BBLog.cache("mode") != "bf3" || !match) return this.callback();
                var e = $("#profile-stats-weapons-main-column .profile-stats-type-container-filters:first ul:first");
                if(!e.size() || BBLog.elementCheck(e, action)) return this.callback();
                var l = e.find(".last");
                l.before('<li><div class="kit-all" data-extrafilter="pdw" data-tooltip="Personal Defence Weapons"><p>PDW</p></div></li>');
                l.before('<li><div class="kit-all" data-extrafilter="pist" data-tooltip="Pistols"><p>PIST</p></div></li>');
                l.before('<li><div class="kit-all" data-extrafilter="shotgun" data-tooltip="Shotguns"><p>SGUN</p></div></li>');
                e.find("[data-extrafilter]").on("click", function(){
                    var type = $(this).attr("data-extrafilter");
                    var extraFilter = {
                        "pist" : BBLogWeapons["weapon-groups"]["pistols"],
                        "shotgun" : BBLogWeapons["weapon-groups"]["shotguns"],
                        "pdw" : BBLogWeapons["weapon-groups"]["pdw"],
                    };
                    var data = extraFilter[type];
                    var items = $("#profile-stats-weapons-main-column table.statisticstable td.item-name a");
                    items.closest("tr").hide();
                    items.each(function(){
                        for(var i in data){
                            var r = new RegExp("/"+data[i]+"/", "i");
                            if(r.test($(this).attr("href"))){
                                $(this).closest("tr").show();
                            }
                        }
                    });
                });
                BBLog.handle("_bf3.vehicle.weapons.textfilter", {type : "weapon"});
            break;
            case "bf3.weapons.list.extradata":
                var match = window.location.href.match(/soldier\/(.*?)\/weapons\/([0-9]+)\//);
                if(BBLog.cache("mode") != "bf3" || !match) return this.callback();
                var e = $("#profile-stats-weapons-main-column");
                if(!e.size() || BBLog.elementCheck(e, action)) return this.callback();
                var device = $(".profile-venicestats-header-soldier-info-type-game:first").attr("class").match(/common-game-([0-9]+)-([0-9])/)[2];
                BBLog.handle("json.from.battlelog", {url : "/bf3/"+BBLog.cache("battlelog.language")+"weaponsPopulateStats/"+match[2]+"/"+device+"/", callback : function(data){
                    // shots and HS rate
                    var items = $("#profile-stats-weapons-main-column table.statisticstable:first td.item-name a");
                    for(var i in data.data.mainWeaponStats){
                        var weapon = data.data.mainWeaponStats[i];
                        var weaponTr = items.filter("[href*='iteminfo/"+weapon.slug+"/']").closest("tr");
                        if(weaponTr.size()){
                            var td = weaponTr.find("td.last").prev();
                            td.find(".item-object").addClass("bblog-shots-position");
                            var hsRate = ((100 / weapon.kills) * weapon.headshots).toFixed(2).toString();
                            hsRate = hsRate == "NaN" ? "0" : hsRate;
                            var html = $(
                                '<div class="bblog-shots">'
                                + '<div class="shots"><span></span> '+weapon.shotsFired+' / '+weapon.shotsHit+'</div>'
                                + '<div class="hs"><span></span> '+weapon.headshots+' ('+hsRate+'%)</div>'
                                + '</div>'
                            );
                            html.find(".shots").attr("data-tooltip", BBLog.t("weaponlist.shots"));
                            html.find(".hs").attr("data-tooltip", BBLog.t("weaponlist.hs"));
                            td.find(".item-object").append(html);
                        }
                    }
                    // kills to progress bar
                    var items = $("td.item-servicestars");
                    items.each(function(){
                        var kills = $(this).next().find(".item-object").clone();
                        kills.children(":not(:text)").remove();
                        kills = parseInt(kills.text().replace(/[^0-9]/g, ""));
                        var nextUp = Math.ceil(kills/100) * 100;
                        var up = nextUp - kills;
                        up = up == 0 ? 100 : up;
                        $(this).find(".common-percentbar-container").attr("data-tooltip", up+" "+BBLog.t("kills.remaining")).closest("td").attr("data-remaining", up);
                    });
                    // mini server stars
                    var items = $("#profile-stats-weapons-secondary-column  div.profile-stats-unlock-progression-kit-item a");
                    for(var i in data.data.mainWeaponStats){
                        var weapon = data.data.mainWeaponStats[i];
                        var weaponTr = items.filter("[href*='iteminfo/"+weapon.slug+"/']").closest("div");
                        // check for duplicates
                        for(var i in BBLogWeapons.duplicates){
                            if(weapon.slug == BBLogWeapons.duplicates[i]){
                                weaponTr = weaponTr.add(items.filter("[href*='iteminfo/"+i+"/']"));
                            }
                        }
                        if(weaponTr.size()){
                            var html = $(
                                '<span class="bblog-mini-stars">'+Math.floor(weapon.kills/100)+'</span>'
                            );
                            weaponTr.append(html);
                        }
                    }
                    e.data(action+".ajax.finished", 1);
                }});
            break;
            case "bf3.vehicle.list.filters":
                var match = window.location.href.match(/soldier\/(.*?)\/vehicles\/([0-9]+)\//);
                if(BBLog.cache("mode") != "bf3" || !match) return this.callback();
                var e = $("#profile-stats-vehicle-statistics");
                if(!e.size() || BBLog.elementCheck(e, action)) return this.callback();
                var list = $(
                    '<div class="profile-stats-type-container-filters"><ul class="common-selector">'
                    + '</ul></div>'
                );
                for(var id in BBLogWeapons["vehicle-groups"]){
                    var name = BBLog.t("vehicle.group."+id);
                    var vehicles = BBLogWeapons["vehicle-groups"][id];
                    list.find("ul").append($('<li><div class="kit-all kit-'+id+'" data-filter="'+id+'"><span></span><p>'+id.toUpperCase()+'</p></div></li>').attr("data-tooltip", name));
                }
                list.find("ul").append('<li><div class="kit-all" data-filter="all"><span></span><p>All</p></div></li>');
                list.find("ul").find("li:first").addClass("first");
                list.find("ul").find("li:last").addClass("last");
                list.find("[data-filter]").on("click", function(){
                    var tb = $("#profile-stats-vehicle-statistics table.statisticstable tbody");
                    var type = $(this).attr("data-filter");
                    if(type == "all"){
                        tb.find("tr").show();
                    }else{
                        var vehicles = BBLogWeapons["vehicle-groups"][type];
                        var items = tb.find("td.item-name a");
                        tb.find("tr").hide();
                        for(var i in vehicles){
                            var vehicle = vehicles[i];
                            items.filter("[href*='iteminfo/"+vehicle+"/']").closest("tr").show();
                        }
                    }
                });
                e.find("h1:first").after(list);
                BBLog.handle("_bf3.vehicle.weapons.textfilter", {type : "vehicle"});
            break;
            case "bf3.vehicle.list.extradata":
                var match = window.location.href.match(/soldier\/(.*?)\/vehicles\/([0-9]+)\//);
                if(BBLog.cache("mode") != "bf3" || !match) return this.callback();
                var e = $("#profile-stats-vehicle-statistics");
                if(!e.size() || BBLog.elementCheck(e, action)) return this.callback();
                var device = $(".profile-venicestats-header-soldier-info-type-game:first").attr("class").match(/common-game-([0-9]+)-([0-9])/)[2];
                BBLog.handle("json.from.battlelog", {url : "/bf3/"+BBLog.cache("battlelog.language")+"vehiclesPopulateStats/"+match[2]+"/"+device+"/", callback : function(data){
                    // add vehicles destroyed info
                    var items = $("#profile-stats-vehicle-statistics table.statisticstable:first td.item-name a");
                    for(var i in data.data.mainVehicleStats){
                        var vehicle = data.data.mainVehicleStats[i];
                        var vehicleTr = items.filter("[href*='iteminfo/"+vehicle.slug+"/']").closest("tr");
                        if(vehicleTr.size()){
                            vehicleTr.attr("data-extended", true);
                            var td = vehicleTr.find("td.item-kills");
                            var html = $(
                                '<div class="bblog-kills">'
                                + '<span></span> '+vehicle.destroyXinY
                                + '</div>'
                            ).attr("data-tooltip", BBLog.t("weaponlist.destroyed"));
                            td.find(".item-object").append(html);
                        }
                    }
                    // add kills per minute
                    $("td.item-kills").each(function(){
                        var time = parseInt($(this).nextAll("td.item-duration").attr("data-sort-value"));
                        var kills = parseInt($(this).attr("data-sort-value"));
                        var kpm = ((kills/time) * 60).toFixed(2);
                        $(this).find(".bblog-kills").append('<div class="bblog-kpm">KPM '+kpm+'</div>');
                    });

                    // add service star information
                    var vehicleToGroup = {};
                    var groupToVehicle = {};
                    var groupValues = {};
                    for(var i in data.data.mainVehicleStats){
                        var g = data.data.mainVehicleStats[i].category;
                        var s = data.data.mainVehicleStats[i].slug;
                        vehicleToGroup[s] = g;
                        if(typeof groupToVehicle[g] == "undefined") groupToVehicle[g] = {};
                        groupToVehicle[g][s] = s;
                    }
                    vehicleToGroup["a-10-thunderbolt"] = vehicleToGroup["su-25tm-frogfoot"] = "Vehicle Air Jet Fighter";
                    // first iterate and add correct grouped unlocks
                    e.find("td.item-nextunlock").each(function(){
                        var vehicle = $(this).parent().find(".item-name a:first").attr("href").match(/iteminfo\/(.*?)\//i)[1];
                        var group = vehicleToGroup[vehicle];
                        $(this).closest("tr").find("td.item-servicestars").data("vehicleslug", vehicle).data("vehiclegroup", group);
                    });
                    e.find("td.item-servicestars").each(function(){
                        var vehicle = $(this).data("vehicleslug");
                        var group = $(this).data("vehiclegroup");
                        var dataObj = data.data.unlockProgression[group];
                        if(dataObj && dataObj.length){
                            var obj = null;
                            for(var i in dataObj){
                                obj = dataObj[i].unlockedBy;
                            }
                            dataObj = obj;
                            if(dataObj && !dataObj.license && dataObj.valueNeeded){
                                var lastProgressValue = dataObj.valueNeeded;
                                var haveValue = dataObj.actualValue;
                                var stars = Math.ceil(haveValue / lastProgressValue);
                                var nextValue = lastProgressValue * (stars);
                                var prevValue = nextValue - lastProgressValue;
                                var currentValue = haveValue - prevValue;
                                var perc = Math.floor((currentValue / lastProgressValue) * 100);
                                var bubble = "<div style='text-align:left;'>Star "+(stars-1)+": "+prevValue+"<br/>"
                                          + "Current: "+haveValue+"<br/>"
                                          + "Star "+(stars)+": "+nextValue+"<br/>"
                                          + "Remaining: "+(nextValue - haveValue)+"</div>";
                                var bubbleStar = perc+'% '+BBLog.t("vss.have");
                            }else{
                                var haveValue = 0;
                                var stars = "-";
                                var nextValue = 0;
                                var perc = 100;
                                var bubble = bubbleStar = ' - No Service Star data available (Shortcut Kit)';
                            }
                            var el = $(this).find("[data-tooltip]");
                            el.attr("data-tooltip", el.attr("data-tooltip")+"\n"+bubble);
                            el.closest("[data-count]").attr("data-points-required", nextValue - haveValue);
                        }
                    });
                    e.data(action+".ajax.finished", 1);
                }});
            break;
            case "bf3.vehicle.altSort":
                var match = window.location.href.match(/\/vehicles\//);
                if(BBLog.cache("mode") != "bf3" || !match) return this.callback();
                var e = $("#profile-stats-vehicle-statistics");
                if(!e.data("bf3.vehicle.list.extradata.ajax.finished")) return this.callback();
                BBLog.handle("bf3.vehicle.list.extradata", data, function(){
                    var e = $("#statisticstable");
                    if(!e.size() || BBLog.elementCheck(e, action)) return;
                    $("#statisticstable th:eq(2)").attr("data-tooltip", BBLog.t("bf3.vehicle.altSort.active"));
                    $("#statisticstable td.item-servicestars").each(function(){
                        $(this).find("[data-count]").removeAttr("data-count");
                        var points = parseInt($(this).find("[data-points-required]").attr("data-points-required"));
                        if(!points) points = 999999;
                        $(this).attr("data-sort-value", points);
                        e.trigger("update");
                    });
                    e.find("th.headerSortUp, th.headerSortDown").trigger("click").trigger("click");
                });
            break;
            case "bf3.weapons.altSort":
                var match = window.location.href.match(/\/weapons\//);
                if(BBLog.cache("mode") != "bf3" || !match) return this.callback();
                var e = $("#profile-stats-weapons-main-column");
                if(!e.data("bf3.weapons.list.extradata.ajax.finished")) return this.callback();
                BBLog.handle("bf3.weapons.list.extradata", data, function(){
                    var e = $("#bf3-weapon-table");
                    if(!e.size() || BBLog.elementCheck(e, action)) return;
                    $("#bf3-weapon-table th:eq(2)").attr("data-tooltip", BBLog.t("bf3.weapons.altSort.active"));
                    $("#bf3-weapon-table td.item-servicestars").each(function(){
                        $(this).attr("data-sort-value", $(this).attr("data-remaining"));
                        e.trigger("update");
                    });
                    e.find("th.headerSortUp, th.headerSortDown").trigger("click").trigger("click");
                });
            break;
            case "bf3.weapons.info":
                var match = window.location.href.match(/iteminfo\/(.*?)\/(.*?)\//);
                if(BBLog.cache("mode") != "bf3" || !match) return this.callback();
                var boxContainer = $("div.venice-stats-small-boxes:first");
                if(!boxContainer.size() || BBLog.elementCheck(boxContainer, action)) return this.callback();
                var weapon = match[1];
                var wdata = BBLogWeapons[weapon];
                if(typeof wdata == "string") wdata = BBLogWeapons[wdata];
                if(typeof wdata == "undefined") return this.callback();

                var title = boxContainer.parent().find(".common-secondary-column-line");
                title.next().css("margin-top", "0px");
                title.remove();

                // get box tpl
                var getBoxTpl = function(cl, additionalData){
                    additionalData = typeof additionalData == "undefined" ? "" : additionalData;
                    return '<div class="'+cl+' common-box-narrow common-box-title-clean venice-single-stats-column"><div class="common-box-container"><div class="common-box-inner-border"><div class="common-box-title"></div><div class="common-box-inner venice-single-stats-column-height"><div class="venice-statsitem-bar-container">'+additionalData+'</div></div></div></div></div>'
                };

                // get item row
                var getItemRow = function(title, value){
                    if(typeof title == "object") title = title.html();
                    return '<div class="venice-statsitem-box-item"><div class="venice-statsitem-bar-title">'+title+'</div>'
                    + '<div class="venice-statsitem-bar-value">'+value+'</div><div style="clear:both;"></div>'
                };

                var appendTo = $('<div class="base-clear"></div><div class="bblog-weapon-container" id="bblog-weapon-container"></div><div class="base-clear"></div>');
                boxContainer.after(appendTo);
                appendTo = $("#bblog-weapon-container");

                // first row
                if(typeof wdata.supp != "undefined"){
                    var firstBox = $(getBoxTpl("extraInfos first box-1"));
                    var dmgChest = 100;
                    var dmgHead = 200;
                    var dmgLegs = 91;
                    if(typeof wdata.multiChest != "undefined") dmgChest = 100 * wdata.multiChest;
                    if(typeof wdata.multiHead != "undefined") dmgHead = 100 * wdata.multiHead;
                    var secondBox = $(getBoxTpl("damagemodel", '<div class="torso"><span class="chest">'+dmgChest+'%</span><span class="head">'+dmgHead+'%</span><span class="legs">'+dmgLegs+'%</span></div>'));
                    var thirdBox = $(getBoxTpl("damagecharts"));

                    // add some extra weapon info
                    firstBox.find(".common-box-title").html(BBLog.t("weapon.info"));
                    var drop = 15;
                    if(typeof wdata.drop != "undefined") drop = wdata.drop;
                    var dropTime = (wdata.maxdist / wdata.speed).toFixed(1);
                    var maxDrop = (dropTime * drop).toFixed(1) * -1;
                    var url = 'http://chart.googleapis.com/chart?chxt=x,x,y,y&cht=lxy&chf=bg,s,FFFFFF00&chf=bg,s,FFFFFF00&'
                    + 'chd=t:0,0,'+wdata.maxdist+','+wdata.maxdist+'|0,0,'+maxDrop+','+maxDrop+'&'
                    + 'chls=3.0&chs=250x130&chxl=1:|||3:||&chma=60,0,0,0&'
                    + 'chxr=0,0,'+wdata.maxdist+','+(wdata.maxdist/5)+'|2,'+maxDrop+',0&chg=10,10,2,2,0&chds=0,'+wdata.maxdist+','+maxDrop+',0'
                    + '&chxs=0N*f*m,aaaaaa|2N*f*m,aaaaaa';
                    var chart = '<div class="bblog-dropchart"><span class="drop">'+BBLog.t("dropchart.drop")+'</span><span class="dist">'+BBLog.t("dropchart.distance")+'</span>';
                    chart += '<img src="'+url+'" alt="Dropchart" width="250" height="130"/>';
                    chart += '</div>';
                    var displayInfos = {
                        "supp" : wdata.supp+"%",
                        "speed" : wdata.speed+" m/s",
                        "drop" : drop+" m/s <span data-tooltip='"+chart+"' style='color:#F80;'>(Chart)</span>",
                        "rld" : wdata.rld + "s",
                        "rldem" : wdata.rldem + "s",
                        "rldtrs" : (wdata.rldtrs * wdata.rld).toPrecision(2) + "s / "+(wdata.rldtrs * wdata.rldem).toPrecision(2) + "s",
                        "maxdist" : wdata.maxdist + "m",
                        "maxdisttime" : dropTime+" s",
                    };
                    var appendCont = firstBox.find(".venice-statsitem-bar-container");
                    for(var id in displayInfos){
                        // if some information not exists than remove it
                        if(displayInfos[id].match(/undefined/)) continue;
                        var span = $("<span>").text(BBLog.t("weapon."+id));
                        var key = "weapon."+id+".bubble";
                        if(BBLog.t(key) != key){
                            var b = BBLog.t("weapon."+id+".bubble");
                            b = b.replace(/{chart}/, chart);
                            span.prepend($("<span class='info'></span> "+BBLog.t("weapon."+id)).attr("data-tooltip", b));
                        }
                        appendCont.append(getItemRow(span, displayInfos[id]));
                    };

                    // add some damage info
                    secondBox.find(".common-box-title").html(BBLog.t("weapon.damage"));
                    var appendCont = secondBox.find(".venice-statsitem-bar-container");
                    var count = 1;
                    var chd = [];
                    var meterDist = [1,5,10,15,20,25,30,45,60,75,90,120];
                    var entries = BBLog.count(meterDist);
                    var minDmg = 999;
                    var maxDmg = 0;
                    for(var i in meterDist){
                        var dist = meterDist[i];
                        var calculatedDistDmg = 0;
                        if(dist <= wdata.dmgFallStart){
                            calculatedDistDmg = wdata.dmgMax;
                        }else if(dist >= wdata.dmgFallEnd){
                            calculatedDistDmg = wdata.dmgMin;
                        }else{
                            var looseDmgMax = wdata.dmgMax - wdata.dmgMin;
                            var percLoose = (100 / wdata.dmgFallEnd) * dist;
                            calculatedDistDmg = wdata.dmgMax - (looseDmgMax / 100 * percLoose);
                        }
                        if(count == entries){
                            var text = dist+"m - "+wdata.maxdist+"m";
                        }else{
                            var text = "in "+dist+"m";
                        }
                        calculatedDistDmg = calculatedDistDmg.toFixed(1);
                        minDmg = Math.min(minDmg, calculatedDistDmg);
                        maxDmg = Math.max(maxDmg, calculatedDistDmg);
                        chd.push(calculatedDistDmg);
                        appendCont.append(getItemRow(text, calculatedDistDmg));
                        count++;
                    };

                    // add charts to third box
                    thirdBox.find(".common-box-title").html(BBLog.t("weapon.damage"));
                    minDmg -= 6;
                    maxDmg += 6;
                    var scale = wdata.dmgFallEnd+10;
                    var appendCont = thirdBox.find(".venice-statsitem-bar-container");
                    var url = 'http://chart.googleapis.com/chart?chxt=x,x,y,y&cht=lxy&chf=bg,s,FFFFFF00&chf=bg,s,FFFFFF00&'
                    + 'chd=t:0,'+wdata.dmgFallStart+','+wdata.dmgFallEnd+','+scale+'|'+wdata.dmgMax+','+wdata.dmgMax+','+wdata.dmgMin+','+wdata.dmgMin+'&'
                    + 'chls=3.0&chs=300x150&chxl=1:|all data from symthic.com|Distance|3:||Damage&chma=0,0,0,0&'
                    + 'chxr=0,0,'+scale+',10|2,'+minDmg+','+maxDmg+'&chg='+(100/scale).toFixed(2)*10+',10,2,2,0&chds=0,'+scale+','+minDmg+','+maxDmg
                    + '&chxs=0N*f*m,aaaaaa|2N*f*,aaaaaa';
                    appendCont.html('<img src="'+url+'" alt="" style="padding-top:20px;"/>');
                    // add row
                    appendTo.append($('<div class="row">').append(firstBox).append(secondBox).append(thirdBox).append('<div class="base-clear">'));
                }
                if(typeof wdata.spread != "undefined"){
                    // second row
                    firstBox = $('<div class="common-box-narrow common-box-title-clean venice-single-stats-column first">'+BBLog.plotter.getBoxHtml(weapon)+'</div>');
                    secondBox = $(getBoxTpl("plotinfo box-1"));
                    thirdBox = $(getBoxTpl("plotdesc"));

                    // accuracy plot data
                    secondBox.find(".common-box-title").html(BBLog.t("weapon.plotinfo"));
                    var appendCont = secondBox.find(".venice-statsitem-bar-container");
                    for(var i in wdata["recoil"]){
                        var span = $("<span>").text(BBLog.t("weapon.recoil."+i));
                        var key = "weapon.recoil."+i+".bubble";
                        if(BBLog.t(key) != key){
                            span.prepend($("<span class='info'></span>" + BBLog.t("weapon.recoil."+i)).attr("data-tooltip", BBLog.t(key)));
                        }
                        appendCont.append(getItemRow(span , '<span class="recoil-data-'+i+'">'+wdata["recoil"][i]+'</span>'));
                    }
                    for(var i in wdata["spread"]){
                        text = BBLog.t("weapon.spread."+i);
                        if(text == "weapon.spread."+i) continue;
                        var span = $("<span>").text(BBLog.t("weapon.spread."+i));
                        var key = "weapon.spread."+i+".bubble";
                        if(BBLog.t(key) != key){
                            span.prepend($("<span class='info'></span>" + BBLog.t("weapon.spread."+i)).attr("data-tooltip", BBLog.t(key)));
                        }
                        appendCont.append(getItemRow(span, '<span class="spread-data-'+i+'">'+wdata["spread"][i]+'</span>'));
                    }

                    // accuracy plot desc
                    thirdBox.find(".common-box-title").html(BBLog.t("weapon.plot.desc.title"));
                    thirdBox.find(".venice-statsitem-bar-container").html(BBLog.t("weapon.plot.desc"));

                    // append to row
                    appendTo.append($('<div class="row">').append(firstBox).append(secondBox).append(thirdBox).append('<div class="base-clear">'));
                    BBLog.plotter.init(weapon);
                    BBLog.plotter.draw(weapon, {"attachment" : false, "aim" : "ads", "position" : "stand", "action" : "base"});
                }

                // third row (TTK ROW)
                if(typeof wdata["ttk"] != "undefined"){
                    var firstBox = $(getBoxTpl("extraInfos first"));
                    var secondBox = $(getBoxTpl("plotinfo"));
                    var thirdBox = $(getBoxTpl("plotdesc"));

                    firstBox.find(".common-box-title").html(BBLog.t("weapon.ttk"));
                    var appendCont = firstBox.find(".venice-statsitem-bar-container");
                    for(var i in wdata["ttk"]){
                        var text = "in "+i+"m";
                        appendCont.append(getItemRow(text, wdata["ttk"][i]+" / "+wdata["ttk-hc"][i]));
                    };

                    secondBox.find(".common-box-title").html(BBLog.t("weapon.btk"));
                    var appendCont = secondBox.find(".venice-statsitem-bar-container");
                    for(var i in wdata["btk"]){
                        var text = "in "+i+"m";
                        appendCont.append(getItemRow(text, wdata["btk"][i]+" / "+wdata["btk-hc"][i]));
                    };

                    // ttk desc info
                    thirdBox.find(".common-box-title").html(BBLog.t("weapon.ttk.info"));
                    thirdBox.find(".venice-statsitem-bar-container").html(BBLog.t("weapon.ttk.desc"));

                    // add row
                    appendTo.append($('<div class="row">').append(firstBox).append(secondBox).append(thirdBox).append('<div class="base-clear">'));
                }

                // full weapon table
                var html = $("<div class='bblog-fullWeaponTable'>");
                html.append('<div class="venice-stats-info-title secondary" onclick="window.open(\''+BBLog.serviceUrl+"/"+BBLog.cache("language")+'/bf3-weapon-comparison#'+weapon+'\', \'_blank\');" style="cursor:pointer;">'+BBLog.t("weapon.compare")+'</div><table></table>');
                html.append('<div class="common-secondary-column-line">');
                appendTo.append($('<div class="row">').append(html).append('<div class="base-clear">'));

                // sight videos
                var availableSights = {
                    rx01 : "Reflex (RDS)",
                    eotech : "Holographic (HOLO)",
                    acog : "ACOG (4x)",
                    irnv : "IRNV (IR 1x)",
                    riflescope : "Rifle Scope (6x)",
                    m145 : "M145 (3,4x)",
                    kobra : "KOBRA (RDS)",
                    pkas : "PKA-S (HOLO)",
                    pso : "PSO-1 (4x)",
                    pks07 : "PKS-07 (7x)",
                    pka : "PK-A (3,4x)",
                    riflescope8x : "Rifle Scope (8x)",
                    ballistic : "Ballistic (12x)"
                };
                var sights = $("div.profile-stats-unlock-progression-kit-item img");
                if(sights.size()){
                    var html = $("<div class='bblog-sightVideos'>");
                    html.append('<div class="venice-stats-info-title secondary" style="cursor:pointer;">'+BBLog.t("weapon.sight.videos")+'</div>');
                    for(var i in availableSights){
                        html.append('<div data-sight="'+i+'" class="video" style="display:none;"><div class="play" data-video="'+i+'">'+availableSights[i]+'<div>'+BBLog.t("weapon.sight.startvideo")+'</div></div></div>');
                    }
                    html.append('<div class="common-secondary-column-line">');

                    html.find(".venice-stats-info-title").on("click", function(){
                        $(this).toggleClass("visible");
                        $(this).nextAll().hide();
                        if($(this).hasClass("visible")){
                            // remove all not available sights
                            $(this).nextAll().each(function(){
                                var sightE = $(this);
                                var sight = $(this).attr("data-sight");
                                if(sight){
                                    sights.each(function(){
                                        var thisSight = $(this).attr("src").replace(/(.*)\//ig, "").replace(/\?(.*)/ig, "").replace(/\.(.*)/ig, "").toLowerCase();
                                        if(thisSight == sight){
                                            sightE.show();
                                            return false;
                                        }
                                    });
                                }
                            });
                        }
                    });

                    html.find(".play").on("click", function(){
                        var p = $(this).parent();
                        $(this).replaceWith('<video width="230" height="144"><source src="'+BBLog.serviceUrl+'/videos/sights/'+$(this).attr("data-video")+'.ogv" type="video/ogg" /></video>')
                        p.children().get(0).play();
                    }).find(".venice-stats-info-title").css("cursor", "pointer").on("click", function(){
                        $(this).parent().find(".video").toggle();
                    });

                    appendTo.append($('<div class="row">').append(html).append('<div class="base-clear">'));
                }

                // weapon switch
                var weapDiv = $('<div class="hidden">');
                for(var group in BBLogWeapons["weapon-groups"]){
                    var weapons = BBLogWeapons["weapon-groups"][group];
                    weapDiv.append('<div class="title">'+group.toUpperCase()+'</div><div class="base-clear"></div>');
                    for(var w in weapons){
                        w = weapons[w];
                        if(typeof BBLogWeapons[w] == "undefined"){
                            var name = w;
                        }else{
                            var name = typeof BBLogWeapons[w]["displayname"] != "undefined" ? BBLogWeapons[w]["displayname"] : w;
                        }
                        var url = window.location.href.replace(new RegExp("/"+weapon+"/"), "/"+w+"/");
                        var a = $("<a href='"+url+"'>"+name.toUpperCase()+"</a>");
                        weapDiv.append(a);
                    }
                    weapDiv.append('<div class="base-clear">');
                }
                var html = $("<div class='bblog-weaponSwitch'>");
                html.append('<div class="venice-stats-info-title secondary" style="cursor:pointer;">'+BBLog.t("weapon.switch")+'</div>');
                html.append(weapDiv);
                html.append('<div class="common-secondary-column-line">');

                html.find(".venice-stats-info-title").on("click", function(){
                    $(this).next().toggle();
                });

                appendTo.append($('<div class="row">').append(html).append('<div class="base-clear">'));
            break;
            case "bf4.weapons.info":
                if(BBLog.cache("mode") != "bf4" || !window.location.href.match(/\/weapons\//)) return this.callback();

                var e = $("#weapon-details");
                var e4 = $("#bblog-weapon-stats-btn");

                if(e.size() && !e4.size()){
                    e.find(".box").first().prepend($('<input id="bblog-weapon-stats-btn" type="button" class="btn btn-tiny"/>').attr("value", BBLog.t("bf3.weapons.info")).on("click", function(){
                        var weapon = $("#weapon-list > table:first tr.active").attr("data-slug");
                        if(weapon && BBLog.storage("init.data") && BBLog.storage("init.data")["symthic.frame"]){
                            BBLog.popup('weapon-info', BBLog.t("bf3.weapons.info")+": "+weapon.toUpperCase(), '<iframe src="'+BBLog.storage("init.data")["symthic.frame"]+'?weapon='+weapon+'&comeFrom=bblog" width="100%" height="'+($(window).height()-100)+'" scrolling="auto" frameborder="0"></iframe>');
                        }
                    }));
                }

                e = e.find(".box-content").first().find(".track-weapon-stats").first();
                if(!BBLog.elementCheck(e, action)){
                    try{
                        var weaponData = Surface.Renderer.state.surface["weapon-details"]["detailedWeapon"]["info"]["weaponData"];
                        if(typeof weaponData.rateOfFire != "undefined" && typeof weaponData.statDamage != "undefined"){
                            var c = e.find("li.clearfix").last();
                            var clone;
                            var damage = weaponData.statDamage * 100;
                            var rof = weaponData.rateOfFire;
                            if(isNaN(weaponData.rateOfFire)) rof = 6 * 60;
                            var max, curr, playerDamage, btk;
                            playerDamage = 60;

                            clone = c.clone();
                            curr = btk = Math.ceil(playerDamage / damage);
                            max = Math.max(curr, 5);
                            clone.attr("data-tooltip", BBLog.t("bf4.weapons.info.btk.hc"));
                            clone.find("span").first().html("Ø BTK HC");
                            clone.find("span").last().text(curr);
                            curr -= 1;
                            max -= 1;
                            clone.find(".progress-bar-inner").css("width", 100 - ((100 / max) * curr)+"%");
                            c.after(clone);

                            clone = c.clone();
                            curr = btk == 1 ? 5 : ((1 / (rof / 60)) * btk) * 1000;
                            max = Math.max(curr, 1000);
                            clone.attr("data-tooltip", BBLog.t("bf4.weapons.info.ttk.hc"));
                            clone.find("span").first().html("Ø TTK HC (ms)");
                            clone.find("span").last().text(curr.toFixed(0));
                            clone.find(".progress-bar-inner").css("width", 100 - ((100 / max) * curr)+"%");
                            c.after(clone);

                            playerDamage = 100;

                            clone = c.clone();
                            curr = btk = Math.ceil(playerDamage / damage);
                            max = Math.max(curr, 5);
                            clone.attr("data-tooltip", BBLog.t("bf4.weapons.info.btk"));
                            clone.find("span").first().html("Ø BTK");
                            clone.find("span").last().text(curr)
                            curr -= 1;
                            max -= 1;
                            clone.find(".progress-bar-inner").css("width", 100 - ((100 / max) * curr)+"%");
                            c.after(clone);

                            clone = c.clone();
                            curr = btk == 1 ? 5 : ((1 / (rof / 60)) * btk) * 1000;
                            max = Math.max(curr, 1000);
                            clone.attr("data-tooltip", BBLog.t("bf4.weapons.info.ttk"));
                            clone.find("span").first().html("Ø TTK (ms)");
                            clone.find("span").last().text(curr.toFixed(0));
                            clone.find(".progress-bar-inner").css("width", 100 - ((100 / max) * curr)+"%");
                            c.after(clone);
                        }
                    }catch(e){}
                }
            break;
            case "bf4.weapons.list.filters":
            case "bf4.vehicle.list.filters":
                if(BBLog.cache("mode") != "bf4" || !window.location.href.match(/\/(weapons|vehicles)\//)) return this.callback();
                var ids = {
                    "bf4.weapons.list.filters" : ["#weapon-details", "#weapon-list > table:first", "#weapon-statistics > div.span8"],
                    "bf4.vehicle.list.filters" : ["#vehicle-details", "#vehicle-list > table:first", "#vehicle-statistics > div.span8"]
                }
                var e = $(ids[action][0]);
                var e2 = $(ids[action][1]);
                var e3 = $(ids[action][2]);
                if(!e.size() || !e3.size() || BBLog.elementCheck(e3, action)) return this.callback();

                e3.prepend('<div class="box bblog-textual-filter"><header><h1>'+BBLog.t("list.filters.search")+'</h1></header><div class="box-content"><div id="bblog-textual-filter"></div></div></div>');
                var textfield = $('<input type="text" value="" data-key="'+action+'.filter"/>');
                textfield.val(BBLog.storage(textfield.attr("data-key")) || "");
                textfield.on("keyup", [ids[action][1]], function(ev){
                    BBLog.storage($(this).attr("data-key"), $(this).val());

                    var val = $(this).val().replace(/[^0-9a-zA-Z,]/g, "").toLowerCase();
                    var vals = val.split(",");
                    var table = $(ev.data[0]);
                    var items = table.find("td.item-name p");

                    items.closest("tr").removeClass("bblog-hide");
                    if(val.length){
                        if($("#bn-show-all").size()){
                            $("#bn-show-all").trigger("click").remove();
                            setTimeout(function(){textfield.trigger("keyup")}, 100);
                        }
                        items.each(function(){
                            var text = $(this).text().replace(/[^0-9a-zA-Z,\ä\ü\ö\Ö\Ü\Ä]/g, "").toLowerCase();
                            for(var i in vals){
                                if(text.match(vals[i])){
                                    return true;
                                }
                            }
                            $(this).closest("tr").addClass("bblog-hide");
                        });
                    }
                }).triggerHandler("keyup");
                $("#bblog-textual-filter").append(textfield);
            break;
            case "bf4.weapons.list.sort":
            case "bf4.vehicle.list.sort":
                var mode = false;
                if(window.location.href.match(/\/weapons\//) && Surface.Renderer.state.surface["weapon-list"] && action == "bf4.weapons.list.sort") mode = "weapon";
                if(window.location.href.match(/\/vehicles\//) && Surface.Renderer.state.surface["vehicle-list"] && action == "bf4.vehicle.list.sort") mode = "vehicle";
                if(mode){
                    var e = $("#"+mode+"-list");
                    if(BBLog.elementCheck(e, action)) return this.callback();

                    if(mode == "weapon") {

                        var sorts = [
                            {
                                "filter" : "th:eq(2)",
                                "tdfilter" : "td.item-servicestars",
                                "active" : 0,
                                "arr" : [
                                    {title : BBLog.t("bf4.weapons.list.sort.stars.star"), value : "data-sort-value-w-star", "sort" : "headerSortUp", "defaultVal" : 999999},
                                    {title : BBLog.t("bf4.weapons.list.sort.stars.kills"), value : "data-sort-value-w-kills", "sort" : "headerSortDown", "defaultVal" : 999999}
                                ]
                            },
                            {
                                "filter" : "th:eq(3)",
                                "tdfilter" : "td.item-nextunlock",
                                "active" : 0,
                                "arr" : [
                                    {title : BBLog.t("bf4.weapons.list.sort.unlocks.star"), value : "data-sort-value-w-percent", "sort" : "headerSortUp", "defaultVal" : 999999},
                                    {title : BBLog.t("bf4.weapons.list.sort.unlocks.kills"), value : "data-sort-value-w-kills", "sort" : "headerSortDown", "defaultVal" : 999999}
                                ]
                            }
                        ];

                        e.find("td.item-servicestars").each(function(){
                            var sort = $(this).attr("data-sort-value");
                            while(sort > 100) sort -= 100;
                            sort = 100 - sort;
                            $(this).attr("data-sort-value-w-star", $(this).attr("data-sort-value"));
                            $(this).attr("data-sort-value-w-kills", sort);
                            var tmp = $(this).find(".service-star");
                            tmp.attr("data-tooltip", tmp.attr("data-tooltip")+"<br/>"+BBLog.t("kills.remaining")+": "+sort);
                        });

                        var arr = Surface.Renderer.state.surface["weapon-list"].mainWeapons;
                        for(var i in arr){
                            var w = arr[i];
                            if(w.nextAccessoryUnlock && w.nextAccessoryUnlock.weaponAddonUnlock && w.nextAccessoryUnlock.weaponAddonUnlock.unlockedBy){
                                var tmp = w.nextAccessoryUnlock.weaponAddonUnlock.unlockedBy;
                                var sortValue = tmp.valueNeeded - tmp.actualValue;
                                var tr = $("#weapon-list tr[data-guid='"+w.guid+"']");
                                tr.find("td.item-nextunlock")
                                    .attr("data-sort-value", (100 / tmp.valueNeeded) * tmp.actualValue)
                                    .attr("data-sort-value-w-percent", (100 / tmp.valueNeeded) * tmp.actualValue)
                                    .attr("data-sort-value-w-kills", sortValue);
                                var tmp = tr.find("td.item-nextunlock [data-tooltip]").first();
                                tmp.attr("data-tooltip", tmp.attr("data-tooltip")+"<br/>"+BBLog.t("kills.remaining")+": "+sortValue);
                            }
                        }

                    }else if(mode == "vehicle"){

                        var sorts = [
                            {
                                "filter" : "th:eq(2)",
                                "tdfilter" : "td.item-servicestars",
                                "active" : 0,
                                "arr" : [
                                    {title : BBLog.t("bf4.vehicle.list.sort.stars.star"), value : "data-sort-value-v-percent", "sort" : "headerSortUp", "defaultVal" : 0},
                                    {title : BBLog.t("bf4.vehicle.list.sort.stars.points"), value : "data-sort-value-v-points", "sort" : "headerSortDown", "defaultVal" : 999999}
                                ]
                            },
                            {
                                "filter" : "th:eq(3)",
                                "tdfilter" : "td.item-nextunlock",
                                "active" : 0,
                                "arr" : [
                                    {title : BBLog.t("bf4.vehicle.list.sort.unlocks.star"), value : "data-sort-value-v-percent", "sort" : "headerSortDown", "defaultVal" : 0},
                                    {title : BBLog.t("bf4.vehicle.list.sort.unlocks.points"), value : "data-sort-value-v-points", "sort" : "headerSortDown", "defaultVal" : 999999}
                                ]
                            }
                        ];

                        e.find("td.item-servicestars").each(function(){
                            $(this).attr("data-sort-value-v-percent", $(this).attr("data-sort-value"));
                        });

                        var cats = Surface.Renderer.state.surface["vehicle-list"].categories;
                        for(var c in cats){
                            var cat = cats[c];
                            var vehicle = cat.vehicles.shift();
                            if(vehicle && vehicle.unlocks){
                                var highestUnlock = null;
                                var nearestUnlock = null;
                                var currentValue = 0;
                                var tr = e.find("tr[data-category='"+cat.name+"']");
                                for(var u in vehicle.unlocks){
                                    var unlock = vehicle.unlocks[u];
                                    if(unlock && unlock.unlockedBy){
                                        unlock = unlock.unlockedBy;
                                        var currentValue = unlock.actualValue;
                                        if(!highestUnlock || highestUnlock.valueNeeded < unlock.valueNeeded) highestUnlock = unlock;
                                        if(unlock.actualValue < unlock.valueNeeded && (!nearestUnlock || unlock.valueNeeded < nearestUnlock.valueNeeded)) nearestUnlock = unlock;
                                        var tmp = tr.find("td.item-nextunlock");
                                    }
                                }
                                if(nearestUnlock){
                                    tmp.attr("data-sort-value", (100 / nearestUnlock.valueNeeded) * nearestUnlock.actualValue);
                                    tmp.attr("data-sort-value-v-percent", tmp.attr("data-sort-value"));
                                    tmp.attr("data-sort-value-v-points", nearestUnlock.valueNeeded - nearestUnlock.actualValue);
                                    tmp = tmp.find(".vehicleunlock");
                                    tmp.attr("data-tooltip", tmp.attr("data-tooltip")+"<br/>Remaining: "+(nearestUnlock.valueNeeded - nearestUnlock.actualValue));
                                }
                                if(highestUnlock){
                                    var nextStar = highestUnlock.valueNeeded;
                                    while(nextStar < currentValue) nextStar += highestUnlock.valueNeeded;
                                    var tmp = tr.find("td.item-servicestars .service-star");
                                    tmp.attr("data-tooltip", tmp.attr("data-tooltip")+"<br/>Current: "+currentValue+"<br/>Next: "+nextStar+"<br/>"+BBLog.t("points.remaining")+": "+(nextStar - currentValue));
                                    tr.find("td.item-servicestars").attr("data-sort-value-v-points", nextStar - currentValue);
                                }
                            }
                        }
                    }

                    var sorter = e.find("table").data("tablesorter");
                    for(var i in sorts){
                        var s = sorts[i];
                        e.find(s.filter).css("position", "relative").on("mouseenter", {"s" : s, "e" : e}, function(ev){
                            var th = $(this);
                            if($("#bblog-altersort").size()) $("#bblog-altersort").remove();
                            var l = $(this).offset().left+1;
                            var t = $(this).offset().top + $(this).outerHeight() + 1;
                            $("body").append('<div id="bblog-altersort" style="left:'+l+'px; top:'+t+'px;"><div class="inner"></div></div>');
                            $("#bblog-altersort").on("mouseleave", function(){
                                $(this).remove();
                            });
                            var cont = $("#bblog-altersort").children();
                            for(var c in ev.data.s.arr){
                                var entry = ev.data.s.arr[c];
                                var div = $("<div>").text(entry.title).on("click", {"c" : c, "s" : ev.data.s, "entry" : entry, "e" : ev.data.e}, function(ev){
                                    ev.data.e.find(ev.data.s.tdfilter).each(function(){
                                        $(this).attr("data-sort-value", $(this).attr(ev.data.entry.value));
                                        if(!parseFloat($(this).attr("data-sort-value"))) $(this).attr("data-sort-value", ev.data.entry.defaultVal);
                                    });
                                    ev.data.e.find("table").trigger("update");
                                    th.trigger("click");
                                    setTimeout(function(){
                                        if(!th.hasClass(ev.data.entry.sort)) th.trigger("click");
                                    }, 50);
                                    ev.data.s.active=  ev.data.c;
                                    $("#bblog-altersort").remove();
                                });
                                if(c == ev.data.s.active) div.addClass("active").off("click");
                                cont.append(div);
                            }
                        });
                    }
                }
            break;
            case "egg":
                (function(){
                    function t0(){
                        var nr = 60;
                        var iv = 50;
                        var tiv = null;
                        var s = 1;
                        var r = 0;
                        var sd = 0.01;
                        var rd = 1;
                        function t1(){
                            $("#bblog-egg .m.d").text(nr).show();
                            setTimeout(t2, iv);
                        }

                        function t2(){
                            nr--;
                            if(nr < 0){
                                t3();
                                return;
                            }
                            t1();
                        }

                        function t3(){
                            $("#bblog-egg").remove();
                            $("body").append('<div id="bblog-eggn">Eeeem... Ya, doesn\'t worked as expected, anyway, have fun on battlelog</div>');
                            $("*").off("click");
                            $(document).off("click").on("click", function(ev){
                                $(ev.target).remove();
                                ev.stopPropagation();
                                ev.preventDefault();
                                if(!$("#bblog-eggn").size()){
                                    $("body").append('<div id="bblog-eggn"></div>');
                                }
                                shuffle(texts);
                                $("#bblog-eggn").text(texts[0]);
                            });
                        }

                        function shuffle(array) {
                            for (var i = array.length - 1; i > 0; i--) {
                                var j = Math.floor(Math.random() * (i + 1));
                                var temp = array[i];
                                array[i] = array[j];
                                array[j] = temp;
                            }
                            return array;
                        }

                        var texts = [
                            'UUUUps, weird, isn\'t it?',
                            'Hahahahaaaaa, owned',
                            'That you don\'t expected, right?',
                            'This is one of the battlefield moments, legen... hold on... dary!',
                            'If you smile, the mission is now to destroy your smileface!',
                            'Come on, give me a fistbump - In the middle of the monitor',
                            '4 8 15 16 23 42 - Getting lost in battlelog?',
                            'I\'m sorry, my responses are limited. You must click on the right areas.'
                        ];

                        window.scrollTo(0, 0);
                        var e = $('<div id="bblog-egg"><h1>Hmm...<br/>This is getting weird,<br/>what do you want from BBLog</h1><br/><br/><ul><li><b>1.</b> I\'m just a fanboy/fangirl and i type all day long BBLog in my keyboard</li><li><b>2.</b> I hate BBLog and Battlelog, destroy yourself</li></ul><div class="m"></div><div class="m d"></div></div>');
                        e.find("li").first().on("click", function(){
                            $("#bblog-egg .m").html('100000 thanks, but... Get a life...<br/>We now shutdown Battlelog for you, the first step to your freedom');
                            t1();
                        });
                        e.find("li").last().on("click", function(){
                            $("#bblog-egg .m").html('Well, haters are not welcome, instead of destroying ourselves, we destroy you!');
                            t1();
                        });
                        $("body").append(e);
                    }
                    var keyProcess = [];
                    $(document).on("keydown.bblogeasteregg", function(ev){
                        if($(ev.srcElement || ev.target).is("body")){
                            keyProcess.push(ev.keyCode);
                            keyProcess = keyProcess.slice(-5);
                            if(keyProcess.length == 5 && keyProcess[0] == 66 && keyProcess[1] == 66 && keyProcess[2] == 76 && keyProcess[3] == 79 && keyProcess[4] == 71){
                                keyProcess = [];
                                t0();
                            }
                        }
                    });
                })();
            break;
        }
        return this.callback();
    },

    /**
    * The cache getter/setter
    * Cache means only variable storage until the next page call
    *
    * @param key
    * @param value
    * @return
    */
    _cache : {},
    cache : function(key, value){
        if(typeof value == "undefined"){
            return typeof BBLog._cache[key] != "undefined" ? BBLog._cache[key] : null;
        }else{
            BBLog._cache[key] = value;
        }
    },

    /**
    * Store and receive data in storage in correct type hints
    * Data is stored parmanently
    *
    * @param key string
    * @param value If given (not undefined) the setter is active
    * @return string
    */
    storage : function(key, value){
        if(!BBLog.count(BBLogStorageObject)) BBLogStorageObject = {};
        if(typeof value != "undefined"){
            BBLogStorageObject[key] = value;
            if(typeof storeSettings != "undefined"){
                storeSettings();
            }else{
                window.postMessage({ action : "store", data : BBLogStorageObject}, "*");
            }
            return null;
        }
        return (typeof BBLogStorageObject[key] != "undefined") ? BBLogStorageObject[key] : null;
    },

    /**
    * Get translation for a key
    * Fallback to english of key not set
    * If nothing exist, return the key
    *
    * @param key
    * @return string
    */
    t : function(key){
        if(!BBLog.count(BBLogTranslations)) return key;
        var lang = BBLog.cache("language");
        if(typeof BBLogTranslations[lang] != "undefined" && typeof BBLogTranslations[lang][key] != "undefined"){
            return BBLogTranslations[lang][key];
        }
        if(typeof BBLogTranslations["en"][key] != "undefined"){
            return BBLogTranslations["en"][key];
        }
        return key;
    },

    /**
    * Get the bf3stats mapping name for a weapon
    *
    * @return string
    */
    getBf3StatsMapName : function(weapon){
        if(weapon == "acb-90") weapon = "knife";
        for(var i in BBLogWeapons["bf3stats-mapping"]){
            if(BBLogWeapons["bf3stats-mapping"][i] == weapon){
                return i;
            }
        }
        return null;
    },

    /**
    * Get all configkey data for a key
    *
    * @param key
    * @return object
    */
    getConfigData : function (key){
        for(var i in BBLog.configKeys){
            if(key == BBLog.configKeys[i].key) return BBLog.configKeys[i];
        }
        return null;
    },

    /**
    * Search for a given key value pair and return the result
    */
    searchInObject : function(object, key, value, returnIndex){
        var index = null;
        key = typeof key == "undefined" ? null : key;
        value = typeof value == "undefined" ? null : value;
        // multidimensional search
        if(key !== null && value !== null){
            for(var i in object) {
                if(!object[i]) continue;
                if(object[i][key] == value) {
                    index = i;
                    break;
                }
            }
        // search for key
        }else if(key !== null && value === null){
            for(var i in object) {
                if(!object[i]) continue;
                if(i == key){
                    index = i;
                    break;
                }
            }
        // search for value
        }else if(key === null && value !== null){
            for(var i in object) {
                if(!object[i]) continue;
                if(object[i].toLowerCase() == value.toLowerCase()){
                    index = i;
                    break;
                }
            }
        }
        if(index !== null && !returnIndex) return object[index];
        return index;
    },

    /**
    * Count entries of a object/array
    *
    * @param obj
    * @param bool ignoreNull
    * @return int
    */
    count : function(obj, ignoreNull){
        if(!obj) return 0;
        var c = 0;
        for(var _i in obj) {
            if(ignoreNull){
                if(obj[_i] === null || obj[_i] === undefined) continue;
                c++;
            }else{
                c++;
            }
        }
        return c;
    },

    /**
    * Get selected text of the document or given element
    *
    * @param element el If set the selection must be match with this el
    * @return string or null
    */
    getSelection : function(el){
        try{
            var sel = window.getSelection();
            var range = sel.getRangeAt(0);
            var parent = range.commonAncestorContainer.nodeName.toLowerCase() == "#text" ? range.commonAncestorContainer.parentElement : range.commonAncestorContainer;
            var node = sel.anchorNode.parentNode;
            var t = '';
            if(typeof el == "undefined" || $(el).get(0) === $(parent).get(0) || $(el).has(parent).size()){
                t = document.getSelection().toString();
            }
            return t == '' ? null : t;
        }catch(e){
            return null;
        }

    },

    /**
    * Check element if its processed for given action
    *
    * @return int or null
    */
    elementCheck : function(e, action){
        var ret = e.data(action);
        e.data(action, 1);
        return ret;
    },

    plotter : {
        /**
        * Init
        */
        init : function(weapon){
            var el = $("#bblog-plot");
            var data = typeof BBLogWeapons[weapon] != "undefined" ? BBLogWeapons[weapon] : null;
            if(data && typeof data.lastupdate != "undefined"){
                var d = [data.lastupdate.substr(8, 2), data.lastupdate.substr(5, 2), data.lastupdate.substr(0, 4)];
                el.find(".update").text("Updated @ "+d.join("."));
            }
            var colors = [[255,136,0], [144, 255, 0], [0, 165, 255], [182, 0, 255]];
            el.data("colors", colors);
            el.find(".bullets div").each(function(index){
                $(this).find("span").css("background-color", "rgb("+colors[index].join(",")+")");
                $(this).append((index+1) + " Bullet");
            });
            el.find("select").on("change", function(){
                var options = el.data("options");
                if($(this).attr("class").match(/attachment/)){
                    if(typeof options["attachment"] != "object") options["attachment"] = {};
                    options["attachment"][$(this).attr("data-slot")] = $(this).val();
                }else{
                    options[$(this).attr("class")] = $(this).val();
                }
                BBLog.plotter.draw(el.data("weapon"), options);
            });
        },

        /**
        * Get html for the box
        *
        * @returns {String}
        */
        getBoxHtml : function(weapon){
            var attachments = {
                0 : BBLog.t("weapon.slot"),
                "heavybarrel" : null,
                "soundsuppressor" : null,
                "flashsuppressor" : null,
                "targetpointer" : null,
                "foregrip" : null,
                "bipod" : null,
            };
            // determine localized wordings
            $("div.profile-stats-unlock-progression-kit-item img").each(function(){
                var m = $(this).attr("src").match(/79x43\/(.*?)\.png/);
                if(!m) return true;
                var name = m[1];
                if(typeof attachments[name] != "undefined"){
                    var title = $(this).closest("[data-tooltip]").attr("data-tooltip").match(/(.*?)</)[1];
                    attachments[name] = title;
                }
            });
            switch(weapon){
                case "g17c":
                    attachments["targetpointer"] = "Laserpointer";
                    attachments["soundsuppressor"] = "Suppressor";
                    break;
                case "g18":
                case "m9":
                case "m1911":
                case "mp443":
                    attachments["soundsuppressor"] = "Suppressor";
                    break;
                case "m27-iar":
                case "m249":
                case "m240b":
                case "m60e4":
                case "pkp-pecheneg":
                case "rpk-74m":
                case "type-88-lmg":
                case "lsat":
                case "mg36":
                    attachments["bipod"] = "Bipod";
                    break;
                case "l96":
                    attachments["flashsuppressor"] = "Flashsuppressor";
                    break;
            }
            var attachmentOptions = "";
            for(var i in attachments){
                if(attachments[i] == null) continue;
                attachmentOptions += '<option value="'+i+'">'+attachments[i]+'</option>';
            }
            return '<div id="bblog-plot">\
            <div class="update"></div>\
            <div class="overlay">\
            <div class="bullets">\
            <div><span>&nbsp;</span></div>\
            <div><span>&nbsp;</span></div>\
            <div><span>&nbsp;</span></div>\
            <div><span>&nbsp;</span></div>\
            </div>\
            <div class="chooser">\
            <div>\
            <select class="attachment" data-tooltip="'+BBLog.t("weapon.slot.info")+'" data-slot="1">\
            '+attachmentOptions.replace(/{nr}/, 1)+'\
            </select>\
            </div>\
            <div>\
            <select class="attachment" data-tooltip="'+BBLog.t("weapon.slot.info")+'" data-slot="2">\
            '+attachmentOptions.replace(/{nr}/, 2)+'\
            </select>\
            </div>\
            <div>\
            <select class="aim">\
            <option value="ads">'+BBLog.t("weapon.ads")+'</option>\
            <option value="hip">'+BBLog.t("weapon.hip")+'</option>\
            </select>\
            </div>\
            <div>\
            <select class="position">\
            <option value="stand">'+BBLog.t("weapon.stand")+'</option>\
            <option value="crouch">'+BBLog.t("weapon.crouch")+'</option>\
            <option value="prone">'+BBLog.t("weapon.prone")+'</option>\
            </select>\
            </div>\
            <div>\
            <select class="action">\
            <option value="base">'+BBLog.t("weapon.base")+'</option>\
            <option value="move">'+BBLog.t("weapon.move")+'</option>\
            </select>\
            </div>\
            </div>\
            </div>\
            </div>';
        },

        /**
        * Re-Draw the plot
        */
        draw : function(weapon, options){
            var symthicWeapon = "";
            for(var i in BBLogWeapons["symthic-mapping"]){
                if(weapon == BBLogWeapons["symthic-mapping"][i]){
                    symthicWeapon = i;
                    break;
                }
            }
            if(symthicWeapon == "") symthicWeapon = weapon;
            var el = $("#bblog-plot");
            el.data("weapon", weapon);
            el.data("options", options);
            var colors = el.data("colors");
            var data = BBLogWeapons[weapon];
            var circleRadius = 4;
            var bursts = 300;
            var distanceMultiplier = 160;
            var spreadMulti = distanceMultiplier * 0.1;
            var recoilMulti = distanceMultiplier * 0.3;
            var startX = 158;
            var startY = 174;
            var spreadData = data["spread"];
            var bulletsPerBurst = 4;
            el.find("svg").remove();
            var getAttVal = function(key, slot){
                if(!options.attachment) return false;
                if(typeof BBLogWeapons["attachments"] == "undefined") return false;
                slot = typeof slot == "undefined" ? 1 : slot;
                var att = options.attachment[slot];
                if(typeof BBLogWeapons["attachments"][att] == "undefined") return false;
                if(typeof BBLogWeapons["attachments"][att][symthicWeapon] != "undefined" && typeof BBLogWeapons["attachments"][att][symthicWeapon][key] != "undefined"){
                    return BBLogWeapons["attachments"][att][symthicWeapon][key];
                }
                return false;
            };
            var dimension = [320, 260];
            var weapCont = $("#bblog-weapon-container");

            var svg = document.createElementNS("http://www.w3.org/2000/svg", "svg");
            svg.setAttribute("width", dimension[0]);
            svg.setAttribute("height", dimension[1]);

            var minSpread, minSpreadBase, maxSpread, maxSpreadBase,
                spreadInc, spreadIncBase, spreadDec, spreadDecBase,
                recoilUp, recoilUpBase, recoilLeft, recoilLeftBase, recoilRight, recoilRightBase;

            minSpread = minSpreadBase = spreadData[options.position+"-min-"+options.aim+"-"+options.action];
            // respect spread min for aim and attachment

            if(getAttVal(options.aim+"spread", 1)) minSpread = minSpreadBase = minSpread * getAttVal(options.aim+"spread", 1);
            if(getAttVal(options.aim+"spread", 2)) minSpread = minSpreadBase = minSpread * getAttVal(options.aim+"spread", 2);

            minSpread = minSpread < 0 ? 0 : minSpread;
            minSpread = parseFloat(minSpread.toPrecision(2));

            maxSpread = maxSpreadBase = 99;
            maxSpread = parseFloat(maxSpread.toPrecision(2));

            spreadInc = spreadIncBase = spreadData["inc"];
            // respect spread increase for shot - aim
            if(getAttVal("spreadinc", 1)) spreadInc = spreadIncBase = spreadInc * getAttVal("spreadinc", 1);
            if(getAttVal("spreadinc", 2)) spreadInc = spreadIncBase = spreadInc * getAttVal("spreadinc", 2);

            spreadInc = spreadInc < 0 ? 0 : spreadInc;
            spreadInc = parseFloat(spreadInc.toPrecision(2));

            spreadDec = spreadDecBase = spreadData["dec"];
            // respect spread decrease for shot - aim
            if(getAttVal("spreaddec", 1)) spreadDec = spreadDecBase = spreadDec * getAttVal("spreaddec", 1);
            if(getAttVal("spreaddec", 2)) spreadDec = spreadDecBase = spreadDec * getAttVal("spreaddec", 2);

            var rps = data["rpm"] / 60;
            var spreadDecBullet = spreadDec / rps;
            spreadDec = spreadDec < 0 ? 0 : spreadDec;
            spreadDec = parseFloat(spreadDec.toPrecision(2));

            recoilUp = recoilUpBase = data["recoil"]["u"];
            // respect recoil for attachment
            if(getAttVal("recoilup", 1)) recoilUp = recoilUpBase = recoilUp * getAttVal("recoilup", 1);
            if(getAttVal("recoilup", 2)) recoilUp = recoilUpBase = recoilUp * getAttVal("recoilup", 2);

            recoilUp = recoilUp < 0 ? 0 : recoilUp;
            recoilUp = parseFloat(recoilUp.toPrecision(2));

            recoilLeft = recoilLeftBase = data["recoil"]["l"];
            recoilRight = recoilRightBase = data["recoil"]["r"];
            // respect recoil for attachment
            if(getAttVal("recoilhorz", 1)){
                recoilLeft = recoilLeftBase = recoilLeft * getAttVal("recoilhorz", 1);
                recoilRight = recoilRightBase = recoilRight * getAttVal("recoilhorz", 1);
            }
            if(getAttVal("recoilhorz", 2)){
                recoilLeft = recoilLeftBase = recoilLeft * getAttVal("recoilhorz", 2);
                recoilRight = recoilRightBase = recoilRight * getAttVal("recoilhorz", 2);
            }
            recoilLeft = parseFloat(recoilLeft.toPrecision(2));
            recoilRight = parseFloat(recoilRight.toPrecision(2));

            weapCont.find(".spread-data-min").text(minSpread);
            weapCont.find(".spread-data-max").text(maxSpread);
            weapCont.find(".spread-data-inc").text(spreadInc);
            weapCont.find(".spread-data-dec").text(spreadDec);
            weapCont.find(".recoil-data-u").text(recoilUp);
            weapCont.find(".recoil-data-l").text(recoilLeft);
            weapCont.find(".recoil-data-r").text(recoilRight);

            var burst = function(){
                var x = startX;
                var y = startY;
                var spread = minSpread;
                x += BBLog.plotter.floatRandMax(0, spread) * spreadMulti * BBLog.plotter.getShuffleMultiplier();
                y += BBLog.plotter.floatRandMax(0, spread) * spreadMulti * BBLog.plotter.getShuffleMultiplier();
                for(var bullet = 1; bullet <= bulletsPerBurst; bullet++){
                    // add shuffle spread
                    x += BBLog.plotter.floatRandMax(0, spread) * spreadMulti * BBLog.plotter.getShuffleMultiplier();
                    y += BBLog.plotter.floatRandMax(0, spread) * spreadMulti * BBLog.plotter.getShuffleMultiplier();

                    if(x < 0 || y < 0 || x > dimension[0] || y > dimension[1]) return false;

                    // draw circle
                    var circle = document.createElementNS("http://www.w3.org/2000/svg", "circle");
                    circle.setAttribute("cx", x);
                    circle.setAttribute("cy", y);
                    circle.setAttribute("r", circleRadius);
                    circle.setAttribute("style", 'fill:rgb('+colors[bullet-1].join(",")+')');
                    svg.appendChild(circle);

                    // recoil add
                    var bulletRecoilMulti = bullet === 1 ? data["spread"]["first"] : 1;
                    if(BBLog.plotter.rand(0, 1)){
                        x -= BBLog.plotter.floatRandMax(0, recoilLeft) * recoilMulti * bulletRecoilMulti;
                    }else{
                        x += BBLog.plotter.floatRandMax(0, recoilRight) * recoilMulti * bulletRecoilMulti;
                    }

                    y -= recoilUp * recoilMulti * bulletRecoilMulti;

                    spread += spreadInc;
                    spread -= spreadDecBullet;
                    // respect spread max for aim and attachment
                    spread = Math.min(spread, maxSpread);
                }
            };
            for(var i = 0; i <= bursts; i++) burst();
            document.getElementById("bblog-plot").appendChild(svg);
        },
        /**
        * Helper func
        */
        floatRandMax : function(min, max){
            var multi = 10000000;
            return BBLog.plotter.rand(min, max*multi) / multi;
        },
        /**
        * Helper func
        */
        getShuffleMultiplier : function(){
            if(BBLog.plotter.rand(0, 1)) return 1;
            return -1;
        },
        /**
        * Helper func
        */
        rand : function(min, max){
            return Math.floor(Math.random() * (max - min + 1)) + min;
        }
    },

    /**
    * Get clean uri without parameters and anchors
    *
    * @returns string
    */
    getCleanUrl : function(){
        return window.location.href.replace(/(\#|\?).*$/ig, "");
    },

    /**
    * Get the real textarea height in pixels
    */
    getTextareaHeight : function(textarea){
        textarea = $(textarea);
        var cssCopy = ["width", "padding-left", "padding-top", "padding-bottom", "padding-right", "font-size", "font-family", "line-height", "font-variant", "font-weight", "font-style", "display"];
        var el = $('<div>');
        for(var i in cssCopy) el.css(cssCopy[i], textarea.css(cssCopy[i]));
        el.html(textarea.val().replace(/\n/g, "<br/>"));
        el = el.appendTo($("body"));
        var h = el.height();
        el.remove();
        return h;
    },

    /**
    * Play a audio file
    *
    * @return audioElement
    */
    playAudio : function(file, volume){
        var slugFile = file.replace(/[^0-9a-z]/ig, "-");
        var audioElement = $("#bblog-audio-"+slugFile);
        if(!audioElement.size()){
            $("body").append('<audio id="bblog-audio-'+slugFile+'"><source type="audio/ogg" src="'+BBLog.serviceUrl+'/ogg/'+file+'"></source></audio>');
        }
        audioElement = $("#bblog-audio-"+slugFile).get(0);
        audioElement.volume = volume / 100;
        audioElement.play();
        return audioElement;
    },

    /**
    * Check if the custom contextmenu is allowed now
    *
    * @return bool
    */
    customContextable : function(){
        if(!BBLog.storage("general.delayed.contextmenu")) return true;
        var t = new Date().getTime();
        var t2 = BBLog.cache("mousedown.time.3");
        if(t2 <= (t - 250)) return true;
        return false;
    },

    /**
    * Combine multiple arrays into one flat array
    *
    * @param array [arr1, arr2, ...]
    * @return array
    */
    combineArray : function(multiArr){
        var newArr = [];
        for(var i in multiArr){
            if(!multiArr[i]) continue;
            for(var j in multiArr[i]){
                if(!multiArr[i][j]) continue;
                newArr.push(multiArr[i][j]);
            }
        }
        return newArr;
    },

    /**
    * Show a popup
    *
    * @param {String} id
    * @param {String} title
    * @param {String} text
    * @param {String} footer
    */
    popup : function(id, title, text, footer){
        id = "popup-"+id;
        $("#dialog-container").show();
        if(!$("#"+id).size()){
            if(!$("#dialog-container .overlay-container").length) $("#dialog-container").prepend('<div class="overlay-container">');
            $("#dialog-container").show();
            $("#dialog-container").append('<div id="'+id+'" class="bblog-popup dialog"><header><a class="icon-dialog-close" href="#"></a><h3></h3></header><section class="dialog-body"></section><footer></footer></div>');
            $("#dialog-container .overlay-container").html($('<div class="overlay show" style="display:block;">').one("click", BBLog.closeAllPopups));
            $("#"+id).find(".icon-dialog-close").on("click", function(ev){
                BBLog.closeAllPopups();
                ev.stopPropagation();
                ev.preventDefault();
            })
        }
        $("#"+id+" header h3").text(title);
        $("#"+id+" section").html(text);
        if(footer) {
            $("#"+id+" footer").html(footer);
        }else{
            $("#"+id+" footer").remove();
        }
        popup.centerAndShowPopup($("#"+id));
    },

    /**
    * Close the popup
    */
    closeAllPopups : function(){
        $("#dialog-container").children("*").remove();
    },

    /**
    * Debug helper
    */
    debug : {
        elementsWithData : function(e, recursive){
            var f = function(){
                if(BBLog.count($(this).data())){
                    console.log($(this), $(this).data());
                }
                if(recursive){
                    $(this).children().each(f);
                }
            };
            $(e).children().each(f);
        },

        /**
        * Clear the whole bblog storage
        */
        clearStorage : function(){
            BBLogStorageObject = {};
            BBLog.storage("fresh", 1);
        },

        /**
        * Clear the api cache
        */
        clearAPICache : function(){
            BBLog.storage("last.api.call."+BBLog.version, 0);
        },
    }
};

// init if we must listen to the postMessage from the extension before we can init
window.addEventListener("message", function(event) {
    if(event.data && event.data.action && event.data.action == "init"){
        $._post = $.post;
        $._get = $.get;
        for(var i in event.data) window[i] = event.data[i];
        window.postMessage({
            action : "initiated"
        }, "*");
    }
}, false);

BBLog.initIVC = 0;
BBLog.initIV = setInterval(function(){
    if(typeof BBLogStorageObject != "undefined" && typeof BBLogTranslations != "undefined" && typeof S != "undefined" && typeof S.globalContext != "undefined" && typeof Surface != "undefined" && $("body").hasClass("is-loggedin")){
        clearInterval(BBLog.initIV);
        BBLog.init();
    }
    if(BBLog.initIVC++ > 500) clearInterval(BBLog.initIV);
}, 20);