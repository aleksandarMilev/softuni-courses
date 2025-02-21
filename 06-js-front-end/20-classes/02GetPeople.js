class Person{
    constructor(firstName = null, lastName = null, age = 0, email = null){
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.email = email;
    }

    toString(){
        return `${this.firstName} ${this.lastName} (age: ${this.age}, email: ${this.email})`;
    }
}

function solve(){
    let people = [];

    people.push(new Person('Anna', 'Simpson', 22, 'anna@yahoo.com'));
    people.push(new Person('Softuni'));
    people.push(new Person('Stephan', 'Johnson', 25));
    people.push(new Person('Gabriel', 'Peterson', 24, 'g.p@gmail.com'));

    return people;
}