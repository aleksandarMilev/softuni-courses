function solve(newArrayLength, array) {
    console.log(array
    .slice(0, newArrayLength)
    .reverse()
    .join(' '));
}


function solve1(newArrayLength, array) {
    let result = '';
    
    for (let i = newArrayLength - 1; i > 0; i--) {
        result += array[i] + ' ';
    }

    result += array[0];
    console.log(result);
}
