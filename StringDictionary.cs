// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.StringDictionary
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CloudinaryDotNet
{
  public class StringDictionary : IDictionary<string, string>, ICollection<KeyValuePair<string, string>>, IEnumerable<KeyValuePair<string, string>>, IEnumerable
  {
    private List<KeyValuePair<string, string>> m_list = new List<KeyValuePair<string, string>>();

    public bool Sort { get; set; }

    public string this[string key]
    {
      get
      {
        foreach (KeyValuePair<string, string> keyValuePair in this.m_list)
        {
          if (keyValuePair.Key == key)
            return keyValuePair.Value;
        }
        return (string) null;
      }
      set
      {
        KeyValuePair<string, string> keyValuePair = new KeyValuePair<string, string>(key, value);
        bool flag = false;
        for (int index = 0; index < this.m_list.Count; ++index)
        {
          if (this.m_list[index].Key == key)
          {
            this.m_list[index] = keyValuePair;
            flag = true;
          }
        }
        if (flag)
          return;
        this.m_list.Add(keyValuePair);
      }
    }

    public int Count
    {
      get
      {
        return this.m_list.Count;
      }
    }

    public string[] Pairs
    {
      get
      {
        return this.m_list.Select<KeyValuePair<string, string>, string>((Func<KeyValuePair<string, string>, string>) (pair =>
        {
          if (pair.Value != null)
            return string.Format("{0}={1}", (object) pair.Key, (object) pair.Value);
          return pair.Key;
        })).ToArray<string>();
      }
    }

    public ICollection<string> Keys
    {
      get
      {
        return (ICollection<string>) this.m_list.Select<KeyValuePair<string, string>, string>((Func<KeyValuePair<string, string>, string>) (pair => pair.Key)).ToArray<string>();
      }
    }

    public ICollection<string> Values
    {
      get
      {
        return (ICollection<string>) this.m_list.Select<KeyValuePair<string, string>, string>((Func<KeyValuePair<string, string>, string>) (pair => pair.Value)).ToArray<string>();
      }
    }

    public bool IsReadOnly
    {
      get
      {
        return false;
      }
    }

    public StringDictionary()
    {
    }

    public StringDictionary(params string[] keyValuePairs)
    {
      foreach (string keyValuePair in keyValuePairs)
      {
        int length = keyValuePair.IndexOf('=');
        if (length == -1)
          this.Add(keyValuePair, (string) null);
        else
          this.Add(keyValuePair.Substring(0, length), keyValuePair.Substring(length + 1));
      }
    }

    public void Add(string key, string value)
    {
      this.m_list.Add(new KeyValuePair<string, string>(key, value));
    }

    public string Remove(string key)
    {
      foreach (KeyValuePair<string, string> keyValuePair in this.m_list)
      {
        if (keyValuePair.Key == key)
        {
          this.m_list.Remove(keyValuePair);
          return keyValuePair.Value;
        }
      }
      return (string) null;
    }

    public void Clear()
    {
      this.m_list.Clear();
    }

    public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    {
      if (this.Sort)
        return new SortedList<string, string>((IDictionary<string, string>) this).GetEnumerator();
      return (IEnumerator<KeyValuePair<string, string>>) this.m_list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) this.GetEnumerator();
    }

    public bool ContainsKey(string key)
    {
      foreach (KeyValuePair<string, string> keyValuePair in this.m_list)
      {
        if (keyValuePair.Key == key)
          return true;
      }
      return false;
    }

    bool IDictionary<string, string>.Remove(string key)
    {
      foreach (KeyValuePair<string, string> keyValuePair in this.m_list)
      {
        if (keyValuePair.Key == key)
        {
          this.m_list.Remove(keyValuePair);
          return true;
        }
      }
      return false;
    }

    public bool TryGetValue(string key, out string value)
    {
      value = (string) null;
      foreach (KeyValuePair<string, string> keyValuePair in this.m_list)
      {
        if (keyValuePair.Key == key)
        {
          value = keyValuePair.Value;
          return true;
        }
      }
      return false;
    }

    public void Add(KeyValuePair<string, string> item)
    {
      this.m_list.Add(item);
    }

    public bool Contains(KeyValuePair<string, string> item)
    {
      return this.m_list.Contains(item);
    }

    public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
    {
      this.m_list.CopyTo(array, arrayIndex);
    }

    public bool Remove(KeyValuePair<string, string> item)
    {
      return this.m_list.Remove(item);
    }
  }
}
