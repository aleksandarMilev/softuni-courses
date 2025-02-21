function solve(input) {
    let astronautsCount = Number(input.shift());

    let astronauts = {};

    for (let i = 0; i < astronautsCount; i++) {
        let[name, oxygenLevel, energyResources] = input.shift().split(' ');
        oxygenLevel = Number(oxygenLevel);
        energyResources = Number(energyResources);

        astronauts[name] = { name, oxygenLevel, energyResources };
    }

    while(input.length) {
        let[action, name, amount] = input.shift().split(' - ');
        amount = Number(amount);

        switch(action) {
            case 'Explore':
                if(astronauts[name].energyResources > amount) {
                    astronauts[name].energyResources -= amount;
                    console.log(`${astronauts[name].name} has successfully explored a new area and now has ${astronauts[name].energyResources} energy!`);
                } else {
                    console.log(`${astronauts[name].name} does not have enough energy to explore!`);
                }
                break;
            case 'Refuel':
                if(astronauts[name].energyResources + amount > 200) {
                    amount = 200 - astronauts[name].energyResources;
                }

                astronauts[name].energyResources += amount;
                console.log(`${astronauts[name].name} refueled their energy by ${amount}!`);
                break;
            case 'Breathe':
                if(astronauts[name].oxygenLevel + amount > 100) {
                    amount = 100 - astronauts[name].oxygenLevel;
                }

                astronauts[name].oxygenLevel += amount;
                console.log(`${astronauts[name].name} took a breath and recovered ${amount} oxygen!`);
                break;
            default:
                break;
        }
    }

    for (let astronaut in astronauts) {
        console.log(`Astronaut: ${astronauts[astronaut].name}, Oxygen: ${astronauts[astronaut].oxygenLevel}, Energy: ${astronauts[astronaut].energyResources}`);
    }
}