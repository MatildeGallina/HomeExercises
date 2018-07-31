var flyer ={
    fly: function(){
        if(this.name)
            console.log(`I'm ${this.name} and I'm flying`)
        else
            console.log(`I have no name`)
    }
}

console.log("Calling 'fly' on the flyer...")
flyer.fly()
console.log()

var swimmer = {
    swim: function(){
        console.log(`I'm ${this.name} and I'm swimming`)
    }
}

var aquaman = {
    name = 'Aquaman'
}

console.log('Aquaman name;', aquaman.name)

console.log('Applying flyer proto to aquaman...')
aquaman.__proto__ = flyer
aquaman.fly()
console.log()

console.log('Applying swimmer proto to aquaman')
aquaman.__proto__ = swimmer
aquaman.swim()
console.log()
