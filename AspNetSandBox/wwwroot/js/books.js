"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();

connection.start().then(function () {
    console.log("Connection established.");
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("BookCreated", function (book) {
    console.log(`Book Created: ${JSON.stringify(book)}.`);
    $("#books").append(`<tr data-id="${book.id}" id="book${book.id}">
                            ${generateActionsHTML(book)}
                        </tr>`);
    
});

connection.on("BookUpdated", function (book) {
    console.log(`Book Updated: ${JSON.stringify(book)}.`);
    $(`#book${book.id}`).html(`${generateActionsHTML(book)}`);
});

connection.on("BookDeleted", function (id) {
    console.log(`Book with id ${JSON.stringify(id)} deleted.`);
    $(`#book${id}`).remove();
});

function generateActionsHTML(book) {
    return `<td>${book.title}</td>
                            <td>${book.author}</td>
                            <td>${book.language}</td>
                            <td class="text-center">
                                <a type="button" data-toggle="modal" data-target="#updateBookModal" class="btn btn-outline-dark mx-2" onclick="updateBook(this)">
                                    <i class="bi bi-pencil-square"></i> Edit</a><button type="button" class="btn btn-outline-dark mx-2" onclick="deleteBook(this)">
                                    <i class="bi bi-trash"></i> Delete</button><button type="button" data-toggle="modal" data-target="#getBookModal" class="btn btn-outline-dark mx-2" onclick="getBook(this)">
                                    <i class="bi bi-search"></i> Details</button>
            </td>`;
}