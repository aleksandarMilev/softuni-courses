function findSmallesNumber(...numbers) {
    let numbersAsArray = Array.from(numbers);
    let minNumber = Number.MAX_SAFE_INTEGER;

    for(const number of numbersAsArray) {
        if(number < minNumber) {
            minNumber = number;
        }
    }

    return minNumber; 
}