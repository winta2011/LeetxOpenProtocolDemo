using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Alarm;
using OpenProtocolInterpreter.Curve;
using OpenProtocolInterpreter.Job;
using OpenProtocolInterpreter.Job.Advanced;
using OpenProtocolInterpreter.MultipleIdentifiers;
using OpenProtocolInterpreter.ParameterSet;
using OpenProtocolInterpreter.Tightening;
using OpenProtocolInterpreter.Time;
using OpenProtocolInterpreter.Tool;
using OpenProtocolInterpreter.Vin;

namespace Leetx.OpenProtocol
{
    internal class Program
    {

        static void PrintMidInfo(Mid mid)
        {
            if (mid == null)
            {
                Console.WriteLine($"---> Mid Is Null .... ");
                return;
            }
            Console.WriteLine($"---> {mid.GetType().Name}");
            foreach (var p in mid.GetType().GetProperties())
            {
                if (p.PropertyType.IsGenericType)
                {
                    object v = p.GetValue(mid);
                    if (v == null) continue;
                    Type t = v.GetType();
                    Console.WriteLine($"    {p.Name} :");
                    int cnt = Convert.ToInt32(t.GetProperty("Count").GetValue(v));
                    for (int i = 0; i < cnt; i++)
                    {
                        object listItem = t.GetMethod("get_Item").Invoke(v, new object[] { i });  //t.GetProperty("Item").GetValue(v, new object[] { i });
                        Console.Write($"        [{i}] - ");
                        Console.WriteLine(listItem);
                    }
                }
                else
                    Console.WriteLine($"    {p.Name}:{p.GetValue(mid)}");
            }
        }
        static async Task Main(string[] args)
        {
            OpClient client = new OpClient();
            client.TightingProcessEvent += Client_TightingProcessEvent;
            client.PropertyChanged += Client_PropertyChanged;
            var ret = client.Open("192.168.20.145", 9101);
            List<string> list = new List<string>();
            var cmd = Console.ReadLine();
            while (cmd != "quit")
            {
                if (cmd == "10") //获取Pset列表
                {
                    var mid = await client.SendMidWithResponse(new Mid0010(1)); //支持版本1
                    PrintMidInfo(mid);
                }
                else if (cmd == "12") // 获取Pset内容
                {
                    var mid = await client.SendMidWithResponse(new Mid0012(2) { ParameterSetId =1 }); //支持版本1,
                    PrintMidInfo(mid);
                }
                else if (cmd == "14") //Pset订阅
                {
                    var mid = await client.SendMidWithResponse(new Mid0014(2) ); //支持版本1,
                    PrintMidInfo(mid);
                }
                else if (cmd == "18")//切Pset
                {
                    var mid = await client.SendMidWithResponse(new Mid0018() { ParameterSetId= 2 }); //支持版本1,
                    PrintMidInfo(mid);
                }
                else if (cmd == "30")//Job列表
                {
                    var mid = await client.SendMidWithResponse(new Mid0030(2)); //支持版本1,2
                    PrintMidInfo(mid);
                }
                else if (cmd == "32")//获取Job信息
                {
                    var mid = await client.SendMidWithResponse(new Mid0032(1) { JobId=3 }); //支持版本1
                    PrintMidInfo(mid);
                }
                else if (cmd == "34")//订阅Job信息
                {
                    var mid = await client.SendMidWithResponse(new Mid0034(2) ); //支持版本1,2
                    PrintMidInfo(mid);
                }
                else if (cmd == "38")//切换JOB
                {
                    var mid = await client.SendMidWithResponse(new Mid0038(1) { JobId=1}); // 支持版本1
                    PrintMidInfo(mid);
                }
                else if (cmd == "39")//重启JOB
                {
                    var mid = await client.SendMidWithResponse(new Mid0039(1) { JobId = 1 }); // 支持版本1
                    PrintMidInfo(mid);
                }
                else if (cmd == "42")// 工具禁使能
                {
                    var mid = await client.SendMidWithResponse(new Mid0042(1)); // 支持版本1,2
                    PrintMidInfo(mid);
                }
                else if (cmd == "43")// 工具使能
                {
                    var mid = await client.SendMidWithResponse(new Mid0043(1)); // 支持版本1,2
                    PrintMidInfo(mid);
                }
                else if (cmd == "50")//下发VIN
                {
                    var mid = await client.SendMidWithResponse(new Mid0050() { VinNumber="LX1234567890"  }); // 支持版本1
                    PrintMidInfo(mid);
                }
                else if (cmd == "51")// 订阅VIN
                {
                    var mid = await client.SendMidWithResponse(new Mid0051(1)); // 支持版本1,2
                    PrintMidInfo(mid);
                }
                else if (cmd == "60")// 订阅结果
                {
                    var mid = await client.SendMidWithResponse(new Mid0060(3)); // 支持版本1,2,3
                    PrintMidInfo(mid);
                }
                else if (cmd == "63") // 订阅结果
                {
                    var mid = await client.SendMidWithResponse(new Mid0063(3)); // 支持版本1,2,3
                    PrintMidInfo(mid);
                }
                else if (cmd == "64") // 根据拧紧Id查询结果
                {
                    var mid = await client.SendMidWithResponse(new Mid0064() { TighteningId=142928}); // 支持版本1
                    PrintMidInfo(mid);
                }
                else if (cmd == "70")// 订阅报警
                {
                    var mid = await client.SendMidWithResponse(new Mid0070() ); // 支持版本1
                    PrintMidInfo(mid);
                }
                else if (cmd == "73")// 取消订阅报警
                {
                    var mid = await client.SendMidWithResponse(new Mid0073()); // 支持版本1
                    PrintMidInfo(mid);
                }
                else if (cmd == "74")// 清除报警
                {
                    var mid = await client.SendMidWithResponse(new Mid0074()); // 支持版本1
                    PrintMidInfo(mid);
                }
                else if (cmd == "80")//获取时间
                {
                    var mid = await client.SendMidWithResponse(new Mid0080()); // 支持版本1
                    PrintMidInfo(mid);
                }
                else if (cmd == "127")//获取时间
                {
                    var mid = await client.SendMidWithResponse(new Mid0127()); // 支持版本1
                    PrintMidInfo(mid);
                }
                else if (cmd == "150")//下发VIN
                {
                    var mid = await client.SendMidWithResponse(new Mid0150() { IdentifierData = "LX1234567890" }); // 支持版本1
                    PrintMidInfo(mid);
                }
                else if (cmd == "7402")//订阅分步结果
                {
                    var mid = await client.SendMidWithResponse(new Mid7402()); // 支持版本1
                    PrintMidInfo(mid);
                }
                else if (cmd == "7403")//取消订阅分步结果
                {
                    var mid = await client.SendMidWithResponse(new Mid7403()); // 支持版本1
                    PrintMidInfo(mid);
                }
                else if (cmd == "7408")//订阅曲线
                {
                    var mid = await client.SendMidWithResponse(new Mid7408()); // 支持版本1
                    PrintMidInfo(mid);
                }
                else if (cmd == "7409")//取消订阅曲线
                {
                    var mid = await client.SendMidWithResponse(new Mid7409()); // 支持版本1
                    PrintMidInfo(mid);
                }
                else
                {
                    Console.WriteLine("Unknown Command");
                }
                cmd = Console.ReadLine();
            }
        }

        private static void Client_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ConnnectStatus")
                Console.WriteLine(((OpClient)sender).ConnnectStatus);
        }

        //曲线缓存
        static Mid7410 buff = new Mid7410();
        private static void Client_TightingProcessEvent(int mid, OpenProtocolInterpreter.Mid data)
        {
            Console.WriteLine($"订阅信息->:Mid{mid}");
            switch (mid)
            {
                case 61:
                    var mid0061 = (Mid0061)data;
                    Console.WriteLine("Tighting Result: ");
                    PrintMidInfo(mid0061);
                    break;
                case 7410:
                    var resultcurve = (Mid7410)data;
                    Console.WriteLine($"{resultcurve.SegmentID} - {resultcurve.NumSegments}");
                    buff.Torque.AddRange(resultcurve.Torque);
                    buff.Angle.AddRange(resultcurve.Angle);
                    if (resultcurve.Header.Revision == 2)
                        buff.Speed.AddRange(resultcurve.Speed);
                    if (resultcurve.SegmentID == resultcurve.NumSegments) //曲线接收完成
                    {
                        int i = 0;  // 保存曲线到CSV
                       // var fs = System.IO.File.OpenWrite("./curve.csv");
                       // for (i = 0; i < buff.Torque.Count; i++)
                       // {
                          //  var bytes = Encoding.ASCII.GetBytes($"{i}, {buff.Torque[i]},{buff.Angle[i]} ");,{(resultcurve.Header.Revision == 2 ? buff.Speed[i] : 0)}\n");
                           // fs.Write(bytes, 0, bytes.Length);
                           // Console.WriteLine($"{i}: {buff.Torque[i]} N.m {buff.Angle[i]}° {(resultcurve.Header.Revision == 2 ? buff.Speed[i] : 0)} rpm");
                     //   }
                        //fs.Flush();
                        //fs.Close();
                        Console.WriteLine($"curve points {buff.Torque.Count}");
                        buff.Torque.Clear();
                        buff.Angle.Clear();
                        buff.Speed.Clear();
                    }
                    break;

                case 15:
                    PrintMidInfo(data);
                    break;
                case 35:
                     PrintMidInfo( data );
                    break;
                default:
                    PrintMidInfo(data);
                    break;

            }
        }
    }
}
