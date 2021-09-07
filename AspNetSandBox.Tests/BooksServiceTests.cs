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

        [Fact]
        public void ShouldUpdateValidBook()
        {
            //Assume
            IBooksService booksService = new BooksService();

            //Act
            booksService.Add(new Book
            {
                Title = "Test Book",
                Author = "Test Author",
                Language = "Test Language"
            });

            booksService.Update(3, new Book
            {
                Title = "Test Book Updated",
                Author = "Test Author Updated",
                Language = "Test Language Updated"
            });

            //Assert
            Assert.True(booksService.Get(3).Title == "Test Book Updated" &&
                        booksService.Get(3).Author == "Test Author Updated" &&
                        booksService.Get(3).Language == "Test Language Updated");
        }


        [Fact]
        public void ShouldNotUpdateInvalidBook()
        {
            //Assume
            IBooksService booksService = new BooksService();

            try
            {
                //Act
                booksService.Update(10, new Book
                {
                    Title = "Test Book Updated",
                    Author = "Test Author Updated",
                    Language = "Test Language Updated"
                });
            }catch (Exception e)
            {
                Assert.Equal("Invalid id !", e.Message);
            }
        }

        [Fact]
        public void ShouldNotUpdateBookWithInvalidValue()
        {
            //Assume
            IBooksService booksService = new BooksService();

            try
            {
                //Act
                booksService.Update(10, new Book());
            }
            catch (Exception e)
            {
                Assert.Equal("Book fields should not be null !", e.Message);
            }
        }

        [Fact]
        public void ShouldDeleteValidBook()
        {
            //Assume
            IBooksService booksService = new BooksService();

            //Act
            booksService.Add(new Book
            {
                Title = "Test Book Delete",
                Author = "Test Author Delete",
                Language = "Test Language Delete"
            });
            booksService.Delete(3);

            //Assert
            try
            {
                booksService.Get(3);
            }catch (Exception e)
            {
                Assert.Equal("Sequence contains no matching element", e.Message);
            }
        }

        [Fact]
        public void ShouldNotDeleteInvalidBook()
        {
            //Assume
            IBooksService booksService = new BooksService();

            try
            {
                //Act
                booksService.Delete(3);
            }
            catch(Exception e)
            {
                //Assert
                Assert.Equal("Invalid id !", e.Message);
            }
        }
    }
}
