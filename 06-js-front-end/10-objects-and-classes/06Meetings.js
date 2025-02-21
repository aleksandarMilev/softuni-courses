function meetings(meetingsInput) {
    const meetings = {};

    for(const meet of meetingsInput) {
        const [day, name] = meet.split(' ');

        if(meetings[day]) {
            console.log(`Conflict on ${day}!`);
        } else {
            meetings[day] = name;        
            console.log(`Scheduled for ${day}`);  
        }
    }

    for(const day in meetings) {
        console.log(`${day} -> ${meetings[day]}`);
    }
}
