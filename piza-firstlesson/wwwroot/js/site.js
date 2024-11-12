let basicUrl = 'https://localhost:7297';
let myToken = "";
// let headerAuthorize = new Headers();
// headerAuthorize.append("Authorization", myToken);
// headerAuthorize.append("Content-Type", "application/json");
let myRaw = "";
var headerAuthorize = new Headers();
headerAuthorize.append("Authorization", myToken);
headerAuthorize.append("Content-Type", "application/json");

var raw = JSON.stringify({
    "name": "tzr",
    "password": "123a"
});

function login() {
    let name = document.getElementById("logname").value;
    let password = document.getElementById("logpassword").value;

    raw = JSON.stringify({
        "name": name,
        "password": password,
    });
    myRaw = raw;
    var requestOptions = {
        method: 'POST',
        headers: headerAuthorize,
        body: raw,
        redirect: 'follow'
    };
    var urli = `${basicUrl}/api/Login/Login/Login`;
    fetch(urli, requestOptions)
        .then(response => response.text())
        .then(ref => loginlogin(ref))
        .then(result => console.log(result))
        .catch(error => alert('error: please login...', error.message));
}


function loginlogin(tokenforyou) {
    myToken = `Bearer ${tokenforyou}`;
    headerAuthorize.append("Authorization", myToken);
    headerAuthorize.append("Content-Type", "application/json");
    alert("you are connected!!!");
    return `Bearer ${tokenforyou}`;
}

//pizzas::::::
function getAllPizzas() {
    var urli = `${basicUrl}/api/pizza/get`;
    fetch(urli).then(response => response.json())
        .then(json => fillPizzaList(json))
        .catch(error => alert('error: '+error.message));
}
function fillPizzaList(pizzaList) {
    var tbody = document.getElementById('pizzatbody');
    tbody.innerHTML = `<b><tr><th>Id</th><th>Name</th><th>Price</th><th>Gluten Free</th></tr></b>`;
    pizzaList.forEach(pizza => {
        var tr = `<tr>
        <td>${pizza.id}</td>
        <td>${pizza.name}</td>
        <td>${pizza.price}</td>
        <td>${pizza.gluten}</td>
        </tr>`
        tbody.innerHTML += tr;
    });
}
function getById() {
    let iddom = document.getElementById("Byid");
    let id = iddom.value;
    var urli = `${basicUrl}/api/pizza/GetById/${id}`;
    fetch(urli).then(response => response.json())
        .then(json => getPizzaById(json))
        .catch(error => alert('error: '+error.message));
}

function getPizzaById(data) {
    let tbody = document.getElementById('pizzatbody');
    var tr = `<tr>
    <td>${data.id}</td>
    <td>${data.name}</td>
    <td>${data.price}</td>
    <td>${data.gluten}</td>
    </tr>`
    tbody.innerHTML += tr;
}
function create() {
    var myHeaders = new Headers();
    myHeaders.append("Authorization", myToken);
    myHeaders.append("Content-Type", "application/json");
    var raw = myRaw;

    let name = document.getElementById("createName").value;
    let price = parseInt(document.getElementById("createPrice").value);
    let gluten = document.getElementById("createGluten").willValidate;
    var urli = `${basicUrl}/api/pizza/Create/${name}/${gluten}/${price}`;

    var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: raw,
        redirect: 'follow'
    };
    fetch(urli, requestOptions)
        .then(response => response.json()).then(getAllPizzas())
        .catch(error => alert('error: ', error.message));
}

function change() {
    var myHeaders = new Headers();
    myHeaders.append("Authorization", myToken);
    myHeaders.append("Content-Type", "application/json");
    var raw = myRaw;

    let name = document.getElementById("new_name").value;
    let price = parseInt(document.getElementById("price").value);
    let id = document.getElementById("idname").value;
    let gluten = document.getElementById("gluten").willValidate;
    var urli = `${basicUrl}/api/pizza/upDate/${id}/${name}/${gluten}/${price}`;

    var requestOptions = {
        method: 'PUT',
        headers: myHeaders,
        body: raw,
        redirect: 'follow'
    };
    fetch(urli, requestOptions)
        .then(response => response.json())
        .then(result => console.log(result))
        .then(getAllPizzas())
        .catch(error => alert('error: ', error.message));
}

//workers::::::
function getAllWorkers() {
    var myHeaders = new Headers();
    myHeaders.append("Authorization", myToken);
    myHeaders.append("Content-Type", "application/json");
    var raw = myRaw;

    var requestOptions = {
        method: 'GET',
        headers: myHeaders,
        redirect: 'follow'
    };
    var urli = `${basicUrl}/api/worker/get`;
    fetch(urli, requestOptions)
        .then(response => response.json())
        .then(json => fillWorkerList(json))
        .catch(error => alert('error: ' + error.message));
}
function fillWorkerList(workerList) {
    var tbody = document.getElementById('workertbody');
    tbody.innerHTML = `<b><tr><th>Id</th><th>Name</th><th>Role</th></tr></b>`;
    workerList.forEach(w => {
        var tr = `<tr>
        <td>${w.id}</td>
        <td>${w.name}</td>
        <td>${w.role}</td>
        </tr>`
        tbody.innerHTML += tr;
    });
}

function getWorkerById() {
    var myHeaders = new Headers();
    myHeaders.append("Authorization", myToken);
    myHeaders.append("Content-Type", "application/json");
    var raw = myRaw;

    let id = document.getElementById("wByid").value;
    var urli = `${basicUrl}/api/worker/GetById/${id}`;
    var requestOptions = {
        method: 'GET',
        headers: myHeaders,
        redirect: 'follow'
    };
    fetch(urli, requestOptions).then(response => response.json())
        .then(json => getwById(json))
        .catch(error => alert('error: ' + error.message));
}

function getwById(data) {
    let tbody = document.getElementById('workertbody');
    var tr = `<tr>
    <td>${data.id}</td>
    <td>${data.name}</td>
    <td>${data.role}</td>
    </tr>`
    tbody.innerHTML += tr;
}

function createWorker() {
    var myHeaders = new Headers();
    myHeaders.append("Authorization", myToken);
    myHeaders.append("Content-Type", "application/json");
    var raw = myRaw;

    let name = document.getElementById("createWorkerName").value;
    let password = document.getElementById("createWorkerpass").value;
    let role = document.getElementById("createWorkerRole").value;
    var urli = `${basicUrl}/api/worker/Create/${name}/${password}/${role}`;

    var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: raw,
        redirect: 'follow'
    };
    fetch(urli, requestOptions)
        .catch(error => alert('error: ', error.message));
}

function changeWorker() {
    var myHeaders = new Headers();
    myHeaders.append("Authorization", myToken);
    myHeaders.append("Content-Type", "application/json");
    var raw = myRaw;

    let name = document.getElementById("newWorkerName").value;
    let id = parseInt(document.getElementById("idWorker").value);
    let password = document.getElementById("newWorkerPassword").value;
    let role = document.getElementById("newWorkerRole").value;

    var urli = `${basicUrl}/api/worker/upDate/${id}/${name}/${password}/${role}`;

    var requestOptions = {
        method: 'PUT',
        headers: myHeaders,
        body: raw,
        redirect: 'follow'
    };
    fetch(urli, requestOptions)
        .then(response => response.json())
        .catch(error => alert('error: ', error.message));
}


//order.....................
var pizzaorder="";
function getpid(id){
    var urli = `${basicUrl}/api/pizza/GetById/${id}`;
    fetch(urli).then(response => response.json())
        .then(json => pizzaorder=json)
        .catch(error => alert('error: '+error.message));
}

let items=[{
    itemId:1,
    quantity:0,
    price:0
},];
let count=0;
// JSON.stringify({
    // itemId:1,
    // quantity:0,
    // price:0
//},)
function additem(){
    let iditem = document.getElementById("iditem").value;
    let qty = document.getElementById("qitem").value;
    let pr;
    getpid(iditem);
    pr = pizzaorder.price * qty;
    
    items[count]={
        itemId:iditem,
        quantity:qty,
        price:pr
    };
    count++;
    // items+=JSON.stringify({
    //     itemId:iditem,
    //     quantity:qty,
    //     price:pr
    // });
    
}

function order(){
    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");
    let id = document.getElementById("cusid").value;
    let ccnum = document.getElementById("ccnum").value;
    let expires = document.getElementById("expires").value;
    let cvv = document.getElementById("cvv").value;
    let amount=0;
    // items.forEach(i => {
    //     amount+= i.price;
    // });
    for(let i=1; i<count; i++){
        // if(items[i].price==NaN){
        // }
        // else{
            amount+= items[i].price;
        // }
    }
    var raw = JSON.stringify({
        "customerId": id,
        "date": "29/01/2024 22:01:29",//Date.now(),
        "totalAmount": amount,
        "items": items,
        "pay": {
          "num": ccnum,
          "expires": expires,
          "cvv": cvv
        }
    });
      
    var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: raw,
        redirect: 'follow'
    };
    fetch("https://localhost:7297/api/Order/SendOrder", requestOptions)
        .then(response => response.text())
        .then(result => console.log(result))
        .catch(error => console.log('error', error));
}

// var raw = JSON.stringify({
//     "customerId": "1",
//     "date": "2024-01-29T17:01:29.527Z",
//     "totalAmount": 0,
//     "items": [
//       {
//         "itemId": 1,
//         "quantity": 0,
//         "price": 0
//       }
//     ],
//     "pay": {
//       "num": "string",
//       "expires": "string",
//       "cvv": "string"
//     }
//   });
  
//   var requestOptions = {
//     method: 'POST',
//     headers: myHeaders,
//     body: raw,
//     redirect: 'follow'
//   };
  
  