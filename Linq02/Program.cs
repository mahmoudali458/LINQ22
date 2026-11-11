using LINQ.Models;

namespace Linq02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q1
            var result = ProductList.OrderByDescending(p => p.UnitPrice)
                .Take(3);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region Q2
            var result = ProductList.Skip(5).Take(5);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region Q3
            var result = ProductList.OrderBy(p => p.UnitPrice)
                .TakeWhile(p => p.UnitPrice < 25);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region Q4
            var result = ProductList.Where(p => p.Category == "Seafood")
                .All(p => p.UnitsInStock > 0);
            Console.WriteLine(result);
            #endregion

            #region Q5
            int[] ids = { 3, 9, 13, 18 };
            var result = ids.Any(i => i == 9);
            Console.WriteLine(result);
            #endregion

            #region Q6
            var result = ProductList.GroupBy(p => p.Category);
            foreach (var item in result)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Count());
            }
            #endregion

            #region Q7
            var result = ProductList.GroupBy(p => p.Category);
            foreach (var group in result)
            {
                Console.WriteLine(group.Key);
                Console.WriteLine("***********************************");
                foreach (var item in group)
                {
                    Console.WriteLine(item.ProductName);
                    Console.WriteLine("--------------------------------");
                }

            }
            #endregion

            #region Q8
            var result = ProductList.GroupBy(p => p.Category).Where(g => g.Count() > 3).
                Select(g => new { CategoryName = g.Key, count = g.Count() });
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            #endregion

            #region Q9
            var result = from c in CustomerList
                         group c by c.Country
                          into Group
                         select new
                         {
                             Country = Group.Key,
                             Countt = Group.Count()
                         };
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            #endregion

            #region Q10
            var result = ProductList.Sum(p => p.UnitsInStock);

            Console.WriteLine(result);
            #endregion

            #region Q11
            var result = ProductList.MaxBy(p => p.UnitPrice);
            Console.WriteLine($"max product price: {result}");

            var results = ProductList.MinBy(p => p.UnitPrice);
            Console.WriteLine($"min product price: {results}");
            #endregion

            #region Q12
            var result = ProductList.DistinctBy(p => p.Category);
            foreach (var item in result)
            {
                Console.WriteLine(item.Category);
            }
            #endregion

            #region Q13
            int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
            int[] setB = { 3, 6, 9, 12, 15, 13 };
            var result = setA.Except(setB);
            foreach (int i in result)
            {
                Console.WriteLine(i);
            }
            #endregion

            #region Q14
            string[] list1 = { "Germany", "France", "UK", "Spain" };
            string[] list2 = { "france", "SPAIN", "Italy" };

            var result = list1.Except(list2, StringComparer.OrdinalIgnoreCase
);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region Q15
            Dictionary<int, Product> ProductDic = ProductList.ToDictionary(p => p.ProductID);
            var result = ProductDic[18];
            Console.WriteLine(result);
            #endregion

            #region Q16
            var result = ProductList.First(p => p.UnitPrice > 50);
            Console.WriteLine(result);
            #endregion

            #region Q17
            var result = ProductList.FirstOrDefault(p => p.UnitPrice > 500);
            Console.WriteLine(result);
            #endregion

            #region Q18
            var result = Enumerable.Range(1, 10);
            foreach (var item in result)
            {
                Console.WriteLine($"7 x {item} = {7 * item}");
            }
            #endregion

            #region Q19
            var result = Enumerable.Range(1, 30);
            foreach (var item in result)
            {
                if (item % 2 == 0)
                    Console.WriteLine(item);
            }
            #endregion

            #region Q20
            var result = ProductList.Take(3).Select(p => p.ProductName)
                .Concat(CustomerList.Take(3)
                .Select(c => c.CustomerName));
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region Q21
            var result = ProductList.Zip(CustomerList, (p, c) => $"[{p.ProductName}] sold to => {c.CustomerName}");

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            #endregion

        }
    }
}
