using System;
using System.Collections.Generic;

namespace XScriptedObject.Sample
{
    /// <summary>
    /// An object with 4 mixed arguments.
    /// </summary>
    public class WriteArgs4 : IExecutable
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
        /// <param name="pP3">The third argument.</param>
        /// <param name="pP4">The fourth argument.</param>
        public WriteArgs4(double pP1, bool pP2, int pP3, string pP4)
        {
            this.mParameters.Add(pP1);
            this.mParameters.Add(pP2);
            this.mParameters.Add(pP3);
            this.mParameters.Add(pP4);
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
