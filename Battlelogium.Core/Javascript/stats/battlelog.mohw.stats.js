var battlelogstats = {
    overview: function () {
        if ($('#battlelogiumStats').length == 0) {
            var checkExist = setInterval(function () {
                if ($('.profile-venicestats-overview-boxwideclean:last').length) {
                    var e = $(".profile-venicestats-overview-boxwideclean:last");
                    var time = $(".profile-venicestats-overview-highlight-stat-value").text();
                    var timePlayed = 0;
                    var minutes = time.match(/([0-9]+)m+/i);
                    var hours = time.match(/([0-9]+)h+/i);
                    var username = window.location.href.match(/\/soldier\/(.*?)\//)[1];
                    if (hours) timePlayed += parseInt(hours[1]) * 3600;
                    if (minutes) timePlayed += parseInt(minutes[1]) * 60;
                    var url = 'http://mohwstats.com/stats_pc/' + username + '/battlelog_frame?timePlayed=' + timePlayed;
                    var c = e.clone();
                    c.removeClass("profile-venicestats-overview-boxwideclean");
                    c.find(".common-box-title").text("Extended Player Statistics by mohwstats.com");
                    c.find(".common-box-inner").html('<div style="padding-top:10px;"></div><iframe src="' + url + '" style="width:100%; height:600px; overflow-x:hidden; overflow-y:hidden; border:0px; margin:0px; padding:0px;" scrollbars="no"></iframe>');
                    c.attr('id', 'battlelogiumStats');
                    if ($('#battlelogiumStats').length == 0) {
                        e.after(c);
                    }
                    e.css("margin-bottom", "10px");
                    clearInterval(checkExist);
                }
            }, 500);
       }
    }
}