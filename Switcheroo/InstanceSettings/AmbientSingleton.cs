using System;
using System.Runtime.Remoting.Messaging;

namespace Switcheroo.InstanceSettings
{
    partial class AmbientSingleton<T>
    {
        private string slotName = Guid.NewGuid().ToString();
        private Lazy<T> defaultValue;

        /// </summary>
        public AmbientSingleton()
            : this(() => default(T))
        {
        }

        public AmbientSingleton(T defaultValue)
            : this(() => defaultValue)
        {
        }

        public AmbientSingleton(Func<T> defaultValueFactory)
        {
            if (defaultValueFactory == null) throw new ArgumentNullException(nameof(defaultValueFactory));

            this.defaultValue = new Lazy<T>(defaultValueFactory);
        }

        public T Value
        {
            get
            {
                var contextValue = CallContext.LogicalGetData(this.slotName);
                if (contextValue != null)
                    return (T)contextValue;

                return this.defaultValue.Value;
            }
            set
            {
                CallContext.LogicalSetData(this.slotName, value);
            }
        }
    }

    static partial class AmbientSingleton
    {
        public static AmbientSingleton<T> Create<T>(T defaultValue)
        {
            return new AmbientSingleton<T>(defaultValue);
        }

        public static AmbientSingleton<T> Create<T>(Func<T> defaultValueFactory)
        {
            return new AmbientSingleton<T>(defaultValueFactory);
        }
    }
}