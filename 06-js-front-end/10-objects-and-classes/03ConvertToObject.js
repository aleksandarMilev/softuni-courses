function convertToObject(json) {
    const object = JSON.parse(json);

    Object
        .keys(object)
        .forEach(key => console.log(`${key}: ${object[key]}`));
}
