using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatsBokning
{
    internal class Seat
    {
        public int SeatNumber { get; set; }
        public bool IsBooked { get; set; }

        public bool IsSmoker { get; set; }
        public string Display { get; set; }

        Output output = new Output();
        Program program = new Program();
        Handler handler = new Handler();
        public void SeatResetTemplate()
        {
            for (int i = 0; i <= 33; i++)
            {
                Seat seat = new Seat();
                seat.Display = $"{i + 1}";
                seat.SeatNumber = i;
                seat.IsBooked = false;
                Program.seats.Add(seat);
                if (i > 18)
                {
                    seat.IsSmoker = true;
                }
                else
                {
                    seat.IsSmoker = false;
                }
            }
        }

        public void BookSeat()
        {
            Console.Clear();
            output.DisplaySeats();
            Console.WriteLine("\nVälkommen till SJ. För att boka en biljett, skriv dess platsnummer!");
            Console.Write("Plats : ");
            string choice = Console.ReadLine();
            int choiceInt;
            while (true)
            {
                bool valid = false;
                while (!valid)
                {
                    if (int.TryParse(choice, out choiceInt))
                    {
                        if(choiceInt > 0 && choiceInt < Program.seats.Count())
                        {
                            if (Program.seats[choiceInt-1].IsBooked == true)
                            {
                                Console.WriteLine("Denna plats är redan bokad, testa en annan!");
                                Console.Write("Plats : ");
                                choice = Console.ReadLine();
                            }
                            else
                            {
                                choiceInt = int.Parse(choice);


                                Console.WriteLine($"Du har nu bokat platsen {choiceInt}, klicka på vilken knapp som helst för att fortsätta!");

                                Program.seats[choiceInt - 1].Display = $"*{Program.seats[choiceInt - 1].Display}*"; //alterntaivt $"*{choice}*";
                                Program.seats[choiceInt - 1].IsBooked = true;
                                valid = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Felaktig input, testa igen!");
                            Console.Write("Plats : ");

                            choice = Console.ReadLine();
                        
                        }
                    }
                    else if (choice.ToLower() == "x")
                    {
                        Console.WriteLine("Du har avbrytit bokningen! Klicka på vilken knapp som helst för att fortsätta!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Felaktig input, testa igen!");
                        Console.Write("Plats : ");

                        choice = Console.ReadLine();
                    }
                }
                break;


            }
        }
        
        public void UnbookSeat()
        {
            Console.WriteLine("Vilket säte vill du avboka?");
            Console.Write("Plats : ");
            string choice = Console.ReadLine();
            bool valid = false;
            while (!valid)
            {
                if(int.TryParse(choice, out int choiceInt))
                {
                    if(choiceInt > 0 && choiceInt <= Program.seats.Count())
                    {
                        if (Program.seats[choiceInt - 1].IsBooked == true)
                        {
                            Program.seats[choiceInt - 1].IsBooked = false;
                            Program.seats[choiceInt - 1].Display = $"{choiceInt}";
                            
                            Console.WriteLine($"Du avbokade plats : {Program.seats[choiceInt - 1].SeatNumber+1}");
                            Console.WriteLine("Klicka på vilken knapp som helst för att fortsätta!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Du kan inte avboka en plats som inte är bokad! Försök igen!");
                            Console.Write("Plats : ");
                            choice = Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Felaktig input, testa igen!");
                        Console.Write("Plats : ");
                        choice = Console.ReadLine();
                    }
                }
                else if(choice.ToLower() == "x")
                {                    
                    Console.WriteLine("Du har avbrytit avbokningen! Klicka på vilken knapp som helst för att fortsätta!");
                    break;
                }
                else
                {
                    Console.WriteLine("Felaktig input!");
                    Console.Write("Plats : ");
                    choice = Console.ReadLine();
                }
            }
        }
    }
}
