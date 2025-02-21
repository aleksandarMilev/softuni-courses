//function declaration
function printHelloWorld() {
    console.log('I\'m a function which prints "Hello, Wolrd!"');
}

printHelloWorld();

//function expression
const fuctionExpression = function() {
    console.log('I\'m a function expression')
}

fuctionExpression();

//defaultReturnValue
function someVoidFunction() {
    console.log('I return "undefined" because I\'m a void function');
}

const defaultReturnValue = someVoidFunction();
console.log(defaultReturnValue);

//Pass function as argument to another fucnction
function someFunction(someFunctionAsParameter, someNumber, anotherNumber) {
    const result = someFunctionAsParameter(someNumber, anotherNumber);
    console.log(result);
}

    //By reference
    function sum(a, b) {
        return a + b;
    }

    someFunction(sum, 2, 3);

    //By function expression body
    someFunction(function(a, b) {
        return a + b; 
    }, 2, 3);

    //By arrow function
    someFunction((a, b) => a + b, 2, 3);

//Return function as result from function
function createGreeting(greeting) {
    return function(name) {
        return `${greeting}, ${name}!`;
    };
  }
  
const greetHello = createGreeting("Hello");
console.log(greetHello("Alice"));

//arrow functions

    //statement body
    const arrowFunctionStatement = (a, b) => {
        /*We cah have anything more here:
            if(a > 0) {...} 
            else if (b < 0) {...}
            else {...}
            while(true) {}
            for(let i = 0; i < 10; i++) {}
        */
        return a + b;
    }

    console.log(arrowFunctionStatement(2, 3));

    //expressionBody
    const arrowFunctionExpression = (a, b) => a + b;
    console.log(arrowFunctionExpression(2, 3));

//arrow function with one parameter
const arrowFunctionWithOneParameter = x => console.log(`I\'m an arrow function with one parameter - ${x}`);
arrowFunctionWithOneParameter('Hello!');

//arrow function with two or more parameters
const arrowFunctionWithTwoOrMoreParameters = (x, y, z) => console.log(`I\'m an arrow function with three parameters - ${x}${y}${z}`);
arrowFunctionWithTwoOrMoreParameters('Hello, ', 'World',  '!');