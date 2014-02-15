var battlelogstats = {

    overview: function () {
        //window.location.href.match(/\/soldier\//))
        var e = $(".profile-venicestats-overview-boxwideclean:last");
        var time = $(".profile-venicestats-overview-highlight-stat-value").text();
        var timePlayed = 0;
        var minutes = time.match(/([0-9]+)m+/i);
        var hours = time.match(/([0-9]+)h+/i);
        var username = window.location.href.match(/\/soldier\/(.*?)\//)[1];
        if (hours) timePlayed += parseInt(hours[1]) * 3600;
        if (minutes) timePlayed += parseInt(minutes[1]) * 60;
        var url = 'http://bf3stats.com/stats_pc/' + username + '/battlelog_frame?timePlayed=' + timePlayed;
        var c = e.clone();
        c.removeClass("profile-venicestats-overview-boxwideclean");
        c.find(".common-box-title").text("Extended Player Statistics by bf3stats.com");
        c.find(".common-box-inner").html('<div style="padding-top:10px;"></div><iframe src="' + url + '" style="width:100%; height:600px; overflow-x:hidden; overflow-y:hidden; border:0px; margin:0px; padding:0px;" scrollbars="no"></iframe>');
        e.after(c);
        e.css("margin-bottom", "10px");
    },
    weapons: function () {
        //window.location.href.match(/\/soldier\/.*?\/weapons\//)
        var e = $("#profile-stats-weapons-statistics");
        var soldierInfo = $("div.profile-venicestats-header-soldier-info:first");
        var soldier = soldierInfo.find(".profile-venicestats-header-soldier-info-name span").text();
        var d = { "player": decodeURIComponent(soldier), "opt": "clear,ranking,weapons,weaponsRanking" };
        $._post("http://api.bf3stats.com/pc/" + "/player/", d, function (data) {
            var entries = e.find("tr.filterByKit");
            data = JSON.parse(data);
            entries.each(function () {
                var weapon = $(this).find("a:first").attr("href").match(/iteminfo\/(.*?)\//)[1];
                var bf3Weapon = BBLog.getBf3StatsMapName(weapon);
                if (bf3Weapon && typeof data["stats"]["weapons"][bf3Weapon] != "undefined" && typeof data["stats"]["weapons"][bf3Weapon]["c"] != "undefined") {
                    var wd = data["stats"]["weapons"][bf3Weapon];
                    var perc = Math.ceil((wd.r / wd.c) * 100);
                    var startR = Math.ceil(wd.r / 100) * 100;
                    var el = $('<div class="bf3stats-top disabled"><span class="profile-select-view-image stats"></span>Top ' + perc + '%</div>');
                    el.attr("data-tooltip", '<span class="bblog-tt-top-bf3stats">' + "This show the worldwide kill rank for this item.<br\/>Smaller value is better than larger.<br\/>Note: Only items with 100 kills or more ranked.<br\/><b>Rank: {place} of {all}<\/b>".replace(/\{place\}/, wd.r).replace(/\{all\}/, wd.c) + '<br/>by bf3stats.com</span>');
                    $(this).find(".item-kills .item-object").prepend(el);
                }
            });
        });
    },
    getBf3StatsMapName: function (weapon) {
        if (weapon == "acb-90") weapon = "knife";
        for (var i in BBLogWeapons["bf3stats-mapping"]) {
            if (BBLogWeapons["bf3stats-mapping"][i] == weapon) {
                return i;
            }
        }
        return null;
    },

}