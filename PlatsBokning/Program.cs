using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PlatsBokning
{
    internal class Program
    {

        public static List<Seat> seats = new List<Seat>();
        public static List<Seat> booked = new List<Seat>();

        static void Main(string[] args)
        {
            Output output = new Output();
            Seat seat = new Seat();
            Handler handler = new Handler();

            //seat.SeatResetTemplate(); starta denna vid första uppstart, samt ta bort handler.load på rad 28



            while (true)
            {
                handler.Load();
                if(seats.Count == 0) 
                {
                    seat.SeatResetTemplate();
                    handler.Save();
                }

                booked.Clear();
                foreach (Seat seatx in seats)
                {
                    if (seatx.IsBooked == true)
                    {
                        booked.Add(seatx);
                        {
                        }
                        seatx.Display = $"*{seatx.SeatNumber+1}*";

                    }
                }
                Console.Clear();
                output.DisplaySeats();


                Console.WriteLine("\n1. Boka biljett");
                Console.WriteLine("2. AVBoka biljett");
                Console.WriteLine("3. Visa bokade biljetter");
                Console.WriteLine("4. Avsluta");
                string optionX = Console.ReadLine();
                if (int.TryParse(optionX, out int option))
                {
                    if (option == 1)
                    {
                        seat.BookSeat();
                        handler.Save();
                        Console.ReadKey();
                    }
                    else if (option == 2)
                    {
                        if(booked.Count() > 0)
                        {
                            output.DisplaySeats();
                            Console.WriteLine("\nDina säten");
                            for (int i = 0; i < booked.Count(); i++)
                            {
                                Console.Write($"Plats : {booked[i].SeatNumber + 1}");
                            }
                            Console.WriteLine("\n");
                            seat.UnbookSeat();
                            handler.Save();
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Du har inga säten att avboka!");
                            Console.WriteLine("Klicka på vilken knapp som helst för att fortsätta!");
                            Console.ReadKey();
                        }

                    }
                    else if (option == 3)
                    {
                        if (booked.Count() > 0)
                        {
                            output.PrintTickets();
                            Console.WriteLine("\nKlicka på vilken knapp som helst för att fortsätta!");
                            Console.ReadKey();
                        }
                        else if (booked.Count() == 0)
                        {
                            Console.WriteLine("Du har inga bokade säten!");
                            Console.WriteLine("Klicka på vilken knapp som helst för att fortsätta!");
                        }
                        Console.ReadKey();

                    }
                    else if (option == 4)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Felaktig inmatning!");
                        Console.WriteLine("Tryck på valfri tangent för att fortsätta");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Felaktig inmatning!");
                    Console.WriteLine("Tryck på valfri tangent för att fortsätta");
                    Console.ReadKey();
                }

            }
        }
    }
}
