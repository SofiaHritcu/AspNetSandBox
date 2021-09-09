var bookId = 0;

async function updateBook(buttonUpdate) {
    // get id of book to be deleted
    bookId = buttonUpdate.parentNode.parentNode.getAttribute('data-id');

    // call backend for deleting book
    await getBookToUpdateCall();
}

// updating book form submission
window.addEventListener('load', async function () {
    const updateBookForm = document.getElementById('updateBookForm');
    updateBookForm.addEventListener('submit', async function (event) {
        event.preventDefault();

        const title = document.getElementById('titleInputUpdate').value;
        const author = document.getElementById('authorInputUpdate').value;
        const language = document.getElementById('languageInputUpdate').value;

        await putBookCall(title, author, language);
        alert('You have updated the book!', 'success');
    });
})

// call to backend api to delete book
async function getBookToUpdateCall() {
    fetch(`/api/books/${bookId}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
        }
    })
        .then((result) => result.json())
        .then(data => {
            document.getElementById('titleInputUpdate').value = data.title;
            document.getElementById('authorInputUpdate').value = data.author;
            document.getElementById('languageInputUpdate').value = data.language;
        });
}

async function putBookCall(title, author, language) {
    console.log(bookId + " " + title + " " + author + " " + language)
    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");

    var raw = JSON.stringify({
        "id": bookId,
        "title": title,
        "author": author,
        "language": language
    });

    var requestOptions = {
        method: 'PUT',
        headers: myHeaders,
        body: raw,
        redirect: 'follow'
    };

    fetch(`/api/books/${bookId}`, requestOptions)
        .then(async function () {
            await fetchBooks();
            document.getElementById('closeModalUpdate').click();
        });

   
}