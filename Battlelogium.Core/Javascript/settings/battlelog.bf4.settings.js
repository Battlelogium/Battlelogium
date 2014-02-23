var battlelogsettings = {
    addSettingsSection: function () {
        if ($('#battlelogSettings').length == 0) {
            var checkExist = setInterval(function () {
                if ($('#profile-edit-row-game-launch').length) {
                    var section = $("<fieldset/>")
                    section.attr('class', 'box-content inline')
                    section.attr('id', 'battlelogSettings')
                    section.html('<div class="profile-edit-row"><label>Battlelogium Settings</label> <div class="profile-location-display"> <p class="margin-bottom">Change Battlelogium settings</p> <a onclick="app.opensettings()" href="#" style="font-size:12px;text-decoration: underline;margin-right: 16px;line-height: 40px;">Edit Program Settings</a><a onclick="app.clearcache()" href="#" style="font-size: 12px;text-decoration: underline;  margin-right: 16px;line-height: 40px;">Clear Cache and Cookies</a></div></div>')
                    section.insertBefore($(".box-content.inline")[0])
                    clearInterval(checkExist);
                }
            }, 500);
        }
    }
}
