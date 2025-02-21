function solve() {
    let inputElement = document.querySelector('#exercise textarea');
    let generateProductsButtonElement = document.querySelector('#exercise button');
    let tablebodyElement = document.querySelector('tbody');
    let buyButtonElement = document.querySelector('#exercise button:last-child');
    let outputAreaElement = document.querySelector('textarea:last-of-type');

    let productsBought = new Set();

    let message = '';
    let totalPrice = 0;
    let totaldecFactor = 0;

    generateProductsButtonElement.addEventListener('click', addProducts);
    buyButtonElement.addEventListener('click', renderProducts);

    function addProducts() {
        let jsonString = inputElement
        .value
        .split('')
        .filter(x => x !== '\n')
        .join('');

        let products = Object.entries(JSON.parse(jsonString));

        for (const product of products) {
            let{img, name, price, decFactor} = product[1];

            let rowElement = document.createElement('tr'); 
            tablebodyElement.appendChild(rowElement);

            addImageTableData(rowElement, img);
            addNameTableData(rowElement, name); 
            addPriceTableData(rowElement, price); 
            addDecFactorTableData(rowElement, decFactor); 
            addCheckboxTableData(rowElement); 
        }

        function addImageTableData(rowElement, img) {
            let imgTableDataElement = document.createElement('td'); 
            rowElement.appendChild(imgTableDataElement);
            let imgElement = document.createElement('img');
            imgElement.src = img;
            imgTableDataElement.appendChild(imgElement);
        }

        function addNameTableData(rowElement, name) {
            let nameTableDataElement = document.createElement('td'); 
            rowElement.appendChild(nameTableDataElement);
            let productNameParagraph = document.createElement('p');
            productNameParagraph.textContent = name;
            nameTableDataElement.appendChild(productNameParagraph);
        }

        function addPriceTableData(rowElement, price) {
            let priceTableDataElement = document.createElement('td'); 
            rowElement.appendChild(priceTableDataElement);
            let priceParagraph = document.createElement('p');
            priceParagraph.textContent = price;
            priceTableDataElement.appendChild(priceParagraph);
        }

        function addDecFactorTableData(rowElement, decFactor) {
            let decFactorTableDataElement = document.createElement('td'); 
            rowElement.appendChild(decFactorTableDataElement);
            let decFactorParagraph = document.createElement('p');
            decFactorParagraph.textContent = decFactor;
            decFactorTableDataElement.appendChild(decFactorParagraph);
        }

        function addCheckboxTableData(rowElement) {
            let checkboxTableDataElement = document.createElement('td'); 
            rowElement.appendChild(checkboxTableDataElement);
            let inputCheckboxElement = document.createElement('input');
            inputCheckboxElement.type = 'checkbox';
            checkboxTableDataElement.appendChild(inputCheckboxElement);
        }
    }

    function renderProducts() {
        let prodcutRows = document.querySelectorAll('tr:not(:first-child)');

        for (const product of Array.from(prodcutRows)) {
            let checkbox = product.querySelector('td:last-child').children[0];

            if(checkbox.checked) {
                let name = product.querySelector('td:nth-child(2)').children[0].textContent;
                productsBought.add(name);

                let price = product.querySelector('td:nth-child(3)').children[0].textContent;
                totalPrice += Number(price);

                let decFactor = product.querySelector('td:nth-child(4)').children[0].textContent;
                totaldecFactor += Number(decFactor);
            }
        }

        message += `Bought furniture: ${Array.from(productsBought).join(', ')}\n`;
        message += `Total price: ${totalPrice.toFixed(2)}\n`;
        message += `Average decoration factor: ${(totaldecFactor / productsBought.size).toFixed(1)}`;

        outputAreaElement.value = message;
    }
}