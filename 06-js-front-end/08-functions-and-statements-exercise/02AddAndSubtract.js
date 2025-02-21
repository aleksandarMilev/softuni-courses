function addAndSubtract(firstNumber, secondNumber, thirdNumber) {
    const sum = (a, b) => a + b; 
    const subtract = (a, b) => a - b;

    return subtract(sum(firstNumber,secondNumber) ,thirdNumber);
}

