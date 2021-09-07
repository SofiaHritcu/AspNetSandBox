using System.Collections.Generic;

namespace AspNetSandBox
{
    public interface IBooksService
    {
        void Delete(int id);
        IEnumerable<Book> Get();
        Book Get(int id);
        void Add(Book value);
        void Update(int id, string value);
    }
}