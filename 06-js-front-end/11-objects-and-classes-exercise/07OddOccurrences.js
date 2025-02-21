function OddFrequencyWords(sentence) {
    const words = {};
    const sentenceAsArray = sentence.split(' ');

    for (const word of sentenceAsArray) {
        let currentWord = word.toLowerCase();

        if(!words[currentWord]) {
            words[currentWord] = 0
        }

        words[currentWord]++;
    }

    let filteredWords = Object.entries(words)
        .filter(x => x[1] % 2 === 1)
        .map(x => x[0]);

    console.log(filteredWords.join(' '));
}