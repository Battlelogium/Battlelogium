var battlelogplaybar = {

    createPlaybarButton: function (elementid, label, href, btnclass) {
        if ($('#' + elementid).length == 0) {
            var button = $("<a/>", {
                id: elementid,
                href: href,
                class: 'btn ' + btnclass,
            })
           .html(label);
            return button;
        }
    },

    addPlaybarButton: function (playbarbutton) {
        playbarbutton.appendTo($('.playbar')[0]);
    },

    fixEAPlaybarButtons: function () {
        //Fix Co-Op Button
        if ($('#btnMulti').length == 0) {
            var btnMulti = $('a.btn:not(".btn-block")[href="/bf4/servers/playnow/"]')
            btnMulti.attr('id', 'btnMulti');
            btnMulti.html("MULTIPLAYER");
        }

        //Fix Campaign Button
        if ($('#btnCampaign').length == 0) {
            var btnCampaign = $('a.btn[href="/bf4/campaign/"]')
            btnCampaign.attr('id', 'btnCampaign')
            btnCampaign.html("CAMPAIGN");
        }
    }
}
