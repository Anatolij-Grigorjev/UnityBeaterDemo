namespace BeaterDemo.Input
{
    public abstract class CachedEventInputSource<T>: IInputSource<T> where T : InputEvent {

        protected Dictionary<string, T> eventsCache;

        public CachedEventInputSource(ref string[] sourceCommands) {

            eventsCache = new Dictionary<string, T>(sourceCommands.Length);

            foreach(string cmd in sourceCommands) {

                var freshTemplate = CreateTemplateValue(cmd);
                eventsCache.Add(cmd, freshTemplate)
            }

        }


        public int GetInputEvents(out T[] inputEvents) {
            boolean commandAddable = false;
            int nextEvent = 0;
            foreach(var kvp in eventsCache) {
                commandAddable = ProcessCommand(ref kvp.Value)

                if (commandAddable) {
                    kvp.Value.CopyTo(inputEvents[nextEvent]);
                    nextEvent++;
                }
            }

            return nextEvent;
        }

        protected virtual boolean ProcessCommand(ref T eventTemplate);
        protected virtual T CreateTemplateValue(string command);

    }
}