using System;
using System.Linq;
using System.Reflection;
using System.Text;
namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldNames)
        {
            StringBuilder result = new();
            result.AppendLine($"Class under investigation: {className}");

            Type type = Type.GetType(className);
            FieldInfo[] fieldInfo = type.GetFields((BindingFlags)60);

            object classInstance = Activator.CreateInstance(type, new object[] { });

            foreach (FieldInfo field in fieldInfo.Where(f => fieldNames.Contains(f.Name)))
            {
                result.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return result.ToString().TrimEnd();
        }
        public string AnalyzeAccessModifiers(string className)
        {
            Type type = Type.GetType(className);
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] publicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] nonPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder result = new();

            foreach (FieldInfo fieldInfo in fields)
            {
                result.AppendLine($"{fieldInfo.Name} must be private!");
            }

            foreach (MethodInfo methodInfo in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                result.AppendLine($"{methodInfo.Name} have to be public!");
            }

            foreach (MethodInfo methodInfo in publicMethods.Where(m => m.Name.StartsWith("set")))
            {
                result.AppendLine($"{methodInfo.Name} have to be private!");
            }

            return result.ToString().TrimEnd();
        }
        public string RevealPrivateMethods(string className)
        {
            StringBuilder result = new();

            Type type = Type.GetType(className);
            MethodInfo[] privateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            result.AppendLine($"All Private Methods of Class: {className}");
            result.AppendLine($"Base class {type.BaseType.Name}");

            foreach (MethodInfo methodInfo in privateMethods)
            {
                result.AppendLine(methodInfo.Name);
            }

            return result.ToString().TrimEnd();
        }
        public string CollectGettersAndSetters(string className)
        {
            StringBuilder result = new();

            Type type = Type.GetType(className);
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (MethodInfo methodInfo in methods.Where(m => m.Name.StartsWith("get")))
            {
                result.AppendLine($"{methodInfo.Name} will return {methodInfo.ReturnType}");
            }

            foreach (MethodInfo methodInfo in methods.Where(m => m.Name.StartsWith("set")))
            {
                result.AppendLine($"{methodInfo.Name} will set field of {methodInfo.GetParameters().First().ParameterType}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
