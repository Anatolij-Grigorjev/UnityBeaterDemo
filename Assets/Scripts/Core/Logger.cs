using System;
using UnityEngine;

namespace BeaterDemo {
    public class Logger {

        /// <summary>
        /// Create a new logger configured for a specific identifier with a specific pattern.
        /// Default pattern is  "{0} - [{1}]: {2}".
        /// 
        /// At 0 current tiem is logged
        /// 
        /// At 1 identifier
        /// 
        /// At 2 - message itself
        /// 
        /// </summary>
        /// <param name="identifier">Logger identifier, ex class name</param>
        /// <param name="pattern">custom pattern, keeping in mind the order of the 3 logged components</param>
        /// <returns></returns>
        public static Logger getInstance (string identifier, string pattern = "{0} - [{1}]: {2}") {

            return new Logger (identifier, pattern);
        }

        private string identifier;
        private string pattern;
        private DateTime createdAt;

        private String FormatMessage (object msg) {
            return String.Format (pattern, DateTime.Now, identifier, msg);
        }

        private Logger (string identifier, string pattern) {
            this.identifier = identifier;
            this.pattern = pattern;
            this.createdAt = DateTime.Now;
        }

        public void Info (object msg) {
            Debug.Log (FormatMessage (msg));
        }

        public void Error (Exception ex) {
            Error (ex.ToString ());
        }

        public void Error (object msg) {
            Debug.LogError (FormatMessage (msg));
        }

        public override string ToString () {

            return String.Format (
                "Logger for {0} created at {1} with pattern {2}",
                identifier,
                createdAt,
                pattern
            );
        }
    }
}