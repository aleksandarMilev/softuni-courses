function solve (firstNum, secondNum) {
    let numbers = '';
    let result = 0;

    for (let i = firstNum; i <= secondNum; i++) {
        numbers += i.toString() + ' ';
        result += i;
    }

    console.log(numbers.trimEnd())
    console.log(`Sum: ${result}`);
}