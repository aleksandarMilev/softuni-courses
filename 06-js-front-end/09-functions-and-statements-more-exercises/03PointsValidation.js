function findDistanceBetweenAPointAndTheStart(x, y) {
    return Math.sqrt(Math.pow(x, 2) + Math.pow(y, 2));
}

function findDistanceBetweenTwoPoints(x1, y1, x2, y2) {
    return Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2));
}

function pointsValidation(points) {
    const x1 = points[0];
    const y1 = points[1];
    const x2 = points[2];
    const y2 = points[3];

    const isx1y1ToStartValid = Number
        .isInteger(findDistanceBetweenAPointAndTheStart(x1, y1))
        ? 'valid' 
        : 'invalid';

        const isx2y2ToStartValid = Number
        .isInteger(findDistanceBetweenAPointAndTheStart(x2, y2)) 
        ? 'valid' 
        : 'invalid';
        
        const isx1y1Tox2y2Valid = Number
        .isInteger(findDistanceBetweenTwoPoints(x1, y1, x2, y2))
        ? 'valid' 
        : 'invalid';
        
    console.log(`{${x1}, ${y1}} to {0, 0} is ${isx1y1ToStartValid}`);
    console.log(`{${x2}, ${y2}} to {0, 0} is ${isx2y2ToStartValid}`);
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${isx1y1Tox2y2Valid}`);
}

function solve(points) {
    pointsValidation(points);
}