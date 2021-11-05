using System;
using System.Collections.Generic;

namespace ObesityCenterCaserta.Writer
{
    public interface IWriter<T>
    {
        void WriteData(string path,IEnumerable<T> lista);
    }
}
