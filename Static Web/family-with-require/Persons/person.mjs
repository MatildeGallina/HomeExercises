class Person {
    constructor(name) {
        this.__name__ = name
    }
    
    get name(){
        return this.__name__
    }
    
    set name(value) {
        this.__name__ = value
    }
}

module.exports = Person