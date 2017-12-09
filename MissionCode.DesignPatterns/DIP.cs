namespace MissionCode.DesignPatterns.SOLID
{
    // Dependency Inversion Principle
    //High-level modules should not depend on low-level modules. Both should depend on abstractions.
    //Abstractions should not depend upon details.Details should depend upon abstractions.
    public class Worker
    {
        //violates the dependency inversion principle.
        //i.e. the high level module 'Worker' depends on FileLoger which is a concrete class and not an abstraction.
        FileLoger loger = new FileLoger();

        public void Run()
        {
            // Run Logic goes here
            loger.Log("Log data");
        }
    }

    public class FileLoger
    {
        public void Log(string data)
        {
            // Log data to a file
        }
    }

    //Handle the dependency inversion principle.

    // ILoger is an abtraction that the higher levels(WorkerDI) will depend on.
    public interface ILoger
    {
        void Log(string data);
    }

    public class FileLogerDI : ILoger
    {
        public void Log(string data)
        {
            // Log data to a file
        }
    }

    public class DbLogerDI : ILoger
    {
        public void Log(string data)
        {
            // Log data to a database
        }
    }

    public class WorkerDI
    {
        ILoger loger;

        // Dependency Injection
        // Dependency injection can be done in three ways.

        // 1.Constructor injection
        // 2.Method injection
        // 3.Property injection
        public WorkerDI(ILoger loger)
        {
            this.loger = loger;
        }

        public void Run()
        {
            // Run Logic goes here
            loger.Log("Log data");
        }
    }
}