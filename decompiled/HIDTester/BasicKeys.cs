using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HIDTester;

public class BasicKeys : UserControl
{
	private IContainer components;

	private Button KEY_A;

	private Button KEY_B;

	private Button KEY_C;

	private Button KEY_D;

	private Button KEY_E;

	private Button KEY_F;

	private Button KEY_G;

	private Button KEY_H;

	private Button KEY_I;

	private Button KEY_J;

	private Button KEY_K;

	private Button KEY_W;

	private Button KEY_V;

	private Button KEY_U;

	private Button KEY_T;

	private Button KEY_S;

	private Button KEY_R;

	private Button KEY_Q;

	private Button KEY_P;

	private Button KEY_O;

	private Button KEY_N;

	private Button KEY_M;

	private Button KEY_L;

	private Button KEY_8;

	private Button KEY_7;

	private Button KEY_6;

	private Button KEY_5;

	private Button KEY_4;

	private Button KEY_3;

	private Button KEY_2;

	private Button KEY_1;

	private Button KEY_9;

	private Button KEY_Z;

	private Button KEY_Y;

	private Button KEY_X;

	private Button KEY_0;

	private Button KEY_F12;

	private Button KEY_F11;

	private Button KEY_F10;

	private Button KEY_F9;

	private Button KEY_F8;

	private Button KEY_F7;

	private Button KEY_F6;

	private Button KEY_F5;

	private Button KEY_F4;

	private Button KEY_F3;

	private Button KEY_F2;

	private Button KEY_F1;

	private Button KEY_ESC;

	private Button KEY_PrtSc;

	private Button KEY_PauseBreak;

	private Button KEY_INS;

	private Button KEY_DEL;

	private Button KEY_HOME;

	private Button KEY_PgUg;

	private Button KEY_PgDn;

	private Button KEY_End;

	private Button KEY_SubSub;

	private Button KEY_ADDADD;

	private Button KEY_BACKSPACE;

	private Button KEY_Tabel;

	private Button KEY_kuohao;

	private Button KEY_kuohao2;

	private Button KEY_shu;

	private Button KEY_fenhao;

	private Button KEY_yinghao;

	private Button KEY_Enter;

	private Button KEY_bolanghao;

	private Button KEY_douhao;

	private Button KEY_juhao;

	private Button KEY_wenhao;

	private Button KEY_jiantou_left;

	private Button KEY_jiantou_Up;

	private Button KEY_jiantou_Down;

	private Button KEY_jiantou_right;

	private Button KEY_add;

	private Button KEY_sub;

	private Button KEY_multiply;

	private Button KEY_DIV;

	private Button KEY_NUM;

	private Button KEY_MIN_0;

	private Button KEY_MIN_9;

	private Button KEY_MIN_8;

	private Button KEY_MIN_7;

	private Button KEY_MIN_6;

	private Button KEY_MIN_5;

	private Button KEY_MIN_4;

	private Button KEY_MIN_3;

	private Button KEY_MIN_2;

	private Button KEY_MIN_1;

	private Button KEY_MIN_Dot;

	private Button KEY_CapsLock;

	private Button KEY_SpaceKey;

	private Button KEY_ScrollLock;

	private Button KEY_Menu;

	private Button Key_Ctrl;

	private Button Key_Shift;

	private Button Key_Alt;

	private Button Key_Win;

	public BasicKeys()
	{
		InitializeComponent();
	}

	private void General_Char_Set()
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KeyType_Num] |= 1;
		FormMain.KeyParam.KEY_Char_Num += 2;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KeyGroupCharNum]++;
	}

	private void KEY_A_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 4;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "A";
		General_Char_Set();
	}

	private void KEY_B_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 5;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "B";
		General_Char_Set();
	}

	private void KEY_C_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 6;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "C";
		General_Char_Set();
	}

	private void KEY_D_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 7;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "D";
		General_Char_Set();
	}

	private void KEY_E_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 8;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "E";
		General_Char_Set();
	}

	private void KEY_F_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 9;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "F";
		General_Char_Set();
	}

	private void KEY_G_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 10;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "G";
		General_Char_Set();
	}

	private void KEY_H_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 11;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "H";
		General_Char_Set();
	}

	private void KEY_I_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 12;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "I";
		General_Char_Set();
	}

	private void KEY_J_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 13;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "J";
		General_Char_Set();
	}

	private void KEY_K_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 14;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "K";
		General_Char_Set();
	}

	private void KEY_L_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 15;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "L";
		General_Char_Set();
	}

	private void KEY_M_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 16;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "M";
		General_Char_Set();
	}

	private void KEY_N_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 17;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "N";
		General_Char_Set();
	}

	private void KEY_O_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 18;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "O";
		General_Char_Set();
	}

	private void KEY_P_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 19;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "P";
		General_Char_Set();
	}

	private void KEY_Q_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 20;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "Q";
		General_Char_Set();
	}

	private void KEY_R_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 21;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "R";
		General_Char_Set();
	}

	private void KEY_S_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 22;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "S";
		General_Char_Set();
	}

	private void KEY_T_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 23;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "T";
		General_Char_Set();
	}

	private void KEY_U_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 24;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "U";
		General_Char_Set();
	}

	private void KEY_V_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 25;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "V";
		General_Char_Set();
	}

	private void KEY_W_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 26;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "W";
		General_Char_Set();
	}

	private void KEY_X_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 27;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "X";
		General_Char_Set();
	}

	private void KEY_Y_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 28;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "Y";
		General_Char_Set();
	}

	private void KEY_Z_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 29;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "Z";
		General_Char_Set();
	}

	private void KEY_1_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 30;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "!1";
		General_Char_Set();
	}

	private void KEY_2_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 31;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "@2";
		General_Char_Set();
	}

	private void KEY_3_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 32;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "#3";
		General_Char_Set();
	}

	private void KEY_4_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 33;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "$4";
		General_Char_Set();
	}

	private void KEY_5_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 34;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "%5";
		General_Char_Set();
	}

	private void KEY_6_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 35;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "^6";
		General_Char_Set();
	}

	private void KEY_7_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 36;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "&7";
		General_Char_Set();
	}

	private void KEY_8_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 37;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "*8";
		General_Char_Set();
	}

	private void KEY_9_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 38;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "(9";
		General_Char_Set();
	}

	private void KEY_0_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 39;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ")0";
		General_Char_Set();
	}

	private void KEY_Enter_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 40;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "Enter";
		General_Char_Set();
	}

	private void KEY_ESC_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 41;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "ESC";
		General_Char_Set();
	}

	private void KEY_BACKSPACE_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 42;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "BackSpace";
		General_Char_Set();
	}

	private void KEY_Tabel_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 43;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "Tab";
		General_Char_Set();
	}

	private void KEY_SpaceKey_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 44;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "Space";
		General_Char_Set();
	}

	private void KEY_SubSub_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 45;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "\uffe3－";
		General_Char_Set();
	}

	private void KEY_ADDADD_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 46;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "+=";
		General_Char_Set();
	}

	private void KEY_kuohao_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 47;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "{[";
		General_Char_Set();
	}

	private void KEY_kuohao2_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 48;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "}]";
		General_Char_Set();
	}

	private void KEY_shu_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 49;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "|\\";
		General_Char_Set();
	}

	private void KEY_bolanghao_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 53;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "~、";
		General_Char_Set();
	}

	private void KEY_fenhao_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 51;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ":;";
		General_Char_Set();
	}

	private void KEY_yinghao_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 52;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "\"'";
		General_Char_Set();
	}

	private void KEY_douhao_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 54;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "<,";
		General_Char_Set();
	}

	private void KEY_juhao_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 55;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ">.";
		General_Char_Set();
	}

	private void KEY_wenhao_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 56;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "?/";
		General_Char_Set();
	}

	private void KEY_CapsLock_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 57;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "CapsLock";
		General_Char_Set();
	}

	private void KEY_F1_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 58;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "F1";
		General_Char_Set();
	}

	private void KEY_F2_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 59;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "F2";
		General_Char_Set();
	}

	private void KEY_F3_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 60;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "F3";
		General_Char_Set();
	}

	private void KEY_F4_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 61;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "F4";
		General_Char_Set();
	}

	private void KEY_F5_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 62;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "F5";
		General_Char_Set();
	}

	private void KEY_F6_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 63;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "F6";
		General_Char_Set();
	}

	private void KEY_F7_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 64;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "F7";
		General_Char_Set();
	}

	private void KEY_F8_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 65;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "F8";
		General_Char_Set();
	}

	private void KEY_F9_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 66;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "F9";
		General_Char_Set();
	}

	private void KEY_F10_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 67;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "F10";
		General_Char_Set();
	}

	private void KEY_F11_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 68;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "F11";
		General_Char_Set();
	}

	private void KEY_F12_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 69;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "F12";
		General_Char_Set();
	}

	private void KEY_PrtSc_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 70;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "PrtSc";
		General_Char_Set();
	}

	private void KEY_ScrollLock_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 71;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "ScLock";
		General_Char_Set();
	}

	private void KEY_PauseBreak_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 72;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "PaBk";
		General_Char_Set();
	}

	private void KEY_INS_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 73;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "Ins";
		General_Char_Set();
	}

	private void KEY_HOME_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 74;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "Home";
		General_Char_Set();
	}

	private void KEY_PgUg_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 75;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "PageUp";
		General_Char_Set();
	}

	private void KEY_DEL_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 76;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "Delete";
		General_Char_Set();
	}

	private void KEY_End_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 77;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "End";
		General_Char_Set();
	}

	private void KEY_PgDn_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 78;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "PageDown";
		General_Char_Set();
	}

	private void KEY_jiantou_right_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 79;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "→";
		General_Char_Set();
	}

	private void KEY_jiantou_left_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 80;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "←";
		General_Char_Set();
	}

	private void KEY_jiantou_Down_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 81;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "↓";
		General_Char_Set();
	}

	private void KEY_jiantou_Up_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 82;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "↑";
		General_Char_Set();
	}

	private void KEY_NUM_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 83;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "NumLock";
		General_Char_Set();
	}

	private void KEY_DIV_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 84;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "÷";
		General_Char_Set();
	}

	private void KEY_multiply_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 85;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "×";
		General_Char_Set();
	}

	private void KEY_sub_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 86;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "－";
		General_Char_Set();
	}

	private void KEY_add_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 87;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "＋";
		General_Char_Set();
	}

	private void KEY_MIN_1_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 89;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "1";
		General_Char_Set();
	}

	private void KEY_MIN_2_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 90;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "2";
		General_Char_Set();
	}

	private void KEY_MIN_3_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 91;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "3";
		General_Char_Set();
	}

	private void KEY_MIN_4_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 92;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "4";
		General_Char_Set();
	}

	private void KEY_MIN_5_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 93;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "5";
		General_Char_Set();
	}

	private void KEY_MIN_6_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 94;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "6";
		General_Char_Set();
	}

	private void KEY_MIN_7_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 95;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "7";
		General_Char_Set();
	}

	private void KEY_MIN_8_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 96;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "8";
		General_Char_Set();
	}

	private void KEY_MIN_9_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 97;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "9";
		General_Char_Set();
	}

	private void KEY_MIN_0_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 98;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "0";
		General_Char_Set();
	}

	private void KEY_MIN_Dot_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 99;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "▪";
		General_Char_Set();
	}

	private void KEY_Menu_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 101;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = "▤";
		General_Char_Set();
	}

	private void Key_Ctrl_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 1;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Ctrl";
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KeyType_Num] |= 1;
		FormMain.KeyParam.FunKEY_Char_Num++;
	}

	private void Key_Shift_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 2;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Shift";
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KeyType_Num] |= 1;
		FormMain.KeyParam.FunKEY_Char_Num++;
	}

	private void Key_Alt_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 4;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Alt";
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KeyType_Num] |= 1;
		FormMain.KeyParam.FunKEY_Char_Num++;
	}

	private void Key_Win_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 8;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Win";
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KeyType_Num] |= 1;
		FormMain.KeyParam.FunKEY_Char_Num++;
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
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Expected O, but got Unknown
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Expected O, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Expected O, but got Unknown
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected O, but got Unknown
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Expected O, but got Unknown
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Expected O, but got Unknown
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Expected O, but got Unknown
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected O, but got Unknown
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Expected O, but got Unknown
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected O, but got Unknown
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Expected O, but got Unknown
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Expected O, but got Unknown
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Expected O, but got Unknown
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Expected O, but got Unknown
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Expected O, but got Unknown
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected O, but got Unknown
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Expected O, but got Unknown
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected O, but got Unknown
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Expected O, but got Unknown
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Expected O, but got Unknown
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Expected O, but got Unknown
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0365: Expected O, but got Unknown
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Expected O, but got Unknown
		//IL_0371: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Expected O, but got Unknown
		//IL_037c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Expected O, but got Unknown
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_0391: Expected O, but got Unknown
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Expected O, but got Unknown
		//IL_039d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a7: Expected O, but got Unknown
		//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b2: Expected O, but got Unknown
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Expected O, but got Unknown
		//IL_03be: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c8: Expected O, but got Unknown
		//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d3: Expected O, but got Unknown
		//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03de: Expected O, but got Unknown
		//IL_03df: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e9: Expected O, but got Unknown
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f4: Expected O, but got Unknown
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ff: Expected O, but got Unknown
		//IL_0400: Unknown result type (might be due to invalid IL or missing references)
		//IL_040a: Expected O, but got Unknown
		//IL_040b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0415: Expected O, but got Unknown
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Expected O, but got Unknown
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		//IL_042b: Expected O, but got Unknown
		//IL_042c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Expected O, but got Unknown
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_0441: Expected O, but got Unknown
		//IL_318c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3196: Expected O, but got Unknown
		KEY_A = new Button();
		KEY_B = new Button();
		KEY_C = new Button();
		KEY_D = new Button();
		KEY_E = new Button();
		KEY_F = new Button();
		KEY_G = new Button();
		KEY_H = new Button();
		KEY_I = new Button();
		KEY_J = new Button();
		KEY_K = new Button();
		KEY_W = new Button();
		KEY_V = new Button();
		KEY_U = new Button();
		KEY_T = new Button();
		KEY_S = new Button();
		KEY_R = new Button();
		KEY_Q = new Button();
		KEY_P = new Button();
		KEY_O = new Button();
		KEY_N = new Button();
		KEY_M = new Button();
		KEY_L = new Button();
		KEY_8 = new Button();
		KEY_7 = new Button();
		KEY_6 = new Button();
		KEY_5 = new Button();
		KEY_4 = new Button();
		KEY_3 = new Button();
		KEY_2 = new Button();
		KEY_1 = new Button();
		KEY_9 = new Button();
		KEY_Z = new Button();
		KEY_Y = new Button();
		KEY_X = new Button();
		KEY_0 = new Button();
		KEY_F12 = new Button();
		KEY_F11 = new Button();
		KEY_F10 = new Button();
		KEY_F9 = new Button();
		KEY_F8 = new Button();
		KEY_F7 = new Button();
		KEY_F6 = new Button();
		KEY_F5 = new Button();
		KEY_F4 = new Button();
		KEY_F3 = new Button();
		KEY_F2 = new Button();
		KEY_F1 = new Button();
		KEY_ESC = new Button();
		KEY_PrtSc = new Button();
		KEY_PauseBreak = new Button();
		KEY_INS = new Button();
		KEY_DEL = new Button();
		KEY_HOME = new Button();
		KEY_PgUg = new Button();
		KEY_PgDn = new Button();
		KEY_End = new Button();
		KEY_SubSub = new Button();
		KEY_ADDADD = new Button();
		KEY_BACKSPACE = new Button();
		KEY_Tabel = new Button();
		KEY_kuohao = new Button();
		KEY_kuohao2 = new Button();
		KEY_shu = new Button();
		KEY_fenhao = new Button();
		KEY_yinghao = new Button();
		KEY_Enter = new Button();
		KEY_bolanghao = new Button();
		KEY_douhao = new Button();
		KEY_juhao = new Button();
		KEY_wenhao = new Button();
		KEY_jiantou_left = new Button();
		KEY_jiantou_Up = new Button();
		KEY_jiantou_Down = new Button();
		KEY_jiantou_right = new Button();
		KEY_add = new Button();
		KEY_sub = new Button();
		KEY_multiply = new Button();
		KEY_DIV = new Button();
		KEY_NUM = new Button();
		KEY_MIN_0 = new Button();
		KEY_MIN_9 = new Button();
		KEY_MIN_8 = new Button();
		KEY_MIN_7 = new Button();
		KEY_MIN_6 = new Button();
		KEY_MIN_5 = new Button();
		KEY_MIN_4 = new Button();
		KEY_MIN_3 = new Button();
		KEY_MIN_2 = new Button();
		KEY_MIN_1 = new Button();
		KEY_MIN_Dot = new Button();
		KEY_CapsLock = new Button();
		KEY_SpaceKey = new Button();
		KEY_ScrollLock = new Button();
		KEY_Menu = new Button();
		Key_Ctrl = new Button();
		Key_Shift = new Button();
		Key_Alt = new Button();
		Key_Win = new Button();
		((Control)this).SuspendLayout();
		((Control)KEY_A).Location = new Point(4, 94);
		((Control)KEY_A).Name = "KEY_A";
		((Control)KEY_A).Size = new Size(44, 23);
		((Control)KEY_A).TabIndex = 0;
		((Control)KEY_A).Text = "A";
		((ButtonBase)KEY_A).UseVisualStyleBackColor = true;
		((Control)KEY_A).Click += KEY_A_Click;
		((Control)KEY_B).Location = new Point(54, 94);
		((Control)KEY_B).Name = "KEY_B";
		((Control)KEY_B).Size = new Size(45, 23);
		((Control)KEY_B).TabIndex = 1;
		((Control)KEY_B).Text = "B";
		((ButtonBase)KEY_B).UseVisualStyleBackColor = true;
		((Control)KEY_B).Click += KEY_B_Click;
		((Control)KEY_C).Location = new Point(105, 94);
		((Control)KEY_C).Name = "KEY_C";
		((Control)KEY_C).Size = new Size(45, 23);
		((Control)KEY_C).TabIndex = 2;
		((Control)KEY_C).Text = "C";
		((ButtonBase)KEY_C).UseVisualStyleBackColor = true;
		((Control)KEY_C).Click += KEY_C_Click;
		((Control)KEY_D).Location = new Point(156, 94);
		((Control)KEY_D).Name = "KEY_D";
		((Control)KEY_D).Size = new Size(45, 23);
		((Control)KEY_D).TabIndex = 3;
		((Control)KEY_D).Text = "D";
		((ButtonBase)KEY_D).UseVisualStyleBackColor = true;
		((Control)KEY_D).Click += KEY_D_Click;
		((Control)KEY_E).Location = new Point(207, 94);
		((Control)KEY_E).Name = "KEY_E";
		((Control)KEY_E).Size = new Size(45, 23);
		((Control)KEY_E).TabIndex = 4;
		((Control)KEY_E).Text = "E";
		((ButtonBase)KEY_E).UseVisualStyleBackColor = true;
		((Control)KEY_E).Click += KEY_E_Click;
		((Control)KEY_F).Location = new Point(258, 94);
		((Control)KEY_F).Name = "KEY_F";
		((Control)KEY_F).Size = new Size(45, 23);
		((Control)KEY_F).TabIndex = 5;
		((Control)KEY_F).Text = "F";
		((ButtonBase)KEY_F).UseVisualStyleBackColor = true;
		((Control)KEY_F).Click += KEY_F_Click;
		((Control)KEY_G).Location = new Point(309, 94);
		((Control)KEY_G).Name = "KEY_G";
		((Control)KEY_G).Size = new Size(45, 23);
		((Control)KEY_G).TabIndex = 7;
		((Control)KEY_G).Text = "G";
		((ButtonBase)KEY_G).UseVisualStyleBackColor = true;
		((Control)KEY_G).Click += KEY_G_Click;
		((Control)KEY_H).Location = new Point(360, 94);
		((Control)KEY_H).Name = "KEY_H";
		((Control)KEY_H).Size = new Size(45, 23);
		((Control)KEY_H).TabIndex = 8;
		((Control)KEY_H).Text = "H";
		((ButtonBase)KEY_H).UseVisualStyleBackColor = true;
		((Control)KEY_H).Click += KEY_H_Click;
		((Control)KEY_I).Location = new Point(411, 94);
		((Control)KEY_I).Name = "KEY_I";
		((Control)KEY_I).Size = new Size(45, 23);
		((Control)KEY_I).TabIndex = 9;
		((Control)KEY_I).Text = "I";
		((ButtonBase)KEY_I).UseVisualStyleBackColor = true;
		((Control)KEY_I).Click += KEY_I_Click;
		((Control)KEY_J).Location = new Point(462, 94);
		((Control)KEY_J).Name = "KEY_J";
		((Control)KEY_J).Size = new Size(45, 23);
		((Control)KEY_J).TabIndex = 10;
		((Control)KEY_J).Text = "J";
		((ButtonBase)KEY_J).UseVisualStyleBackColor = true;
		((Control)KEY_J).Click += KEY_J_Click;
		((Control)KEY_K).Location = new Point(513, 94);
		((Control)KEY_K).Name = "KEY_K";
		((Control)KEY_K).Size = new Size(45, 23);
		((Control)KEY_K).TabIndex = 11;
		((Control)KEY_K).Text = "K";
		((ButtonBase)KEY_K).UseVisualStyleBackColor = true;
		((Control)KEY_K).Click += KEY_K_Click;
		((Control)KEY_W).Location = new Point(464, 123);
		((Control)KEY_W).Name = "KEY_W";
		((Control)KEY_W).Size = new Size(45, 23);
		((Control)KEY_W).TabIndex = 23;
		((Control)KEY_W).Text = "W";
		((ButtonBase)KEY_W).UseVisualStyleBackColor = true;
		((Control)KEY_W).Click += KEY_W_Click;
		((Control)KEY_V).Location = new Point(413, 123);
		((Control)KEY_V).Name = "KEY_V";
		((Control)KEY_V).Size = new Size(45, 23);
		((Control)KEY_V).TabIndex = 22;
		((Control)KEY_V).Text = "V";
		((ButtonBase)KEY_V).UseVisualStyleBackColor = true;
		((Control)KEY_V).Click += KEY_V_Click;
		((Control)KEY_U).Location = new Point(362, 123);
		((Control)KEY_U).Name = "KEY_U";
		((Control)KEY_U).Size = new Size(45, 23);
		((Control)KEY_U).TabIndex = 21;
		((Control)KEY_U).Text = "U";
		((ButtonBase)KEY_U).UseVisualStyleBackColor = true;
		((Control)KEY_U).Click += KEY_U_Click;
		((Control)KEY_T).Location = new Point(309, 123);
		((Control)KEY_T).Name = "KEY_T";
		((Control)KEY_T).Size = new Size(47, 23);
		((Control)KEY_T).TabIndex = 20;
		((Control)KEY_T).Text = "T";
		((ButtonBase)KEY_T).UseVisualStyleBackColor = true;
		((Control)KEY_T).Click += KEY_T_Click;
		((Control)KEY_S).Location = new Point(260, 123);
		((Control)KEY_S).Name = "KEY_S";
		((Control)KEY_S).Size = new Size(45, 23);
		((Control)KEY_S).TabIndex = 19;
		((Control)KEY_S).Text = "S";
		((ButtonBase)KEY_S).UseVisualStyleBackColor = true;
		((Control)KEY_S).Click += KEY_S_Click;
		((Control)KEY_R).Location = new Point(209, 123);
		((Control)KEY_R).Name = "KEY_R";
		((Control)KEY_R).Size = new Size(45, 23);
		((Control)KEY_R).TabIndex = 18;
		((Control)KEY_R).Text = "R";
		((ButtonBase)KEY_R).UseVisualStyleBackColor = true;
		((Control)KEY_R).Click += KEY_R_Click;
		((Control)KEY_Q).Location = new Point(158, 123);
		((Control)KEY_Q).Name = "KEY_Q";
		((Control)KEY_Q).Size = new Size(45, 23);
		((Control)KEY_Q).TabIndex = 17;
		((Control)KEY_Q).Text = "Q";
		((ButtonBase)KEY_Q).UseVisualStyleBackColor = true;
		((Control)KEY_Q).Click += KEY_Q_Click;
		((Control)KEY_P).Location = new Point(105, 123);
		((Control)KEY_P).Name = "KEY_P";
		((Control)KEY_P).Size = new Size(47, 23);
		((Control)KEY_P).TabIndex = 16;
		((Control)KEY_P).Text = "P";
		((ButtonBase)KEY_P).UseVisualStyleBackColor = true;
		((Control)KEY_P).Click += KEY_P_Click;
		((Control)KEY_O).Location = new Point(56, 123);
		((Control)KEY_O).Name = "KEY_O";
		((Control)KEY_O).Size = new Size(45, 23);
		((Control)KEY_O).TabIndex = 15;
		((Control)KEY_O).Text = "O";
		((ButtonBase)KEY_O).UseVisualStyleBackColor = true;
		((Control)KEY_O).Click += KEY_O_Click;
		((Control)KEY_N).Location = new Point(5, 123);
		((Control)KEY_N).Name = "KEY_N";
		((Control)KEY_N).Size = new Size(45, 23);
		((Control)KEY_N).TabIndex = 14;
		((Control)KEY_N).Text = "N";
		((ButtonBase)KEY_N).UseVisualStyleBackColor = true;
		((Control)KEY_N).Click += KEY_N_Click;
		((Control)KEY_M).Location = new Point(616, 94);
		((Control)KEY_M).Name = "KEY_M";
		((Control)KEY_M).Size = new Size(46, 23);
		((Control)KEY_M).TabIndex = 13;
		((Control)KEY_M).Text = "M";
		((ButtonBase)KEY_M).UseVisualStyleBackColor = true;
		((Control)KEY_M).Click += KEY_M_Click;
		((Control)KEY_L).Location = new Point(565, 94);
		((Control)KEY_L).Name = "KEY_L";
		((Control)KEY_L).Size = new Size(44, 23);
		((Control)KEY_L).TabIndex = 12;
		((Control)KEY_L).Text = "L";
		((ButtonBase)KEY_L).UseVisualStyleBackColor = true;
		((Control)KEY_L).Click += KEY_L_Click;
		((Control)KEY_8).Location = new Point(411, 65);
		((Control)KEY_8).Name = "KEY_8";
		((Control)KEY_8).Size = new Size(45, 23);
		((Control)KEY_8).TabIndex = 35;
		((Control)KEY_8).Text = "* 8";
		((ButtonBase)KEY_8).UseVisualStyleBackColor = true;
		((Control)KEY_8).Click += KEY_8_Click;
		((Control)KEY_7).Location = new Point(360, 65);
		((Control)KEY_7).Name = "KEY_7";
		((Control)KEY_7).Size = new Size(45, 23);
		((Control)KEY_7).TabIndex = 34;
		((Control)KEY_7).Text = "＆ 7";
		((ButtonBase)KEY_7).UseVisualStyleBackColor = true;
		((Control)KEY_7).Click += KEY_7_Click;
		((Control)KEY_6).Location = new Point(309, 65);
		((Control)KEY_6).Name = "KEY_6";
		((Control)KEY_6).Size = new Size(45, 23);
		((Control)KEY_6).TabIndex = 33;
		((Control)KEY_6).Text = "^ 6";
		((ButtonBase)KEY_6).UseVisualStyleBackColor = true;
		((Control)KEY_6).Click += KEY_6_Click;
		((Control)KEY_5).Location = new Point(258, 65);
		((Control)KEY_5).Name = "KEY_5";
		((Control)KEY_5).Size = new Size(45, 23);
		((Control)KEY_5).TabIndex = 32;
		((Control)KEY_5).Text = "% 5";
		((ButtonBase)KEY_5).UseVisualStyleBackColor = true;
		((Control)KEY_5).Click += KEY_5_Click;
		((Control)KEY_4).Location = new Point(207, 65);
		((Control)KEY_4).Name = "KEY_4";
		((Control)KEY_4).Size = new Size(45, 23);
		((Control)KEY_4).TabIndex = 31;
		((Control)KEY_4).Text = "$ 4";
		((ButtonBase)KEY_4).UseVisualStyleBackColor = true;
		((Control)KEY_4).Click += KEY_4_Click;
		((Control)KEY_3).Location = new Point(156, 65);
		((Control)KEY_3).Name = "KEY_3";
		((Control)KEY_3).Size = new Size(45, 23);
		((Control)KEY_3).TabIndex = 30;
		((Control)KEY_3).Text = "# 3";
		((ButtonBase)KEY_3).UseVisualStyleBackColor = true;
		((Control)KEY_3).Click += KEY_3_Click;
		((Control)KEY_2).Location = new Point(105, 65);
		((Control)KEY_2).Name = "KEY_2";
		((Control)KEY_2).Size = new Size(45, 23);
		((Control)KEY_2).TabIndex = 29;
		((Control)KEY_2).Text = "@ 2";
		((ButtonBase)KEY_2).UseVisualStyleBackColor = true;
		((Control)KEY_2).Click += KEY_2_Click;
		((Control)KEY_1).Location = new Point(54, 65);
		((Control)KEY_1).Name = "KEY_1";
		((Control)KEY_1).Size = new Size(45, 23);
		((Control)KEY_1).TabIndex = 28;
		((Control)KEY_1).Text = "! 1";
		((ButtonBase)KEY_1).UseVisualStyleBackColor = true;
		((Control)KEY_1).Click += KEY_1_Click;
		((Control)KEY_9).Location = new Point(462, 65);
		((Control)KEY_9).Name = "KEY_9";
		((Control)KEY_9).Size = new Size(45, 23);
		((Control)KEY_9).TabIndex = 27;
		((Control)KEY_9).Text = "( 9";
		((ButtonBase)KEY_9).UseVisualStyleBackColor = true;
		((Control)KEY_9).Click += KEY_9_Click;
		((Control)KEY_Z).Location = new Point(615, 123);
		((Control)KEY_Z).Name = "KEY_Z";
		((Control)KEY_Z).Size = new Size(47, 23);
		((Control)KEY_Z).TabIndex = 26;
		((Control)KEY_Z).Text = "Z";
		((ButtonBase)KEY_Z).UseVisualStyleBackColor = true;
		((Control)KEY_Z).Click += KEY_Z_Click;
		((Control)KEY_Y).Location = new Point(565, 123);
		((Control)KEY_Y).Name = "KEY_Y";
		((Control)KEY_Y).Size = new Size(45, 23);
		((Control)KEY_Y).TabIndex = 25;
		((Control)KEY_Y).Text = "Y";
		((ButtonBase)KEY_Y).UseVisualStyleBackColor = true;
		((Control)KEY_Y).Click += KEY_Y_Click;
		((Control)KEY_X).Location = new Point(515, 123);
		((Control)KEY_X).Name = "KEY_X";
		((Control)KEY_X).Size = new Size(44, 23);
		((Control)KEY_X).TabIndex = 24;
		((Control)KEY_X).Text = "X";
		((ButtonBase)KEY_X).UseVisualStyleBackColor = true;
		((Control)KEY_X).Click += KEY_X_Click;
		((Control)KEY_0).Location = new Point(512, 65);
		((Control)KEY_0).Name = "KEY_0";
		((Control)KEY_0).Size = new Size(45, 23);
		((Control)KEY_0).TabIndex = 36;
		((Control)KEY_0).Text = ") 0";
		((ButtonBase)KEY_0).UseVisualStyleBackColor = true;
		((Control)KEY_0).Click += KEY_0_Click;
		((Control)KEY_F12).Location = new Point(617, 7);
		((Control)KEY_F12).Name = "KEY_F12";
		((Control)KEY_F12).Size = new Size(44, 23);
		((Control)KEY_F12).TabIndex = 48;
		((Control)KEY_F12).Text = "F12";
		((ButtonBase)KEY_F12).UseVisualStyleBackColor = true;
		((Control)KEY_F12).Click += KEY_F12_Click;
		((Control)KEY_F11).Location = new Point(566, 7);
		((Control)KEY_F11).Name = "KEY_F11";
		((Control)KEY_F11).Size = new Size(45, 23);
		((Control)KEY_F11).TabIndex = 47;
		((Control)KEY_F11).Text = "F11";
		((ButtonBase)KEY_F11).UseVisualStyleBackColor = true;
		((Control)KEY_F11).Click += KEY_F11_Click;
		((Control)KEY_F10).Location = new Point(515, 7);
		((Control)KEY_F10).Name = "KEY_F10";
		((Control)KEY_F10).Size = new Size(45, 23);
		((Control)KEY_F10).TabIndex = 46;
		((Control)KEY_F10).Text = "F10";
		((ButtonBase)KEY_F10).UseVisualStyleBackColor = true;
		((Control)KEY_F10).Click += KEY_F10_Click;
		((Control)KEY_F9).Location = new Point(464, 7);
		((Control)KEY_F9).Name = "KEY_F9";
		((Control)KEY_F9).Size = new Size(45, 23);
		((Control)KEY_F9).TabIndex = 45;
		((Control)KEY_F9).Text = "F9";
		((ButtonBase)KEY_F9).UseVisualStyleBackColor = true;
		((Control)KEY_F9).Click += KEY_F9_Click;
		((Control)KEY_F8).Location = new Point(413, 7);
		((Control)KEY_F8).Name = "KEY_F8";
		((Control)KEY_F8).Size = new Size(45, 23);
		((Control)KEY_F8).TabIndex = 44;
		((Control)KEY_F8).Text = "F8";
		((ButtonBase)KEY_F8).UseVisualStyleBackColor = true;
		((Control)KEY_F8).Click += KEY_F8_Click;
		((Control)KEY_F7).Location = new Point(362, 7);
		((Control)KEY_F7).Name = "KEY_F7";
		((Control)KEY_F7).Size = new Size(45, 23);
		((Control)KEY_F7).TabIndex = 43;
		((Control)KEY_F7).Text = "F7";
		((ButtonBase)KEY_F7).UseVisualStyleBackColor = true;
		((Control)KEY_F7).Click += KEY_F7_Click;
		((Control)KEY_F6).Location = new Point(311, 7);
		((Control)KEY_F6).Name = "KEY_F6";
		((Control)KEY_F6).Size = new Size(45, 23);
		((Control)KEY_F6).TabIndex = 42;
		((Control)KEY_F6).Text = "F6";
		((ButtonBase)KEY_F6).UseVisualStyleBackColor = true;
		((Control)KEY_F6).Click += KEY_F6_Click;
		((Control)KEY_F5).Location = new Point(260, 7);
		((Control)KEY_F5).Name = "KEY_F5";
		((Control)KEY_F5).Size = new Size(45, 23);
		((Control)KEY_F5).TabIndex = 41;
		((Control)KEY_F5).Text = "F5";
		((ButtonBase)KEY_F5).UseVisualStyleBackColor = true;
		((Control)KEY_F5).Click += KEY_F5_Click;
		((Control)KEY_F4).Location = new Point(209, 7);
		((Control)KEY_F4).Name = "KEY_F4";
		((Control)KEY_F4).Size = new Size(45, 23);
		((Control)KEY_F4).TabIndex = 40;
		((Control)KEY_F4).Text = "F4";
		((ButtonBase)KEY_F4).UseVisualStyleBackColor = true;
		((Control)KEY_F4).Click += KEY_F4_Click;
		((Control)KEY_F3).Location = new Point(158, 7);
		((Control)KEY_F3).Name = "KEY_F3";
		((Control)KEY_F3).Size = new Size(45, 23);
		((Control)KEY_F3).TabIndex = 39;
		((Control)KEY_F3).Text = "F3";
		((ButtonBase)KEY_F3).UseVisualStyleBackColor = true;
		((Control)KEY_F3).Click += KEY_F3_Click;
		((Control)KEY_F2).Location = new Point(107, 7);
		((Control)KEY_F2).Name = "KEY_F2";
		((Control)KEY_F2).Size = new Size(45, 23);
		((Control)KEY_F2).TabIndex = 38;
		((Control)KEY_F2).Text = "F2";
		((ButtonBase)KEY_F2).UseVisualStyleBackColor = true;
		((Control)KEY_F2).Click += KEY_F2_Click;
		((Control)KEY_F1).Location = new Point(56, 5);
		((Control)KEY_F1).Name = "KEY_F1";
		((Control)KEY_F1).Size = new Size(45, 23);
		((Control)KEY_F1).TabIndex = 37;
		((Control)KEY_F1).Text = "F1";
		((ButtonBase)KEY_F1).UseVisualStyleBackColor = true;
		((Control)KEY_F1).Click += KEY_F1_Click;
		((Control)KEY_ESC).Location = new Point(4, 5);
		((Control)KEY_ESC).Name = "KEY_ESC";
		((Control)KEY_ESC).Size = new Size(45, 23);
		((Control)KEY_ESC).TabIndex = 49;
		((Control)KEY_ESC).Text = "ESC";
		((ButtonBase)KEY_ESC).UseVisualStyleBackColor = true;
		((Control)KEY_ESC).Click += KEY_ESC_Click;
		((Control)KEY_PrtSc).Location = new Point(4, 36);
		((Control)KEY_PrtSc).Name = "KEY_PrtSc";
		((Control)KEY_PrtSc).Size = new Size(76, 23);
		((Control)KEY_PrtSc).TabIndex = 50;
		((Control)KEY_PrtSc).Text = "PrtScSysRq";
		((ButtonBase)KEY_PrtSc).UseVisualStyleBackColor = true;
		((Control)KEY_PrtSc).Click += KEY_PrtSc_Click;
		((Control)KEY_PauseBreak).Location = new Point(173, 36);
		((Control)KEY_PauseBreak).Name = "KEY_PauseBreak";
		((Control)KEY_PauseBreak).Size = new Size(90, 23);
		((Control)KEY_PauseBreak).TabIndex = 51;
		((Control)KEY_PauseBreak).Text = "PauseBreak";
		((ButtonBase)KEY_PauseBreak).UseVisualStyleBackColor = true;
		((Control)KEY_PauseBreak).Click += KEY_PauseBreak_Click;
		((Control)KEY_INS).Location = new Point(269, 36);
		((Control)KEY_INS).Name = "KEY_INS";
		((Control)KEY_INS).Size = new Size(54, 23);
		((Control)KEY_INS).TabIndex = 52;
		((Control)KEY_INS).Text = "Insert";
		((ButtonBase)KEY_INS).UseVisualStyleBackColor = true;
		((Control)KEY_INS).Click += KEY_INS_Click;
		((Control)KEY_DEL).Location = new Point(329, 36);
		((Control)KEY_DEL).Name = "KEY_DEL";
		((Control)KEY_DEL).Size = new Size(63, 23);
		((Control)KEY_DEL).TabIndex = 53;
		((Control)KEY_DEL).Text = "Delete";
		((ButtonBase)KEY_DEL).UseVisualStyleBackColor = true;
		((Control)KEY_DEL).Click += KEY_DEL_Click;
		((Control)KEY_HOME).Location = new Point(398, 36);
		((Control)KEY_HOME).Name = "KEY_HOME";
		((Control)KEY_HOME).Size = new Size(58, 23);
		((Control)KEY_HOME).TabIndex = 54;
		((Control)KEY_HOME).Text = "Home";
		((ButtonBase)KEY_HOME).UseVisualStyleBackColor = true;
		((Control)KEY_HOME).Click += KEY_HOME_Click;
		((Control)KEY_PgUg).Location = new Point(462, 36);
		((Control)KEY_PgUg).Name = "KEY_PgUg";
		((Control)KEY_PgUg).Size = new Size(62, 23);
		((Control)KEY_PgUg).TabIndex = 56;
		((Control)KEY_PgUg).Text = "Page Up";
		((ButtonBase)KEY_PgUg).UseVisualStyleBackColor = true;
		((Control)KEY_PgUg).Click += KEY_PgUg_Click;
		((Control)KEY_PgDn).Location = new Point(532, 36);
		((Control)KEY_PgDn).Name = "KEY_PgDn";
		((Control)KEY_PgDn).Size = new Size(70, 23);
		((Control)KEY_PgDn).TabIndex = 57;
		((Control)KEY_PgDn).Text = "Page Down";
		((ButtonBase)KEY_PgDn).UseVisualStyleBackColor = true;
		((Control)KEY_PgDn).Click += KEY_PgDn_Click;
		((Control)KEY_End).Location = new Point(608, 36);
		((Control)KEY_End).Name = "KEY_End";
		((Control)KEY_End).Size = new Size(53, 23);
		((Control)KEY_End).TabIndex = 58;
		((Control)KEY_End).Text = "End";
		((ButtonBase)KEY_End).UseVisualStyleBackColor = true;
		((Control)KEY_End).Click += KEY_End_Click;
		((Control)KEY_SubSub).Location = new Point(565, 65);
		((Control)KEY_SubSub).Name = "KEY_SubSub";
		((Control)KEY_SubSub).Size = new Size(45, 23);
		((Control)KEY_SubSub).TabIndex = 59;
		((Control)KEY_SubSub).Text = "\uffe3－";
		((ButtonBase)KEY_SubSub).UseVisualStyleBackColor = true;
		((Control)KEY_SubSub).Click += KEY_SubSub_Click;
		((Control)KEY_ADDADD).Location = new Point(617, 65);
		((Control)KEY_ADDADD).Name = "KEY_ADDADD";
		((Control)KEY_ADDADD).Size = new Size(45, 23);
		((Control)KEY_ADDADD).TabIndex = 60;
		((Control)KEY_ADDADD).Text = "＋=";
		((ButtonBase)KEY_ADDADD).UseVisualStyleBackColor = true;
		((Control)KEY_ADDADD).Click += KEY_ADDADD_Click;
		((Control)KEY_BACKSPACE).Location = new Point(372, 181);
		((Control)KEY_BACKSPACE).Name = "KEY_BACKSPACE";
		((Control)KEY_BACKSPACE).Size = new Size(92, 23);
		((Control)KEY_BACKSPACE).TabIndex = 61;
		((Control)KEY_BACKSPACE).Text = "← Backspace";
		((ButtonBase)KEY_BACKSPACE).UseVisualStyleBackColor = true;
		((Control)KEY_BACKSPACE).Click += KEY_BACKSPACE_Click;
		((Control)KEY_Tabel).Location = new Point(4, 152);
		((Control)KEY_Tabel).Name = "KEY_Tabel";
		((Control)KEY_Tabel).Size = new Size(97, 23);
		((Control)KEY_Tabel).TabIndex = 62;
		((Control)KEY_Tabel).Text = "Tab";
		((ButtonBase)KEY_Tabel).UseVisualStyleBackColor = true;
		((Control)KEY_Tabel).Click += KEY_Tabel_Click;
		((Control)KEY_kuohao).Location = new Point(309, 152);
		((Control)KEY_kuohao).Name = "KEY_kuohao";
		((Control)KEY_kuohao).Size = new Size(45, 23);
		((Control)KEY_kuohao).TabIndex = 63;
		((Control)KEY_kuohao).Text = "{ [";
		((ButtonBase)KEY_kuohao).UseVisualStyleBackColor = true;
		((Control)KEY_kuohao).Click += KEY_kuohao_Click;
		((Control)KEY_kuohao2).Location = new Point(362, 152);
		((Control)KEY_kuohao2).Name = "KEY_kuohao2";
		((Control)KEY_kuohao2).Size = new Size(45, 23);
		((Control)KEY_kuohao2).TabIndex = 64;
		((Control)KEY_kuohao2).Text = "} ]";
		((ButtonBase)KEY_kuohao2).UseVisualStyleBackColor = true;
		((Control)KEY_kuohao2).Click += KEY_kuohao2_Click;
		((Control)KEY_shu).Location = new Point(413, 152);
		((Control)KEY_shu).Name = "KEY_shu";
		((Control)KEY_shu).Size = new Size(45, 23);
		((Control)KEY_shu).TabIndex = 65;
		((Control)KEY_shu).Text = "| \\";
		((ButtonBase)KEY_shu).UseVisualStyleBackColor = true;
		((Control)KEY_shu).Click += KEY_shu_Click;
		((Control)KEY_fenhao).Location = new Point(464, 152);
		((Control)KEY_fenhao).Name = "KEY_fenhao";
		((Control)KEY_fenhao).Size = new Size(45, 23);
		((Control)KEY_fenhao).TabIndex = 66;
		((Control)KEY_fenhao).Text = "： ；";
		((ButtonBase)KEY_fenhao).UseVisualStyleBackColor = true;
		((Control)KEY_fenhao).Click += KEY_fenhao_Click;
		((Control)KEY_yinghao).Location = new Point(513, 152);
		((Control)KEY_yinghao).Name = "KEY_yinghao";
		((Control)KEY_yinghao).Size = new Size(45, 23);
		((Control)KEY_yinghao).TabIndex = 67;
		((Control)KEY_yinghao).Text = "＂ ＇";
		((ButtonBase)KEY_yinghao).UseVisualStyleBackColor = true;
		((Control)KEY_yinghao).Click += KEY_yinghao_Click;
		((Control)KEY_Enter).Location = new Point(209, 152);
		((Control)KEY_Enter).Name = "KEY_Enter";
		((Control)KEY_Enter).Size = new Size(94, 23);
		((Control)KEY_Enter).TabIndex = 68;
		((Control)KEY_Enter).Text = "Enter";
		((ButtonBase)KEY_Enter).UseVisualStyleBackColor = true;
		((Control)KEY_Enter).Click += KEY_Enter_Click;
		((Control)KEY_bolanghao).Location = new Point(4, 65);
		((Control)KEY_bolanghao).Name = "KEY_bolanghao";
		((Control)KEY_bolanghao).Size = new Size(45, 23);
		((Control)KEY_bolanghao).TabIndex = 69;
		((Control)KEY_bolanghao).Text = "~ 、";
		((ButtonBase)KEY_bolanghao).UseVisualStyleBackColor = true;
		((Control)KEY_bolanghao).Click += KEY_bolanghao_Click;
		((Control)KEY_douhao).Location = new Point(564, 152);
		((Control)KEY_douhao).Name = "KEY_douhao";
		((Control)KEY_douhao).Size = new Size(47, 23);
		((Control)KEY_douhao).TabIndex = 70;
		((Control)KEY_douhao).Text = "＜ ，";
		((ButtonBase)KEY_douhao).UseVisualStyleBackColor = true;
		((Control)KEY_douhao).Click += KEY_douhao_Click;
		((Control)KEY_juhao).Location = new Point(616, 152);
		((Control)KEY_juhao).Name = "KEY_juhao";
		((Control)KEY_juhao).Size = new Size(46, 23);
		((Control)KEY_juhao).TabIndex = 71;
		((Control)KEY_juhao).Text = "＞ .";
		((ButtonBase)KEY_juhao).UseVisualStyleBackColor = true;
		((Control)KEY_juhao).Click += KEY_juhao_Click;
		((Control)KEY_wenhao).Location = new Point(667, 152);
		((Control)KEY_wenhao).Name = "KEY_wenhao";
		((Control)KEY_wenhao).Size = new Size(45, 23);
		((Control)KEY_wenhao).TabIndex = 72;
		((Control)KEY_wenhao).Text = "?  /";
		((ButtonBase)KEY_wenhao).UseVisualStyleBackColor = true;
		((Control)KEY_wenhao).Click += KEY_wenhao_Click;
		((Control)KEY_jiantou_left).Location = new Point(667, 7);
		((Control)KEY_jiantou_left).Name = "KEY_jiantou_left";
		((Control)KEY_jiantou_left).Size = new Size(45, 23);
		((Control)KEY_jiantou_left).TabIndex = 73;
		((Control)KEY_jiantou_left).Text = "←";
		((ButtonBase)KEY_jiantou_left).UseVisualStyleBackColor = true;
		((Control)KEY_jiantou_left).Click += KEY_jiantou_left_Click;
		((Control)KEY_jiantou_Up).Location = new Point(668, 65);
		((Control)KEY_jiantou_Up).Name = "KEY_jiantou_Up";
		((Control)KEY_jiantou_Up).Size = new Size(45, 23);
		((Control)KEY_jiantou_Up).TabIndex = 74;
		((Control)KEY_jiantou_Up).Text = "↑";
		((ButtonBase)KEY_jiantou_Up).UseVisualStyleBackColor = true;
		((Control)KEY_jiantou_Up).Click += KEY_jiantou_Up_Click;
		((Control)KEY_jiantou_Down).Location = new Point(668, 94);
		((Control)KEY_jiantou_Down).Name = "KEY_jiantou_Down";
		((Control)KEY_jiantou_Down).Size = new Size(45, 23);
		((Control)KEY_jiantou_Down).TabIndex = 75;
		((Control)KEY_jiantou_Down).Text = "↓";
		((ButtonBase)KEY_jiantou_Down).UseVisualStyleBackColor = true;
		((Control)KEY_jiantou_Down).Click += KEY_jiantou_Down_Click;
		((Control)KEY_jiantou_right).Location = new Point(668, 36);
		((Control)KEY_jiantou_right).Name = "KEY_jiantou_right";
		((Control)KEY_jiantou_right).Size = new Size(45, 23);
		((Control)KEY_jiantou_right).TabIndex = 76;
		((Control)KEY_jiantou_right).Text = "→";
		((ButtonBase)KEY_jiantou_right).UseVisualStyleBackColor = true;
		((Control)KEY_jiantou_right).Click += KEY_jiantou_right_Click;
		((Control)KEY_add).Location = new Point(470, 181);
		((Control)KEY_add).Name = "KEY_add";
		((Control)KEY_add).Size = new Size(62, 23);
		((Control)KEY_add).TabIndex = 77;
		((Control)KEY_add).Text = "＋";
		((ButtonBase)KEY_add).UseVisualStyleBackColor = true;
		((Control)KEY_add).Click += KEY_add_Click;
		((Control)KEY_sub).Location = new Point(538, 181);
		((Control)KEY_sub).Name = "KEY_sub";
		((Control)KEY_sub).Size = new Size(53, 23);
		((Control)KEY_sub).TabIndex = 78;
		((Control)KEY_sub).Text = "－";
		((ButtonBase)KEY_sub).UseVisualStyleBackColor = true;
		((Control)KEY_sub).Click += KEY_sub_Click;
		((Control)KEY_multiply).Location = new Point(597, 181);
		((Control)KEY_multiply).Name = "KEY_multiply";
		((Control)KEY_multiply).Size = new Size(54, 23);
		((Control)KEY_multiply).TabIndex = 79;
		((Control)KEY_multiply).Text = "×";
		((ButtonBase)KEY_multiply).UseVisualStyleBackColor = true;
		((Control)KEY_multiply).Click += KEY_multiply_Click;
		((Control)KEY_DIV).Location = new Point(657, 181);
		((Control)KEY_DIV).Name = "KEY_DIV";
		((Control)KEY_DIV).Size = new Size(55, 23);
		((Control)KEY_DIV).TabIndex = 80;
		((Control)KEY_DIV).Text = "÷";
		((ButtonBase)KEY_DIV).UseVisualStyleBackColor = true;
		((Control)KEY_DIV).Click += KEY_DIV_Click;
		((Control)KEY_NUM).Location = new Point(5, 210);
		((Control)KEY_NUM).Name = "KEY_NUM";
		((Control)KEY_NUM).Size = new Size(95, 23);
		((Control)KEY_NUM).TabIndex = 91;
		((Control)KEY_NUM).Text = "NumLock";
		((ButtonBase)KEY_NUM).UseVisualStyleBackColor = true;
		((Control)KEY_NUM).Click += KEY_NUM_Click;
		((Control)KEY_MIN_0).Location = new Point(564, 210);
		((Control)KEY_MIN_0).Name = "KEY_MIN_0";
		((Control)KEY_MIN_0).Size = new Size(45, 23);
		((Control)KEY_MIN_0).TabIndex = 90;
		((Control)KEY_MIN_0).Text = "0";
		((ButtonBase)KEY_MIN_0).UseVisualStyleBackColor = true;
		((Control)KEY_MIN_0).Click += KEY_MIN_0_Click;
		((Control)KEY_MIN_9).Location = new Point(513, 210);
		((Control)KEY_MIN_9).Name = "KEY_MIN_9";
		((Control)KEY_MIN_9).Size = new Size(45, 23);
		((Control)KEY_MIN_9).TabIndex = 89;
		((Control)KEY_MIN_9).Text = "9";
		((ButtonBase)KEY_MIN_9).UseVisualStyleBackColor = true;
		((Control)KEY_MIN_9).Click += KEY_MIN_9_Click;
		((Control)KEY_MIN_8).Location = new Point(462, 210);
		((Control)KEY_MIN_8).Name = "KEY_MIN_8";
		((Control)KEY_MIN_8).Size = new Size(45, 23);
		((Control)KEY_MIN_8).TabIndex = 88;
		((Control)KEY_MIN_8).Text = "8";
		((ButtonBase)KEY_MIN_8).UseVisualStyleBackColor = true;
		((Control)KEY_MIN_8).Click += KEY_MIN_8_Click;
		((Control)KEY_MIN_7).Location = new Point(411, 210);
		((Control)KEY_MIN_7).Name = "KEY_MIN_7";
		((Control)KEY_MIN_7).Size = new Size(45, 23);
		((Control)KEY_MIN_7).TabIndex = 87;
		((Control)KEY_MIN_7).Text = "7";
		((ButtonBase)KEY_MIN_7).UseVisualStyleBackColor = true;
		((Control)KEY_MIN_7).Click += KEY_MIN_7_Click;
		((Control)KEY_MIN_6).Location = new Point(360, 210);
		((Control)KEY_MIN_6).Name = "KEY_MIN_6";
		((Control)KEY_MIN_6).Size = new Size(45, 23);
		((Control)KEY_MIN_6).TabIndex = 86;
		((Control)KEY_MIN_6).Text = "6";
		((ButtonBase)KEY_MIN_6).UseVisualStyleBackColor = true;
		((Control)KEY_MIN_6).Click += KEY_MIN_6_Click;
		((Control)KEY_MIN_5).Location = new Point(309, 210);
		((Control)KEY_MIN_5).Name = "KEY_MIN_5";
		((Control)KEY_MIN_5).Size = new Size(45, 23);
		((Control)KEY_MIN_5).TabIndex = 85;
		((Control)KEY_MIN_5).Text = "5";
		((ButtonBase)KEY_MIN_5).UseVisualStyleBackColor = true;
		((Control)KEY_MIN_5).Click += KEY_MIN_5_Click;
		((Control)KEY_MIN_4).Location = new Point(258, 210);
		((Control)KEY_MIN_4).Name = "KEY_MIN_4";
		((Control)KEY_MIN_4).Size = new Size(45, 23);
		((Control)KEY_MIN_4).TabIndex = 84;
		((Control)KEY_MIN_4).Text = "4";
		((ButtonBase)KEY_MIN_4).UseVisualStyleBackColor = true;
		((Control)KEY_MIN_4).Click += KEY_MIN_4_Click;
		((Control)KEY_MIN_3).Location = new Point(207, 210);
		((Control)KEY_MIN_3).Name = "KEY_MIN_3";
		((Control)KEY_MIN_3).Size = new Size(45, 23);
		((Control)KEY_MIN_3).TabIndex = 83;
		((Control)KEY_MIN_3).Text = "3";
		((ButtonBase)KEY_MIN_3).UseVisualStyleBackColor = true;
		((Control)KEY_MIN_3).Click += KEY_MIN_3_Click;
		((Control)KEY_MIN_2).Location = new Point(156, 210);
		((Control)KEY_MIN_2).Name = "KEY_MIN_2";
		((Control)KEY_MIN_2).Size = new Size(45, 23);
		((Control)KEY_MIN_2).TabIndex = 82;
		((Control)KEY_MIN_2).Text = "2";
		((ButtonBase)KEY_MIN_2).UseVisualStyleBackColor = true;
		((Control)KEY_MIN_2).Click += KEY_MIN_2_Click;
		((Control)KEY_MIN_1).Location = new Point(106, 210);
		((Control)KEY_MIN_1).Name = "KEY_MIN_1";
		((Control)KEY_MIN_1).Size = new Size(44, 23);
		((Control)KEY_MIN_1).TabIndex = 81;
		((Control)KEY_MIN_1).Text = "1";
		((ButtonBase)KEY_MIN_1).UseVisualStyleBackColor = true;
		((Control)KEY_MIN_1).Click += KEY_MIN_1_Click;
		((Control)KEY_MIN_Dot).Location = new Point(614, 210);
		((Control)KEY_MIN_Dot).Name = "KEY_MIN_Dot";
		((Control)KEY_MIN_Dot).Size = new Size(45, 23);
		((Control)KEY_MIN_Dot).TabIndex = 92;
		((Control)KEY_MIN_Dot).Text = "·";
		((ButtonBase)KEY_MIN_Dot).UseVisualStyleBackColor = true;
		((Control)KEY_MIN_Dot).Click += KEY_MIN_Dot_Click;
		((Control)KEY_CapsLock).Location = new Point(105, 152);
		((Control)KEY_CapsLock).Name = "KEY_CapsLock";
		((Control)KEY_CapsLock).Size = new Size(98, 23);
		((Control)KEY_CapsLock).TabIndex = 93;
		((Control)KEY_CapsLock).Text = "CapsLock";
		((ButtonBase)KEY_CapsLock).UseVisualStyleBackColor = true;
		((Control)KEY_CapsLock).Click += KEY_CapsLock_Click;
		((Control)KEY_SpaceKey).Location = new Point(291, 181);
		((Control)KEY_SpaceKey).Name = "KEY_SpaceKey";
		((Control)KEY_SpaceKey).Size = new Size(75, 23);
		((Control)KEY_SpaceKey).TabIndex = 94;
		((Control)KEY_SpaceKey).Text = "Space";
		((ButtonBase)KEY_SpaceKey).UseVisualStyleBackColor = true;
		((Control)KEY_SpaceKey).Click += KEY_SpaceKey_Click;
		((Control)KEY_ScrollLock).Location = new Point(86, 36);
		((Control)KEY_ScrollLock).Name = "KEY_ScrollLock";
		((Control)KEY_ScrollLock).Size = new Size(81, 23);
		((Control)KEY_ScrollLock).TabIndex = 95;
		((Control)KEY_ScrollLock).Text = "ScrollLock";
		((ButtonBase)KEY_ScrollLock).UseVisualStyleBackColor = true;
		((Control)KEY_ScrollLock).Click += KEY_ScrollLock_Click;
		((Control)KEY_Menu).Font = new Font("宋体", 14.25f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)KEY_Menu).Location = new Point(668, 123);
		((Control)KEY_Menu).Name = "KEY_Menu";
		((Control)KEY_Menu).Size = new Size(44, 23);
		((Control)KEY_Menu).TabIndex = 96;
		((Control)KEY_Menu).Text = "▤";
		((ButtonBase)KEY_Menu).UseVisualStyleBackColor = true;
		((Control)KEY_Menu).Click += KEY_Menu_Click;
		((Control)Key_Ctrl).Location = new Point(5, 181);
		((Control)Key_Ctrl).Name = "Key_Ctrl";
		((Control)Key_Ctrl).Size = new Size(62, 23);
		((Control)Key_Ctrl).TabIndex = 97;
		((Control)Key_Ctrl).Text = "Ctrl";
		((ButtonBase)Key_Ctrl).UseVisualStyleBackColor = true;
		((Control)Key_Ctrl).Click += Key_Ctrl_Click;
		((Control)Key_Shift).Location = new Point(73, 181);
		((Control)Key_Shift).Name = "Key_Shift";
		((Control)Key_Shift).Size = new Size(64, 23);
		((Control)Key_Shift).TabIndex = 98;
		((Control)Key_Shift).Text = "Shift";
		((ButtonBase)Key_Shift).UseVisualStyleBackColor = true;
		((Control)Key_Shift).Click += Key_Shift_Click;
		((Control)Key_Alt).Location = new Point(143, 181);
		((Control)Key_Alt).Name = "Key_Alt";
		((Control)Key_Alt).Size = new Size(60, 23);
		((Control)Key_Alt).TabIndex = 99;
		((Control)Key_Alt).Text = "Alt";
		((ButtonBase)Key_Alt).UseVisualStyleBackColor = true;
		((Control)Key_Alt).Click += Key_Alt_Click;
		((Control)Key_Win).Location = new Point(209, 181);
		((Control)Key_Win).Name = "Key_Win";
		((Control)Key_Win).Size = new Size(76, 23);
		((Control)Key_Win).TabIndex = 100;
		((Control)Key_Win).Text = "Win";
		((ButtonBase)Key_Win).UseVisualStyleBackColor = true;
		((Control)Key_Win).Click += Key_Win_Click;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 12f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).Controls.Add((Control)(object)Key_Win);
		((Control)this).Controls.Add((Control)(object)Key_Alt);
		((Control)this).Controls.Add((Control)(object)Key_Shift);
		((Control)this).Controls.Add((Control)(object)Key_Ctrl);
		((Control)this).Controls.Add((Control)(object)KEY_Menu);
		((Control)this).Controls.Add((Control)(object)KEY_ScrollLock);
		((Control)this).Controls.Add((Control)(object)KEY_SpaceKey);
		((Control)this).Controls.Add((Control)(object)KEY_CapsLock);
		((Control)this).Controls.Add((Control)(object)KEY_MIN_Dot);
		((Control)this).Controls.Add((Control)(object)KEY_NUM);
		((Control)this).Controls.Add((Control)(object)KEY_MIN_0);
		((Control)this).Controls.Add((Control)(object)KEY_MIN_9);
		((Control)this).Controls.Add((Control)(object)KEY_MIN_8);
		((Control)this).Controls.Add((Control)(object)KEY_MIN_7);
		((Control)this).Controls.Add((Control)(object)KEY_MIN_6);
		((Control)this).Controls.Add((Control)(object)KEY_MIN_5);
		((Control)this).Controls.Add((Control)(object)KEY_MIN_4);
		((Control)this).Controls.Add((Control)(object)KEY_MIN_3);
		((Control)this).Controls.Add((Control)(object)KEY_MIN_2);
		((Control)this).Controls.Add((Control)(object)KEY_MIN_1);
		((Control)this).Controls.Add((Control)(object)KEY_DIV);
		((Control)this).Controls.Add((Control)(object)KEY_multiply);
		((Control)this).Controls.Add((Control)(object)KEY_sub);
		((Control)this).Controls.Add((Control)(object)KEY_add);
		((Control)this).Controls.Add((Control)(object)KEY_jiantou_right);
		((Control)this).Controls.Add((Control)(object)KEY_jiantou_Down);
		((Control)this).Controls.Add((Control)(object)KEY_jiantou_Up);
		((Control)this).Controls.Add((Control)(object)KEY_jiantou_left);
		((Control)this).Controls.Add((Control)(object)KEY_wenhao);
		((Control)this).Controls.Add((Control)(object)KEY_juhao);
		((Control)this).Controls.Add((Control)(object)KEY_douhao);
		((Control)this).Controls.Add((Control)(object)KEY_bolanghao);
		((Control)this).Controls.Add((Control)(object)KEY_Enter);
		((Control)this).Controls.Add((Control)(object)KEY_yinghao);
		((Control)this).Controls.Add((Control)(object)KEY_fenhao);
		((Control)this).Controls.Add((Control)(object)KEY_shu);
		((Control)this).Controls.Add((Control)(object)KEY_kuohao2);
		((Control)this).Controls.Add((Control)(object)KEY_kuohao);
		((Control)this).Controls.Add((Control)(object)KEY_Tabel);
		((Control)this).Controls.Add((Control)(object)KEY_BACKSPACE);
		((Control)this).Controls.Add((Control)(object)KEY_ADDADD);
		((Control)this).Controls.Add((Control)(object)KEY_SubSub);
		((Control)this).Controls.Add((Control)(object)KEY_End);
		((Control)this).Controls.Add((Control)(object)KEY_PgDn);
		((Control)this).Controls.Add((Control)(object)KEY_PgUg);
		((Control)this).Controls.Add((Control)(object)KEY_HOME);
		((Control)this).Controls.Add((Control)(object)KEY_DEL);
		((Control)this).Controls.Add((Control)(object)KEY_INS);
		((Control)this).Controls.Add((Control)(object)KEY_PauseBreak);
		((Control)this).Controls.Add((Control)(object)KEY_PrtSc);
		((Control)this).Controls.Add((Control)(object)KEY_ESC);
		((Control)this).Controls.Add((Control)(object)KEY_F12);
		((Control)this).Controls.Add((Control)(object)KEY_F11);
		((Control)this).Controls.Add((Control)(object)KEY_F10);
		((Control)this).Controls.Add((Control)(object)KEY_F9);
		((Control)this).Controls.Add((Control)(object)KEY_F8);
		((Control)this).Controls.Add((Control)(object)KEY_F7);
		((Control)this).Controls.Add((Control)(object)KEY_F6);
		((Control)this).Controls.Add((Control)(object)KEY_F5);
		((Control)this).Controls.Add((Control)(object)KEY_F4);
		((Control)this).Controls.Add((Control)(object)KEY_F3);
		((Control)this).Controls.Add((Control)(object)KEY_F2);
		((Control)this).Controls.Add((Control)(object)KEY_F1);
		((Control)this).Controls.Add((Control)(object)KEY_0);
		((Control)this).Controls.Add((Control)(object)KEY_8);
		((Control)this).Controls.Add((Control)(object)KEY_7);
		((Control)this).Controls.Add((Control)(object)KEY_6);
		((Control)this).Controls.Add((Control)(object)KEY_5);
		((Control)this).Controls.Add((Control)(object)KEY_4);
		((Control)this).Controls.Add((Control)(object)KEY_3);
		((Control)this).Controls.Add((Control)(object)KEY_2);
		((Control)this).Controls.Add((Control)(object)KEY_1);
		((Control)this).Controls.Add((Control)(object)KEY_9);
		((Control)this).Controls.Add((Control)(object)KEY_Z);
		((Control)this).Controls.Add((Control)(object)KEY_Y);
		((Control)this).Controls.Add((Control)(object)KEY_X);
		((Control)this).Controls.Add((Control)(object)KEY_W);
		((Control)this).Controls.Add((Control)(object)KEY_V);
		((Control)this).Controls.Add((Control)(object)KEY_U);
		((Control)this).Controls.Add((Control)(object)KEY_T);
		((Control)this).Controls.Add((Control)(object)KEY_S);
		((Control)this).Controls.Add((Control)(object)KEY_R);
		((Control)this).Controls.Add((Control)(object)KEY_Q);
		((Control)this).Controls.Add((Control)(object)KEY_P);
		((Control)this).Controls.Add((Control)(object)KEY_O);
		((Control)this).Controls.Add((Control)(object)KEY_N);
		((Control)this).Controls.Add((Control)(object)KEY_M);
		((Control)this).Controls.Add((Control)(object)KEY_L);
		((Control)this).Controls.Add((Control)(object)KEY_K);
		((Control)this).Controls.Add((Control)(object)KEY_J);
		((Control)this).Controls.Add((Control)(object)KEY_I);
		((Control)this).Controls.Add((Control)(object)KEY_H);
		((Control)this).Controls.Add((Control)(object)KEY_G);
		((Control)this).Controls.Add((Control)(object)KEY_F);
		((Control)this).Controls.Add((Control)(object)KEY_E);
		((Control)this).Controls.Add((Control)(object)KEY_D);
		((Control)this).Controls.Add((Control)(object)KEY_C);
		((Control)this).Controls.Add((Control)(object)KEY_B);
		((Control)this).Controls.Add((Control)(object)KEY_A);
		((Control)this).Name = "BasicKeys";
		((Control)this).Size = new Size(760, 385);
		((Control)this).ResumeLayout(false);
	}
}
