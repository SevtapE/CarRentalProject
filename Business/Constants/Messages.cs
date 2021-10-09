using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "The car is added";
        public static string CarDeleted = "The car is deleted";
        public static string CarUpdated = "The car is updated";

        public static string CarInvalidName = "InvalidName: The car description must have at least two characters.";
        public static string CarInvalidPrice = "InvalidPrice: The daily price must be greater than 0.";

        public static string BrandAdded = "The brand is added";
        public static string BrandDeleted = "The brand is deleted";
        public static string BrandUpdated = "The brand is updated";

        public static string BrandError = "There was an error.";

        public static string ColorAdded = "The color is added";
        public static string ColorDeleted = "The color is deleted";
        public static string ColorUpdated = "The color is updated";

        public static string ColorError = "There was an error.";

        public static string ColorGetAll = "The colors are listed.";

        public static string CustomerAdded = "The customer is added";
        public static string CustomerDeleted = "The customer is deleted";
        public static string CustomerUpdated = "The customer is updated";

        public static string UserAdded = "The user is added";
        public static string UserDeleted = "The user is deleted";
        public static string UserUpdated = "The user is updated";

        public static string RentalAdded = "The rental is added";
        public static string RentalDeleted = "The rental is deleted";
        public static string RentalUpdated = "The rental is updated";

        public static string RentalError = "There was an error.";
        public static string CarNotAvailable = "Another customer rented the car.";
    }
}
