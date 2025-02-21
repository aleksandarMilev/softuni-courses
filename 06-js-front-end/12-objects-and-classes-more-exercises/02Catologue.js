function printCatalogue(input) {
    const catalogue = {};

    for (const element of input) {
        let[name, price] = element.split(' : ');
        const letter = name[0];
        price = Number(price);

        if(!catalogue[letter]) {
            catalogue[letter] = [];
        }

        catalogue[letter].push({name, price});
    }

    const sortedByLetter = Object
        .keys(catalogue)
        .sort((a, b) => a.localeCompare(b));

    for (const letter of sortedByLetter) {
        console.log(letter);

        const sortedLetterElements = catalogue[letter]
            .sort((a, b) => a.name.localeCompare(b.name));

        sortedLetterElements.forEach(product => {
            console.log(`${product.name}: ${product.price}`);
        });
    }
}