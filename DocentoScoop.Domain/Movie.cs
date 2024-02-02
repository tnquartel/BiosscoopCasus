
namespace DocentoScoop.Domain;

    public class Movie
    {
        private string title;
        private List<MovieScreening> screenings = new List<MovieScreening>();

        public Movie(string title)
        {
            this.title = title;
        }

        public void addScreening(MovieScreening screening)
        {
            screenings.Add(screening);
        }

        public string toString()
        {
            return title;
        }
    }

