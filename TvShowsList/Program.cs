using System;
using System.Collections.Generic;
using System.Linq;

namespace TvShowsList
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentCommand = "";

            const string AVALIABLE_COMMANDS = "\nAvaliable commands:" +
                        "\n    [show id]: Adds/deletes a show from your favorites." +
                        "\n    list: Shows the full list of tv shows." +
                        "\n    favorites: Shows the tv shows marked as favorites." +
                        "\n    exit: Exit this program";
            const string NO_FAVS = "Currently you don't have any show in your favorites. Try adding one by writing it's ID as a command!";

            List<TvShow> shows = new List<TvShow>() {
                new TvShow(1, "Money Heist", false),
                new TvShow(2, "Breaking bad", false),
                new TvShow(3, "Castlevania", false),
                new TvShow(4, "Narcos", false),
                new TvShow(5, "Cupcake Wars", false),
                new TvShow(6, "Queen's Gambit", false),
                new TvShow(7, "The 100", false),
                new TvShow(8, "Final Space", false),
                new TvShow(9, "The Good Place", false)
            };

            void ShowAllShows()
            {
                var orderedShows = shows.OrderBy(s => s.Name);
                foreach (var item in orderedShows)
                {
                    string favStar = item.IsFavorite ? "*" : " ";
                    Console.WriteLine(favStar + " " + item.Id + " " + item.Name);
                }
            }

            void ShowFavorites()
            {
                var favShows = shows.FindAll(s => s.IsFavorite == true);
                if (favShows.Count == 0)
                {
                    Console.WriteLine(NO_FAVS);
                }
                else
                {
                    foreach (var item in favShows)
                    {
                        Console.WriteLine("* " + item.Id + " " + item.Name);
                    }
                }
            }

            do
            {
                Console.WriteLine("-=SuperCoolShowsDB=-\n");
                switch (currentCommand)
                {
                    case "list":
                        ShowAllShows();
                        break;
                    case "favorites":
                        ShowFavorites();
                        break;
                    default:
                        int id;
                        bool isId = int.TryParse(currentCommand, out id);
                        if (isId)
                        {
                            var selectedShow = shows.Find(s => s.Id == id);
                            if (selectedShow == null)
                            {
                                Console.WriteLine(id + " does not corresponds to a show ID.");
                            }
                            else
                            {
                                selectedShow.IsFavorite = !selectedShow.IsFavorite;
                                string message = (selectedShow.IsFavorite)
                                    ? selectedShow.Name + " was added to your favorites."
                                    : selectedShow.Name + " was removed from your favorites.";
                                Console.WriteLine(message);
                            }
                        }
                        else
                        {
                            ShowAllShows();
                        }

                        break;
                }
                Console.WriteLine(AVALIABLE_COMMANDS);
                currentCommand = Console.ReadLine();
                Console.Clear();
            } while (currentCommand != "exit");
        }
    }
}
