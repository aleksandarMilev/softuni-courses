function countWordsOccurrences(input) {
    const wordsToSearchFor = input
        .shift()
        .split(' ');

    const wordsOccurrences = {};

    for (const word of wordsToSearchFor) {
        wordsOccurrences[word] = 0;        
    }

    for (const word of input) {
        if(wordsToSearchFor.includes(word)) {
            wordsOccurrences[word]++;
        }
    }

    const arrayOccurrences = Object
        .entries(wordsOccurrences)
        .sort((a, b) => b[1] - a[1]);

    const sortedOccurrences = Object.fromEntries(arrayOccurrences);

    for (const word in sortedOccurrences) {
        console.log(`${word} - ${sortedOccurrences[word]}`);
    }
}