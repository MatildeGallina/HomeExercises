var Parent = require('./parent')

class Dad extends Parent
{
    constructor(name) {
        super(name)
    }

    comfortBaby(child) {
        console.log(`${this.name} escapes to Mexico!`)
        child.comforters.remove(this)
    }  
}

module.exports = Dad