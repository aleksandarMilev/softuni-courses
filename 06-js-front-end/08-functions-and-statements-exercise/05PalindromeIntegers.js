function findIfEeachNumberInArrayIsAPalindrome(array) {
    for(const number of array) {
        const numberAsString = number
            .toString();

        const reversedNumberAsString = numberAsString   
            .split('')
            .reverse()
            .join('');

        console.log(numberAsString === reversedNumberAsString);
    }
} 