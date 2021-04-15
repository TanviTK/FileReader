using BitMiracle.Docotic.Pdf;
using FileReaderLibrary;
using Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PDFReaderLibrary.Processor
{
    class PdfProcessor : IProcessor
    {
        private Repository.FileReaderRepo ReaderRepo { get; set; }
        private FileTableInfo FileTable { get; set; }
        private List<Mappings> Mappings { get; set; }
        private List<Output> OutputData { get; set; }
        public PdfProcessor(FileTableInfo file)
        {
            ReaderRepo = new Repository.FileReaderRepo();
            FileTable = new FileTableInfo();
            Mappings = new List<Mappings>();
            OutputData = new List<Output>();
            FileTable = file;
        }
        public void LoadData()
        {
            if (FileTable == null)
            {
                throw new KeyNotFoundException();
            }
           Mappings = ReaderRepo.GetMappingData(FileTable.SettingId);
        }

        public void ProcessFile()
        {
            string filePath = FileTable.FileLocation;
            using (var pdf = new PdfDocument(filePath))
            {
                PdfTextExtractionOptions options = new PdfTextExtractionOptions
                {
                    SkipInvisibleText = true,
                    WithFormatting = true
                };
                string formattedText = pdf.GetText(options);
                string modifiedText = Regex.Replace(formattedText, @"(?<=\b)\p{Zs}(?=\b)", string.Empty);
                string[] strArray = Regex.Split(modifiedText, @"\s+");
                foreach (var map in Mappings)
                {
                    OutputData.Add(new Output
                    {
                        FileId = FileTable.FileId,
                        DataType = map.MapType,
                        Value = GetNextIndexValue(strArray, map.MapName),
                    });
                }
            }
        }

        public void SaveData()
        {
            string isInserted = ReaderRepo.InsertOutputData(OutputData);
            string isUpdated = ReaderRepo.UpdateFileTableData(FileTable.FileId);
        }

        #region Helper
        public string GetNextIndexValue(string[] strArray, string type)
        {
            var index = Array.IndexOf(strArray, type) + 1;
            return Regex.Replace(strArray[index], @"[,)(]", string.Empty);
        }
        #endregion Helper
    }
}
