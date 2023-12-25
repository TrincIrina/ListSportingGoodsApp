using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListSportingGoodsApp
{
    internal class SportGood
    {
        // поля - автосвойства
        public string Description { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        
        // Конструктор со всеми параметрами
        public SportGood(string description, DateTime lastUpdatedAt)
        {
            Description = description;
            LastUpdatedAt = lastUpdatedAt;            
        }

        public override string ToString()
        {
            return $"{Description} ({LastUpdatedAt})";
        }
    }
}
