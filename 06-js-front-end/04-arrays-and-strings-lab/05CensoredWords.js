function solve(text, wordForReplace) {
    while(text.includes(wordForReplace)) {
        text = text.replace(wordForReplace, '*'.repeat(wordForReplace.length));
    }

    console.log(text);
}
