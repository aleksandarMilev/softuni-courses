class Storage {
    constructor(capacity) {
        this.capacity = capacity;
        this.storage = [];
    }

    get totalCost() {
        let totalPrice = 0;
        for (const product of this.storage) {
            totalPrice += this.getProductPrice(product);
        }
    
        return Number(totalPrice.toFixed(1));
    }

    getProductPrice(product) {
        return product.price * product.quantity;
    }

    addProduct(product) {
        this.storage.push(product);
        this.capacity -= product.quantity;
    }

    getProducts() {
        return this.storage.map(product => JSON.stringify(product)).join('\n');
    }
}