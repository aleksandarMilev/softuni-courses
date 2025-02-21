function search() {
   let search = document.getElementById('searchText').value;
   let citiesList = document.getElementsByTagName('li');
   let matches = 0;

   for (const city of citiesList) {
      city.style.fontWeight = '';
      city.style.textDecoration = '';
   }

   for (const city of citiesList) {
      
      if(city.textContent.includes(search)) {
         city.style.fontWeight = 'bold';
         city.style.textDecoration = 'underline';

         matches++;
      }
   }

   document.getElementById('result').textContent = `${matches} matches found`;
}
