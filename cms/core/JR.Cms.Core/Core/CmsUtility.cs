﻿//
// Copyright (C) 2007-2008 TO2.NET,All rights reseved.
// 
// Project: Cms.Cms
// FileName : CmsUtility.cs
// author : PC-CWLIU (new.min@msn.com)
// Create : 2013/06/23 14:53:11
// Description :
//
// Get infromation of this software,please visit our site http://to2.net/jr-cms
//
//

using System;
using System.IO;

namespace JR.Cms.Core
{
    /// <summary>
	/// CMS实用工具
	/// </summary>
	public class CmsUtility
	{
		/// <summary>
		/// 设置目录权限
		/// </summary>
		/// <param name="dirPath"></param>
		public void SetDirCanWrite(string dirPath)
		{
			DirectoryInfo dir = new DirectoryInfo(String.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, dirPath));
			if (dir.Exists)
			{
				if ((dir.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
				{
					dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
				}
			}
			else
			{
				Directory.CreateDirectory(dir.FullName).Create();
			}
		}
		
		/// <summary>
		/// 设置目录隐藏
		/// </summary>
		/// <param name="dirPath"></param>
		public void SetDirHidden(string dirPath)
		{
			if(!Cms.RunAtMono)
			{
				DirectoryInfo dir = new DirectoryInfo(String.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, dirPath));
				if (!dir.Exists)
				{
					Directory.CreateDirectory(dir.FullName).Create();
					dir.Attributes = dir.Attributes & FileAttributes.Hidden;
				}
				else
				{
					if((dir.Attributes & FileAttributes.Hidden) != FileAttributes.ReadOnly)
					{
						dir.Attributes = dir.Attributes & FileAttributes.Hidden;
					}
				}
			}
		}
	}
}