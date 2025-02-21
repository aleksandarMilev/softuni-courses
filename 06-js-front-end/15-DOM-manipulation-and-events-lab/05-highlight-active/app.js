function focused() {
    let formsInput = document.querySelectorAll('input[type="text"]');

    for (const form of formsInput) {
        form.addEventListener('focus', changeParentColor);
        form.addEventListener('blur', resetParentColor);
    }

    function changeParentColor(event) {
        event.target.parentNode.className = 'focused';
    } 

    function resetParentColor(event) {
        event.target.parentNode.classList.remove('focused');
    } 
}