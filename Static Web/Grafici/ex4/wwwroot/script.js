var myCanvas = document.getElementById("myCanvas");
myCanvas.width = 300;
myCanvas.height = 300;
  
var ctx = myCanvas.getContext("2d");

function drawLine(ctx, startX, startY, endX, endY, color){
    ctx.save();
    ctx.strokeStyle = color;
    ctx.beginPath();
    ctx.moveTo(startX,startY);
    ctx.lineTo(endX,endY);
    ctx.stroke();
    ctx.restore();
}

function drawBar(ctx, upperLeftCornerX, upperLeftCornerY, width, height,color){
    ctx.save();
    ctx.fillStyle=color;
    ctx.fillRect(upperLeftCornerX,upperLeftCornerY,width,height);
    ctx.restore();
}

var Barchart = function(options){
    this.options = options;
    this.canvas = options.canvas;
    this.ctx = this.canvas.getContext("2d");
    this.colors = options.colors;
  
    this.draw = function(){
        var maxValue = 100;
        
        var canvasActualHeight = this.canvas.height - this.options.padding * 2;
        var canvasActualWidth = this.canvas.width - this.options.padding * 2;
 
        //drawing the grid lines
        var gridValue = 0;
        while (gridValue <= maxValue){
            var gridY = canvasActualHeight * (1 - gridValue/maxValue) + this.options.padding;
            
            drawLine(
                this.ctx,
                0,
                gridY,
                this.canvas.width,
                gridY,
                this.options.gridColor
            );

            //writing grid markers
            this.ctx.save();
            this.ctx.fillStyle = this.options.gridColor;
            this.ctx.font = "bold 10px Arial";
            this.ctx.fillText(gridValue, 10,gridY - 2);
            this.ctx.restore();
 
            gridValue+=this.options.gridScale;
        }
  
        //drawing the bars
        var collIndex = 0
        var numberOfBars = Object.keys(this.options.data).length;
        var barSize = (canvasActualWidth)/numberOfBars;
        
        console.log("numero di colonne: " + numberOfBars)
        console.log("option.data: " + this.options.data)
        
        for(categ in this.options.data){
            
            console.log("[categ]: " + categ)
            console.log("option.data[categ]: " + this.options.data[categ])

            var barIndex = 0;
            var startX = this.options.padding + collIndex * barSize
            var startY

            console.log("startX: " + startX)
            console.log("startY: " + startY)

            for(var p of this.options.data[categ]){
                console.log("p: " + p)
                
                var barHeight = Math.round( canvasActualHeight * p / maxValue) ;
                console.log("altezza barra: " + barHeight)

                console.log("indice barra: " + barIndex)
                if(barIndex == 0)
                    startY = this.canvas.height - barHeight - this.options.padding
                else{
                    startY = startY - barHeight
                }

                console.log("startX: " + startX)
                console.log("startY: " + startY)
                
                drawBar(
                    this.ctx, // contesto
                    startX, // coordinata x di partenza
                    startY, // coordinata y di partenza
                    barSize, //width
                    barHeight, // height
                    this.colors[barIndex%this.colors.length] //colore barra
                )

                barIndex++;
            }

            collIndex ++;
        }
    }
}

var collezionisti = {
    bar1: [55, 35, 10],
    bar2: [25, 25, 50],
    bar3: [60, 40, 0],
    bar4: [75, 5, 20],
    bar5: [70, 20, 10]
}

var myBarchart = new Barchart(
    {
        canvas: myCanvas,
        padding: 10,
        gridScale: 10,
        gridColor: "#ccc",
        data: collezionisti,
        colors: ["green","yellow", "red"]
    }
);
myBarchart.draw();