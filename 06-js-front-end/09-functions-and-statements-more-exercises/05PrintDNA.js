function printDna(dnaLenght) {
    let symbols = 'ATCGTTAGGG';
    let symbolsIndex = 0;

    for(let i = 0; i < dnaLenght; i++) {
        if(i % 4 === 0) {
            console.log(`**${symbols[symbolsIndex]}${symbols[symbolsIndex + 1]}**`);
        } else if (i % 4 === 1) {
            console.log(`*${symbols[symbolsIndex]}--${symbols[symbolsIndex + 1]}*`);
        } else if (i % 4 === 2) {
            console.log(`${symbols[symbolsIndex]}----${symbols[symbolsIndex + 1]}`);
        } else {
            console.log(`*${symbols[symbolsIndex]}--${symbols[symbolsIndex + 1]}*`);
        }

        symbolsIndex += 2;
        if(symbolsIndex >= 9) {
            symbolsIndex = 0;
        }
    }
}

function solve(dnaLength) {
    printDna(dnaLength);
}