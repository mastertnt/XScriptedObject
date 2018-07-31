using System;
using System.Collections.Generic;
using System.Linq;

namespace XScriptedObject.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            const string cExample = "myFunction(42.34, false, 42, \"this is my world\");WriteArgs2(false,true);";
            ObjectFactory lFactory = new ObjectFactory();
            lFactory.RegisterType("myFunction", typeof(WriteArgs4));
            lFactory.RegisterType("WriteArgs2", typeof(WriteArgs2));
            IEnumerable<IExecutable> lCommands = lFactory.Parse(cExample).Cast<IExecutable>();
            foreach (var lCommand in lCommands)
            {
                lCommand.Execute();
                Console.WriteLine();
            }
        }
    }
}
