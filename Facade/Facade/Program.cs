using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            HolidayBookingsFacade bookHoliday = new HolidayBookingsFacade();
            Console.WriteLine(bookHoliday.BookHolidayPackage("Thailand", DateTime.Now.AddMinutes(5), DateTime.Now.AddDays(4), "JacksonHotel"));
            Console.ReadKey();
        }
    }
    /// <summary>
    /// Facade Design Pattern
    /// </summary>
    class HolidayBookingsFacade
    {
        private readonly Packages package;
        private readonly AirTickets airTickets;
        private readonly Hotels hotel;

        public HolidayBookingsFacade()
        {
            package = new Packages();
            airTickets = new AirTickets();
            hotel = new Hotels();
        }

        private bool IsPackageAvailable(string place, DateTime from, DateTime to, string hotelName)
        {
            if (package.CheckAvailability(place, from, to) &&
                airTickets.isTicketAvailable(place, from, to) && hotel.isRoomAvailable(hotelName, from, to))
            {
                return true;
            }
            else
                return false;
        }

        public string BookHolidayPackage(string place, DateTime from, DateTime to, string hotel)
        {
            if (IsPackageAvailable(place, from, to, hotel))
                return "Booking is confirmed for " + (to.Day - from.Day).ToString() + "nights at the hotel " + hotel;
            else
            {
                return "Apologize for the inconvenience. Selected Package unavailable";
            }
        }

    }

    class Packages
    {
        public void checkForPackages(string place)
        {
            switch (place)
            {
                case "Thailand":
                    Console.WriteLine("Thailand");
                    break;
                case "Mauritius":
                    Console.WriteLine("Mauritius");
                    break;

                case "Maldives":
                    Console.WriteLine("Maldives");
                    break;

                case "Bali":
                    Console.WriteLine("Bali");
                    break;
            }
        }

        public bool CheckAvailability(string place, DateTime from, DateTime to)
        {
            bool isAvailable = false;
            if (place == "Bali" && (from >= DateTime.Now) && to <= DateTime.Now.AddDays(7))
            {
                isAvailable= true;
            }           

            if (place == "Mauritius" && (from >= DateTime.Now && to <= DateTime.Now.AddDays(3)))
            {
                isAvailable= true;
            }

            if (place == "Thailand" && (from >= DateTime.Now && to <= DateTime.Now.AddDays(10)))
            {
                isAvailable = true;
            }
            if (place == "Maldives" && (from >= DateTime.Now && to <= DateTime.Now.AddDays(10)))
            {
                isAvailable = true;
            }
            return isAvailable;
        }
    }

    class AirTickets
    {
        public bool isTicketAvailable(string place, DateTime from, DateTime to)
        {
            bool isAvailable = false;
            if (place == "Bali" && (from >= DateTime.Now && to <= DateTime.Now.AddDays(7)))
            {
                isAvailable = true;
            }

            if (place == "Mauritius" && (from >= DateTime.Now && to <= DateTime.Now.AddDays(3)))
            {
                isAvailable = true;
            }

            if (place == "Thailand" && (from >= DateTime.Now && to <= DateTime.Now.AddDays(10)))
            {
                isAvailable = true;
            }
            if (place == "Maldives" && (from >= DateTime.Now && to <= DateTime.Now.AddDays(10)))
            {
                isAvailable = true;
            }
            return isAvailable;
        }
    }

    class Hotels
    {
        public bool isRoomAvailable(string name, DateTime from, DateTime to)
        {
            bool isAvailable = false;
            if (name == "JacksonHotel" && (from >= DateTime.Now && to <= DateTime.Now.AddDays(7)))
            {
                isAvailable = true;
            }

            if (name == "JamesHotel" && (from >= DateTime.Now && to <= DateTime.Now.AddDays(3)))
            {
                isAvailable = true;
            }

            if (name == "BaxtonHotel" && (from >= DateTime.Now && to <= DateTime.Now.AddDays(10)))
            {
                isAvailable = true;
            }
            if (name == "JohnHotel" && (from >= DateTime.Now && to <= DateTime.Now.AddDays(10)))
            {
                isAvailable = true;
            }
            return isAvailable;
        }
    }
    
}
