using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprache;

namespace XScriptedObject
{
    /// <summary>
    /// This class represents an argument of a function.
    /// </summary>
    public abstract class AArgument
    {
        /// <summary>
        /// Gets the value as an object.
        /// </summary>
        public abstract object Value { get; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        protected AArgument()
        {

        }
    }
}
