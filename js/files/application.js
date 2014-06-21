function Application() {

	var self=this;

	// IE mode
	this._IsIE8=false;
	this._IsIE9=false;
	this._IsIE10=false;

	this.isIE8=function() {
		return self._IsIE8;
	};

	this.isIE9=function() {
		return self._IsIE9;
	};

	this.isIE10=function() {
		return self._IsIE10;
	};

	this.isTouchDevice=function() {
		return ('ontouchstart' in document.documentElement);
	};

	this.isExtraSmallDevice=function() {
		return ($(window).width()<768);
	};

	this.isSmallDevice=function() {
		return ($(window).width()>=768&&$(window).width()<992);
	};

	this.isMediumDevice=function() {
		return ($(window).width()>=992&&$(window).width()<1200);
	};

	this.isLargeDevice=function() {
		return ($(window).width()>=1200);
	};

	this.isLTSmallDevice=function() {
		return ($(window).width()<=1024);
	};

	this.isGTSmallDevice=function() {
		return ($(window).width()>992);
	};

	this.scrollTo=function(el,offeset) {
		pos=el?el.offset().top:0;
		$('html,body').animate({
			scrollTop: pos+(offeset?offeset:0)
		},'slow');
	};

	this.scrollTop=function() {
		self.scrollTo();
	}

	this.responsiveHandlers=[];
	this.runResponsiveHandlers=function() {
		// reinitialize other subscribed elements
		for(var i in self.responsiveHandlers) {
			var each=self.responsiveHandlers[i];
			each.call();
		}
	};

	this.addResponsiveHandler=function(func) {
		this.responsiveHandlers.push(func);
	};


	this.chartToolTip=function(x,y,contents) {
		$('<div id="tooltip" class="chart-tooltip tooltip"><div class="tooltip-arrow"></div><div class="tooltip-inner">'+contents+'</div></div>').css({
			top: y-43,
			left: x-15
		}).appendTo("body").fadeIn(200);
	};


	this.handleMetroCheck=function(filter) {
		var $elements;
		if(filter)
			$elements=$('.metro-checkbox,.metro-radio',filter);
		else
			$elements=$('.metro-checkbox,.metro-radio');

		$elements.each(function() {
			var $this=$(this);
			var $check=$(".check",$this);
			if(!$check.get(0))
				$("input",$this).after("<span class='check'></span>");
		});
	};


	this.handleBreadcrumb=function() {
		// dismiss breadcrumb
		$(document).on('click.breadcrumb.data-api',"[data-dismiss='breadcrumb']",function() {
			var $breadcrumb=$(this).parents(".breadcrumb:first");
			$breadcrumb.fadeOut();
		});
	};

	this.handleFormValidation=function() {
		if($.fn.validate) {
			$(".form-validate").validate({
				ignore: "input[type='text']:hidden"
			});
		}
	};

	this.handleToolTip=function() {
		$("[data-toggle='tooltip']").tooltip();
		$("[rel='tooltip']").tooltip();
	};

	this.handlePopover=function() {
		$("[data-toggle='popover']").popover();
	};

	this.handlePanelTools=function() {

		$('body').on('click.panel > .btn-group > a',"[data-action='collapse']",function(e) {
			e.preventDefault();
			var el=$(this).closest(".panel").children(".panel-body");
			if($(this).hasClass("expand")==false) {
				$(this).addClass("expand");
				el.slideUp(200);
			} else {
				$(this).removeClass("expand");
				el.slideDown(200);
			}
		});

		$('body').on('click.panel > .btn-group > a',"[data-action='remove']",function(e) {
			e.preventDefault();
			$(this).closest(".panel").remove();
		});
	};

	this.handleDropdowns=function() {
		$('body')
		.on('click','.dropdown-menu.hold-on-click',function(e) {
			e.stopPropagation();
		})
	};

	this.handleBootstrapSelect=function($target) {
		if($.fn.selectpicker) {
			var $filter=$('.selectpicker')
			if($target) {
				$filter=$('.selectpicker',$target);
			}
			$filter.selectpicker();
		}
	};

	this.handleSwitch=function($target) {
		if($.fn.bootstrapSwitch) {
			var $filter=$('.switch')
			if($target) {
				$filter=$('.switch',$target);
			}
			$filter.bootstrapSwitch();
		}
	};

	this.handleSlider=function($target) {
		if($.fn.slider) {
			var $filter=$('.slider')
			if($target) {
				$filter=$('.slider',$target);
			}
			$filter.slider();
		}
	};

	this.handleFixedSidebarCollapse=function() {
		var $body=$("body");
		var $pageSidebar=$(".page-sidebar");
		var $pageSidebarMenu=$(".page-sidebar-menu",$pageSidebar);
		if($body.hasClass("page-sidebar-fixed")
			&&$body.hasClass("page-sidebar-collapse-fixed")) {
			$pageSidebar.on('mouseenter',function() {
				if($body.hasClass("page-sidebar-fixed")) {
					$body.removeClass("page-sidebar-collapse");
				}
			}).on('mouseleave',function() {
				if($body.hasClass("page-sidebar-fixed")) {
					$body.addClass("page-sidebar-collapse");
				}
			});
		} else {
			$pageSidebar.off("mouseenter").off("mouseleave");
		}
		if($body.hasClass("page-sidebar-fixed")==false
			&&$body.hasClass("page-sidebar-collapse")) {
			$pageSidebarMenu.find('li').has('ul').children('a')
			.off('click')
			.on('click',function(e) {
				e.preventDefault();
				var $this=$(this);
				var $currentUL=$(this).parent('li')
				.addClass('open')
				.addClass('hover')
				.children('ul')
				.addClass("in").css({
					"display": ""
				});
				var offset=$this.offset();
				var windowHeight=document.documentElement.clientHeight;
				var scrollY=document.documentElement.scrollTop||document.body.scrollTop;
				windowHeight+=scrollY;
				var menuTogglePositon=offset.top;
				var menuToggleHeight=$this.innerHeight();
				var menuHeight=$currentUL.innerHeight();
				var headerHeight=$(".header").innerHeight();
				var footerHeight=$(".footer").innerHeight();
				window.console.log("windowHeight=",windowHeight);
				window.console.log("menuTogglePositon=",menuTogglePositon);
				window.console.log("menuToggleHeight=",menuToggleHeight);
				window.console.log("menuHeight=",menuHeight);
				window.console.log("headerHeight=",headerHeight);
				window.console.log("footerHeight=",footerHeight);
				menuHeight+=footerHeight;
				window.console.log("after menuTogglePositon=",menuTogglePositon);
				window.console.log("after menuHeight=",menuHeight);
				window.console.log("available menuheight=",(windowHeight-menuTogglePositon));
				window.console.log("request menuheight=",(menuToggleHeight+menuHeight));
				window.console.log("calc top=",((windowHeight-menuTogglePositon)<(menuToggleHeight+menuHeight)));
				var menuTop=0;
				var menuTextTop=0;
				if((windowHeight-menuTogglePositon)<(menuToggleHeight+menuHeight)) {
					menuTop=(menuToggleHeight+menuHeight)-(windowHeight-menuTogglePositon);
					if(menuTop>menuTogglePositon) {
						menuTop=menuTogglePositon;
					}
					menuTextTop=menuTop* -1;
					menuTop=(menuTop-menuToggleHeight)* -1;
					$this.addClass("pull-up");
				} else {
					menuTop=menuToggleHeight;
				}
				window.console.log("menuTop=",menuTop);
				window.console.log("menuTextTop=",menuTextTop);
				$currentUL.css("top",menuTop);
				$(".menu-text",$currentUL.parent()).css("top",menuTextTop);
				$(this).parent('li').siblings()
				.removeClass('open')
				.removeClass('hover')
				.children('ul.in').removeClass("in").css({
					"display": ""
				});
			});
		}
	};

	this.handleFixedSideBar=function() {
		var $body=$("body");
		var $leftSidebar=$(".page-sidebar-left");
		var $sidebarContent=$(".sidebar-content",$leftSidebar);
		var $menu=$('.page-sidebar-menu',$leftSidebar);
		var $header=$(".header");
		var $pageContent=$(".page-content");

		if($body.hasClass("page-sidebar-fixed")
			&&$body.hasClass("header-fixed")==false) {
			$leftSidebar.autofix_anything({ "onlyInContainer": false,"manualCSS": true });
		} else {
			$leftSidebar.removeClass("autofix_sb").removeClass("fixed");
		}

		if($.fn.slimScroll&&self.isGTSmallDevice()) {
			var windowHeight=$(window).height();
			if($sidebarContent.parent('.slimScrollDiv').size()===1) { // destroy existing instance before updating the height
				$sidebarContent
                .slimScroll({
                	destroy: true
                });
				$sidebarContent.css({
					'height': '','overflow': '','width': ''
				});
			}
			if($body.hasClass("page-sidebar-fixed")) {
				var height=windowHeight-$header.outerHeight(true);
				$sidebarContent
                .slimScroll({
                	position: 'right',
                	height: height,
                	size: '7px',
                	color: '#f5f5f5',
                	allowPageScroll: true,
                	disableFadeOut: true,
                	alwaysVisible: true
                });
			}
		}
		self.resizeContentHeight();
	};

	this.resizeContentHeight=function() {
		var $body=$('body');

		var $header=$('.header');
		var $footer=$('.footer');
		var $pageContainer=$('.page-container');
		var $pageContent=$('.page-content',$pageContainer);
		var $pageSidebar=$('.page-sidebar-left',$pageContainer);

		var windowHeight=$(window).height();
		var headerHeight=$header.outerHeight(true);
		var footerHeight=$footer.outerHeight(true);
		var pageSidebarHeight=$pageSidebar.outerHeight(true);

		var height=windowHeight-headerHeight-footerHeight;

		if(self.isGTSmallDevice()) {
			pageSidebarHeight=pageSidebarHeight-footerHeight;
			if(pageSidebarHeight>height)
				height=pageSidebarHeight;
		}
		//$pageContent.css({ 'min-height': height+'px' });
	};

	this.responsive=function() {
		self.resizeContentHeight();
		self.handleFixedSideBar();

		self.runResponsiveHandlers();
	};

	this.closeSidebar=function() {
		var $body=$("body");
		$body.removeClass("page-sidebar-left-open");
	};
	this.openSidebar=function() {
		var $body=$("body");
		var $pageContentOverlay=$(".page-content-overlay");
		if(!$pageContentOverlay.get(0)) {
			$pageContentOverlay=$("<div class='page-content-overlay'></div>");
			$(".page-container").append($pageContentOverlay);
			$pageContentOverlay.unbind("click").click(function() {
				self.closeSidebar();
			});
		}
		$body.toggleClass("page-sidebar-left-open");
	};

	this.handleTabLayOutMenu=function() {
		var $body=$("body");
		var $pageTabMenu=$(".page-tab-menu");
		if($body.hasClass("page-tab-layout")) {
			$pageTabMenu.children("ul").children("li").children("a").on('click',function() {
				var $currentLI=$(this).parent('li');
				$("ul > li",$pageTabMenu).removeClass("open");
				window.console.log("test");
				$currentLI.addClass("open");
			});
		}
	};

	this.changeToPageSidebarCollapse=function() {
		var $body=$("body");
		$body
		.addClass("layout-change")
		.toggleClass("page-sidebar-collapse");
		self.applyPSCollapseFixed();
		self.handleFixedSidebarCollapse();
		setTimeout(function() {
			self.responsive();
		},500);
		setTimeout(function() {
			$body.removeClass("dynamic-change");
		},1000);
	}

	this.applyPSCollapseFixed=function() {
		var $body=$("body");
		if($body.hasClass("page-sidebar-fixed")) {
			$body.addClass("page-sidebar-collapse-fixed");
		} else {
			$body.removeClass("page-sidebar-collapse-fixed");
		}
	}

	this.sidebarAccordionMenu=function() {
		var $body=$("body");
		var $pageSidebar=$(".page-sidebar");
		var $sidebarContent=$(".sidebar-content",$pageSidebar);
		var $pageSidebarMenu=$(".page-sidebar-menu",$pageSidebar);
		var $toggle=true;
		var slideSpeed=200;
		var slideOffeset= -200;
		if($body.hasClass("page-sidebar-collapse")==false) {
			$pageSidebarMenu.find('li').has('ul').children('a').off('click').on('click',function(e) {
				e.preventDefault();
				var $this=$(this);

				var $currentUL=$(this).parent('li').toggleClass('open').children('ul');
				var $body=$("body");
				if($currentUL.hasClass("in")==false) {
					$currentUL
                .slideDown(slideSpeed,function() {
                	$(this).addClass("in").css({
                		"display": ""
                	});
                	if($body.hasClass("page-sidebar-collapse")==false) {
                		if(self.isGTSmallDevice()) {
                			if($body.hasClass("page-sidebar-fixed")==false) {
                				self.scrollTo($this,slideOffeset);
                			} else {
                				$sidebarContent.slimScroll({ 'scrollTo': ($this.offset()).top });
                			}
                		} else {
                			$pageSidebar.scrollTo($this);
                		}
                	}
                	self.resizeContentHeight();
                });
				} else {
					$currentUL
                .slideUp(slideSpeed,function() {
                	$(this).removeClass("in").css({
                		"display": ""
                	});
                	if($body.hasClass("page-sidebar-collapse")==false) {
                		if(self.isGTSmallDevice()) {
                			if($body.hasClass("page-sidebar-fixed")==false) {
                				self.scrollTo($this,slideOffeset);
                			} else {
                				$sidebarContent.slimScroll({ 'scrollTo': ($this.offset()).top });
                			}
                		} else {
                			$pageSidebar.scrollTo($this);
                		}
                	}
                	self.resizeContentHeight();
                });
				}

				if($toggle) {

					$(this).parent('li').siblings().removeClass('open').children('ul.in')
                .slideUp(slideSpeed,function() {
                	$(this).removeClass("in").css({
                		"display": ""
                	});
                	self.resizeContentHeight();
                });
				}
			});
		}
	}

	this.handleSidebarMenu=function() {
		var $body=$("body");
		var $pageSidebar=$(".page-sidebar");
		var $sidebarContent=$(".sidebar-content",$pageSidebar);
		var $pageSidebarMenu=$(".page-sidebar-menu",$pageSidebar);
		var $pageSidebarSearch=$(".page-sidebar-search");

		$(".ps-toggler",$pageSidebarMenu)
        .on("click",function() {
        	self.changeToPageSidebarCollapse();
        	self.sidebarAccordionMenu();
        });

		$(".ps-collapse-fixed-toggler",$(".header"))
        .on("click",function() {
        	if($body.hasClass("page-sidebar-fixed")
			&&$body.hasClass("page-sidebar-collapse-fixed")) {
        		$pageSidebar.off("mouseenter").off("mouseleave");
        		$body
				.removeClass("page-sidebar-collapse-fixed")
				.removeClass("page-sidebar-collapse");
        	} else {
        		self.changeToPageSidebarCollapse();
        	}
        });



		$("#open-search",$pageSidebarSearch)
        .on("click",function() {
        	$pageSidebarSearch.addClass("open");
        });
		$("#close-search",$pageSidebarSearch)
        .on("click",function() {
        	$pageSidebarSearch.removeClass("open");
        });



		$('.ps-sm-toggler')
        .on('touchend',function(e) {
        	self.openSidebar();
        	e.preventDefault();
        })
        .click(function(e) {
        	self.openSidebar();
        	e.preventDefault();
        	e.stopPropagation();
        });

		$pageSidebarMenu.find('li.open').has('ul').children('ul').addClass('collapse in');
		$pageSidebarMenu.find('li').not('.open').has('ul').children('ul').addClass('collapse');
		self.sidebarAccordionMenu();
	};

	this.handleHorizontalMenu=function() {
		var $header=$(".header");
		var $horMenu=$(".hor-menu",$header);
		if(this.isTouchDevice()==true) {
			$horMenu.find('.dropdown-menu').click(function(e) {
				e.stopPropagation();
			});
			// handle submenus
			$horMenu.find('.dropdown-submenu').each(function() {
				var $this=$(this);
				var subTimeout;
				$this.click(function() {
					$this.toggleClass("open");
				});
			});
		}
	};

	this.jqValidationSetDefaults=function() {
		if($.validator) {
			$.validator.setDefaults({
				highlight: function(element) {
					$(element).closest('.form-group').addClass('has-error');
				},
				unhighlight: function(element) {
					$(element).closest('.form-group').removeClass('has-error');
				},
				errorElement: 'span',
				errorClass: 'help-block',
				errorPlacement: function(error,element) {
					if(element.closest('.input-group').size()===1) {
						error.insertAfter(element.closest('.input-group'));
					} else if(element.closest('.input-icon').size()===1) {
						error.insertAfter(element.closest('.input-icon'));
					} else if(element.closest('.select-group').size()===1) {
						error.insertAfter(element.closest('.select-group'));
					} else {
						error.insertAfter(element);
					}
				}
			});
		}
	};


	this.isHeaderFixed=false;
	this.isSidebarFixed=false;
	this.isFixedLayout=false;

	this.changeLayout=function() {
		var $body=$("body");
		var $header=$(".header");
		if(this.isHeaderFixed) {
			$body.addClass("header-fixed");
			$header.addClass("navbar-fixed-top");
		} else {
			$body.removeClass("header-fixed");
			$header.removeClass("navbar-fixed-top");
		}
		if(this.isSidebarFixed)
			$body.addClass("page-sidebar-fixed");
		else
			$body.removeClass("page-sidebar-fixed");

		if(this.isFixedLayout)
			$body.removeClass("page-fluid");
		else
			$body.addClass("page-fluid");

		self.responsive();
	};

	this.initSettings=function() {
		var $body=$("body");
		var $header=$(".header");
		if($body.hasClass("header-fixed")) {
			this.isHeaderFixed=true;
			$header.addClass("navbar-fixed-top");
		} else {
			$header.removeClass("navbar-fixed-top");
		}
		this.isSidebarFixed=$body.hasClass("page-sidebar-fixed");
		this.isFixedLayout=!$body.hasClass("page-fluid");
	}

	this.init=function() {
		self._IsIE8=!!navigator.userAgent.match(/MSIE 8.0/);
		self._IsIE9=!!navigator.userAgent.match(/MSIE 9.0/);
		self._IsIE10=!!navigator.userAgent.match(/MSIE 10.0/);



		self.initSettings();
		self.handleSidebarMenu();
		self.handleHorizontalMenu();
		self.handleFixedSideBar();
		self.applyPSCollapseFixed();
		self.handleFixedSidebarCollapse();

		self.handleTabLayOutMenu();

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
		self.resizeContentHeight();

	};

}

var APP=new Application();

$(function() {
	APP.init();
});

$(window).resize(function() {
	APP.responsive();
});