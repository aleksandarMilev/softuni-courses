class List{
    items = [];

    add(element){
        this.items.push(element);
        this.items.sort((a, b) => a - b);
        return this;
    }

    remove(index){
        if(index < 0 || index >= this.items.length){
            throw new Error();
        }
        
        this.items.splice(index, 1);
        return this;
    }

    get(index){
        if(index < 0 || index >= this.items.length){
            throw new Error();
        }
        
        return this.items[index];
    }

    get size(){
        return this.items.length;
    }
}