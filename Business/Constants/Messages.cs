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
    }
}
