using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReaderLibrary
{
    public interface IProcessor
    {
        void LoadData();
        void ProcessFile();
        void SaveData();
    }
}
