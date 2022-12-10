namespace Indexers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <inheritdoc cref="IMap2D{TKey1,TKey2,TValue}" />
    public class Map2D<TKey1, TKey2, TValue> : IMap2D<TKey1, TKey2, TValue>
    {
        private readonly Dictionary<Tuple<TKey1, TKey2>, TValue> map = new Dictionary<Tuple<TKey1, TKey2>, TValue>();

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.NumberOfElements" />
        public int NumberOfElements => map.Count;

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.this" />
        public TValue this[TKey1 key1, TKey2 key2]
        {
            get => map[Tuple.Create(key1, key2)];
            set => map[Tuple.Create(key1, key2)] = value;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetRow(TKey1)" />
        public IList<Tuple<TKey2, TValue>> GetRow(TKey1 key1) => map.Where(_ => _.Key.Item1.Equals(key1)).Select(_ => Tuple.Create(_.Key.Item2, _.Value)).ToArray();

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetColumn(TKey2)" />
        public IList<Tuple<TKey1, TValue>> GetColumn(TKey2 key2) => map.Where(_ => _.Key.Item2.Equals(key2)).Select(_ => Tuple.Create(_.Key.Item1, _.Value)).ToArray();

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetElements" />
        public IList<Tuple<TKey1, TKey2, TValue>> GetElements() => map.Select(_ => Tuple.Create(_.Key.Item1, _.Key.Item2, _.Value)).ToArray();

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.Fill(IEnumerable{TKey1}, IEnumerable{TKey2}, Func{TKey1, TKey2, TValue})" />
        public void Fill(IEnumerable<TKey1> keys1, IEnumerable<TKey2> keys2, Func<TKey1, TKey2, TValue> generator)
        {
            foreach (var k1 in keys1)
            {
                foreach (var k2 in keys2) this[k1, k2] = generator(k1, k2);
            }
        }

        /// <inheritdoc cref="IEquatable{T}.Equals(T)" />
        public bool Equals(IMap2D<TKey1, TKey2, TValue> other) => GetElements().Equals(other.GetElements()); // Non riesco a capire perchè non mi accetta map.Equals(other.map);

        /// <inheritdoc cref="object.Equals(object?)" />
        public override bool Equals(object obj) => obj is IMap2D<TKey1, TKey2, TValue> map && this.Equals(map);

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode() => map.GetHashCode();

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.ToString"/>
        public override string ToString()
        {
            string result = String.Empty;
            long i = 1;
            foreach(var item in map)
            {
                result += String.Format("{0}. ({1}, {2}) -> {3};{4}", i++, item.Key.Item1, item.Key.Item2, item.Value, Environment.NewLine);
            }
            return result;
        }
    }
}
