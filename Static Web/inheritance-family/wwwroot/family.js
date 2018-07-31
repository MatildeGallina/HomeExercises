function Parent(name){
    this.name = name
}
Parent.prototype.comfortBaby = function(child){
    console.log(`${this.name} takes the baby and comforts ${child}.`)
}

function Mum(name){
    this.name = name
    this.patience = 3
    this.child
}
Mum.prototype.makeChild = function(dad){
    console.log(`${this.name} is doing a baby with ${dad.name}.`)
    comfortes = []
    kyloRen = new Baby(`Kylo Ren`, comfortes)
    this.child = kyloRen
    dad.child = kyloRen
    return kyloRen
}
Mum.prototype.__proto__ = Parent.prototype

function Dad(name){
    this.name = name
    this.child
}
Dad.prototype.__proto__ = Parent.prototype

function Baby(name, comfortes){
    this.name = name
    this.comfortes = comfortes
}
Baby.prototype.addComfortes = function(comforter){
    this.comfortes.push(comforter)
}
Baby.prototype.cries = function(){
    console.log(`${this.name} cries.`)
    if(this.comfortes && Array.isArray(this.comfortes) && this.comfortes.length){
        for(let comforter of comfortes){
            comforter.comfortBaby(this.name)
        }
    }
    else{
        console.log(`${this.name} goes to the dark side`)
    }
}

var leila = new Mum(`Leila`)
var hanSolo = new Dad(`Han Solo`)

hanSolo.__proto__.comfortBaby = function(){
    console.log(`${this.name} escape in Mexico`)
    this.child.comfortes.pop()
}
leila.__proto__.comfortBaby = function(child){
    if(this.patience == 0){
        this.child.comfortes.pop()
        console.log(`${this.name} escapes with Chewbecca!`);
    }
    else
        console.log(`${this.name} takes the baby and comforts ${child}.`)
    this.patience --
}

var kyloRen = leila.makeChild(hanSolo, kyloRen)
kyloRen.addComfortes(leila)
kyloRen.addComfortes(hanSolo)
kyloRen.cries();
kyloRen.cries();
kyloRen.cries();
kyloRen.cries();
kyloRen.cries();