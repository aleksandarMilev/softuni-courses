function solve(wordToFind, text) {
    let textAsArray = text.split(' ');

    for(let word of textAsArray) {
        if(word.toLowerCase() === wordToFind.toLowerCase()) {
            console.log(wordToFind);
            return;
        }
    }

    console.log(`${wordToFind} not found!`);
}
