$(function() {
	var $frmLayoutSettings=$("#frmLayoutSettings");
	var $chkHeader=$("#header",$frmLayoutSettings);
	var $chkSidebar=$("#sidebar",$frmLayoutSettings);
	var $chkLayout=$("#layout",$frmLayoutSettings);

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

