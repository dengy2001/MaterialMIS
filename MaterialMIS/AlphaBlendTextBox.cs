/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-09-19
 * 时间: 12:01
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices; 

namespace MaterialMIS
{
	public class BaseTextBox:TextBox
	{
		
		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr LoadLibrary(string lpFileName);
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams prams = base.CreateParams;
				if (LoadLibrary("msftedit.dll") != IntPtr.Zero)
				{
					prams.ExStyle |= 0x020; // transparent
					prams.ClassName = "RICHEDIT50W";
				}
				return prams;
			}
		}
		
		
	}



}
