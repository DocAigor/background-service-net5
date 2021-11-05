using System;

namespace ObesityCenterCaserta.Model
{
    public class Paziente
    {
        public string Name { get;}
        public decimal Weight { get;}
        public decimal Height { get;}
        public decimal BMI => Weight / (Height * Height);
        public string Category { get; set; }

        public Paziente(string nome, decimal peso, decimal altezza)
        {
            Name = nome;
            Weight = peso;
            Height = altezza;
        }
    }
}
