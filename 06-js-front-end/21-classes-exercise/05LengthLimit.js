class Stringer{
    constructor(innerString, innerLength){
        this.innerString = innerString;

        if(innerLength < 0){
            this.innerLength = 0;
        }
        else{
            this.innerLength = innerLength;
        }
    }

    increase(value) {
        this.innerLength += value;
    }

    decrease(value) {
        if(this.innerLength - value < 0){
            this.innerLength = 0;
            return;
        }

        this.innerLength -= value;
    }

    toString(){
        if(this.innerString.length == 0){
            return '...';
        }

        if(this.innerString.length > this.innerLength){
            let result = '';
            for (let i = 0; i < this.innerLength; i++) {
                result += this.innerString[i];
            }

            result += '...';
            return result;
        }

        return this.innerString;
    }
}