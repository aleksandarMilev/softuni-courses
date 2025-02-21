function printTownInfo(townsInfoInput) {
    for(const info of townsInfoInput) {
        const[town, latitude, longitude] = info.split(' | ');

        const townInfo = {
            town,
            latitude: Number(latitude).toFixed(2),
            longitude: Number(longitude).toFixed(2),
        };

        console.log(townInfo)
    } 
}