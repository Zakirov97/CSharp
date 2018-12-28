using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IntroToReflection
{
    static class ExtensionMethods
    {
        public static string ToCustomString(this Object obj)
        {
            StringBuilder stringBuilder = new StringBuilder();

            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (var item in properties)
            {
                string buffer = item.Name + " : " + item.GetValue(obj).ToString() + Environment.NewLine;
                stringBuilder.Append(buffer);
            }
            return stringBuilder.ToString();
        }
    }
    class SecuredData
    {
        public int HashCode { get; } = 1001;
        public override string ToString()
        {
            return this.ToCustomString();
        }
        public SecuredData()
        {
        }
    }

    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return this.ToCustomString();
        }
    }
    class CustomData : Object
    {
        public int Id;
        private string _securedId;
        public string DefaultName { get; set; }
        public string InstantiatedTime { get; set; }
        private static int InstanceCounter;
        private static int EpochCount;
        // public SecuredData SecuredPart { get; set; }

        public override string ToString()
        {
            return this.ToCustomString();
        }

        /// <summary>
        /// This method allows to set next epoch value for
        /// thread synchronyzation between calls.
        /// </summary>
        /// <param name="nextEpochValue"></param>
        public void TransformToNextEpoch(int nextEpochValue)
        {
            EpochCount = nextEpochValue;
            _securedId = Guid.NewGuid().ToString();
        }
        public int GetEpochCounter()
        {
            return EpochCount;
        }
        public CustomData()
        {
            InstanceCounter++;
            TransformToNextEpoch(InstanceCounter++);
            // SecuredPart = new SecuredData();
        }
        static CustomData()
        {
            EpochCount = 0;
            InstanceCounter = 0;
        }
    }

    // Early Binding vs. Late Binding
    class LateBinding
    {
        public void RunLateBinding(string pathToAssembly, string classFullName, string methodFullName)
        {
            Assembly externalAssembly = Assembly.LoadFile(pathToAssembly);
            Assembly [] allAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            Assembly targetAssembly = allAssemblies.First(p=>p.FullName == externalAssembly.FullName);

            Type lateBindedType = targetAssembly.GetTypes().First(p => p.FullName == classFullName);

            object createdInstance = Activator.CreateInstance(lateBindedType);
            MethodInfo targetMethod = lateBindedType.GetMethod(methodFullName);
            var result = targetMethod.Invoke(createdInstance, null);

            Console.WriteLine(result);

        }
    }
    class Program
    {
        static Predicate<MethodInfo> isReturnsIntegerValue = 
            (MethodInfo method) =>
            method.ReturnType == typeof(int) || 
            method.ReturnType == typeof(string);

        static void Main(string[] args)
        {
            /*
            Type customDataType = typeof(CustomData);

            MethodInfo [] methodsList = customDataType.GetMethods();

            IEnumerable<MethodInfo> filteredByType = methodsList
                .ToList()
                .FindAll(isReturnsIntegerValue);

            foreach (var item in filteredByType)
            {
                Console.WriteLine(item.Name);
            }
            */

            /*
            CustomData myCustomData = new CustomData()
            {
                DefaultName = "default",
                InstantiatedTime = DateTime.Now.ToString()
            };

            Type myCustomDataType = typeof(CustomData);
            FieldInfo[] privateFields = 
                myCustomDataType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var item in privateFields)
            {
                item.SetValue(myCustomData, "hacked");
                
                Console.WriteLine(item.Name + " " + item.GetValue(myCustomData));            
            }
            */
            // Person p = new Person() { Id = 100, Name = "Christine" };


            /*
            foreach (var item in methodsList)
            {
                Console.WriteLine("Method Info : ");
                Console.WriteLine($"{item.Name}");

                MethodImplAttributes implementationFlags = item.MethodImplementationFlags;

                Console.WriteLine(implementationFlags);

                ParameterInfo[] parametersList = item.GetParameters();
                foreach (var innerItem in parametersList)
                {
                    Console.WriteLine("Parameter Info : ");
                    Console.WriteLine($"{innerItem.Name} : {innerItem.ParameterType.Name }");
                }
                Console.WriteLine();
            }
            */

            LateBinding lateBinding = new LateBinding();
            lateBinding.RunLateBinding(@"C:\Users\РаимбаевИ.ITSTEP\AnotherLibrary.dll", "AnotherLibrary.AdvancedMath", "GetSomeValue");

            Console.ReadLine();
        }
    }
}
