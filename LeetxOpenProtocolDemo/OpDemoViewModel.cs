using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Leetx.OpenProtocolDemo
{
    internal partial class OpDemoViewModel : NotifyProperty
    {


        public List<int> PsetIdList
		{
			get { return m_PsetIdList; }
			set { m_PsetIdList = value; OnPropertyChanged(); }
		}
		private List<int>  m_PsetIdList;



		public OpenProtocol.OpClient.ConnectStatusEnum ConnectStatus
		{
			get { return m_IsConnected; }
			set { m_IsConnected = value; OnPropertyChanged(); }
		}
		private OpenProtocol.OpClient.ConnectStatusEnum m_IsConnected;


		public ObservableCollection<MessageItem> Msgs
		{
			get {  return m_Msgs;}
			set {  m_Msgs = value; OnPropertyChanged(); }
		}
		private ObservableCollection<MessageItem> m_Msgs = new ObservableCollection<MessageItem>();


		public string SendBuff
		{
			get { return m_SendBuff; }
			set { m_SendBuff = value; OnPropertyChanged(); }
		}
		private string m_SendBuff;


		public MessageItem SelectedItem
		{
			get { return m_SelectedItem; }
			set { m_SelectedItem = value; OnPropertyChanged(); }
		}
		private MessageItem m_SelectedItem;



		public int Psetid
		{
			get { return m_Pstid; }
			set { m_Pstid = value; OnPropertyChanged(); }
		}
		private int m_Pstid;



		public List<int> PsetList
		{
			get { return _PsetList; }
			set { _PsetList = value; OnPropertyChanged(); }
		}
		private List<int> _PsetList;


		public List<int> JobList
		{
			get { return _JobList; }
			set { _JobList = value; OnPropertyChanged(); }
		}
		private List<int> _JobList;

		public int Jobid
		{
			get { return _Jobid; }
			set { _Jobid = value; OnPropertyChanged(); }
		}
		private int _Jobid;


		public string SN
        {
			get { return m_SN; }
			set { m_SN = value; OnPropertyChanged(); }
		}
		private string m_SN="";


		public long Tid
        {
			get { return m_Tid; }
			set { m_Tid = value; OnPropertyChanged(); }
		}
		private long m_Tid;


		public string IpAddr
		{
			get { return _IpAddr; }
			set { _IpAddr = value; OnPropertyChanged(); }
		}
		private string _IpAddr= "192.168.20.145";


		public int Port
		{
			get { return _Port; }
			set { _Port = value; OnPropertyChanged(); }
		}
		private int _Port=9101;


	}
}
