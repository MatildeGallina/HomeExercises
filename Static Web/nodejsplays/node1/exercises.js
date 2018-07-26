function printIsPrime(n){
    function isPrime(){
        if(!n){
            return  'Parameter not defined'
        }
        else if(!Number.isInteger(n)){
            return  'Parameter is not an integer'
        }
        var sqrt = Math.sqrt(n);
        for(i = 2; i <= sqrt; i++){
            if(n % i == 0)
                return false
        }
        return true
    }
    console.log(isPrime(n))
}


printIsPrime("ciao")
printIsPrime()
printIsPrime(3)
printIsPrime(4)
