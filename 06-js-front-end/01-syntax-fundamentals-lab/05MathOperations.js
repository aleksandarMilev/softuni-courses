function solve(number1, number2, operator) {
    let result = undefined;

    switch (operator) {
        case '+':
            result = number1 + number2;
            break;
        case '-':
            result = number1 - number2;
            break;
        case '*':
            result = number1 * number2;
            break;
        case '/':
            result = number1 / number2;
            break;
        case '%':
            result = number1 % number2;
            break;
        case '**':
            result = number1 ** number2;
            break;
        default:
            result = 'Invalid operator!';
            break;
    }
    
    console.log(result);
}