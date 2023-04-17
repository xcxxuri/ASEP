using System;
namespace ConsoleToWeb.SOLID
{
    // SOLID OCP:   Open Closed Principle
    //  A class should be open for extension, but closed for modification.
    //  We should be able to add new functionality without changing the existing code.

    //  we can use upcasting to create an object of a interface that allows different functionality
    // By doing so we are opening for extension by creating new child objects that can be put inside a parent class
    public class OCP
    {
        Car car = new Car();
        Car sudan = new Sudan();
        Car v8Car = new V8Car();

    }

    // an example of OCP, we can create new cars without changing the code of the Car class
    // we can also create new engines without changing the code of the Car class
    public class Car
    {
        public virtual void Engine()
        {
            Console.WriteLine("VRMM");
        }
    }

    public class Sudan : Car
    {
        public override void Engine()
        {
            Console.WriteLine("VRMM VRMM");
        }

    }


    public class V8Car : Car
    {
        public override void Engine()
        {
            Console.WriteLine("VRMM VRMM VRMM");
        }
    }



}

