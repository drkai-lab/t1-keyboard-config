using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HIDTester;

public class FunKey : UserControl
{
	private IContainer components;

	private Button KEY_Ctrl_left;

	private Button KEY_Shift_left;

	private Button KEY_ALT_Left;

	private Button KEY_ALT_Right;

	private Button KEY_Shift_right;

	private Button KEY_Ctrl_Right;

	private Button KEY_Win_left;

	private Button KEY_Win_Right;

	private Button KEY_ctrl_alt;

	private Button KEY_Ctrl_Shift;

	private Button KEY_Alt_Shift;

	private Button KEY_Ctrl_Shift_Alt;

	private Button KEY_Ctrl_Alt_Win;

	private Button KEY_Shift_Win;

	private Button KEY_Ctrl_Alt_Shift_Win;

	private Button KEY_Shift_And_1;

	private Button KEY_Shift_And_2;

	private Button KEY_Shift_And_3;

	private Button KEY_Shift_And_4;

	private Button KEY_Shift_And_5;

	private Button KEY_Shift_And_6;

	private Button KEY_Shift_And_7;

	private Button KEY_Shift_And_8;

	private Button KEY_Shift_And_9;

	private Button KEY_Shift_And_10;

	private Button KEY_Shift_And_11;

	private Button KEY_Shift_And_12;

	private Button KEY_Shift_And_13;

	private Button KEY_Shift_And_14;

	private Button KEY_Shift_And_15;

	private Button KEY_Shift_And_16;

	private Button KEY_Shift_And_17;

	private Button KEY_Shift_And_18;

	private Button KEY_Shift_And_19;

	private Button KEY_Shift_And_20;

	private Button KEY_Shift_And_21;

	public FunKey()
	{
		InitializeComponent();
	}

	private void FunGeneral_Char_Set()
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KeyType_Num] |= 1;
		FormMain.KeyParam.FunKEY_Char_Num++;
	}

	private void KEY_Ctrl_left_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 1;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Ctrl";
		FunGeneral_Char_Set();
	}

	private void KEY_Shift_left_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 2;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Shift";
		FunGeneral_Char_Set();
	}

	private void KEY_ALT_Left_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 4;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Alt";
		FunGeneral_Char_Set();
	}

	private void KEY_Win_left_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 8;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Win";
		FunGeneral_Char_Set();
	}

	private void KEY_Ctrl_Right_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 16;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Ctrl";
		FunGeneral_Char_Set();
	}

	private void KEY_Shift_right_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 32;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Shift";
		FunGeneral_Char_Set();
	}

	private void KEY_ALT_Right_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 64;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Alt";
		FunGeneral_Char_Set();
	}

	private void KEY_Win_Right_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 128;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Win";
		FunGeneral_Char_Set();
	}

	private void KEY_ctrl_alt_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 1;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Ctrl";
		FunGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 4;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Alt";
		FunGeneral_Char_Set();
	}

	private void KEY_Ctrl_Shift_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 1;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Ctrl";
		FunGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 2;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Shift";
		FunGeneral_Char_Set();
	}

	private void KEY_Alt_Shift_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 4;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Alt";
		FunGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 2;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Shift";
		FunGeneral_Char_Set();
	}

	private void KEY_Shift_Win_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 2;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Shift";
		FunGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 8;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Win";
		FunGeneral_Char_Set();
	}

	private void KEY_Ctrl_Shift_Alt_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 1;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Ctrl";
		FunGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 2;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Shift";
		FunGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 4;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Alt";
		FunGeneral_Char_Set();
	}

	private void KEY_Ctrl_Alt_Win_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 1;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Ctrl";
		FunGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 4;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Alt";
		FunGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 8;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Win";
		FunGeneral_Char_Set();
	}

	private void KEY_Ctrl_Alt_Shift_Win_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 1;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Ctrl";
		FunGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 4;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Alt";
		FunGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 2;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Shift";
		FunGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 8;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Win";
		FunGeneral_Char_Set();
	}

	private void ShiftGeneral_Char_Set()
	{
		if (FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] != 0)
		{
			FormMain.KeyParam.KEY_Char_Num += 2;
		}
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 2;
	}

	private void ShiftGeneral_Char_Set2()
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KeyType_Num] |= 1;
		FormMain.KeyParam.KEY_Char_Num += 2;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KeyGroupCharNum]++;
		FormMain.KeyParam.FunKEY_Char_Num++;
	}

	private void KEY_Shift_And_1_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 53;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Shift_And_1).Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_2_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 30;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Shift_And_2).Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_3_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 31;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Shift_And_3).Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_4_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 32;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Shift_And_4).Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_5_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 33;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Shift_And_5).Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_6_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 34;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Shift_And_6).Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_7_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 35;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Shift_And_7).Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_8_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 36;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Shift_And_8).Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_9_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 37;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Shift_And_9).Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_10_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 38;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Shift_And_10).Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_11_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 39;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Shift_And_11).Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_12_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 45;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Shift_And_12).Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_13_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 46;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Shift_And_13).Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_14_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 47;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Shift_And_14).Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_15_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 48;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Shift_And_15).Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_16_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 49;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Shift_And_16).Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_17_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 51;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Shift_And_17).Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_18_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 52;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Shift_And_18).Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_19_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 54;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Shift_And_19).Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_20_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 55;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Shift_And_20).Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_21_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 56;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Shift_And_21).Text;
		ShiftGeneral_Char_Set2();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		((ContainerControl)this).Dispose(disposing);
	}

	private void InitializeComponent()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		KEY_Ctrl_left = new Button();
		KEY_Shift_left = new Button();
		KEY_ALT_Left = new Button();
		KEY_ALT_Right = new Button();
		KEY_Shift_right = new Button();
		KEY_Ctrl_Right = new Button();
		KEY_Win_left = new Button();
		KEY_Win_Right = new Button();
		KEY_ctrl_alt = new Button();
		KEY_Ctrl_Shift = new Button();
		KEY_Alt_Shift = new Button();
		KEY_Ctrl_Shift_Alt = new Button();
		KEY_Ctrl_Alt_Win = new Button();
		KEY_Shift_Win = new Button();
		KEY_Ctrl_Alt_Shift_Win = new Button();
		KEY_Shift_And_1 = new Button();
		KEY_Shift_And_2 = new Button();
		KEY_Shift_And_3 = new Button();
		KEY_Shift_And_4 = new Button();
		KEY_Shift_And_5 = new Button();
		KEY_Shift_And_6 = new Button();
		KEY_Shift_And_7 = new Button();
		KEY_Shift_And_8 = new Button();
		KEY_Shift_And_9 = new Button();
		KEY_Shift_And_10 = new Button();
		KEY_Shift_And_11 = new Button();
		KEY_Shift_And_12 = new Button();
		KEY_Shift_And_13 = new Button();
		KEY_Shift_And_14 = new Button();
		KEY_Shift_And_15 = new Button();
		KEY_Shift_And_16 = new Button();
		KEY_Shift_And_17 = new Button();
		KEY_Shift_And_18 = new Button();
		KEY_Shift_And_19 = new Button();
		KEY_Shift_And_20 = new Button();
		KEY_Shift_And_21 = new Button();
		((Control)this).SuspendLayout();
		((Control)KEY_Ctrl_left).Location = new Point(3, 3);
		((Control)KEY_Ctrl_left).Name = "KEY_Ctrl_left";
		((Control)KEY_Ctrl_left).Size = new Size(94, 23);
		((Control)KEY_Ctrl_left).TabIndex = 69;
		((Control)KEY_Ctrl_left).Text = "Ctrl+";
		((ButtonBase)KEY_Ctrl_left).UseVisualStyleBackColor = true;
		((Control)KEY_Ctrl_left).Click += KEY_Ctrl_left_Click;
		((Control)KEY_Shift_left).Location = new Point(206, 3);
		((Control)KEY_Shift_left).Name = "KEY_Shift_left";
		((Control)KEY_Shift_left).Size = new Size(97, 23);
		((Control)KEY_Shift_left).TabIndex = 70;
		((Control)KEY_Shift_left).Text = "Shift+";
		((ButtonBase)KEY_Shift_left).UseVisualStyleBackColor = true;
		((Control)KEY_Shift_left).Click += KEY_Shift_left_Click;
		((Control)KEY_ALT_Left).Location = new Point(103, 3);
		((Control)KEY_ALT_Left).Name = "KEY_ALT_Left";
		((Control)KEY_ALT_Left).Size = new Size(97, 23);
		((Control)KEY_ALT_Left).TabIndex = 71;
		((Control)KEY_ALT_Left).Text = "Alt+";
		((ButtonBase)KEY_ALT_Left).UseVisualStyleBackColor = true;
		((Control)KEY_ALT_Left).Click += KEY_ALT_Left_Click;
		((Control)KEY_ALT_Right).Location = new Point(103, 32);
		((Control)KEY_ALT_Right).Name = "KEY_ALT_Right";
		((Control)KEY_ALT_Right).Size = new Size(97, 23);
		((Control)KEY_ALT_Right).TabIndex = 72;
		((Control)KEY_ALT_Right).Text = "Right Alt+";
		((ButtonBase)KEY_ALT_Right).UseVisualStyleBackColor = true;
		((Control)KEY_ALT_Right).Click += KEY_ALT_Right_Click;
		((Control)KEY_Shift_right).Location = new Point(206, 32);
		((Control)KEY_Shift_right).Name = "KEY_Shift_right";
		((Control)KEY_Shift_right).Size = new Size(97, 23);
		((Control)KEY_Shift_right).TabIndex = 73;
		((Control)KEY_Shift_right).Text = "Right Shift+";
		((ButtonBase)KEY_Shift_right).UseVisualStyleBackColor = true;
		((Control)KEY_Shift_right).Click += KEY_Shift_right_Click;
		((Control)KEY_Ctrl_Right).Location = new Point(3, 32);
		((Control)KEY_Ctrl_Right).Name = "KEY_Ctrl_Right";
		((Control)KEY_Ctrl_Right).Size = new Size(94, 23);
		((Control)KEY_Ctrl_Right).TabIndex = 74;
		((Control)KEY_Ctrl_Right).Text = "Right  Ctrl+";
		((ButtonBase)KEY_Ctrl_Right).UseVisualStyleBackColor = true;
		((Control)KEY_Ctrl_Right).Click += KEY_Ctrl_Right_Click;
		((Control)KEY_Win_left).Location = new Point(309, 3);
		((Control)KEY_Win_left).Name = "KEY_Win_left";
		((Control)KEY_Win_left).Size = new Size(88, 23);
		((Control)KEY_Win_left).TabIndex = 75;
		((Control)KEY_Win_left).Text = "Win+";
		((ButtonBase)KEY_Win_left).UseVisualStyleBackColor = true;
		((Control)KEY_Win_left).Click += KEY_Win_left_Click;
		((Control)KEY_Win_Right).Location = new Point(309, 32);
		((Control)KEY_Win_Right).Name = "KEY_Win_Right";
		((Control)KEY_Win_Right).Size = new Size(88, 23);
		((Control)KEY_Win_Right).TabIndex = 76;
		((Control)KEY_Win_Right).Text = "Right Win+";
		((ButtonBase)KEY_Win_Right).UseVisualStyleBackColor = true;
		((Control)KEY_Win_Right).Click += KEY_Win_Right_Click;
		((Control)KEY_ctrl_alt).Location = new Point(3, 61);
		((Control)KEY_ctrl_alt).Name = "KEY_ctrl_alt";
		((Control)KEY_ctrl_alt).Size = new Size(94, 23);
		((Control)KEY_ctrl_alt).TabIndex = 77;
		((Control)KEY_ctrl_alt).Text = "Ctrl+Alt+";
		((ButtonBase)KEY_ctrl_alt).UseVisualStyleBackColor = true;
		((Control)KEY_ctrl_alt).Click += KEY_ctrl_alt_Click;
		((Control)KEY_Ctrl_Shift).Location = new Point(106, 61);
		((Control)KEY_Ctrl_Shift).Name = "KEY_Ctrl_Shift";
		((Control)KEY_Ctrl_Shift).Size = new Size(94, 23);
		((Control)KEY_Ctrl_Shift).TabIndex = 78;
		((Control)KEY_Ctrl_Shift).Text = "Ctrl+Shift+";
		((ButtonBase)KEY_Ctrl_Shift).UseVisualStyleBackColor = true;
		((Control)KEY_Ctrl_Shift).Click += KEY_Ctrl_Shift_Click;
		((Control)KEY_Alt_Shift).Location = new Point(206, 61);
		((Control)KEY_Alt_Shift).Name = "KEY_Alt_Shift";
		((Control)KEY_Alt_Shift).Size = new Size(97, 23);
		((Control)KEY_Alt_Shift).TabIndex = 79;
		((Control)KEY_Alt_Shift).Text = "Alt+Shift+";
		((ButtonBase)KEY_Alt_Shift).UseVisualStyleBackColor = true;
		((Control)KEY_Alt_Shift).Click += KEY_Alt_Shift_Click;
		((Control)KEY_Ctrl_Shift_Alt).Location = new Point(3, 90);
		((Control)KEY_Ctrl_Shift_Alt).Name = "KEY_Ctrl_Shift_Alt";
		((Control)KEY_Ctrl_Shift_Alt).Size = new Size(197, 23);
		((Control)KEY_Ctrl_Shift_Alt).TabIndex = 80;
		((Control)KEY_Ctrl_Shift_Alt).Text = "Ctrl+Shift+Alt+";
		((ButtonBase)KEY_Ctrl_Shift_Alt).UseVisualStyleBackColor = true;
		((Control)KEY_Ctrl_Shift_Alt).Click += KEY_Ctrl_Shift_Alt_Click;
		((Control)KEY_Ctrl_Alt_Win).Location = new Point(206, 90);
		((Control)KEY_Ctrl_Alt_Win).Name = "KEY_Ctrl_Alt_Win";
		((Control)KEY_Ctrl_Alt_Win).Size = new Size(191, 23);
		((Control)KEY_Ctrl_Alt_Win).TabIndex = 81;
		((Control)KEY_Ctrl_Alt_Win).Text = "Ctrl+Alt+Win+";
		((ButtonBase)KEY_Ctrl_Alt_Win).UseVisualStyleBackColor = true;
		((Control)KEY_Ctrl_Alt_Win).Click += KEY_Ctrl_Alt_Win_Click;
		((Control)KEY_Shift_Win).Location = new Point(309, 61);
		((Control)KEY_Shift_Win).Name = "KEY_Shift_Win";
		((Control)KEY_Shift_Win).Size = new Size(88, 23);
		((Control)KEY_Shift_Win).TabIndex = 82;
		((Control)KEY_Shift_Win).Text = "Shift+Win+";
		((ButtonBase)KEY_Shift_Win).UseVisualStyleBackColor = true;
		((Control)KEY_Shift_Win).Click += KEY_Shift_Win_Click;
		((Control)KEY_Ctrl_Alt_Shift_Win).Location = new Point(3, 119);
		((Control)KEY_Ctrl_Alt_Shift_Win).Name = "KEY_Ctrl_Alt_Shift_Win";
		((Control)KEY_Ctrl_Alt_Shift_Win).Size = new Size(394, 23);
		((Control)KEY_Ctrl_Alt_Shift_Win).TabIndex = 83;
		((Control)KEY_Ctrl_Alt_Shift_Win).Text = "Ctrl+Alt+Shift+Win+";
		((ButtonBase)KEY_Ctrl_Alt_Shift_Win).UseVisualStyleBackColor = true;
		((Control)KEY_Ctrl_Alt_Shift_Win).Click += KEY_Ctrl_Alt_Shift_Win_Click;
		((Control)KEY_Shift_And_1).Location = new Point(423, 3);
		((Control)KEY_Shift_And_1).Name = "KEY_Shift_And_1";
		((Control)KEY_Shift_And_1).Size = new Size(41, 23);
		((Control)KEY_Shift_And_1).TabIndex = 84;
		((Control)KEY_Shift_And_1).Text = "～";
		((ButtonBase)KEY_Shift_And_1).UseVisualStyleBackColor = true;
		((Control)KEY_Shift_And_1).Click += KEY_Shift_And_1_Click;
		((Control)KEY_Shift_And_2).Location = new Point(470, 3);
		((Control)KEY_Shift_And_2).Name = "KEY_Shift_And_2";
		((Control)KEY_Shift_And_2).Size = new Size(41, 23);
		((Control)KEY_Shift_And_2).TabIndex = 85;
		((Control)KEY_Shift_And_2).Text = "！";
		((ButtonBase)KEY_Shift_And_2).UseVisualStyleBackColor = true;
		((Control)KEY_Shift_And_2).Click += KEY_Shift_And_2_Click;
		((Control)KEY_Shift_And_3).Location = new Point(517, 3);
		((Control)KEY_Shift_And_3).Name = "KEY_Shift_And_3";
		((Control)KEY_Shift_And_3).Size = new Size(41, 23);
		((Control)KEY_Shift_And_3).TabIndex = 86;
		((Control)KEY_Shift_And_3).Text = "@";
		((ButtonBase)KEY_Shift_And_3).UseVisualStyleBackColor = true;
		((Control)KEY_Shift_And_3).Click += KEY_Shift_And_3_Click;
		((Control)KEY_Shift_And_4).Location = new Point(564, 3);
		((Control)KEY_Shift_And_4).Name = "KEY_Shift_And_4";
		((Control)KEY_Shift_And_4).Size = new Size(41, 23);
		((Control)KEY_Shift_And_4).TabIndex = 87;
		((Control)KEY_Shift_And_4).Text = "#";
		((ButtonBase)KEY_Shift_And_4).UseVisualStyleBackColor = true;
		((Control)KEY_Shift_And_4).Click += KEY_Shift_And_4_Click;
		((Control)KEY_Shift_And_5).Location = new Point(611, 3);
		((Control)KEY_Shift_And_5).Name = "KEY_Shift_And_5";
		((Control)KEY_Shift_And_5).Size = new Size(41, 23);
		((Control)KEY_Shift_And_5).TabIndex = 88;
		((Control)KEY_Shift_And_5).Text = "$";
		((ButtonBase)KEY_Shift_And_5).UseVisualStyleBackColor = true;
		((Control)KEY_Shift_And_5).Click += KEY_Shift_And_5_Click;
		((Control)KEY_Shift_And_6).Location = new Point(423, 32);
		((Control)KEY_Shift_And_6).Name = "KEY_Shift_And_6";
		((Control)KEY_Shift_And_6).Size = new Size(41, 23);
		((Control)KEY_Shift_And_6).TabIndex = 89;
		((Control)KEY_Shift_And_6).Text = "%";
		((ButtonBase)KEY_Shift_And_6).UseVisualStyleBackColor = true;
		((Control)KEY_Shift_And_6).Click += KEY_Shift_And_6_Click;
		((Control)KEY_Shift_And_7).Location = new Point(470, 32);
		((Control)KEY_Shift_And_7).Name = "KEY_Shift_And_7";
		((Control)KEY_Shift_And_7).Size = new Size(41, 23);
		((Control)KEY_Shift_And_7).TabIndex = 90;
		((Control)KEY_Shift_And_7).Text = "∧";
		((ButtonBase)KEY_Shift_And_7).UseVisualStyleBackColor = true;
		((Control)KEY_Shift_And_7).Click += KEY_Shift_And_7_Click;
		((Control)KEY_Shift_And_8).Location = new Point(517, 32);
		((Control)KEY_Shift_And_8).Name = "KEY_Shift_And_8";
		((Control)KEY_Shift_And_8).Size = new Size(41, 23);
		((Control)KEY_Shift_And_8).TabIndex = 91;
		((Control)KEY_Shift_And_8).Text = "＆";
		((ButtonBase)KEY_Shift_And_8).UseVisualStyleBackColor = true;
		((Control)KEY_Shift_And_8).Click += KEY_Shift_And_8_Click;
		((Control)KEY_Shift_And_9).Location = new Point(564, 32);
		((Control)KEY_Shift_And_9).Name = "KEY_Shift_And_9";
		((Control)KEY_Shift_And_9).Size = new Size(41, 23);
		((Control)KEY_Shift_And_9).TabIndex = 92;
		((Control)KEY_Shift_And_9).Text = "*";
		((ButtonBase)KEY_Shift_And_9).UseVisualStyleBackColor = true;
		((Control)KEY_Shift_And_9).Click += KEY_Shift_And_9_Click;
		((Control)KEY_Shift_And_10).Location = new Point(611, 32);
		((Control)KEY_Shift_And_10).Name = "KEY_Shift_And_10";
		((Control)KEY_Shift_And_10).Size = new Size(41, 23);
		((Control)KEY_Shift_And_10).TabIndex = 93;
		((Control)KEY_Shift_And_10).Text = "(";
		((ButtonBase)KEY_Shift_And_10).UseVisualStyleBackColor = true;
		((Control)KEY_Shift_And_10).Click += KEY_Shift_And_10_Click;
		((Control)KEY_Shift_And_11).Location = new Point(423, 61);
		((Control)KEY_Shift_And_11).Name = "KEY_Shift_And_11";
		((Control)KEY_Shift_And_11).Size = new Size(41, 23);
		((Control)KEY_Shift_And_11).TabIndex = 94;
		((Control)KEY_Shift_And_11).Text = ")";
		((ButtonBase)KEY_Shift_And_11).UseVisualStyleBackColor = true;
		((Control)KEY_Shift_And_11).Click += KEY_Shift_And_11_Click;
		((Control)KEY_Shift_And_12).Location = new Point(470, 61);
		((Control)KEY_Shift_And_12).Name = "KEY_Shift_And_12";
		((Control)KEY_Shift_And_12).Size = new Size(41, 23);
		((Control)KEY_Shift_And_12).TabIndex = 95;
		((Control)KEY_Shift_And_12).Text = "\uffe3";
		((ButtonBase)KEY_Shift_And_12).UseVisualStyleBackColor = true;
		((Control)KEY_Shift_And_12).Click += KEY_Shift_And_12_Click;
		((Control)KEY_Shift_And_13).Location = new Point(517, 61);
		((Control)KEY_Shift_And_13).Name = "KEY_Shift_And_13";
		((Control)KEY_Shift_And_13).Size = new Size(41, 23);
		((Control)KEY_Shift_And_13).TabIndex = 96;
		((Control)KEY_Shift_And_13).Text = "＋";
		((ButtonBase)KEY_Shift_And_13).UseVisualStyleBackColor = true;
		((Control)KEY_Shift_And_13).Click += KEY_Shift_And_13_Click;
		((Control)KEY_Shift_And_14).Location = new Point(564, 61);
		((Control)KEY_Shift_And_14).Name = "KEY_Shift_And_14";
		((Control)KEY_Shift_And_14).Size = new Size(41, 23);
		((Control)KEY_Shift_And_14).TabIndex = 97;
		((Control)KEY_Shift_And_14).Text = "{";
		((ButtonBase)KEY_Shift_And_14).UseVisualStyleBackColor = true;
		((Control)KEY_Shift_And_14).Click += KEY_Shift_And_14_Click;
		((Control)KEY_Shift_And_15).Location = new Point(611, 61);
		((Control)KEY_Shift_And_15).Name = "KEY_Shift_And_15";
		((Control)KEY_Shift_And_15).Size = new Size(41, 23);
		((Control)KEY_Shift_And_15).TabIndex = 98;
		((Control)KEY_Shift_And_15).Text = "}";
		((ButtonBase)KEY_Shift_And_15).UseVisualStyleBackColor = true;
		((Control)KEY_Shift_And_15).Click += KEY_Shift_And_15_Click;
		((Control)KEY_Shift_And_16).Location = new Point(423, 90);
		((Control)KEY_Shift_And_16).Name = "KEY_Shift_And_16";
		((Control)KEY_Shift_And_16).Size = new Size(41, 23);
		((Control)KEY_Shift_And_16).TabIndex = 99;
		((Control)KEY_Shift_And_16).Text = "|";
		((ButtonBase)KEY_Shift_And_16).UseVisualStyleBackColor = true;
		((Control)KEY_Shift_And_16).Click += KEY_Shift_And_16_Click;
		((Control)KEY_Shift_And_17).Location = new Point(470, 90);
		((Control)KEY_Shift_And_17).Name = "KEY_Shift_And_17";
		((Control)KEY_Shift_And_17).Size = new Size(41, 23);
		((Control)KEY_Shift_And_17).TabIndex = 100;
		((Control)KEY_Shift_And_17).Text = "：";
		((ButtonBase)KEY_Shift_And_17).UseVisualStyleBackColor = true;
		((Control)KEY_Shift_And_17).Click += KEY_Shift_And_17_Click;
		((Control)KEY_Shift_And_18).Location = new Point(517, 90);
		((Control)KEY_Shift_And_18).Name = "KEY_Shift_And_18";
		((Control)KEY_Shift_And_18).Size = new Size(41, 23);
		((Control)KEY_Shift_And_18).TabIndex = 101;
		((Control)KEY_Shift_And_18).Text = "＂";
		((ButtonBase)KEY_Shift_And_18).UseVisualStyleBackColor = true;
		((Control)KEY_Shift_And_18).Click += KEY_Shift_And_18_Click;
		((Control)KEY_Shift_And_19).Location = new Point(564, 90);
		((Control)KEY_Shift_And_19).Name = "KEY_Shift_And_19";
		((Control)KEY_Shift_And_19).Size = new Size(41, 23);
		((Control)KEY_Shift_And_19).TabIndex = 102;
		((Control)KEY_Shift_And_19).Text = "＜";
		((ButtonBase)KEY_Shift_And_19).UseVisualStyleBackColor = true;
		((Control)KEY_Shift_And_19).Click += KEY_Shift_And_19_Click;
		((Control)KEY_Shift_And_20).Location = new Point(611, 90);
		((Control)KEY_Shift_And_20).Name = "KEY_Shift_And_20";
		((Control)KEY_Shift_And_20).Size = new Size(41, 23);
		((Control)KEY_Shift_And_20).TabIndex = 103;
		((Control)KEY_Shift_And_20).Text = "＞";
		((ButtonBase)KEY_Shift_And_20).UseVisualStyleBackColor = true;
		((Control)KEY_Shift_And_20).Click += KEY_Shift_And_20_Click;
		((Control)KEY_Shift_And_21).Location = new Point(423, 119);
		((Control)KEY_Shift_And_21).Name = "KEY_Shift_And_21";
		((Control)KEY_Shift_And_21).Size = new Size(41, 23);
		((Control)KEY_Shift_And_21).TabIndex = 104;
		((Control)KEY_Shift_And_21).Text = "？";
		((ButtonBase)KEY_Shift_And_21).UseVisualStyleBackColor = true;
		((Control)KEY_Shift_And_21).Click += KEY_Shift_And_21_Click;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 12f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).Controls.Add((Control)(object)KEY_Shift_And_21);
		((Control)this).Controls.Add((Control)(object)KEY_Shift_And_20);
		((Control)this).Controls.Add((Control)(object)KEY_Shift_And_19);
		((Control)this).Controls.Add((Control)(object)KEY_Shift_And_18);
		((Control)this).Controls.Add((Control)(object)KEY_Shift_And_17);
		((Control)this).Controls.Add((Control)(object)KEY_Shift_And_16);
		((Control)this).Controls.Add((Control)(object)KEY_Shift_And_15);
		((Control)this).Controls.Add((Control)(object)KEY_Shift_And_14);
		((Control)this).Controls.Add((Control)(object)KEY_Shift_And_13);
		((Control)this).Controls.Add((Control)(object)KEY_Shift_And_12);
		((Control)this).Controls.Add((Control)(object)KEY_Shift_And_11);
		((Control)this).Controls.Add((Control)(object)KEY_Shift_And_10);
		((Control)this).Controls.Add((Control)(object)KEY_Shift_And_9);
		((Control)this).Controls.Add((Control)(object)KEY_Shift_And_8);
		((Control)this).Controls.Add((Control)(object)KEY_Shift_And_7);
		((Control)this).Controls.Add((Control)(object)KEY_Shift_And_6);
		((Control)this).Controls.Add((Control)(object)KEY_Shift_And_5);
		((Control)this).Controls.Add((Control)(object)KEY_Shift_And_4);
		((Control)this).Controls.Add((Control)(object)KEY_Shift_And_3);
		((Control)this).Controls.Add((Control)(object)KEY_Shift_And_2);
		((Control)this).Controls.Add((Control)(object)KEY_Shift_And_1);
		((Control)this).Controls.Add((Control)(object)KEY_Ctrl_Alt_Shift_Win);
		((Control)this).Controls.Add((Control)(object)KEY_Shift_Win);
		((Control)this).Controls.Add((Control)(object)KEY_Ctrl_Alt_Win);
		((Control)this).Controls.Add((Control)(object)KEY_Ctrl_Shift_Alt);
		((Control)this).Controls.Add((Control)(object)KEY_Alt_Shift);
		((Control)this).Controls.Add((Control)(object)KEY_Ctrl_Shift);
		((Control)this).Controls.Add((Control)(object)KEY_ctrl_alt);
		((Control)this).Controls.Add((Control)(object)KEY_Win_Right);
		((Control)this).Controls.Add((Control)(object)KEY_Win_left);
		((Control)this).Controls.Add((Control)(object)KEY_Ctrl_Right);
		((Control)this).Controls.Add((Control)(object)KEY_Shift_right);
		((Control)this).Controls.Add((Control)(object)KEY_ALT_Right);
		((Control)this).Controls.Add((Control)(object)KEY_ALT_Left);
		((Control)this).Controls.Add((Control)(object)KEY_Shift_left);
		((Control)this).Controls.Add((Control)(object)KEY_Ctrl_left);
		((Control)this).Name = "FunKey";
		((Control)this).Size = new Size(858, 443);
		((Control)this).ResumeLayout(false);
	}
}
