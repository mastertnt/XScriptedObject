using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprache;

namespace XScriptedObject
{
    /// <summary>
    /// A function represents an object creator.
    /// A function has an id representing the object type.
    /// A function can have some parameters separated by comma (the parameters will be used for constructor parameters).
    /// </summary>
    public class Function
    {
        /// <summary>
        /// Parser for a list of argument (non-spaced, non-quoted).
        /// </summary>
        public static readonly Parser<AArgument> ARGUMENT_PARSER = Boolean.PARSER.Or(QuotedString.PARSER.Or(Real.PARSER.Or(Integer.PARSER)));

        /// <summary>
        /// Parser for an argument (non-spaced, non-quoted).
        /// </summary>
        public static readonly Parser<IEnumerable<AArgument>> ARGUMENT_PARSERS = ARGUMENT_PARSER.DelimitedBy(Sprache.Parse.Char(',').Token());

        /// <summary>
        /// Parser for an identifier (non-spaced, non-quoted).
        /// </summary>
        public static readonly Parser<string> IDENTIFIER_PARSER = 
            from lFirstLetter in Parse.Letter.Once()
            from lRest in Parse.LetterOrDigit.Many()
            select new string(lFirstLetter.Concat(lRest).ToArray());


        /// <summary>
        /// Parser for  a function with arguments.
        /// </summary>
        public static readonly Parser<Function> PARSER_WITH_ARGS =
            from lIdentifier in IDENTIFIER_PARSER
            from lOpenParenthesis in Sprache.Parse.Char('(')
            from lArguments in ARGUMENT_PARSERS
            from lCloseParenthesis in Sprache.Parse.Char(')')
            select new Function(lIdentifier, lArguments.ToArray());


        /// <summary>
        /// Parser for a function with no arguments.
        /// </summary>
        public static readonly Parser<Function> PARSER_NO_ARGS =
            from lIdentifier in IDENTIFIER_PARSER
            from lOpenParenthesis in Sprache.Parse.Char('(')
            from lCloseParenthesis in Sprache.Parse.Char(')')
            select new Function(lIdentifier, null);

        /// <summary>
        /// Main parser.
        /// </summary>
        public static readonly Parser<Function> PARSER = PARSER_WITH_ARGS.Or(PARSER_NO_ARGS);

        /// <summary>
        /// Gets the identifier of a functions.
        /// </summary>
        public string Identifier
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the list of arguments.
        /// </summary>
        public IEnumerable<AArgument> Arguments
        {
            get;
            private set;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="pIdentifier">the idenfiier of the function.</param>
        /// <param name="pArguments">The arguments.</param>
        public Function(string pIdentifier, IEnumerable<AArgument> pArguments)
        {
            this.Identifier = pIdentifier;
            this.Arguments = pArguments;
        }

        /// <summary>
        /// Build a parameter array
        /// </summary>
        /// <returns>The parameter array.</returns>
        public object[] GetParameters()
        {
            object[] lParameters = new object[this.Arguments.Count()];
            int lIndex = 0;
            foreach (var lArgument in this.Arguments)
            {
                lParameters[lIndex] = lArgument.Value;
                lIndex++;
            }

            return lParameters;
        }
    }
}
