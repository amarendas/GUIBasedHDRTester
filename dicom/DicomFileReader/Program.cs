using System;
using EvilDICOM.Core;

using EvilDICOM.RT;
using System.Collections.Generic;// For implimenting List<T>
using System.Collections.Specialized;
using System.Xml.Linq;
using static EvilDICOM.Core.Element.Age;
using EvilDICOM.Core.Element;
using System.Collections;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using EvilDICOM.Core.Helpers;
using System.IO;

namespace DicomFileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            
           
            List<source> SourceList= new List<source>() ;


            DICOMObject dcm =new DICOMObject() ;
            try {
                dcm = DICOMObject.Read(@"D:\Projects\HDR-BRIT\TPS\TreatmentPlans Sent CDAC TPS 15 march 2023\CT-RTPLAN.dcm");
            }
            catch 
            { 
                Console.WriteLine(" File not found");
                return;
            }
           
            var sel = dcm.GetSelector();

            // Get GeneralDetails
            var strongName = dcm.FindFirst(TagHelper.PatientName )as PersonName;
            Console.WriteLine($"Patient: {strongName.FirstName} {strongName.LastName}");        
            

            // Get the source sequence
            var SorceSeq = sel.SourceSequence_;
            var noofSources = SorceSeq.Count;
            Console.WriteLine($"No of sources;{noofSources}");
            
            for (int i=0; i<noofSources; i++) // Read Property of Each Source
            {
                source mySource = new source(SorceSeq,i);
                SourceList.Add(mySource); // Create a list of Sources      
            } 

            //Print all the source Details
             foreach ( source s in SourceList )                  
                    Console.WriteLine($"Source no:{s.sourceno}, Isotope used: {s.isotope}, Strength:{s.sStrength} {s.unit}, Calibration Date: {(s.CalibDate).ToShortDateString()}  {s.CalibTime.ToShortTimeString()}" );


            //-----------------------------------------------------------------------------------
            var fracSeq = sel.FractionGroupSequence_;
            var noFracSeq = fracSeq.Count;
            for (int ii = 0; ii < noFracSeq; ii++)
            {
                var fracGNo = fracSeq[ii].Select(s => s.FractionGroupNumber);
                var No_Of_Fractions_Planned = fracSeq[ii].Select(s => s.NumberOfFractionsPlanned);
                
            }

            var doseSeq = sel.DoseReferenceSequence_;
            var noDoseSq = doseSeq.Count;
            for(int ii=0; ii<noDoseSq; ii++)
            {
                doseSeq[ii].Select(s => s.DoseReferenceNumber);
            }

            var applicationSeupSeq = sel.ApplicationSetupSequence_;
            var noofAppSetup = applicationSeupSeq[0].Data_.Count;
            List < ApplicationSetup>  appSetupList =new List<ApplicationSetup>();
            ApplicationSetup mySetup = new ApplicationSetup();
            //          var AppSetpuData=new ArrayList();
            for (int setNo = 0; setNo < noofAppSetup; setNo++)
            {

                var data = (applicationSeupSeq[setNo].Select(s => s.ApplicationSetupType).DData).ToString();
                mySetup.ApplicationSetupType = data;
                var data1 = applicationSeupSeq[setNo].Select(s => s.ApplicationSetupNumber).DData;
                mySetup.ApplicationSetupNumber = Convert.ToInt16(data1);
                var data2 = (applicationSeupSeq[setNo].Select(s => s.TotalReferenceAirKerma).DData);
                mySetup.TotalReferenceAirKerma = Convert.ToDouble(data2);

                // Catch the Channel sequence
                var ChannelSeq = applicationSeupSeq[setNo].Select(s => s.ChannelSequence_);
                mySetup.Process(ChannelSeq);
                var noOfCh = ChannelSeq[setNo].Data_.Count; ;

                Channel myChannel = new Channel();


                for (int chNo = 0; chNo < noOfCh; chNo++)
                {

                    var x = ChannelSeq[setNo].Select(s => s.ChannelNumber_[chNo]).DData;
                    myChannel.chNumber = Convert.ToInt32(x);
                    myChannel.chLength = Convert.ToInt32(ChannelSeq[setNo].Select(s => s.ChannelLength_[chNo]).DData);
                    myChannel.chTotalTime = Convert.ToDouble(ChannelSeq[setNo].Select(s => s.ChannelTotalTime_[chNo]).DData);
                    myChannel.soueceMovementType = (ChannelSeq[setNo].Select(s => s.SourceMovementType_[chNo]).DData).ToString();
                    myChannel.SourceApplicatorStepSize = Convert.ToDouble(ChannelSeq[setNo].Select(s => s.SourceApplicatorStepSize_[chNo]).DData);
                    myChannel.FinalCumulativeTimeWeight = Convert.ToDouble(ChannelSeq[setNo].Select(s => s.FinalCumulativeTimeWeight_[chNo]).DData);
                    myChannel.cplist = new List<CpData>();
                    var BrachContPtSeq = ChannelSeq[setNo].Select(s => s.BrachyControlPointSequence_[chNo]);
                    var noOfContPt = BrachContPtSeq.Data_.Count;


                    CpData cp = new CpData();
                    for (int k = 0; k < noOfContPt; k++)
                    {
                        cp.ptIndex = (int)(BrachContPtSeq.Select(s => s.ControlPointIndex_[k]).DData);
                        cp.relPosition = (double)(BrachContPtSeq.Select(s => s.ControlPointRelativePosition_[k]).DData);
                        cp.cumulativeTimeWeight = (double)(BrachContPtSeq.Select(s => s.CumulativeTimeWeight_[k]).DData);
                        myChannel.cplist.Add(cp); // each control point to the channel

                    }
                    mySetup.channelList.Add(myChannel);

                }
            }
            appSetupList.Add(mySetup);
            foreach (ApplicationSetup a in appSetupList)
            {
                Console.WriteLine($"Setup No: {a.ApplicationSetupNumber}  Type: {a.ApplicationSetupType}");
                foreach (Channel c in a.channelList)
                {
                    Console.WriteLine($"------- Channel No: {c.chNumber}, Total Time:{c.chTotalTime}, Cumulative Time: {c.FinalCumulativeTimeWeight}");
                    foreach (CpData d in c.cplist)
                    {
                        if (d.ptIndex % 2 != 0)
                        {
                            
                            double dwell = c.chTotalTime * d.cumulativeTimeWeight / c.FinalCumulativeTimeWeight;
                            Console.WriteLine($"-------------- Index: {d.ptIndex}, Position: {d.relPosition}, Dwell Time: {dwell}");
                        }

                    }
                    for (int x=0;x<c.cplist.Count; x = x + 2)
                    {
                        
                    }
                }
            }
            

        }// Main
    }//class:Program
}//Namespace
