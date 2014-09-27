namespace Proxy
{
    /** This interface is the Subject role: here an Image. 
     * No real functionality is provided, only the ideas.
     */
    interface IImage
    {
        void Load(string filename);
        
        /** show the image (here return a description string) */
        string Show();
    }
}