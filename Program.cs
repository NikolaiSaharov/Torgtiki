using System;
using System.Collections.Generic;
using System.IO;

public class CakeOrder
{
    private string form;
    private string size;
    private string flavor;
    private int quantity;
    private string glaze;
    private string decoration;
    private decimal totalPrice;

    public void PlaceOrder()
    {
        Console.WriteLine("ЗАКАЗИКИ!");
        do
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("Главное Меню:");
            Console.WriteLine("1. Выберите форму");
            Console.WriteLine("2. Выберите размер");
            Console.WriteLine("3. Выберите вкус");
            Console.WriteLine("4. Выберите глазурь");
            Console.WriteLine("5. Выберите украшения");
            Console.WriteLine("6. Сохранить заказ");
            Console.WriteLine("7. Выйти");
            int choice = ReadChoice(8);
            Console.WriteLine();
            switch (choice)
            {
                case 1:
                    form = ShowSubMenu("Выберите форму", new List<string> { "Круг - 100", "Квадрат - 120", "Сердце - 130" });
                    break;
                case 2:
                    size = ShowSubMenu("Выберите размер", new List<string> { "Маленький - 50", "Средний - 70", "Большой - 100" });
                    break;
                case 3:
                    flavor = ShowSubMenu("Выберите вкус", new List<string> { "Шоколадный - 20", "Ванильный - 15", "Фруктовый - 25" });
                    break;
                
                case 4:
                    glaze = ShowSubMenu("Выберите глазурь", new List<string> { "Шоколадная - 10", "Кремовая - 15", "Фруктовая - 12" });
                    break;
                case 5:
                    decoration = ShowSubMenu("Выберите украшения", new List<string> { "Спиральки - 8", "Чоколате крошка - 5", "Фрукты - 10" });
                    break;
                case 6:
                    SaveOrder();
                    break;
                case 7:
                    return;
            }
        } while (true);
    }

    private void SaveOrder()
    {
        Console.Clear();
        Console.WriteLine("Сохранение заказа...");
        Console.WriteLine("------------------------");
        Console.WriteLine($"Форма: {form}");
        Console.WriteLine($"Размер: {size}");
        Console.WriteLine($"Вкус: {flavor}");
        Console.WriteLine($"Глазурь: {glaze}");
        Console.WriteLine($"Украшения: {decoration}");


        decimal price = CalculatePrice();

        Console.WriteLine("------------------------");
        Console.WriteLine($"Общая стоимость: {price} руб.");
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string filePath = Path.Combine(desktopPath, "История заказов.txt");

        string confirmation = GetStringInput("Введите 'да', чтобы подтвердить заказ, или 'нет', чтобы отменить: ");
        if (confirmation.ToLower() == "да")
        {
            
            Console.WriteLine("Заказ сохранен!");
            
        }
        else
        {
            Console.WriteLine("Заказ отменен.");
        }
        Console.WriteLine("------------------------");
        Console.WriteLine();
    }

    private decimal CalculatePrice()
    {
        decimal price = 0;
        
        switch (form)
        {
            case "Круг - 100":
                price += 100;
                break;
            case "Квадрат - 120":
                price += 120;
                break;
            case "Сердце - 130":
                price += 130;
                break;
        }
        
        switch (size)
        {
            case "Маленький - 50":
                price += 50;
                break;
            case "Средний - 70":
                price += 70;
                break;
            case "Большой - 100":
                price += 100;
                break;
        }
        
        switch (flavor)
        {
            case "Шоколадный - 20":
                price += 20;
                break;
            case "Ванильный - 15":
                price += 15;
                break;
            case "Фруктовый - 25":
                price += 25;
                break;
        }
        
        price += quantity * 10;
        
        switch (glaze)
        {
            case "Шоколадная - 10":
                price += 10;
                break;
            case "Кремовая - 15":
                price += 15;
                break;
            case "Фруктовая - 12":
                price += 12;
                break;
        }
        
        switch (decoration)
        {
            case "Спиральки - 8":
                price += 8;
                break;
            case "Чоколате крошка - 5":
                price += 5;
                break;
            case "Фрукты - 10":
                price += 10;
                break;
        }

        return price;
    }

    private int ReadChoice(int maxChoice)
    {
        int choice;
        do
        {
            Console.Write("Введите номер выбранного пункта: ");
        } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > maxChoice);
        return choice;
    }

    private string ShowSubMenu(string title, List<string> options)
    {
        Console.Clear();
        Console.WriteLine(title + "\n");
        for (int i = 0; i < options.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {options[i]}");
        }
        int selectedOption = ReadChoice(options.Count);
        return options[selectedOption - 1];
    }

    

    private string GetStringInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        CakeOrder cakeOrder = new CakeOrder();
        cakeOrder.PlaceOrder();
    }
}