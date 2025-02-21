function solve(array) {
    console.log(array.shift() + array.pop());
}

function solve1(array) {
    let firstNumber = array[0];
    let lastNumber = array[array.length - 1];
    const result = firstNumber + lastNumber;

    console.log(result);
}
