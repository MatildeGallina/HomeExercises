function Person(name){
    this.name = name
}

Person.prototype.greet = function(){
    console.log(`Hello! I'm ${this.name}`)
}

var mario = new Person("mario")
var luigi = new Person("luigi")

console.log(mario)
console.log(luigi)

console.log(mario.name)
mario.greet()

function Student(name, code){
    this.name = name
    this.code = code
}
Student.prototype.__proto__ = Person.prototype
Student.prototype.greetWithCode = function() {
    console.log(`Hello I'm ${this.name} and my code is: ${this.code}`)
}

var frantz = new Student(`Frantz`, `code123`)
frantz.greet()
frantz.greetWithCode()