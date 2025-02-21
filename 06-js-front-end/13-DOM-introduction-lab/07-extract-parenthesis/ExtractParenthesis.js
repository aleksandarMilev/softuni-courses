function extract(content) {
    const text = document.getElementById('content').textContent;
    let startIndex = 0;
    let endIndex = 0;
    let result = [];

    for (let i = 0; i < text.length; i++) {
        if(text[i] === '(') {
            startIndex = i + 1;
        }

        if(text[i] === ')') {
            endIndex = i;
            result.push(text.substring(startIndex, endIndex));
        }
    }

    return result.join('; ');
}