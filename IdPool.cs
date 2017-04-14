using System.Collections.Generic;

namespace GPS.Tools
{
    public class IdPool : IIdPool
    {
        public Id this[string name] => new Id(this, name);
        public string this[Id id] => _idToName[id.Value];
        
        public int GetRawId(string name)
        {
            if (_nameToId.TryGetValue(name, out var id))
                return id;
            
            id = _next++;
            _nameToId.Add(name, id);
            _idToName.Add(id, name);
            return id;
        }
        
        private readonly Dictionary<int, string> _idToName = new Dictionary<int, string>();
        private readonly Dictionary<string, int> _nameToId = new Dictionary<string, int>();
        private int _next = 0;
    }
}