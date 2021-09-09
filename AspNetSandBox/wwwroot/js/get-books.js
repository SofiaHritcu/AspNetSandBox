
// render one book instance to the book table
function addBookInstanceToTable(book) {
    const table = document.getElementById('books');
    const bookTableRow = document.createElement('tr');

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
    
    const editAnchore = document.createElement('a');
    editAnchore.setAttribute('class', 'mx-2');
    editAnchore.innerHTML = '<i class="bi bi-pencil-square"></i> Edit'
    actionsColumn.appendChild(editAnchore);

    const deleteAnchore = document.createElement('a');
    deleteAnchore.setAttribute('class', 'mx-2');
    deleteAnchore.innerHTML = '<i class="bi bi-trash"></i> Delete'
    actionsColumn.appendChild(deleteAnchore);

    const detailsAnchore = document.createElement('a');
    detailsAnchore.setAttribute('class', 'mx-2');
    detailsAnchore.innerHTML = '<i class="bi bi-search"></i> Details'
    actionsColumn.appendChild(detailsAnchore);

    tableRow.appendChild(actionsColumn);
}

// load result of fetching into table
function loadTable(data) {
    if (data == []) {
        document.getElementById('books').innerHTML = "No books.";
        return;
    }
    console.log(data)
    data.forEach(book => {
        addBookInstanceToTable(book);
    })
}


// feth data from backend
window.addEventListener('load', function () {
    fetch("https://localhost:5001/api/books")
        .then((result) => result.json())
        .then((data) => {
            loadTable(data);
            document.getElementById('loading').setAttribute('style', 'display: none');
        })
});