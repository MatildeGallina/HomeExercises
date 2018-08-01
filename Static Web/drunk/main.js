class Pub{
    createDrunkLevel(isDrunk, muchDrunk){
        if(isDrunk){
            if(muchDrunk){
                return new MuchDrunkLevel()
            } else{
                return new LittleDrunkLevel()
            }
        } else {
            return new NullDrunkLevel()
        }
    }
    doCreateDrunk(type, level){
        if (type == "wine")
            return new WineDrunk(level);
    
        else if (type == "beer")
            return new BeerDrunk(level);
        else{
            throw new Error
        }
    }
    createDrunk(isDrunk, type, muchDrunk){
        var level = this.createDrunkLevel(isDrunk, muchDrunk)
        return this.doCreateDrunk(type, level)
    }
}

class NullDrunkLevel{
   isDrunk(){
       return false
   }
}

class LittleDrunkLevel{
    isDrunk(){
        return true
    }
}

class MuchDrunkLevel{
    isDrunk(){
        return true
    }
}

class WineDrunk{
    constructor(level){
        this.level = level
    }
}

class BeerDrunk{
    constructor(level){
        this.level = level
    }
}

var p = new Pub()

var dl = p.createDrunkLevel(true, false)
console.log(dl)
console.log(dl.isDrunk())

var drunk = p.doCreateDrunk("wine", dl)
console.log(drunk)
console.log(drunk.level)

var drunk1 = p.createDrunk(true, "wine", false)
console.log(drunk1)
console.log(drunk1.level)

var drunk2 = p.createDrunk(true, "beer", true)
console.log(drunk2)
console.log(drunk2.level)

var drunk3 = p.createDrunk(false, "wine", false)
console.log(drunk3)
console.log(drunk3.level)
