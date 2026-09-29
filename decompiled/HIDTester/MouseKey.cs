using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HIDTester;

public class MouseKey : UserControl
{
	private IContainer components;

	private Button KEY_Mouse_Left;

	private Button KEY_Mouse_Right;

	private Button KEY_Mouse_Centre;

	private Button KEY_MOUSE_WHEEL_ADD;

	private Button KEY_MOUSE_WHEEL_SUB;

	private Button Ctrl_Mouse_wheel_Up;

	private Button Ctrl_Mouse_wheel_Down;

	private Button Shift_Mouse_wheel_Up;

	private Button Shift_Mouse_wheel_Down;

	private Button Alt_Mouse_wheel_Up;

	private Button Alt_Mouse_wheel_Down;

	public MouseKey()
	{
		InitializeComponent();
	}

	private void KEY_Colour_Init()
	{
		int red = 152;
		int green = 251;
		int blue = 152;
		((Control)KEY_Mouse_Left).BackColor = Color.FromArgb(red, green, blue);
		((Control)KEY_Mouse_Centre).BackColor = Color.FromArgb(red, green, blue);
		((Control)KEY_Mouse_Right).BackColor = Color.FromArgb(red, green, blue);
		((Control)KEY_MOUSE_WHEEL_ADD).BackColor = Color.FromArgb(red, green, blue);
		((Control)KEY_MOUSE_WHEEL_SUB).BackColor = Color.FromArgb(red, green, blue);
	}

	private void MouseGeneral_Char_Set()
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KeyType_Num] |= 3;
	}

	private void KEY_Mouse_Left_Click(object sender, EventArgs e)
	{
		MouseGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 1;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 2] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 3] = 0;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Mouse_Left).Text;
	}

	private void KEY_Mouse_Centre_Click(object sender, EventArgs e)
	{
		MouseGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 4;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 2] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 3] = 0;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Mouse_Centre).Text;
	}

	private void KEY_Mouse_Right_Click(object sender, EventArgs e)
	{
		MouseGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 2;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 2] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 3] = 0;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Mouse_Right).Text;
	}

	private void KEY_MOUSE_WHEEL_ADD_Click(object sender, EventArgs e)
	{
		MouseGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 2] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 3] = 1;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_MOUSE_WHEEL_ADD).Text;
	}

	private void KEY_MOUSE_WHEEL_SUB_Click(object sender, EventArgs e)
	{
		MouseGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 2] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 3] = byte.MaxValue;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_MOUSE_WHEEL_SUB).Text;
	}

	private void Ctrl_Mouse_wheel_Up_Click(object sender, EventArgs e)
	{
		MouseGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 2] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 3] = 1;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 4] = 1;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)Ctrl_Mouse_wheel_Up).Text;
	}

	private void Ctrl_Mouse_wheel_Down_Click(object sender, EventArgs e)
	{
		MouseGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 2] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 3] = byte.MaxValue;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 4] = 1;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)Ctrl_Mouse_wheel_Down).Text;
	}

	private void Shift_Mouse_wheel_Up_Click(object sender, EventArgs e)
	{
		MouseGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 2] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 3] = 1;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 4] = 2;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)Shift_Mouse_wheel_Up).Text;
	}

	private void Shift_Mouse_wheel_Down_Click(object sender, EventArgs e)
	{
		MouseGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 2] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 3] = byte.MaxValue;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 4] = 2;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)Shift_Mouse_wheel_Down).Text;
	}

	private void Alt_Mouse_wheel_Up_Click(object sender, EventArgs e)
	{
		MouseGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 2] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 3] = 1;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 4] = 4;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)Alt_Mouse_wheel_Up).Text;
	}

	private void Alt_Mouse_wheel_Down_Click(object sender, EventArgs e)
	{
		MouseGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 2] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 3] = byte.MaxValue;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 4] = 4;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)Alt_Mouse_wheel_Down).Text;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MouseKey));
		KEY_Mouse_Left = new Button();
		KEY_Mouse_Right = new Button();
		KEY_Mouse_Centre = new Button();
		KEY_MOUSE_WHEEL_ADD = new Button();
		KEY_MOUSE_WHEEL_SUB = new Button();
		Ctrl_Mouse_wheel_Up = new Button();
		Ctrl_Mouse_wheel_Down = new Button();
		Shift_Mouse_wheel_Up = new Button();
		Shift_Mouse_wheel_Down = new Button();
		Alt_Mouse_wheel_Up = new Button();
		Alt_Mouse_wheel_Down = new Button();
		((Control)this).SuspendLayout();
		componentResourceManager.ApplyResources(KEY_Mouse_Left, "KEY_Mouse_Left");
		((Control)KEY_Mouse_Left).Name = "KEY_Mouse_Left";
		((ButtonBase)KEY_Mouse_Left).UseVisualStyleBackColor = true;
		((Control)KEY_Mouse_Left).Click += KEY_Mouse_Left_Click;
		componentResourceManager.ApplyResources(KEY_Mouse_Right, "KEY_Mouse_Right");
		((Control)KEY_Mouse_Right).Name = "KEY_Mouse_Right";
		((ButtonBase)KEY_Mouse_Right).UseVisualStyleBackColor = true;
		((Control)KEY_Mouse_Right).Click += KEY_Mouse_Right_Click;
		componentResourceManager.ApplyResources(KEY_Mouse_Centre, "KEY_Mouse_Centre");
		((Control)KEY_Mouse_Centre).Name = "KEY_Mouse_Centre";
		((ButtonBase)KEY_Mouse_Centre).UseVisualStyleBackColor = true;
		((Control)KEY_Mouse_Centre).Click += KEY_Mouse_Centre_Click;
		componentResourceManager.ApplyResources(KEY_MOUSE_WHEEL_ADD, "KEY_MOUSE_WHEEL_ADD");
		((Control)KEY_MOUSE_WHEEL_ADD).Name = "KEY_MOUSE_WHEEL_ADD";
		((ButtonBase)KEY_MOUSE_WHEEL_ADD).UseVisualStyleBackColor = true;
		((Control)KEY_MOUSE_WHEEL_ADD).Click += KEY_MOUSE_WHEEL_ADD_Click;
		componentResourceManager.ApplyResources(KEY_MOUSE_WHEEL_SUB, "KEY_MOUSE_WHEEL_SUB");
		((Control)KEY_MOUSE_WHEEL_SUB).Name = "KEY_MOUSE_WHEEL_SUB";
		((ButtonBase)KEY_MOUSE_WHEEL_SUB).UseVisualStyleBackColor = true;
		((Control)KEY_MOUSE_WHEEL_SUB).Click += KEY_MOUSE_WHEEL_SUB_Click;
		componentResourceManager.ApplyResources(Ctrl_Mouse_wheel_Up, "Ctrl_Mouse_wheel_Up");
		((Control)Ctrl_Mouse_wheel_Up).Name = "Ctrl_Mouse_wheel_Up";
		((Control)Ctrl_Mouse_wheel_Up).Click += Ctrl_Mouse_wheel_Up_Click;
		componentResourceManager.ApplyResources(Ctrl_Mouse_wheel_Down, "Ctrl_Mouse_wheel_Down");
		((Control)Ctrl_Mouse_wheel_Down).Name = "Ctrl_Mouse_wheel_Down";
		((Control)Ctrl_Mouse_wheel_Down).Click += Ctrl_Mouse_wheel_Down_Click;
		componentResourceManager.ApplyResources(Shift_Mouse_wheel_Up, "Shift_Mouse_wheel_Up");
		((Control)Shift_Mouse_wheel_Up).Name = "Shift_Mouse_wheel_Up";
		((Control)Shift_Mouse_wheel_Up).Click += Shift_Mouse_wheel_Up_Click;
		componentResourceManager.ApplyResources(Shift_Mouse_wheel_Down, "Shift_Mouse_wheel_Down");
		((Control)Shift_Mouse_wheel_Down).Name = "Shift_Mouse_wheel_Down";
		((Control)Shift_Mouse_wheel_Down).Click += Shift_Mouse_wheel_Down_Click;
		componentResourceManager.ApplyResources(Alt_Mouse_wheel_Up, "Alt_Mouse_wheel_Up");
		((Control)Alt_Mouse_wheel_Up).Name = "Alt_Mouse_wheel_Up";
		((Control)Alt_Mouse_wheel_Up).Click += Alt_Mouse_wheel_Up_Click;
		componentResourceManager.ApplyResources(Alt_Mouse_wheel_Down, "Alt_Mouse_wheel_Down");
		((Control)Alt_Mouse_wheel_Down).Name = "Alt_Mouse_wheel_Down";
		((Control)Alt_Mouse_wheel_Down).Click += Alt_Mouse_wheel_Down_Click;
		componentResourceManager.ApplyResources(this, "$this");
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).Controls.Add((Control)(object)Alt_Mouse_wheel_Down);
		((Control)this).Controls.Add((Control)(object)Alt_Mouse_wheel_Up);
		((Control)this).Controls.Add((Control)(object)Shift_Mouse_wheel_Down);
		((Control)this).Controls.Add((Control)(object)Shift_Mouse_wheel_Up);
		((Control)this).Controls.Add((Control)(object)Ctrl_Mouse_wheel_Down);
		((Control)this).Controls.Add((Control)(object)Ctrl_Mouse_wheel_Up);
		((Control)this).Controls.Add((Control)(object)KEY_MOUSE_WHEEL_SUB);
		((Control)this).Controls.Add((Control)(object)KEY_MOUSE_WHEEL_ADD);
		((Control)this).Controls.Add((Control)(object)KEY_Mouse_Centre);
		((Control)this).Controls.Add((Control)(object)KEY_Mouse_Right);
		((Control)this).Controls.Add((Control)(object)KEY_Mouse_Left);
		((Control)this).Name = "MouseKey";
		((Control)this).ResumeLayout(false);
	}
}
