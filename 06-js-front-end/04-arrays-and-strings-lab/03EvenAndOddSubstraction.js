function solve(array) {
    console.log(
        array
        .filter(x => x % 2 === 0)
        .reduce((a, b) => a + b, 0) -
        array
        .filter(x => x % 2 !== 0)
        .reduce((a, b) => a + b, 0));
}

function solve1(array) {
    let evenNumbersSum = 0;
    let oddNumberSum = 0;

    for (let i = 0; i < array.length; i++) {
        if(array[i] % 2 === 0) {
            evenNumbersSum += array[i];
        } else {
            oddNumberSum += array[i];
        }
    }

    const result = evenNumbersSum - oddNumberSum;
    console.log(result);
}