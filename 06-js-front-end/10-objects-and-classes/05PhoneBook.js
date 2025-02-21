function phoneBook(phoneBookArray) {
    const phoneBook = {};

    for(const nameAndPhone of phoneBookArray) {
        const [name, phone] = nameAndPhone.split(' ');
        phoneBook[name] = phone;
    }

    for (const name in phoneBook) {
        console.log(`${name} -> ${phoneBook[name]}`)
    }
}