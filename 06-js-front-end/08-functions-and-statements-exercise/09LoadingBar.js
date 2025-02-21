function visualiseLoadingBar(percentsDone) {
    if(percentsDone === 100) {
        console.log('100% Complete!');
        console.log('[%%%%%%%%%%]');
        return;
    }

    let output = `${percentsDone}% [`;
    const charsCount = 10;
    const percentCharsCount = percentsDone / charsCount;

    for(let i = 0; i < percentCharsCount; i++) {
        output += '%';
    }

    for(let i = percentCharsCount + 1; i <= charsCount; i++) {
        output += '.'
    }

    output += ']';
    console.log(output);
    console.log('Still loading...');
}