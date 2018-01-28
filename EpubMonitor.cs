using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace EpubMonitor
{
    public partial class EpubMonitor : ServiceBase
    {
        private string BookPath { get; set; }
        private string KindleEmail { get; set; }
        public EpubMonitor(string[] args)
        {
            InitializeComponent();
            BookPath = args[0];
            KindleEmail = args[1];

            eventLog = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("EpubMonitorSource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "EpubMonitorSource", "EpubMonitorLog");
            }
            eventLog.Source = "EpubMonitorSource";
            eventLog.Log = "EpubMonitorLog";
        }

        protected override void OnStart(string[] args)
        {
            eventLog.WriteEntry("Epub monitoring started", EventLogEntryType.Information);
            eventLog.WriteEntry("Monitoring path: " + BookPath, EventLogEntryType.Information);

        }

        protected override void OnStop()
        {
        }
    }
}
