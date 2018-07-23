using System;
using System.Collections;
using System.Collections.Generic;

namespace BeaterDemo.Input
{
    public abstract class CachedEventInputSource<T>: IInputSource<T> where T : InputEvent {

        protected Dictionary<string, T> eventsCache;
        public string[] sourceCommands;

        public CachedEventInputSource(ref string[] sourceCommands) {
            this.sourceCommands = sourceCommands;

            eventsCache = new Dictionary<string, T>(sourceCommands.Length);

            foreach(string cmd in sourceCommands) {

                var freshTemplate = CreateTemplateValue(cmd);
                eventsCache.Add(cmd, freshTemplate);
            }

        }


        public int GetInputEvents(ref T[] inputEvents) {
            bool commandAddable = false;
            int nextEvent = 0;
            foreach(string cmd in sourceCommands) {

                var eventTemplate = eventsCache[cmd];
                commandAddable = ProcessCommand(eventTemplate);

                if (commandAddable) {
                    eventTemplate.CopyTo(inputEvents[nextEvent]);
                    nextEvent++;
                }
            }

            return nextEvent;
        }

        public abstract bool ProcessCommand(T eventTemplate);
        public abstract T CreateTemplateValue(string command);

    }
}