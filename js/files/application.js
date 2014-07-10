function Application() {

    var self = this;

    this.themesPath = "/css/themes/";

    // IE mode
    this._IsIE8 = false;
    this._IsIE9 = false;
    this._IsIE10 = false;

    this.isIE8 = function () {
        return self._IsIE8;
    };

    this.isIE9 = function () {
        return self._IsIE9;
    };

    this.isIE10 = function () {
        return self._IsIE10;
    };

    this.getViewPort = function () {
        var e = window, a = 'inner';
        if (!('innerWidth' in window)) {
            a = 'client';
            e = document.documentElement || document.body;
        }
        return {
            width: e[a + 'Width'],
            height: e[a + 'Height']
        }
    };

    this.isTouchDevice = function () {
        return ('ontouchstart' in document.documentElement);
    };

    this.isExtraSmallDevice = function () {
        var width = this.getViewPort().width;
        return (width < 768);
    };

    this.isSmallDevice = function () {
        var width = this.getViewPort().width;
        return (width >= 768 && width < 992);
    };

    this.isMediumDevice = function () {
        var width = this.getViewPort().width;
        return (width >= 992 && width < 1200);
    };

    this.isLargeDevice = function () {
        var width = this.getViewPort().width;
        return (width >= 1200);
    };

    this.isLTSmallDevice = function () {
        var width = this.getViewPort().width;
        return (width <= 991);
    };

    this.isGTSmallDevice = function () {
        var width = this.getViewPort().width;
        return (width >= 992);
    };

    this.scrollTo = function (el, offeset) {
        pos = el ? el.offset().top : 0;
        $('html,body').animate({
            scrollTop: pos + (offeset ? offeset : 0)
        }, 'slow');
    };

    this.scrollTop = function () {
        self.scrollTo();
    }

    this.responsiveHandlers = [];

    this.addResponsiveHandler = function (func) {
        this.responsiveHandlers.push(func);
    };


    this.chartToolTip = function (x, y, contents) {
        $('<div id="tooltip" class="chart-tooltip tooltip"><div class="tooltip-arrow"></div><div class="tooltip-inner">' + contents + '</div></div>').css({
            top: y - 43,
            left: x - 15
        }).appendTo("body").fadeIn(200);
    };


    this.handleMetroCheck = function (filter) {
        var $elements;
        if (filter)
            $elements = $('.fancy-checkbox,.fancy-radio', filter);
        else
            $elements = $('.fancy-checkbox,.fancy-radio');

        $elements.each(function () {
            var $this = $(this);
            var $check = $(".check", $this);
            if (!$check.get(0))
                $("input", $this).after("<span class='check'></span>");
        });
    };


    this.handleBreadcrumb = function () {
        // dismiss breadcrumb
        $(document).on('click.breadcrumb.data-api', "[data-dismiss='breadcrumb']", function () {
            var $breadcrumb = $(this).parents(".breadcrumb:first");
            $breadcrumb.fadeOut();
        });
    };

    this.handleFormValidation = function () {
        if ($.fn.validate) {
            $(".form-validate").validate({
                ignore: "input[type='text']:hidden"
            });
        }
    };

    this.handleToolTip = function () {
        $("[data-toggle='tooltip']").tooltip();
        $("[rel='tooltip']").tooltip();
    };

    this.handlePopover = function () {
        $("[data-toggle='popover']").popover();
    };

    this.handlePanelTools = function () {

        $('body').on('click.panel > .btn-group > a', "[data-action='collapse']", function (e) {
            e.preventDefault();
            var el = $(this).closest(".panel").children(".panel-body");
            if ($(this).hasClass("expand") == false) {
                $(this).addClass("expand");
                el.slideUp(200);
            } else {
                $(this).removeClass("expand");
                el.slideDown(200);
            }
        });

        $('body').on('click.panel > .btn-group > a', "[data-action='remove']", function (e) {
            e.preventDefault();
            $(this).closest(".panel").remove();
        });
    };

    this.handleDropdowns = function () {
        $('body')
		.on('click', '.dropdown-menu.hold-on-click', function (e) {
		    e.stopPropagation();
		})
    };

    this.handleBootstrapSelect = function ($target) {
        if ($.fn.selectpicker) {
            var $filter = $('.selectpicker')
            if ($target) {
                $filter = $('.selectpicker', $target);
            }
            $filter.selectpicker();
        }
    };

    this.handleSwitch = function ($target) {
        if ($.fn.bootstrapSwitch) {
            var $filter = $('.switch')
            if ($target) {
                $filter = $('.switch', $target);
            }
            $filter.bootstrapSwitch();
        }
    };

    this.handleSlider = function ($target) {
        if ($.fn.slider) {
            var $filter = $('.slider')
            if ($target) {
                $filter = $('.slider', $target);
            }
            $filter.slider();
        }
    };

    this.resizeContentHeight = function () {
        var $body = $('body');
        var $header = $('.header');
        var $footer = $('.footer');
        var $pageContainer = $('.page-container');
        var $pageContent = $('.page-content', $pageContainer);
        var $pageSidebar = $('.page-sidebar-left', $pageContainer);

        var windowHeight = this.getViewPort().height;
        var headerHeight = $header.outerHeight(true);
        var footerHeight = $footer.outerHeight(true);
        var pageSidebarHeight = $pageSidebar.outerHeight(true);
        var height = 0;

        if ($body.hasClass("page-sidebar-fixed")) {
            height = windowHeight - headerHeight - footerHeight;
        } else {
            if (this.getViewPort().width < 992) {
                height = windowHeight - headerHeight - footerHeight;
            } else {
                height = pageSidebarHeight + 20;
            }
            if (this.getViewPort().width > 1024 && (height + headerHeight + footerHeight) < windowHeight) {
                height = windowHeight - headerHeight - footerHeight;
            }
        }
        $pageContent.css({ 'min-height': height + 'px' });
    };

    this.responsive = function () {
        // reinitialize other subscribed elements
        for (var i in self.responsiveHandlers) {
            var each = self.responsiveHandlers[i];
            each.call();
        }
    };

    this.closeSidebar = function () {
        var $body = $("body");
        $body.removeClass("page-sidebar-left-open");
    };

    this.openSidebar = function () {
        var $body = $("body");
        var $pageContentOverlay = $(".page-content-overlay");
        if (!$pageContentOverlay.get(0)) {
            $pageContentOverlay = $("<div class='page-content-overlay'></div>");
            $(".page-container").append($pageContentOverlay);
            $pageContentOverlay.unbind("click").click(function () {
                self.closeSidebar();
            });
        }
        $body.toggleClass("page-sidebar-left-open");
    };

    this.handleSidebar = function () {
        var $body = $("body");
        var $header = $(".header");
        var $pageSidebar = $(".page-sidebar");
        var $sidebarContent = $(".sidebar-content", $pageSidebar);
        var $pageSidebarMenu = $(".page-sidebar-menu", $pageSidebar);
        var $pageSidebarSearch = $(".page-sidebar-search");
        var $pageContent = $(".page-content");

        var $toggle = true;
        var slideSpeed = 200;
        var slideOffeset = -200;


        $pageSidebarMenu.find('li.open').has('ul').children('ul').addClass('collapse in');
        $pageSidebarMenu.find('li').not('.open').has('ul').children('ul').addClass('collapse');

        $pageSidebarMenu.children('li').off('mouseenter').off('mouseleave');
        $pageSidebarMenu.find('li').has('ul').children('a').off('click').on('click', function (e) {
            e.preventDefault();
            var $this = $(this);
            window.console.log("page sidebar menu expand");
            var $currentUL = $(this).parent('li').toggleClass('open').children('ul');
            var $body = $("body");
            if ($currentUL.hasClass("in") == false) {
                $currentUL.slideDown(slideSpeed, function () {
                    $(this).addClass("in").css({
                        "display": ""
                    });
                    if ($body.hasClass("page-sidebar-small") == false) {
                        if (self.isGTSmallDevice()) {
                            if ($body.hasClass("page-sidebar-fixed") == false) {
                                self.scrollTo($this, slideOffeset);
                            } else {
                                $sidebarContent.slimScroll({ 'scrollTo': ($this.position()).top });
                            }
                        }
                    }
                    self.resizeContentHeight();
                });
            } else {
                $currentUL.slideUp(slideSpeed, function () {
                    $(this).removeClass("in").css({
                        "display": ""
                    });
                    if ($body.hasClass("page-sidebar-small") == false) {
                        if (self.isGTSmallDevice()) {
                            if ($body.hasClass("page-sidebar-fixed") == false) {
                                self.scrollTo($this, slideOffeset);
                            } else {
                                $sidebarContent.slimScroll({ 'scrollTo': ($this.position()).top });
                            }
                        }
                    }
                    self.resizeContentHeight();
                });
            }

            if ($toggle) {
                $(this).parent('li').siblings().removeClass('open').children('ul.in').slideUp(slideSpeed, function () {
                    $(this).removeClass("in").css({
                        "display": ""
                    });
                    self.resizeContentHeight();
                });
            }
        });
        $pageSidebar.off("mouseenter").off("mouseleave");
        if ($body.hasClass("page-sidebar-fixed") && $body.hasClass("page-sidebar-small-fixed")) {
            $pageSidebar.on('mouseenter', function () {
                if ($body.hasClass("page-sidebar-fixed")) {
                    $body.removeClass("page-sidebar-small");
                }
            }).on('mouseleave', function () {
                if ($body.hasClass("page-sidebar-fixed")) {
                    $body.addClass("page-sidebar-small");
                }
            });
        }
        if ($body.hasClass("page-sidebar-fixed") &&
            $body.hasClass("page-sidebar-medium-fixed")) {
            $pageSidebar.on('mouseenter', function () {
                if ($body.hasClass("page-sidebar-fixed")) {
                    $body.removeClass("page-sidebar-medium");
                }
            }).on('mouseleave', function () {
                if ($body.hasClass("page-sidebar-fixed")) {
                    $body.addClass("page-sidebar-medium");
                }
            });
        }
        $pageSidebarMenu.children('li').off('mouseenter').off('mouseleave');
        if ($body.hasClass("page-sidebar-fixed") == false && ($body.hasClass("page-sidebar-small") || $body.hasClass("page-sidebar-medium"))) {

            $pageSidebarMenu
            .children('li')
			.on('mouseleave', function (e) {
			    e.preventDefault();
			    $(this)
			    .removeClass('open')
			    .removeClass('hover')
			    .children('ul.in').removeClass("in").css({
			        "display": ""
			    });
			})
			.on('mouseenter', function (e) {
			    var $this = $(this).removeClass("pull-up");
			    var $currentUL = $this.addClass('open hover')
										.children('ul')
										.addClass("in").css({
										    "display": ""
										})
										.css("top", "");
			    if (!$currentUL.get(0)) {
			        $this.addClass("no-submenu")
			    } else {
			        $this.removeClass("no-submenu")
			    }
			    var $menuText = $(".menu-text", $currentUL.parent()).css("top", "");

			    var offset = $this.offset();
			    var windowHeight = document.documentElement.clientHeight;
			    var scrollY = document.documentElement.scrollTop || document.body.scrollTop;
			    windowHeight += scrollY;
			    var menuTogglePositon = offset.top;
			    var menuToggleHeight = $this.innerHeight();
			    var menuHeight = $currentUL.innerHeight();
			    var headerHeight = $(".header").innerHeight();
			    var footerHeight = $(".footer").innerHeight();
			    var availbleHeight = windowHeight - headerHeight - menuTogglePositon;
			    var menuTop = 0;
			    var menuTextTop = 0;
			    if (availbleHeight < (menuHeight)) {
			        menuTextTop = (menuHeight) - availbleHeight;
			        if (menuTextTop > menuTogglePositon) {
			            menuTextTop = (menuTogglePositon - headerHeight - 5);
			        }
			        menuTop = (menuTextTop - menuToggleHeight) * -1;
			        if (menuTextTop > menuToggleHeight) {
			            $this.addClass("pull-up");
			        }
			        menuTextTop = menuTextTop * -1;
			    } else {
			        menuTextTop = 0;
			        menuTop = menuToggleHeight;
			    }
			    if ($body.hasClass("page-sidebar-medium")) {
			        menuTop -= menuToggleHeight;
			    }
			    $currentUL.css("top", menuTop);
			    $menuText.css("top", menuTextTop);
			    $(this).siblings()
				.removeClass('open')
				.removeClass('hover')
				.children('ul.in').removeClass("in").css({
				    "display": ""
				});
			});
        }

        if ($body.hasClass("page-sidebar-fixed")
			&& $body.hasClass("header-fixed") == false) {
            $pageSidebar.autofix_anything({ "onlyInContainer": false, "manualCSS": true });
        } else {
            $pageSidebar.removeClass("autofix_sb").removeClass("fixed");
        }

        if ($.fn.slimScroll) {
            var windowHeight = $(window).height();
            if ($sidebarContent.parent('.slimScrollDiv').size() === 1) { // destroy existing instance  
                $sidebarContent
                .slimScroll({
                    destroy: true
                });
                $sidebarContent.css({
                    'height': '', 'overflow': '', 'width': ''
                });
            }
            if ($body.hasClass("page-sidebar-fixed")) {
                var height = windowHeight - $header.outerHeight(true);
                $sidebarContent
                .slimScroll({
                    allowPageScroll: true,
                    size: '5px',
                    borderRadius: '0px',
                    railBorderRadius: '0px',
                    wrapperClass: 'slimScrollDiv',
                    position: 'right',
                    height: height,
                    color: ($sidebarContent.attr("data-scroll-handle-color") ? $sidebarContent.attr("data-scroll-handle-color") : '#000'),
                    railColor: ($sidebarContent.attr("data-scroll-rail-color") ? $sidebarContent.attr("data-scroll-rail-color") : '#333'),
                    railOpacity: ($sidebarContent.attr("data-scroll-rail-color") ? $sidebarContent.attr("data-scroll-rail-opacity") : '.2'),
                    opacity: ($sidebarContent.attr("data-scroll-handle-color") ? $sidebarContent.attr("data-scroll-handle-opacity") : '.4'),
                    disableFadeOut: true
                });
            }
        }
        self.resizeContentHeight();
    };

    this.handleHorizontalMenu = function () {
        var $header = $(".header");
        var $horMenu = $(".hor-menu", $header);
        if (this.isTouchDevice() == true) {
            $horMenu.find('.dropdown-menu').click(function (e) {
                e.stopPropagation();
            });
            // handle submenus
            $horMenu.find('.dropdown-submenu').each(function () {
                var $this = $(this);
                var subTimeout;
                $this.click(function () {
                    $this.toggleClass("open");
                });
            });
        }
    };

    this.jqValidationSetDefaults = function () {
        if ($.validator) {
            $.validator.setDefaults({
                highlight: function (element) {
                    $(element).closest('.form-group').addClass('has-error');
                },
                unhighlight: function (element) {
                    $(element).closest('.form-group').removeClass('has-error');
                },
                errorElement: 'span',
                errorClass: 'help-block',
                errorPlacement: function (error, element) {
                    if (element.closest('.input-group').size() === 1) {
                        error.insertAfter(element.closest('.input-group'));
                    } else if (element.closest('.input-icon').size() === 1) {
                        error.insertAfter(element.closest('.input-icon'));
                    } else if (element.closest('.select-group').size() === 1) {
                        error.insertAfter(element.closest('.select-group'));
                    } else {
                        error.insertAfter(element);
                    }
                }
            });
        }
    };


    this.isHeaderFixed = false;
    this.isSidebarFixed = false;
    this.isFixedLayout = false;

    this.changeLayout = function () {
        self.applyLayoutClasses();
        self.handleSidebar();
        self.responsive();
    };

    this.applyLayoutClasses = function () {
        var $body = $("body");
        var $header = $(".header");
        var $headerContent = $(".header-content", $header);
        var $pageContainer = $(".page-container");
        if (this.isHeaderFixed) {
            $body.addClass("header-fixed");
            $header.addClass("navbar-fixed-top");
        } else {
            $body.removeClass("header-fixed");
            $header.removeClass("navbar-fixed-top");
        }
        if (this.isSidebarFixed) {
            $body.addClass("page-sidebar-fixed");
            if ($body.hasClass("page-sidebar-small"))
                $body.addClass("page-sidebar-small-fixed")
            else if ($body.hasClass("page-sidebar-medium"))
                $body.addClass("page-sidebar-medium-fixed")
        } else {
            $body.removeClass("page-sidebar-fixed");
        }

        if (this.isFixedLayout) {
            $body.addClass("page-boxed");
            $headerContent.addClass("container").removeClass("container-fluid");
            $pageContainer.addClass("container").removeClass("container-fluid");
        } else {
            $headerContent.removeClass("container").addClass("container-fluid");
            $pageContainer.removeClass("container").addClass("container-fluid");
        }
    };

    this.initSettings = function () {
        var $body = $("body");
        var $header = $(".header");
        if ($body.hasClass("header-fixed")) {
            this.isHeaderFixed = true;
            $header.addClass("navbar-fixed-top");
        } else {
            $header.removeClass("navbar-fixed-top");
        }
        this.isSidebarFixed = $body.hasClass("page-sidebar-fixed");
        this.isFixedLayout = $body.hasClass("page-boxed");
    }

    this.setTheme = function (themeName) {
        $('#theme-link').attr("href", this.themesPath + themeName + ".css?v=1.0");
    }

    this.themePanelSettings = function () {
        var $themePanel = $(".theme-panel");
        if (!$themePanel.get(0)) return;

        $(".toggler", $themePanel).click(function () {
            $(".theme-options", $themePanel).toggleClass("open");
        });

        var $chkHeader = $("#chkheader", $themePanel);
        var $chkSidebar = $("#chksidebar", $themePanel);
        var $chkLayout = $("#chklayout", $themePanel);

        $chkLayout.get(0).checked = APP.isFixedLayout;
        $chkHeader.get(0).checked = APP.isHeaderFixed;
        $chkSidebar.get(0).checked = APP.isSidebarFixed;

        $chkLayout
		.click(function () {
		    APP.isFixedLayout = this.checked;
		    APP.changeLayout();
		});

        $chkHeader
		.click(function () {
		    APP.isHeaderFixed = this.checked;
		    APP.changeLayout();
		});

        $chkSidebar
		.click(function () {
		    APP.isSidebarFixed = this.checked;
		    APP.changeLayout();
		});

        $(".theme-group", $themePanel).find("a").click(function () {
            var $this = $(this);
            $this.parent().siblings().removeClass("select");
            $this.parent().addClass("select");
            self.setTheme($this.attr("data-theme-name"));
        });
    }

    this.init = function () {
        self._IsIE8 = !!navigator.userAgent.match(/MSIE 8.0/);
        self._IsIE9 = !!navigator.userAgent.match(/MSIE 9.0/);
        self._IsIE10 = !!navigator.userAgent.match(/MSIE 10.0/);

        self.initSettings();
        self.applyLayoutClasses();
        self.themePanelSettings();

        self.jqValidationSetDefaults();
        self.handleFormValidation();
        self.handleToolTip();
        self.handlePopover();

        self.handlePanelTools();
        self.handleDropdowns();
        self.handleBootstrapSelect();
        self.handleSwitch();
        self.handleSlider();
        self.handleMetroCheck();

        self.handleSidebar();
        self.handleHorizontalMenu();

        $("body").addClass("sidebar-animation");

        $("[data-action='page-sidebar-small-toggle']")
        .on("click", function () {
            var $body = $("body");
            if ($body.hasClass("page-sidebar-fixed")) {
                $body.toggleClass("page-sidebar-small-fixed");
                if ($body.hasClass("page-sidebar-small-fixed"))
                    $body.addClass("page-sidebar-small");
                else
                    $body.removeClass("page-sidebar-small");
            } else {
                $body.toggleClass("page-sidebar-small");
            }
            self.handleSidebar();
        });
        $("[data-action='page-sidebar-medium-toggle']")
        .on("click", function () {
            var $body = $("body");
            if ($body.hasClass("page-sidebar-fixed")) {
                $body.toggleClass("page-sidebar-medium-fixed");
                if ($body.hasClass("page-sidebar-medium-fixed"))
                    $body.addClass("page-sidebar-medium");
                else
                    $body.removeClass("page-sidebar-medium");
            } else {
                $body.toggleClass("page-sidebar-medium");
            }
            self.handleSidebar();
        });

        $("[data-action='page-sidebar-toggle']")
        .on('touchend', function (e) {
            self.openSidebar();
            e.preventDefault();
        })
        .click(function (e) {
            self.openSidebar();
            e.preventDefault();
            e.stopPropagation();
        });

        $("#open-search")
        .on("click", function () {
            $pageSidebarSearch.addClass("open");
        });
        $("#close-search")
        .on("click", function () {
            $pageSidebarSearch.removeClass("open");
        });

    };
}

var APP = new Application();

$(function () {
    APP.init();
});

$(window).resize(function () {
    APP.handleSidebar();
    APP.responsive();
});