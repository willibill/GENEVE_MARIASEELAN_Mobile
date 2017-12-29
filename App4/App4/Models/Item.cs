using Realms;
using System;

namespace App4
{
    public class Item : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return base.ToString() + Text;
        }
    }
}
