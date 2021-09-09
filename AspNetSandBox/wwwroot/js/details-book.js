async function getBook(buttonDetails) {
    // get id of book to be deleted
    const bookId = buttonDetails.parentNode.parentNode.getAttribute('data-id');

    // call backend for deleting book
    await getBookCall(bookId);
}

// call to backend api to delete book
async function getBookCall(bookId) {
    fetch(`/api/books/${bookId}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
        }
    })
        .then((result) => result.json())
        .then(data => {
            document.getElementById('titleInputGet').value = data.title;
            document.getElementById('authorInputGet').value = data.author;
            document.getElementById('languageInputGet').value = data.language;
        });
}