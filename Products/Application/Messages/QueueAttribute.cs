using System;

namespace Avanade.eShop.Application.Messages
{
    /// <summary>
    /// Attribute used to mark a message to be destined 
    /// to a particular queue.
    /// </summary>
    public class QueueAttribute : Attribute
    {
        public QueueAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
