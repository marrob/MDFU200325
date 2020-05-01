namespace Konvolucio.MATL200319.Service
{
    using Common;
   // using Events;
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Text;
    using System.Threading;
    using NiCan;

    public interface IIoService : IDisposable
    {
        event EventHandler Stopped;
        event EventHandler Started;
        SafeQueue<CanMsg> TxQueue { get; }
        string GetDefaultDeviceName { get; }
        int? GetWaitForParseFrames { get; }
        int? GetDroppedFrames { get; }
        int? GetParsedFrames { get; }
        int? GetRxFrames { get;  }
        int? GetTxFrames { get; }
        int? GetWaitForTxFrames { get; }
        void Play();
        void Stop();
    }

    class IoService : IIoService
    {
        public string GetDefaultDeviceName => throw new NotImplementedException();

        public event EventHandler Stopped;
        public event EventHandler Started;
        public event EventHandler Reset;

        public int? GetWaitForParseFrames { get; private set; }
        public int? GetDroppedFrames { get; private set; }
        public int? GetParsedFrames { get; private set; }
        public int? GetRxFrames { get; private set; }
        public int? GetTxFrames { get; private set; }
        public int? GetWaitForTxFrames { get; private set; }

        string CanInterface = "CAN0";
        uint Baudrate = 500000;


        //private Explorer _explorer;

        private AutoResetEvent _shutdownEvent;
        private AutoResetEvent _readyToDisposeEvent;

        public SafeQueue<CanMsg> TxQueue { get; } = new SafeQueue<CanMsg>();

        private bool _isRunning;
        private bool _disposed;

        uint _handle = 0;

        private Explorer _explorer;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="explorer"></param>
        public IoService(Explorer explorer)
        {
            _explorer = explorer;
        }

        /// <summary>
        /// Play
        /// </summary>
        public void Play()
        {
            Debug.WriteLine(GetType().Namespace + "." + GetType().Name + "." + MethodBase.GetCurrentMethod().Name + "()");

            _shutdownEvent = new AutoResetEvent(false);
            _readyToDisposeEvent = new AutoResetEvent(false);
            //EventAggregator.Instance.Publish(new PlayAppEvent(this));
            try
            {
                var th = new Thread(new ThreadStart(DoWork))
                {
                    Priority = ThreadPriority.Normal,
                    Name = "IoService",
                };
                th.Start();
            }
            catch
            {
                OnStopped();
                throw;
            }
        }

        /// <summary>
        /// Stop
        /// </summary>
        public void Stop()
        {
            Debug.WriteLine(GetType().Namespace + "." +
                            GetType().Name + "." +
                            MethodBase.GetCurrentMethod().Name + "()");

            if (_shutdownEvent != null)
            {
                Debug.WriteLine(GetType().Namespace + "." +
                                GetType().Name + "." +
                                MethodBase.GetCurrentMethod().Name +
                                "(): Stop is pending.");
                /*Break Thread*/
                _shutdownEvent.Set();
            }

            /*Waiting for resources free*/
            if (_readyToDisposeEvent.WaitOne(5000))
            {
                Debug.WriteLine(GetType().Namespace + "." +
                                GetType().Name + "." +
                                MethodBase.GetCurrentMethod().Name +
                                "(): Stop is ready.");
            }
        }

        /// <summary>
        /// Ütemesen nézzük mi a helyzet a CAN-el
        /// </summary>
        private void DoWork()
        {
      


            uint attrValue = 0;
            _isRunning = true;
            Exception loopExp = null;

            #region Thread Started Publishing
            Action doMehtod = () => OnStarted();
            if (App.SyncContext != null)
                App.SyncContext.Post((e1) => { doMehtod(); }, null);
            else
                doMehtod();
            #endregion

            try
            {
                _handle = NiCanOpen(CanInterface);
            }
            catch (Exception ex)
            {
                loopExp = ex;
            }
            GetWaitForParseFrames = 0;
            GetDroppedFrames = 0;
            GetParsedFrames = 0;
            GetRxFrames = 0;
            GetTxFrames = 0;
            GetWaitForTxFrames  = 0;
            do
            {
                if (loopExp != null)
                    break;

                var rx = new NiCan.NCTYPE_CAN_STRUCT();

                /*** Get NC_ATTR_READ_PENDING ***/
                loopExp = NiCanStatusCheck(NiCan.ncGetAttribute(_handle, NiCan.NC_ATTR_READ_PENDING, 4, ref attrValue));
                if (loopExp != null)
                    break;

                GetWaitForParseFrames = (int)attrValue;

                if (GetWaitForParseFrames != 0)
                {
                    /*** Read ***/
                    loopExp = NiCanStatusCheck(NiCan.ncRead(_handle, NiCan.CanStructSize, ref rx));
                    if (loopExp != null)
                        break;
                    GetRxFrames++;

                    if ((rx.ArbitrationId & 0x20000000) == 0x20000000)
                    { /*Message is Extended */
                        /*Mask*/
                        UInt32 arbId = rx.ArbitrationId & 0x1FFFFFFF;

                        byte[] datatemp = new byte[]
                        {   rx.Data0,
                            rx.Data1,
                            rx.Data2,
                            rx.Data3,
                            rx.Data4,
                            rx.Data5,
                            rx.Data6,
                            rx.Data7, };
                        byte[] data = new byte[rx.DataLength];

                        Buffer.BlockCopy(datatemp, 0, data, 0, rx.DataLength);

                        IoLog.Instance.WirteLine("RX " + arbId.ToString("X8") + " " + Tools.ByteArrayLogString(data));

                        doMehtod = () =>
                        {
                            if (_explorer.UpdateTask(new CanMsg(arbId, data)))
                                GetParsedFrames++;
                            else
                                GetDroppedFrames++;
                        };
                        if (App.SyncContext != null)
                            App.SyncContext.Post((e1) => { doMehtod(); }, null);
                        else
                            doMehtod();


                        /*** Write ***/
                        GetWaitForTxFrames = TxQueue.Count;
                        if ((GetWaitForTxFrames = TxQueue.Count) != 0)
                        {
                            var tx = TxQueue.Dequeue();
                            var niTx = new NiCan.NCTYPE_CAN_FRAME();
                            tx.ArbId |= 0x20000000;
                            niTx.ArbitrationId = tx.ArbId;
                            niTx.DataLength = 8;
                            niTx.IsRemote = NiCan.NC_FALSE;
                            niTx.Data0 = tx.Data[0];
                            niTx.Data1 = tx.Data[1];
                            niTx.Data2 = tx.Data[2];
                            niTx.Data3 = tx.Data[3];
                            niTx.Data4 = tx.Data[4];
                            niTx.Data5 = tx.Data[5];
                            niTx.Data6 = tx.Data[6];
                            niTx.Data7 = tx.Data[7];

                            IoLog.Instance.WirteLine("TX " + tx.ArbId.ToString("X8") + " " + Tools.ByteArrayLogString(tx.Data));
                            loopExp = NiCanStatusCheck(NiCan.ncWrite(_handle, NiCan.CanFrameSize, ref niTx));
                            if (loopExp != null)
                                break;
                            GetTxFrames++;
                        }
                    }
                    else
                    {
                        GetDroppedFrames++;
                    }

                }


                if (_shutdownEvent.WaitOne(0))
                {
                    Debug.WriteLine(GetType().Namespace + "." +
                                    GetType().Name + "." +
                                    MethodBase.GetCurrentMethod().Name +
                                    "(): DoWork is now shutdown!");
                    break;
                }

            } while (true);

            /*Probléma megjelnítése*/
            if (loopExp != null)
            {
                AppLog.Instance.WirteLine("DoWork()");
                
            }
            #region Resource Freeing
            if (_handle != 0)
            {
                NiCanClose(_handle);
                _handle = 0;
            }
            _readyToDisposeEvent.Set();
            _isRunning = false;
            #endregion

            #region Thread Terminate Publishing
            doMehtod = () =>
            {
                try
                {

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    /*Minden áron jelezni kell! hogy megállt.*/
                    OnStopped();
                    Debug.WriteLine(GetType().Namespace + "." + GetType().Name + "." + MethodBase.GetCurrentMethod().Name + "(): Loop is colsed...");
                }
            };
            if (App.SyncContext != null)
                App.SyncContext.Post((e1) => { doMehtod(); }, null);
            else
                doMehtod();
            #endregion
        }

        Exception NiCanStatusCheck(int status)
        {
            if(status != 0)
                AppLog.Instance.WirteLine(NiCanTools.StatusToString(status));

            switch ((uint)status)
            {
                case 0xBFF62023:
                    {
                        /* The Interface is invalid or unknown.*/
                        /* 1. Az Adaptert menetköben eltávolították */
                        return new NiCanIoException(status);
                       
                    }
                default:
                   {
                        return null;
                   }
            }
        }

        #region NiCan
        /// <summary>
        /// Open
        /// </summary>
        /// <returns> handle </returns>
        uint NiCanOpen(string canInterface)
        {
            int status = 0;
            uint handle = 0;

            /*** Config ***/
            uint[] AttrIdList = { NiCan.NC_ATTR_BAUD_RATE, NiCan.NC_ATTR_START_ON_OPEN };
            uint[] AttrValueList = { Baudrate, NiCan.NC_FALSE };
            uint NumAttrs = 2;
            status = NiCan.ncConfig(new StringBuilder(canInterface), NumAttrs, AttrIdList, AttrValueList);
            if (status != 0)
                throw new NiCanIoException(status);

            /*** Open Object ***/
            status = NiCan.ncOpenObject(new StringBuilder(canInterface), ref handle);
            if (status != 0)
                 throw new NiCanIoException(status);

            /*** Start ***/
            status = NiCan.ncAction(handle, NiCan.NC_OP_START, 0);
            if (status != 0)
                throw new NiCanIoException(status);
            return handle;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        void NiCanClose(uint handle)
        {
            NiCan.ncAction(handle, NiCan.NC_OP_STOP, 0);
            NiCan.ncCloseObject(handle);
       }

        #endregion

        #region OnEvent
        private void OnStopped()
        {
            if (Stopped != null)
            {
                Stopped(this, EventArgs.Empty);
            }
        }

        private void OnStarted()
        {
            if (Started != null)
            {
                Started(this, EventArgs.Empty);
            }
        }

        private void OnReseted()
        {
            if (Reset != null)
            {
                Reset(this, EventArgs.Empty);
            }
        }
        #endregion

        #region Disopse
        /// <summary>
        ///  Public implementation of Dispose pattern callable by consumers. 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Protected implementation of Dispose pattern. 
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
                if (_isRunning)
                {
                    Debug.WriteLine(GetType().Namespace + "." +
                                    GetType().Name + "." +
                                    MethodBase.GetCurrentMethod().Name + 
                                    "(): Running-> Stop()");
                    Stop();
                }

                if (_shutdownEvent != null)
                {
                    _shutdownEvent.Dispose();
                    _shutdownEvent = null;
                }

                if (_readyToDisposeEvent != null)
                {
                    _readyToDisposeEvent.Dispose();
                    _readyToDisposeEvent = null;
                }
            }
            _disposed = true;
        }
        #endregion
    }
}
