function solve (year) {

    let result = 0;

    if ((year % 4 === 0 && year % 100 !== 0 ) || 
        (year % 400 === 0)) {
        result = 'yes'
    } else {
        result = 'no';
    } 

    console.log(result);
}