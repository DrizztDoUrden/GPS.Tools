using System;

namespace GPS.Tools
{
    public interface IIdPool
    {
        Id this[string name] { get; }
        string this[Id id] { get; }
        
        int GetRawId(string name);
    }
}
