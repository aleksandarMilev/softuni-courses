function printProductDescription(jsonStrings) {
    const dictionary = {};

    jsonStrings.forEach(json => {
        const wordDescriptionPair = JSON.parse(json);

        for([word, description] of Object.entries(wordDescriptionPair)) {
            dictionary[word] = description;
        }
    });

    Object
        .entries(dictionary)
        .sort((a, b) => a[0].localeCompare(b[0]))
        .forEach(([word, description]) => console.log(`Term: ${word} => Definition: ${description}`));
}