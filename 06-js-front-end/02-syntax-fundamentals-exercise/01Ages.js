function solve (age) {
    let personType;
    
    if (age >= 0 && age <= 2) {
        personType = 'baby';
    } else if (age > 2 && age <= 13) {
        personType = 'child';
    } else if (age > 13 && age <= 19) {
        personType = 'teensager';
    } else if (age > 19 && age <= 65) {
        personType = 'adult';
    } else if (age > 65) {
        personType = 'elder';
    } else {
        personType = 'out of bounds';
    }

    console.log(personType);
}