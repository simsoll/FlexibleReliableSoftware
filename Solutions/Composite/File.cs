using System;

namespace Composite
{
    /** Define a (partial) file abstraction. */
    class File : IComponent
    {
        private readonly int _size;

        public File(string name, int size)
        {
            Name = name;
            _size = size;
        }

        public string Name { get; set; }

        public void AddComponent(IComponent child)
        {
            // no-operation, does not make sense.
        }

        public int Size()
        {
            return _size;
        }

        public void Print(int tapped)
        {
            var tap = new string('\t', tapped);
            Console.WriteLine(tap + Name + " *");
        }

        public void Delete()
        {
            
        }
    }
}