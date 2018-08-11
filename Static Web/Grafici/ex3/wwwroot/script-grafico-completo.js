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


var myVinyls1 = {
    "Classical music": 10,
    "Alternative rock": 14,
    "Pop": 2,
    "Jazz": 12,
    "Indie": 9
};

var myVinyls2 = {
    "Classical music": 10,
    "Alternative rock": 14,
    "Pop": 2,
    "Jazz": 12
};



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

        start_angle = 0;
        for (categ in this.options.data){
            val = this.options.data[categ];
            slice_angle = 2 * Math.PI * val / total_value;
            var pieRadius = Math.min(this.canvas.width/2,this.canvas.height/2);
            var labelX =
                this.canvas.width/2 + (pieRadius / 2) *
                Math.cos(start_angle + slice_angle/2);
            var labelY =
                this.canvas.height/2 + (pieRadius / 2) *
                Math.sin(start_angle + slice_angle/2);
         
            if (this.options.doughnutHoleSize){
                var offset = (pieRadius * this.options.doughnutHoleSize ) / 2;
                labelX =
                    this.canvas.width/2 + (offset + pieRadius / 2) *
                    Math.cos(start_angle + slice_angle/2);
                labelY =
                    this.canvas.height/2 + (offset + pieRadius / 2) *
                    Math.sin(start_angle + slice_angle/2);               
            }
         
            var labelText = Math.round(100 * val / total_value);
            this.ctx.fillStyle = "white";
            this.ctx.font = "bold 20px Arial";
            this.ctx.fillText(labelText+"%", labelX,labelY);
            start_angle += slice_angle;
        }

        sliceIndex = 0;
        var legend = document.querySelector("legend[for='myCanvas']");
        var ul = document.createElement("ul");
        legend.append(ul);
        for (categ in this.options.data){
            var li = document.createElement("li");
            li.style.listStyle = "none";
            li.style.borderLeft = "20px solid "+this.colors[sliceIndex%this.colors.length];
            li.style.padding = "5px";
            li.textContent = categ;
            ul.append(li);
            sliceIndex++;
        }
 
    }
}


// // torta
// var myDougnutChart1 = new Piechart(
//     {
//         canvas:myCanvas,
//         data:myVinyls1,
//         colors:["#fde23e","#f16e23", "#57d9ff","#937e88", "red"],
//     }
// );
// myDougnutChart1.draw();


// Ciambella
var myDougnutChart2 = new Piechart(
    {
        canvas:myCanvas,
        data:myVinyls2,
        colors:["#fde23e","#f16e23", "#57d9ff","#937e88"],
        doughnutHoleSize:0.5
    }
);
myDougnutChart2.draw();



/*******************************************************************************************************
**                                                                                                    **
**      Considerazioni                                                                                **
**                                                                                                    **
*******************************************************************************************************/

/*
    La legenda viene completata utilizzando lo stesso codice dell'ex2

    In alternativa neel'html invece di creare un tag legend creiamo un tag div con un id
    che viene usato per il riferimento nel foglio javascript: il codice cerca un elemento
    `legenda` passato tramite il parametro options. Se ne viene fornito uno, questo
    elemento viene riempito con il codice HTML contenente un riquadro colorato e il nome
    della categoria del modello di dati.

        // codice da aggiungere alla fine della funzione draw:
        ...
            if (this.options.legend){
                color_index = 0;
                var legendHTML = "";
                for (categ in this.options.data){
                    legendHTML += "<div><span style=
                            'display:inline-block;
                             width:20px;
                             background-color:"+this.colors[color_index++]+";'>
                         &nbsp;
                         </span> " + categ + "</div>";
                }
                this.options.legend.innerHTML = legendHTML;
            }
        ...
        
        
    Quindi cambia anche il modo in cui chiamare il disegno del grafico:

        // var myLegend = document.getElementById("myLegend");
        // 
        // var myDougnutChart = new Piechart(
        //     {
        //         canvas:myCanvas,
        //         data:myVinyls,
        //         colors:["#fde23e","#f16e23", "#57d9ff","#937e88"],
        //         legend:myLegend
        //     }
        // );
        // myDougnutChart.draw();
*/
