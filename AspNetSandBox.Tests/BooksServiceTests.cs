using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetSandBox.Tests
{
    public class BooksServiceTests
    {


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
