function solve(array, steps) {
    let result = [];

    for(let i = 0; i < array.length; i += steps) {
        result.push(array[i]);
    }

    return result;
}