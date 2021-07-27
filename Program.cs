using System;
using System.Collections.Generic;
using System.Linq;

namespace Bootcamps.Avenade.Series
{
    class Program
    {
        static SeriesRepository repository = new SeriesRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSeries();
                        break;
                    case "3":
                        UpdateSeries();
                        break;
                    case "4":
                        DeleteSeries();
                        break;
                    case "5":
                        ViewSeries();
                        break;
                    default:
                        Console.Clear();
                        break;
                }

                userOption = GetUserOption();
            }

            Console.WriteLine("Thank you for using our services..");
            System.Environment.Exit(0);
        }

        private static void DeleteSeries()
        {
            Console.Clear();
            Console.WriteLine("---- DELETE A SERIES");
            Console.WriteLine();
            var idList = ListSeries();
            if (idList.Count() > 0)
            {
                Console.Write("Enter the series id: ");
                int seriesIndex = int.Parse(Console.ReadLine());
                if (idList.Contains(seriesIndex))
                {
                    var series = repository.ReturnById(seriesIndex);
                    if (!series.getDeleted())
                    {
                        repository.Delete(seriesIndex);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("The series of the entered id has already been deleted");
                        System.Threading.Thread.Sleep(2000);
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Unable to find a series with the given id! Please try again!");
                    System.Threading.Thread.Sleep(2000);
                    DeleteSeries();
                }
            }
        }

        private static void ViewSeries()
        {
            Console.Clear();
            Console.WriteLine("---- VIEW A SERIES");
            Console.WriteLine();
            var idList = ListSeries();
            if (idList.Count() > 0)
            {
                Console.Write("Enter the series id: ");
                int seriesIndex = int.Parse(Console.ReadLine());
                if (idList.Contains(seriesIndex))
                {
                    Console.Clear();
                    var series = repository.ReturnById(seriesIndex);
                    Console.WriteLine("Viewing series with id = " + series.getId());
                    Console.WriteLine("----");
                    Console.WriteLine(series);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Unable to find a series with the given id! Please try again!");
                    System.Threading.Thread.Sleep(2000);
                    ViewSeries();
                }
            }
        }

        private static void UpdateSeries()
        {
            Console.Clear();
            Console.WriteLine("---- UPDATE A SERIES");
            Console.WriteLine();
            var idList = ListSeries();
            Console.Write("Enter the series id: ");
            int seriesIndex = int.Parse(Console.ReadLine());

            if (idList.Contains(seriesIndex))
            {
                Console.Clear();

                var series = repository.ReturnById(seriesIndex);
                var genresList = new List<int>();

                Console.WriteLine("Editing series with ID = {0}: {1} {2}", seriesIndex, series.getTitle(), (series.getDeleted() ? "*Deleted*" : ""));
                Console.WriteLine();

                foreach (int i in Enum.GetValues(typeof(Genre)))
                {
                    Console.WriteLine("{0}- {1}", i, Enum.GetName(typeof(Genre), i));
                    genresList.Add(i);
                }

                Console.WriteLine();
                Console.Write("Enter one genre id from the options above: ");
                int entryGenre = int.Parse(Console.ReadLine());

                if (genresList.Contains(entryGenre))
                {

                    Console.Write("Enter the series title: ");
                    string entryTitle = Console.ReadLine();

                    Console.Write("Enter the start year of the series: ");
                    int entryYear = int.Parse(Console.ReadLine());

                    Console.Write("Enter the series description: ");
                    string entryDescription = Console.ReadLine();

                    Series updateSeries = new Series(id: seriesIndex,
                                                genre: (Genre)entryGenre,
                                                title: entryTitle,
                                                year: entryYear,
                                                description: entryDescription);

                    repository.Update(seriesIndex, updateSeries);

                    Console.Clear();
                    Console.WriteLine("The series has been successfully updated!");
                    ListSeries();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Unable to find a genre with the given id! Please start the process again!");
                    System.Threading.Thread.Sleep(2000);
                    UpdateSeries();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Unable to find a series with the given id! Please try again!");
                System.Threading.Thread.Sleep(2000);
                UpdateSeries();
            }
        }
        private static List<int> ListSeries()
        {
            Console.Clear();
            Console.WriteLine("---- LIST SERIES");
            Console.WriteLine();

            var idList = new List<int>();

            var list = repository.List();

            if (list.Count == 0)
            {
                Console.WriteLine("There is no registered series.");
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------");
                return new List<int>();
            }

            foreach (var series in list)
            {
                var deleted = series.getDeleted();

                idList.Add(series.getId());

                Console.WriteLine("#ID {0}: {1} {2}", series.getId(), series.getTitle(), (deleted ? "*Deleted*" : ""));
            }
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            return idList;
        }

        private static void InsertSeries()
        {
            Console.Clear();
            Console.WriteLine("---- INSERT NEW SERIES");
            Console.WriteLine();
            var genresList = new List<int>();


            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}- {1}", i, Enum.GetName(typeof(Genre), i));
                genresList.Add(i);
            }

            Console.WriteLine();
            Console.Write("Enter one genre id from the options above: ");
            int entryGenre = int.Parse(Console.ReadLine());

            if (genresList.Contains(entryGenre))
            {

                Console.Write("Enter the series title: ");
                string entryTitle = Console.ReadLine();

                Console.Write("Enter the start year of the series: ");
                int entryYear = int.Parse(Console.ReadLine());

                Console.Write("Enter the series description: ");
                string entryDescription = Console.ReadLine();

                Series newSeries = new Series(id: repository.NextId(),
                                            genre: (Genre)entryGenre,
                                            title: entryTitle,
                                            year: entryYear,
                                            description: entryDescription);

                repository.Add(newSeries);
                Console.Clear();
                Console.WriteLine("The series has been successfully added!");
                ListSeries();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Unable to find a genre with the given id! Please start the process again!");
                System.Threading.Thread.Sleep(2000);
                UpdateSeries();
            }
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Matheus version of the Avanade Bootcamp series system at your service!!!");
            Console.WriteLine();
            Console.WriteLine("1- List series");
            Console.WriteLine("2- Insert new series");
            Console.WriteLine("3- Update a series");
            Console.WriteLine("4- Delete a series");
            Console.WriteLine("5- View a series");
            Console.WriteLine("X- Exit");
            Console.WriteLine();
            Console.WriteLine("Enter the desired option: ");

            string userOption = Console.ReadLine();
            Console.WriteLine();
            return userOption.ToUpper();
        }
    }
}