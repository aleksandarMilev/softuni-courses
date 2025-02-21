function charactersInRange(firstChar, secondChar) {
    const smallerChar = firstChar < secondChar ? firstChar : secondChar;
    const biggerChar = firstChar > secondChar ? firstChar : secondChar;

    const smallerCharCode = smallerChar.charCodeAt(0);
    const biggerCharCode = biggerChar.charCodeAt(0);

    let result = [];
    for(let i = smallerCharCode + 1; i < biggerCharCode; i++) {
        result.push(String.fromCharCode(i));
    }

    return result.join(' ');
}