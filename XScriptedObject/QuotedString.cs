using Sprache;

namespace XScriptedObject
{
    /// <summary>
    /// This class represents a string argument of a function.
    /// </summary>
    public class QuotedString : AArgument
    {
        /// <summary>
        /// Main parser for quoted string.
        /// </summary>
        public static readonly Parser<AArgument> PARSER = 
                from open in Parse.Char('"')
                from content in Parse.CharExcept('"').Many().Text()
                from close in Parse.Char('"')
                select new QuotedString(content);

        /// <summary>
        /// Gets the value as an object.
        /// </summary>
        public override object Value
        {
            get { return this.TypedValue; }
        }

        /// <summary>
        /// Gets the typed value.
        /// </summary>
        public string TypedValue
        {
            get;
            private set;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="pValue">The string.</param>
        public QuotedString(string pValue)
        {
            this.TypedValue = pValue;
        }
    }
}
