using Library.DTOs;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Library.Services
{
    public class BooksService
    {
        public List<BookDTO> GetBooks(string directoryPath)
        {
            var booksDTO = new List<BookDTO>();

            string[] files = Directory.GetFiles(directoryPath);

            foreach (var file in files)
            {
                var bookDTO = new BookDTO();
                var arrPath = file.Split('\\');
                bookDTO.Id = arrPath[arrPath.Length-1];
                var arrFileName = bookDTO.Id.Split('.');
                bookDTO.Title = arrFileName[0];
                booksDTO.Add(bookDTO);
            }

            return booksDTO;
        }

        public List<WordDTO> GetBookById(string directoryPath, string id)
        {
            var fileName = directoryPath + id;
            var wordsDTO = new List<WordDTO>();

            var fileContent = File.ReadAllText(fileName);
            var words = fileContent
              .Split(' ')
              .Where(x => x.Length>=5)
              .GroupBy(x => x)
              .Select(x => new {
                  KeyField = x.Key,
                  Count = x.Count()
              })
              .OrderByDescending(x => x.Count)
              .Take(10);

            foreach(var word in words)
            {
                var wordDTO = new WordDTO();
                wordDTO.Word = word.KeyField[0].ToString().ToUpper() + word.KeyField.Substring(1);
                wordDTO.Count = word.Count;
                wordsDTO.Add(wordDTO);
            }

            return wordsDTO;
        }

        public List<WordDTO> SearchWords(string directoryPath, string id, string query)
        {
            var fileName = directoryPath + id;
            var wordsDTO = new List<WordDTO>();

            var fileContent = File.ReadAllText(fileName);
            var words = fileContent
              .Split(' ')
              .Where(x => x.Length >= 5 && x.Contains(query))
              .GroupBy(x => x)
              .Select(x => new
              {
                  KeyField = x.Key,
                  Count = x.Count()
              })
              .OrderByDescending(x => x.Count);

            foreach (var word in words)
            {
                var wordDTO = new WordDTO();
                wordDTO.Word = word.KeyField[0].ToString().ToUpper() + word.KeyField.Substring(1);
                wordDTO.Count = word.Count;
                wordsDTO.Add(wordDTO);
            }

            return wordsDTO;
        }
    }
}