function solve(names) {
    names.sort((a, b) => a.toLowerCase().localeCompare(b.toLowerCase()));
    let counter = 0;

    for (const name of names) {
        console.log(`${++counter}.${name}`)
    }
}