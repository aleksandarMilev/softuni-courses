function solve() {
   let addProductButtonElements = document.getElementsByClassName('add-product');
   let textAreaElement = document.getElementsByTagName('textarea')[0];
   let checkOutButtonElement = document.getElementsByClassName('checkout')[0];

   let totalPrice = 0;
   let foodsBought = new Set();

   for (const button of Array.from(addProductButtonElements)) {
      button.addEventListener('click', addProduct);
   }

   checkOutButtonElement.addEventListener('click', checkout);

   function addProduct() {
      let product = this.parentNode.parentNode;

      let price = product.querySelector('.product-line-price').textContent;
      totalPrice += Number(price);

      let name = product.querySelector('.product-title').textContent;
      foodsBought.add(name);

      textAreaElement.value += `Added ${name} for ${price} to the cart.\n`;
   }

   function checkout() {
      textAreaElement.value += `You bought ${Array.from(foodsBought).join(', ')} for ${totalPrice.toFixed(2)}.`;
      
      for (const button of Array.from(addProductButtonElements)) {
         button.disabled = true;
      }

      this.disabled = true;
   }
}