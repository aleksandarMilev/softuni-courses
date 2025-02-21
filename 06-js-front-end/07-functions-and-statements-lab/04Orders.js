function getTotalPrice(product, quantity) {
    switch (product) {
        case 'coffee':
            return (1.5 * quantity).toFixed(2);
        case 'water':
            return quantity.toFixed(2);
        case 'coke':
            return (1.4 * quantity).toFixed(2);
        case 'snacks':
            return (2 * quantity).toFixed(2);
    }
}