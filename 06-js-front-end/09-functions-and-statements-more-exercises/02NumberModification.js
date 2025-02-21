function findDivisible(numberAsString) {
    let divisible = 0;
    for (const digit of numberAsString) {
        divisible += parseInt(digit);
    }

    return divisible;
}  

function findDivisor(numberAsString) {
    return numberAsString.length;
}

function numberModification(number) {
    let numberAsString = number.toString();
    let divisible = findDivisible(numberAsString);
    let divisor = findDivisor(numberAsString);

    while(divisible / divisor <= 5) {
        numberAsString += '9';
        divisible = findDivisible(numberAsString);
        divisor = findDivisor(numberAsString);
    }

    return parseInt(numberAsString);
}

function solve(number) {
    console.log(numberModification(number));
}