using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeatherEntities.Model
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Url_Code { get; set; }

        public virtual ICollection<Weather> Weathers { get; set; }
    }
}
