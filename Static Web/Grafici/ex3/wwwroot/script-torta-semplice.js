// Prima di disegnare un grafico a torta vediamo come disegnare le sue parti:
//     - una linea
//     - un arco
//     - una forma colorata
// Usando i componenti del canvas

/*
    1) fare riferimento al canvas usando il suo id
    2) impostare le dimensioni (altezza e larghezza)
    3) impostare il contesto (2d) che contiene tutti i metodi di disegno
*/

var myCanvas = document.getElementById("myCanvas");
myCanvas.width = 300;
myCanvas.height = 300;
 
var ctx = myCanvas.getContext("2d");

/******************************************************************************************************/



function drawLine(ctx, startX, startY, endX, endY){
    ctx.beginPath();
    ctx.moveTo(startX,startY);
    ctx.lineTo(endX,endY);
    ctx.stroke();
}

// è molto simile al drawLine dei grafici a barre
// gli manca solo la possibilità di dare un colore alla linea e quindi manca
//  - il parametro
//  - settare la proprietà strokeStyle
//  - i metodi save() e restore()


function drawArc(ctx, centerX, centerY, radius, startAngle, endAngle){
    ctx.beginPath();
    ctx.arc(centerX, centerY, radius, startAngle, endAngle);
    ctx.stroke();
}

// - ctx: si riferisce al contesto disegnato
// - centerX: coordinata X del centro del cerchio
// - centerY: coordinata Y del centro del cerchio
// - radius: la coordinata X del punto finale della linea
// - startAngle: l'angolo iniziale in radianti dove inizia la parte del cerchio
// - endAngle: l'angolo finale in radianti dove finisce la parte del cerchio



// Poiché il nostro obiettivo è disegnare un grafico a torta composto da sezioni,
// creiamo una funzione che disegna una fetta di torta.

function drawPieSlice(ctx,centerX, centerY, radius, startAngle, endAngle, color ){
    ctx.fillStyle = color;
    ctx.beginPath();
    ctx.moveTo(centerX,centerY);
    ctx.arc(centerX, centerY, radius, startAngle, endAngle);
    ctx.closePath();
    ctx.fill();
}

// color: colore usato per riempire la fetta

/*
//    Esempi per chiamare le tre funzioni:
        drawLine(ctx,100,100,200,200);
        drawArc(ctx, 150,150,150, 0, Math.PI/3);
        drawPieSlice(ctx, 150,150,150, Math.PI/2, Math.PI/2 + Math.PI/4, '#ff0000');

/******************************************************************************************************/



/*******************************************************************************************************
**                                                                                                    **
**      Concettualmente ogni grafico ha due parti fondamentali:                                       **
**          1) Il modello dati                                                                        **
**              (contiene i dati numerici da rappresentare.                                           **
**              Questo è strutturato in un formato specifico per il tipo di grafico)                  **
**          2) La rappresentazione grafica                                                            **
**              (è come i dati numerici nel modello vengono rappresentati da elementi visivi)         **
**                                                                                                    **
*******************************************************************************************************/



// modello di dati

var myVinyls = {
    "Classical music": 10,
    "Alternative rock": 14,
    "Pop": 2,
    "Jazz": 12
};


// Per determinare l'angolo per la fetta di ogni categoria usiamo la formula:
//  slice angle = 2 * PI * category value / total value



/*******************************************************************************************************
**                                                                                                    **
**      Disegnamo il grafico:                                                                         **
**                                                                                                    **
*******************************************************************************************************/


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
 
    }
}

/*
    Costruttore:
        - canvas: riferimento al canvas dove vogliamo disegnare il grafico
        - data: riferimento a un oggetto che contiene il modello di dati
        - colors: un array che contiene i colore che vogliamo usare per ogni fetta
    La classe inizia memorizzando le opzioni passate come parametri.
    Memorizza il riferimento al canvar e crea un contesto di disegno anche memorizzato
    come membro della classe.
    Quindi memorizza l'array di colori passato come opzioni.

    Funzione draw():
        1) calcola la somma di tutti i valori nel modello di dati
        2) per ogni categoria nel modello applica la formula per calcolare l'ampiezza dell'angolo
           della fetta
        3) usa la funzione drawPieSlice() usando:
            - il centro del canvas come centro della fetta
            - come raggio il valore minimo tra metà della larghezza della tela e metà dell'altezza
              della tela (poiché non vogliamo che la nostra torta esca dall'area di disegno)
        4) compensa l'angolo iniziale e finale delle fette ogni volta che viene disegnata la fetta
           di una categoria, altrimenti le fette si sovrappongono
*/



var myPiechart = new Piechart(
    {
        canvas:myCanvas,
        data:myVinyls,
        colors:["#fde23e","#f16e23", "#57d9ff","#937e88"]
    }
);
myPiechart.draw();


