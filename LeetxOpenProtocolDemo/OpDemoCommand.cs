using Leetx.OpenProtocol;
using OpenProtocolInterpreter.Alarm;
using OpenProtocolInterpreter.Curve;
using OpenProtocolInterpreter.Job;
using OpenProtocolInterpreter.Job.Advanced;
using OpenProtocolInterpreter.ParameterSet;
using OpenProtocolInterpreter.Tightening;
using OpenProtocolInterpreter.Time;
using OpenProtocolInterpreter.Tool;
using OpenProtocolInterpreter.Vin;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Leetx.OpenProtocolDemo
{
    partial class OpDemoViewModel
    {

        Leetx.OpenProtocol.OpClient client;

        public OpDemoViewModel()
        {
            client = new OpClient();
            client.PropertyChanged += Client_PropertyChanged;
            client.TightingProcessEvent += this.Client_TightingProcessEvent;
            client.TightingWriteEvent += Client_TightingWriteEvent;
            client.TightingReadEvent += Client_TightingReadEvent;
            client.TightingProcessExceptioneEvent += Client_TightingProcessExceptioneEvent;
        }

        private void Client_TightingProcessExceptioneEvent(string arg1, TightingProcessException arg2)
        {
             Console.WriteLine(arg2.Message + " " + arg1);
        }
    
        void addMessageItem(byte[] arg2,int flag=0)
        {
            var t = DateTime.Now.ToString("HH:mm:ss.ffff");
            App.Current.Dispatcher.InvokeAsync(() =>
            {
                Msgs.Add(new MessageItem()
                {
                    Flag = flag,
                    Buff = arg2,
                    Time = t
                });
            });
        }


        private void Client_TightingReadEvent(int arg1, byte[] arg2)
        {
            addMessageItem(arg2, int.Parse(Encoding.ASCII.GetString(arg2, 4, 4)));
        }

        private void Client_TightingWriteEvent(int arg1, byte[] arg2)
        {
            addMessageItem( arg2 );
        }

        /// <summary>
        /// 订阅结果处理
        /// </summary>
        /// <param name="arg1"> mid编号 </param>
        /// <param name="mid"> 订阅对象 </param>
        private void Client_TightingProcessEvent(int arg1, OpenProtocolInterpreter.Mid mid)
        {

        }

        private void Client_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            ConnectStatus = client.ConnnectStatus;
        }

        void Open(object para)
        {
            client.Open(this.IpAddr, this.Port);
        }
        bool CanOpen(object para)
        {
            return client.ConnnectStatus <= OpClient.ConnectStatusEnum.UnConnected;
        }
        public ICommand CommandOpenOp => new LeetxCommand(Open, CanOpen);

        /// <summary>
        /// 关闭OP连接
        /// </summary>
        public ICommand CommandCloseOp => new LeetxCommand((x) =>
        {
            client.Close();

        }, x =>
        {
            return client.ConnnectStatus != OpClient.ConnectStatusEnum.Disconnected;
        });
        /// <summary>
        /// 获取Pset列表,支持版本1
        /// </summary>
        public ICommand CommandGetPsetList => new LeetxCommand((x) =>
        {
            Task.Run(async () =>
            {
                var mid = (Mid0011) await client.SendMidWithResponse(new Mid0010(1));
                PsetIdList = mid.ParameterSets;
                if(PsetIdList.Count>0) Psetid = PsetIdList[0];
                else Psetid = 0;
            });

        }, x =>
        {
            return client.ConnnectStatus == OpClient.ConnectStatusEnum.Connected;
        });

        /// <summary>
        /// 获取指定Pset内容,支持版本1,2
        /// </summary>
        public ICommand CommandGetPset => new LeetxCommand((x) =>
        {
            client.SendMidWithResponse(new Mid0012(2) { ParameterSetId = Psetid });
        }, x =>
        {
            return client.ConnnectStatus == OpClient.ConnectStatusEnum.Connected && Psetid!=0;
        });

        /// <summary>
        /// 订阅当前Pset,支持版本1,2
        /// </summary>
        public ICommand CommandSubscribePset => new LeetxCommand((x) =>
        {
            client.SendMidWithResponse(new Mid0014(2));
        }, x =>
        {
            return client.ConnnectStatus == OpClient.ConnectStatusEnum.Connected;
        });

        /// <summary>
        /// 取消订阅当前Pset,支持版本1,2
        /// </summary>
        public ICommand CommandUnsubscribePset => new LeetxCommand((x) =>
        {
            client.SendMidWithResponse(new Mid0017());
        }, x =>
        {
            return client.ConnnectStatus == OpClient.ConnectStatusEnum.Connected;
        });

        /// <summary>
        /// 切换当前Pset,支持版本1
        /// </summary>
        public ICommand CommandChangeControllerCurPset => new LeetxCommand((x) =>
        {
            client.SendMidWithResponse(new Mid0018() { ParameterSetId = Psetid });
        }, x =>
        {
            return client.ConnnectStatus == OpClient.ConnectStatusEnum.Connected && Psetid != 0;
        });

        /// <summary>
        /// 获取可用的Job列表,支持版本1,2
        /// </summary>
        public ICommand CommandGetJobList => new LeetxCommand((x) =>
        {
            Task.Run(async () =>
            {
                var c =(Mid0031) await client.SendMidWithResponse(new Mid0030(2));
                JobList = c.JobIds;
                Jobid = JobList.Count >0 ? JobList[0] : 0;
            });

        }, x =>
        {
            return client.ConnnectStatus == OpClient.ConnectStatusEnum.Connected;
        });

        /// <summary>
        /// 获取指定Job信息
        /// </summary>
        public ICommand CommandGetJobInfo => new LeetxCommand((x) =>
        {
            client.SendMidWithResponse(new Mid0032(1) { JobId = this.Jobid });
        }, x =>
        {
            return client.ConnnectStatus == OpClient.ConnectStatusEnum.Connected && Jobid > 0;
        });

        /// <summary>
        /// 订阅Job,支持版本1,2  反馈 0035
        /// </summary>
        public ICommand CommandSubscribeJobInfo => new LeetxCommand((x) =>
        {
            client.SendMidWithResponse(new Mid0034(2));
        }, x =>
        {
            return client.ConnnectStatus == OpClient.ConnectStatusEnum.Connected;
        });

        /// <summary>
        /// 切换Job ,支持版本1
        /// </summary>
        public ICommand CommandSetJobId => new LeetxCommand((x) =>
        {
            client.SendMidWithResponse(new Mid0038(1) { JobId = this.Jobid });
        }, x =>
        {
            return client.ConnnectStatus == OpClient.ConnectStatusEnum.Connected && Jobid > 0;
        });

        /// <summary>
        /// 重启JOB,支持版本1
        /// </summary>
        public ICommand CommandRestartJob => new LeetxCommand((x) =>
        {
            client.SendMidWithResponse(new Mid0039(1) { JobId = this.Jobid });
        }, x =>
        {
            return client.ConnnectStatus == OpClient.ConnectStatusEnum.Connected && Jobid > 0;
        });

        /// <summary>
        /// 禁止工具使能,支持版本1
        /// </summary>
        public ICommand CommandDisableTools => new LeetxCommand((x) =>
        {
            client.SendMidWithResponse(new Mid0042(1));
        }, x =>
        {
            return client.ConnnectStatus == OpClient.ConnectStatusEnum.Connected;
        });

        /// <summary>
        ///  工具使能,支持版本1
        /// </summary>
        public ICommand CommandEnableTools => new LeetxCommand((x) =>
        {
            client.SendMidWithResponse(new Mid0043(1));
        }, x =>
        {
            return client.ConnnectStatus == OpClient.ConnectStatusEnum.Connected;
        });

        /// <summary>
        /// 修改Sn/VIN码,支持版本1
        /// </summary>
        public ICommand CommandModifyVN => new LeetxCommand((x) =>
        {
            client.SendMidWithResponse(new Mid0050() { VinNumber = this.SN });
        }, x =>
        {
            return client.ConnnectStatus == OpClient.ConnectStatusEnum.Connected ;
        });
        /// <summary>
        /// 修改多段 Sn/VIN码,支持版本1,目前仅支持单段
        /// </summary>
        public ICommand CommandModifyVN150 => new LeetxCommand((x) =>
        {
            client.SendMidWithResponse(new OpenProtocolInterpreter.MultipleIdentifiers.Mid0150() { IdentifierData = this.SN });
        }, x =>
        {
            return client.ConnnectStatus == OpClient.ConnectStatusEnum.Connected  ;
        });

        /// <summary>
        /// 订阅VN码,支持版本1,2
        /// </summary>
        public ICommand CommandSubscribeVN => new LeetxCommand((x) =>
        {
            client.SendMidWithResponse(new Mid0051(2));
        }, x =>
        {
            return client.ConnnectStatus == OpClient.ConnectStatusEnum.Connected;
        });

        /// <summary>
        /// 订阅结果,支持版本1,2,3
        /// </summary>
        public ICommand CommandSubscribeResult => new LeetxCommand((x) =>
        {
            client.SendMidWithResponse(new Mid0060(3));
        }, x =>
        {
            return client.ConnnectStatus == OpClient.ConnectStatusEnum.Connected;
        });

        /// <summary>
        /// 取消订阅结果,支持版本1,2,3
        /// </summary>
        public ICommand CommandUnsubscribeResult => new LeetxCommand((x) =>
        {
            client.SendMidWithResponse(new Mid0063(1));
        }, x =>
        {
            return client.ConnnectStatus == OpClient.ConnectStatusEnum.Connected;
        });

        /// <summary>
        /// 根据拧紧Id获取结果数据,支持版本1
        /// </summary>
        public ICommand CommandGetResultbyTid => new LeetxCommand((x) =>
        {
            client.SendMidWithResponse(new Mid0064() { TighteningId = this.Tid });
        }, x =>
        {
            return client.ConnnectStatus == OpClient.ConnectStatusEnum.Connected;
        });

        /// <summary>
        ///  订阅报警;支持版本1
        /// </summary>
        public ICommand CommandSubscribeAlarm => new LeetxCommand((x) =>
        {
            client.SendMidWithResponse(new Mid0070() );
        }, x =>
        {
            return client.ConnnectStatus == OpClient.ConnectStatusEnum.Connected;
        });

        /// <summary>
        ///  取消报警订阅;支持版本1
        /// </summary>
        public ICommand CommandUnsubscribeAlarm => new LeetxCommand((x) =>
        {
            client.SendMidWithResponse(new Mid0073());
        }, x =>
        {
            return client.ConnnectStatus == OpClient.ConnectStatusEnum.Connected;
        });


        /// <summary>
        ///  获取时间;支持版本1
        /// </summary>
        public ICommand CommandGetControllerTime => new LeetxCommand((x) =>
        {
            client.SendMidWithResponse(new Mid0080());
        }, x =>
        {
            return client.ConnnectStatus == OpClient.ConnectStatusEnum.Connected;
        });

        /// <summary>
        ///  停止JOb;支持版本1
        /// </summary>
        public ICommand CommandAbortJob => new LeetxCommand((x) =>
        {
            client.SendMidWithResponse(new Mid0127());
        }, x =>
        {
            return client.ConnnectStatus == OpClient.ConnectStatusEnum.Connected;
        });

        /// <summary>
        /// 订阅分步结果,支持版本1
        /// </summary>
        public ICommand CommandSubscribePhaseResult => new LeetxCommand((x) =>
        {
            client.SendMidWithResponse(new Mid7402());
        }, x =>
        {
            return client.ConnnectStatus == OpClient.ConnectStatusEnum.Connected;
        });

        /// <summary>
        /// 取消分步结果订阅,支持版本1
        /// </summary>
        public ICommand CommandUnsubscribePhaseResult => new LeetxCommand((x) =>
        {
            client.SendMidWithResponse(new Mid7403());
        }, x =>
        {
            return client.ConnnectStatus == OpClient.ConnectStatusEnum.Connected;
        });

        /// <summary>
        /// 订阅拧紧曲线,支持版本1,2
        /// </summary>
        public ICommand CommandSubscribeCurve => new LeetxCommand((x) =>
        {
            client.SendMidWithResponse(new Mid7408(2));
        }, x =>
        {
            return client.ConnnectStatus == OpClient.ConnectStatusEnum.Connected;
        });

        /// <summary>
        /// 取消拧紧曲线订阅,支持版本1
        /// </summary>
        public ICommand CommandUnsubscribeCurve => new LeetxCommand((x) =>
        {
            client.SendMidWithResponse(new Mid7409());
        }, x =>
        {
            return client.ConnnectStatus == OpClient.ConnectStatusEnum.Connected;
        });


    }
}
