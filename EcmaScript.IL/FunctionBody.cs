using System.Collections.Generic;
using System.IO;

namespace EcmaScript.IL
{
    public class FunctionBody
    {
        public List<LocalVariableDefinition> Locals = new List<LocalVariableDefinition>();
        public MemoryStream Code = new MemoryStream();
    }
}