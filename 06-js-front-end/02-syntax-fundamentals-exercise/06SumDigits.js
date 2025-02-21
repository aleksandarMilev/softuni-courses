function solve(number) {
    let sum = 0;
    const numberAsString = number.toString();

    for (let i = 0; i < numberAsString.length; i++) {
        sum += parseInt(numberAsString[i]);
    }

    console.log(sum);
}