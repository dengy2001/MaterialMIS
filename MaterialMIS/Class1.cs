/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-09-19
 * 时间: 14:55
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Runtime.InteropServices; 

namespace MaterialMIS
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class Class1
	{
		[DllImport("kernel32.dll")]
		public static extern bool Beep(int frequency, int duration);

		
	}
}
