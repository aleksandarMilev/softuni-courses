function solve(text, word) {
    const regex = new RegExp(`\\b${word}\\b`, 'gi');
    const matches = text.match(regex);
    let count = 0;

    if(matches) {
        count = matches.length;
    } else {
        count = 0;
    }

    console.log(count);
}