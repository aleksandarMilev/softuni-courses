function calc() {
    const firstNumber = Number(document.getElementById('num1').value);
    const secondNumber = Number(document.getElementById('num2').value);

    const sumElement = document.getElementById('sum');
    sumElement.value = firstNumber + secondNumber;
}
