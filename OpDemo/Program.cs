using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using OpenProtocolInterpreter.Curve;
using OpenProtocolInterpreter.ParameterSet;
using OpenProtocolInterpreter.Tightening;
using OpenProtocolInterpreter.Tool;

namespace Leetx.OpenProtocol
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            OpClient client = new OpClient();
            client.TightingProcessEvent += Client_TightingProcessEvent;
            client.PropertyChanged += Client_PropertyChanged;
            var ret = client.Open("192.168.20.145", 9101);

            var c = Console.ReadLine();
            while (c != "quit")
            {
                c = Console.ReadLine();
                if (c == "10")
                {
                    var mid = await client.SendMidWithResponse(new Mid0010(1)); //支持版本1
                    if (mid is Mid0011 mid0011)
                    {
                        Console.WriteLine($"Mid0010 ->TotalParameterSets {mid0011.TotalParameterSets}");
                        foreach (var item in mid0011.ParameterSets)
                        {
                            Console.WriteLine($"Psets {item}");
                        }

                    }
                    else { Console.WriteLine($"Error : {mid.Header.Mid} , {mid.Header.Revision} , {mid.Header.StationId}"); }
                }
                else if (c == "12")
                {
                    var mid = await client.SendMidWithResponse(new Mid0012(1) { ParameterSetId = 1 }); //支持版本1,2
                    if (mid is Mid0013 dt)
                    {
                        Console.WriteLine($"---> {dt.GetType().Name}");
                        foreach (var p in dt.GetType().GetProperties())
                        {
                            Console.WriteLine($" {p.Name}:{p.GetValue(dt)}");
                        }
                    }
                    else { Console.WriteLine($"Error : {mid.Header.Mid} , {mid.Header.Revision} , {mid.Header.StationId}"); }
                }
                else if (c == "42")//
                {
                    var mid = await client.SendMidWithResponse(new Mid0042()); //支持版本1,2
                    if (mid is OpenProtocolInterpreter.Communication.Mid0005 dt)
                    {
                        Console.WriteLine($"---> {dt.GetType().Name}");
                        foreach (var p in dt.GetType().GetProperties())
                        {
                            Console.WriteLine($" {p.Name}:{p.GetValue(dt)}");
                        }
                    }
                    else { Console.WriteLine($"Error : {mid.Header.Mid} , {mid.Header.Revision} , {mid.Header.StationId}"); }
                }
                else
                {
                    Console.WriteLine("Unknown Command");
                }
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
            switch (mid)
            {
                case 61:
                    var mid0061 = (Mid0061)data;
                    Console.WriteLine("Tighting Result: {0}, {1:f2}Nm, {2:f2}degree", mid0061.TighteningId, mid0061.Torque, mid0061.Angle);
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
                        //int i = 0;
                        //var fs = System.IO.File.OpenWrite("./curve.csv");
                        //for (i = 0; i < buff.Torque.Count; i++)
                        //{
                        //    var bytes = Encoding.ASCII.GetBytes($"{i}, {buff.Torque[i]},{buff.Angle[i]},{(resultcurve.Header.Revision == 2 ? buff.Speed[i] : 0)}\n");
                        //    fs.Write(bytes,0, bytes.Length);
                        //    //Console.WriteLine($"{i}: {buff.Torque[i]} N.m {buff.Angle[i]}° {buff?.Speed[i++]} rpm");
                        //}
                        //fs.Flush();
                        //fs.Close();
                        Console.WriteLine($"curve points {buff.Torque.Count}");
                        buff.Torque.Clear();
                        buff.Angle.Clear();
                        buff.Speed.Clear();
                    }
                    break;

                case 15:
                    var dt = (Mid0015)data;
                    Console.WriteLine($"---> {dt.GetType().Name}");
                    foreach (var p in dt.GetType().GetProperties())
                    {
                        Console.WriteLine($" {p.Name}:{p.GetValue(dt)}");
                    }
                    break;
                default:
                    Console.WriteLine($"订阅信息->:Mid{mid}");
                    break;

            }
        }
    }
}
