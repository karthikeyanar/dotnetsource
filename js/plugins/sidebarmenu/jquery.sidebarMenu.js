;(function($,window,document,undefined) {

    var pluginName="sidebarMenu",
        defaults={
            toggle: true
        };

    function Plugin(element,options) {
        this.element=element;
        this.settings=$.extend({},defaults,options);
        this._defaults=defaults;
        this._name=pluginName;
        this.init();
    }

    Plugin.prototype={
        init: function() {

            var $this=$(this.element),
                $toggle=this.settings.toggle;

            $this.find('li.active').has('ul').children('ul').addClass('collapse in');
            $this.find('li').not('.active').has('ul').children('ul').addClass('collapse');

            var slideSpeed=200;
            var slideOffeset= -200;

            $this.find('li').has('ul').children('a').on('click',function(e) {
                e.preventDefault();

                var $currentUL=$(this).parent('li').toggleClass('active').children('ul');
                var $body=$("body");
                if($currentUL.hasClass("in")==false) {
                    $currentUL
                    .slideDown(slideSpeed,function() {
                        $(this).addClass("in").css({
                            "display": ""
                        });
                        if($body.hasClass("page-sidebar-fixed")==false) {
                            APP.scrollTo($currentUL,slideOffeset);
                        }
                        APP.handleFixedSideBar();
                    });
                } else {
                    $currentUL
                    .slideUp(slideSpeed,function() {
                        $(this).removeClass("in").css({
                            "display": ""
                        });
                        APP.handleFixedSideBar();
                    });
                }

                if($toggle) {

                    $(this).parent('li').siblings().removeClass('active').children('ul.in')
                    .slideUp(slideSpeed,function() {
                        $(this).removeClass("in").css({
                            "display": ""
                        });
                        APP.handleFixedSideBar();
                    });
                }


            });


        }
    };

    $.fn[pluginName]=function(options) {
        return this.each(function() {
            if(!$.data(this,"plugin_"+pluginName)) {
                $.data(this,"plugin_"+pluginName,new Plugin(this,options));
            }
        });
    };

})(jQuery,window,document);
