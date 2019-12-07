using EditorTools;
using ScriptableSystems;
using System;
using System.Collections.Generic;

namespace Characters
{
    [Serializable]
    public class GuestType
    {
        public string id;

        public List<HotelParameter> requirements = new List<HotelParameter>();
    }
}