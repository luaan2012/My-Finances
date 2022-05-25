
var dom = document.getElementById("echart")
var myChart = echarts.init(dom);


var app = {};

var option;



// prettier-ignore
let dataAxis = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31];
// prettier-ignore
let data = [220, 182, 191, 234, 290, 330, 310, 123, 442, 321, 90, 149, 210, 122, 133, 334, 210, 122, 133, 334, 444, 122, 133, 334, 210, 122, 133, 334, 444, 44 ,33];
let yMax = 500;
let dataShadow = [];
for (let i = 0; i < data.length; i++) {
    dataShadow.push(yMax);
}
option = {
    responsive: true,
    maintainAspectRatio: false,
    grid: {
        left: '5%',
        bottom: '3%',
        right: '2%',
        top: '3%'
    },
    xAxis: {
        data: dataAxis,
        axisLabel: {
            inside: true,
            color: '#fff'
        },
        axisTick: {
            show: false
        },
        axisLine: {
            show: false
        },
        z: 10
    },
    yAxis: {
        axisLine: {
            show: false
        },
        axisTick: {
            show: false
        },
        axisLabel: {
            color: '#999'
        }
    },
 
    series: [
        {
            type: 'bar',
            showBackground: true,
            itemStyle: {
                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [
                    { offset: 0, color: '#83bff6' },
                    { offset: 0.5, color: '#188df0' },
                    { offset: 1, color: '#188df0' }
                ])
            },
            emphasis: {
                itemStyle: {
                    color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [
                        { offset: 0, color: '#2378f7' },
                        { offset: 0.7, color: '#2378f7' },
                        { offset: 1, color: '#83bff6' }
                    ])
                }
            },
            data: data
        }
    ]
};
// Enable data zoom when user click bar.


if (option && typeof option === 'object') {
    myChart.setOption(option);
}

$(document).ready(function () {
    $("canvas[data-zr-dom-id='zr_0']").css('width', '1200')
    $("canvas[data-zr-dom-id='zr_0']").on('click', function () {
        myChart.resize();
        console.log("teste")

    })
});

$(window).on('resize', function () {
    if (myChart != null && myChart != undefined) {
        myChart.resize();
    }
});




