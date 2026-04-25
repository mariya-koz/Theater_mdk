using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Theater.Test.Model
{
    public class TicketTests
    {
        [Fact]
        public void Book_WithValidData_ShouldBeValid()
        {
            // Arrange
            var ticket = new Ticket
            {
                Title = "C# in Depth",           // Обязательное поле, строка < 100 символов
                TimeMin = 120, // Обязательное поле
                DataShow = new DateTime(2001, 02, 20),                     // В пределах 1000–2100
                Price = 1000,                    // Предположим, это сумма
            };

            // Act
            var context = new ValidationContext(ticket);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(ticket, context, results, true);

            // Assert
            Assert.True(isValid);
            Assert.Empty(results);
        }

        [Fact]
        public void Book_WithInvalidYear_ShouldBeInvalid()
        {
            // Arrange
            var ticket = new Ticket
            {
                Title = "Test Book",
                TimeMin = 312, // Обязательное поле
                DataShow = new DateTime (2001,02,20),                     // В пределах 1000–2100
                Price = 1000,                    // Предположим, это сумма
            };

            var context = new ValidationContext(ticket);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(ticket, context, results, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage != null &&
                                         r.ErrorMessage.Contains("Год должен быть"));
        }
    }

    // Пример классов с атрибутами валидации
    public class Ticket
    {
        [Required(ErrorMessage = "Название обязательно")]
        [StringLength(100, ErrorMessage = "Название не должно превышать 100 символов")]
        public string Title { get; set; }

        [Range(60, 300, ErrorMessage = "Год должен быть между 1000 и 2100")]
        public int TimeMin { get; set; }

        [Range(1000, 2100, ErrorMessage = "Год должен быть между 1000 и 2100")]
        public DateTime DataShow { get; set; }

        [Range(0, 1000000, ErrorMessage = "Цена должна быть положительной")]
        public double Price { get; set; }
    }

    public class Viewer
    {
        [Required(ErrorMessage = "Имя Зрителя обязательно")]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
