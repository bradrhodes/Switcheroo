using System;
using System.Collections.Generic;

namespace Switcheroo.InstanceSettings
{
    public class NonPersistedSettingsData
    {
        public NonPersistedSettingsData()
        {
            PinnedToBottom = new List<IntPtr>();
        }

        public List<IntPtr> PinnedToBottom { get; private set; } 
    }
}