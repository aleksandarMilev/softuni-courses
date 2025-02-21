function solve(string, startIndex, countOfElementsToDelete) {
    console.log(string.substring(startIndex, startIndex + countOfElementsToDelete));
}

function solve1(string, startIndex, countOfElementsToDelete) {
    let result = '';
    
    for(let i = startIndex; i < startIndex + countOfElementsToDelete; i++) {
        result += string[i];
    }

    console.log(result);
}
