using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Game.LogSystem
{
    public class FileWriter : IDisposable
    {
        private const string DATA_FORMAT = "yyyy-MM-dd";
        private const string LOG_TIME_FORMAT = "{0:dd/MM/yyyy HH:mm:ss:ffff} [{1}]: {2}\r";
        private const  int  MAX_MESSAGE_LENGHT = 3500;
        
        private FileAppender _fileAppender;
        private Thread _workingThread;
        private readonly ConcurrentQueue<LogMessage> _logMessages = new ConcurrentQueue<LogMessage>();
        private readonly ManualResetEvent _mre = new ManualResetEvent(true);

        private Thread _chekNewDateThread;
        private DateTime _prevData;
        
        private string _folder;
        private string _filePath;
        private bool _disposing;

        public FileWriter(string Folder)
        {
            _folder = Folder;
            ManagePath();
            _workingThread = new Thread(StoreMessage)
            {
                IsBackground = true,
                Priority = ThreadPriority.BelowNormal
            };
            _workingThread.Start();

            _chekNewDateThread = new Thread(CheckNewDay)
            {
                IsBackground = true,
                Priority = ThreadPriority.BelowNormal
            };
            _chekNewDateThread.Start();
        }

        private void ManagePath()
        {
            _prevData = DateTime.UtcNow;
            _filePath = $@"{_folder}/{DateTime.UtcNow.ToString(DATA_FORMAT)}";
        }

        public void Write(LogMessage Messeg)
        {
            try
            {
                if (Messeg.Message.Length > MAX_MESSAGE_LENGHT)
                {
                    var preview = Messeg.Message.Substring(0 , MAX_MESSAGE_LENGHT);
                    LogMessage newMessage = new LogMessage(Messeg.Type,
                        $"Message to long {Messeg.Message.Length}. Preview: {preview}");
                    newMessage.UpdaiteTime();
                    
                    _logMessages.Enqueue(newMessage);
                }
                else
                {
                    _logMessages.Enqueue(Messeg);
                }
                _mre.Set();
            }
            catch (Exception e)
            {
                // ignored
            }
        }

        public void StoreMessage()
        {
            while (!_disposing)
            {
                while (!_logMessages.IsEmpty)
                {
                    try
                    {
                        LogMessage message;
                        if (!_logMessages.TryPeek(out message))
                        {
                            Thread.Sleep(5);
                        }

                        if (_fileAppender == null || _fileAppender.FileName != _filePath)
                        {
                            _fileAppender = new FileAppender(_filePath);
                        }
                        
                        var messageToWrite = string.Format(LOG_TIME_FORMAT , message.Time , message.Type , message.Message);

                        if (_fileAppender.Append(messageToWrite))
                        {
                            _logMessages.TryDequeue(out message);
                        }
                        else
                        {
                            Thread.Sleep(5);
                        }
                    }
                    catch (Exception e)
                    {
                       break;
                    }
                }

                _mre.Reset();
                _mre.WaitOne(500);
            }
        }

        private void CheckNewDay()
        {
            while (_disposing)
            {
                var currentDate = DateTime.UtcNow;
                if (currentDate.Day != _prevData.Day)
                {
                    ManagePath();
                }
                Thread.Sleep(1000);
            }
        }
        
        public void Dispose()
        {
            _disposing = true;
            _workingThread?.Abort();
            _chekNewDateThread?.Abort();
            GC.SuppressFinalize(this);
        }
    }
}