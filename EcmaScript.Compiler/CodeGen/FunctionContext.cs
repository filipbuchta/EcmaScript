using EcmaScript.IL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.CodeGen
{
    public class FunctionContext
    {
        public FunctionDefinition Definition;
        public ILGenerator Generator;

        public FunctionContext(FunctionDefinition definition)
        {
            this.Definition = definition;
            Generator = new ILGenerator(Definition.Body.Code);
        }
    }
}
