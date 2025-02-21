function solve(groupCount, groupType, day) {
    let singlePrice;
    
    switch (groupType) {
        case 'Students':
            if (day === 'Friday') {
                singlePrice = 8.45;
            } else if (day === 'Saturday') {
                singlePrice = 9.8;
            } else {
                singlePrice = 10.46;
            }
            break;
        case 'Business':
            if (day === 'Friday') {
                singlePrice = 10.9;
            } else if (day === 'Saturday') {
                singlePrice = 15.6;
            } else {
                singlePrice = 16;
            }
            break;
        case 'Regular':
            if (day === 'Friday') {
                singlePrice = 15;
            } else if (day === 'Saturday') {
                singlePrice = 20;
            } else {
                singlePrice = 22.5;
            }
            break;
    }
    
    if (groupType === 'Students' && groupCount >= 30) {
        singlePrice *= 0.85;
    } else if (groupType === 'Business' && groupCount >= 100) {
        groupCount -= 10;
    } else if (groupType === 'Regular' && (groupCount >= 10 && groupCount <= 20)) {
        singlePrice *= 0.95;
    }

    const totalPrice = singlePrice * groupCount;

    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}