namespace MuLinq
{
    public static class EnumerableExtentions
    {
        public static TSource[] Where<TSource>(this IEnumerable<TSource> source, Predicate<TSource> criterion)
        {

            if (source == null)
                throw new InvalidOperationException();

            var result = new List<TSource>();
            foreach (var item in source)
            {
                if (criterion?.Invoke(item) == true)
                    result.Add(item);
            }

            return result.ToArray();
        }
            public void First
            {

            }
    }
}