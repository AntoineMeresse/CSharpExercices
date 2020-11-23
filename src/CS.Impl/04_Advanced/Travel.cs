using System;
using System.Collections.Generic;

namespace CS.Impl._04_Advanced
{
    public class Travel
    {
        public TravelRoadmap BuildTravelRoadmap(City initial, City destination)
        {
            DistanceHelper dh = new DistanceHelper();
            Distance d = dh.GetDistance(initial, destination);

            List<TransportMode> transports; 

            if (d == Distance.Short)
            {
                transports = new List<TransportMode> { TransportMode.Foot, TransportMode.Car, TransportMode.Train };
            }
            else if (d == Distance.Medium)
            {
                transports = new List<TransportMode> { TransportMode.Plane, TransportMode.Car, TransportMode.Train };
            }
            else
            {
                transports = new List<TransportMode> { TransportMode.Plane, TransportMode.Boat};
            }
            return new TravelRoadmap { Modes = transports };
        }
    }

    public class TravelRoadmap
    {
        public IEnumerable<TransportMode> Modes { get; set; }
    }

    public enum City
    {
        Barcelona,
        London,
        Sydney
    }

    public enum TransportMode
    {
        Foot,
        Car,
        Train,
        Boat,
        Plane
    }

    public class DistanceHelper
    {
        public Distance GetDistance(City initial, City destination)
        {
            if (initial == destination) return Distance.Short;
            if (initial == City.Barcelona && destination == City.London) return Distance.Medium;
            if (destination == City.Barcelona && initial == City.London) return Distance.Medium;
            return Distance.Long;
        }
    }

    public enum Distance
    {
        Short,
        Medium,
        Long
    }
}