using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic19_5
{
    // Исключение, указывающее, что книга уже выдана
    public class BookAlreadyTakenException : Exception
    {
        public string BookName { get; }
        public string ReaderName { get; }

        public BookAlreadyTakenException(string bookName, string readerName)
            : base($"Книга \"{bookName}\" уже взята читателем {readerName}.")
        {
            BookName = bookName;
            ReaderName = readerName;
        }
    }

    public class Library
    {
        // Словарь для отслеживания выданных книг (ключ = название книги, значение = имя читателя)
        private Dictionary<string, string> takenBooks = new Dictionary<string, string>();

        public void TakeBook(string bookName, string reader)
        {
            if (takenBooks.ContainsKey(bookName))
            {
                // Если книга уже выдана - кидаем исключение
                throw new BookAlreadyTakenException(bookName, takenBooks[bookName]);
            }
            takenBooks[bookName] = reader;
            Console.WriteLine($"Книга \"{bookName}\" успешно выдана читателю {reader}.");
        }

        public void ReturnBook(string bookName)
        {
            if (takenBooks.ContainsKey(bookName))
            {
                takenBooks.Remove(bookName);
                Console.WriteLine($"Книга \"{bookName}\" возвращена в библиотеку.");
            }
            else
            {
                Console.WriteLine($"Книга \"{bookName}\" не числится выданной.");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var library = new Library();

            try
            {
                library.TakeBook("Война и мир", "Иван Иванов");
                library.TakeBook("Война и мир", "Петр Петров"); // здесь будет исключение
            }
            catch (BookAlreadyTakenException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            library.ReturnBook("Война и мир");

            // Попытка взять книгу снова
            try
            {
                library.TakeBook("Война и мир", "Петр Петров");
            }
            catch (BookAlreadyTakenException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
