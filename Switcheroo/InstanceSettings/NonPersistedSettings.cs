namespace Switcheroo.InstanceSettings
{
    public class NonPersistedSettings
    {
        private static readonly AmbientSingleton<NonPersistedSettingsData> instance = new AmbientSingleton<NonPersistedSettingsData>();

        private NonPersistedSettings() { }

        public static NonPersistedSettingsData Default
        {
            get
            {
                if(instance.Value == null)
                    instance.Value = new NonPersistedSettingsData();

                return instance.Value;
            }
            internal set { instance.Value = value; }
        }
    }
}