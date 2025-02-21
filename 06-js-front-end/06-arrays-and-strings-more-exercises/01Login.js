function solve(input) {
    const username = input.shift();
    let invalidInputsCount = 0;

    for (let password of input) {
        if(password.split('').reverse().join('') === username) {
            console.log(`User ${username} logged in.`);
            break;
        } else {
            invalidInputsCount++;
            
            if(invalidInputsCount === 4) {
                console.log(`User ${username} blocked!`);
                break;
            } else {
                console.log('Incorrect password. Try again.');
            }
        }
    }
}