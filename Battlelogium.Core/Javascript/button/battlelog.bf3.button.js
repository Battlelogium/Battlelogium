function addPlaybarButton(elementid, label, tooltip, onclick) {
    if ($('#' + elementid).length == 0) {
        $("<button/>", {
            id: elementid,
            onclick: onclick,
            class: 'common-button-large main-loggedin-playbutton',
            'data-tooltip': tooltip
        })
        .html("<p>" + label + "</p>")
        .appendTo($('.main-loggedin-playbar')[0]);
    }
}

function fixQuickMatchButtons() {
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
        $('.tooltip').find('.tooltip-body:contains("Loading")').html("Play a Quick Match");
        $('#btnQuickMatchServerBrowser').load();
        $('#btnQuickMatchBig').load();
    }
}

function fixEAPlaybarButtons() {

    //Fix Co-Op Button
    if ($('#btnCoOp').length == 0) {
        var btnCoOp = $("button[data-track='actionbar.coop']")
        btnCoOp.attr('id', 'btnCoOp');
        btnCoOp.attr('data-tooltip', 'Play a Co-Op Match');
        btnCoOp.html("<p>CO-OP</p>");
    }

    //Fix Campaign Button
    if ($('#btnCampaign').length == 0) {
        var btnCampaign = $("button[data-track='actionbar.campaign']")
        btnCampaign.attr('id', 'btnCampaign')
        btnCampaign.attr('data-tooltip', 'Play Campaign Mode');
        btnCampaign.html("<p>CAMPAIGN</p>");
    }
}
