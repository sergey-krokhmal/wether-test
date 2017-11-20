using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherEntities.Model
{
    /// <summary>
    /// Класс EF представляющий таблицу с информацией о погоде
    /// </summary>
    public class Weather
    {
        /// <summary>
        /// Id записи о погоде
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Дата погоды. Обяз.
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Погода на текущий день Date для конкретного города Id_City. Обяз.
        /// </summary>
        [Required]
        public string Wether_Type { get; set; }

        /// <summary>
        /// Id города, для которого текущая информация о погоде. Обяз.
        /// </summary>
        [Required]
        public int Id_City { get; set; }
        
        /// <summary>
        /// Объект представляющий информацию о городе Id_City
        /// </summary>
        [ForeignKey("Id_City")]
        public City City { get; set; }

        /// <summary>
        /// Температура днём. Обяз.
        /// </summary>
        [Required]
        public decimal Temperature_Day { get; set; }

        /// <summary>
        /// Температура ночью. Обяз.
        /// </summary>
        [Required]
        public decimal Temperature_Night { get; set; }
    }
}
