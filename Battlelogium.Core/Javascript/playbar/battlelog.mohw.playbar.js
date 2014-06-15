var battlelogplaybar = {
    
    createPlaybarButton: function (elementid, label, onclick) {
        if ($('#' + elementid).length == 0) {
             var button = $("<button/>", {
                id: elementid,
                onclick: onclick,
                class: 'common-button-large main-loggedin-playbutton',
            })
            .html("<p>" + label + "</p>");
             return button;
        }
    },

    addPlaybarButton: function (playbarbutton){
        playbarbutton.appendTo($('.main-loggedin-playbar')[0])
    },

    fixQuickMatchButtons: function () {
        if ($('#btnQuickMatch').length == 0) {
            var btnQuickMatch = $("button[data-track='actionbar.quickmatch']")
               .attr('id', 'btnQuickMatch')
               .hide(0)
               .mouseover()
               .mouseout()
               .show(0); //Workaround to get the tooltip to appear
        }

        if ($('#btnQuickMatchBig').length == 0) {
            var btnQuickMatchBig = $("button[data-track='menudropdown.quickmatch']")
             .attr('id', 'btnQuickMatchBig')
             .hide(0)
             .mouseover() //Workaround to get the tooltip to appear
             .mouseout()
             .show(0);
        }

        if ($('#btnQuickMatchServerBrowser').length == 0) {
            var btnQuickMatchServerBrowser = $("button[data-track='serverbrowser.server.quickmatch']")
             .attr('id', 'btnQuickMatchServerBrowser')
             .hide(0)
             .mouseover() //Workaround to get the tooltip to appear
             .mouseout()
             .show(0);
        }

        if ($('.tooltip').find('.tooltip-body:contains("Loading")').length > 0) {
            $('.tooltip').find('.tooltip-body:contains("Loading")').parent().remove(); //Remove the tooltips
            $('#btnQuickMatchServerBrowser').load();
            $('#btnQuickMatchBig').load();
        }
    },

    fixEAPlaybarButtons: function () {
        //Fix Campaign Button
        if ($('#btnCampaign').length == 0) {
            var btnCampaign = $(".launch-campaign-button")
            btnCampaign.attr('id', 'btnCampaign')
            btnCampaign.html("<p>CAMPAIGN</p>");
        }
    }
}
