var Person = require('./person')

function isFunction(functionToCheck) {
    return !!functionToCheck && {}.toString.call(functionToCheck) === '[object Function]'
}

class Baby extends Person
{
    constructor(name) {
        super(name)
        this.comforters = []
    }

    cries() {
        console.log(`${this.name} started to cry!`)
        if (this.comforters && Array.isArray(this.comforters) && this.comforters.length) {
            for(let c of this.comforters) {
                if (c && c.comfortBaby && isFunction(c.comfortBaby)) {
                c.comfortBaby(this)
                }
            }
        } else {
        console.log(`${this.name} goes to the Dark Side!`)
        }
    }
}

module.exports = Baby