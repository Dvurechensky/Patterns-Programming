﻿/*  Приспособленец
    Благодаря совместному использованию,
    поддерживает эффективную работу 
    с большим количеством объектов.
    (для оптимизации работы с памятью)
 */

using System.Collections;

class Program
{
    static void Main()
    {
        double longtitude = 22.33;
        double latitude = 55.11;

        HouseFactory houseFactory = new HouseFactory();
        for (int i = 0; i < 10; i++)
        {
            House panelH = houseFactory.GetHouse("Panel");
            if(panelH != null)
                panelH.Build(longtitude, latitude);
            longtitude += 0.1;
            latitude += 0.1;
        }

        for (int i = 0; i < 10; i++)
        {
            House officeH = houseFactory.GetHouse("Office");
            if (officeH != null)
                officeH.Build(longtitude, latitude);
            longtitude += 0.1;
            latitude += 0.1;
        }

        Console.Read();
    }
}

abstract class House
{
    protected int stages; // кол-во этажей - внутреннее состояние

    public abstract void Build(double latitude, double longitude); // внешнее состояние
}

class PanelHouse : House
{
    public PanelHouse()
    {
        stages = 5;
    }

    public override void Build(double latitude, double longitude)
    {
        Console.WriteLine($"PanelHouse Build stages-{stages} {latitude}, {longitude}");
    }
}

class OfficeHouse : House
{
    public OfficeHouse()
    {
        stages = 50;
    }

    public override void Build(double latitude, double longitude)
    {
        Console.WriteLine($"OfficeHouse Build stages-{stages} {latitude}, {longitude}");
    }
}

class HouseFactory
{
    Dictionary<string, House> houses = new Dictionary<string, House>();
    
    public HouseFactory()
    {
        houses.Add("Panel", new PanelHouse());
        houses.Add("Office", new OfficeHouse());
    }

    public House GetHouse(string key)
    {
        if (houses.ContainsKey(key))
            return houses[key];
        else
            return null;
    }
}