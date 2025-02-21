function calculateCarCleanliness(commands) {
    let percentsDone = 0;

    for (const command of commands) {
        switch (command) {
            case 'soap':
                percentsDone += 10;
                break;
            case 'water':
                percentsDone *= 1.20;
                break;
            case 'vacuum cleaner':
                percentsDone *= 1.25;
                break;
            case 'mud':
                percentsDone *= 0.9;
                break;
        }
    }

    return `The car is ${percentsDone.toFixed(2)}% clean.`;
}

function solve(commands) {
    console.log(calculateCarCleanliness(commands));
}