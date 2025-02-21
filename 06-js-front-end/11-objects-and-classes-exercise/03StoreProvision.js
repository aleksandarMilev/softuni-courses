function printProductsQuantity(currentProducts, deliveredProducts) {
    const productsQuantity = {};

    for (let i = 0; i < currentProducts.length; i += 2) {
        productsQuantity[currentProducts[i]] = Number(currentProducts[i + 1]);
    }

    for(let i = 0; i < deliveredProducts.length; i += 2) {
        if(productsQuantity[deliveredProducts[i]]) {
            productsQuantity[deliveredProducts[i]] += Number(deliveredProducts[i + 1]);
        } else {
            productsQuantity[deliveredProducts[i]] = Number(deliveredProducts[i + 1]);
        }
    }

    for(const productName in productsQuantity) {
        console.log(`${productName} -> ${productsQuantity[productName]}`);
    }
}