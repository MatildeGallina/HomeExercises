var Person = require('../person')
var Parent = require('./parent')
var Baby = require('../baby')

class Mum extends Parent {
    constructor(name) {
        super(name)
        this.patience = 3
    }

    makeBaby(childName, dad) {
        if (!dad) {
        throw new Error("You are not the Holy Mary!")
        }
        var baby = new Baby(childName)
        this.setChild(baby)
        dad.setChild(baby)
    }

    comfortBaby(child) {
        if (Number.isNaN(this.patience)) {
        throw new Error("patience of the object has been hacked!")
        }
        if (this.patience > 0) {
        console.log(`I, ${this.name}, am comforting ${child.name}`)
        this.patience--
        } else {
        console.log(`${this.name} escapes with Chewbacca`)
        child.comforters.remove(this)
        }
    }
}

module.exports = Mum