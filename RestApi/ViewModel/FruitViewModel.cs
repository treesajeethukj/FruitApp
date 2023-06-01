using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.ViewModel
{
    public class fruitViewModel 
    {

            public string Name { get; set; }
            public string FruitFamily { get; set; }
            public string Genus { get; set; }
            public string Order { get; set; }
            public nutritionsViewModel Nutritions { get; set; }




        }
        public class nutritionsViewModel
        {
            
            public int Carbohydrates { get; set; }
            public int Protein { get; set; }
            public int Fat { get; set; }
            public int Calories { get; set; }
            public int Sugar { get; set; }

        }
    }

