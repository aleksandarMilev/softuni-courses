function solve(wordsForReplace, text) {
    let wordsForReplaceAsArray = wordsForReplace.split(', ');
    let textAsArray = text.split(' ');

    for (let i = 0; i < textAsArray.length; i++) {
        if(textAsArray[i].includes('*')) {
            for (const wordForReplace of wordsForReplaceAsArray) {
                if(textAsArray[i].length === wordForReplace.length) {
                    textAsArray[i] = wordForReplace;
                }
            }
        }
    }

    console.log(textAsArray.join(' '));
}
