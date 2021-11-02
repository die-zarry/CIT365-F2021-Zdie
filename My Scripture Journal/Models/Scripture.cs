using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace My_Scripture_Journal.Models
{
    public class Scripture
    {

        public int ID { get; set; }
       
        public string Book { get; set; }
        
        public int Chapter { get; set;}
        public int Verse { get; set; }
        [Display(Name = "Release Date")]


        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Note { get; set; }

    }
}
