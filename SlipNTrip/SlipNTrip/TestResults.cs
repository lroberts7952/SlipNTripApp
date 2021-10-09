using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SQLite;

namespace SlipNTrip
{
    public class TestResults
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int TestNumber { get; set; }
        public string Date { get; set; }
        public double MotorSpeed { get; set; }
        public string Direction { get; set; }
        public bool StepTaken { get; set; }
        public double TimeBetweenStep { get; set; }
        public double DistanceBetweenStep { get; set; }
    }
}
