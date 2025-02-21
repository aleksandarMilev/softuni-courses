function findIfNumberIsPerfect(number) {
    let divisorsSum = 0;

    for(let i = 1; i < number; i++) {
        if(number % i === 0) {
            divisorsSum += i;
        }
    }

    if(number === divisorsSum || number / 2 === divisorsSum) {
        return 'We have a perfect number!';
    }

    return 'It\'s not so perfect.';
}