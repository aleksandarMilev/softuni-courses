function addItem() {
    let unorderedListElement = document.getElementById('items');
    let newItemElement = document.getElementById('newItemText');
    let newItemValue = newItemElement.value;

    let newElement = document.createElement('li');
    newElement.textContent = newItemValue;
    unorderedListElement.appendChild(newElement);

    newItemElement.value = '';
}