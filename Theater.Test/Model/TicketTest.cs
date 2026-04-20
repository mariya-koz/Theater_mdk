using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Theater.Test.Model
{
    internal class TicketTest
    {
        [Fact]
        public void Book_WithValidData_ShouldBeValid()
        {
            // Создаем объект книги с валидными значениями.
            var book = new Ticket
            {
                Name = "C# in Depth",     // Обязательное поле, строка < 100 символов
                Author = new Author { Name = "Пушкин" },      // Обязательное поле, строка < 100 символов
                Year = 2020,               // В пределах допустимого диапазона 1000–2100
            };

            // Создаем контекст валидации на основе объекта
            var context = new ValidationContext(book);

            // Сюда будут записаны ошибки валидации, если они есть
            var result = new List<ValidationResult>();

            // Проводим валидацию объекта с учетом всех атрибутов [Required], [Range] и т.п.
            var isValid = Validator.TryValidateObject(book, context, result, true);

            // Ожидаем, что валидация прошла успешно (все поля корректны)
            Assert.True(isValid);

            // Также убеждаемся, что список ошибок пуст
            Assert.Empty(result);
        }
    }
}
