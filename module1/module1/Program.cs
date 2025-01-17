﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_1
{

    public class Program
    {
        public static void Main()
        {

            Console.WriteLine("Product Management");
            

            var repository = new DictionaryRepository<int, Product>();
            while (true)
            {
                Console.WriteLine(" 1. Add\n 2. Get\n 3. Update\n 4. Delete\n 5. Show All\n 6. Exit");
                if (!int.TryParse(Console.ReadLine(), out int command))
                    continue;

                switch (command)
                {
                    case 1:
                        Console.Write("Enter Product ID: ");
                        if (int.TryParse(Console.ReadLine(), out int addId))
                        {
                            if (addId == 0)
                            {
                                Console.WriteLine("You entered 0, which is not allowed.");
                            }
                            else
                            {
                                Console.Write("Enter Product Name: ");
                                string addName = Console.ReadLine();
                                repository.Add(addId, new Product { ProductId = addId, ProductName = addName });
                                Console.WriteLine("Product added.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You entered a text or an invalid ID.");
                        }


                        break;

                    case 2:
                        Console.Write("Enter Product ID to retrieve: ");
                        int getId = int.Parse(Console.ReadLine());
                        try
                        {
                            Console.WriteLine(repository.Get(getId));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 3:
                        Console.Write("Enter Product ID to update: ");
                        int updateId = int.Parse(Console.ReadLine());
                        Console.Write("Enter new Product Name: ");
                        string updateName = Console.ReadLine();
                        try
                        {
                            repository.Update(updateId, new Product { ProductId = updateId, ProductName = updateName });
                            Console.WriteLine("Product updated.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 4:
                        Console.Write("Enter Product ID to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        try
                        {
                            repository.Delete(deleteId);
                            Console.WriteLine("Product deleted.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 5:
                        Console.WriteLine("All Products:");
                        foreach (var item in repository.GetAll())
                        {
                            Console.WriteLine($"ID: {item.Key}, Product Name: {item.Value}");
                        }
                        break;

                    case 6:
                        return;

                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
        }
    }



}
