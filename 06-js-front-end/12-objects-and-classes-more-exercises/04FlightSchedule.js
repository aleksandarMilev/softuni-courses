function printFightsSchedule(input) {
    const flightsAndDestinations = input[0];
    const flightsWithChangedStatus = input[1];
    const flightStatusToCheckFor = input[2][0];

    const intialStatus = 'Ready to fly';
    const flights = [];

    for (const info of flightsAndDestinations) {
        const[flightNumber, ...destination] = info.split(' ');

        const flight = {
            Destination: destination.join(' '),
            flightNumber,
            Status: intialStatus,
        };

        flights.push(flight);
    }

    for (const info of flightsWithChangedStatus) {
        const[flightNumber, status] = info.split(' ');

        const flight = flights.find(fl => fl.flightNumber === flightNumber);

        if(flight) {
            flight.Status = status;
        }
    }

    const flightsFiltered = flights
        .filter(fl => fl.Status === flightStatusToCheckFor);

    for (const flight of flightsFiltered) {
        delete flight.flightNumber;

        console.log(flight);
    }
}