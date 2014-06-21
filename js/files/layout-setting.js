$(function() {
	var $frmLayoutSettings=$("#frmLayoutSettings");
	var $chkHeader=$("#header",$frmLayoutSettings);
	var $chkSidebar=$("#sidebar",$frmLayoutSettings);
	var $chkLayout=$("#layout",$frmLayoutSettings);
	var $themePanel=$(".theme-panel");
	$(".toggler",$themePanel).click(function() {
		$(".theme-options",$themePanel).toggleClass("open");
	});


	$chkLayout.get(0).checked=APP.isFixedLayout;
	$chkHeader.get(0).checked=APP.isHeaderFixed;
	$chkSidebar.get(0).checked=APP.isSidebarFixed;

	$chkLayout
    .click(function() {
    	APP.isFixedLayout=this.checked;
    	APP.changeLayout();
    });

	$chkHeader
    .click(function() {
    	APP.isHeaderFixed=this.checked;
    	APP.changeLayout();
    });

	$chkSidebar
	.click(function() {
		APP.isSidebarFixed=this.checked;
		APP.changeLayout();
	});

});

