using System.Collections.Generic;
using System.Data;

namespace libreria_JSVE.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Propiedades de navegacion
        public List<Book> Books { get; set; } 
    }
}
