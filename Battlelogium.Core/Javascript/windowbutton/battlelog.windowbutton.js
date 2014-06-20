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
    toggleMaximizeButton: function () {
        if (app.ismaximized) {
            app.restore();
        } else {
            app.maximize();
        }
    },
    updateMaximizeButton: function(){
        if (app.ismaximized) {
            $('#maximizeButton div').addClass('restore')
        } else {
            $('#maximizeButton div').removeClass('restore')
        }
    },
    addWindowButtons: function () {
        var avatarLi = $('#base-header-user-tools .tools.pull-right .comcenter-toggle.tools-item').prev(); //Insert our chrome buttons before the avatar list item. 
        var closeButton = this.createToolsButton("app.quit()", 'close');
        var minimizeButton = this.createToolsButton("app.minimize()", 'minimize');
        var reloadButton = this.createToolsButton("location.reload(true)", 'reload');
        var maximizeButton = this.createToolsButton("windowbutton.toggleMaximizeButton()", 'maximize');


        if ($('#reloadButton').length == 0) {
            reloadButton.insertBefore(avatarLi);
        }
        if ($('#minimizeButton').length == 0) {
            minimizeButton.insertBefore(avatarLi);
        }
        if ($('#maximizeButton').length == 0) {
            maximizeButton.insertBefore(avatarLi);
        }
        if ($('#closeButton').length == 0) {
            closeButton.insertBefore(avatarLi);
        }
    }
}
