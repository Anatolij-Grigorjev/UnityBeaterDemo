using System;
using System.Collections;

namespace BeaterDemo.Input
{
    
    public interface IInputSource<T> where T: InputEvent
    {
        /// <summary>
        /// Generate input events from underlying event source.
        /// Generated events are placed into the provided array of InputEvent objects
        /// </summary>
        /// <param name="InputEvent[]">The InputEvent objects array to put gathered events into.
        /// This array is not resized if there are too many events to put into it</param>
        /// <returns>The actual number of events newly placed into the array</returns>
        int GetInputEvents(ref T[] inputEvents);
    }

}