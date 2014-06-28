Application.prototype.popoverConfirm=function(element,message,callback,option) {
	var options=$.extend({},defaults,option)
	var $element=$(element);

	var defaults={
		okBtnClass: 'btn btn-primary input-small',
		okBtnText: 'OK',
		cancelBtnClass: 'btn btn-danger input-small margin-left-10',
		cancelBtnText: 'Cancel',
		modalClass: '',
		placement: 'bottom',
		trigger: 'click',
		animation: true,
		html: true,
		title: '',
		delay: 0,
		container: false
	}

	var options=$.extend({},defaults,option)

	var template="<div> \
				<p class='bs-popover-msg'>"+message+"</p> \
				<div> \
					<button type='button' id='ok' class='"+options.okBtnClass+"' aria-hidden='true'>"+options.okBtnText+"</button> \
					<button type='button' id='cancel' class='"+options.cancelBtnClass+"' aria-hidden='true'>"+options.cancelBtnText+"</button> \
				</div> \
			</div>";

	if($element.data('bs.popover')) {
		$element.popover('hide');
	}

	var popover=$element.popover({
		"animation": options.animation,
		"html": options.html,
		"placement": options.placement,
		"trigger": options.trigger,
		"title": options.title,
		"content": template,
		"delay": options.delay,
		"container": options.container
	})
	.on('hidden.bs.popover',function() {
		$element.popover('destroy');
	})
	.on('shown.bs.popover',function() {
		var $tip=$($element.data('bs.popover').tip()[0]);
		$('#ok',$tip).click(function() {
			if(callback)
				callback(true);

			$element.popover('hide');
		});

		$('#cancel',$tip).click(function() {
			if(callback)
				callback(false);

			$element.popover('hide');
		});

	});
	$element.popover('toggle');
};
Application.prototype.metroAlert=function(message,callback,option) {

	var defaults={
		okBtnClass: 'btn btn-primary input-small',
		okBtnText: 'OK',
		modalClass: ''
	}

	var options=$.extend({},defaults,option)

	var template="<div class='modal fade modal-metro notification "+options.modalClass+"' role='dialog'> \
				<div class='modal-dialog'> \
					<div class='modal-content'> \
						<div class='modal-body'> \
							<p>"+message+"</p> \
						</div> \
						<div class='modal-footer'> \
							<button type='button' id='ok' class='"+options.okBtnClass+"' data-dismiss='modal' aria-hidden='true'>"+options.okBtnText+"</button> \
						</div> \
					</div> \
				</div> \
			</div>";

	var bsModal=$(template);

	bsModal.appendTo(document.body);

	bsModal.modal({
		"backdrop": true,"keyboard": true,"show": false
	});

	bsModal
	.on('shown.bs.modal',function(e) {
		$('#ok',bsModal).focus();
	})
	.on('hide.bs.modal',function(e) {
		if(callback)
			callback();
	});

	bsModal.on('hidden.bs.modal',function(e) {
		setTimeout(function() {
			bsModal.remove();
		},500);
	});

	bsModal.modal('toggle');

};
Application.prototype.metroConfirm=function(message,callback,option) {

	var defaults={
		okBtnClass: 'btn btn-primary input-small',
		okBtnText: 'OK',
		cancelBtnClass: 'btn btn-danger input-small margin-left-10',
		cancelBtnText: 'Cancel',
		modalClass: ''
	}

	var options=$.extend({},defaults,option)

	var template="<div class='modal fade modal-metro notification "+options.modalClass+"' role='dialog'> \
				<div class='modal-dialog'> \
					<div class='modal-content'> \
						<div class='modal-body'> \
							<p>"+message+"</p> \
						</div> \
						<div class='modal-footer'> \
							<button type='button' id='ok' class='"+options.okBtnClass+"' aria-hidden='true'>"+options.okBtnText+"</button> \
							<button type='button' id='cancel' class='"+options.cancelBtnClass+"' aria-hidden='true'>"+options.cancelBtnText+"</button> \
						</div> \
					</div> \
				</div> \
			</div>";

	var bsModal=$(template);

	bsModal.appendTo(document.body);

	$('#ok',bsModal).click(function() {
		if(callback)
			callback(true);

		bsModal.modal('hide');
	});

	$('#cancel',bsModal).click(function() {
		if(callback)
			callback(false);

		bsModal.modal('hide');
	});

	bsModal.modal({
		"backdrop": true,"keyboard": true,"show": false
	});

	bsModal
	.on('shown.bs.modal',function(e) {
		$('#cancel',bsModal).focus();
	})
	.on('hidden.bs.modal',function(e) {
		setTimeout(function() {
			bsModal.remove();
		},500);
	});

	bsModal.modal('toggle');

};