using System.Collections.Generic;

namespace AspNetSandBox
{
    public interface IBooksService
    {
        IEnumerable<Book> Get();
        Book Get(int id);
        void Add(Book value);
        void Delete(int id);
        void Update(int id, string value);
    }
}