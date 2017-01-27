// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.StringDictionary
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CloudinaryDotNet
{
    public class StringDictionary : IDictionary<string, string>, ICollection<KeyValuePair<string, string>>, IEnumerable<KeyValuePair<string, string>>, IEnumerable
    {
        private readonly List<KeyValuePair<string, string>> m_list = new List<KeyValuePair<string, string>>();

        public StringDictionary()
        {
        }

        public StringDictionary(params string[] keyValuePairs)
        {
            foreach (var keyValuePair in keyValuePairs)
            {
                var length = keyValuePair.IndexOf('=');
                if (length == -1)
                    Add(keyValuePair, null);
                else
                    Add(keyValuePair.Substring(0, length), keyValuePair.Substring(length + 1));
            }
        }

        public bool Sort { get; set; }

        public string[] Pairs
        {
            get
            {
                return m_list.Select(pair =>
                {
                    if (pair.Value != null)
                        return string.Format("{0}={1}", pair.Key, pair.Value);
                    return pair.Key;
                }).ToArray();
            }
        }

        public string this[string key]
        {
            get
            {
                foreach (var keyValuePair in m_list)
                    if (keyValuePair.Key == key)
                        return keyValuePair.Value;
                return null;
            }
            set
            {
                var keyValuePair = new KeyValuePair<string, string>(key, value);
                var flag = false;
                for (var index = 0; index < m_list.Count; ++index)
                    if (m_list[index].Key == key)
                    {
                        m_list[index] = keyValuePair;
                        flag = true;
                    }
                if (flag)
                    return;
                m_list.Add(keyValuePair);
            }
        }

        public int Count
        {
            get { return m_list.Count; }
        }

        public ICollection<string> Keys
        {
            get { return m_list.Select(pair => pair.Key).ToArray(); }
        }

        public ICollection<string> Values
        {
            get { return m_list.Select(pair => pair.Value).ToArray(); }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Add(string key, string value)
        {
            m_list.Add(new KeyValuePair<string, string>(key, value));
        }

        public void Clear()
        {
            m_list.Clear();
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            if (Sort)
                return new SortedList<string, string>(this).GetEnumerator();
            return m_list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool ContainsKey(string key)
        {
            foreach (var keyValuePair in m_list)
                if (keyValuePair.Key == key)
                    return true;
            return false;
        }

        bool IDictionary<string, string>.Remove(string key)
        {
            foreach (var keyValuePair in m_list)
                if (keyValuePair.Key == key)
                {
                    m_list.Remove(keyValuePair);
                    return true;
                }
            return false;
        }

        public bool TryGetValue(string key, out string value)
        {
            value = null;
            foreach (var keyValuePair in m_list)
                if (keyValuePair.Key == key)
                {
                    value = keyValuePair.Value;
                    return true;
                }
            return false;
        }

        public void Add(KeyValuePair<string, string> item)
        {
            m_list.Add(item);
        }

        public bool Contains(KeyValuePair<string, string> item)
        {
            return m_list.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            m_list.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<string, string> item)
        {
            return m_list.Remove(item);
        }

        public string Remove(string key)
        {
            foreach (var keyValuePair in m_list)
                if (keyValuePair.Key == key)
                {
                    m_list.Remove(keyValuePair);
                    return keyValuePair.Value;
                }
            return null;
        }
    }
}