using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatsBokning
{
    internal class Output
    {

        
        public void DisplaySeats()
        {

            Console.WriteLine($"{Program.seats[0].Display}  {Program.seats[7].Display}  {Program.seats[8].Display}  {Program.seats[15].Display} \t{Program.seats[16].Display}  {Program.seats[23].Display}  {Program.seats[24].Display}  {Program.seats[31].Display}");
            Console.WriteLine($"{Program.seats[1].Display}  {Program.seats[6].Display}  {Program.seats[9].Display}  {Program.seats[14].Display} \t {Program.seats[17].Display}  {Program.seats[22].Display}  {Program.seats[25].Display}  {Program.seats[30].Display}");
            Console.WriteLine("----Rökare---------Icke-Röckre-----");
            Console.WriteLine($"{Program.seats[2].Display}  {Program.seats[5].Display}  {Program.seats[10].Display}  {Program.seats[13].Display} \t{Program.seats[18].Display}  {Program.seats[21].Display}  {Program.seats[26].Display}  {Program.seats[29].Display}");
            Console.WriteLine($"{Program.seats[3].Display}  {Program.seats[4].Display}  {Program.seats[11].Display}  {Program.seats[12].Display} \t{Program.seats[19].Display}  {Program.seats[20].Display}  {Program.seats[27].Display}  {Program.seats[28].Display}");
        }

        public void PrintTickets()
        {
            Console.Clear();
            Console.WriteLine("Bokade biljetter:");
            int counter = 0;

            foreach (Seat seat in Program.seats)
            {
                if (seat.IsBooked == true)
                {
                    counter++;
                    Console.WriteLine($"---- Biljett {counter}----");
                    Console.WriteLine("Stockholm-Götebord 2019-10-10 10:00");
                    Console.WriteLine($"Plats {seat.SeatNumber+1}");
                    if (seat.IsSmoker == true)
                    {
                        Console.WriteLine("Rökare");
                    }
                    else
                    {
                        Console.WriteLine("Icke-Rökare");
                    }
                    if (seat.SeatNumber == 0 || seat.SeatNumber == 7 || seat.SeatNumber == 8 || seat.SeatNumber == 15 || seat.SeatNumber == 16 || seat.SeatNumber == 23 || seat.SeatNumber == 24 || seat.SeatNumber == 31)
                    {
                        Console.WriteLine("Fönsterplats");
                    }
                    else if (seat.SeatNumber == 3 || seat.SeatNumber == 4 || seat.SeatNumber == 11 || seat.SeatNumber == 12 || seat.SeatNumber == 19 || seat.SeatNumber == 20 || seat.SeatNumber == 27 || seat.SeatNumber == 28)
                    {
                        Console.WriteLine("Fönsterplats");
                    }
                    else
                    {
                        Console.WriteLine("Mittgång");
                    }

                }

            }
        }
    }
}
