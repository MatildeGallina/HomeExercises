/*******************************************************************************************************
**                                                                                                    **
**      Aggiunta di etichette e una legenda del grafico                                               **
**                                                                                                    **
*******************************************************************************************************/


/*
    Di solito, i valori associati alle sezioni sono rappresentati come valori percentuali
    calcolati come `100 * valore associato a una sezione / valore totale`, con l'intero
    cerchio che rappresenta il 100%.

    Per aggiungere a ogni fetta il valore percentuale corrispondente viene usata la funzione
    fillText(text,x,y) che prende come parametri:
        - text: il testo
        - x: coordinata x
        - y: coordinata y

        Per calcorare le coordinate vengono usate le coordinate polari che usano un raggio e
        un angolo per definire la posizione di un punto.
        Le due formule usate sono:
        1) x = R * cos(angle)
        2) y = R * sin(angle)

    
    Posizioneremo il testo a metà del raggio del grafico a torta e a metà dell'angolo per ogni
    fetta di torta. Per fare ciò, dobbiamo modificare la nostra classe Piechart e aggiungere
    il seguente codice subito dopo il blocco if (this.options.doughnutHoleSize) {...}:

        // ...
        // start_angle = 0;
        // for (categ in this.options.data){
        //     val = this.options.data[categ];
        //     slice_angle = 2 * Math.PI * val / total_value;
        //     var pieRadius = Math.min(this.canvas.width/2,this.canvas.height/2);
        //     var labelX = 
        //          this.canvas.width/2 + (pieRadius / 2) * Math.cos(start_angle + slice_angle/2);
        //     var labelY = 
        //          this.canvas.height/2 + (pieRadius / 2) * Math.sin(start_angle + slice_angle/2);
        // 
        //     if (this.options.doughnutHoleSize){
        //         var offset = (pieRadius * this.options.doughnutHoleSize ) / 2;
        //         labelX = 
        //          this.canvas.width/2 + (offset + pieRadius / 2) *
        //          Math.cos(start_angle + slice_angle/2);
        //         labelY =
        //          this.canvas.height/2 + (offset + pieRadius / 2) *
        //          Math.sin(start_angle + slice_angle/2);               
        //     }
        // 
        //     var labelText = Math.round(100 * val / total_value);
        //     this.ctx.fillStyle = "white";
        //     this.ctx.font = "bold 20px Arial";
        //     this.ctx.fillText(labelText+"%", labelX,labelY);
        //     start_angle += slice_angle;
        // }
        // ...

    Per ogni sezione:
        1) calcola la percentuale
        2) calcola la posizione
        3) utilizza il metodo fillText () per disegnarlo sul grafico
        4) utilizza le proprietà:
            - fillStyle per settare il colore del testo (bianco)
            - font per settare dimensioni, stile e il font dell'etichetta


    // Per i grafici a ciambella:
            Se viene impostato doughnutHoleSize, l'etichetta verrà spinta verso il bordo del
            grafico per centrarlo sulla fetta di ciambella.
*/



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
 
    }
}


// torta
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