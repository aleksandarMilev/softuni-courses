function addressBook(addressBookInput) {
    const addressBook = {};

    for(const addressAndName of addressBookInput) {
        const [name, address] = addressAndName.split(':');
        addressBook[name] = address;
    }

    const addressBookSorted = Object
        .entries(addressBook)
        .sort((a, b) => a[0].localeCompare(b[0]));

    addressBookSorted.forEach(([name, address]) => console.log(`${name} -> ${address}`))
}