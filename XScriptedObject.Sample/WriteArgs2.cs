using System;
using System.Collections.Generic;

namespace XScriptedObject.Sample
{
    /// <summary>
    /// An object with 4 mixed arguments.
    /// </summary>
    public class WriteArgs2 : IExecutable
    {
        /// <summary>
        /// This field stores the constructor parameters.
        /// </summary>
        private List<object> mParameters = new List<object>();

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="pP1">The first argument</param>
        /// <param name="pP2">The second argument.</param>
        public WriteArgs2(bool pP1, bool pP2)
        {
            this.mParameters.Add(pP1);
            this.mParameters.Add(pP2);
        }

        /// <summary>
        /// Executes the object.
        /// </summary>
        public void Execute()
        {
            foreach (var lParameter in this.mParameters)
            {
                Console.Write(lParameter);
                Console.Write(" ");
            }
        }
    }
}
