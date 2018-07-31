using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Sprache;

namespace XScriptedObject
{
    /// <summary>
    /// This class is responsible to create all objects of the script.
    /// </summary>
    public class ObjectFactory
    {
        /// <summary>
        /// This field stores all registered objects.
        /// </summary>
        private readonly Dictionary<string, Type> mRegisteredTypes = new Dictionary<string, Type>();
        
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ObjectFactory()
        {
        }

        /// <summary>
        /// This method parses a string and returns all created objects.
        /// </summary>
        /// <param name="pScript"></param>
        /// <returns></returns>
        public List<object> Parse(string pScript)
        {
            List<object> lResult = new List<object>();
            var lParseResult = Script.PARSER.TryParse(pScript);
            if (lParseResult.WasSuccessful)
            {
                foreach (var lFunction in lParseResult.Value.Functions)
                {
                    if (this.mRegisteredTypes.ContainsKey(lFunction.Identifier))
                    {
                        Type lType = this.mRegisteredTypes[lFunction.Identifier];
                        IEnumerable<ConstructorInfo> lConstructors = lType.GetConstructors().Where(pConstructor => pConstructor.GetParameters().Length == lFunction.Arguments.Count());
                        if (lConstructors.Any())
                        {
                            ConstructorInfo lToUse = null;
                            // Look for the first with best match.
                            foreach (var lConstructor in lConstructors)
                            {
                                if (lToUse == null)
                                {
                                    lToUse = lConstructor;
                                }
                                int lIdx = 0;
                                foreach (var lParameterInfo in lConstructor.GetParameters())
                                {
                                    if (lParameterInfo.ParameterType != lFunction.Arguments.ElementAt(lIdx).Value.GetType())
                                    {

                                        if (lToUse != null && lToUse == lConstructor)
                                        {
                                            lToUse = null;
                                        }
                                    }

                                    lIdx++;
                                }
                            }

                            if (lToUse != null)
                            {
                                lResult.Add(lToUse.Invoke(lFunction.GetParameters()));
                            }

                        }

                    }
                    else
                    {
                        // Manage error.
                    }
                }
            }
            else
            {
                // Manage error.
            }

            return lResult;
        }

        /// <summary>
        /// Register a type to build from a script.
        /// </summary>
        /// <param name="pAlias">The alias of the type (function identifier)</param>
        /// <param name="pType">The type to register</param>
        /// <returns></returns>
        public bool RegisterType(string pAlias, Type pType)
        {
            if (this.mRegisteredTypes.ContainsKey(pAlias) == false)
            {
                this.mRegisteredTypes.Add(pAlias, pType);
                return true;
            }
            return false;
        }


    }
}
