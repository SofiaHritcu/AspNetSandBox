async function deleteBook(buttonDelete) {
    // get id of book to be deleted
    const bookId = buttonDelete.parentNode.parentNode.getAttribute('data-id');
    console.log(bookId)

    // call backend for deleting book
    await deleteBookCall(bookId);
}

// call to backend api to delete book
async function deleteBookCall(bookId) {
    fetch(`/api/books/${bookId}`,{
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        }
    })
    .then(async function () {
        await fetchBooks();
        alert('You have deleted the book!', 'success');
    });
}