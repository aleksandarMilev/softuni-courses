function deleteByEmail() {
    let tableRowsElements = document.querySelectorAll('tbody tr');
    let emailToBeDeleted = document.querySelector('input[type ="text"]').value.trim();
    let resultElement = document.getElementById('result');

    for (const row of tableRowsElements) {
        let email = row.cells[1];
        
        if(email.textContent.trim() === emailToBeDeleted) {
            row.remove();
            resultElement.textContent = 'Deleted.';
            return;
        }        
    }

    resultElement.textContent = 'Not found.';
}