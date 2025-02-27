using Godot;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace EventBus
{
    public partial class EventBusController : Node
    {
        enum AssemblyType
        {
            AssemblyCSharp,
            AssemblyCSharpEditor,
            AssemblyCSharpEditorFirstPass,
            AssemblyCSharpFirstPass
        }

        /// <summary>
        /// Maps the assembly name to the corresponding AssemblyType.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <returns>AssemblyType corresponding to the assembly name, null if no match.</returns>
        static AssemblyType? GetAssemblyType(string assemblyName)
        {
            return assemblyName switch
            {
                "Assembly-CSharp" => AssemblyType.AssemblyCSharp,
                "Assembly-CSharp-Editor" => AssemblyType.AssemblyCSharpEditor,
                "Assembly-CSharp-Editor-firstpass" => AssemblyType.AssemblyCSharpEditorFirstPass,
                "Assembly-CSharp-firstpass" => AssemblyType.AssemblyCSharpFirstPass,
                _ => null
            };
        }

        /// <summary>
        /// Method looks through a given assembly and adds types that fulfill a certain interface to the provided collection.
        /// </summary>
        /// <param name="assemblyTypes">Array of Type objects representing all the types in the assembly.</param>
        /// <param name="interfaceType">Type representing the interface to be checked against.</param>
        /// <param name="results">Collection of types where result should be added.</param>
        static void AddTypesFromAssembly(Type[] assemblyTypes, Type interfaceType, ICollection<Type> results)
        {
            if (assemblyTypes == null) return;
            for (int i = 0; i < assemblyTypes.Length; i++)
            {
                Type type = assemblyTypes[i];
                if (type != interfaceType && interfaceType.IsAssignableFrom(type))
                {
                    results.Add(type);
                }
            }
        }

        /// <summary>
        /// Gets all Types from all assemblies in the current AppDomain that implement the provided interface type.
        /// </summary>
        /// <param name="interfaceType">Interface type to get all the Types for.</param>
        /// <returns>List of Types implementing the provided interface type.</returns>    
        public static List<Type> GetTypes(Type interfaceType)
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            Dictionary<AssemblyType, Type[]> assemblyTypes = new Dictionary<AssemblyType, Type[]>();
            List<Type> types = new List<Type>();
            for (int i = 0; i < assemblies.Length; i++)
            {
                AssemblyType? assemblyType = GetAssemblyType(assemblies[i].GetName().Name);
                if (assemblyType != null)
                {
                    assemblyTypes.Add((AssemblyType)assemblyType, assemblies[i].GetTypes());
                }
            }

            assemblyTypes.TryGetValue(AssemblyType.AssemblyCSharp, out var assemblyCSharpTypes);
            AddTypesFromAssembly(assemblyCSharpTypes, interfaceType, types);

            assemblyTypes.TryGetValue(AssemblyType.AssemblyCSharpFirstPass, out var assemblyCSharpFirstPassTypes);
            AddTypesFromAssembly(assemblyCSharpFirstPassTypes, interfaceType, types);

            return types;
        }

        public static List<Type> EventBusTypes { get; set; } = new List<Type>();

        public override void _Ready()
        {
         //   GD.Print(GetTypes(typeof(EventBus<>)).Count);
        }

        public void add(Type eventType)
        {
            var typeDef = typeof(EventBus<>);
            EventBusTypes.Add(typeDef.MakeGenericType(eventType));
        }
    }
}
