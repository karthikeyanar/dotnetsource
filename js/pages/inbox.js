function Inbox() {
	var self=this;
	this.mails=ko.observableArray([]);
	this.types=ko.observableArray([]);
	this.all_selected=ko.observable(false);
	this.open_message_count=ko.computed(function() {
		var count=0;
		$.each(self.mails(),function(i,mail) {
			if(mail.is_open()==true) {
				count++;
			}
		});
		return count;
	});
	this.open_message=ko.observable(null);
	this.selectAll=function() {
		var all=self.all_selected();
		console.log(!all);
		ko.utils.arrayForEach(self.mails(),function(mail) {
			mail.is_select(!all);
		});
		return true;
	};
	this.isAnyOneSelect=ko.computed(function() {
		var count=0;
		ko.utils.arrayForEach(self.mails(),function(mail) {
			if(mail.is_select()==true) {
				count++;
			}
		});
		if(count>0)
			return true;
		else
			return false;
	});
}
function MessageModel(data) {
	var self=this;
	this.type_id=ko.observable(data.type_id||0);
	this.sender=ko.observable(data.sender||"");
	this.sender_mail=ko.observable(data.sender_mail||"");
	this.subject=ko.observable(data.subject||"");
	this.is_read=ko.observable(data.is_read||false);
	this.is_attachment=ko.observable(data.is_attachment||false);
	this.is_starred=ko.observable(data.is_starred||false);
	this.is_select=ko.observable(data.is_select||false);
	this.is_read=ko.observable(data.is_read||false);
	this.is_show=ko.observable(data.is_show||false);
	this.is_open=ko.observable(data.is_open||false);
	this.body=ko.observable(data.body||"");
	this.created=ko.observable(data.created||"");
	this.close=function() {
		_Inbox.open_message(null);
		self.is_open(false);
	};
	this.open=function() {
		$.each(_Inbox.mails(),function(i,mail) {
			mail.is_open()==false;
		});
		_Inbox.open_message(self);
		self.is_read(true);
		self.is_open(true);
	};
	this.date_format=ko.computed(function() {
		var dateInt=self.created();
		var date=new Date(dateInt),
            now=new Date(),
            todayStart=new Date(now.getFullYear(),now.getMonth(),now.getDate())
		window.console.log(date);
		if(date.getTime()>todayStart) {
			return date.getHours()+":"+(date.getMinutes()<10?'0'+date.getMinutes():date.getMinutes());
		}
		return ['Jan','Feb','Mar','Apr',
            'May','Jun','Jul','Aug',
            'Sep','Oct','Nov','Dec'][date.getMonth()]+' '+date.getDate();
	});
	this.starStatus=ko.computed(function() {
		return self.is_starred()==true?"fa fa-star fg-warning":"fa fa-star-o";
	});
	this.setStar=function() {
		if(self.is_starred()==false) {
			self.is_starred(true);
		} else {
			self.is_starred(false);
		}
	};
}
function TypeModel(data) {
	var self=this;
	this.type_id=ko.observable(data.type_id||0);
	this.name=ko.observable(data.name||"");
	this.is_active=ko.observable(data.is_active||false);
	this.open=function() {
		_Inbox.open_message(null);
		$.each(_Inbox.mails(),function(i,mail) {
			mail.is_open()==false;
		});
		ko.utils.arrayForEach(_Inbox.types(),function(type) {
			type.is_active(false);
		});
		self.is_active(true);
		if(self.type_id()==4) {
			ko.utils.arrayForEach(_Inbox.mails(),function(mail) {
				if(mail.is_starred()==true) {
					mail.is_show(true);
				} else {
					mail.is_show(false);
				}
			});
		} else {
			ko.utils.arrayForEach(_Inbox.mails(),function(mail) {
				if(mail.type_id()==self.type_id()) {
					mail.is_show(true);
				} else {
					mail.is_show(false);
				}
			});
		}
	};
}
var _Inbox=new Inbox();
$(function() {
	var data={
		"type_id": 1,
		"name": "Inbox",
		"is_active": true
	}
	_Inbox.types.push(new TypeModel(data));
	data={
		"type_id": 2,
		"name": "Sent"
	}
	_Inbox.types.push(new TypeModel(data));
	data={
		"type_id": 3,
		"name": "Drafts"
	}
	_Inbox.types.push(new TypeModel(data));
	data={
		"type_id": 4,
		"name": "Starred"
	}
	_Inbox.types.push(new TypeModel(data));
	ko.applyBindings(_Inbox);
	$.getJSON("/php/inbox.php",function(data) {
		$.each(data,function(i,mail) {
			var message=new MessageModel(mail);
			if(message.type_id()==1) {
				message.is_show(true);
			}
			_Inbox.mails.push(message);
		});
	});
}); 