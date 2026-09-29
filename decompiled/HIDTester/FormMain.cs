using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using HID;

namespace HIDTester;

public class FormMain : Form
{
	public class KeyParam
	{
		public static byte[] Data_Send_Buff = new byte[65];

		public static byte KeySet_KeyNum = 0;

		public static byte KeyType_Num = 1;

		public static byte KeyGroupCharNum = 2;

		public static byte KeySet_KeyValNum = 3;

		public static byte Key_Fun_Num = 4;

		public static byte KEY_Char_Num = 5;

		public static byte PageBet_Inte_Cmd = 0;

		public static string[] KeyChar = new string[100];

		public static string[] FunKeyChar = new string[100];

		public static byte FunKEY_Char_Num = 0;

		public static byte ReportID = 0;

		public static byte KEY_Cur_Layer = 1;

		public static byte KEY_Cur_Page = 1;

		public static byte Language_Set = 0;
	}

	private ushort WriteMode = 1;

	private Hid myHid = new Hid();

	private IntPtr myHidPtr;

	private AutoSizeFormClass asc = new AutoSizeFormClass();

	private HidLib myHidLib = new HidLib();

	private byte[] RecDataBuffer = new byte[90];

	private int Display_Dowlaod_Char_TM;

	private readonly Color menuBackColor = Color.FromArgb(200, 200, 169);

	private readonly Color menuMouserOverColor = Color.FromArgb(230, 206, 172);

	private readonly string[] menuStr = new string[6] { "KEY", "Ctrl Shift Alt", "Multimedia", "LED", "Mouse", "" };

	private Dictionary<string, Form> menuDic = new Dictionary<string, Form>();

	private IContainer components;

	private Label stateLabel;

	private ToolStripMenuItem fdToolStripMenuItem;

	private Button Download;

	private Button KEY1;

	private Button KEY2;

	private Button KEY3;

	private Button KEY4;

	private Button K1_Left;

	private Button K1_Centre;

	private Button K1_Right;

	private TextBox SetText;

	private Button Key_Clear;

	private Button KEY8;

	private Button KEY7;

	private Button KEY6;

	private Button KEY5;

	private Button KEY12;

	private Button KEY11;

	private Button KEY10;

	private Button KEY9;

	private Button KEY16;

	private Button KEY15;

	private Button KEY14;

	private Button KEY13;

	private Button K2_Right;

	private Button K2_Centre;

	private Button K2_Left;

	private SplitContainer splitContainer1;

	private FlowLayoutPanel flowLayoutPanel1;

	private TextBox SetFunText;

	private Button K3_Left;

	private Button K3_Centre;

	private Button K3_Right;

	private FlowLayoutPanel flowLayoutPanel_LayerFun;

	private PictureBox pictureBox1;

	private Label label_Dowload_Dsp;

	public FormMain()
	{
		InitializeComponent();
		myHid.DataReceived += myhid_DataReceived;
		myHid.DeviceRemoved += myhid_DeviceRemoved;
		MenuList();
		KEY_Colour_Init();
		Time_Display_Text();
		Hide_Dowload_Text();
		LayerFunList();
		Lanuage_Set_EN();
	}

	private void MenuList()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		for (int i = 0; i < menuStr.Length; i++)
		{
			Button val = new Button();
			((Control)val).Text = menuStr[i];
			((ButtonBase)val).FlatStyle = (FlatStyle)0;
			((ButtonBase)val).FlatAppearance.MouseOverBackColor = menuMouserOverColor;
			((ButtonBase)val).FlatAppearance.BorderSize = 0;
			((Control)val).Width = ((Control)flowLayoutPanel1).Width;
			((Control)val).Height = 40;
			Padding margin = default(Padding);
			((Padding)(ref margin)).All = 0;
			((Control)val).Margin = margin;
			((Control)val).MouseClick += new MouseEventHandler(Btn_OnClick);
			((Control)flowLayoutPanel1).Controls.Add((Control)(object)val);
			((Control)flowLayoutPanel1).BackColor = menuBackColor;
		}
		BasicKeys basicKeys = new BasicKeys();
		((Control)basicKeys).Parent = (Control)(object)splitContainer1.Panel2;
		((Control)basicKeys).Dock = (DockStyle)5;
		((Control)basicKeys).Show();
		KeyParam.KEY_Cur_Page = 1;
	}

	private void LayerFunList()
	{
		LayerFun layerFun = new LayerFun();
		((Control)flowLayoutPanel_LayerFun).Controls.Add((Control)(object)layerFun);
		((Control)layerFun).Show();
	}

	private void Btn_OnClick(object sender, MouseEventArgs e)
	{
		switch (((Control)((sender is Button) ? sender : null)).Text)
		{
		case "KEY":
		{
			((Control)splitContainer1.Panel2).Controls.Clear();
			BasicKeys basicKeys = new BasicKeys();
			((Control)basicKeys).Parent = (Control)(object)splitContainer1.Panel2;
			((Control)basicKeys).Dock = (DockStyle)5;
			((Control)basicKeys).Show();
			KeyParam.KEY_Cur_Page = 1;
			break;
		}
		case "Ctrl Shift Alt":
		{
			((Control)splitContainer1.Panel2).Controls.Clear();
			FunKey funKey = new FunKey();
			((Control)funKey).Parent = (Control)(object)splitContainer1.Panel2;
			((Control)funKey).Dock = (DockStyle)5;
			((Control)funKey).Show();
			KeyParam.KEY_Cur_Page = 2;
			break;
		}
		case "Multimedia":
		{
			((Control)splitContainer1.Panel2).Controls.Clear();
			MULKey mULKey = new MULKey();
			((Control)mULKey).Parent = (Control)(object)splitContainer1.Panel2;
			((Control)mULKey).Dock = (DockStyle)5;
			((Control)mULKey).Show();
			KeyParam.KEY_Cur_Page = 3;
			break;
		}
		case "LED":
		{
			((Control)splitContainer1.Panel2).Controls.Clear();
			LEDkey lEDkey = new LEDkey();
			((Control)lEDkey).Parent = (Control)(object)splitContainer1.Panel2;
			((Control)lEDkey).Dock = (DockStyle)5;
			((Control)lEDkey).Show();
			Key_Clear_Fun();
			KeyParam.KEY_Cur_Page = 4;
			break;
		}
		case "Mouse":
		{
			((Control)splitContainer1.Panel2).Controls.Clear();
			MouseKey mouseKey = new MouseKey();
			((Control)mouseKey).Parent = (Control)(object)splitContainer1.Panel2;
			((Control)mouseKey).Dock = (DockStyle)5;
			((Control)mouseKey).Show();
			Key_Clear_Fun();
			KeyParam.KEY_Cur_Page = 5;
			break;
		}
		}
	}

	private void Show_Dowload_Text()
	{
		Display_Dowlaod_Char_TM = 20;
		((Control)label_Dowload_Dsp).Show();
	}

	private void Hide_Dowload_Text()
	{
		((Control)label_Dowload_Dsp).Hide();
	}

	private void AutoCheckUsb()
	{
		if (WriteMode == 0)
		{
			if (!myHid.Opened)
			{
				ushort vID = 4489;
				ushort pID = 34960;
				if ((int)(myHidPtr = myHid.OpenDevice(vID, pID)) != -1)
				{
					KeyBoardVersion_Check();
					((Control)stateLabel).Text = "Connected";
					Label obj = stateLabel;
					Color backColor = (((Control)stateLabel).BackColor = Color.Green);
					((Control)obj).BackColor = backColor;
				}
				else
				{
					((Control)stateLabel).Text = "Not Connected";
					Label obj2 = stateLabel;
					Color backColor = (((Control)stateLabel).BackColor = Color.Red);
					((Control)obj2).BackColor = backColor;
				}
			}
			else
			{
				((Control)stateLabel).Text = "Connected";
				Label obj3 = stateLabel;
				Color backColor = (((Control)stateLabel).BackColor = Color.Green);
				((Control)obj3).BackColor = backColor;
			}
		}
		else
		{
			if (WriteMode != 1)
			{
				return;
			}
			if (!myHidLib.Get_Dev_Sta())
			{
				if (myHidLib.Connect_Device())
				{
					KeyBoardVersion_Check();
					((Control)stateLabel).Text = "Connected";
					Label obj4 = stateLabel;
					Color backColor = (((Control)stateLabel).BackColor = Color.Green);
					((Control)obj4).BackColor = backColor;
				}
				else
				{
					((Control)stateLabel).Text = "Not Connected";
					Label obj5 = stateLabel;
					Color backColor = (((Control)stateLabel).BackColor = Color.Red);
					((Control)obj5).BackColor = backColor;
				}
			}
			else if (myHidLib.Check_Disconnect())
			{
				((Control)stateLabel).Text = "Connected";
				Label obj6 = stateLabel;
				Color backColor = (((Control)stateLabel).BackColor = Color.Green);
				((Control)obj6).BackColor = backColor;
			}
			else
			{
				((Control)stateLabel).Text = "Not Connected";
				Label obj7 = stateLabel;
				Color backColor = (((Control)stateLabel).BackColor = Color.Red);
				((Control)obj7).BackColor = backColor;
			}
		}
	}

	protected void myhid_DataReceived(object sender, report e)
	{
		RecDataBuffer = e.reportBuff;
		new ASCIIEncoding().GetString(RecDataBuffer);
	}

	protected void myhid_DeviceRemoved(object sender, EventArgs e)
	{
		((Control)stateLabel).Text = "设备移除";
		Label obj = stateLabel;
		Color backColor = (((Control)stateLabel).BackColor = Color.Red);
		((Control)obj).BackColor = backColor;
	}

	private void aboutMenu_Click(object sender, EventArgs e)
	{
		Process.Start("http://www.cnblogs.com/hebaichuanyeah/p/4504855.html");
	}

	private void Time_Display_Text()
	{
		System.Timers.Timer timer = new System.Timers.Timer();
		timer.Enabled = true;
		timer.Interval = 30.0;
		timer.Start();
		timer.Elapsed += Timer1_Elapsed;
	}

	private void Timer1_Elapsed(object sender, ElapsedEventArgs e)
	{
		AutoCheckUsb();
		if (KeyParam.PageBet_Inte_Cmd != 0 && KeyParam.PageBet_Inte_Cmd == 1)
		{
			KeyParam.PageBet_Inte_Cmd = 0;
			Key_Clear_Fun();
		}
		if (Display_Dowlaod_Char_TM-- == 0)
		{
			Hide_Dowload_Text();
		}
		if (KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] != 0)
		{
			string text = "";
			string text2 = "";
			text += KeyParam.KeyChar[0];
			text += " ";
			text += KeyParam.KeyChar[2];
			text += " ";
			text += KeyParam.KeyChar[4];
			text += " ";
			text += KeyParam.KeyChar[6];
			text += " ";
			text += KeyParam.KeyChar[8];
			((Control)SetText).Text = text;
			text2 += KeyParam.FunKeyChar[0];
			text2 += " ";
			text2 += KeyParam.FunKeyChar[1];
			text2 += " ";
			text2 += KeyParam.FunKeyChar[2];
			text2 += " ";
			text2 += KeyParam.FunKeyChar[3];
			((Control)SetFunText).Text = text2;
		}
		else
		{
			string text3 = "";
			string text4 = "";
			((Control)SetText).Text = text3;
			((Control)SetFunText).Text = text4;
		}
	}

	private void KeyBoardVersion_Check()
	{
		byte[] array = new byte[65];
		KeyParam.ReportID = 0;
		array[0] = 0;
		array[1] = 0;
		if (WriteMode == 0)
		{
			report r = new report(KeyParam.ReportID, array);
			if ((byte)myHid.Write(r) == 0)
			{
				KeyParam.ReportID = 0;
				return;
			}
			KeyParam.ReportID = 2;
			r = new report(KeyParam.ReportID, array);
			if ((byte)myHid.Write(r) == 0)
			{
				KeyParam.ReportID = 2;
			}
			else
			{
				KeyParam.ReportID = 3;
			}
		}
		else
		{
			if (WriteMode != 1)
			{
				return;
			}
			KeyParam.ReportID = 3;
			if (myHidLib.WriteDevice(KeyParam.ReportID, array))
			{
				KeyParam.ReportID = 3;
				return;
			}
			KeyParam.ReportID = 0;
			if (myHidLib.WriteDevice(KeyParam.ReportID, array))
			{
				KeyParam.ReportID = 0;
				return;
			}
			KeyParam.ReportID = 2;
			if (myHidLib.WriteDevice(KeyParam.ReportID, array))
			{
				KeyParam.ReportID = 2;
			}
		}
	}

	private void Send_WriteFlash_Cmd()
	{
		byte[] array = new byte[65];
		array[0] = 170;
		array[1] = 170;
		if (WriteMode == 0)
		{
			report r = new report(KeyParam.ReportID, array);
			if ((byte)myHid.Write(r) == 0)
			{
				if (KeyParam.Language_Set == 0)
				{
					((Control)label_Dowload_Dsp).Text = "Download success";
				}
				else if (KeyParam.Language_Set == 1)
				{
					((Control)label_Dowload_Dsp).Text = "下载成功";
				}
				Label obj = label_Dowload_Dsp;
				Color backColor = (((Control)label_Dowload_Dsp).BackColor = Color.Green);
				((Control)obj).BackColor = backColor;
				Show_Dowload_Text();
			}
			else
			{
				if (KeyParam.Language_Set == 0)
				{
					((Control)label_Dowload_Dsp).Text = "Download failed";
				}
				else if (KeyParam.Language_Set == 1)
				{
					((Control)label_Dowload_Dsp).Text = "下载失败";
				}
				Label obj2 = label_Dowload_Dsp;
				Color backColor = (((Control)label_Dowload_Dsp).BackColor = Color.Red);
				((Control)obj2).BackColor = backColor;
				Show_Dowload_Text();
			}
		}
		else
		{
			if (WriteMode != 1)
			{
				return;
			}
			if (myHidLib.WriteDevice(KeyParam.ReportID, array))
			{
				if (KeyParam.Language_Set == 0)
				{
					((Control)label_Dowload_Dsp).Text = "Download success";
				}
				else if (KeyParam.Language_Set == 1)
				{
					((Control)label_Dowload_Dsp).Text = "下载成功";
				}
				Label obj3 = label_Dowload_Dsp;
				Color backColor = (((Control)label_Dowload_Dsp).BackColor = Color.Green);
				((Control)obj3).BackColor = backColor;
				Show_Dowload_Text();
			}
			else
			{
				if (KeyParam.Language_Set == 0)
				{
					((Control)label_Dowload_Dsp).Text = "Download failed";
				}
				else if (KeyParam.Language_Set == 1)
				{
					((Control)label_Dowload_Dsp).Text = "下载失败";
				}
				Label obj4 = label_Dowload_Dsp;
				Color backColor = (((Control)label_Dowload_Dsp).BackColor = Color.Red);
				((Control)obj4).BackColor = backColor;
				Show_Dowload_Text();
			}
		}
	}

	private void Send_WriteFlashLED_Cmd()
	{
		byte[] array = new byte[65];
		array[0] = 170;
		array[1] = 161;
		if (WriteMode == 0)
		{
			report r = new report(KeyParam.ReportID, array);
			if ((byte)myHid.Write(r) == 0)
			{
				if (KeyParam.Language_Set == 0)
				{
					((Control)label_Dowload_Dsp).Text = "Download success";
				}
				else if (KeyParam.Language_Set == 1)
				{
					((Control)label_Dowload_Dsp).Text = "下载成功";
				}
				Label obj = label_Dowload_Dsp;
				Color backColor = (((Control)label_Dowload_Dsp).BackColor = Color.Green);
				((Control)obj).BackColor = backColor;
				Show_Dowload_Text();
			}
			else
			{
				if (KeyParam.Language_Set == 0)
				{
					((Control)label_Dowload_Dsp).Text = "Download failed";
				}
				else if (KeyParam.Language_Set == 1)
				{
					((Control)label_Dowload_Dsp).Text = "下载失败";
				}
				Label obj2 = label_Dowload_Dsp;
				Color backColor = (((Control)label_Dowload_Dsp).BackColor = Color.Red);
				((Control)obj2).BackColor = backColor;
				Show_Dowload_Text();
			}
		}
		else
		{
			if (WriteMode != 1)
			{
				return;
			}
			if (myHidLib.WriteDevice(KeyParam.ReportID, array))
			{
				if (KeyParam.Language_Set == 0)
				{
					((Control)label_Dowload_Dsp).Text = "Download success";
				}
				else if (KeyParam.Language_Set == 1)
				{
					((Control)label_Dowload_Dsp).Text = "下载成功";
				}
				Label obj3 = label_Dowload_Dsp;
				Color backColor = (((Control)label_Dowload_Dsp).BackColor = Color.Green);
				((Control)obj3).BackColor = backColor;
				Show_Dowload_Text();
			}
			else
			{
				if (KeyParam.Language_Set == 0)
				{
					((Control)label_Dowload_Dsp).Text = "Download failed";
				}
				else if (KeyParam.Language_Set == 1)
				{
					((Control)label_Dowload_Dsp).Text = "下载失败";
				}
				Label obj4 = label_Dowload_Dsp;
				Color backColor = (((Control)label_Dowload_Dsp).BackColor = Color.Red);
				((Control)obj4).BackColor = backColor;
				Show_Dowload_Text();
			}
		}
	}

	private void Send_SwLayer()
	{
		byte[] array = new byte[65];
		array[0] = 161;
		array[1] = KeyParam.KEY_Cur_Layer;
		if (array[1] == 0)
		{
			array[1] = 1;
		}
		if (WriteMode == 0)
		{
			report r = new report(KeyParam.ReportID, array);
			_ = (byte)myHid.Write(r);
		}
		else if (WriteMode == 1)
		{
			myHidLib.WriteDevice(KeyParam.ReportID, array);
		}
	}

	private void Download_Click(object sender, EventArgs e)
	{
		byte b = 0;
		byte[] array = new byte[65];
		if (!myHidLib.Get_Dev_Sta())
		{
			return;
		}
		array[0] = KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum];
		if (array[0] == 0)
		{
			return;
		}
		if (KeyParam.ReportID == 0)
		{
			array[1] = (KeyParam.Data_Send_Buff[KeyParam.KeyType_Num] &= 15);
		}
		else
		{
			Send_SwLayer();
			array[1] = KeyParam.KEY_Cur_Layer;
			array[1] <<= 4;
			array[1] |= KeyParam.Data_Send_Buff[KeyParam.KeyType_Num];
		}
		if ((KeyParam.Data_Send_Buff[KeyParam.KeyType_Num] & 0xF) == 1)
		{
			array[2] = KeyParam.Data_Send_Buff[KeyParam.KeyGroupCharNum];
			for (b = 0; b <= KeyParam.Data_Send_Buff[KeyParam.KeyGroupCharNum]; b++)
			{
				array[3] = b;
				switch (b)
				{
				case 0:
					array[4] = KeyParam.Data_Send_Buff[4];
					array[5] = 0;
					break;
				case 1:
					array[4] = KeyParam.Data_Send_Buff[4];
					array[5] = KeyParam.Data_Send_Buff[5];
					break;
				case 2:
					array[4] = KeyParam.Data_Send_Buff[6];
					array[5] = KeyParam.Data_Send_Buff[7];
					break;
				case 3:
					array[4] = KeyParam.Data_Send_Buff[8];
					array[5] = KeyParam.Data_Send_Buff[9];
					break;
				case 4:
					array[4] = KeyParam.Data_Send_Buff[10];
					array[5] = KeyParam.Data_Send_Buff[11];
					break;
				case 5:
					array[4] = KeyParam.Data_Send_Buff[12];
					array[5] = KeyParam.Data_Send_Buff[13];
					break;
				}
				if (WriteMode == 0)
				{
					report r = new report(KeyParam.ReportID, array);
					myHid.Write(r);
				}
				else if (WriteMode == 1)
				{
					myHidLib.WriteDevice(KeyParam.ReportID, array);
				}
			}
			Send_WriteFlash_Cmd();
		}
		else if ((KeyParam.Data_Send_Buff[KeyParam.KeyType_Num] & 0xF) == 2)
		{
			array[2] = KeyParam.Data_Send_Buff[5];
			array[3] = KeyParam.Data_Send_Buff[6];
			if (WriteMode == 0)
			{
				report r = new report(KeyParam.ReportID, array);
				myHid.Write(r);
			}
			else if (WriteMode == 1)
			{
				myHidLib.WriteDevice(KeyParam.ReportID, array);
			}
			Send_WriteFlash_Cmd();
		}
		else if ((KeyParam.Data_Send_Buff[KeyParam.KeyType_Num] & 0xF) == 8)
		{
			array[2] = KeyParam.Data_Send_Buff[2];
			if (WriteMode == 0)
			{
				report r = new report(KeyParam.ReportID, array);
				myHid.Write(r);
			}
			else if (WriteMode == 1)
			{
				myHidLib.WriteDevice(KeyParam.ReportID, array);
			}
			Send_WriteFlashLED_Cmd();
		}
		else if ((KeyParam.Data_Send_Buff[KeyParam.KeyType_Num] & 0xF) == 3)
		{
			array[2] = KeyParam.Data_Send_Buff[5];
			array[3] = KeyParam.Data_Send_Buff[6];
			array[4] = KeyParam.Data_Send_Buff[7];
			array[5] = KeyParam.Data_Send_Buff[8];
			array[6] = KeyParam.Data_Send_Buff[9];
			if (WriteMode == 0)
			{
				report r = new report(KeyParam.ReportID, array);
				myHid.Write(r);
			}
			else if (WriteMode == 1)
			{
				myHidLib.WriteDevice(KeyParam.ReportID, array);
			}
			Send_WriteFlash_Cmd();
		}
	}

	private void Key_Clear_Click(object sender, EventArgs e)
	{
		Key_Clear_Fun();
	}

	private void Key_Clear_Fun()
	{
		Clear_Key_Char();
		Set_Key_Init();
		KEY_Colour_Init();
		KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 0;
	}

	private void Clear_Key_Char()
	{
		int num = 0;
		for (num = 0; num < 100; num++)
		{
			KeyParam.KeyChar[num] = null;
			KeyParam.FunKeyChar[num] = null;
			KeyParam.FunKEY_Char_Num = 0;
		}
	}

	private void Set_Key_Init()
	{
		KeyParam.KEY_Char_Num = 5;
		KeyParam.Data_Send_Buff[KeyParam.KeyType_Num] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KeyGroupCharNum] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyValNum] = 0;
		KeyParam.Data_Send_Buff[KeyParam.Key_Fun_Num] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 1] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 2] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 3] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 4] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 5] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 6] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 7] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 8] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 9] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 10] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 11] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 12] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 13] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 14] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 15] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 16] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 17] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 18] = 0;
	}

	private void KEY_Colour_Init()
	{
		int red = 152;
		int green = 251;
		int blue = 152;
		((Control)KEY1).BackColor = Color.FromArgb(red, green, blue);
		((Control)KEY2).BackColor = Color.FromArgb(red, green, blue);
		((Control)KEY3).BackColor = Color.FromArgb(red, green, blue);
		((Control)KEY4).BackColor = Color.FromArgb(red, green, blue);
		((Control)KEY5).BackColor = Color.FromArgb(red, green, blue);
		((Control)KEY6).BackColor = Color.FromArgb(red, green, blue);
		((Control)KEY7).BackColor = Color.FromArgb(red, green, blue);
		((Control)KEY8).BackColor = Color.FromArgb(red, green, blue);
		((Control)KEY9).BackColor = Color.FromArgb(red, green, blue);
		((Control)KEY10).BackColor = Color.FromArgb(red, green, blue);
		((Control)KEY11).BackColor = Color.FromArgb(red, green, blue);
		((Control)KEY12).BackColor = Color.FromArgb(red, green, blue);
		((Control)KEY13).BackColor = Color.FromArgb(red, green, blue);
		((Control)KEY14).BackColor = Color.FromArgb(red, green, blue);
		((Control)KEY15).BackColor = Color.FromArgb(red, green, blue);
		((Control)KEY16).BackColor = Color.FromArgb(red, green, blue);
		((Control)K1_Left).BackColor = Color.FromArgb(red, green, blue);
		((Control)K1_Centre).BackColor = Color.FromArgb(red, green, blue);
		((Control)K1_Right).BackColor = Color.FromArgb(red, green, blue);
		((Control)K2_Left).BackColor = Color.FromArgb(red, green, blue);
		((Control)K2_Centre).BackColor = Color.FromArgb(red, green, blue);
		((Control)K2_Right).BackColor = Color.FromArgb(red, green, blue);
		((Control)K3_Left).BackColor = Color.FromArgb(red, green, blue);
		((Control)K3_Centre).BackColor = Color.FromArgb(red, green, blue);
		((Control)K3_Right).BackColor = Color.FromArgb(red, green, blue);
	}

	private void KEY1_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 1;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			((Control)KEY1).BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void KEY2_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 2;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			((Control)KEY2).BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void KEY3_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 3;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			((Control)KEY3).BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void KEY4_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 4;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			((Control)KEY4).BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void KEY5_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 5;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			((Control)KEY5).BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void KEY6_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 6;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			((Control)KEY6).BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void KEY7_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 7;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			((Control)KEY7).BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void KEY8_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 8;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			((Control)KEY8).BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void KEY9_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 9;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			((Control)KEY9).BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void KEY10_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 10;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			((Control)KEY10).BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void KEY11_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 11;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			((Control)KEY11).BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void KEY12_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 12;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			((Control)KEY12).BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void K1_Left_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 13;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			((Control)K1_Left).BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void K1_Centre_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 14;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			((Control)K1_Centre).BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void K1_Right_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 15;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			((Control)K1_Right).BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void K2_Left_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 16;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			((Control)K2_Left).BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void K2_Centre_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 17;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			((Control)K2_Centre).BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void K2_Right_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 18;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			((Control)K2_Right).BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void FormMain_Load(object sender, EventArgs e)
	{
		asc.controllInitializeSize((Control)(object)this);
	}

	private void MainPage_SizeChanged(object sender, EventArgs e)
	{
		asc.controlAutoSize((Control)(object)this);
	}

	private void Lanuage_Set_ZH()
	{
		Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-CN");
		ApplyResource();
	}

	private void Lanuage_Set_EN()
	{
		Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
		ApplyResource();
	}

	private void ApplyResource()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormMain));
		foreach (Control item in (ArrangedElementCollection)((Control)this).Controls)
		{
			Control val = item;
			componentResourceManager.ApplyResources(val, val.Name);
		}
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
		componentResourceManager.ApplyResources(this, "$this");
	}

	private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
	{
	}

	private void SetFunText_TextChanged(object sender, EventArgs e)
	{
	}

	private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
	{
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void InitializeComponent()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Expected O, but got Unknown
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormMain));
		splitContainer1 = new SplitContainer();
		flowLayoutPanel1 = new FlowLayoutPanel();
		stateLabel = new Label();
		fdToolStripMenuItem = new ToolStripMenuItem();
		Download = new Button();
		KEY1 = new Button();
		KEY2 = new Button();
		KEY3 = new Button();
		KEY4 = new Button();
		K1_Left = new Button();
		K1_Centre = new Button();
		K1_Right = new Button();
		SetText = new TextBox();
		Key_Clear = new Button();
		KEY8 = new Button();
		KEY7 = new Button();
		KEY6 = new Button();
		KEY5 = new Button();
		KEY12 = new Button();
		KEY11 = new Button();
		KEY10 = new Button();
		KEY9 = new Button();
		KEY16 = new Button();
		KEY15 = new Button();
		KEY14 = new Button();
		KEY13 = new Button();
		K2_Right = new Button();
		K2_Centre = new Button();
		K2_Left = new Button();
		SetFunText = new TextBox();
		K3_Left = new Button();
		K3_Centre = new Button();
		K3_Right = new Button();
		flowLayoutPanel_LayerFun = new FlowLayoutPanel();
		pictureBox1 = new PictureBox();
		label_Dowload_Dsp = new Label();
		((ISupportInitialize)splitContainer1).BeginInit();
		((Control)splitContainer1).SuspendLayout();
		((ISupportInitialize)pictureBox1).BeginInit();
		((Control)this).SuspendLayout();
		componentResourceManager.ApplyResources(splitContainer1, "splitContainer1");
		((Control)splitContainer1).Name = "splitContainer1";
		((Control)splitContainer1.Panel1).Paint += new PaintEventHandler(splitContainer1_Panel1_Paint);
		((Control)splitContainer1.Panel2).Paint += new PaintEventHandler(splitContainer1_Panel2_Paint);
		componentResourceManager.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
		((Control)flowLayoutPanel1).Name = "flowLayoutPanel1";
		componentResourceManager.ApplyResources(stateLabel, "stateLabel");
		((Control)stateLabel).BackColor = SystemColors.ActiveCaption;
		((Control)stateLabel).Name = "stateLabel";
		((ToolStripItem)fdToolStripMenuItem).Name = "fdToolStripMenuItem";
		componentResourceManager.ApplyResources(fdToolStripMenuItem, "fdToolStripMenuItem");
		componentResourceManager.ApplyResources(Download, "Download");
		((Control)Download).Name = "Download";
		((ButtonBase)Download).UseVisualStyleBackColor = true;
		((Control)Download).Click += Download_Click;
		componentResourceManager.ApplyResources(KEY1, "KEY1");
		((Control)KEY1).Name = "KEY1";
		((ButtonBase)KEY1).UseVisualStyleBackColor = true;
		((Control)KEY1).Click += KEY1_Click;
		componentResourceManager.ApplyResources(KEY2, "KEY2");
		((Control)KEY2).Name = "KEY2";
		((ButtonBase)KEY2).UseVisualStyleBackColor = true;
		((Control)KEY2).Click += KEY2_Click;
		componentResourceManager.ApplyResources(KEY3, "KEY3");
		((Control)KEY3).Name = "KEY3";
		((ButtonBase)KEY3).UseVisualStyleBackColor = true;
		((Control)KEY3).Click += KEY3_Click;
		componentResourceManager.ApplyResources(KEY4, "KEY4");
		((Control)KEY4).Name = "KEY4";
		((ButtonBase)KEY4).UseVisualStyleBackColor = true;
		((Control)KEY4).Click += KEY4_Click;
		componentResourceManager.ApplyResources(K1_Left, "K1_Left");
		((Control)K1_Left).Name = "K1_Left";
		((ButtonBase)K1_Left).UseVisualStyleBackColor = true;
		((Control)K1_Left).Click += K1_Left_Click;
		componentResourceManager.ApplyResources(K1_Centre, "K1_Centre");
		((Control)K1_Centre).Name = "K1_Centre";
		((ButtonBase)K1_Centre).UseVisualStyleBackColor = true;
		((Control)K1_Centre).Click += K1_Centre_Click;
		componentResourceManager.ApplyResources(K1_Right, "K1_Right");
		((Control)K1_Right).Name = "K1_Right";
		((ButtonBase)K1_Right).UseVisualStyleBackColor = true;
		((Control)K1_Right).Click += K1_Right_Click;
		componentResourceManager.ApplyResources(SetText, "SetText");
		((Control)SetText).Name = "SetText";
		componentResourceManager.ApplyResources(Key_Clear, "Key_Clear");
		((Control)Key_Clear).Name = "Key_Clear";
		((ButtonBase)Key_Clear).UseVisualStyleBackColor = true;
		((Control)Key_Clear).Click += Key_Clear_Click;
		componentResourceManager.ApplyResources(KEY8, "KEY8");
		((Control)KEY8).Name = "KEY8";
		((ButtonBase)KEY8).UseVisualStyleBackColor = true;
		((Control)KEY8).Click += KEY8_Click;
		componentResourceManager.ApplyResources(KEY7, "KEY7");
		((Control)KEY7).Name = "KEY7";
		((ButtonBase)KEY7).UseVisualStyleBackColor = true;
		((Control)KEY7).Click += KEY7_Click;
		componentResourceManager.ApplyResources(KEY6, "KEY6");
		((Control)KEY6).Name = "KEY6";
		((ButtonBase)KEY6).UseVisualStyleBackColor = true;
		((Control)KEY6).Click += KEY6_Click;
		componentResourceManager.ApplyResources(KEY5, "KEY5");
		((Control)KEY5).Name = "KEY5";
		((ButtonBase)KEY5).UseVisualStyleBackColor = true;
		((Control)KEY5).Click += KEY5_Click;
		componentResourceManager.ApplyResources(KEY12, "KEY12");
		((Control)KEY12).Name = "KEY12";
		((ButtonBase)KEY12).UseVisualStyleBackColor = true;
		((Control)KEY12).Click += KEY12_Click;
		componentResourceManager.ApplyResources(KEY11, "KEY11");
		((Control)KEY11).Name = "KEY11";
		((ButtonBase)KEY11).UseVisualStyleBackColor = true;
		((Control)KEY11).Click += KEY11_Click;
		componentResourceManager.ApplyResources(KEY10, "KEY10");
		((Control)KEY10).Name = "KEY10";
		((ButtonBase)KEY10).UseVisualStyleBackColor = true;
		((Control)KEY10).Click += KEY10_Click;
		componentResourceManager.ApplyResources(KEY9, "KEY9");
		((Control)KEY9).Name = "KEY9";
		((ButtonBase)KEY9).UseVisualStyleBackColor = true;
		((Control)KEY9).Click += KEY9_Click;
		componentResourceManager.ApplyResources(KEY16, "KEY16");
		((Control)KEY16).Name = "KEY16";
		((ButtonBase)KEY16).UseVisualStyleBackColor = true;
		componentResourceManager.ApplyResources(KEY15, "KEY15");
		((Control)KEY15).Name = "KEY15";
		((ButtonBase)KEY15).UseVisualStyleBackColor = true;
		componentResourceManager.ApplyResources(KEY14, "KEY14");
		((Control)KEY14).Name = "KEY14";
		((ButtonBase)KEY14).UseVisualStyleBackColor = true;
		componentResourceManager.ApplyResources(KEY13, "KEY13");
		((Control)KEY13).Name = "KEY13";
		((ButtonBase)KEY13).UseVisualStyleBackColor = true;
		componentResourceManager.ApplyResources(K2_Right, "K2_Right");
		((Control)K2_Right).Name = "K2_Right";
		((ButtonBase)K2_Right).UseVisualStyleBackColor = true;
		((Control)K2_Right).Click += K2_Right_Click;
		componentResourceManager.ApplyResources(K2_Centre, "K2_Centre");
		((Control)K2_Centre).Name = "K2_Centre";
		((ButtonBase)K2_Centre).UseVisualStyleBackColor = true;
		((Control)K2_Centre).Click += K2_Centre_Click;
		componentResourceManager.ApplyResources(K2_Left, "K2_Left");
		((Control)K2_Left).Name = "K2_Left";
		((ButtonBase)K2_Left).UseVisualStyleBackColor = true;
		((Control)K2_Left).Click += K2_Left_Click;
		componentResourceManager.ApplyResources(SetFunText, "SetFunText");
		((Control)SetFunText).Name = "SetFunText";
		((Control)SetFunText).TextChanged += SetFunText_TextChanged;
		componentResourceManager.ApplyResources(K3_Left, "K3_Left");
		((Control)K3_Left).Name = "K3_Left";
		((ButtonBase)K3_Left).UseVisualStyleBackColor = true;
		componentResourceManager.ApplyResources(K3_Centre, "K3_Centre");
		((Control)K3_Centre).Name = "K3_Centre";
		((ButtonBase)K3_Centre).UseVisualStyleBackColor = true;
		componentResourceManager.ApplyResources(K3_Right, "K3_Right");
		((Control)K3_Right).Name = "K3_Right";
		((ButtonBase)K3_Right).UseVisualStyleBackColor = true;
		componentResourceManager.ApplyResources(flowLayoutPanel_LayerFun, "flowLayoutPanel_LayerFun");
		((Control)flowLayoutPanel_LayerFun).Name = "flowLayoutPanel_LayerFun";
		((Control)pictureBox1).BackColor = Color.FromArgb(192, 192, 255);
		componentResourceManager.ApplyResources(pictureBox1, "pictureBox1");
		((Control)pictureBox1).Name = "pictureBox1";
		pictureBox1.TabStop = false;
		componentResourceManager.ApplyResources(label_Dowload_Dsp, "label_Dowload_Dsp");
		((Control)label_Dowload_Dsp).Name = "label_Dowload_Dsp";
		componentResourceManager.ApplyResources(this, "$this");
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).Controls.Add((Control)(object)flowLayoutPanel1);
		((Control)this).Controls.Add((Control)(object)label_Dowload_Dsp);
		((Control)this).Controls.Add((Control)(object)flowLayoutPanel_LayerFun);
		((Control)this).Controls.Add((Control)(object)SetFunText);
		((Control)this).Controls.Add((Control)(object)K3_Right);
		((Control)this).Controls.Add((Control)(object)K3_Centre);
		((Control)this).Controls.Add((Control)(object)K3_Left);
		((Control)this).Controls.Add((Control)(object)K2_Right);
		((Control)this).Controls.Add((Control)(object)K2_Centre);
		((Control)this).Controls.Add((Control)(object)K2_Left);
		((Control)this).Controls.Add((Control)(object)KEY16);
		((Control)this).Controls.Add((Control)(object)KEY15);
		((Control)this).Controls.Add((Control)(object)KEY14);
		((Control)this).Controls.Add((Control)(object)KEY13);
		((Control)this).Controls.Add((Control)(object)KEY12);
		((Control)this).Controls.Add((Control)(object)KEY11);
		((Control)this).Controls.Add((Control)(object)KEY10);
		((Control)this).Controls.Add((Control)(object)KEY9);
		((Control)this).Controls.Add((Control)(object)KEY8);
		((Control)this).Controls.Add((Control)(object)KEY7);
		((Control)this).Controls.Add((Control)(object)KEY6);
		((Control)this).Controls.Add((Control)(object)KEY5);
		((Control)this).Controls.Add((Control)(object)Key_Clear);
		((Control)this).Controls.Add((Control)(object)SetText);
		((Control)this).Controls.Add((Control)(object)K1_Right);
		((Control)this).Controls.Add((Control)(object)K1_Centre);
		((Control)this).Controls.Add((Control)(object)K1_Left);
		((Control)this).Controls.Add((Control)(object)KEY4);
		((Control)this).Controls.Add((Control)(object)KEY3);
		((Control)this).Controls.Add((Control)(object)KEY2);
		((Control)this).Controls.Add((Control)(object)KEY1);
		((Control)this).Controls.Add((Control)(object)Download);
		((Control)this).Controls.Add((Control)(object)stateLabel);
		((Control)this).Controls.Add((Control)(object)splitContainer1);
		((Control)this).Controls.Add((Control)(object)pictureBox1);
		((Control)this).Cursor = Cursors.Default;
		((Form)this).FormBorderStyle = (FormBorderStyle)2;
		((Control)this).Name = "FormMain";
		((Form)this).Load += FormMain_Load;
		((ISupportInitialize)splitContainer1).EndInit();
		((Control)splitContainer1).ResumeLayout(false);
		((ISupportInitialize)pictureBox1).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
