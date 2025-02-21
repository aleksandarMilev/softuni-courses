function checkIfStringLengthIsInTheRange6To10Chars(string) {
    return string.length >= 6 && string.length <= 10;
}

function checkIfStringConsistsOnlyLettersAndDigits(string) {
    const regex = /^[A-Za-z0-9]+$/;
    return regex.test(string);
}

function checkIfStringConsistsAtLeastTwoDigits(string) {
    const regex = /\d/g;
    const result = string.match(regex);

    if(result !== null){
        return result.length >= 2;
    }

    return false;
}


function validatePassword(password) {
    let isValid = true;

    if(!checkIfStringLengthIsInTheRange6To10Chars(password)) {
        console.log('Password must be between 6 and 10 characters');
        isValid = false;
    }

    if(!checkIfStringConsistsOnlyLettersAndDigits(password)) {
       console.log('Password must consist only of letters and digits');
       isValid = false;
    }

    if(!checkIfStringConsistsAtLeastTwoDigits(password)) {
        console.log('Password must have at least 2 digits');
        isValid = false;
    }

    if(isValid) {
        console.log('Password is valid');
    }
}