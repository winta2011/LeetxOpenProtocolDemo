
// Type: OpenProtocolInterpreter.Converters.AsciiConverter`1
using System.Text;


namespace OpenProtocolInterpreter.Converters
{
  public abstract class AsciiConverter<T> : ValueConverter, IValueConverter<T>
  {
    public abstract T Convert(string value);

    public abstract string Convert(T value);

    public abstract string Convert(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      T value);

    public virtual T ConvertFromBytes(byte[] value)
    {
      return this.Convert(Encoding.ASCII.GetString(value));
    }

    public virtual byte[] ConvertToBytes(T value) => Encoding.ASCII.GetBytes(this.Convert(value));

    public virtual byte[] ConvertToBytes(
      char paddingChar,
      int size,
      DataField.PaddingOrientations orientation,
      T value)
    {
      return Encoding.ASCII.GetBytes(this.Convert(paddingChar, size, orientation, value));
    }
  }
}
