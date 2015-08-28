using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using System.Diagnostics;

namespace SG.USB
{
    /// <summary>
    /// 全局钩子类
    /// 提供事件对键盘、鼠标的消息进行拦截
    /// 您可以使用事件注册的方式通过自定义方法处理键盘、鼠标的动作
    /// 值得注意的是：您必须手动安装钩子并将自定义方法注册到事件中后，您才能对事件进行拦截
    /// JH_USB.Hook hook;   //刷卡
    /// string CardNum = "";    //卡号
    /// 刷卡时获取卡号
    ///  if (IsUseCard())
            //{
            //    timer_Card.Tick += new EventHandler(timer_Card_Tick);//用来处理数据
            //    hook = JH_USB.Hook.GetInstance();
            //    hook.get_Card = new JH_USB.Hook.Get_CardNo(Get_CardNo);
            //    hook.InstallKeyBoardHook();
            //}
        //private void Get_CardNo(string val_cardno)
        //{
        //    CardNum = val_cardno;
        //    timer_Card.Start();
        //    btnCopy.Enabled = false;
        //    btnExit.Enabled = false;
        //    btnFlash.Enabled = false;
        //    btnImportData.Enabled = false;
        //    btnPL.Enabled = false;
        //    btnSave.Enabled = false;
        //    btnSubItem.Enabled = false;
        //    hook.UninstallKeyBoardHook();
        //}
    /// 
    /// 
    /// </summary>
    public sealed class Hook
    {
        public delegate void Get_CardNo(string val_cardno);
        //public delegate void BardCodeDeletegate(BarCodes barCode);
        //public event BardCodeDeletegate BarCodeEvent;
       public Get_CardNo get_Card;
        BarCodes barCode = new BarCodes();
        string gt_CardNO = "";
        int hKeyboardHook = 0;
        string strBarCode = "";
        public struct BarCodes
        {
            public int VirtKey;//虚拟吗
            public int ScanCode;//扫描码
            public string KeyName;//键名
            public uint Ascll;//Ascll
            public char Chr;//字符

            public string BarCode;//条码信息
            public bool IsValid;//条码是否有效
            public DateTime Time;//扫描时间
        }

        private struct EventMsg
        {
            public int message;
            public int paramL;
            public int paramH;
            public int Time;
            public int hwnd;
        }
        #region DllImport

        [DllImport("user32", EntryPoint = "GetKeyNameText")]
        private static extern int GetKeyNameText(int IParam, StringBuilder lpBuffer, int nSize);

        [DllImport("user32", EntryPoint = "GetKeyboardState")]
        private static extern int GetKeyboardState(byte[] pbKeyState);

        [DllImport("user32", EntryPoint = "ToAscii")]
        private static extern bool ToAscii(int VirtualKey, int ScanCode, byte[] lpKeySate, ref uint lpChar, int uFlags);


        /// <summary>
        /// 设置钩子
        /// </summary>
        /// <param name="idHook">钩子类型，此处用整形的枚举表示</param>
        /// <param name="lpfn">钩子发挥作用时的回调函数</param>
        /// <param name="hInstance">应用程序实例的模块句柄(一般来说是你钩子回调函数所在的应用程序实例模块句柄)</param>
        /// <param name="threadId">与安装的钩子子程相关联的线程的标识符</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int SetWindowsHookEx(
            HookType idHook,
            HookProc lpfn,
            IntPtr hInstance,
            int threadId
            );

        /// <summary>
        /// 抽掉钩子
        /// </summary>
        /// <param name="idHook">要取消的钩子的句柄</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(
            int idHook
            );

        /// <summary>
        /// 调用下一个钩子
        /// </summary>
        /// <param name="idHook">当前钩子的句柄</param>
        /// <param name="nCode">钩子链传回的参数，非0表示要丢弃这条消息，0表示继续调用钩子</param>
        /// <param name="wParam">传递的参数</param>
        /// <param name="lParam">传递的参数</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int CallNextHookEx(
            int idHook,
            int nCode,
            int wParam,
            IntPtr lParam
            );

        /// <summary>
        /// 获取一个应用程序或动态链接库的模块句柄
        /// </summary>
        /// <param name="name">指定模块名，这通常是与模块的文件名相同的一个名字</param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(
            string name
            );
        #endregion

        #region 单例实现相关
        static Hook() { }
        private Hook() { }

        /// <summary>
        /// 内部类，用于提供Hook类的单实例
        /// </summary>
        private class Nested
        {
            static Nested() { }
            internal static readonly Hook instance = new Hook();
        }

        ~Hook()
        {
            UninstallAllHook();
        }

        public static Hook GetInstance()
        {
            return Nested.instance;
        }
        #endregion

        #region 钩子句柄

        /// <summary>
        /// 键盘钩子句柄
        /// </summary>
        private static int kbhHook = 0;

        /// <summary>
        /// 鼠标钩子
        /// </summary>
        private static int mshHook = 0;

        /// <summary>
        /// 自定义钩子
        /// </summary>
        private static int userHook = 0;

        /// <summary>
        /// 键盘钩子回调函数
        /// </summary>
        private static HookProc kbHook;
      

        #endregion

        #region 提供给外界使用的事件



       

    


        #endregion

        #region 安装钩子、卸载钩子的方法

        /// <summary>
        /// 安装键盘钩子(使用默认配置)
        /// </summary>
        public void InstallKeyBoardHook()
        {
            InstallKeyBoardHook(HookType.WH_KEYBOARD_LL);
        }

      

      

        /// <summary>
        /// 使用自定义配置安装键盘钩子(推荐有一定经验的专业人士使用)
        /// </summary>
        /// <param name="type"></param>
        public void InstallKeyBoardHook(HookType type)
        {
            if (kbhHook == 0)
            {
                kbHook = new HookProc(DefaultKeyBoardHookProc);
                kbhHook = SetWindowsHookEx(
                    type,
                    kbHook,
                    GetModuleHandle(
                        Process.GetCurrentProcess().MainModule.ModuleName
                        ),
                    0
                    );
                if (kbhHook == 0)
                    UninstallKeyBoardHook();
            }
        }

      

        /// <summary>
        /// 使用自定义配置安装钩子(不建议使用)
        /// </summary>
        /// <param name="type">钩子类型</param>
        /// <param name="dele">钩子回调函数</param>
        public int InstallHook(HookType type, HookProc dele)
        {
            if (userHook == 0)
            {
                userHook = SetWindowsHookEx(
                    type,
                    dele,
                    GetModuleHandle(
                        Process.GetCurrentProcess().MainModule.ModuleName
                        ),
                    0
                    );
                if (userHook == 0)
                    UninstallKeyBoardHook();
            }
            return userHook;
        }

        /// <summary>
        /// 更具自由性的钩子绑定方法
        /// 您几乎可以为任何线程(也可以是全部线程)、任何模块(也可以是主模块)设置任意类型的钩子
        /// </summary>
        /// <param name="type">钩子类型</param>
        /// <param name="dele">钩子回调函数</param>
        /// <param name="moduleHandel">回调函数所在模块句柄</param>
        /// <param name="threadId">线程编号(0表示为所有线程设置钩子)</param>
        public void InstallHook(HookType type, HookProc dele, IntPtr moduleHandel, int threadId)
        {
            if (userHook == 0)
            {
                userHook = SetWindowsHookEx(
                    type,
                    dele,
                    moduleHandel,
                    threadId
                    );
                if (userHook == 0)
                    UninstallKeyBoardHook();
            }
        }

        /// <summary>
        /// 卸载键盘钩子
        /// </summary>
        public void UninstallKeyBoardHook()
        {
            UninstallHook(ref kbhHook);
        }

        /// <summary>
        /// 卸载鼠标钩子
        /// </summary>
        public void UninstallMouseHook()
        {
            UninstallHook(ref mshHook);
        }

        /// <summary>
        /// 卸载所有钩子
        /// </summary>
        public void UninstallAllHook()
        {
            UninstallKeyBoardHook();
            UninstallMouseHook();
            UninstallHook(ref userHook);
        }

        /// <summary>
        /// 卸载钩子
        /// </summary>
        /// <param name="idhook"></param>
        private void UninstallHook(ref int idhook)
        {
            if (idhook != 0)
            {
                UnhookWindowsHookEx(idhook);
                idhook = 0;
            }
        }

        #endregion

        #region 钩子发挥作用时的方法

        /// <summary>
        /// 默认键盘钩子回调函数
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        private int DefaultKeyBoardHookProc(int nCode, int wParam, IntPtr lParam)
        {
           
            if (nCode == 0)
            {
                EventMsg msg = (EventMsg)Marshal.PtrToStructure(lParam, typeof(EventMsg));
                if (wParam == 0x100)//WM_KEYDOWN=0x100
                {
                    barCode.VirtKey = msg.message & 0xff;//虚拟吗
                    barCode.ScanCode = msg.paramL & 0xff;//扫描码
                    StringBuilder strKeyName = new StringBuilder(225);
                    if (GetKeyNameText(barCode.ScanCode * 65536, strKeyName, 255) > 0)
                    {
                        barCode.KeyName = strKeyName.ToString().Trim(new char[] { ' ', '\0' });
                    }
                    else
                    {
                        barCode.KeyName = "";
                    }
                    byte[] kbArray = new byte[256];
                    uint uKey = 0;
                    GetKeyboardState(kbArray);


                    if (ToAscii(barCode.VirtKey, barCode.ScanCode, kbArray, ref uKey, 0))
                    {
                        barCode.Ascll = uKey;
                        barCode.Chr = Convert.ToChar(uKey);
                    }

                    TimeSpan ts = DateTime.Now.Subtract(barCode.Time);

                    if (ts.TotalMilliseconds > 50)
                    {
                        strBarCode = barCode.Chr.ToString();
                    }
                    else
                    {
                        if ((msg.message & 0xff) == 13 && strBarCode.Length > 3)
                        {
                            barCode.BarCode = strBarCode;
                            barCode.IsValid = true;
                           
                        }
                        strBarCode += barCode.Chr.ToString();
                    }
                    barCode.Time = DateTime.Now;
                    //if (BarCodeEvent != null)
                    //{
                    //    BarCodeEvent(barCode);//触发事件
                       
                    //}
                    if (barCode.IsValid)
                    {
                        if (gt_CardNO == barCode.BarCode)
                    
                        {
                            gt_CardNO = barCode.BarCode;//注释掉，则不判断是否重复

                            get_Card(barCode.BarCode);//注释掉，则不判断是否重复
                        }
                   
                        else
                    
                        {

                            gt_CardNO = barCode.BarCode;
                        
                            get_Card(barCode.BarCode);
                   
                        }
                    }



                    barCode.IsValid = false;
                   
                }
            }
           
            return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
        }

      

      
        #endregion
    }
}
