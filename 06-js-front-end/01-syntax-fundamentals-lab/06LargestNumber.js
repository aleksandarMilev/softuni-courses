function solve(...numbers) {
    let largest = numbers[0];

    for (let i = 0; i < numbers.length; i++) {
        if (numbers[i] > largest) {
            largest = numbers[i];
        }
    }

    console.log(`The largest number is ${largest}.`);
}