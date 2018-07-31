using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprache;

namespace XScriptedObject
{
    /// <summary>
    /// A script is a set of functions separated by ";"
    /// </summary>
    public class Script
    {
        /// <summary>
        /// Retrieves a list of functions separated by ";"
        /// </summary>
        public static readonly Parser<IEnumerable<Function>> FUNCTION_PARSERS = Function.PARSER.DelimitedBy(Sprache.Parse.Char(';').Token());

        /// <summary>
        /// Main parser.
        /// </summary>
        public static readonly Parser<Script> PARSER = 
            from lFunctions in FUNCTION_PARSERS
            select new Script(lFunctions);

        /// <summary>
        /// Gets the list of functions.
        /// </summary>
        public IEnumerable<Function> Functions
        {
            get;
            private set;
        }

        /// <summary>
        /// Default constructor for a script.
        /// </summary>
        /// <param name="pFunctions">The list of functions</param>
        public Script(IEnumerable<Function> pFunctions)
        {
            this.Functions = pFunctions;
        }
    }
}
