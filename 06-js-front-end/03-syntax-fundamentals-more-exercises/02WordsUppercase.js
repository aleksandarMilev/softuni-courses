function solve(text) {
    let textAsArray = text
        .split(/[\W]+/)
        .filter(Boolean);

    for(let i = 0; i < textAsArray.length; i++) {
        textAsArray[i] = textAsArray[i].toUpperCase();
    }

    console.log(textAsArray.join(', '))    
}