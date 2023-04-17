using System;
namespace ConsoleToWeb.SOLID
{
    public class ISP
    {
        // ISP:  Interface Segregation Principle
        // when there is an interface that has some properties that does not apply to some of the classes, use multiple interfaces to split up the interface into smaller ones. This allows for more flexibility


    }

    public interface IAutomobile { }

    public interface IEngine { }

    public interface IWheel { }
    public interface IWindshield { }
    // some Motorcycle may not have a windshield
    public class Motorcycle :  IEngine, IWheel {}

}

