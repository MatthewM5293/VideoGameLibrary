namespace VGLibrary.Models
{
    public class Game
    {
        private static int nextID = 0;
        public int? Id { get; set; } = nextID++;

        public string Title { get; set; } = "{NO TITLE}";
        public string? Platform { get; set; } = "{NO PLATFORM}";
        public string Genre { get; set; }

        public string? Rating { get; set; }
        public int Year { get; set; } = 1958;
        public string Image { get; set; }
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
