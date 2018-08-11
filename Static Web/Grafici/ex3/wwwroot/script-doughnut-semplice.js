/*******************************************************************************************************
**                                                                                                    **
**      Disegnamo un grafico a doughnut                                                               **
**                                                                                                    **
*******************************************************************************************************/


/*
    Differisce da un grafico a torta solo perchè al centro ha un buco.

    Il codice aggiunto alla classe Piechart cerca nel parametro options
    una variabile membro doughnutHoleSize. Se questo non esiste nelle opzioni,
    il codice disegnerà il grafico a torta come prima, ma se esiste, viene
    disegnato un cerchio bianco con lo stesso centro del grafico a torta.
        (Il raggio del cerchio è determinato moltiplicando il raggio del grafico a torta e il
         valore di doughnutHoleSize. Questo dovrebbe essere un numero compreso tra 0 e 1, dove
         0 risulterà in un grafico a torta e qualsiasi valore superiore a 0 risulterebbe in una
         ciambella con il buco sempre più grande, 1 rendendo il grafico invisibile.)
*/



/******************************************************************************************************/

// Codice in comune



var myCanvas = document.getElementById("myCanvas");
myCanvas.width = 300;
myCanvas.height = 300;
 
var ctx = myCanvas.getContext("2d");


function drawLine(ctx, startX, startY, endX, endY){
    ctx.beginPath();
    ctx.moveTo(startX,startY);
    ctx.lineTo(endX,endY);
    ctx.stroke();
}


function drawArc(ctx, centerX, centerY, radius, startAngle, endAngle){
    ctx.beginPath();
    ctx.arc(centerX, centerY, radius, startAngle, endAngle);
    ctx.stroke();
}


function drawPieSlice(ctx,centerX, centerY, radius, startAngle, endAngle, color ){
    ctx.fillStyle = color;
    ctx.beginPath();
    ctx.moveTo(centerX,centerY);
    ctx.arc(centerX, centerY, radius, startAngle, endAngle);
    ctx.closePath();
    ctx.fill();
}


var myVinyls = {
    "Classical music": 10,
    "Alternative rock": 14,
    "Pop": 2,
    "Jazz": 12,
    "Indie": 9
};

/******************************************************************************************************/



var Piechart = function(options){
    this.options = options;
    this.canvas = options.canvas;
    this.ctx = this.canvas.getContext("2d");
    this.colors = options.colors;
 
    this.draw = function(){
        var total_value = 0;
        var color_index = 0;
        for (var categ in this.options.data){
            var val = this.options.data[categ];
            total_value += val;
        }
 
        var start_angle = 0;
        for (categ in this.options.data){
            val = this.options.data[categ];
            var slice_angle = 2 * Math.PI * val / total_value;
 
            drawPieSlice(
                this.ctx,
                this.canvas.width/2,
                this.canvas.height/2,
                Math.min(this.canvas.width/2,this.canvas.height/2),
                start_angle,
                start_angle+slice_angle,
                this.colors[color_index%this.colors.length]
            );
 
            start_angle += slice_angle;
            color_index++;
        }
 
        //drawing a white circle over the chart
        //to create the doughnut chart
        if (this.options.doughnutHoleSize){
            drawPieSlice(
                this.ctx,
                this.canvas.width/2,
                this.canvas.height/2,
                this.options.doughnutHoleSize * Math.min(this.canvas.width/2,this.canvas.height/2),
                0,
                2 * Math.PI,
                "white"
            );
        }
 
    }
}



var myDougnutChart = new Piechart(
    {
        canvas:myCanvas,
        data:myVinyls,
        colors:["#fde23e","#f16e23", "#57d9ff","#937e88", "red"],
        doughnutHoleSize:0.5
    }
);
myDougnutChart.draw();