class Hex {
    constructor(value) {
        this.value = value;
    }

    valueOf() {
        return this.value;
    }

    toString() {
        return `0x${this.value.toString(16).toUpperCase()}`;
    }

    plus(number) {
        let valueToAdd = number instanceof Hex ? number.valueOf() : number;
        return new Hex(this.value + valueToAdd);
    }

    minus(number) {
        let valueToSubtract = number instanceof Hex ? number.valueOf() : number;
        return new Hex(this.value - valueToSubtract);
    }

    static parse(hexString) {
        return parseInt(hexString, 16);
    }
}