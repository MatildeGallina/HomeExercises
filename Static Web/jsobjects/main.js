function greetFunction(){
    console.log(`Hello, I'${this.name}`)
}

var mario = {
    name : 'Mario',
    surname: 'Rossi',
    age: 55,
    greet : greetFunction
}

mario.greet()
greetFunction()

var robot = {
    name: "Siri",
    serialNumber: 123456789,
    greetHuman: greetFunction
}

robot.greetHuman()

var luigi = {
    name: "Luigi",
    greet: mario.greet
}

luigi.greet()

var fakeHuman = {
    name: "fake",
    greet: function(){
        mario.greet.call(this)
    }
}

fakeHuman.greet()