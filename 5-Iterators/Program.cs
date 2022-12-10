namespace Iterators
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The runnable entrypoint of the exercise.
    /// </summary>
    public class Program
    {
        /// <inheritdoc cref="Program" />
        public static void Main()
        {
            const int len = 50;
            int?[] numbers = new int?[len];
            Random rand = new Random();
            for (int i = 0; i < len; i++)
            {
                if (rand.NextDouble() > 0.2)
                {
                    numbers[i] = rand.Next(len);
                }
            }

            // Console.WriteLine("exemple");
            // new int[] {2, 4, 6, 3}
            //     .SkipSome(2)
            //     .ForEach(num => Console.Write(num.ToString() + ","));
            // Console.WriteLine();
            // Console.WriteLine();

            Console.WriteLine("SkipSome(1)");
            numbers
                .SkipSome(1)
                .ForEach(num => Console.Write(num.ToString() + ","));
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("TakeSome(" + (len - 2) + ")");
            numbers
                .TakeSome(len - 2)
                .ForEach(num => Console.Write(num.ToString() + ","));
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("SkipSome(1) + TakeSome(" + (len - 2) + ")");
            numbers
                .SkipSome(1)
                .TakeSome(len - 2)
                .ForEach(num => Console.Write(num.ToString() + ","));
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("SkipSome(1) + TakeSome(" + (len - 2) + ") + Filtered");
            numbers
                .SkipSome(1)
                .TakeSome(len - 2)
                .Filter(optN => optN.HasValue)
                .Map(optN => optN.Value)
                .ForEach(num => Console.Write(num.ToString() + ","));
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Actions:");
            IDictionary<int, int> occurrences = numbers
                .Map(optN => {
                    Console.Write(optN.ToString() + ",");
                    return optN;
                })
                .SkipSome(1)
                .TakeSome(len - 2)
                .Filter(optN => optN.HasValue)
                .Map(optN => optN.Value)
                .Reduce(new Dictionary<int, int>(), (d, n) => {
                    if (!d.ContainsKey(n))
                    {
                        d[n] = 1;
                    }
                    else
                    {
                        d[n]++;
                    }

                    return d;
            });

            Console.WriteLine();
            Console.WriteLine();

            long count = 0;
            foreach (KeyValuePair<int, int> kv in occurrences)
            {
                count += kv.Value;
                Console.WriteLine(kv);
            }
            Console.WriteLine();
            Console.WriteLine("Total counted = " + count + " of " + len);
        }
    }
}
