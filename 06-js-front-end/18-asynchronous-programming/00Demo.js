//1 Create a promise
//1.1
function isEvenNumber(number) {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            if (number % 2 === 0) {
                resolve('Even number!');
            } else {
                reject('Odd number!'); 
            }
        }, 1000);
    });
}

isEvenNumber(10)
    .then((message) => {
        console.log(message);
    })
    .catch((errorMessage) => {
        console.log(errorMessage);
    });

//1.2
let promise = new Promise(function(resolve, reject) {
    if(Math.random() < 0.5) {
        reject('Buy, Buy...');
        return;
    }

    setTimeout(() => {
        resolve('Hello, World!');
    }, 2000);
});

promise
    .then((result) => console.log(result))
    .catch((error) => console.log(error))
    .finally(() => console.log(promise));


//alwaysRejectingPromise
let alwaysRejectingPromise = Promise.reject('Error!');
alwaysRejectingPromise.catch((error) => console.log(error));

//alwaysResolvingPromise
let alwaysResolvingPromise = Promise.resolve('Success!');
alwaysRejectingPromise.then((message) => console.log(message));

//2. Get a promise as result from some asynchronous operation
    fetch('https://www.example.com')
        .then(response => response.json())
        .then(data => console.log(data))
        .catch(err => console.error(err));

//3. async-await
//wihtout async/await
function fetchData() {
    return fetch('https://www.test.com')
        .then(response => response.json())
        .then(data => console.log(data))
        .catch(err => console.error(err.message));
}

//with async/await 
async function fancyfetchData() {
    try {
        let response = await fetch('https://www.test.com');
        if(!response.ok) {
            throw new Error(`${response.status}`);
        }
        
        let json = await response.json();
        return json;
    } catch (err) {
        console.error(err.message);
    }
}

//every async function returns a promise! So we can not use the result by it like this:
let data = fancyfetchData();

//instead of this, we must to resolve it first:
fancyfetchData()
    .then(data => {
        //...
    })
