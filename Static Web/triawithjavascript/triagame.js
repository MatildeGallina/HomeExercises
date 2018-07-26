let array = []
function fillArray(){
    for(let i = 0; i < 9; i++){
        array.push(" ")
    }
}
fillArray()

function randomNumber() {
    return Math.floor(Math.random() * 9)
}

function draw() {
    var value = randomNumber()
    while(array[value] != " "){
        value = randomNumber()
    }
    return value
}

function newDrawO() {
    let o = draw()
    array[o] = "o"
}

function newDrawX() {
    let x = draw()
    array[x] = "x"
}

function printTable() {
    console.log(" ", array[0], "|", array[1], "|", array[2])
    console.log("-------------")
    console.log(" ", array[3], "|", array[4], "|", array[5])
    console.log("-------------")
    console.log(" ", array[6], "|", array[7], "|", array[8])
    console.log()
}

let row1 = [0, 1, 2]
let row2 = [3, 4, 5]
let row3 = [6, 7, 8]

let col1 = [0, 3, 6]
let col2 = [1, 4, 7]
let col3 = [2, 5, 8]

let dig1 = [0, 4, 8]
let dig2 = [2, 4, 6]

let winAllignments = [row1, row2, row3, col1, col2, col3, dig1, dig2]

function end(){
    for(let allignment of winAllignments){
        let firstCell = allignment[0]
        let secondCell = allignment[1]
        let thirdCell = allignment[2]

        if(array[firstCell] != " " &&
            array[firstCell] == array[secondCell] &&
            array[secondCell] == array[thirdCell]){
            
            return true
        }
    }
    return false
}


var round = 1
var i = 0

while(true){
    console.log(`round ${round};`)
    console.log()
    
    newDrawO()
    printTable()
    i++
    if(end()){
        console.log("'o' wins")
        break;
    }

    else if(i == 9 && !end()){
        console.log("Game over!")
        break;
    }

    newDrawX()
    printTable()
    i++
    if(end()){
        console.log("'x' wins")
        break;
    }
    
    round++
}

