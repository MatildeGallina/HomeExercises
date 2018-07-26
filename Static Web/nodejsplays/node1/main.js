// concatenation of strings and numbers
var truth = "La risposta a tutte le domande è " + 42
console.log(truth);


// create funtions
// dato un numero stampare il suo doppio e la  metà
function printDouble(n) {
    console.log(n * 2)
}
function printHalf(n) {
    console.log(n / 2)
}

printDouble(3)
printHalf(3)


// scope
function printTriple(n) {
    triple = n * 3
    console.log(`Il doppio di ${n} è ${triple}`)
}
function printFifthPart(n) {
    var fifthPart = n / 5
    console.log(`Un quinto di ${n} è ${fifthPart}`)
}

function printPower(n, e) {
    result = 1

    for (var i = 0; i < e; i++){
        result *= n
    }

    console.log(`${n} elevato alla ${e} fa ${result}`)
    
    console.log(`Il valore di 'i' fuori dal for è ${i}`)
}

printTriple(4)
printFifthPart(4)
printPower(3, 4)

console.log(`Il valore di 'triple' fuori dalla funzione è ${triple}`)
/* 
 * fifthPart genera un errore "fifthPart is not defined" perchè l'ho dichiarata con var dentro la funtion
 * console.log(`Il valore di 'fifthPart' fuori dalla funzione è ${fifthPart}`)
 */


