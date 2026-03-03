using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class Program
{
    static void Main()
    {
        var products = ListGenerators.Products;
        var customers = ListGenerators.Customers;

        string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

        // ================= Restriction =================
        var q1 = products.Where(p => p.UnitsInStock == 0);
        var q2 = products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3);
        var q3 = digits.Where((d, i) => d.Length < i);

        // ================= Element =================
        var e1 = products.First(p => p.UnitsInStock == 0);
        var e2 = products.FirstOrDefault(p => p.UnitPrice > 1000);
        var e3 = numbers.Where(n => n > 5).Skip(1).First();

        // ================= Aggregate =================
        var a1 = numbers.Count(n => n % 2 == 1);

        var a2 = customers.Select(c => new
        {
            c.CustomerName,
            OrdersCount = c.Orders.Count
        });

        var a3 = products.GroupBy(p => p.Category)
                         .Select(g => new { Category = g.Key, Count = g.Count() });

        var a4 = numbers.Sum();

        var dict = new[] { "apple", "banana", "cherry", "kiwi", "watermelon" };

        var a5 = dict.Sum(w => w.Length);

        var a6 = products.GroupBy(p => p.Category)
                         .Select(g => new { g.Key, TotalUnits = g.Sum(p => p.UnitsInStock) });

        var a7 = dict.Min(w => w.Length);

        var a8 = products.GroupBy(p => p.Category)
                         .Select(g => new { g.Key, MinPrice = g.Min(p => p.UnitPrice) });

        var a9 = from p in products
                 group p by p.Category into g
                 let min = g.Min(x => x.UnitPrice)
                 from p in g
                 where p.UnitPrice == min
                 select p;

        var a10 = dict.Max(w => w.Length);

        var a11 = products.GroupBy(p => p.Category)
                          .Select(g => new { g.Key, MaxPrice = g.Max(p => p.UnitPrice) });

        var a12 = products.GroupBy(p => p.Category)
                          .SelectMany(g => g.Where(p => p.UnitPrice == g.Max(x => x.UnitPrice)));

        var a13 = dict.Average(w => w.Length);

        var a14 = products.GroupBy(p => p.Category)
                          .Select(g => new { g.Key, AvgPrice = g.Average(p => p.UnitPrice) });

        // ================= Ordering =================
        var o1 = products.OrderBy(p => p.ProductName);

        var o2 = words.OrderBy(w => w, StringComparer.OrdinalIgnoreCase);

        var o3 = products.OrderByDescending(p => p.UnitsInStock);

        var o4 = digits.OrderBy(d => d.Length).ThenBy(d => d);

        var o5 = words.OrderBy(w => w.Length)
                      .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);

        var o6 = products.OrderBy(p => p.Category)
                         .ThenByDescending(p => p.UnitPrice);

        var o7 = words.OrderBy(w => w.Length)
                      .ThenByDescending(w => w, StringComparer.OrdinalIgnoreCase);

        var o8 = digits.Where(d => d.Length > 1 && d[1] == 'i')
                       .Reverse();

        // ================= Transformation =================
        var t1 = products.Select(p => p.ProductName);

        var t2 = new[] { "aPPLE", "BlUeBeRrY", "cHeRry" }
                 .Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower() });

        var t3 = products.Select(p => new
        {
            p.ProductName,
            p.Category,
            Price = p.UnitPrice
        });

        var t4 = numbers.Select((n, i) => new { Number = n, InPlace = n == i });

        int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
        int[] numbersB = { 1, 3, 5, 7, 8 };

        var t5 = from a in numbersA
                 from b in numbersB
                 where a < b
                 select new { a, b };

        var t6 = customers.SelectMany(c => c.Orders)
                          .Where(o => o.Total < 500);

        var t7 = customers.SelectMany(c => c.Orders)
                          .Where(o => o.OrderDate.Year >= 1998);

        // ================= Partitioning =================
        var p1 = customers.Where(c => c.Region == "WA")
                          .SelectMany(c => c.Orders)
                          .Take(3);

        var p2 = customers.Where(c => c.Region == "WA")
                          .SelectMany(c => c.Orders)
                          .Skip(2);

        var p3 = numbers.TakeWhile((n, i) => n >= i);

        var p4 = numbers.SkipWhile(n => n % 3 != 0);

        var p5 = numbers.SkipWhile((n, i) => n >= i);

        // ================= Quantifiers =================
        var qn1 = dict.Any(w => w.Contains("ei"));

        var qn2 = products.GroupBy(p => p.Category)
                          .Where(g => g.Any(p => p.UnitsInStock == 0));

        var qn3 = products.GroupBy(p => p.Category)
                          .Where(g => g.All(p => p.UnitsInStock > 0));
    }
}

public static class ListGenerators
{
    public static List<Product> Products = new List<Product>
    {
        new Product{ ProductName="Chai", Category="Beverages", UnitPrice=18, UnitsInStock=0 },
        new Product{ ProductName="Chang", Category="Beverages", UnitPrice=19, UnitsInStock=17 },
        new Product{ ProductName="Tofu", Category="Produce", UnitPrice=23, UnitsInStock=35 },
        new Product{ ProductName="Ikura", Category="Seafood", UnitPrice=31, UnitsInStock=0 },
        new Product{ ProductName="Pavlova", Category="Confections", UnitPrice=17, UnitsInStock=29 }
    };

    public static List<Customer> Customers = new List<Customer>
    {
        new Customer
        {
            CustomerName="Sara",
            Region="WA",
            Orders = new List<Order>
            {
                new Order{ OrderDate=new DateTime(1997,1,1), Total=200 },
                new Order{ OrderDate=new DateTime(1999,1,1), Total=800 },
                new Order{ OrderDate=new DateTime(2000,1,1), Total=150 }
            }
        }
    };
}

public class Product
{
    public string ProductName { get; set; }
    public string Category { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
}

public class Customer
{
    public string CustomerName { get; set; }
    public string Region { get; set; }
    public List<Order> Orders { get; set; }
}

public class Order
{
    public DateTime OrderDate { get; set; }
    public decimal Total { get; set; }
}