function printCatInfo(catInfoInput) {
    class Cat {
        constructor(name, age) {
            this.name = name;
            this.age = age;
        }
    
        meow() {
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    for(const info of catInfoInput) {
        const [name, age] = info.split(' ');

        const cat = new Cat(name, age);
        cat.meow();
    }
}