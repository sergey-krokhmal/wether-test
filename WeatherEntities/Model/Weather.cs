using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherEntities.Model
{
    public class Weather
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType("Date")]
        public DateTime Date { get; set; }

        [Required]
        public string Wether_Type { get; set; }

        [Required]
        public int Id_City { get; set; }

        [Required]
        [ForeignKey("Id_City")]
        public City City { get; set; }

        [Required]
        public decimal Temperature_Day { get; set; }

        [Required]
        public decimal Temperature_Night { get; set; }
    }
}
