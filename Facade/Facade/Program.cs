using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CarFacade facade = new CarFacade();
            facade.CreateCar();
            Console.ReadLine();
        }
    }
/// <summary>
/// Facade Design Pattern
/// </summary>
    class CarFacade
    {
        private readonly CarAccessories accessories;
        private readonly CarBody body;
        private readonly CarEngine engine;
        private readonly CarModel model;

        public CarFacade()
        {
            accessories = new CarAccessories();
            body = new CarBody();
            engine = new CarEngine();
            model = new CarModel();
        }

        public void CreateCar()
        {
            Console.WriteLine("--------Creating a car--------");
            model.SetCarModel();
            engine.SetCarEngine();
            body.SetCarBody();
            accessories.SetCarAccessories();
            Console.WriteLine("-------Car Creation done------");
        }
    }

    class CarModel
    {
        public void SetCarModel()
        {
            Console.WriteLine("Car Model :SetCarModel()");
        }
    }

    class CarBody
    {
        public void SetCarBody()
        {
            Console.WriteLine("Car Body :SetCarBody()");
        }
    }

    class CarAccessories
    {
        public void SetCarAccessories()
        {
            Console.WriteLine("Car Accessories :SetCarAccessories()");
        }
    }

    class CarEngine
    {
        public void SetCarEngine()
        {
            Console.WriteLine("Car Engine : SetCarEngine()");
        }
    }
}
