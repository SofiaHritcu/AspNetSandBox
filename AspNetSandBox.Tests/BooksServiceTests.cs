using System;
using Xunit;

namespace AspNetSandBox.Tests
{
    public class BooksServiceTests
    {
        [Fact]
        public void ShouldGetBookValidId()
        {
            //Assume
            IBooksService booksService = new BooksService();

            //Act
            booksService.Add(new Book
            {
                Title = "Test Book Valid Id",
                Author = "Test Author Valid Id",
                Language = "Test Language Valid Id"
            });

            //Assert
            Assert.Equal("Test Book Valid Id", booksService.Get(3).Title);
        }

        [Fact]
        public void ShouldNotGetBookInvalidId()
        {
            //Assume
            IBooksService booksService = new BooksService();

            try
            {
                //Act
                booksService.Get(0);
            }
            catch (Exception e)
            {
                //Assert
                Assert.Equal("Invalid id !", e.Message);
            }
        }

        [Fact]
        public void ShouldAddValidBook()
        {
            //Assume
            IBooksService booksService = new BooksService();

            //Act
            booksService.Add(new Book
            {
                Title = "Test Book Valid",
                Author = "Test Author Valid",
                Language = "Test Language Valid"
            });

            //Assert
            Assert.True(booksService.Get(3).Title == "Test Book Valid" && 
                            booksService.Get(3).Author == "Test Author Valid" && 
                                booksService.Get(3).Language == "Test Language Valid");
        }

        [Fact]
        public void ShouldNotAddInvalidBook()
        {
            //Assume
            IBooksService booksService = new BooksService();

            try
            {
                //Act
                booksService.Add(new Book());
            } catch (Exception e )
            {
                //Assert
                Assert.Equal("Book fields should not be null !", e.Message);
            }
        }

        [Fact]
        public void ShouldNotAddNullBook()
        {
            //Assume
            IBooksService booksService = new BooksService();

            try
            {
                //Act
                booksService.Add(null);
            }
            catch (Exception e)
            {
                //Assert
                Assert.Equal("Book cannot be null !", e.Message);
            }
        }

        [Fact]
        public void ShouldAddBooksWithUniqueIds()
        {
            //Assume
            IBooksService booksService = new BooksService();

            //Act
            booksService.Add( new Book
            {
                Title = "Test Book 1",
                Author = "Test Author 1",
                Language = "english"
            });

            booksService.Delete(2);

            booksService.Add(new Book
            {
                Title = "Test Book 2",
                Author = "Test Author 2",
                Language = "english"
            });

            //Assert
            Assert.Equal("Test Book 1", booksService.Get(3).Title);
        }
    }
}
