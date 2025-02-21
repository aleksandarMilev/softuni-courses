function getFigures(){
    class Figure {
        constructor(units = 'cm') {
            this.units = units;
        }
    
        get area() {
            return 0;
        }
    
        changeUnits(value) {
            this.units = value;
        }
    
        convertUnits(value) {
            switch (this.units) {
                case 'm':
                    return value / 100;
                case 'mm':
                    return value * 10;
                case 'cm':
                default:
                    return value;
            }
        }
    
        toString() {
            return `Figures units: ${this.units}`;
        }
    }
    
    class Circle extends Figure {
        constructor(radius, units = 'cm') {
            super(units);
            this._radius = radius;
        }
    
        get radius() {
            return this.convertUnits(this._radius);
        }
    
        get area() {
            return Math.PI * this.radius * this.radius;
        }
    
        toString() {
            return `Figures units: ${this.units} Area: ${this.area} - radius: ${this.radius}`;
        }
    }
    
    class Rectangle extends Figure {
        constructor(width, height, units = 'cm') {
            super(units);
            this._width = width; 
            this._height = height; 
        }
    
        get width() {
            return this.convertUnits(this._width);
        }
    
        get height() {
            return this.convertUnits(this._height);
        }
    
        get area() {
            return this.width * this.height;
        }
    
        toString() {
            return `Figures units: ${this.units} Area: ${this.area} - width: ${this.width}, height: ${this.height}`;
        }
    }
    
    return {
        Figure,
        Circle,
        Rectangle
    };
}

