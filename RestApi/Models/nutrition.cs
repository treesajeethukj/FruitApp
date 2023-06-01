using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Models
{
    public class nutrition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNutritions { get; set; }

        [ForeignKey("fruit")]
        public int IdFruit { get; set; }
        public fruit fruit { get; set; }
        public double Carbohydrates { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double Calories { get; set; }
        public double Sugar { get; set; }
    }
}
