using System;
using System.Collections.Generic;
using DrilledHoleSurvey;
using DrilledHoleSurvey.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrilledHoleSurvey_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckAzimuthValue_Pass()
        {
            double startValue = 0;
            List<View_HoleDepthInfo> depthInfoList = new List<View_HoleDepthInfo>()
            {
                new View_HoleDepthInfo
                {
                     HoleName = "Hole1",
                     Depth = 10,
                     Dip = 90,
                     Azimuth = 0
                },
                new View_HoleDepthInfo
                {
                     HoleName = "Hole1",
                     Depth = 10,
                     Dip = 90,
                     Azimuth = 1
                },
            };
            DrilledHoleSurveyClass.CheckAzimuthValue(startValue, depthInfoList);
            Assert.IsTrue(depthInfoList.Exists(a => a.AzimuthStatus == "false") == false);
        }

        [TestMethod]
        public void CheckAzimuthValue_Fail()
        {
            double startValue = 0;
            List<View_HoleDepthInfo> depthInfoList = new List<View_HoleDepthInfo>()
            {
                new View_HoleDepthInfo
                {
                     HoleName = "Hole1",
                     Depth = 10,
                     Dip = 90,
                     Azimuth = 0
                },
                new View_HoleDepthInfo
                {
                     HoleName = "Hole1",
                     Depth = 10,
                     Dip = 90,
                     Azimuth = 6
                },
            };
            DrilledHoleSurveyClass.CheckAzimuthValue(startValue, depthInfoList);
            Assert.IsTrue(depthInfoList.Exists(a => a.AzimuthStatus == "false") == true);
        }

        [TestMethod]
        public void CheckDipValue_Pass()
        {
            double startValue = 90;
            List<View_HoleDepthInfo> depthInfoList = new List<View_HoleDepthInfo>()
            {
                new View_HoleDepthInfo
                {
                     HoleName = "Hole1",
                     Depth = 10,
                     Dip = 90,
                     Azimuth = 0
                },
                new View_HoleDepthInfo
                {
                     HoleName = "Hole1",
                     Depth = 20,
                     Dip = 89,
                     Azimuth = 0
                },
                new View_HoleDepthInfo
                {
                     HoleName = "Hole1",
                     Depth = 30,
                     Dip = 91,
                     Azimuth = 0
                },
                new View_HoleDepthInfo
                {
                     HoleName = "Hole1",
                     Depth = 40,
                     Dip = 92,
                     Azimuth = 0
                },
                new View_HoleDepthInfo
                {
                     HoleName = "Hole1",
                     Depth = 50,
                     Dip = 91,
                     Azimuth = 0
                },
            };
            DrilledHoleSurveyClass.CheckDipValue(startValue, depthInfoList);
            Assert.IsTrue(depthInfoList.Exists(a => a.DipStatus == "false") == false);
        }

        [TestMethod]
        public void CheckDipValue_Fail()
        {
            double startValue = 90;
            List<View_HoleDepthInfo> depthInfoList = new List<View_HoleDepthInfo>()
            {
                new View_HoleDepthInfo
                {
                     HoleName = "Hole1",
                     Depth = 10,
                     Dip = 90,
                     Azimuth = 0
                },
                new View_HoleDepthInfo
                {
                     HoleName = "Hole1",
                     Depth = 20,
                     Dip = 90,
                     Azimuth = 0
                },
                new View_HoleDepthInfo
                {
                     HoleName = "Hole1",
                     Depth = 30,
                     Dip = 90,
                     Azimuth = 0
                },
                new View_HoleDepthInfo
                {
                     HoleName = "Hole1",
                     Depth = 40,
                     Dip = 90,
                     Azimuth = 0
                },
                new View_HoleDepthInfo
                {
                     HoleName = "Hole1",
                     Depth = 50,
                     Dip = 85,
                     Azimuth = 0
                },
            };
            DrilledHoleSurveyClass.CheckDipValue(startValue, depthInfoList);
            Assert.IsTrue(depthInfoList.Exists(a => a.DipStatus == "false") == true);
        }

    }
}
