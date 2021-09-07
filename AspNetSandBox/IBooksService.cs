﻿using System.Collections.Generic;

namespace AspNetSandBox
{
    public interface IBooksService
    {
        void Delete(int id);
        IEnumerable<Book> Get();
        Book Get(int id);
        void Update(Book value);
        void Put(int id, string value);
    }
}