using Sprache;

namespace XScriptedObject
{
    /// <summary>
    /// This class represents a boolean argument of a function.
    /// </summary>
    public class Boolean : AArgument
    {
        /// <summary>
        /// Main parser for boolean.
        /// </summary>
        public static readonly Parser<AArgument> PARSER = 
                Parse.String("true").Return(new Boolean(true))
                .Or(Parse.String("false").Return(new Boolean(false)));

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
        public bool TypedValue
        {
            get;
            private set;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="pValue">The boolean value.</param>
        public Boolean(bool pValue)
        {
            this.TypedValue = pValue;
        }
    }
}
