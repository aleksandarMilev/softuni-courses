function printMatrix(number) {
    let output = '';

    for(let i = 0; i < number; i++) {
        for(let j = 0; j < number - 1; j++) {
            output += number + ' ';
        }

        output += number;
        output += '\n';
    }

    return output;
}