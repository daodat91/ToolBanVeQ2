using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DocumentManage
{
	public static class TreeViewExtensions
	{
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 8)]
		private struct TVITEM
		{
			public int mask;

			public IntPtr hItem;

			public int state;

			public int stateMask;

			[MarshalAs(UnmanagedType.LPTStr)]
			public string lpszText;

			public int cchTextMax;

			public int iImage;

			public int iSelectedImage;

			public int cChildren;

			public IntPtr lParam;
		}

		private const int TVIF_STATE = 8;

		private const int TVIS_STATEIMAGEMASK = 61440;

		private const int TV_FIRST = 4352;

		private const int TVM_SETITEM = 4415;

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref TreeViewExtensions.TVITEM lParam);

		public static void HideCheckBox(this TreeNode node)
		{
			TreeViewExtensions.TVITEM tVITEM = default(TreeViewExtensions.TVITEM);
			tVITEM.hItem = node.Handle;
			tVITEM.mask = 8;
			tVITEM.stateMask = 61440;
			tVITEM.state = 0;
			TreeViewExtensions.SendMessage(node.TreeView.Handle, 4415, IntPtr.Zero, ref tVITEM);
		}
	}
}
