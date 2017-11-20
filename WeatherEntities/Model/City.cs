using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeatherEntities.Model
{
    /// <summary>
    /// Класс EF для таблицы cities (Города)
    /// </summary>
    public class City
    {
        /// <summary>
        /// Id города в таблице
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Название города. Обязательное поле
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Часть url для ссылки на страниуц погоды города. Обязательное поле
        /// </summary>
        [Required]
        public string Url_Code { get; set; }

        public virtual ICollection<Weather> Weathers { get; set; }
    }
}
