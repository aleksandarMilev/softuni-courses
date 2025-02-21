function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let tableRows = document.querySelectorAll('tbody tr');
      let searchWord = document.getElementById('searchField').value;

      for (const row of tableRows) {
         row.classList.remove('select');       
      }

      for (const row of tableRows) {
         if(row.textContent.includes(searchWord)) {
            row.classList.add('select');
         }
      }
   }  
}