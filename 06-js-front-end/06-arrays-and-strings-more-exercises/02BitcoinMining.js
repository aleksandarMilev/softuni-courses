function solve(input) {
    let daysCount = 0;
    let dayOfTheFirstBitcoin = 0;
    let totalMoney = 0;
    let bitcoinsBoughtCount = 0;
    const bitcoinPrice = 11949.16;

    for(let goldInGrams of input) {
        daysCount++;
        if(daysCount % 3 === 0) {
            goldInGrams *= 0.7;
        }
        
        totalMoney += goldInGrams * 67.51;
        while(totalMoney >= bitcoinPrice) {
            totalMoney -= bitcoinPrice;
            bitcoinsBoughtCount++;

            if(bitcoinsBoughtCount === 1) {
                dayOfTheFirstBitcoin = daysCount;
            }
        }
    }

    console.log(`Bought bitcoins: ${bitcoinsBoughtCount}`);

    if(bitcoinsBoughtCount) {
        console.log(`Day of the first purchased bitcoin: ${dayOfTheFirstBitcoin}`);
    }
    
    console.log(`Left money: ${totalMoney.toFixed(2)} lv.`);
}