
// Type: OpenProtocolInterpreter.Converters.BitConverter

namespace OpenProtocolInterpreter.Converters
{
  public class BitConverter
  {
    public bool GetBit(byte b, int bitNumber) => ((uint) b & (uint) (1 << bitNumber - 1)) > 0U;

    protected byte SetByte(bool[] values)
    {
      byte num1 = 0;
      int num2 = 8 - values.Length;
      foreach (bool flag in values)
      {
        if (flag)
          num1 |= (byte) (1 << 7 - num2);
        ++num2;
      }
      return num1;
    }
  }
}
