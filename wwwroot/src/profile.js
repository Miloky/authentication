var Profile = Profile || { __namespace: true }
Profile.View = Profile.View || {};


Profile.View = {
    init: function () {
        this.navEvents();
    },

    navEvents: function () {
        Profile.Data.tabs.forEach(function(selector) {
            $(selector).on("click",
                function() {
                    console.log(selector);
                });
        });
    }
}

Profile.Data = {
    tabs: ["#profile-tab", "change-password-tab", "change-email-tab", "manage-authentication-tab"]
};

document.addEventListener("DOMContentLoaded", function () {
    Profile.View.init();
});