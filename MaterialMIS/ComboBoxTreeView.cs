/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-05-24
 * 时间: 10:30
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MaterialMIS
{

    public class ComboBoxTreeView : ComboBox
    {
        private const int WM_LBUTTONDOWN = 0x201, WM_LBUTTONDBLCLK = 0x203;
        ToolStripControlHost treeViewHost;
        ToolStripDropDown dropDown;
        public ComboBoxTreeView()
        {
            TreeView treeView = new TreeView();
            treeView.AfterSelect+=new TreeViewEventHandler(treeView_AfterSelect);
            treeView.BorderStyle = BorderStyle.None;
           
            treeViewHost = new ToolStripControlHost(treeView);
            dropDown = new ToolStripDropDown();
            dropDown.Width = this.Width;
            dropDown.Items.Add(treeViewHost);
        }
        public void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Text=TreeView.SelectedNode.Text;
            this.Tag = TreeView.SelectedNode.Tag;
            dropDown.Close();
        }
        public TreeView TreeView
        {
            get { return treeViewHost.Control as TreeView; }
        }
        private void ShowDropDown()
        {
            if (dropDown != null)
            {
               treeViewHost.Size =new System.Drawing.Size(DropDownWidth-2,DropDownHeight);       
               dropDown.Show(this, 0, this.Height);
            }
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDBLCLK || m.Msg == WM_LBUTTONDOWN)
            {
                ShowDropDown();
                return;
            }        
            base.WndProc(ref m);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dropDown != null)
                {
                    dropDown.Dispose();
                    dropDown = null;
                }
            }
            base.Dispose(disposing);
        }
    }
    

}