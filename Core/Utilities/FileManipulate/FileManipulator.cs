using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileManipulate
{
    public class FileManipulator:IFileManipulateService
    {

        //destination can change - I'm gonna change how it works
        // string _destinationFolder = @"C:\Users\user\source\repos\CarRental\Business\Images\CarImages\";

        ///Images/CarImages/

      //  string _destinationFolder = Path.GetFullPath( @"..\Business\Images\CarImages\");

        string _destinationFolder = "~/Images/CarImages/";

        string myExtension = ".jpg";
        public FileInfo Add(string eklenecekDosya)
        {

            string copiedFile = $"{_destinationFolder}{YeniIsim()}{myExtension}";


            File.Copy(eklenecekDosya, copiedFile);
            return new FileInfo(copiedFile);
        }


        public FileInfo Delete(string silinecekDosya)
        {

            string deletedFile = silinecekDosya;


            File.Delete(silinecekDosya);
            return new FileInfo(deletedFile);
        }

        public FileInfo Update(string guncellenecekDosya, string yeniDosya)
        {
            File.Delete(guncellenecekDosya);
            var updatedFile= Add(yeniDosya);
            return updatedFile;
        }

        private string YeniIsim()
        {
            return Guid.NewGuid().ToString("N");
        }

    }
}
