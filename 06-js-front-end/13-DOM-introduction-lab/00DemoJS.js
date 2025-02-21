/*
Browser Object Model (BOM):
Browsers expose some objects like window, screen, navigator, history, location, document ж 
*/
console.dir(window); //The global object when JS is run in browser (in nodeJS is 'global');
console.dir(navigator);
console.dir(screen);
console.dir(location);
console.dir(history);
console.dir(document);

console.log(this) //always pointing to the global object when is in the global scope (again, when JS is running in browser)

/*
Document Object Model (DOM)
JS objects in the memory, represented as tree-like structure
We can add JS in HTML internal or as external file:
<script src="00DemoJS.js"></script> -> external
<script>console.log('Hello, World!')</script> -> internal
*/

//DOM Methods:
//Get element/s:
//by ID:
let element = document.getElementById('id');

//by class name (one or more, returns HTML collection):
let htmlCollection = document.getElementsByClassName('className');

//by tag (one or more, returns HTML collection):
htmlCollection = document.getElementsByClassName('tagName');

//by css selector
//pass a css selector as string as argument
element = document.querySelector('selector'); //returns single element (if threre are more mathches, returns only the first)
let nodeList = document.querySelectorAll('selector') //returns Node List

//remove element by index(as argument in .item())
htmlCollection.item(0).remove();

//iterate
htmlCollection.forEach(element => console.log(element));

//convert to array
let nodeListAsArray = Array.from(nodeList);

//Take element text contnent (<p>I am some text</p => I am some text)
let text = element.textContent;

//Take element value(for forms):
let inputValue = element.value;

/*
-getElementsByClassName returns a live HTMLCollection, meaning if the DOM changes, the collection updates automatically. On the other hand, querySelectorAll returns a static NodeList, which won't automatically update if the DOM changes.

-NodeList objects returned by querySelectorAll can be iterated with forEach() directly, but HTMLCollection cannot without converting to an array first.

-querySelector can be used not only to select elements by CSS selectors but also by IDs and classes (document.querySelector('.className') or document.querySelector('#id'))

-with methods like getAttribute(), setAttribute(), and removeAttribute() we can add, remove, and modify element attributes

-with methods like classList.add(), classList.remove(), classList.toggle(), and classList.contains() we can work with classes
*/