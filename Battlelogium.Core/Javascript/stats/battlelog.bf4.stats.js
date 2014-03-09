var battlelogstats = {
    overview: function () {
        if ($('#battlelogiumStats').length == 0) {
            var checkExist = setInterval(function () {
                if ($('#overview-completion').length) {
                    var e = $("#overview-completion");
                    var time = $("#stat-time-played").text();
                    var timePlayed = 0;
                    var minutes = time.match(/([0-9]+)m+/i);
                    var hours = time.match(/([0-9]+)h+/i);
                    var username = window.location.href.match(/\/soldier\/(.*?)\//)[1];
                    if (hours) timePlayed += parseInt(hours[1]) * 3600;
                    if (minutes) timePlayed += parseInt(minutes[1]) * 60;
                    var url = 'http://bf4stats.com/pc/' + username + '/bblogframe?timePlayed=' + timePlayed;
                    var c = e.clone();
                    c.removeAttr("id");
                    c.css("margin-top", "10px");
                    c.find("h1").text("Extended Player Statistics by bf4stats.com");
                    c.find(".box-content").html('<div></div><iframe src="' + url + '" style="width:100%; height:400px; overflow-x:hidden; overflow-y:auto; border:0px; margin:0px; padding:0px;" scrollbars="auto"></iframe>');
                    c.attr('id', 'battlelogiumStats');
                    if ($('#battlelogiumStats').length == 0) {
                        e.after(c);
                    }
                    clearInterval(checkExist);
                }
            }, 500);
        }
    },
}

