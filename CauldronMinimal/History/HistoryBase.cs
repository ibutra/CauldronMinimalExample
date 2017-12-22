using System;
using System.Linq;

namespace CauldronMinimal.History
{
    [Serializable]
    public abstract class HistoryBase : IHistory
    {
        [NonSerialized]
        private bool _historyEnabled = false;

        public bool HistoryEnabled()
        {
            return _historyEnabled;
        }
        public void StartHistory()
        {
            _historyEnabled = true;
            foreach (var propertyInfo in this.GetType().GetProperties().Where(p => p.PropertyType.GetInterfaces().Contains(typeof(IHistory))))
            {
                var property = propertyInfo.GetValue(this) as IHistory;
                property?.StartHistory();
            }
        }

        

    }
}