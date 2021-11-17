using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileManipulate
{
  public  interface IFileManipulateService
    {
        FileInfo Add(string eklenecekDosya);
        FileInfo Delete(string silinecekDosya);
        FileInfo Update(string guncellenecekDosya,string yeniDosya);
    }
}
