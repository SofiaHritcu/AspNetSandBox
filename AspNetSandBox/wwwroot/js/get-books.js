
// render one book instance to the book table
function addBookInstanceToTable(book) {
    const table = document.getElementById('books');
    const bookTableRow = document.createElement('tr');
    bookTableRow.setAttribute('data-id', book.id);

    // title column
    const titleColumn = document.createElement('td');
    titleColumn.innerHTML = book.title;
    bookTableRow.appendChild(titleColumn);

    // author column
    const authorColumn = document.createElement('td');
    authorColumn.innerHTML = book.author;
    bookTableRow.appendChild(authorColumn);

    // language column
    const languageColumn = document.createElement('td');
    languageColumn.innerHTML = book.language;
    bookTableRow.appendChild(languageColumn);

    table.appendChild(bookTableRow);
    createActionsColumn(book, bookTableRow);
}

// create a cell containing actions for a book : update, see details, delete
function createActionsColumn(book, tableRow) {
    const actionsColumn = document.createElement('td');
    actionsColumn.setAttribute('class', 'text-center');
    
    const editButton = document.createElement('a');
    editButton.setAttribute('type', 'button');
    editButton.setAttribute('data-toggle', 'modal');
    editButton.setAttribute('data-target', '#updateBookModal');
    editButton.setAttribute('class', 'btn btn-outline-dark mx-2');
    editButton.setAttribute('onclick', 'updateBook(this)');
    editButton.innerHTML = '<i class="bi bi-pencil-square"></i> Edit'
    actionsColumn.appendChild(editButton);

    const deleteButton = document.createElement('button');
    deleteButton.setAttribute('type', 'button');
    deleteButton.setAttribute('class', 'btn btn-outline-dark mx-2');
    deleteButton.setAttribute('onclick', 'deleteBook(this)');
    deleteButton.innerHTML = '<i class="bi bi-trash"></i> Delete'
    actionsColumn.appendChild(deleteButton);

    const detailsButton = document.createElement('button');
    detailsButton.setAttribute('type', 'button');
    detailsButton.setAttribute('data-toggle', 'modal');
    detailsButton.setAttribute('data-target', '#getBookModal');
    detailsButton.setAttribute('class', 'btn btn-outline-dark mx-2');
    detailsButton.setAttribute('onclick', 'getBook(this)');
    detailsButton.innerHTML = '<i class="bi bi-search"></i> Details'
    actionsColumn.appendChild(detailsButton);

    tableRow.appendChild(actionsColumn);
}

// load result of fetching into table
function loadTable(data) {
    if (data == []) {
        document.getElementById('books').innerHTML = "No books.";
        return;
    }
    document.getElementById('books').innerHTML = ''
    data.forEach(book => {
        addBookInstanceToTable(book);
    })
}

async function fetchBooks() {
    console.log('fetching...')
    fetch("/api/books")
        .then((result) => result.json())
        .then((data) => {
            loadTable(data);
            document.getElementById('loading').setAttribute('style', 'display: none');
        })
}

// feth data from backend
window.addEventListener('load', async function () {
    await fetchBooks();
});
