using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HIDTester;

public class LEDkey : UserControl
{
	private IContainer components;

	private Button KEY_LEDMode0;

	private Button KEY_LEDMode1;

	private Button KEY_LEDMode2;

	public LEDkey()
	{
		InitializeComponent();
		KEY_Colour_Init();
	}

	private void KEY_Colour_Init()
	{
		int red = 152;
		int green = 251;
		int blue = 152;
		((Control)KEY_LEDMode0).BackColor = Color.FromArgb(red, green, blue);
		((Control)KEY_LEDMode1).BackColor = Color.FromArgb(red, green, blue);
		((Control)KEY_LEDMode2).BackColor = Color.FromArgb(red, green, blue);
	}

	private void LEDGeneral_Char_Set()
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KeyType_Num] |= 8;
	}

	private void KEY_LEDMode0_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KeySet_KeyNum] = 176;
		LEDGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[2] = 0;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_LEDMode0).Text;
		KEY_Colour_Init();
		((Control)KEY_LEDMode0).BackColor = Color.FromArgb(255, 48, 48);
	}

	private void KEY_LEDMode1_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KeySet_KeyNum] = 176;
		LEDGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[2] = 1;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_LEDMode1).Text;
		KEY_Colour_Init();
		((Control)KEY_LEDMode1).BackColor = Color.FromArgb(255, 48, 48);
	}

	private void KEY_LEDMode2_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KeySet_KeyNum] = 176;
		LEDGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[2] = 2;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_LEDMode2).Text;
		KEY_Colour_Init();
		((Control)KEY_LEDMode2).BackColor = Color.FromArgb(255, 48, 48);
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(LEDkey));
		KEY_LEDMode0 = new Button();
		KEY_LEDMode1 = new Button();
		KEY_LEDMode2 = new Button();
		((Control)this).SuspendLayout();
		componentResourceManager.ApplyResources(KEY_LEDMode0, "KEY_LEDMode0");
		((Control)KEY_LEDMode0).Name = "KEY_LEDMode0";
		((ButtonBase)KEY_LEDMode0).UseVisualStyleBackColor = true;
		((Control)KEY_LEDMode0).Click += KEY_LEDMode0_Click;
		componentResourceManager.ApplyResources(KEY_LEDMode1, "KEY_LEDMode1");
		((Control)KEY_LEDMode1).Name = "KEY_LEDMode1";
		((ButtonBase)KEY_LEDMode1).UseVisualStyleBackColor = true;
		((Control)KEY_LEDMode1).Click += KEY_LEDMode1_Click;
		componentResourceManager.ApplyResources(KEY_LEDMode2, "KEY_LEDMode2");
		((Control)KEY_LEDMode2).Name = "KEY_LEDMode2";
		((ButtonBase)KEY_LEDMode2).UseVisualStyleBackColor = true;
		((Control)KEY_LEDMode2).Click += KEY_LEDMode2_Click;
		componentResourceManager.ApplyResources(this, "$this");
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).Controls.Add((Control)(object)KEY_LEDMode2);
		((Control)this).Controls.Add((Control)(object)KEY_LEDMode1);
		((Control)this).Controls.Add((Control)(object)KEY_LEDMode0);
		((Control)this).Name = "LEDkey";
		((Control)this).ResumeLayout(false);
	}
}
