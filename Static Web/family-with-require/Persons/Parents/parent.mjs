var Person = require('../person')
var Baby = require('../baby')

class Parent extends Person
{
    constructor(name) {
        super(name)
    }

    setChild(child) {
        if (child && child.constructor === Baby) {
        console.log(`Now ${this.name} has a baby, his name is ${child.name}`);
        this.child = child
        child.comforters.push(this)
        }
    }

    comfortBaby(child) {
        console.log(`I, ${this.name}, am comforting ${child.name}`)
    }
}

module.exports = Parent