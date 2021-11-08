using ObesityCenterCaserta.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ObesityCenterCaserta.Reader
{
    public class CSVReader : IReader<Paziente>
    {
        public IEnumerable<Paziente> Read(string path)
        {
            if (!File.Exists(path)) return Enumerable.Empty<Paziente>();
            var listPazienti = new List<Paziente>();
            var pazienti = File.ReadAllLines(path);
            foreach(var paziente in pazienti.Skip(1)){
                var campiPazienti = paziente.Split(";");
                listPazienti.Add(new Paziente(campiPazienti[0],
                    Convert.ToDecimal(campiPazienti[1], new CultureInfo("en-GB")),
                    Convert.ToDecimal(campiPazienti[2], new CultureInfo("en-GB"))));
            }
            return listPazienti;
        }
    }
}
