var windowbutton = {
    createToolsButton: function (onclick, id) {
        var toolsButton =
        $('<li/>', {
            onclick: onclick,
            id: id + "Button"
        });

        $('<div/>', {
            class: "tools-item log " + id
        }).appendTo(toolsButton);

        return toolsButton;
    },

    addWindowButtons: function () {
        var avatarLi = $('#base-header-user-tools .tools.pull-right .comcenter-toggle.tools-item').prev(); //Insert our chrome buttons before the avatar list item. 
        var closeButton = this.createToolsButton("app.quit()", 'close');
        var minimizeButton = this.createToolsButton("app.minimize()", 'minimize');
        var reloadButton = this.createToolsButton("location.reload(true)", 'reload');

        if ($('#reloadButton').length == 0) {
            reloadButton.insertBefore(avatarLi);
        }
        if ($('#minimizeButton').length == 0) {
            minimizeButton.insertBefore(avatarLi);
        }
        if ($('#closeButton').length == 0) {
            closeButton.insertBefore(avatarLi);
        }
    }
}
