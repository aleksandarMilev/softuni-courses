function sumTable() {
    const rowsElements = document.querySelectorAll('tr td:last-of-type:not(#sum)');
    const sumElement = document.getElementById('sum');

    sumElement.textContent = 
        Array.from(rowsElements)
        .reduce((acc, element) => acc + Number(element.textContent), 0);
}