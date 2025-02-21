function solve(text) {
    let textAsArray = text.split(' ');
    let result = [];
    const regex = /\b[A-Za-z]+\b/;

    for (let word of textAsArray) {
        if(word[0] === '#') {
            let wordWithoutHashTag = word.substring(1, word.length);

            if(regex.test(wordWithoutHashTag)) {
                result.push(wordWithoutHashTag);
            }
        }
    }

    for (const word of result) {
        console.log(word);
    }
}