using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public interface IRange<T> {
  T Start { get; }
  T End { get; }
  bool Includes(T value);
  bool Includes(IRange<T> range);
}

public class DateRange : IRange<DateTime> {
  public DateTime Start { get; private set; }
  public DateTime End { get; private set; }

  public DateRange(DateTime start, DateTime end) {
    if(false == end > start) throw new ArgumentOutOfRangeException("End must be later than Start");
    Start = start;
    End = end;
  }

  public DateRange(DateTime start, TimeSpan length) {
    
  }

  public DateRange(TimeSpan length, DateTime end) {
  }

  public bool Includes(DateTime value) {
    return (Start <= value) && (value <= End);
  }

  public bool Includes(IRange<DateTime> range) {
    return (Start <= range.Start) && (range.End <= End);
  }
}

public class NumberRange : IRange<int> {
  public int Start { get; private set; }
  public int End { get; private set; }

  public NumberRange(int start, int end) {
    if(false == end > start) throw new ArgumentOutOfRangeException("End must be later than Start");
    Start = start;
    End = end;
  }
  public bool Includes(int value) {
    return (Start <= value) && (value <= End);
  }

  public bool Includes(IRange<int> range) {
    return (Start <= range.Start) && (range.End <= End);
  }
}

public class HttpRequestParameters {}


[AttributeUsage(AttributeTargets.Property)]
public class HttpRequestParameterAttribute : Attribute
{
  public string Name { get; set; }
  public HttpRequestParameterAttribute(){}
  public HttpRequestParameterAttribute(string name)
  {
    Name = name;
  }
}

public static partial class Extensions
{
  public static IEnumerable<KeyValuePair<string,string>> AsEnumerable<T>(this T parameters) where T : HttpRequestParameters 
  {
    BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
    PropertyInfo[] properties = typeof(T).GetProperties(flags);

    var enumerable = properties
    .Where(property => null != property.GetValue(parameters))
    .Select(property =>
    {
      string val = property.GetValue(parameters)!.ToString();
      HttpRequestParameterAttribute? attribute = property.GetCustomAttribute<HttpRequestParameterAttribute>();
      string key = null == attribute ?
        property.Name : (attribute.Name ?? property.Name);
      return new KeyValuePair<string,string>(key, val);
    });

    return enumerable;
  }
}


