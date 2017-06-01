namespace GPS.Tools
{
    public struct Id
    {
        public static IdPool DefaultPool = new IdPool();
        public int Value { get; private set; }
        public string Name => _pool[this];
        
        public Id(string name)
        {
            _pool = DefaultPool;
            Value = DefaultPool.GetRawId(name);
        }
        
        public Id(IIdPool pool, string name)
        {
            _pool = pool;
            Value = pool.GetRawId(name);
        }
        
        public void ChangePool(IIdPool pool)
        {
            Value = pool.GetRawId(Name);
            _pool = pool;
        }
        
        public static implicit operator string(Id id) => id.Name;
        public static implicit operator Id(string name) => new Id(name);
        public static bool operator==(Id left, Id right) => left.Value == right.Value;
        public static bool operator!=(Id left, Id right) => left.Value != right.Value;
        public override string ToString() => Name;
        public override int GetHashCode() => Value;
        public override bool Equals(object other) => other is Id oid && Value == oid.Value;
        
        private IIdPool _pool;
    }
}