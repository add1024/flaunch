using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using static FLaunch.Logic.CommonConst;

namespace FLaunch.Logic
{
    /// <summary>
    /// Shortcut helper
    /// </summary>
    internal static class ShortcutUtil
    {
        /// <summary>
        /// ItemType
        /// </summary>
        private enum ItemType : byte
        {
            /// <summary>
            /// Is shortcut
            /// </summary>
            Shortcut,
            /// <summary>
            /// Is Directory
            /// </summary>
            Directory
        }

        /// <summary>
        /// ItemProperty
        /// </summary>
        private struct Item
        {
            /// <summary>
            /// ItemType
            /// </summary>
            public ItemType Type;
            /// <summary>
            /// Path
            /// </summary>
            public string ShortcutPath;
        }

        /// <summary>
        /// Check & Create shortcut dir
        /// </summary>
        private static void DirCheck()
        {
            if (!Directory.Exists(ShortcutDirFullPath))
            {
                Directory.CreateDirectory(ShortcutDirFullPath);
            }
        }

        /// <summary>
        /// Open shortcut dir
        /// </summary>
        internal static void OpenShortcutDirFromExplorer()
        {
            DirCheck();
            Process.Start(ShortcutDirFullPath);
        }

        /// <summary>
        /// CreateTreeView
        /// </summary>
        /// <param name="treeView">TreeView</param>
        /// <param name="imageList">ImageList</param>
        internal static void CreateTreeViewNodes(TreeView treeView, ImageList imageList)
        {
            const string shortcutExtensionPattern = "*.lnk";
            const string shortcutExtensionPatternUrl = "*.url";

            //init
            treeView.Nodes.Clear();
            imageList.Images.Clear();
            var resoucePath = Assembly.GetExecutingAssembly().GetName().Name + ".materials.dir.ico";
            var dirIconStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resoucePath);
            if (dirIconStream != null)
            {
                imageList.Images.Add("*dir*", new Icon(dirIconStream));
            } //ignore resource fail...

            DirCheck();

            //scan
            var dirQue = new Stack<DirectoryInfo>();
            dirQue.Push(new DirectoryInfo(ShortcutDirFullPath));
            var treeQue = new Stack<TreeNodeCollection>();
            treeQue.Push(treeView.Nodes);
            while (dirQue.Count > 0)
            {
                var currentDir = dirQue.Pop();
                var currentNode = treeQue.Pop();

                //dir
                var directories = currentDir.GetDirectories().OrderBy(v => v.Name).ToArray();
                foreach (var dir in directories)
                {
                    var newDirNode = new TreeNode(dir.Name) { Tag = new Item { Type = ItemType.Directory } };
                    currentNode.Add(newDirNode);
                    dirQue.Push(dir);
                    treeQue.Push(newDirNode.Nodes);
                }

                //shortcut
                var files = currentDir.GetFiles(shortcutExtensionPattern).Union(currentDir.GetFiles(shortcutExtensionPatternUrl)).OrderBy(v => v.Name);
                foreach (var file in files)
                {
                    var fullPath = file.FullName;
                    var newScNode = new TreeNode(Path.GetFileNameWithoutExtension(fullPath))
                    {
                        Tag = new Item { Type = ItemType.Shortcut, ShortcutPath = fullPath }

                    };
                    var icon = Icon.ExtractAssociatedIcon(fullPath);
                    if (icon != null)
                    {
                        imageList.Images.Add(fullPath, icon);
                        var index = imageList.Images.Count - 1;
                        newScNode.ImageIndex = index;
                        newScNode.SelectedImageIndex = index;
                    }
                    currentNode.Add(newScNode);
                }
            }
        }

        /// <summary>
        /// Execute shortcut
        /// </summary>
        /// <param name="treeView">TreeView</param>
        /// <param name="openAll">OpenAll</param>
        /// <returns>result</returns>
        internal static bool ExecuteOpen(TreeView treeView, bool openAll = false)
        {
            var ret = false;
            var node = treeView.SelectedNode;

            if (node?.Tag == null) { return false; } //Selected?

            var item = (Item)node.Tag;

            if (!openAll && item.Type == ItemType.Shortcut)
            {
                OpenShortcut(item.ShortcutPath);
                ret = true;
            }
            else if (openAll && item.Type == ItemType.Directory)
            {
                //1 Layer only
                foreach (TreeNode childNode in node.Nodes)
                {
                    if (childNode.Tag == null) { continue; }
                    var childItem = (Item)childNode.Tag;
                    if (childItem.Type == ItemType.Shortcut)
                    {
                        OpenShortcut(childItem.ShortcutPath);
                        if (!ret) { ret = true; }
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// Open shortcut
        /// </summary>
        /// <param name="fullPath">Fullpath</param>
        private static void OpenShortcut(string fullPath)
        {
            if (File.Exists(fullPath))
            {
                Process.Start(fullPath);
            }
        }
    }
}
