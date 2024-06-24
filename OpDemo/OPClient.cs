
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.Curve;
using OpenProtocolInterpreter.KeepAlive;
using OpenProtocolInterpreter.Tightening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leetx.OpenProtocol
{
    public class OpClient : PropertyChangedEvent
    {
        private TcpClient tcpClient;
        private const int Timeout = 10000;
        private NetworkStream networkStream;
        private MidInterpreter midInterpreter;
        private byte[] TxBuf = new byte[4096 * 2];
        private string sQueryResponse = "";
        private bool gGlobalRunFalg = true;
        private bool bRunFlag = false;
        private string toolName;
        private DateTime keepAliveWatch = DateTime.Now;
        private readonly SemaphoreSlim sem = new SemaphoreSlim(0);
        private string sMid9999 = new Mid9999().Pack();
        string ip = "";
        int connectId = 0;
        /// <summary>
        /// 工具名
        /// </summary>
        public string ToolName
        {
            get { return toolName; }
            set { toolName = value; }
        }

         string sn = "";
        /// <summary>
        /// 扳手序列号
        /// </summary>
        public string SN
        {
            get { return sn; }
            set { sn = value; }
        }
        public int errorCount = 0;
        public string ipTimeOut = "";
        /// <summary>
        /// Mid号,mid结果事件
        /// </summary>
        public event Action<int, Mid> TightingProcessEvent;
        private string connnectStatus = "未启动";
        /// <summary>
        /// 连接状态报告
        /// </summary>
        public string ConnnectStatus { get { return connnectStatus; } set { connnectStatus = value; RaisePropertyChanged(); } }


        public OpClient()
        {

        }
        /// <summary>
        /// 打开OP通讯客户端
        /// </summary>
        /// <param name="ipString">工具OP服务IP</param>
        /// <param name="port">工具OP服务端口号</param>
        /// <param name="keepAliveInterval">Op心跳间隔</param>
        /// <returns></returns>
        public async Task<bool> Open(string ipString, int port, int keepAliveInterval = 3000 )
        {
            midInterpreter = new MidInterpreter()
                                            .UseAllMessages(new Type[]
                                            {
                                    typeof(Mid0001),typeof(Mid0002),typeof(Mid0003),typeof(Mid0004),typeof(Mid0005),
                                    typeof(Mid0060),typeof(Mid0061),typeof(Mid0062),typeof(Mid0064),typeof(Mid0065),
                                    typeof(Mid7408),typeof(Mid7410),typeof(Mid7411),
                                    typeof(Mid9999)
                                            });
            gGlobalRunFalg = true;
            ipTimeOut = ipString;
            Console.WriteLine(ipString + connnectStatus);
            while (gGlobalRunFalg)
            {
                try
                {
                    ConnnectStatus = "开始连接...";
                    OpenTcpClient(ipString, port);
                    if (tcpClient?.Connected == false || networkStream == null)
                    {
                        await Task.Delay(3000);
                        continue;
                    }
                    ConnnectStatus = "连接成功。建立OP通讯...";
                    Console.WriteLine(ipString + connnectStatus);
                    bRunFlag = true;
                    //开始接收数据
                    StartReceiveMsg(networkStream);
                    Console.WriteLine($"{ipString}-发送0001");
                    var mid0002 = await StartCommunication(); //发送0001
                    if (mid0002 == null)
                    {
                        Console.WriteLine("Can't Start Communication. Exit...");
                        continue;
                    }
                    else
                    {
                        //从版本6的0002帧中拿到扳手的名字和序列号
                        toolName = mid0002.ControllerName;
                        sn = mid0002.ControllerSerialNumber;
                    }

                    ConnnectStatus = "OP通讯已建立。发送订阅 Mid0060...";
                    bool subOk = await Subscribe(new Mid0060(1, 0).Pack());//订阅结果
                    {
                        ConnnectStatus = "发送曲线订阅7408";
                        subOk = await Subscribe(new Mid7408(2, 0).Pack()); //订阅曲线
                    }

                    while (bRunFlag)
                    {
                        if (tcpClient != null && tcpClient.Connected)
                        {
                            Console.WriteLine($" {ipString} 发送心跳 ... ");
                            await WriteMidAsync(sMid9999, 3000);
                        }
                        else
                        {
                            bRunFlag = false;
                        }
                        if ((DateTime.Now - keepAliveWatch).TotalMilliseconds > Timeout)
                        {
                            bRunFlag = false;
                            Console.WriteLine($"{ipTimeOut}心跳超时, 退出");
                        }
                        await Task.Delay(keepAliveInterval);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
            }
            return true;
        }


        public async Task Close()
        {
            ConnnectStatus = "断开通讯...";
            bRunFlag = false;
            gGlobalRunFalg = false;
            await Task.Delay(200);
            tcpClient.Close();
            tcpClient.Dispose();
            ConnnectStatus = "连接已断开";
        }

        public void CloseAll()
        {
            bRunFlag = false;
            gGlobalRunFalg = false;
            tcpClient.Close();
            tcpClient.Dispose();
        }


        void OpenTcpClient(string ipString, int port)
        {
            ip = ipString;
            try
            {
                tcpClient = new TcpClient() { ReceiveTimeout = 1000, ReceiveBufferSize = 409600, SendBufferSize = 204800 };
                connectId++;
                tcpClient.Connect(ipString, port);
                if (tcpClient.Connected == false)
                {
                    tcpClient.Dispose();
                    networkStream?.Dispose();
                }
                else
                {
                    connectId = 0;
                    networkStream = tcpClient.GetStream();
                }
            }
            catch (Exception ex)
            {
                tcpClient?.Dispose();
                networkStream?.Dispose();
                ConnnectStatus = $"Connect to {ipString} Failed,ConnectId={connectId},failed reason[{ex.Message}],Reconnecting....";
            }
        }
        void StartReceiveMsg(NetworkStream networkStream)
        {
            Task.Factory.StartNew(async () =>
            {
                List<byte> rxBuff = new List<byte>();
                while (bRunFlag)
                {
                    try
                    {
                        if (networkStream.DataAvailable == false)
                        {
                            await Task.Delay(5);
                            continue;
                        }
                        else
                        {
                            int tmp = networkStream.ReadByte();
                            switch (tmp)
                            {
                                case -1:
                                    {
                                        bRunFlag = false;
                                        ConnnectStatus = "远程Socket连接已断开";
                                    }
                                    break;
                                case 0:
                                    {
                                        if (rxBuff.Count >= 20)
                                        {
                                            try
                                            {
                                                HandleRxBuff(rxBuff.ToArray());
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine($"解析数据包出错 {ex.Message}");
                                            }
                                        }
                                        rxBuff.Clear();
                                    }
                                    break;
                                default:
                                    rxBuff.Add((byte)tmp);
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }

            }, TaskCreationOptions.None);
        }
        Mid7410 mid7410 = new Mid7410();
        void HandleRxBuff(byte[] buff)
        {
            int frameLen = 0;
            string frameAscii = Encoding.ASCII.GetString(buff);
            bool praseOk = int.TryParse(Encoding.ASCII.GetString(buff.ToArray(), 0, 4), out frameLen);
            string midNo = Encoding.ASCII.GetString(buff.ToArray(), 4, 4);
            if (praseOk == false)
            {
                return;
            }
            Console.WriteLine($"{ip}收到 Mid {midNo}");
            switch (midNo)
            {
                case "0061":  //结果数据
                    var mid0061 = midInterpreter.Parse<Mid0061>(frameAscii);
                    WriteMid(new Mid0062().Pack()); //mid0061.HeaderData.Revision
                    TightingProcessEvent?.BeginInvoke(Mid0061.MID, mid0061, (x) =>
                    {
                        Console.WriteLine("----> Tighting Result Completed !");
                    }, null);
                    break;
                case "7410": //曲线数据 //处理曲线帧解析函数 
                    TightingProcessEvent?.BeginInvoke(Mid7410.MID, mid7410.Parse(buff), x =>
                    {
                        Console.WriteLine("----> Cureve Completed !");
                    }, null);
                    break;
                case "9999":
                    keepAliveWatch = DateTime.Now;
                    Console.WriteLine("收到心跳响应...");
                    break;
                default:
                    sQueryResponse = frameAscii;
                    sem.Release();
                    break;
            }
        }
        public async Task WriteMidAsync(string str, int timeout = Timeout)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(str);
            Array.Copy(bytes, TxBuf, bytes.Length);
            TxBuf[bytes.Length] = 0;
            await networkStream.WriteAsync(TxBuf, 0, bytes.Length + 1);
        }

        private void WriteMid(string str, int timeout = Timeout)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(str);
            Array.Copy(bytes, TxBuf, bytes.Length);
            TxBuf[bytes.Length] = 0;
            networkStream.WriteAsync(TxBuf, 0, bytes.Length + 1);
        }

        /// <summary>
        /// 发送Mid指令
        /// </summary>
        /// <param name="str">指令文本</param>
        /// <param name="timeout">指令超时时间</param>
        /// <returns>响应的Mid</returns>
        public async Task<Mid> SendMidWithResponse(string str, int timeout = Timeout)
        {
            await WriteMidAsync(str, timeout);
            bool bOK = await sem.WaitAsync(timeout);
            if (bOK)
            {
                Mid mid = midInterpreter.Parse(sQueryResponse);
                return mid;
            }
            return null;
        }
        /// <summary>
        /// 发送Mid指令
        /// </summary>
        /// <param name="midCmd">指令类型Mid</param>
        /// <param name="timeout">指令超时时间</param>
        /// <returns>响应的Mid</returns>
        public async Task<Mid> SendMidWithResponse(Mid midCmd, int timeout = Timeout)
        {
            await WriteMidAsync(midCmd.Pack(), timeout);
            bool bOK = await sem.WaitAsync(timeout);
            if (bOK)
            {
                Mid mid = midInterpreter.Parse(sQueryResponse);
                return mid;
            }
            return null;
        }
        private const int RetryTimes = 3;

        private async Task<Mid0002> StartCommunication()
        {
            for (int i = 0; i < 10; i++)
            {
                Mid rxMid = await SendMidWithResponse(new Mid0001(5).Pack(), 5000);//7.20 ,发送0001时的是版本6
                if (rxMid != null && rxMid.HeaderData.Mid == 2)
                {
                    return (Mid0002)rxMid;
                }
            }
            return null;
        }

        public async Task<bool> Subscribe(string subscribeMidString)
        {
            for (int i = 0; i < RetryTimes; i++)
            {
                Mid rxMid = await SendMidWithResponse(subscribeMidString);
                if (rxMid != null)
                {
                    if (rxMid.HeaderData.Mid == 5)
                    {
                        return true;
                    }
                    if (rxMid.HeaderData.Mid == 4)
                    {
                        var mid0004 = (Mid0004)midInterpreter.Parse(sQueryResponse);
                        if (mid0004.ErrorCode == Error.SUBSCRIPTION_ALREADY_EXISTS)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 根据拧紧Id主动获取离线数据
        /// </summary>
        /// <param name="tighteningID">拧紧Id</param>
        /// <returns></returns>
        private async Task<Mid0065> QueryResultByTighteningID(long tighteningID)
        {
            var txMid = new Mid0064((int)tighteningID, 1);
            for (int i = 0; i < RetryTimes; i++)
            {
                Mid rxMid = await SendMidWithResponse(txMid.Pack(), Timeout);
                Console.WriteLine($"Mid0064 -->,ID:{tighteningID}");
                if (rxMid != null)
                {
                    if (rxMid.HeaderData.Mid == 65)
                    {
                        return (Mid0065)rxMid;
                    }
                }
            }
            return null;
        }
    }
}