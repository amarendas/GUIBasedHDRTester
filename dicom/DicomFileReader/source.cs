using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DicomFileReader
{
    internal class source
    {
        #region Fields 
        public int sourceno { get; set; }
        public string sourceType{ get; set; }
        public string isotope { get; set; }
        public string unit { get; set; }
        public double sStrength { get; set; }
        DateTime calibDate, calibTime;
        public DateTime CalibDate
        {
            set { this.calibDate = Convert.ToDateTime(value); }
            get { return calibDate; }
        }
        public DateTime CalibTime
        {
            set { this.calibTime = Convert.ToDateTime(value); }
            get { return calibTime; }
        }
        #endregion
        public source()
        {
            sourceno = 0;
            sourceType = "Nil";
            isotope = "Nil";
            unit = "Nil";
            sStrength = 0;
            calibDate = DateTime.Now;
            calibTime = DateTime.Now;

        }
        public source (List<EvilDICOM.Core.Element.Sequence> ss, int i)
        {
            var data = ss[i].Select(x => x.SourceNumber).DData;
            sourceno = int.Parse(data.ToString());
            data = ss[i].Select(x => x.SourceType).DData;
            sourceType = data.ToString();
            data = ss[i].Select(x => x.SourceIsotopeName).DData;
            isotope = data.ToString();
            data = ss[i].Select(x => x.SourceStrengthUnits).DData;
            unit = data.ToString();
            data = ss[i].Select(x => x.ReferenceAirKermaRate).DData;
            sStrength = Convert.ToDouble(data);
            data = ss[i].Select(x => x.SourceStrengthReferenceDate).DData;
            CalibDate = Convert.ToDateTime(data);
            data = ss[i].Select(x => x.SourceStrengthReferenceTime).DData;
            CalibTime = Convert.ToDateTime(data);

        }

        


    }
}
