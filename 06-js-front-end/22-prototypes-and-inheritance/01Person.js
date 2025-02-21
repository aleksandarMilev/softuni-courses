function createPerson(firstName, lastName){
    class Person{
        constructor(firstName, lastName){
            this.firstName = firstName,
            this.lastName = lastName
        }
    
        get fullName(){
            return `${this.firstName} ${this.lastName}`
        }
    
        set fullName(value){
            let regex = /^[A-Za-z]+ [A-Za-z]+$/;
    
            if(regex.test(value)){
                let [firstName, lastName] = value.split(' ');
                this.firstName = firstName;
                this.lastName = lastName;
            }
        }
    }

    return new Person(firstName, lastName);
}
