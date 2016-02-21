using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jukebox.Helpers
{
    // Class found at http://stackoverflow.com/a/23909882, posted by Dalstroem
    public class Messenger
    {
        private Dictionary<MessengerKey, object> _subscribers = new Dictionary<MessengerKey, object>();
        private static Messenger _instance;

        /// <summary>
        /// Registers a recipient for a type of message T. The action parameter will be executed
        /// when a corresponding message is sent.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="recipient"></param>
        /// <param name="action"></param>
        public void Register<T>(object recipient, Action<T> action)
        {
            Register(recipient, action, null);
        }

        /// <summary>
        /// Registers a recipient for a type of message T and a matching context. The action parameter will be executed
        /// when a corresponding message is sent.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="recipient"></param>
        /// <param name="action"></param>
        /// <param name="context"></param>
        public void Register<T>(object recipient, Action<T> action, object context)
        {
            var key = new MessengerKey(recipient, context);
            _subscribers.Add(key, action);
        }

        public void Unregister(object recipient)
        {
            Unregister(recipient, null);
        }

        public void Unregister(object recipient, object context)
        {
            var key = new MessengerKey(recipient, context);
            _subscribers.Remove(key);
        }

        public void Send<T>(T message)
        {
            Send(message, null);
        }

        public void Send<T>(T message, object context)
        {
            IEnumerable<KeyValuePair<MessengerKey, object>> result;

            if(context == null)
            {
                result = from r in _subscribers where r.Key.Context == null select r;
            }
            else
            {
                result = from r in _subscribers where r.Key.Context != null && r.Key.Context.Equals(context) select r;
            }

            foreach(var action in result.Select(x => x.Value).OfType<Action<T>>())
            {
                action(message);
            }
        }

        public static Messenger Default
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Messenger();
                }
                return _instance;
            }
        }

        protected class MessengerKey
        {
            public object Recipient { get; private set; }
            public object Context { get; private set; }

            /// <summary>
            /// Initializes a new instance of the MessengerKey class.
            /// </summary>
            /// <param name="recipient"></param>
            /// <param name="context"></param>
            public MessengerKey(object recipient, object context)
            {
                Recipient = recipient;
                Context = context;
            }

            /// <summary>
            /// Determines whether the specified MessengerKey is equal to the current MessengerKey.
            /// </summary>
            /// <param name="other"></param>
            /// <returns></returns>
            protected bool Equals(MessengerKey other)
            {
                return Equals(Recipient, other.Recipient) && Equals(Context, other.Context);
            }

            /// <summary>
            /// Determines whether the specified MessengerKey is equal to the current MessengerKey.
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != GetType()) return false;

                return Equals((MessengerKey)obj);
            }

            /// <summary>
            /// Serves as a hash function for a particular type. 
            /// </summary>
            /// <returns></returns>
            public override int GetHashCode()
            {
                unchecked
                {
                    return ((Recipient != null ? Recipient.GetHashCode() : 0) * 397) ^ (Context != null ? Context.GetHashCode() : 0);
                }
            }
        }
    }
}
