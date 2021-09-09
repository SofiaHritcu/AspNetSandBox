// adding book form submission
window.addEventListener('load', async function () {
    const addBookForm = document.getElementById('addBookForm');
    addBookForm.addEventListener('submit', async function (event) {
        event.preventDefault();

        const title = document.getElementById('titleInput').value;
        const author = document.getElementById('authorInput').value;
        const language = document.getElementById('languageInput').value;

        await postBookCall(title, author, language);
        alert('You have added the book!', 'success');
    });
})

function alert(message, type) {
    var wrapper = document.createElement('div')
    wrapper.innerHTML = '<div class="alert alert-' + type + ' alert-dismissible fade show" role="alert">' + message + '<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">CLOSE</span></button></div>';

    document.getElementById('headerRow').append(wrapper);
}

async function postBookCall(title, author, language) {
    fetch("/api/books", {
        method: "POST",
        body: JSON.stringify({
            title: title,
            author: author,
            language: language
        }),
        headers: {
            "Content-type": "application/json; charset=UTF-8"
        }
    })
    .then(async function () {
        await fetchBooks();
        document.getElementById('closeModal').click();
    });
}