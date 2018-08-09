var teamsPoints = {
    'rome': [106, 106, 107, 111, 133, 221, 783, 2478],
    'milan': [12, 18, 31, 64, 156, 339, 820, 1217],
    'juventus': [411, 502, 635, 809, 947, 1402, 3700, 5267],
    'napoli': [178, 190, 203, 276, 408, 547, 675, 734],
    'inter': [3, 2, 2, 2, 6, 13, 30, 57],
    'fiorentina': [710, 791, 978, 1262, 1650, 2521, 6008, 9725]
};
var xScale = 150;

document.addEventListener('DOMContentLoaded', function (event) {
    var canvas = document.getElementById('canvas')
    var context = canvas.getContext('2d');
    context.strokeColor = '#7142f4';
    draw(context, teamsPoints);
});

function draw(context, dataSet) {
    for (var datas in dataSet) {
        var data = dataSet[datas];
        plotDataset(context, data);
    }
}

function plotDataset(context, dataSet) {
    var canvasHeight = context.canvas.height;
    context.beginPath();
    context.moveTo(0, dataSet[0]);
    for (var populationIndex = 0; populationIndex < dataSet.length; populationIndex++) {
        var population = dataSet[populationIndex];
        var xCoordinate = populationIndex * xScale;
        var yCoordinate = canvasHeight - population;
        context.lineTo(xCoordinate, yCoordinate);
    }
    context.stroke();
}