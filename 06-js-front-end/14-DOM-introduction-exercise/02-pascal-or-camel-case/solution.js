function solve() {
  let textElement = document.getElementById('text').value;
  let conventionNameElement = document.getElementById('naming-convention').value;

  let result = textElement
    .toLowerCase()
    .split(' ')
    .map(word => word.charAt(0).toUpperCase() + word.slice(1))
    .join('');

    switch(conventionNameElement) {
      case 'Camel Case':
        result = result.charAt(0).toLowerCase() + result.slice(1);
        break;
      case 'Pascal Case':
        break;
      default:
        result = 'Error!';
        break;
    } 

  document.getElementById('result').textContent = result;
}