using System;
using System.Collections;
using System.Web;

namespace OpenEhs.Data
{
    public static class Local
    {
        static readonly ILocalData _data = new LocalData();

        public static ILocalData Data
        {
            get { return _data; }
        }

        private class LocalData : ILocalData
        {
            [ThreadStatic]
            private static Hashtable _localData;
            private static readonly object LocalDataHashtableKey = new object();

            private static Hashtable LocalHashtable
            {
                get 
                {
                    if (!RunningInWeb)
                    {
                        if (_localData == null)
                            _localData = new Hashtable();
                        return _localData;
                    }
                    else
                    {
                        var webHashtable = HttpContext.Current.Items[LocalDataHashtableKey] as Hashtable;
                        if (webHashtable == null)
                        {
                            webHashtable = new Hashtable();
                            HttpContext.Current.Items[LocalDataHashtableKey] = webHashtable;
                        }
                        return webHashtable;
                    }
                }
            }

            public object this[object key]
            {
                get { return LocalHashtable[key]; }
                set { LocalHashtable[key] = value; }
            }

            public int Count
            {
                get { return LocalHashtable.Count; }
            }

            public void Clear()
            {
                LocalHashtable.Clear();
            }

            public static bool RunningInWeb
            {
                get { return HttpContext.Current != null; }
            }
        }
    }
}