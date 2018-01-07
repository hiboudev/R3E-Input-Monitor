using da2mvc.core.events;
using R3E_Inputs_Monitor.r3e.events;
using R3E_Inputs_Monitor.r3e.socket.Data;
using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using System.Windows.Threading;

namespace R3E_Inputs_Monitor.r3e.socket
{
    class R3eApiSocket:IEventDispatcher
    {
        public event EventHandler MvcEventHandler;
        public static readonly int EVENT_DATA_UPDATED = EventId.New();

        private DispatcherTimer timer;
        public Shared Data;
        private MemoryMappedFile _file;
        private byte[] _buffer;
        private bool Mapped
        {
            get { return (_file != null); }
        }

        public R3eApiSocket()
        {
            timer = new DispatcherTimer();
        }

        private void AttemptR3eConnection(object sender, EventArgs e)
        {
            if (Utilities.IsRrreRunning() && !Mapped)
            {
                Console.WriteLine("Found RRRE.exe, mapping shared memory...");

                if (Map())
                {
                    Console.WriteLine("Memory mapped successfully");
                    timer.Stop();

                    _buffer = new Byte[Marshal.SizeOf(typeof(Shared))];
                }
            }

            if (Mapped)
            {
                StartMonitoring();
            }
        }

        private void StartMonitoring()
        {
            timer.Interval = new TimeSpan(0, 0, 0, 0, 8);
            timer.Tick -= AttemptR3eConnection;
            timer.Tick += Monitor;
            timer.Start();
        }

        private bool Read()
        {
            try
            {
                var _view = _file.CreateViewStream();
                BinaryReader _stream = new BinaryReader(_view);
                _buffer = _stream.ReadBytes(Marshal.SizeOf(typeof(Shared)));
                GCHandle _handle = GCHandle.Alloc(_buffer, GCHandleType.Pinned);
                Data = (Shared)Marshal.PtrToStructure(_handle.AddrOfPinnedObject(), typeof(Shared));
                _handle.Free();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void Monitor(object sender, EventArgs e)
        {
            if (Read())
            {
                DispatchEvent(new SocketEventArgs(EVENT_DATA_UPDATED, this));
                //Console.WriteLine("Name: {0}", System.Text.Encoding.UTF8.GetString(_data.PlayerName).TrimEnd('\0'));

                //if (_data.Gear >= -1)
                //{
                //    Console.WriteLine("Gear: {0}", _data.Gear);
                //}

                //if (_data.EngineRps > -1.0f)
                //{
                //    Console.WriteLine("RPM: {0}", Utilities.RpsToRpm(_data.EngineRps));
                //    Console.WriteLine("Speed: {0}", Utilities.MpsToKph(_data.CarSpeed));
                //}
                //Debug.WriteLine(_data.ThrottlePedal);
                //Debug.WriteLine(_data.BrakePedal);
                //Debug.WriteLine(_data.ClutchPedal);

                //Console.WriteLine("");
            }
        }

        private bool Map()
        {
            try
            {
                _file = MemoryMappedFile.OpenExisting(Constant.SharedMemoryName);
                return true;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
        }

        public void Connect()
        {
            // TODO Gestion des déconnections, fin du moniroting, etc.
            timer.Interval = new TimeSpan(0,0,1);
            timer.Tick += AttemptR3eConnection;
            timer.Start();
        }

        public void DispatchEvent(BaseEventArgs args)
        {
            MvcEventHandler?.Invoke(this, args);
        }
    }
}
