function printHeroInfo(input) {
    const heroes = [];

    for (const line of input) {
        const [name, level, ...items] = line.split(' / ');
        heroes.push({name, level, items});
    }

    for (const hero of heroes.sort((a, b) => a.level - b.level)) {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items.join(', ')}`)
    }
}