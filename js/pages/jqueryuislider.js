function hexFromRGB(r,g,b) {
	var hex=[
r.toString(16),
g.toString(16),
b.toString(16)
];
	$.each(hex,function(nr,val) {
		if(val.length===1) {
			hex[nr]="0"+val;
		}
	});
	return hex.join("").toUpperCase();
}
function refreshSwatch() {
	var red=$("#red").slider("value"),
green=$("#green").slider("value"),
blue=$("#blue").slider("value"),
hex=hexFromRGB(red,green,blue);
	$("#swatch").css("background-color","#"+hex);
}
$(function() {
	$("#red, #green, #blue").slider({
		orientation: "horizontal",
		range: "min",
		max: 255,
		value: 127,
		slide: refreshSwatch,
		change: refreshSwatch
	});
	$("#red").slider("value",255);
	$("#green").slider("value",140);
	$("#blue").slider("value",60);
	$("#slider").slider();
	// setup master volume
	$("#master").slider({
		value: 60,
		orientation: "horizontal",
		range: "min",
		animate: true
	});
	// setup graphic EQ
	$("#eq > span").each(function() {
		// read initial values from markup and remove that
		var value=parseInt($(this).text(),10);
		$(this).empty().slider({
			value: value,
			range: "min",
			animate: true,
			orientation: "vertical"
		});
	});
	$("#slider-range").slider({
		range: true,
		min: 0,
		max: 500,
		values: [75,300],
		slide: function(event,ui) {
			$("#amount").val("$"+ui.values[0]+" - $"+ui.values[1]);
		}
	});
	$("#amount").val("$"+$("#slider-range").slider("values",0)+" - $"+$("#slider-range").slider("values",1));


	$("#slider-range-max").slider({
		range: "max",
		min: 1,
		max: 10,
		value: 2,
		slide: function(event,ui) {
			$("#amountmax").val(ui.value);
		}
	});
	$("#amountmax").val($("#slider-range-max").slider("value"));
	$("#slider-range-min").slider({
		range: "min",
		value: 37,
		min: 1,
		max: 700,
		slide: function(event,ui) {
			$("#amountmin").val("$"+ui.value);
		}
	});
	$("#amountmin").val("$"+$("#slider-range-min").slider("value"));
	$("#slider-range-vertical").slider({
		orientation: "vertical",
		range: "min",
		min: 0,
		max: 100,
		value: 60,
		slide: function(event,ui) {
			$("#amountvertical").val(ui.value);
		}
	});
	$("#amountvertical").val($("#slider-range-vertical").slider("value"));
	$("#slider-range-vertical-range").slider({
		orientation: "vertical",
		range: true,
		values: [17,67],
		slide: function(event,ui) {
			$("#amountverticalrange").val("$"+ui.values[0]+" - $"+ui.values[1]);
		}
	});
	$("#amountverticalrange").val("$"+$("#slider-range-vertical-range").slider("values",0)+" - $"+$("#slider-range").slider("values",1));
});
