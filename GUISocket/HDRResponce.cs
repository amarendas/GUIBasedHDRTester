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
        /*int dWheelDia = 90;// 90mm drive wheel dia
        int sWheelDia = 90;
        int dPPR = 4000; // pulse per rev of dummy encoder
        int sPPR = 4000;
        */
        double mmPerEncD = 1.0 / 14.7; // experimentaly measured
        double mmPerEncS = 1.0 / 15.0; // experimentaly measured
        
        double offsetS;        
        double offsetD;

        public byte Sensor1 { get => sensor1; }
        public byte Sensor2 { get => sensor2; }
        public int IndxEnc { get => indxEnc;  }
        public int SrcEnc { get => srcEnc;  }
        public int DmyEnc { get => dmyEnc;  }
        public int DwellT { get => dwellT;  }
        public int TotalT { get => totalT;  }
        public int ErrCode { get => errCode;  }
        public double OffsetS { get => offsetS; set => offsetS = value; }
        public double OffsetD { get => offsetD; set => offsetD = value; }

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
            offsetS = 278;//Default Values
            offsetD = 315; // Default Values

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
            
            return  Math.Round(mmPerEncD*Math.Abs(dmyEnc)- OffsetD, 2);
        }

        public double SourcePosMM()
        {
            
            return Math.Round(mmPerEncS * Math.Abs(srcEnc)-OffsetS, 2);
        }



    }
}
