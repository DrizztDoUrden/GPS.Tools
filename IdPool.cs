using System.Collections.Generic;

namespace GPS.Tools
{
	public class IdPool : IIdPool
	{
		public Id this[string name] => new Id(this, name);
		public string this[Id id] => _idToName[id.Value];
		public int Count => _next;

		public int GetRawId(string name)
		{
			var ntl = name.ToLower();

			if (_nameToId.TryGetValue(ntl, out var id))
				return id;

			id = _next++;
			_nameToId.Add(ntl, id);
			_idToName.Add(id, name);
			return id;
		}

		private readonly Dictionary<int, string> _idToName = new Dictionary<int, string>();
		private readonly Dictionary<string, int> _nameToId = new Dictionary<string, int>();
		private int _next = 0;
	}
}