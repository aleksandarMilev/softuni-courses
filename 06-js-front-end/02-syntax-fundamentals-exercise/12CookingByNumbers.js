function solve(numberAsString, command1, command2, command3, command4, command5) {
    let number = parseInt(numberAsString);
    let commands = [command1, command2, command3, command4, command5]

    for (let command of commands) {
        switch (command) {
            case 'chop':
                number /= 2;
                console.log(number);
                break;
            case 'dice':
                number = Math.sqrt(number);
                console.log(number);
                break;
            case 'spice':
                number += 1;
                console.log(number);
                break;
            case 'bake':
                number *= 3;
                console.log(number);
                break;
            case 'fillet':
                number *= 0.8;
                console.log(number);
                break;
        }
    }
}