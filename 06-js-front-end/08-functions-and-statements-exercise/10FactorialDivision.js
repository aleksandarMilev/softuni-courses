function divideTheFactorialsOfTwoNumbers(firstNumber, secondNumber) {
    let firstNumberFactorial = 1;
    let secondNumberFactorial = 1;

    for(let i = 2; i <= firstNumber; i++) {
        firstNumberFactorial *= i;
    }

    for(let i = 2; i <= secondNumber; i++) {
        secondNumberFactorial *= i;
    }

    return (firstNumberFactorial / secondNumberFactorial).toFixed(2);
}