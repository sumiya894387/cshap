﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Cognizant.MovieCruiser.Model;
using Com.Cognizant.MovieCruiser.Dao;
namespace MovieCruiser
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;




            //favoritemovielist
            List<Movie> favorites = new List<Movie>()
            {


                new Movie(1, "Avatar", 2787965087, "Yes", "15/03/2017", "Science Fiction", "Yes"),
                new Movie(2, "The Avengers", 1518812988, "Yes", "23/12/2017", "Superhero", "No")

            };

            Admin admin = new Admin();
            Customer customer = new Customer();


            Dictionary<int, Customer> customerList = new Dictionary<int, Customer>()
            {
                 {1,new Customer( 1,"sumiya") },
                {2, new Customer(2,"sumi") },
            };

            Console.WriteLine("welcome to movie cruiser");
            Console.WriteLine("If you are an admin enter 1 OR If you are  a customer enter 2 ");




            int UserType = Convert.ToInt16(Console.ReadLine());

            if (UserType == 1)
            {
                Console.WriteLine("enter your name:");
                admin.adminName = Console.ReadLine();
                Console.WriteLine("enter your admin id:");
                admin.adminId = Console.ReadLine();
                if ((admin.adminName == "Sumiya") && (admin.adminId == "473"))
                {
                    int choice = 1;
                    Console.WriteLine("Logged in admin successfully");
                    while (choice == 1)
                    {
                        Console.WriteLine("Enter 1 to view movielist,2 to edit movie and 0 to exit");
                        int option = Convert.ToInt32(Console.ReadLine());
                        if (option < 0 || option > 2)
                        {
                            Console.WriteLine("wrong option selected");
                        }
                        if (option == 1)
                        {
                            List<Movie> movielist = new List<Movie>();
                            admin.DisplayMovieListByAdmin(movielist);
                        }
                        else if (option == 2)
                        {
                            Console.WriteLine("enter id of movie to edit");
                            int k = Convert.ToInt32(Console.ReadLine());
                            admin.EditMovie(k);
                            Console.WriteLine("Movie record updated successfully");
                        }
                        else if (option == 0)
                        {
                            choice = 0;
                        }
                    }
                }



                else
                {
                    Console.WriteLine("wrong input,try again");
                }

            }






            if (UserType == 2)
            {
                Console.WriteLine("Enter your name");
                string customerName = Console.ReadLine();
                Console.WriteLine("Enter your Customer Id");
                int customerId = Convert.ToInt32(Console.ReadLine());
                int customeriD = customerId - 1;

                if (customerList.ContainsKey(customerId))
                {
                    if (customerId == customerList[customerId].CustomerId && customerName == customerList[customerId].CustomerName)
                    {
                        int choice1 = 1;


                        Console.WriteLine("Logged in succesfully as a customer");

                        while (choice1 == 1)
                        {
                            Console.WriteLine("Enter 1 to view movie list \n Enter 2 to add movie to favorites\n Enter 3 to view favorites \n Enter 4 to remove item from favorites \n Enter 0 to exit");
                            int option1 = Convert.ToInt32(Console.ReadLine());
                            if (option1 == 1)
                            {
                                List<Movie> movielist = new List<Movie>();
                                customer.DisplayMovieListByCustomer(movielist);
                            }
                            else if (option1 == 2)
                            {
                                List<Movie> movielist = new List<Movie>();
                                customer.DisplayMovieListByCustomer(movielist);
                                Console.WriteLine("enter an id from movielist to add to favorites");

                                int x = Convert.ToInt32(Console.ReadLine());
                                customer.AddToFavorites(x, favorites);
                            }
                            else if (option1 == 3)
                            {
                                customer.ViewFavorites(favorites);
                            }
                            else if (option1 == 4)
                            {
                                List<Movie> movielist = new List<Movie>();
                                customer.DisplayMovieListByCustomer(movielist);
                                Console.WriteLine("enter id in favorites to delete from favorites");
                                int y = Convert.ToInt32(Console.ReadLine());
                                customer.RemoveFavorites(y, favorites);
                            }
                            else if (option1 == 0)
                            {
                                choice1 = 0;
                            }

                            else
                            {
                                Console.WriteLine("wrong input");

                            }
                        }
                    }
                }

            }






        }
    }
}

            