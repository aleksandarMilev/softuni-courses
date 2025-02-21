function addItem() {
    let listElement = document.getElementById('items');
    let newElementInputField = document.getElementById('newItemText');

    let addedElement = document.createElement('li');
    addedElement.textContent = newElementInputField.value;

    let deleteElement = document.createElement('a');
    deleteElement.textContent = '[Delete]';
    deleteElement.href = '#'

    addedElement.appendChild(deleteElement);
    listElement.appendChild(addedElement);

    
    deleteElement.addEventListener('click', deleteItem);
    
    newElementInputField.value = '';
    
    function deleteItem(event) {
        event.currentTarget.parentNode.remove();
    }
}