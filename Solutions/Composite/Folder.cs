using System;
using System.Collections.Generic;
using System.Linq;

namespace Composite
{
    class Folder : IComponent
    {
        private IList<IComponent> _components = new List<IComponent>();

        public string Name { get; set; }

        public Folder(string name)
        {
            Name = name;
        }

        public void AddComponent(IComponent child)
        {
            _components.Add(child);
        }

        public int Size()
        {
            return _components.Sum(component => component.Size());
        }

        public void Print(int tapped)
        {
            var tap = new string('\t', tapped);
            Console.WriteLine(tap + Name);

            foreach (var component in _components)
            {
                component.Print(tapped + 1);
            }
        }

        public void Delete()
        {
            _components = new List<IComponent>();
        }
    }
}