function addItem() {
    let newItemTextElement = document.getElementById('newItemText');
    let newItemValueElement = document.getElementById('newItemValue');

    let optionElement = document.createElement('option');
    optionElement.textContent = newItemTextElement.value;
    optionElement.value = newItemValueElement.value;
    
    let selectElement = document.getElementById('menu');
    selectElement.appendChild(optionElement);

    newItemTextElement.value = '';
    newItemValueElement.value = '';
} 