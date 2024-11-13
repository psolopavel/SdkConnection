using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Threading;
using GeneralDef;
using NETSDKHelper;
using System.Diagnostics;
using System.Reflection;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace DemoTestConsole
{
   class Program
   {
      /******************* Define member variables start *******************************/
      private List<DeviceInfo> m_deviceInfoList = new List<DeviceInfo>(); // FIX


      public Int32 m_curSelectedTreeDeviceIndex = -1;
      public Int32 m_curSelectedTreeChannelIndex = -1;


      PlayBackInfo m_playBackInfo = new PlayBackInfo();
      List<NETDEMO.NETDEMO_UPDATE_TIME_INFO> m_downloadInfoList = new List<NETDEMO.NETDEMO_UPDATE_TIME_INFO>();
      static readonly object m_notLoggeddeviceInfoListlocker = new object();
      NETDEVSDK.NETDEV_AlarmMessCallBack_PF alarmCB = null;
      NETDEVSDK.NETDEV_ExceptionCallBack_PF excepCB = null;
      NETDEVSDK.NETDEV_FaceSnapshotCallBack_PF faceSnapCB = null;
      public NETDEVSDK.NETDEV_DISCOVERY_CALLBACK_PF discoveryCB = null;
      NETDEVSDK.NETDEV_PassengerFlowStatisticCallBack_PF passengerCB = null;

      private List<DeviceInfo> m_notLoggeddeviceInfoList = new List<DeviceInfo>();

      String strSubItemName = "";
      int iItemIndex = -1;

      List<string> usedDevIndList = new List<string>();
      List<int> usedTrackIndList = new List<int>();
      List<int> usedTimeIndList = new List<int>();

      List<string> camList = new List<string>();
      List<List<long[]>> timeList = new List<List<long[]>>();
      List<int> mainIndList = new List<int>();
      int alarmState = 0;
      long alarmResetTime = 0;
      int actionType = 0;
      int streamMode = 0;

      string localOnlineStatusPath = "";
      string localAlarmStatusPath = "";
      string localAlarmTaskPath = "";

      int timeListInd = -1;

      int lastDeviceInd = -1;
      string lastDeviceName = "";

      bool enableLogging = true;

      enum FileStatus
      {
         CAMERA_NOT_FOUND,
         DATA_FROM_CAMERA_NOT_FOUND,
         CONNECT_ERROR,
         DATA_DOWNLOADING_ERROR,
         CAMERA_IS_CONNECTED,
         DATA_IS_DOWNLOADING,
         DOWNLOADING_IS_COMPLETE
      }

      private readonly String cloudLogin = "wt45q12";
      private readonly String cloudPassword = "4G2hn3Ew5d11";
      private readonly String cloudUrl_1 = "www.star4live.com";
      private readonly String cloudUrl_2 = "eu1.ezcloud.uniview.com";
      static void Main(string[] args)
      {
         Program program = new Program();
         program.InitNetDemo();  // Вызов InitNetDemo через экземпляр Program
         Console.WriteLine("Hello All is good");
      }

      private void InitNetDemo()
      {
         int iRet = NETDEVSDK.NETDEV_Init();
         if (NETDEVSDK.TRUE != iRet)
         {
            Console.WriteLine("Ошибка инициализации NETDEVSDK!");
         }

         setSavePath();
         setSaveKeepLiveTime();
         setSaveTimeOut();
         setSaveOperLog();
      }

      private void setSavePath()
      {
         string m_currentPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
         // Логика для инициализации путей
      }

      private void setSaveKeepLiveTime()
      {
         int iWaitTime = Convert.ToInt32(15);
         int iTryTime = Convert.ToInt32(3);
         // Логика для установки времени ожидания
      }

      private void setSaveTimeOut()
      {
         int iRevTimeOut = Convert.ToInt32(5);
         int iFileReportTimeOut = Convert.ToInt32(60);
         // Логика для установки таймаута
      }

      private void setSaveOperLog()
      {
         bool bAutoSaveCkBox = true;
         bool bFailureLogCkBox = true;
         bool bSuccessLogCkBox = true;
         // Логика для настройки логирования
      }
   }
}