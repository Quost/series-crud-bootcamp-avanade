namespace Bootcamps.Avenade.Series
{
    public class Series : BaseEntity
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set;  }


        public Series(int id, Genre genre, string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Description = description;
            this.Title = title;
            this.Year = year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string returnObj = "";

            returnObj += "Gender: " + this.Genre + "\n";
            returnObj += "Title: " + this.Title + "\n";
            returnObj += "Description: " + this.Description + "\n";
            returnObj += "Start year: " + this.Year + "\n";

            return returnObj;
        }

        public string getTitle(){
            return this.Title;
        }

        public int getId(){
            return this.Id;
        }

        public void Delete() {
            this.Deleted = true;
        }

        public bool getDeleted()
		{
			return this.Deleted;
		}
    }
}