using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HIDTester;

public class LayerFun : UserControl
{
	private IContainer components;

	private RadioButton KEY_Layer1;

	private RadioButton KEY_Layer2;

	private RadioButton KEY_Layer3;

	private RadioButton KEY_FunLayer1;

	private RadioButton KEY_FunLayer2;

	private RadioButton KEY_FunLayer3;

	public LayerFun()
	{
		InitializeComponent();
	}

	private void KEY_FunLayer1_CheckedChanged(object sender, EventArgs e)
	{
		if (KEY_FunLayer1.Checked)
		{
			FormMain.KeyParam.KEY_Cur_Layer = 1;
			FormMain.KeyParam.PageBet_Inte_Cmd = 1;
		}
	}

	private void KEY_FunLayer2_CheckedChanged(object sender, EventArgs e)
	{
		if (KEY_FunLayer2.Checked)
		{
			FormMain.KeyParam.KEY_Cur_Layer = 2;
			FormMain.KeyParam.PageBet_Inte_Cmd = 1;
		}
	}

	private void KEY_FunLayer3_CheckedChanged(object sender, EventArgs e)
	{
		if (KEY_FunLayer3.Checked)
		{
			FormMain.KeyParam.KEY_Cur_Layer = 3;
			FormMain.KeyParam.PageBet_Inte_Cmd = 1;
		}
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(LayerFun));
		KEY_Layer1 = new RadioButton();
		KEY_Layer2 = new RadioButton();
		KEY_Layer3 = new RadioButton();
		KEY_FunLayer1 = new RadioButton();
		KEY_FunLayer2 = new RadioButton();
		KEY_FunLayer3 = new RadioButton();
		((Control)this).SuspendLayout();
		componentResourceManager.ApplyResources(KEY_Layer1, "KEY_Layer1");
		((Control)KEY_Layer1).Name = "KEY_Layer1";
		componentResourceManager.ApplyResources(KEY_Layer2, "KEY_Layer2");
		((Control)KEY_Layer2).Name = "KEY_Layer2";
		componentResourceManager.ApplyResources(KEY_Layer3, "KEY_Layer3");
		((Control)KEY_Layer3).Name = "KEY_Layer3";
		componentResourceManager.ApplyResources(KEY_FunLayer1, "KEY_FunLayer1");
		KEY_FunLayer1.Checked = true;
		((Control)KEY_FunLayer1).Name = "KEY_FunLayer1";
		KEY_FunLayer1.TabStop = true;
		((ButtonBase)KEY_FunLayer1).UseVisualStyleBackColor = true;
		KEY_FunLayer1.CheckedChanged += KEY_FunLayer1_CheckedChanged;
		componentResourceManager.ApplyResources(KEY_FunLayer2, "KEY_FunLayer2");
		((Control)KEY_FunLayer2).Name = "KEY_FunLayer2";
		KEY_FunLayer2.TabStop = true;
		((ButtonBase)KEY_FunLayer2).UseVisualStyleBackColor = true;
		KEY_FunLayer2.CheckedChanged += KEY_FunLayer2_CheckedChanged;
		componentResourceManager.ApplyResources(KEY_FunLayer3, "KEY_FunLayer3");
		((Control)KEY_FunLayer3).Name = "KEY_FunLayer3";
		KEY_FunLayer3.TabStop = true;
		((ButtonBase)KEY_FunLayer3).UseVisualStyleBackColor = true;
		KEY_FunLayer3.CheckedChanged += KEY_FunLayer3_CheckedChanged;
		componentResourceManager.ApplyResources(this, "$this");
		((Control)this).Controls.Add((Control)(object)KEY_FunLayer3);
		((Control)this).Controls.Add((Control)(object)KEY_FunLayer2);
		((Control)this).Controls.Add((Control)(object)KEY_FunLayer1);
		((Control)this).ForeColor = SystemColors.InactiveCaptionText;
		((Control)this).Name = "LayerFun";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
