function formatGrade(grade) {
    if(grade < 3) {
        return `Fail (${grade})`;
    }

    if (grade >= 3 && grade < 3.5) {
        return `Poor (${grade.toFixed(2)})`;
    }

    if (grade >= 3.5 && grade < 4.5) {
        return `Good (${grade.toFixed(2)})`;
    }

    if (grade >= 4.5 && grade < 5.5) {
        return `Very good (${grade.toFixed(2)})`;
    }

    return `Excellent (${grade.toFixed(2)})`;
}