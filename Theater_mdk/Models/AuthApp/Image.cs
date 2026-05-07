namespace Theater_mdk.Models.AuthApp
{
    public class Image
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] ImageData { get; set; } // Хранит бинарные данные изображения
        public string ContentType { get; set; } // Опционально: тип контента изображения
    }
}
