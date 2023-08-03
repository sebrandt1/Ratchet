using System;

namespace RatchetMemoryApi.Events
{
    public class EnabledValueUpdatedArgs : EventArgs
    {
        public bool NewValue { get; set; }
    }
}
