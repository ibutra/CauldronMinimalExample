using System;
using CauldronMinimal.History;

namespace CauldronMinimal
{
    [Serializable]
    public class ClassToSerialize : HistoryBase
    {
        [EnableHistory]
        public String Test { get; set; }
    }
}