class Ticket{
    constructor(destination, price, status){
        this.destination = destination;
        this.price = parseFloat(price);
        this.status = status;
    }
}

function solve(description, sorting){
    let tickets =  description.map(descr => {
        let[destination, price, status] = descr.split('|');
        return new Ticket(destination, price, status);
    });

    tickets.sort((a, b) => {
        if (sorting === 'destination') {
            return a.destination.localeCompare(b.destination);
        } else if (sorting === 'price') {
            return a.price - b.price;
        } else if (sorting === 'status') {
            return a.status.localeCompare(b.status);
        }
        return 0;
    });

    return tickets;
}