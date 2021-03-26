using Library.Services;
using Microsoft.Extensions.Configuration;
using System;
using Xunit;
using System.Collections.Generic;
using Library.DTOs;

namespace UnitTest
{
    public class BookTests
    {
        //THIS IS THE FOLDER TEST 
        public string _booksPath = "C:\\Library\\Library\\Resources\\";

        [Fact]
        public void GetBookById()
        {
            var booksService = new BooksService();
            var wordsDTO = booksService.GetBookById(_booksPath, "A Tale Of Two Cities.txt");
            Assert.Equal(317, wordsDTO[0].Count);
        }

        [Fact]
        public void GetBooks()
        {
            var booksService = new BooksService();
            List<BookDTO> booksDTO = booksService.GetBooks(_booksPath);
            Assert.True(booksDTO.Count > 0);
        }

        [Fact]
        public void SearchWords()
        {
            var booksService = new BooksService();
            List<WordDTO> wordsDTO = booksService.SearchWords(_booksPath, "A Tale Of Two Cities.txt", "whi");
            Assert.Equal(317, wordsDTO[0].Count);

        }

    }
}
