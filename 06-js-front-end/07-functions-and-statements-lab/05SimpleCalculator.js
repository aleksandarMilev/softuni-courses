function getOperation(action) {
    switch(action) {
        case 'add':
            return (a, b) => a + b;
        case 'subtract':
            return (a, b) => a - b;
        case 'multiply':
            return (a, b) => a * b;
        case 'divide':
            return (a, b) => a / b;
    }
} 

function getResult(a, b, action) {
    const operation = getOperation(action);
    return operation(a, b);
}