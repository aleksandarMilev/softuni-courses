 function solve() {
    document.querySelector('tfoot tr td button').addEventListener('click', renderTheTableAfterChecking);
    document.querySelector('td button:last-of-type').addEventListener('click', clearTheTable)
    
    function renderTheTableAfterChecking() {
        let grid = [[], [], []]; 
        
        document.querySelectorAll('tbody tr').forEach((row, i) => { 
            row.querySelectorAll('td input').forEach((input, j) => { 
                grid[i][j] = parseInt(input.value);
            });
        });

        if (isValidSudoku(grid)) {
            document.getElementById('check').querySelector('p').textContent = 'You solve it! Congratulations!';
            document.getElementsByTagName('table')[0].style.border = '2px solid green';
        } else {
            document.getElementById('check').querySelector('p').textContent = 'NOP! You are not done yet...';
            document.getElementsByTagName('table')[0].style.border = '2px solid red';
        }
    }

    function isValidSudoku(grid) {
        for (let i = 0; i < 3; i++) { 
            let rowSet = new Set(); 
            let colSet = new Set(); 
            
            for (let j = 0; j < 3; j++) {
                if (rowSet.has(grid[i][j]) || colSet.has(grid[j][i])) { 
                    return false;
                } 
                    
                rowSet.add(grid[i][j]); 
                colSet.add(grid[j][i]); 
            }
        }
        return true; 
    }

    function clearTheTable() { 
        Array.from(document.querySelectorAll('td input')).map(x => x.value = ''); 
        document.getElementsByTagName('table')[0].style.border = 'none'; 
        document.getElementById('check').querySelector('p').textContent = '';
    }
}