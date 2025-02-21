function solve(number) {
    const numberAsString = number.toString();
    let result = 0;
    let allDigitsSame = true;

    for (let i = 0; i < numberAsString.length - 1; i++) {
        if (numberAsString[i] !== numberAsString[i + 1]) {
            allDigitsSame = false;
        }

        result += parseInt(numberAsString[i]);
    }

    result += parseInt(numberAsString[numberAsString.length - 1]);

    console.log(allDigitsSame);
    console.log(result);
}