using System;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Core.Utilities.Helpers;
using System.Dynamic;
using DataAccess.Abstract;

namespace ConsoleUI {
    class Program {
        static void Main(string[] args) {
            IDynamicService dynamicManager = new DynamicManager(new InMemoryDynamicDal());

            dynamic dynamicObject = new Dynamic();
            dynamic dynamicObject2 = new Dynamic();
            dynamic dynamicObject3 = new Dynamic();

            dynamicObject.Id = "A";
            dynamicObject2.Id = "B";
            dynamicObject3.Id = "C";

            var a = dynamicManager.Add(dynamicObject, new List<string>() { "Id", "UniqueKey" });
            var b = dynamicManager.Add(dynamicObject2, new List<string>() { "Id", "UniqueKey" });
            var c = dynamicManager.Add(dynamicObject3, new List<string>() { "Id", "UniqueKey" });

            Console.WriteLine(dynamicManager.GetByUniqueKey(a));
            Console.WriteLine(dynamicManager.GetByUniqueKey(b));
            Console.WriteLine(dynamicManager.GetByUniqueKey(c));

            dynamic myDynamicObject = new Dynamic();

            while (true) {
                Console.WriteLine("1: add new object");
                Console.WriteLine("2: lookup the object by Unique Key");
                Console.WriteLine("0: list all and exit the program");
                var input = Console.ReadLine();
                var addingObjectProperties = true;
                List<string> properties = new List<string>() {  };
                List<string> values = new List<string>() {  };
                string propertyName;
                string val;
                switch (input) {
                    case "0":
                        foreach (var item in dynamicManager.GetAll()) {
                            Console.WriteLine(item);   
                        }
                        Environment.Exit(0);
                        break;

                    case "1":
                        Console.WriteLine("Adding new object...");
                        while (addingObjectProperties) {
                            Console.Write("Type property name for the object: ");
                            propertyName = Console.ReadLine();
                            properties.Add(propertyName);
                            Console.Write($"Type value for the property {propertyName}: ");
                            val = Console.ReadLine();
                            values.Add(val);
                            Console.Write("Do you wanna add more properties? (Y/n): ");
                            var addAnotherProperty = Console.ReadLine().ToLower();
                            Console.WriteLine(addAnotherProperty);
                            if (addAnotherProperty.Contains("n"))
                                addingObjectProperties = false;
                                continue;
                        }
                        if (properties.Count > 0) {
                            for (int i = 0; i < properties.Count; ++i) {
                                myDynamicObject[properties[i]] = values[i];
                            }
                            properties.Add("UniqueKey");
                            Console.WriteLine(dynamicManager.Add(myDynamicObject, properties));
                            Console.WriteLine();
                        }
                        break;

                    case "2":
                        Console.Write("Type the Unique Key for Look up: ");
                        var lookUp = Console.ReadLine();
                        Console.WriteLine(dynamicManager.GetByUniqueKey(lookUp));
                        Console.WriteLine();
                        break;

                    default:
                        Console.WriteLine("invalid");
                        Console.WriteLine();
                        break;
                }
            }


            //IBookService bookManager = new BookManager(new InMemoryBookDal());

            //var books = new List<Book>();
            //books.Add(new Book { BookId = 1, BookName = "Book1", BookAuthorName = "Author1" });
            //books.Add(new Book { BookId = 2, BookName = "Book2", BookAuthorName = "Author2" });
            //books.Add(new Book { BookId = 3, BookName = "Book3", BookAuthorName = "Author3" });
            //books.Add(new Book { BookId = 4, BookName = "Book4", BookAuthorName = "Author4" });

            //var bookUniqueKeys = new List<string>();
            //foreach (var book in books)
            //{
                //bookUniqueKeys.Add(bookManager.Add(book));
            //}

            //foreach (var uniqueKey in bookUniqueKeys) {
                //var book = bookManager.GetByUniqueKey(uniqueKey);
                //Console.WriteLine($"Book Id: {book.BookId}\n" +
                        //$"Book Name: {book.BookName}\n" +
                        //$"Author Name: {book.BookAuthorName}\n" +
                        //$"Unique Key: {book.BookUniqueKey}");
                //Console.WriteLine("\n=====================\n");
            //}
        }
    }
}
