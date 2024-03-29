using System;
using System.Collections.Generic;


public class Drukowanie
{
    public string Zawartosc { get; set; }

    public Drukowanie(string zawartosc)
    {
        Zawartosc = zawartosc;
    }
}


public class BuforDrukowania
{
    private static BuforDrukowania instance;
    private Queue<Drukowanie> KolejkaDrukowania;


    private BuforDrukowania()
    {
        KolejkaDrukowania = new Queue<Drukowanie>();
    }

    public Drukowanie Drukowanie
    {
        get => default;
        set
        {
        }
    }

    public static BuforDrukowania GetInstance()
    {
        if (instance == null)
        {
            instance = new BuforDrukowania();
        }
        return instance;
    }


    public void DodajZadanie(Drukowanie zadanie)
    {
        KolejkaDrukowania.Enqueue(zadanie);
    }


    public Drukowanie NastepneZadanie()
    {
        if (KolejkaDrukowania.Count > 0)
        {
            return KolejkaDrukowania.Dequeue();
        }
        else
        {
            return null; 
        }
    }


    public void WyswietlKolejke()
    {
        Console.WriteLine("Kolejka drukowania:");
        foreach (var zadanie in KolejkaDrukowania)
        {
            Console.WriteLine(zadanie.Zawartosc);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {

        BuforDrukowania NoweDrukowanie = BuforDrukowania.GetInstance();

        NoweDrukowanie.DodajZadanie(new Drukowanie("Zadanie 1"));
        NoweDrukowanie.DodajZadanie(new Drukowanie("Zadanie 2"));
        NoweDrukowanie.DodajZadanie(new Drukowanie("Zadadnie 3"));


        NoweDrukowanie.WyswietlKolejke();


        Console.WriteLine("Drukowanie zadania:");
        while (true)
        {
            Drukowanie zadanie = NoweDrukowanie.NastepneZadanie();
            if (zadanie != null)
            {
                Console.WriteLine("Drukowanie: " + zadanie.Zawartosc);
            }
            else
            {
                Console.WriteLine("Brak zadań do wydrukowania");
                break;
            }
        }
    }
}


