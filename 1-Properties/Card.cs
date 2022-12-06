namespace Properties
{
    using System;

    /// <summary>
    /// The class models a card.
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="name">the name of the card.</param>
        /// <param name="seed">the seed of the card.</param>
        /// <param name="ordinal">the ordinal number of the card.</param>
        public Card(string name, string seed, int ordinal)
        {
            this.Name = name;
            this.Ordinal = ordinal;
            this.Seed = seed;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="tuple">the informations about the card as a tuple.</param>
        internal Card(Tuple<string, string, int> tuple)
            : this(tuple.Item1, tuple.Item2, tuple.Item3)
        {
        }

        /// <summary>
        /// Gets the seed of the card.
        /// </summary>
        public string Seed { get; }

        /// <summary>
        /// Gets the name of the card.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the ordinal number of the card.
        /// </summary>
        public int Ordinal { get; }

        /// <inheritdoc cref="object.ToString"/>
        public override string ToString() => // TODO understand string interpolation
            $"{GetType().Name}(Name={Name}, Seed={Seed}, Ordinal={Ordinal})";

        /// <inheritdoc cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(Card other)
        {
            return string.Equals(Seed, other.Seed)
                   && string.Equals(Name, other.Name)
                   && Ordinal == other.Ordinal;
        }

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj) => obj is Card card && Equals(card);

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Seed, Name, Ordinal);
        }
    }
}
