Array.prototype.remove = function(item) {
    var index = this.indexOf(item)
    if (index > -1) {
      this.splice(index, 1)
    }
}

// var Baby = require('./Persons/baby')
// var Mum = require('./Persons/Parents/mum')
// var Dad = require('./Persons/Parents/dad')

import Baby from './Persons/baby'
import Mum from './Persons/Parents/mum'
import Dad from './Persons/Parents/dad'

console.log("*** Family with Interfaces!");
console.log("A long long time ago, in a galaxy far away...");

var jediSpirit = {
    comfortBaby: function(child) {
        console.log(`The Jedi Spirit is comforting ${child.name}`)
    }
}

var leila = new Mum("Leila")
var hanSolo = new Dad("Han Solo")
leila.makeBaby("Kylo Ren", hanSolo)

var kyloRen = leila.child
// kyloRen.comforters.push(jediSpirit)

kyloRen.cries()
kyloRen.cries()
kyloRen.cries()
kyloRen.cries()
kyloRen.cries()

var luke = new Baby('luke')
console.log(luke.name)