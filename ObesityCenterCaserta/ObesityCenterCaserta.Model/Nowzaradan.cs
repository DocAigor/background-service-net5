using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObesityCenterCaserta.Model
{
    public class Nowzaradan
    {
        private readonly IList<ClassificationBMI> _tabellaBMI;
        public Nowzaradan(IList<ClassificationBMI> tabellaBMI)
        {
            _tabellaBMI = tabellaBMI;
        }

        public string GetBMIClassification(decimal bmi) =>
            _tabellaBMI.Where(x=>bmi>=x.MinIndex && bmi<x.MaxIndex)
            .Select(y=>y.Classification)
            .Single();
        
    }
}
