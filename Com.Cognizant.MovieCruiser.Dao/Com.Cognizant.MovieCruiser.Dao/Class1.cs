using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Cognizant.MovieCruiser.Model;

namespace Com.Cognizant.MovieCruiser.Dao
{
    abstract public class user
    {
        public List<Movie> movielist = new List<Movie>()
                {
                   new Movie(1,"Avatar",2787965087,"Yes","15/03/2017","Science Fiction","Yes"),
                    new Movie(2,"The Avengers",1518812988,"Yes","23/12/2017","Superhero","No"),
                    new Movie(3,"Titanic",2187463944,"Yes","21/08/2017","Romance","No"),
                    new Movie(4,"Jurassic World",1617713208,"No","02/07/2017","Science Fiction","Yes"),
                    new Movie(5,"Avengers",2750760348,"Yes","02/11/2022","Superhero","Yes")
            };
        abstract public List<Movie> GetMovieList();
    }
    public class Admin : user
    {
        string AdminId;
        public string adminId
        {
            get
            {
                return AdminId;
            }
            set
            {
                AdminId = value;
            }
        }
        string AdminName;
        public string adminName
        {
            get
            {
                return AdminName;
            }
            set
            {
                AdminName = value;
            }
        }
        public override List<Movie> GetMovieList()
        {
            return movielist;
        }

        public void DisplayMovieListByAdmin(List<Movie>movielist)
        {
            movielist = GetMovieList();
            int i = 1;
            Console.WriteLine(" Id     Title             BoxOffice        Active       DateOfLaunch        Genre          HasTeaser");

            foreach (Movie temp in movielist)
            {
                Console.WriteLine("{0,3}   {1,-18} {2,-6}    {3,-14} {4}    {5,-15}     {6}", i, temp.Title, temp.BoxOffice, temp.Active, temp.DateOfLaunch, temp.Genre, temp.HasTeaser);
                i++;
            }

        }
        public void EditMovie(int k)
        {
            movielist = GetMovieList();
            foreach (Movie temp in movielist)
            {
                if (temp.Id == k)
                {
                    Console.WriteLine("Enter title");
                    temp.Title = Console.ReadLine();
                    Console.WriteLine("Enter Active");
                    temp.Active = Console.ReadLine();
                    Console.WriteLine("Enter Dateoflaunch");
                    temp.DateOfLaunch = Console.ReadLine();
                    Console.WriteLine("Enter genre");
                    temp.Genre = Console.ReadLine();
                    Console.WriteLine("Enter Hasteaser");
                    temp.HasTeaser = Console.ReadLine();
                    Console.WriteLine("Selected Record Updated Succesfully");
                }
            }
            //GetMovieList(movielist);
        }
    }
    public class Customer : user
    {
        int customerId;
        public int CustomerId
        {
            get
            {
                return customerId;
            }
            set
            {
                customerId = value;
            }
        }
        string customerName;
        public string CustomerName
        {
            get
            {
                return customerName;
            }
            set
            {
                customerName = value;
            }
        }
        public Customer() { }
        public Customer(int customerId, string customerName)
        {
            this.customerId = customerId;
            this.customerName = customerName;
        }
      

        //public List<Movie> movielist;
        public override List<Movie> GetMovieList()
        {
            return movielist;
        }
        public void DisplayMovieListByCustomer(List<Movie> movielist)
        {
            movielist = GetMovieList();
            int i = 1;
            Console.WriteLine(" Id     Title             BoxOffice            Genre           HasTeaser");
            for (int a = 0; a < movielist.Count - (2); a++)
            {
                Console.WriteLine("{0,3}   {1,-18} {2,-6}    {3,-16}     {4,-2}", i, movielist[a].Title, movielist[a].BoxOffice, movielist[a].Genre, movielist[a].HasTeaser);
                i++;
            }
        }
        //Add to favorrites
        public void AddToFavorites(int id, List<Movie> favorites)

        {
            movielist = GetMovieList();
            int favId, s = 0, count = 0;
            string FavTitle;
            long FavBoxOffice;
            string FavActive;
            string FavDateOfLaunch;
            string FavGenre;
            string FavHasteaser;

            foreach (Movie temp in movielist)
            {
                count++;
                if (temp.Id == id)
                {
                    foreach (Movie emp in favorites)
                    {
                        if (temp.Id == emp.Id)
                        {
                            s = 1;
                        }
                    }
                    if (s == 0)
                    {
                        favId = temp.Id;
                        FavTitle = temp.Title;
                        FavBoxOffice = temp.BoxOffice;
                        FavActive = temp.Active;
                        FavDateOfLaunch = temp.DateOfLaunch;
                        FavGenre = temp.Genre;
                        FavHasteaser = temp.HasTeaser;
                        favorites.Add(new Movie(favId, FavTitle, FavBoxOffice, FavActive, FavDateOfLaunch, FavGenre, FavHasteaser));
                        Console.WriteLine("Movie Added to Favorites Succesfully");
                        Console.WriteLine("The movies list in favorites is");
                        ViewFavorites(favorites);
                    }
                    else
                    {
                        Console.WriteLine("The selected movie is in favorites already");
                    }
                }
            }
            if (count < id)
            {
                Console.WriteLine("Movie index out  bounds");
            }
        }
        public void ViewFavorites(List<Movie> favorites)
        {
            int i = 1;
            Console.WriteLine(" Id     Title             BoxOffice            Genre");
            foreach (Movie temp in favorites)
            {
                Console.WriteLine("{0,3}   {1,-18} {2,-6}    {3,-16}", i, temp.Title, temp.BoxOffice, temp.Genre);
                i++;
            }
        }
        //Remove Favorites
        public void RemoveFavorites(int id, List<Movie> favorites)
        {
            if (favorites.ElementAtOrDefault(id - 1) != null)
            {
                favorites.RemoveAt(id - 1);
                Console.WriteLine("Movie Removed Successfully from favorites");
                ViewFavorites(favorites);
            }
            else
                Console.WriteLine("No movie found with selected id");
        }
    }
}