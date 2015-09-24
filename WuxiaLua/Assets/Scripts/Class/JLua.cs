using UnityEngine;
using System.Collections;
using LuaInterface;

public class JLua{

    /// <summary>
    /// 单例模式
    /// </summary>
    private static LuaState Lua;

    /// <summary>
    /// 获取LuaState
    /// </summary>
    /// <returns>LuaState</returns>
    public static void Init() {
        if (Lua==null) {
            Lua = new LuaState();
        }
    }

    /// <summary>
    /// 运行Lua文件
    /// </summary>
    /// <param name="name">Lua文件名称</param>
    /// <param name="folder">Lua文件所在的文件夹</param>
    public static void RunLua(string name, string folder=null) {
        string luaPath = "";
        if (folder == null) {
            luaPath = Application.dataPath + "/Lua/" + name + ".lua";
        }
        else {
            luaPath = Application.dataPath + "/Lua/" + folder+"/"+name + ".lua";
        }
        Lua.DoFile(luaPath); 
    }

    /// <summary>
    /// 调用Lua函数
    /// </summary>
    /// <param name="func">Lua函数名称</param>
    /// <param name="args">函数所需参数</param>
    /// <returns>对象数组</returns>
    public static object[] CallLuaFunc(string func, params object[] args) {
        LuaFunction f = Lua.GetFunction(func);
        object[] r = f.Call(args);
        return r;
    } 
}
