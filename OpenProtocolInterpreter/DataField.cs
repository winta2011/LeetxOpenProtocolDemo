
// Type: OpenProtocolInterpreter.DataField
using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpenProtocolInterpreter
{
  public class DataField
  {
    private readonly char _paddingChar;
    private readonly DataField.PaddingOrientations _paddingOrientation;
    private object CachedValue;

    public bool HasPrefix { get; set; }

    public int Field { get; set; }

    public int Index { get; set; }

    public int Size { get; set; }

    public string Value { get; set; }

    public byte[] RawValue { get; set; }

    public DataField(int field, int index, int size, bool hasPrefix = true)
    {
      this.HasPrefix = hasPrefix;
      this.Field = field;
      this.Index = index;
      this.Size = size;
      this._paddingChar = ' ';
    }

    public DataField(
      int field,
      int index,
      int size,
      char paddingChar,
      DataField.PaddingOrientations paddingOrientation = DataField.PaddingOrientations.RIGHT_PADDED,
      bool hasPrefix = true)
    {
      this._paddingChar = paddingChar;
      this._paddingOrientation = paddingOrientation;
      this.HasPrefix = hasPrefix;
      this.Field = field;
      this.Index = index;
      this.Size = size;
    }

    public virtual T GetValue<T>(Func<string, T> converter)
    {
      if (string.IsNullOrWhiteSpace(this.Value))
        this.CachedValue = (object) default (T);
      else if (this.IsValueNotCached<T>())
        this.CachedValue = (object) converter(this.Value);
      return (T) this.CachedValue;
    }

    public virtual T GetValue<T>(Func<byte[], T> converter)
    {
      if (this.RawValue == null || !((IEnumerable<byte>) this.RawValue).Any<byte>())
        this.CachedValue = (object) default (T);
      else if (this.IsValueNotCached<T>())
        this.CachedValue = (object) converter(this.RawValue);
      return (T) this.CachedValue;
    }

    public virtual void SetValue<T>(
      Func<char, int, DataField.PaddingOrientations, T, string> converter,
      T value)
    {
      this.CachedValue = (object) null;
      this.Value = converter(this._paddingChar, this.Size, this._paddingOrientation, value);
      this.Size = this.Value.Length;
    }

    public virtual void SetRawValue<T>(
      Func<char, int, DataField.PaddingOrientations, T, byte[]> converter,
      T value)
    {
      this.CachedValue = (object) null;
      this.RawValue = converter(this._paddingChar, this.Size, this._paddingOrientation, value);
      this.Size = this.RawValue.Length;
    }

    public virtual void SetValue(string value)
    {
      this.CachedValue = (object) null;
      this.SetValue<string>(new Func<char, int, DataField.PaddingOrientations, string, string>(new ValueConverter().GetPadded), value);
    }

    private bool IsValueNotCached<T>() => this.CachedValue == null || this.IsNotTypeOf<T>();

    private bool IsNotTypeOf<T>() => !this.CachedValue.GetType().Equals(typeof (T));

    public enum PaddingOrientations
    {
      RIGHT_PADDED,
      LEFT_PADDED,
    }
  }
}
