using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace HIDTester;

public class MULKey : UserControl
{
	private IContainer components;

	private Button KEY_Play;

	private Button KEY_VolumeAdd;

	private Button KEY_VolumeSub;

	private Button KEY_PreSong;

	private Button KEY_NextSong;

	private Button KEY_Mute;

	public MULKey()
	{
		InitializeComponent();
	}

	private void MULGeneral_Char_Set()
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KeyType_Num] |= 2;
	}

	private void KEY_Play_Click(object sender, EventArgs e)
	{
		if (FormMain.KeyParam.ReportID == 0)
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 64;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Play).Text;
			MULGeneral_Char_Set();
		}
		else if (FormMain.KeyParam.ReportID == 2)
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 4;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Play).Text;
			MULGeneral_Char_Set();
		}
		else
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 205;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Play).Text;
			MULGeneral_Char_Set();
		}
	}

	private void KEY_PreSong_Click(object sender, EventArgs e)
	{
		if (FormMain.KeyParam.ReportID == 0)
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 128;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_PreSong).Text;
			MULGeneral_Char_Set();
		}
		else if (FormMain.KeyParam.ReportID == 2)
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 11;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_PreSong).Text;
			MULGeneral_Char_Set();
		}
		else
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 182;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_PreSong).Text;
			MULGeneral_Char_Set();
		}
	}

	private void KEY_NextSong_Click(object sender, EventArgs e)
	{
		if (FormMain.KeyParam.ReportID == 0)
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 1;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_NextSong).Text;
			MULGeneral_Char_Set();
		}
		else if (FormMain.KeyParam.ReportID == 2)
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 10;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_NextSong).Text;
			MULGeneral_Char_Set();
		}
		else
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 181;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_NextSong).Text;
			MULGeneral_Char_Set();
		}
	}

	private void KEY_Mute_Click(object sender, EventArgs e)
	{
		if (FormMain.KeyParam.ReportID == 0)
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 4;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Mute).Text;
			MULGeneral_Char_Set();
		}
		else if (FormMain.KeyParam.ReportID == 2)
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 1;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Mute).Text;
			MULGeneral_Char_Set();
		}
		else
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 226;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_Mute).Text;
			MULGeneral_Char_Set();
		}
	}

	private void KEY_VolumeAdd_Click(object sender, EventArgs e)
	{
		if (FormMain.KeyParam.ReportID == 0)
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 2;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_VolumeAdd).Text;
			MULGeneral_Char_Set();
		}
		else if (FormMain.KeyParam.ReportID == 2)
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 64;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_VolumeAdd).Text;
			MULGeneral_Char_Set();
		}
		else
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 233;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_VolumeAdd).Text;
			MULGeneral_Char_Set();
		}
	}

	private void KEY_VolumeSub_Click(object sender, EventArgs e)
	{
		if (FormMain.KeyParam.ReportID == 0)
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 1;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_VolumeSub).Text;
			MULGeneral_Char_Set();
		}
		else if (FormMain.KeyParam.ReportID == 2)
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 128;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_VolumeSub).Text;
			MULGeneral_Char_Set();
		}
		else
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 234;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = ((Control)KEY_VolumeSub).Text;
			MULGeneral_Char_Set();
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MULKey));
		KEY_Play = new Button();
		KEY_VolumeAdd = new Button();
		KEY_VolumeSub = new Button();
		KEY_PreSong = new Button();
		KEY_NextSong = new Button();
		KEY_Mute = new Button();
		((Control)this).SuspendLayout();
		componentResourceManager.ApplyResources(KEY_Play, "KEY_Play");
		((Control)KEY_Play).Name = "KEY_Play";
		((ButtonBase)KEY_Play).UseVisualStyleBackColor = true;
		((Control)KEY_Play).Click += KEY_Play_Click;
		componentResourceManager.ApplyResources(KEY_VolumeAdd, "KEY_VolumeAdd");
		((Control)KEY_VolumeAdd).Name = "KEY_VolumeAdd";
		((ButtonBase)KEY_VolumeAdd).UseVisualStyleBackColor = true;
		((Control)KEY_VolumeAdd).Click += KEY_VolumeAdd_Click;
		componentResourceManager.ApplyResources(KEY_VolumeSub, "KEY_VolumeSub");
		((Control)KEY_VolumeSub).Name = "KEY_VolumeSub";
		((ButtonBase)KEY_VolumeSub).UseVisualStyleBackColor = true;
		((Control)KEY_VolumeSub).Click += KEY_VolumeSub_Click;
		componentResourceManager.ApplyResources(KEY_PreSong, "KEY_PreSong");
		((Control)KEY_PreSong).Name = "KEY_PreSong";
		((ButtonBase)KEY_PreSong).UseVisualStyleBackColor = true;
		((Control)KEY_PreSong).Click += KEY_PreSong_Click;
		componentResourceManager.ApplyResources(KEY_NextSong, "KEY_NextSong");
		((Control)KEY_NextSong).Name = "KEY_NextSong";
		((ButtonBase)KEY_NextSong).UseVisualStyleBackColor = true;
		((Control)KEY_NextSong).Click += KEY_NextSong_Click;
		componentResourceManager.ApplyResources(KEY_Mute, "KEY_Mute");
		((Control)KEY_Mute).Name = "KEY_Mute";
		((ButtonBase)KEY_Mute).UseVisualStyleBackColor = true;
		((Control)KEY_Mute).Click += KEY_Mute_Click;
		componentResourceManager.ApplyResources(this, "$this");
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).Controls.Add((Control)(object)KEY_Mute);
		((Control)this).Controls.Add((Control)(object)KEY_NextSong);
		((Control)this).Controls.Add((Control)(object)KEY_PreSong);
		((Control)this).Controls.Add((Control)(object)KEY_VolumeSub);
		((Control)this).Controls.Add((Control)(object)KEY_VolumeAdd);
		((Control)this).Controls.Add((Control)(object)KEY_Play);
		((Control)this).Name = "MULKey";
		((Control)this).ResumeLayout(false);
	}
}
