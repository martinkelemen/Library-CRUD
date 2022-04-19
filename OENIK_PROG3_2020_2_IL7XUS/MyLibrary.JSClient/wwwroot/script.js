let books = [];
let connection = null;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:1967/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("BookCreated", (user, message) => {
        getdata();
    });

    connection.on("BookUpdated", (user, message) => {
        getdata();
    });

    connection.on("BookDeleted", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:1967/book')
        .then(x => x.json())
        .then(y => {
            books = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    books.forEach(t => {
        let bookisbn = t.isbn;
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.isbn + "</td><td>"
            + t.title + "</td><td>"
            + t.authorName + "</td><td>"
            + t.category + "</td><td>"
            + t.language + "</td><td>"
            + t.year + "</td><td>"
            + t.publisher + "</td><td>"
            + t.pageNumber + "</td><td>" +
            '<button type="button" onclick="remove(\'' + t.isbn + '\')">Delete</button>'
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:1967/book/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null })
    .then(response => response)
    .then(data => {
        console.log('Success:', data);
        getdata();
    })
    .catch((error) => { console.error('Error: ', error); });
}

function create() {
    let isbnnumber = document.getElementById('isbn').value;
    let booktitle = document.getElementById('title').value;
    let author = document.getElementById('authorname').value;
    let bookcategory = document.getElementById('category').value;
    let booklanguage = document.getElementById('language').value;
    let publishyear = Number(document.getElementById('year').value);
    let publishername = document.getElementById('publisher').value;
    let pages = Number(document.getElementById('pages').value);

    fetch("http://localhost:1967/book", {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { isbn: isbnnumber, title: booktitle, authorName: author, category: bookcategory, language: booklanguage, year: publishyear, publisher: publishername, pageNumber: pages })})
        .then(response => response)
        .then(data =>
        {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error: ', error); });
}