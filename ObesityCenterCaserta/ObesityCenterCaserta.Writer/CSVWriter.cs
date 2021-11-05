using ObesityCenterCaserta.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObesityCenterCaserta.Writer
{
    public class CSVWriter : IWriter<Paziente>
    {
        private readonly Nowzaradan GiudizioDelDottore;

        public CSVWriter(Nowzaradan giudizioDelDottore)
        {
            GiudizioDelDottore = giudizioDelDottore;
        }
        public void WriteData(string path, IEnumerable<Paziente> lista)
        {
            File.WriteAllLines(path, 
                    lista.Select(x=> $"{x.Name};{x.BMI};" +
                    $"{GiudizioDelDottore.GetBMIClassification(x.BMI)}")
            );
        }

    }

    
}
