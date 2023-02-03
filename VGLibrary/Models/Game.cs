using System.ComponentModel.DataAnnotations;
using VGLibrary.Validators;

namespace VGLibrary.Models
{
    [Game]
    public class Game
    {
        private static int nextID = 0;
        public int? Id { get; set; } = nextID++;

        [Required]
        public string Title { get; set; }
        [Required]
        public string? Platform { get; set; }
        [Required]
        public string Genre { get; set; }

        [Required]
        public string? Rating { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Image { get; set; } = "images/missing.png";



        public string? LoanedTo { get; set; }
        public DateTime? LoanDate { get; set; }

        public Game() { }

        public Game(int? id, string title, string? platform, string genre, string? ESRBrating, int year, string image, string? loanedTo, DateTime? loanDate)
        {
            Id = id;
            Title = title;
            Platform = platform;
            Genre = genre;
            Rating = ESRBrating;
            Year = year;
            Image = image;
            LoanedTo = loanedTo;
            LoanDate = loanDate;
        }
    }
}
