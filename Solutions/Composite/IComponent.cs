namespace Composite
{
    /** Define the Component interface 
     * (partial for a folder hierarchy) */
    interface IComponent
    {
        string Name { get; set; }

        void AddComponent(IComponent child);
        int Size();
        void Print(int tapped);
        void Delete();
    }

    /** Define a (partial) folder abstraction */
}