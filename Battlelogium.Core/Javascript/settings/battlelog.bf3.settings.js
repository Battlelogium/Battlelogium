var battlelogsettings = {
    addSettingsSection: function () {
        if (!$('#battlelogSettings').length) {
            var checkExist = setInterval(function () {
                if ($('.profile-edit-gravatar-info').length) {
                    var section = $("<div/>")
                    section.attr('class', 'profile-edit-row')
                    section.attr('style', 'border-bottom: 1px solid #ededed;  margin-bottom: 12px;')
                    section.attr('id', 'battlelogSettings')
                    section.html('<div class="label"> <label>Battlelogium Settings</label> </div> <div> <p>Edit Battlelogium Settings</p><br><a onclick="app.opensettings()" href="#" style="margin-right: 16px;">Edit Program Settings</a><a onclick="app.clearcache()" href="#">Clear Cache and Cookies</a> </div><div style="clear:both;float:none;"></div>')
                    if (!$("label:contains('Battlelogium Settings')").length) {
                        $('.profile-edit-gravatar-info').before(section);
                    }
                    clearInterval(checkExist);
                }
            }, 1000);
        }
    }
}