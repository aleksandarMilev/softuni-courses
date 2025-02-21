function solve(text) {
    const textAsArray = text.split(/(?=[A-Z])/);
    const result = textAsArray.join(', ');
    console.log(result);
}