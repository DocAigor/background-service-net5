using System.Collections.Generic;

namespace ObesityCenterCaserta.Reader
{
    public interface IReader<T>
    {
        IEnumerable<T> Read(string path);
    }
}
