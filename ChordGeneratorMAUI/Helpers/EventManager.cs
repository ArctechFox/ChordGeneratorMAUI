using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordGeneratorMAUI.Helpers
{
    internal sealed class EventManager
    {
        private EventManager() { }

        private static readonly EventManager _instance = new EventManager();

        internal static EventManager Instance { get { return _instance; } }

        private IEventAggregator _eventAggregator;
        internal IEventAggregator EventAggregator
        {
            get
            {
                if (_eventAggregator == null)
                    _eventAggregator = new EventAggregator();

                return _eventAggregator;
            }
        }
    }

    #region Application Events

    public class ChartGeneratedEvent : PubSubEvent { }
    public class TimerStartEvent : PubSubEvent { }
    public class TimerPauseEvent : PubSubEvent { }
    public class ResetToDefaultSettingsEvent : PubSubEvent { }
    public class BeatElapsedEvent : PubSubEvent<int> { }
    public class BarCountChangedEvent : PubSubEvent<int> { }
    public class BPMChangedEvent : PubSubEvent<int> { }
    public class KeyChangedEvent : PubSubEvent<string> { }

    //public class DataReceivedEvent : PubSubEvent<DataReceivedEvent_Parameters> { }
    //public class FreezeEvent : PubSubEvent<bool> { }
    //public class StallEvent : PubSubEvent<bool> { }
    //public class CallStackSetEvent : PubSubEvent<int> { }
    //public class PointSelectedEvent : PubSubEvent<Tuple<int, int>> { }
    //public class ClearEvent : PubSubEvent { }
    //public class ErrorEvent : PubSubEvent<Tuple<Exception, string>> { }


    #endregion

    // These are customized to encapsulate multi-property "payloads" as one object
    #region Special PubSubEvent Payload Parameters

    //public class DataReceivedEvent_Parameters
    //{
    //    public Stats StatsCurrent { get; set; }
    //    public List<Stats> StatsAll { get; set; }

    //    public float FPS { get; set; }
    //    public float HighFPS { get; set; }
    //    public float LowFPS { get; set; }

    //    public float CpuAvg { get; set; }
    //    public float GpuAvgDraw { get; set; }
    //    public float GpuAvgTransfer { get; set; }

    //    public GpuMetricsData GpuMetricsAvg { get; set; }
    //}
    #endregion
}
