namespace VGLibrary.Models
{
    public class Game
    {
        private static int nextID = 0;
        public int? Id { get; set; } = nextID++;

        public string Title { get; set; } = "{NO TITLE}";
        public string Platform { get; set; } = "{NO PLATFORM}";
        public string Genre { get; set; }

        public float? Rating { get; set; } = 0f;
        public int? Year { get; set; } = 1958;
        public string Image { get; set; }
        public string LoanedTo { get; set; }


        public DateTime? LoanDate { get; set; }

    }
}
