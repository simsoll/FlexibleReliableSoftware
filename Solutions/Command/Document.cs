using System;
using System.Collections.Generic;
using System.Text;

namespace Command
{
    /** This class is a simple document, it acts as the
    * Receive role in the Command pattern
    */
    public class Document
    {
        private readonly IList<string> _contents = new List<string>();

        public void Write(string text)
        {
            _contents.Add(text);
        }
        public void Erase(string text)
        {
            _contents.Remove(text);
        }

        public override string ToString() {
            var result = new StringBuilder();

            foreach(var text in _contents) {
                result.AppendLine(text);
            }

            return result.ToString();
        }
    }
}