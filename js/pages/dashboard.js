$(function() {
	var c3SplineChart=c3.generate({
		bindto: '#c3SplineChart',
		data: {
			x: 'x',
			columns: [
            ['x','2009-01-01','2010-01-01','2011-01-01','2012-01-01','2013-01-01','2014-01-01'],
            ['Desktop',1000,3000,4000,500,2500,4000],
			['Mobile',1500,5050,7000,3245,5741,6845],
			['Tablet',3264,1425,4021,5784,7015,2415],
			],
			type: 'spline'
		},
		axis: {
			x: {
				type: 'timeseries',
				tick: {
					format: function(x) { return x.getFullYear(); }
					//format: '%Y' // format string is also available for timeseries data
				}
			}
		}
		/*
		,onclick: function(d,element) {
		//console.log("onclick",d,element); 
		}
		,onmouseover: function(d) {
		//console.log("onmouseover",d); 
		}
		,onmouseout: function(d) {
		//console.log("onmouseout",d); 
		}
		*/
	});

	var c3BarChart=c3.generate({
		bindto: '#c3BarChart',
		data: {
			x: 'x',
			columns: [
            ['x','2009-01-01','2010-01-01','2011-01-01','2012-01-01','2013-01-01','2014-01-01'],
            ['Desktop',1000,3000,4000,500,2500,4000],
			['Mobile',1500,5050,7000,3245,5741,6845],
			['Tablet',3264,1425,4021,5784,7015,2415],
			]
			,type: 'bar'
			,colors: {
				Computer: '#0072C6',
				Mobile: '#D24726',
				Labtop: '#8C0095'
			}
		},
		axis: {
			x: {
				type: 'timeseries',
				tick: {
					format: function(x) { return x.getFullYear(); }
					//format: '%Y' // format string is also available for timeseries data
				}
			}
		}
		/*
		,onclick: function(d,element) {
		//console.log("onclick",d,element); 
		}
		,onmouseover: function(d) {
		//console.log("onmouseover",d); 
		}
		,onmouseout: function(d) {
		//console.log("onmouseout",d); 
		}
		*/
	});
	var c3PieChart=c3.generate({
		bindto: '#c3PieChart',
		data: {
			// iris data from R
			columns: [
				["Desktop",0.2,0.2,0.2,0.2,0.2,0.4,0.3,0.2,0.2,0.1,0.2,0.2,0.1,0.1,0.2,0.4,0.4,0.3,0.3,0.3,0.2,0.4,0.2,0.5,0.2,0.2,0.4,0.2,0.2,0.2,0.2,0.4,0.1,0.2,0.2,0.2,0.2,0.1,0.2,0.2,0.3,0.3,0.2,0.6,0.4,0.3,0.2,0.2,0.2,0.2],
				["Mobile",1.4,1.5,1.5,1.3,1.5,1.3,1.6,1.0,1.3,1.4,1.0,1.5,1.0,1.4,1.3,1.4,1.5,1.0,1.5,1.1,1.8,1.3,1.5,1.2,1.3,1.4,1.4,1.7,1.5,1.0,1.1,1.0,1.2,1.6,1.5,1.6,1.5,1.3,1.3,1.3,1.2,1.4,1.2,1.0,1.3,1.2,1.3,1.3,1.1,1.3],
				["Tablet",2.5,1.9,2.1,1.8,2.2,2.1,1.7,1.8,1.8,2.5,2.0,1.9,2.1,2.0,2.4,2.3,1.8,2.2,2.3,1.5,2.3,2.0,2.0,1.8,2.1,1.8,1.8,1.8,2.1,1.6,1.9,2.0,2.2,1.5,1.4,2.3,2.4,1.8,1.8,2.1,2.4,2.3,1.9,2.3,2.5,2.3,1.9,2.0,2.3,1.8],
		    ]
			,type: 'pie'
			,colors: {
				Desktop: '#004B8B',
				Mobile: '#008A17',
				Tablet: '#8C0095'
			}
		}
		/*
		,pie: {
		onclick: function(d,i) { console.log(d,i); },
		onmouseover: function(d,i) { console.log(d,i); },
		onmouseout: function(d,i) { console.log(d,i); }
		}
		*/
	});

	var c3DonutChart=c3.generate({
		bindto: '#c3DonutChart',
		data: {
			// iris data from R
			columns: [
				["Desktop",0.2,0.2,0.2,0.2,0.2,0.4,0.3,0.2,0.2,0.1,0.2,0.2,0.1,0.1,0.2,0.4,0.4,0.3,0.3,0.3,0.2,0.4,0.2,0.5,0.2,0.2,0.4,0.2,0.2,0.2,0.2,0.4,0.1,0.2,0.2,0.2,0.2,0.1,0.2,0.2,0.3,0.3,0.2,0.6,0.4,0.3,0.2,0.2,0.2,0.2],
				["Mobile",1.4,1.5,1.5,1.3,1.5,1.3,1.6,1.0,1.3,1.4,1.0,1.5,1.0,1.4,1.3,1.4,1.5,1.0,1.5,1.1,1.8,1.3,1.5,1.2,1.3,1.4,1.4,1.7,1.5,1.0,1.1,1.0,1.2,1.6,1.5,1.6,1.5,1.3,1.3,1.3,1.2,1.4,1.2,1.0,1.3,1.2,1.3,1.3,1.1,1.3],
				["Tablet",2.5,1.9,2.1,1.8,2.2,2.1,1.7,1.8,1.8,2.5,2.0,1.9,2.1,2.0,2.4,2.3,1.8,2.2,2.3,1.5,2.3,2.0,2.0,1.8,2.1,1.8,1.8,1.8,2.1,1.6,1.9,2.0,2.2,1.5,1.4,2.3,2.4,1.8,1.8,2.1,2.4,2.3,1.9,2.3,2.5,2.3,1.9,2.0,2.3,1.8],
		    ]
			,type: 'donut'
			,colors: {
				Desktop: '#D24726',
				Mobile: '#FF8F32',
				Tablet: '#4617B4'
			}
		}
		/*
		,pie: {
		onclick: function(d,i) { console.log(d,i); },
		onmouseover: function(d,i) { console.log(d,i); },
		onmouseout: function(d,i) { console.log(d,i); }
		}
		*/
	});

	$('.easy-pie-chart').easyPieChart({
		animate: 1000,
		onStep: function(from,to,percent) {
			$(this.el).find('span').text(Math.round(percent)+"%");
		}
	});

	APP.addResponsiveHandler(function () {
	    c3SplineChart.resize();
	    c3BarChart.resize();
	    c3DonutChart.resize();
	    c3PieChart.resize();
	});
});