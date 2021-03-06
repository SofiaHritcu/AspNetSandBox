using System;
using AspNetSandBox.Models;
using AspNetSandBox.Services;
using Xunit;

namespace AspNetSandBox.Tests
{
    /// <summary>BooksInMemoDryRepositoryTests Class.</summary>
    public class BooksInMemoryRepositoryTests
    {
        /// <summary>Shoulds the get book valid identifier.</summary>
        [Fact]
        public void ShouldGetBookValidId()
        {
            // Assume
            IBooksRepository booksService = new BooksInMemoryRepository();

            // Act
            booksService.Add(new Book
            {
                Title = "War And Peace",
                Author = "Lev Tolstoi",
                Language = "english",
            });

            // Assert
            Assert.Equal("War And Peace", booksService.Get(3).Title);
        }

        /// <summary>Shoulds the not get book invalid identifier.</summary>
        [Fact]
        public void ShouldNotGetBookInvalidId()
        {
            // Assume
            IBooksRepository booksService = new BooksInMemoryRepository();

            try
            {
                // Act
                booksService.Get(0);
            }
            catch (Exception e)
            {
                // Assert
                Assert.Equal("Invalid id !", e.Message);
            }
        }

        /// <summary>Shoulds the add valid book.</summary>
        [Fact]
        public void ShouldAddValidBook()
        {
            // Assume
            IBooksRepository booksService = new BooksInMemoryRepository();

            // Act
            booksService.Add(new Book
            {
                Title = "Murder on the Orient Express",
                Author = "Agatha Christie",
                Language = "english",
            });

            // Assert
            Assert.True(booksService.Get(3).Title == "Murder on the Orient Express" &&
                            booksService.Get(3).Author == "Agatha Christie" &&
                                booksService.Get(3).Language == "english");
        }

        /// <summary>Shoulds the not add invalid book.</summary>
        [Fact]
        public void ShouldNotAddInvalidBook()
        {
            // Assume
            IBooksRepository booksService = new BooksInMemoryRepository();

            try
            {
                // Act
                booksService.Add(new Book());
            }
            catch (Exception e)
            {
                // Assert
                Assert.Equal("Book fields should not be null !", e.Message);
            }
        }

        /// <summary>Shoulds the not add null book.</summary>
        [Fact]
        public void ShouldNotAddNullBook()
        {
            // Assume
            IBooksRepository booksService = new BooksInMemoryRepository();

            try
            {
                // Act
                booksService.Add(null);
            }
            catch (Exception e)
            {
                // Assert
                Assert.Equal("Book cannot be null !", e.Message);
            }
        }

        /// <summary>Shoulds the add books with unique ids.</summary>
        [Fact]
        public void ShouldAddBooksWithUniqueIds()
        {
            // Assume
            IBooksRepository booksService = new BooksInMemoryRepository();

            // Act
            booksService.Add(new Book
            {
                Title = "Murder on the Orient Express",
                Author = "Agatha Christie",
                Language = "english",
            });

            booksService.Delete(2);

            booksService.Add(new Book
            {
                Title = "The Da Vinci Code",
                Author = "Dan Brown",
                Language = "english",
            });

            // Assert
            Assert.Equal("Murder on the Orient Express", booksService.Get(3).Title);
        }

        /// <summary>Shoulds the update valid book.</summary>
        [Fact]
        public void ShouldUpdateValidBook()
        {
            // Assume
            IBooksRepository booksService = new BooksInMemoryRepository();

            // Act
            booksService.Add(new Book
            {
                Title = "Murder on the Orient Express",
                Author = "Agatha Christie",
                Language = "english",
            });

            booksService.Update(3, new Book
            {
                Title = "The Da Vinci Code",
                Author = "Dan Brown",
                Language = "english",
            });

            // Assert
            Assert.True(booksService.Get(3).Title == "The Da Vinci Code" &&
                        booksService.Get(3).Author == "Dan Brown" &&
                        booksService.Get(3).Language == "english");
        }

        /// <summary>Shoulds the not update invalid book.</summary>
        [Fact]
        public void ShouldNotUpdateInvalidBook()
        {
            // Assume
            IBooksRepository booksService = new BooksInMemoryRepository();

            try
            {
                // Act
                booksService.Update(10, new Book
                {
                    Title = "The Da Vinci Code",
                    Author = "Dan Brown",
                    Language = "english",
                });
            }
            catch (Exception e)
            {
                Assert.Equal("Invalid id !", e.Message);
            }
        }

        /// <summary>Shoulds the not update book with invalid value.</summary>
        [Fact]
        public void ShouldNotUpdateBookWithInvalidValue()
        {
            // Assume
            IBooksRepository booksService = new BooksInMemoryRepository();

            try
            {
                // Act
                booksService.Update(10, new Book());
            }
            catch (Exception e)
            {
                Assert.Equal("Book fields should not be null !", e.Message);
            }
        }

        /// <summary>Shoulds the delete valid book.</summary>
        [Fact]
        public void ShouldDeleteValidBook()
        {
            // Assume
            IBooksRepository booksService = new BooksInMemoryRepository();

            // Act
            booksService.Add(new Book
            {
                Title = "The Da Vinci Code",
                Author = "Dan Brown",
                Language = "english",
            });
            booksService.Delete(3);

            // Assert
            try
            {
                booksService.Get(3);
            }
            catch (Exception e)
            {
                Assert.Equal("Sequence contains no matching element", e.Message);
            }
        }

        /// <summary>Shoulds the not delete invalid book.</summary>
        [Fact]
        public void ShouldNotDeleteInvalidBook()
        {
            // Assume
            IBooksRepository booksService = new BooksInMemoryRepository();

            try
            {
                // Act
                booksService.Delete(3);
            }
            catch (Exception e)
            {
                // Assert
                Assert.Equal("Invalid id !", e.Message);
            }
        }
    }
}
