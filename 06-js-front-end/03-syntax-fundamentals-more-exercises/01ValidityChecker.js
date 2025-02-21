function solve(x1, y1, x2, y2) {
    function calculateDistance(xA, yA, xB, yB) {
        return Math.sqrt((xB - xA) ** 2 + (yB - yA) ** 2);
    }

    function isIntegerDistance(xA, yA, xB, yB) {
        const distance = calculateDistance(xA, yA, xB, yB);
        return distance % 1 === 0;
    }

    if (isIntegerDistance(x1, y1, 0, 0)) {
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }

    if (isIntegerDistance(x2, y2, 0, 0)) {
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    } else {
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }

    if (isIntegerDistance(x1, y1, x2, y2)) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }
}