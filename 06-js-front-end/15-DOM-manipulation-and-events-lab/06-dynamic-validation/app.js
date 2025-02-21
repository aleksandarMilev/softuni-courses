function validate() {
    let emailInputElement = document.getElementById('email');

    emailInputElement.addEventListener('change', colorizeInputField);
    
    function colorizeInputField(event) {
        let regex = /^[a-z]+@[a-z]+\.[a-z]+$/;

        if(!regex.test(event.target.value)) {
            event.target.classList.add('error');
        } else {
            event.target.classList.remove('error');
        }
    }
}