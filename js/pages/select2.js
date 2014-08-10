$(function() {
	var opts=$("#select1").html(),opts2="<option></option>"+opts;
	$("select.populate").each(function() { var e=$(this);e.html(e.hasClass("placeholder")?opts2:opts); });

	$(".select2").select2();
	$("#e2").select2({
		placeholder: "Select a state",
		allowClear: true
	});
	$("#e2_2").select2({
		placeholder: "Select a state"
	});
	$("#e3").select2({
		minimumInputLength: 2
	});
	function formatResult(state) {
		if(!state.id) return state.text; // optgroup
		return "<img class='photo' style='width:36px;height:36px;' src='/img/avatars/75/"+state.id.toLowerCase()+".jpg'/>&nbsp;&nbsp;"+state.text;
	}
	function formatSelection(state) {
		if(!state.id) return state.text; // optgroup
		return "<img class='photo' style='width:15px;height:15px;' src='/img/avatars/75/"+state.id.toLowerCase()+".jpg'/>&nbsp;&nbsp;"+state.text;
	}
	$("#e4").select2({
		formatResult: formatResult,
		formatSelection: formatSelection,
		escapeMarkup: function(m) { return m; }
	});
	$("#e5").select2({
		minimumInputLength: 1,
		query: function(query) {
			var data={ results: [] },i,j,s;
			for(i=1;i<5;i++) {
				s="";
				for(j=0;j<i;j++) { s=s+query.term; }
				data.results.push({ id: query.term+i,text: s });
			}
			query.callback(data);
		}
	});
	$("#e19").select2({ maximumSelectionSize: 3 });
});