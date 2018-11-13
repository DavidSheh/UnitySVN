/* 
 * 将 TortoiseSVN 的基础操作内嵌到 Unity，并使用快捷键操作，提高效率
 * 这里只是举了几个简单的例子 
 * 具体命令可参见TortoiseSVN的help功能 
 * 也可以直接去官网查看相关的命令：https://tortoisesvn.net/docs/nightly/TortoiseSVN_en/tsvn-cli-main.html 
 */

using UnityEngine;  
using UnityEditor;  
using System.Diagnostics;  

public class UnitySVN  
{  
	private const string COMMIT = "commit";  
	private const string UPDATE = "update";
    private const string LOG = "log";

    private const string SVN_COMMIT = "Assets/SVN/Commit &c";  
	private const string SVN_COMMIT_ALL = "Assets/SVN/CommitAll &#c";  
	private const string SVN_UPDATE = "Assets/SVN/Update &u";  
	private const string SVN_UPDATE_ALL = "Assets/SVN/UpdateAll &#u";
    private const string SVN_LOG = "Assets/SVN/ShowLog &l";
    private const string SVN_LOG_ALL = "Assets/SVN/ShowLogAll &#l";

    /// <summary>  
    /// 创建一个SVN的cmd命令  
    /// </summary>  
    /// <param name="command">命令(可在help里边查看)</param>  
    /// <param name="path">命令激活路径</param>  
    public static void SVNCommand(string command, string path)  
	{  
		//closeonend 2 表示假设提交没错，会自动关闭提交界面返回原工程，详细描述可在  
		//TortoiseSVN/help/TortoiseSVN/Automating TortoiseSVN里查看  
		string c = "/c tortoiseproc.exe /command:{0} /path:\"{1}\" /closeonend 2";  
		c = string.Format(c, command, path);  
		ProcessStartInfo info = new ProcessStartInfo("cmd.exe", c);  
		info.WindowStyle = ProcessWindowStyle.Hidden;  
		Process.Start(info);  
	}  
	/// <summary>  
	/// 提交选中内容  
	/// </summary>  
	[MenuItem(SVN_COMMIT)]  
	public static void SVNCommit()  
	{  
		SVNCommand(COMMIT, GetSelectedObjectPath());  
	}  
	/// <summary>  
	/// 提交全部Assets文件夹内容  
	/// </summary>  
	[MenuItem(SVN_COMMIT_ALL)]  
	public static void SVNCommitAll()  
	{  
		SVNCommand(COMMIT, Application.dataPath);  
	}  
	/// <summary>  
	/// 更新选中内容  
	/// </summary>  
	[MenuItem(SVN_UPDATE)]  
	public static void SVNUpdate()  
	{  
		SVNCommand(UPDATE, GetSelectedObjectPath());  
	}  
	/// <summary>  
	/// 更新全部内容  
	/// </summary>  
	[MenuItem(SVN_UPDATE_ALL)]  
	public static void SVNUpdateAll()  
	{  
		SVNCommand(UPDATE, Application.dataPath);  
	}
    /// <summary>  
    /// 显示更改日志  
    /// </summary>  
    [MenuItem(SVN_LOG)]
    public static void SVNLog()
    {
        SVNCommand(LOG, GetSelectedObjectPath());
    }
    /// <summary>  
    /// 显示所有的更改日志  
    /// </summary>  
    [MenuItem(SVN_LOG_ALL)]
    public static void SVNLogAll()
    {
        SVNCommand(LOG, Application.dataPath);
    }

    /// <summary>  
    /// 获取全部选中物体的路径  
    /// 包括meta文件  
    /// </summary>  
    /// <returns></returns>  
    private static string GetSelectedObjectPath()  
	{  
		string path = string.Empty;  

		for (int i = 0; i < Selection.objects.Length; i++)  
		{  
			path += AssetsPathToFilePath(AssetDatabase.GetAssetPath(Selection.objects[i]));  
			//路径分隔符  
			path += "*";  
			//meta文件  
			path += AssetsPathToFilePath(AssetDatabase.GetAssetPath(Selection.objects[i])) + ".meta";  
			//路径分隔符  
			path += "*";  
		}  

		return path;  
	}  
	/// <summary>  
	/// 将Assets路径转换为File路径  
	/// </summary>  
	/// <param name="path">Assets/Editor/...</param>  
	/// <returns></returns>  
	public static string AssetsPathToFilePath(string path)  
	{  
		string m_path = Application.dataPath;  
		m_path = m_path.Substring(0, m_path.Length - 6);  
		m_path += path;  

		return m_path;  
	}  

}