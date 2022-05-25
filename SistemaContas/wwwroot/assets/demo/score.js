var dom = document.getElementById("score");
var myChart = echarts.init(dom);
var app = {};

var option;



option = {
    tooltip: {
        formatter: '{a} <br/>{b} : {c}%'
    },
    series: [
        {
            name: 'Pressure',
            type: 'gauge',
            progress: {
                show: true
            },
            detail: {
                valueAnimation: true,
                formatter: '{value}'
            },
            data: [
                {
                    value: 50,
                    name: 'SCORE'
                }
            ]
        }
    ]
};

if (option && typeof option === 'object') {
    myChart.setOption(option);
}