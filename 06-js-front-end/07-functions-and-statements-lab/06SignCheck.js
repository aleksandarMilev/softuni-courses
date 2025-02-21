function signCheck(number1, number2, number3) {
    const numbersAsArray = [number1, number2, number3];
    let negativesCount = 0;

    for(const number of numbersAsArray) {
        if(number < 0) {
            negativesCount++;
        }
    }

    return negativesCount % 2 === 0
        ? 'Positive' 
        : 'Negative';
}