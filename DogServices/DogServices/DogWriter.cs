using System;
using System.IO;

namespace FinancialServices
{
    public class DogWriter : IWriter
    {
        public void Write(string source, string line)
        {

            try
            {
                File.AppendAllText(source, $"{line}{Environment.NewLine}");
            }
            catch (System.Exception)
            {

                throw new Exception("Impossibile scrivere il file.");
            }
        }
            
    }
}
