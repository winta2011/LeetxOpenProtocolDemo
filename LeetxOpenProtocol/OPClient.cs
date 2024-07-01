
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Alarm;
using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.Curve;
using OpenProtocolInterpreter.Job;
using OpenProtocolInterpreter.KeepAlive;
using OpenProtocolInterpreter.ParameterSet;
using OpenProtocolInterpreter.Tightening;
using OpenProtocolInterpreter.Time;
using OpenProtocolInterpreter.Vin;
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
        private byte[] commandResponseBuff = new byte[1];
        private bool gGlobalRunFalg = true;
        private bool bRunFlag = false;
        private string toolName;
        private DateTime keepAliveWatch = DateTime.Now;
        private readonly SemaphoreSlim cmdSem = new SemaphoreSlim(0);
        private string strMid9999 = new Mid9999().Pack();
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
        string ip = "";

        Dictionary<string, Type> mids = new Dictionary<string, Type>();

        public enum ConnectStatusEnum
        {
            Disconnecting ,
            UnConnected,
            Disconnected = 1,
            Connecting ,
            KeepAliveTimeout,
            Connected =100,
        }


        private ConnectStatusEnum connnectStatus = ConnectStatusEnum.UnConnected;
        /// <summary>
        /// 连接状态报告
        /// </summary>
        public ConnectStatusEnum ConnnectStatus { get { return connnectStatus; } set { connnectStatus = value; RaisePropertyChanged(); } }
       
        /// <summary>
        /// Mid号,mid结果事件
        /// </summary>
        public event Action<int, Mid> TightingProcessEvent;
        public event Action<int, Byte[]> TightingWriteEvent;
        public event Action<int, Byte[]> TightingReadEvent;
        public event Action<string,TightingProcessException> TightingProcessExceptioneEvent;
        /// <summary>
        /// 注册需要解析的Mid,必须要有无参构造函数 
        /// </summary>
        readonly Type[] typs = new Type[] {
                 typeof( Mid0002 ),
                 typeof( Mid0003 ),
                 typeof( Mid0004 ),
                 typeof( Mid0005 ),
                 typeof( Mid0011 ),
                 typeof( Mid0013 ),
                 typeof( Mid0015 ),
                 typeof( Mid0031 ),
                 typeof( Mid0033 ),
                 typeof( Mid0035 ),
                 typeof( Mid0052 ),
                 typeof( Mid0061 ),
                 typeof( Mid0065 ),
                 typeof( Mid0071 ), // 推送报警信息
                 typeof( Mid0074 ), // 清除报警时发送
                 // Mid0076报警状态 
                 typeof( Mid0076 ),     
                 typeof( Mid0081 ),
                 typeof( Mid7404 ),
                 typeof( Mid7406 ),
                 typeof( Mid7410 ),
            };

        public OpClient()
        {
            foreach (var t in typs)
            {
                mids[t.Name.Substring(3, 4)] = t;
            }
        }

        /// <summary>
        /// 打开OP通讯客户端
        /// </summary>
        /// <param name="ipString">工具OP服务IP</param>
        /// <param name="port">工具OP服务端口号</param>
        /// <param name="keepAliveInterval">Op心跳间隔</param>
        /// <returns></returns>
        public async Task<bool> Open(string ipString, int port, int keepAliveInterval = 3000)
        {
            gGlobalRunFalg = true;
            ip = ipString;

            while (gGlobalRunFalg)
            {
                try
                {
                    OpenTcpClient(ipString, port);
                    if (tcpClient == null || tcpClient.Connected == false || networkStream == null)
                    {
                        await Task.Delay(3000);
                        continue;
                    }
                    ConnnectStatus = ConnectStatusEnum.Connecting;
                    Console.WriteLine(ipString + connnectStatus);
                    bRunFlag = true;
                    //开始接收数据
                    StartReceiveMsg(networkStream);
                    var mid0002 = await StartCommunication(); //发送0001
                    if (mid0002 == null )
                    {
                        continue;
                    }
                    else
                    {
                        // 从版本6的0002帧中拿到扳手的名字和序列号
                        toolName = mid0002.ControllerName;
                        sn = mid0002.ControllerSerialNumber;
                    }
                    ConnnectStatus = ConnectStatusEnum.Connected ;
                    // 添加默认订阅
                    //bool subOk = await Subscribe(new Mid0060(3));//订阅结果
                    //{
                    //    subOk = await Subscribe(new Mid7408(2, 0)); //订阅曲线
                    //    subOk = await Subscribe(new Mid7402()); //订阅曲线
                    //}
                    keepAliveWatch = DateTime.Now;
                    while (bRunFlag)
                    {
                        if (tcpClient != null && tcpClient.Connected)
                        {
                            await WriteMidAsync(strMid9999);
                        }
                        else
                        {
                            bRunFlag = false;
                        }
                        if ((DateTime.Now - keepAliveWatch).TotalMilliseconds > Timeout)
                        {
                            bRunFlag = false;
                            ConnnectStatus = ConnectStatusEnum.KeepAliveTimeout;
                        }
                        await Task.Delay(keepAliveInterval);
                    }
                }
                catch (Exception ex)
                {
                    TightingProcessExceptioneEvent?.Invoke("TcpConnectedError", new TightingProcessException($"Connect to {ip} Failed,ConnectId={connectId},failed reason[{ex.Message}],Reconnecting...."));
                }
            }
            return true;
        }


        public async Task Close()
        {
            ConnnectStatus =  ConnectStatusEnum.Disconnected;
            bRunFlag = false;
            gGlobalRunFalg = false;
            await Task.Delay(200);
            tcpClient.Close();
            tcpClient.Dispose();
            ConnnectStatus = ConnectStatusEnum.Disconnected;
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
                tcpClient = new TcpClient() { ReceiveTimeout = 3000,SendTimeout=2000, ReceiveBufferSize = 409600, SendBufferSize = 204800 };
                connectId++;
                tcpClient.Connect(ipString, port);
                if (tcpClient.Connected == false)
                {
                    throw new Exception("连接OP服务失败...");
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
                tcpClient = null;
                bRunFlag = false;
                networkStream?.Dispose();
                ConnnectStatus = ConnectStatusEnum.UnConnected;
                TightingProcessExceptioneEvent?.Invoke("TcpClientError",new TightingProcessException($"Connect to {ipString} Failed,ConnectId={connectId},failed reason[{ex.Message}],Reconnecting...."));
            }
        }
        void StartReceiveMsg(NetworkStream networkStream)
        {
            Task.Factory.StartNew(async () =>
            {
                byte[] rxBuff = new byte[4096];
                int rxIndx = 0;
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
                                        ConnnectStatus = ConnectStatusEnum.Disconnected;
                                    }
                                    break;
                                case 0:
                                    {
                                        if (rxIndx >= 20)
                                        {
                                            try
                                            {
                                                HandleRxBuff(rxBuff.Take(rxIndx).ToArray());
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine($"解析数据包出错 {ex.Message}");
                                                TightingProcessExceptioneEvent?.Invoke("HandleRxBuffError", new TightingProcessException($"解析数据包出错 [{ex.Message}]"));
                                            }
                                        }
                                        rxIndx = 0;
                                    }
                                    break;
                                default:
                                    rxBuff[rxIndx++] = (byte)tmp;
                                    if (rxIndx > 4095) rxIndx = 0;
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        TightingProcessExceptioneEvent?.Invoke("TcpReceiveError", new TightingProcessException($" {ex.Message} "));
                    }
                }

            }, TaskCreationOptions.None);
        }
        void HandleRxBuff(byte[] buff)
        {
            int frameLen = 0;
            bool praseOk = int.TryParse(Encoding.ASCII.GetString(buff, 0, 4), out frameLen);
            string midNo = Encoding.ASCII.GetString(buff, 4, 4);
            TightingReadEvent?.BeginInvoke(frameLen, buff, null, null);
            if (frameLen!= buff.Length)
            {
                TightingProcessExceptioneEvent?.Invoke("ParseMidError", new TightingProcessException($"Mid{midNo} Frame is {frameLen},but bytes buff length is {buff.Length} "));
                return;
            }
            switch (midNo)
            {
                case "0061": // 结果数据
                case "0071": // 报警事件
                case "0074": // 报警确认
                case "0076": // 报警状态
                case "7404": // 分步结果
                case "7406": // 分步结果总
                case "7410": // 曲线数据 //处理曲线帧解析函数 
                case "0015": // 激活的Pset变更
                case "0035": // 激活的Job变更
                    var mid = ParseMid(buff);
                    TightingProcessEvent?.BeginInvoke(int.Parse(midNo), mid,null, null);
                    break;
                case "9999":
                    keepAliveWatch = DateTime.Now;
                    break;
                default:
                    commandResponseBuff = buff;
                    cmdSem.Release();
                    break;
            }
        }

        private Mid ParseMid(byte[] buff)
        {
            var key = Encoding.ASCII.GetString(buff, 4, 4);
            if (mids.ContainsKey(key))
            {
                return ((Mid)Activator.CreateInstance(mids[key]))?.Parse(buff);
            }
            return null;
        }

        public async Task WriteMidAsync(string str)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(str + "\0");
            TightingWriteEvent?.BeginInvoke(bytes.Length, bytes, null, null);
            await networkStream.WriteAsync(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// 发送Mid指令
        /// </summary>
        /// <param name="str">指令文本</param>
        /// <param name="timeout">指令超时时间</param>
        /// <returns>响应的Mid</returns>
        public async Task<Mid> SendMidWithResponse(string str, int timeout = Timeout)
        {
            await WriteMidAsync(str);
            bool bOK = await cmdSem.WaitAsync(timeout);
            if (bOK)
            {
                return ParseMid(commandResponseBuff);
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
            await WriteMidAsync(midCmd.Pack());
            bool bOK = await cmdSem.WaitAsync(timeout);
            if (bOK)
            {
                return ParseMid(commandResponseBuff);
            }
            return null;
        }
        private const int RetryTimes = 3;

        private async Task<Mid0002> StartCommunication()
        {
            for (int i = 0; i < 10; i++)
            {
                Mid rxMid = await SendMidWithResponse(new Mid0001(5).Pack(), 5000);//7.20 ,发送0001时的是版本6
                if (rxMid != null && rxMid.Header.Mid == 2)
                {
                    return (Mid0002)rxMid;
                }
                await Task.Delay(1000);
            }
            return null;
        }

        public async Task<bool> Subscribe(Mid mid)
        {
            for (int i = 0; i < RetryTimes; i++)
            {
                Mid rxMid = await SendMidWithResponse(mid.Pack());
                if (rxMid != null)
                {
                    if (rxMid.Header.Mid == 5)
                    {
                        return true;
                    }
                    if (rxMid.Header.Mid == 4)
                    {
                        if (rxMid is Mid0004 mid4 && mid4.ErrorCode == Error.SubscriptionAlreadyExists)
                        {
                            return true;
                        }
                        else
                        {
                          await  Task.Delay(600);
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
            var txMid = new Mid0064(1) { TighteningId = tighteningID };
            for (int i = 0; i < RetryTimes; i++)
            {
                Mid rxMid = await SendMidWithResponse(txMid.Pack(), Timeout);
                if (rxMid != null)
                {
                    if (rxMid.Header.Mid == 65)
                    {
                        return (Mid0065)rxMid;
                    }
                }
                await Task.Delay(500);
            }
            return null;
        }
    }
}