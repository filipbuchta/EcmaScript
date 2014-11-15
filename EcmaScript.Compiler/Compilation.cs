using System;
using System.Collections.Generic;
using EcmaScript.IL;

namespace EcmaScript
{
    public class Compilation
    {
        public static string MainFunction = "main";

        public FunctionDefinition Main;
        public List<FunctionDefinition> Functions = new List<FunctionDefinition>();
        public List<string> Strings = new List<string>();
        public AssemblySymbol Assembly;

        //public List<InterfaceDefinition> Interfaces = new List<InterfaceDefinition>();
        //public List<ClassDefinitions> Classes = new List<ClassDefinitions>();

        public int GetStringConstant(string str)
        {
            var index = Strings.IndexOf(str);
            if (index != -1)
            {
                return index;
            }

            Strings.Add(str);

            return Strings.Count - 1;
        }

        public void SetSyntaxTree(SyntaxTree syntaxTree)
        {
            throw new NotImplementedException();
        }
    }
}