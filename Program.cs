using System;
using System.Collections.Generic;

public interface IComponent
{
    double GetPrice();
}

public class Product : IComponent
{
    private string name;
    private double price;

    public Product(string name, double price)
    {
        this.name = name;
        this.price = price;
    }

    public double GetPrice()
    {
        return price;
    }
}

public class Box : IComponent
{
    private List<IComponent> components = new List<IComponent>();

    public void AddComponent(IComponent component)
    {
        components.Add(component);
    }

    public double GetPrice()
    {
        double totalPrice = 0;
        foreach (var component in components)
        {
            totalPrice += component.GetPrice();
        }
        return totalPrice;
    }
}
public class Order : IComponent
{
    private List<IComponent> components = new List<IComponent>();

    public void AddComponent(IComponent component)
    {
        components.Add(component);
    }

    public double GetPrice()
    {
        double totalPrice = 0;
        foreach (var component in components)
        {
            totalPrice += component.GetPrice();
        }
        return totalPrice;
    }
}

class Program
{
    static void Main()
    {
        //продукты в коробке
        Product laptop = new Product("Laptop", 1000);
        Product iphone = new Product("iPhone", 2500);
        Product phone = new Product("Xiaomi 13 pro max super puper top za svoi den'gi", 200);
        Product book = new Product("Book", 20);
        Product pen = new Product("Pen", 5);

        //коробка с гаджетами состоит из ноутбука и двух телефонов
        Box gadgetsBox = new Box();
        gadgetsBox.AddComponent(laptop);
        gadgetsBox.AddComponent(iphone);
        gadgetsBox.AddComponent(phone);
        
        //коробка с концелярией состоит из книжки и ручки
        Box stationeryBox = new Box();
        stationeryBox.AddComponent(book);
        stationeryBox.AddComponent(pen);

        //заказ состоит из 2х коробок + наушники
        Order order = new Order();
        order.AddComponent(gadgetsBox);
        order.AddComponent(stationeryBox);
        order.AddComponent(new Product("Headphones", 50));

        double totalPrice = order.GetPrice();
        Console.WriteLine($"Total Price of the Order: ${totalPrice}");

        Console.ReadLine();
    }
}


