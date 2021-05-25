using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameLibraryPt1.Models
{

    
    public class Game
    {
        public int? Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Platform { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Rating { get; set; }
        [Required]
        public int Year { get; set; }
        public string Image { get; set; } = null;
        public string LoanedTo { get; set; } = null;
        public DateTime? LoanDate { get; set; } = null;

        [Required]
        public string UserId { get; set; }


        public Game()
        {

        }

        public Game(string title,string platform,string genre,string rating, int year, string image, string loadnedTo, DateTime? loanDate)
        {
            this.Title = title;
            this.Platform = platform;
            this.Genre = genre;
            this.Rating = rating;
            this.Year = year;
            this.Image = image;
            this.LoanedTo = loadnedTo;
            this.LoanDate = loanDate;
        }

        

       public string Tostring()
        {
            return ($"{Title}, {Platform}, {Genre}, {Rating}, {Year}, {Image}, {LoanedTo}, {LoanDate}");

        }

    }
}
