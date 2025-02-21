function carParking(commands) {
    const cars = [];

    for (const line of commands) {
        const[command, carNumber] = line.split(', ');

        if(command === 'IN') {

            if(!cars.some(car => car.carNumber === carNumber)) {
                const car = {carNumber, status: true};
                cars.push(car); 
            } else {
                const car = cars.find(car => car.carNumber === carNumber);
                car.status = true;
            }
            
        } else if(command === 'OUT'){
            const car = cars.find(car => car.carNumber === carNumber);

            if(car) {
                car.status = false;
            }
        }
    }

    const carsInParking = cars
        .filter(car => car.status)
        .sort((a, b) => a.carNumber.localeCompare(b.carNumber));

    if(!carsInParking.length) {
        console.log('Parking Lot is Empty');
    } else {
        carsInParking.forEach(car => console.log(car.carNumber));
    }
}