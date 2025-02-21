function attachGradientEvents() {
    let gradientElement = document.getElementById('gradient');
    let resultElement = document.getElementById('result');
    
    gradientElement.addEventListener('mousemove', printMousePointPercentage);
    gradientElement.addEventListener('mouseout', removeMousePointPercenatge);
    
    function printMousePointPercentage(event) {
        let power = event.offsetX / (event.target.clientWidth - 1);
        power = Math.trunc(power * 100);

        resultElement.textContent = power + '%';
    }

    function removeMousePointPercenatge() {
        resultElement.textContent = '';
    }
}
 