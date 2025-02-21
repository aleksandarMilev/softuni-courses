function solve(input) {
    let ridersCount = Number(input.shift());
    let riders = {};

    while(ridersCount) {
        createRiders();
    }

    while(input.length) {
        processComands();
    }

    Object
    .entries(riders)
    .forEach(r => {
        console.log(r[0]);
        console.log(`  Final position: ${r[1].position}`);
    });

    function createRiders() {
        let riderInfo = input.shift();
        let [name, fuelCapacity, position] = riderInfo.split('|');

        fuelCapacity = Number(fuelCapacity);
        fuelCapacity = fuelCapacity > 100 ? 100 : fuelCapacity;
        position = Number(position);

        riders[name] = { fuelCapacity, position };

        ridersCount--;
    }

    function processComands() {
        let command = input.shift().split(' - ');
        let action = command.shift();

        if (action === 'StopForFuel') {
            let [riderName, minimumFuel, changedPosition] = command;

            if (riders[riderName].fuelCapacity < minimumFuel) {
                riders[riderName].position = changedPosition;

                console.log(`${riderName} stopped to refuel but lost his position, now he is ${changedPosition}.`);
            } else {
                console.log(`${riderName} does not need to stop for fuel!`);
            }

        } else if (action === 'Overtaking') {
            let [firstRiderName, secondRiderName] = command;

            if (riders[firstRiderName].position < riders[secondRiderName].position) {
                let firstRiderPostion = riders[firstRiderName].position;

                riders[firstRiderName].position = riders[secondRiderName].position;
                riders[secondRiderName].position = firstRiderPostion;

                console.log(`${firstRiderName} overtook ${secondRiderName}!`);
            }
        } else if (action === 'EngineFail') {
            let [riderName, lapsLeft] = command;

            console.log(`${riderName} is out of the race because of a technical issue, ${lapsLeft} laps before the finish.`);

            delete riders[riderName];
        }
    }
}