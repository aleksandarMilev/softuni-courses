function colorize() {
    document
        .querySelectorAll('table tr:nth-child(2n)')
        .forEach(row => row.style.backgroundColor = 'Teal');
}   