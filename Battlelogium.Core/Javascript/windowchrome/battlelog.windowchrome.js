function createToolsButton(onclick, id) {
    var toolsButton =
    $('<li/>', {
        onclick: onclick,
        id: id + "Button"
    });

    $('<div/>', {
        class: "tools-item log " + id
    }).appendTo(toolsButton);

    return toolsButton
}

function addChromeButtons() {
    var avatarLi = $('#base-header-user-tools .tools.pull-right .comcenter-toggle.tools-item').prev(); //Insert our chrome buttons before the avatar list item. 
    var closeButton = createToolsButton("app.quit()", 'close');
    var minimizeButton = createToolsButton("app.minimize()", 'minimize');
    var reloadButton = createToolsButton("location.reload()", 'reload');

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

addChromeButtons();