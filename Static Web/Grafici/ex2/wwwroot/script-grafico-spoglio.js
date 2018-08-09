// Questo produce un riferimento all'elemento canvas e imposta la larghezza e l'altezza a 300px.
// Per disegnare nel canvas abbiamo solo bisogno di un riferimento al suo contesto 2D, che contiene
// tutti i metodi di disegno.

var myCanvas = document.getElementById("myCanvas");
myCanvas.width = 300;
myCanvas.height = 300;
  
var ctx = myCanvas.getContext("2d");

/***************************************************************************************************/



/***************************************************************************************************
**                                                                                                **
**  Disegnare il grafico a barre richiede solo il saper disegnare due elementi:                   **
**      1) disegnare una linea: per disegnare le linee della griglia.                             **
**      2) disegnare un rettangolo colorato-totalmente: per disegnare le barre di un grafico      **
**                                                                                                **
***************************************************************************************************/



function drawLine(ctx, startX, startY, endX, endY, color){
    ctx.save();
    ctx.strokeStyle = color;
    ctx.beginPath();
    ctx.moveTo(startX,startY);
    ctx.lineTo(endX,endY);
    ctx.stroke();
    ctx.restore();
}

// ctx: si riferisce al contesto disegnato
// startX: la coordinata X del punto iniziale della linea
// startY: la coordinata Y del punto iniziale della linea
// endX: la coordinata X del punto in cui termina la linea
// endY:  la coordinata Y del punto in cui termina la linea
// color: nient'altro che il colore della linea

/* - Stiamo modificando le impostazioni del colore per il strokeStyle. Questo determina il colore 
     usato per disegnare la linea. Usiamo ctx.save() e ctx.restore() in modo da non influenzare i
     colori usati al di fuori di questa funzione.

    - Disegniamo la linea chiamando beginPath(). Questo informa il contesto del disegno che noi stiamo
      iniziando a disegnare qualcosa di nuovo nel canvas. Usiamo moveTo() per impostare il punto
      d'inizio, chiamiamo  invece lineTo() per indicare il punto finale, e quindi eseguiamo il disegno
      attuale richiamando stroke().

/****************************************************************************************************/

function drawBar(ctx, upperLeftCornerX, upperLeftCornerY, width, height,color){
    ctx.save();
    ctx.fillStyle=color;
    ctx.fillRect(upperLeftCornerX,upperLeftCornerY,width,height);
    ctx.restore();
}

// ctx: riferimento al contesto del disegno.
// upperLeftCornerX: la coordinata X dell'angolo a sinistra della barra
// upperLeftCornerY: la coordinata Y dell'angolo a sinistra della barra
// width: la larghezza della barra
// height: l'altezza della barra
// color: il colore della barra

/****************************************************************************************************/



// Dati del grafico racchiusi in un oggetto

var myVinyls = {
    "Classical music": 10,
    "Alternative rock": 14,
    "Pop": 2,
    "Jazz": 12
};


var isdf = {
    "a": 25,
    "b": 4,
    "c": 9,
    "d": 14,
    "e": 20,
}

//   // stampo il contenuto di myVinyls
//   console.log("c.l di ogni categoria in myVinyls")
//   for (var categ in myVinyls){
//       console.log(myVinyls[categ]);
//   }
//   console.log("c.l dell'oggeto myVinyls")
//   console.log(myVinyls)

/***************************************************************************************************
**                                                                                                **
**  Implementare la funzione draw:                                                                **
**      1) disegnerà il grafico disegnando prima le linee della griglia                           **
**      2) successivamente imarcatori della griglia                                               **
**      3) infine le barre usando i parametri passati attraverso l'oggetto options                **                                                                         **
**                                                                                                **
***************************************************************************************************/


/* La classe inizia memorizzando le opzioni passate come parametri.
    1) memorizza il riferiment del canvas
    2) crea un contesto del disegno anche memorizzato come membro della classe.
    3) memorizza l'array di colors passate come opzioni.

  Osservando la funzione draw:
        1) Inizialmente calcoliamo il valore massimo per il nostro modello dei dati
            (Abbiamo bisogno di questo numero perché avremo bisogno di ridimensionare tutte
            le barre in base a questo valore e in base alle dimensioni del canvas. Altrimenti
            le nostre barre potrebbero uscire dall'area di visualizzazione)
        2) Le variabili canvasActualHeight e il canvasActualWidth memorizzano l'altezza e la
            larghezza del canvas regolata usando il valore del padding passato tramite options.
            La variabile padding indica il numero dei pixel tra il bordo del canvas e l'interno
            del grafico.
        3) Disegniamo le linee della griglia del grafico
            (La variabile  options.gridScale imposta il pezzo utilizzato per disegnare le linee.
            Quindi un gridScale di 10 significherà disegnare linee di griglia ogni 10 unità.
            Per disegnare le linee della griglia, usiamo la funzione di aiuto drawLine(); per il
            colore delle linee della griglia, lo prendiamo dalla variabile options.gridColor.
            Si noti che le coordinate del canvas iniziano da 0,0 nell'angolo in alto a sinistra
            che aumentano a destra e in basso, mentre i valori della griglia aumentano di valore
            dal basso verso l'alto. Questo è il motivo per cui usiamo  1 - gridValue/maxValue nella
            formula per calcolare il valore di gridY.
            Per ogni linea della griglia, disegniamo anche il valore della linea della griglia di 2
            pixel sopra la linea della griglia, ecco perché abbiamo  gridY - 2 per le coordinate Y
            del testo)
        4) Disegniamo le barre
            (Usando la funzione di aiuto drawBar().
            Il calcolo matematico per calcolare l'altezza e la larghezza di ogni barra è abbastanza
            semplice; questi tengono conto del padding e del valore e colore per ogni categoria nel
            modello di dati del grafico)
*/

var Barchart = function(options){
    this.options = options;
    this.canvas = options.canvas;
    this.ctx = this.canvas.getContext("2d");
    this.colors = options.colors;
  
    this.draw = function(){
        var maxValue = 0;
        for (var categ in this.options.data){
            maxValue = Math.max(maxValue,this.options.data[categ]);
        }
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
        var barIndex = 0;
        var numberOfBars = Object.keys(this.options.data).length;
        var barSize = (canvasActualWidth)/numberOfBars;
 
        for (categ in this.options.data){
            var val = this.options.data[categ];
            var barHeight = Math.round( canvasActualHeight * val/maxValue) ;
            drawBar(
                this.ctx,
                this.options.padding + barIndex * barSize,
                this.canvas.height - barHeight - this.options.padding,
                barSize,
                barHeight,
                this.colors[barIndex%this.colors.length]
            );
 
            barIndex++;
        }
  
    }
}

/****************************************************************************************************/



// Come usare il componente del grafico a barre:
//  istanziare la classe Barchart e richiamare la funzione draw()

// var myBarchart = new Barchart(
//     {
//         canvas:myCanvas,
//         padding:10,
//         gridScale:5,
//         gridColor:"#ccc",
//         data:myVinyls,
//         colors:["#a55ca5","#67b6c7", "#bccd7a","#eb9743"]
//     }
// );
// myBarchart.draw();

var myBarchart = new Barchart(
    {
        canvas:myCanvas,
        padding:10,
        gridScale:5,
        gridColor:"#ccc",
        data:isdf,
        colors:["#a55ca5","#67b6c7", "#bccd7a","#eb9743", "red"]
    }
);
myBarchart.draw();