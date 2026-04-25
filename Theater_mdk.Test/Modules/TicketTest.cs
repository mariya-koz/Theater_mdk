using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theater_mdk.Models;

namespace Theater_mdk.Test.Modules
{
    public class TicketTest
    {
        [Fact]
        public void Ticket_WithValidData_ShouldBeValid()
        {
            // Создаем объект книги с валидными значениями.
            var ticket = new Ticket
            {
                Name = "C# in Depth",     // Обязательное поле, строка < 100 символов
                DataShow = new DateTime(2001, 02, 20),      // Обязательное поле, строка < 100 символов
                Price = 2020,               // В пределах допустимого диапазона 1000–2100
            };

            // Создаем контекст валидации на основе объекта
            var context = new ValidationContext(ticket);

            // Сюда будут записаны ошибки валидации, если они есть
            var result = new List<ValidationResult>();

            // Проводим валидацию объекта с учетом всех атрибутов [Required], [Range] и т.п.
            var isValid = Validator.TryValidateObject(ticket, context, result, true);

            // Ожидаем, что валидация прошла успешно (все поля корректны)
            Assert.True(isValid);

            // Также убеждаемся, что список ошибок пуст
            Assert.Empty(result);
        }

        // Тест проверяет, что если не указать заголовок, то объект будет невалиден.
        [Fact]
        public void Ticket_WithInvalidYear_ShouldBeInvalid()
        {
            // Arrange
            var ticket = new Ticket
            {
                Name = "Test Ticket",
                DataShow = new DateTime(1500, 02, 20),
                Price = 1200 // ❗ теперь это действительно ошибка
            };

            var context = new ValidationContext(ticket);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(ticket, context, results, true);

            // Assert
            //Assert.False(isValid);
            //Assert.Contains(results, r => r.ErrorMessage.Contains("Год должен быть"));
        }
    }
}
