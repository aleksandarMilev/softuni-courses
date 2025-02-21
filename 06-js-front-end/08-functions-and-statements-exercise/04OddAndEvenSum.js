function findTheSumOfTheEvenAndTheOddDigitsOfANumber(number) {
    const numberAsCharArray = number
        .toString()
        .split('');

    let evenSum = 0;
    let oddSum = 0;
    
    for(let i = 0; i < numberAsCharArray.length; i++) {
        let currentDigit = parseInt(numberAsCharArray[i])

        if(currentDigit % 2 === 0) {
            evenSum += currentDigit;
        } else {
            oddSum += currentDigit;
        }
    }

    return `Odd sum = ${oddSum}, Even sum = ${evenSum}`;
}