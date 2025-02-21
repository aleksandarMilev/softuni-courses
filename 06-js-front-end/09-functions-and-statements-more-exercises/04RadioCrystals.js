function processCrystal(input) { 
    const cut = x => x /= 4;
    const lap = x => x *= 0.8;;
    const grind = x => x -= 20;
    const etch = x => x -= 2;
    const xray = x => x += 1;
    const transportingAndWashing = x => Math.floor(x);

    const targetThickness = input.shift();
    let chunks = input;

    for(let chunkThickness of chunks) {
        let cutTimes = 0;
        let lapTimes = 0;
        let grindTimes = 0;
        let etchTimes = 0;
        console.log(`Processing chunk ${chunkThickness} microns`);

        while(chunkThickness / 4 >= targetThickness) {
            chunkThickness = cut(chunkThickness);
            cutTimes++;
        }

        console.log(`Cut x${cutTimes}`);
        chunkThickness = transportingAndWashing(chunkThickness);
        console.log('Transporting and washing');

        if(chunkThickness === targetThickness) {
            console.log(`Finished crystal ${targetThickness} microns`);
            continue;
        }

        while(chunkThickness * 0.8 >= targetThickness) {
            chunkThickness = lap(chunkThickness);
            lapTimes++;
        }

        console.log(`Lap x${lapTimes}`);
        chunkThickness = transportingAndWashing(chunkThickness);
        console.log('Transporting and washing');

        if(chunkThickness === targetThickness) {
            console.log(`Finished crystal ${targetThickness} microns`);
            continue;
        }

        while(chunkThickness - 20 >= targetThickness) {
            chunkThickness = grind(chunkThickness);
            grindTimes++;
        }

        console.log(`Grind x${grindTimes}`);
        chunkThickness = transportingAndWashing(chunkThickness);
        console.log('Transporting and washing');

        if(chunkThickness === targetThickness) {
            console.log(`Finished crystal ${targetThickness} microns`);
            continue;
        }

        while(chunkThickness > targetThickness) {
            chunkThickness = etch(chunkThickness);
            etchTimes++;
        }

        console.log(`Etch x${etchTimes}`);
        chunkThickness = transportingAndWashing(chunkThickness);
        console.log('Transporting and washing');

        if(chunkThickness === targetThickness) {
            console.log(`Finished crystal ${targetThickness} microns`);
            continue;
        }

        if(chunkThickness < targetThickness) {
            chunkThickness = xray(chunkThickness);
            console.log(`X-ray x1`);
        }
        
        console.log(`Finished crystal ${targetThickness} microns`);
    }
}