using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public interface IFileReader
    {
        string[] Read(string path);
    }
}
