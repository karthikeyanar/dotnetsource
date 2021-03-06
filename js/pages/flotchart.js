﻿$(function() {

	/* pie chart */

	var data=[],
			series=Math.floor(Math.random()*6)+3;

	for(var i=0;i<series;i++) {
		data[i]={
			label: "Series"+(i+1),
			data: Math.floor(Math.random()*100)+1
		}
	}

	var placeholder=$("#pie-chart1");

	$.plot($("#pie-chart1"),data,{
		series: {
			pie: {
				show: true
			}
		}
	});

	/* interactivity chart */

	var sin=[],
			cos=[];

	for(var i=0;i<14;i+=0.5) {
		sin.push([i,Math.sin(i)]);
		cos.push([i,Math.cos(i)]);
	}

	var plot=$.plot("#interactivity",[
			{ data: sin,label: "sin(x)" },
			{ data: cos,label: "cos(x)" }
		],{
			series: {
				lines: {
					show: true
				},
				points: {
					show: true
				}
			},
			grid: {
				hoverable: true,
				clickable: true
			},
			yaxis: {
				min: -1.2,
				max: 1.2
			}
		});

	var previousPoint=null;
	$("#interactivity").bind("plothover",function(event,pos,item) {


		if(item) {
			if(previousPoint!=item.dataIndex) {

				previousPoint=item.dataIndex;

				$("#tooltip").remove();
				var x=item.datapoint[0].toFixed(2),
						y=item.datapoint[1].toFixed(2);

				chartToolTip(item.pageX,item.pageY,
						    item.series.label+" of "+x+" = "+y);
			}
		} else {
			$("#tooltip").remove();
			previousPoint=null;
		}

	});

	function chartToolTip(x,y,contents) {
		$('<div id="tooltip" class="chart-tooltip tooltip"><div class="tooltip-arrow"></div><div class="tooltip-inner">'+contents+'</div></div>').css({
			top: y-43,
			left: x-15
		}).appendTo("body").fadeIn(200);
	};

	// generate data set from a parametric function with a fractal look

	function sumf(f,t,m) {
		var res=0;
		for(var i=1;i<m;++i) {
			res+=f(i*i*t)/(i*i);
		}
		return res;
	}

	var d1=[];
	for(var t=0;t<=2*Math.PI;t+=0.01) {
		d1.push([sumf(Math.cos,t,10),sumf(Math.sin,t,10)]);
	}

	var data=[d1],
			placeholder=$("#panning");

	var plot=$.plot(placeholder,data,{
		series: {
			lines: {
				show: true
			},
			shadowSize: 0
		},
		xaxis: {
			zoomRange: [0.1,10],
			panRange: [-10,10]
		},
		yaxis: {
			zoomRange: [0.1,10],
			panRange: [-10,10]
		},
		zoom: {
			interactive: true
		},
		pan: {
			interactive: true
		}
	});

	// show pan/zoom messages to illustrate events 

	placeholder.bind("plotpan",function(event,plot) {
		var axes=plot.getAxes();
		$(".message").html("Panning to x: "+axes.xaxis.min.toFixed(2)
			+" &ndash; "+axes.xaxis.max.toFixed(2)
			+" and y: "+axes.yaxis.min.toFixed(2)
			+" &ndash; "+axes.yaxis.max.toFixed(2));
	});

	placeholder.bind("plotzoom",function(event,plot) {
		var axes=plot.getAxes();
		$(".message").html("Zooming to x: "+axes.xaxis.min.toFixed(2)
			+" &ndash; "+axes.xaxis.max.toFixed(2)
			+" and y: "+axes.yaxis.min.toFixed(2)
			+" &ndash; "+axes.yaxis.max.toFixed(2));
	});

	// add zoom out button 

	$("<div class='button' style='right:20px;top:20px'>zoom out</div>")
			.appendTo(placeholder)
			.click(function(event) {
				event.preventDefault();
				plot.zoomOut();
			});

	// and add panning buttons

	// little helper for taking the repetitive work out of placing
	// panning arrows

	function addArrow(dir,right,top,offset) {
		$("<img class='button' src='/img/arrow-"+dir+".gif' style='right:"+right+"px;top:"+top+"px'>")
				.appendTo(placeholder)
				.click(function(e) {
					e.preventDefault();
					plot.pan(offset);
				});
	}

	addArrow("left",55,60,{ left: -100 });
	addArrow("right",25,60,{ left: 100 });
	addArrow("up",40,45,{ top: -100 });
	addArrow("down",40,75,{ top: 100 });

});
		  