using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Alarm;
using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.Curve;
using OpenProtocolInterpreter.Job;
using OpenProtocolInterpreter.Job.Advanced;
using OpenProtocolInterpreter.KeepAlive;
using OpenProtocolInterpreter.ParameterSet;
using OpenProtocolInterpreter.Tightening;
using OpenProtocolInterpreter.Time;
using OpenProtocolInterpreter.Tool;
using OpenProtocolInterpreter.Vin;


namespace Leetx.OpenProtocolDemo
{
    public sealed class ListViewHeightConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double h && h > 0)
            {
                if(parameter  != null && parameter is string s)
                {
                    return h - 430+ double.Parse(s);
                }
                return h - 430;
            }
            return 300;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        ListViewHeightConverter provider;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (provider == null)
            {
                provider = new ListViewHeightConverter();
            }
            return provider;
        }
    }
    public sealed class Mid2DescConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int v)
            {
                switch (v)
                {
                    case 0:
                        return "发送指令";
                    case 4:
                        return "发送失败";
                    case 5:
                        return "发送成功";
                    default:
                        return "反馈";
                }
            }
            return 300;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        Mid2DescConverter provider;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (provider == null)
            {
                provider = new Mid2DescConverter();
            }
            return provider;
        }
    }

    public sealed class ByteBuffer2StrConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is byte[] v)
            {
                return Encoding.ASCII.GetString(v);
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        ByteBuffer2StrConverter provider;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (provider == null)
            {
                provider = new ByteBuffer2StrConverter();
            }
            return provider;
        }
    }
    public sealed class ByteBuffer2HexStrConverter : MarkupExtension, IValueConverter
    {
        string Bytes2Hex(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (var item in bytes)
            {
                sb.Append(item.ToString("X2"));
                sb.Append(' ');
            }
            sb.Append('\n');
            return sb.ToString();
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is byte[] v)
            {
                return Bytes2Hex(v);
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        ByteBuffer2HexStrConverter provider;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (provider == null)
            {
                provider = new ByteBuffer2HexStrConverter();
            }
            return provider;
        }
    }
    public sealed class ByteBuffer2MidStrConverter : MarkupExtension, IValueConverter
    {
        string PrintMidInfo(Mid mid)
        {
            if (mid == null)
            {
                return "";
            }
            Console.WriteLine($"{mid.GetType().Name}:---> \n");
            var sb = new StringBuilder($"{mid.GetType().Name}:\n");
            foreach (var p in mid.GetType().GetProperties())
            {
                if (p.PropertyType.IsGenericType)
                {
                    object v = p.GetValue(mid);
                    if (v == null) continue;
                    Type t = v.GetType();
                    sb.Append($"    {p.Name} : \n");
                    var cp = t.GetProperty("Count");
                    if (cp == null) continue;
                    int cnt = (int)cp.GetValue(v);
                    for (int i = 0; i < cnt; i++)
                    {
                        object listItem = t.GetMethod("get_Item").Invoke(v, new object[] { i });  //t.GetProperty("Item").GetValue(v, new object[] { i });
                        sb.Append($"        [{i}] - {listItem} \n");
                    }
                }
                else
                    sb.Append($"    {p.Name}:{p.GetValue(mid)}\n");
            }
            return sb.ToString();
        }
        Dictionary<string, Type> mids = new Dictionary<string, Type>();
        readonly Type[] types = new Type[] { typeof( Mid0001 ),  typeof( Mid0002 ),
                 typeof( Mid0003 ),
                 typeof( Mid0004 ),
                 typeof( Mid0005 ),
                 typeof( Mid0010 ),
                 typeof( Mid0011 ),
                 typeof( Mid0012 ),
                 typeof( Mid0013 ),
                 typeof( Mid0014 ),
                 typeof( Mid0015 ),
                 typeof( Mid0016 ),
                 typeof( Mid0017 ),
                 typeof( Mid0018 ),
                 typeof( Mid0030 ),
                 typeof( Mid0031 ),
                 typeof( Mid0032 ),
                 typeof( Mid0033 ),
                 typeof( Mid0034 ),
                 typeof( Mid0035 ),
                 typeof( Mid0050 ),
                 typeof( Mid0051 ),
                 typeof( Mid0052 ),
                 typeof( Mid0042 ),
                 typeof( Mid0043 ),
                 typeof( Mid0060 ),
                 typeof( Mid0061 ),
                 typeof( Mid0063 ),
                 typeof( Mid0064 ),
                 typeof( Mid0065 ),
                 typeof( Mid0070 ),
                 typeof( Mid0071 ),
                 typeof( Mid0073 ),
                 typeof( Mid0074 ), // 清除报警时发送
                 // Mid0076报警状态 
                 typeof( Mid0076 ),
                 typeof( Mid0080 ),
                 typeof( Mid0081 ),
                 typeof( Mid0127 ),
                 typeof( OpenProtocolInterpreter.MultipleIdentifiers.Mid0150 ),
                 typeof( Mid7402 ),
                 typeof( Mid7403 ),
                 typeof( Mid7404 ),
                 typeof( Mid7405 ),
                 typeof( Mid7406 ),
                 typeof( Mid7407 ),
                 typeof( Mid7408 ),
                 typeof( Mid7409 ),
                 typeof( Mid7410 ),
                 typeof( Mid7411 ),
                 typeof( Mid9999 ),
                 typeof( OpenProtocolInterpreter.LinkCommunication.Mid9997 ),
        };
        private Mid ParseMid(byte[] buff)
        {
            var key = Encoding.ASCII.GetString(buff, 4, 4);
            if (mids.ContainsKey(key))
            {
                return ((Mid)Activator.CreateInstance(mids[key]))?.Parse(buff);
            }
            return null;
        }

        public ByteBuffer2MidStrConverter()
        {
            foreach (var t in types)
            {
                mids[t.Name.Substring(3, 4)] = t;
            }
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is byte[] v)
            {
                return PrintMidInfo(ParseMid(v));
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        ByteBuffer2MidStrConverter provider;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (provider == null)
            {
                provider = new ByteBuffer2MidStrConverter();
            }
            return provider;
        }
    }
}
