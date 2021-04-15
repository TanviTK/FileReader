using PDFReaderLibrary.Processor;
using Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReaderLibrary
{
    public class ProcessManager
    {
        private FileReaderRepo Repo { get; set; }
        public ProcessManager()
        {
            Repo = new FileReaderRepo();
        }
        public void ProcessFiles()
        {
            //get all the files with isprocessed = 0
            
            List<FileTableInfo> unProcessedFiles = Repo.GetAllUnprocessedFiles();

            foreach (FileTableInfo file in unProcessedFiles)
            {
                IProcessor processor = GetFileProcesser(file);
                processor.LoadData();
                processor.ProcessFile();
                processor.SaveData();
            }
        }

        private static IProcessor GetFileProcesser(FileTableInfo  file)
        {
            string fileExtension = Path.GetExtension(file.FileLocation);

            if (fileExtension == ".pdf" || fileExtension == ".PDF")
                return new PdfProcessor(file);

            throw new NotImplementedException();
        }
    }
}
