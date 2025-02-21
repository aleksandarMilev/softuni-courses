class Company {
    constructor() {
        this.departments = {};
    }

    addEmployee(name, salary, position, department) {
        this.validateParams(name, salary, position, department);

        if (salary < 0) {
            throw new Error('Invalid input!');
        }

        if (!this.departments[department]) {
            this.departments[department] = [];
        }
        
        let employee = new {
            name,
            salary,
            position
        };

        this.departments[department].push(employee);

        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment() {
        let bestDept = null;
        let highestAvgSalary = 0;

        for (const dept in this.departments) {
            let employees = this.departments[dept];
            let totalSalary = employees.reduce((acc, emp) => acc + emp.salary, 0);
            let avgSalary = totalSalary / employees.length;

            if (avgSalary > highestAvgSalary) {
                highestAvgSalary = avgSalary;
                bestDept = dept;
            }
        }

        if (!bestDept) {
            return "No employees in the company.";
        }

        let sortedEmployees = this.departments[bestDept]
            .slice()
            .sort((a, b) => b.salary - a.salary || a.name.localeCompare(b.name));

        let avgSalaryFormatted = highestAvgSalary.toFixed(2);
        let result = `Best Department is: ${bestDept}\nAverage salary: ${avgSalaryFormatted}\n`;

        for (const emp of sortedEmployees) {
            result += `${emp.name} ${emp.salary} ${emp.position}\n`;
        }

        return result.trim();
    }

    validateParams(name, salary, position, department) {
        let isInvalid = value => value === null || value === undefined || value === '';

        if (isInvalid(name) || isInvalid(salary) || isInvalid(position) || isInvalid(department)) {
            throw new Error('Invalid input!');
        }
    }
}