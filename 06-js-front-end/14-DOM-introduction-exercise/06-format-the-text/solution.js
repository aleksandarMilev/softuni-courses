function solve() {
  let text = document.getElementById('input').value;
  let outputElement = document.getElementById('output');

  let peroidsCount = 0;
  let tempText = '';

  for (let i = 0; i < text.length; i++) {
    tempText += text[i];

    if(text[i] === '.') {
      peroidsCount++;
    }
    
    if(peroidsCount === 3 || i === text.length - 1) {

      let paragraph = document.createElement('p');
      paragraph.textContent = tempText;
      outputElement.appendChild(paragraph);

      peroidsCount = 0;
      tempText = '';
    }
  }
}