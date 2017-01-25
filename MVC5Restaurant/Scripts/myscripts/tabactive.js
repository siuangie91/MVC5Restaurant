var TabActive = TabActive || {};

TabActive = function () {
    var props = {
        url: window.location.href.split("/"),
        tabs: $('.navbar-static-top .nav>li>a')
    };

    var makeActive = function (path) {
        if (props.url.indexOf(path) > -1) {
            $('a[href="/' + path + '"]').addClass('active');
        }
    };

    var loopThroughTabs = function () {
        for (var i = 0; i < props.tabs.length; i++) {
            var thePath = props.tabs.eq(i).attr('href').substring(1);

            makeActive(thePath);
        }
    };

    this.init = function () {
        loopThroughTabs();
    }
};

var activateTabActive = new TabActive();
activateTabActive.init();