using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace IP_App.DataClasses
{
    public class PingStatus
    {
        public string Address { get; set; }
        public long RoadTripTime { get; set; }
        public int TimeToLive { get; set; }
        public bool DontFragment { get; set; }
        public int BufferSize { get; set; }
        public IPStatus IPStatus { get; set; }

        public PingStatus(string address)
        {
            Address = address;
        }

        public PingStatus(string address, long roadTripTime) : this (address)
        {
            RoadTripTime = roadTripTime;
        }

        public PingStatus(string address, long roadTripTime, int timeToLive) : this (address ,roadTripTime)
        {
            TimeToLive = timeToLive;
        }

        public PingStatus(string address, long roadTripTime, int timeToLive, bool dontFragment) : this (address, roadTripTime, timeToLive)
        {
            DontFragment = dontFragment;
        }

        public PingStatus(string address, long roadTripTime, int timeToLive, bool dontFragment, int bufferSize) : this (address, roadTripTime, timeToLive, dontFragment)
        {
            BufferSize = bufferSize;
        }

        public PingStatus(string address, long roadTripTime, int timeToLive, bool dontFragment, int bufferSize, IPStatus iPStatus) : this (address, roadTripTime, timeToLive, dontFragment)
        {
            IPStatus = iPStatus;
        }

        public override string ToString()
        {
            return $"Address: {Address}\nRoad Trip Time: {RoadTripTime}\nTime To Live: {TimeToLive}\nDon't Fragment: {DontFragment}\nBuffer Size: {BufferSize}\nIP Status: {IPStatus}";
        }
    }
}
