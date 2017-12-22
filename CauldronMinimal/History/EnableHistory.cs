using System;
using Cauldron.Interception;

namespace CauldronMinimal.History
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class EnableHistory : Attribute, IPropertySetterInterceptor
    {
        public void OnException(Exception e)
        {
            throw e;
        }

        public void OnExit()
        {
            
        }

        public bool OnSet(PropertyInterceptionInfo propertyInterceptionInfo, object oldValue, object newValue)
        {
            if (propertyInterceptionInfo.Instance is HistoryBase instance)
            {
                if (!instance.HistoryEnabled())
                {
                    return false;
                }
            }
            var command = new GenericCommand(
                () =>
                {
                    propertyInterceptionInfo.SetValue(newValue);
                },
                () =>
                {
                    propertyInterceptionInfo.SetValue(oldValue);
                });
            CommandManager.PerformCommand(command);
            return true;
        }
    }
}