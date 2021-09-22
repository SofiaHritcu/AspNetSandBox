using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSandBox.DTOs;
using AspNetSandBox.Models;
using AutoMapper;

namespace AspNetSandBox.Profiles
{
    /// <summary>BookProfile.</summary>
    public class BookProfile : Profile
    {
        /// <summary>Initializes a new instance of the <see cref="BookProfile" /> class.</summary>
        public BookProfile()
        {
            CreateMap<CreateBookDto, Book>();

            CreateMap<Book, ReadBookDto>();
        }
    }
}
