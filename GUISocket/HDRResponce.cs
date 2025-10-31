using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUISocket
{
    internal class HDRResponce
    {
        byte sensor1;
        byte sensor2;
        int indxEnc;
        int srcEnc;
        int dmyEnc;
        int dwellT;
        int totalT;
        int errCode;

        int pcd = 180; //PCD of Holes
        int dWheelDia = 90;// 90mm drive wheel dia
        int sWheelDia = 90;
        int dPPR = 4000; // pulse per rev of dummy encoder
        int sPPR = 4000;

        public byte Sensor1 { get => sensor1; }
        public byte Sensor2 { get => sensor2; }
        public int IndxEnc { get => indxEnc;  }
        public int SrcEnc { get => srcEnc;  }
        public int DmyEnc { get => dmyEnc;  }
        public int DwellT { get => dwellT;  }
        public int TotalT { get => totalT;  }
        public int ErrCode { get => errCode;  }

        public HDRResponce()
        {
            string dtRecievd = "#,0,0,0,0,0,0,0,0";
            string[] chunks = dtRecievd.Split(",");
            sensor1 = byte.Parse(chunks[1]);
            sensor1 = byte.Parse(chunks[2]);
            indxEnc = int.Parse(chunks[3]);
            srcEnc = int.Parse(chunks[4]);// Source out will generate negative value
            dmyEnc = int.Parse(chunks[5]);
            dwellT = int.Parse(chunks[6]);
            totalT = int.Parse(chunks[7]);
            errCode = int.Parse(chunks[8]);

        }
        public void Update(string dtRecievd)
        {
            string[] chunks = dtRecievd.Split(",");
            sensor1 = byte.Parse(chunks[1]);
            sensor2 = byte.Parse(chunks[2]);
            indxEnc = int.Parse(chunks[3]);
            srcEnc = int.Parse(chunks[4]);
            dmyEnc = int.Parse(chunks[5]);
            dwellT = int.Parse(chunks[6]);
            totalT = int.Parse(chunks[7]);
            errCode = int.Parse(chunks[8]);

        }
        public double IndexerPosDeg()
        {
            // 1,00,000 encoder counts = 360Deg 
            return Math.Round(indxEnc * Convert.ToSingle(0.0036),2); 
        }

        public double IndexerPosMM()
        {

            double val = pcd * 3.14 / 100000;
            return Math.Round(indxEnc * val, 2);
        }

        public double DummyPosMM()
        {
            //double val= (dWheelDia*3.14)/dPPR;
            double mmPerEnc =1.0/14.7; // experimentaly measured
            return  Math.Round(mmPerEnc*Math.Abs(dmyEnc)-315, 2);
        }

        public double SourcePosMM()
        {
            //double val=  (sWheelDia * 3.14) / sPPR; // Direction is inverted due to physical connection.
            double mmPerEnc =1.0/15.0; // experimentaly measured
            return Math.Round(mmPerEnc * Math.Abs(srcEnc)-278, 2);
        }



    }
}
