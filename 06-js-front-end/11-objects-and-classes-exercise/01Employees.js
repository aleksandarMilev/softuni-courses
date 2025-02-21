function printEmployeesInfo(employeeNames) {
    employeeNames.forEach(name => {
        const employee = {
            name,
            personalNumber: name.length,
        };

        console.log(`Name: ${employee.name} -- Personal Number: ${employee.personalNumber}`);
    });
}