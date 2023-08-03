using RatchetMemoryApi.Events;
using System;
using System.Timers;

namespace RatchetMemoryApi.Memory.Items
{
    public class ItemBase
    {
        public string Name { get; set; }
        internal int EnabledAddress { get; set; }

        private Timer memoryValueChangedTimer;
        private bool previousEnabledValue;

        public EventHandler<EnabledValueUpdatedArgs> EnabledValueChangedEvent;

        public ItemBase NotifyOfChanges(double checkIntervalMs)
        {
            memoryValueChangedTimer = new Timer();
            memoryValueChangedTimer.Interval = checkIntervalMs;
            memoryValueChangedTimer.AutoReset = true;
            memoryValueChangedTimer.Elapsed += CheckForValueChanged;
            memoryValueChangedTimer.Start();

            return this;
        }

        public bool IsEnabled()
        {
            return MemoryReadWriteHandler.Instance.ReadBool(EnabledAddress);
        }

        public void SetEnabled(bool value)
        {
            MemoryReadWriteHandler.Instance.WriteBool(EnabledAddress, value);
        }

        private void CheckForValueChanged(object src, EventArgs e)
        {
            var enabledFromMem = IsEnabled();
            if(enabledFromMem != previousEnabledValue)
            {
                previousEnabledValue = enabledFromMem;
                EnabledValueChangedEvent?.Invoke(this, new EnabledValueUpdatedArgs() { NewValue = enabledFromMem });
            }
        }
    }
}
